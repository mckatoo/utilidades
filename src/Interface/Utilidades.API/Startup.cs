using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;
using Tapioca.HATEOAS;
using Utilidades.ApplicationCore.Business.Implementattions;
using Utilidades.ApplicationCore.Security.Configuration;
using Utilidades.API.HyperMedia;
using Utilidades.Infrastructure.Business;
using Utilidades.Infrastructure.Business.Implementattions;
using Utilidades.Infrastructure.Data;
using Utilidades.Infrastructure.Repository;
using Utilidades.Infrastructure.Repository.Generic;

namespace Utilidades.API {
    public class Startup {
        private readonly ILogger _logger;
        private readonly string _connectionString;
        public IHostingEnvironment _environment { get; }
        public IConfiguration _configuration { get; }
        public Startup (
            IConfiguration configuration,
            IHostingEnvironment env,
            ILogger<Startup> logger
        ) {
            _configuration = configuration;
            _environment = env;
            _logger = logger;
            _connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<MySQLContext> (options =>
                options.UseMySQL (_connectionString)
            );
            ConfigureAutorization (services);

            services.AddMvc (options => {
                    options.RespectBrowserAcceptHeader = true;
                    options.FormatterMappings.SetMediaTypeMappingForFormat ("xml", MediaTypeHeaderValue.Parse ("text/xml"));
                    options.FormatterMappings.SetMediaTypeMappingForFormat ("json", MediaTypeHeaderValue.Parse ("application/json"));
                })
                .AddXmlSerializerFormatters ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            var filterOptions = new HyperMediaFilterOptions ();
            filterOptions.ObjectContentResponseEnricherList.Add (new UsersTypeEnricher ());
            filterOptions.ObjectContentResponseEnricherList.Add (new UserEnricher ());
            services.AddSingleton (filterOptions);

            services.AddApiVersioning ();

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info {
                    Title = "Sistema de Utilidades",
                        Version = "v1"
                });
            });

            //Dependency Injection
            services.AddScoped<IUserBusiness, UserBusinessImpl> ();
            services.AddScoped<IUsersTypeBusiness, UsersTypeBusinessImpl> ();
            services.AddScoped<ILoginBusiness, LoginBusinessImpl> ();
            services.AddScoped<IUserRepository, UserRepositoryImpl> ();
            services.AddScoped<IUsersTypeRepository, UsersTypeRepositoryImpl> ();
            //Dependency Injection of Generic Repository
            services.AddScoped (typeof (IRepository<>), typeof (GenericRepository<>));
        }

        private void ConfigureAutorization (IServiceCollection services) {
            var signingConfigurations = new SigningConfigurations ();
            services.AddSingleton (signingConfigurations);

            var tokenConfigurations = new TokenConfiguration ();

            new ConfigureFromConfigurationOptions<TokenConfiguration> (
                    _configuration.GetSection ("TokenConfigurations")
                )
                .Configure (tokenConfigurations);

            services.AddSingleton (tokenConfigurations);

            services.AddAuthentication (authOptions => {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (bearerOptions => {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization (auth => {
                auth.AddPolicy ("Bearer", new AuthorizationPolicyBuilder ()
                    .AddAuthenticationSchemes (JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser ().Build ());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            ExecuteMigrations (app, env);

            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Utils API v1");
            });

            var option = new RewriteOptions ();
            option.AddRedirect ("^$", "swagger");
            app.UseRewriter (option);

            app.UseHttpsRedirection ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}"
                );
            });
        }

        private void ExecuteMigrations (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();

                try {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection (_connectionString);
                    var evolve = new Evolve.Evolve ("evolve.json",
                        evolveConnection, msg => _logger.LogInformation (msg)
                    ) {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate ();
                } catch (Exception ex) {
                    _logger.LogCritical ("Database migation failed.", ex);
                    throw;
                }

            } else {
                app.UseHsts ();
            }
        }
    }
}