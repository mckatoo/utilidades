using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
using Utilidades.API.Business;
using Utilidades.API.Business.Implementattions;
using Utilidades.API.HyperMedia;
using Utilidades.API.Model.Context;
using Utilidades.API.Repository.Generic;

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

            services.AddMvc (options => {
                    options.RespectBrowserAcceptHeader = true;
                    options.FormatterMappings.SetMediaTypeMappingForFormat ("xml", MediaTypeHeaderValue.Parse ("text/xml"));
                    options.FormatterMappings.SetMediaTypeMappingForFormat ("json", MediaTypeHeaderValue.Parse ("application/json"));
                })
                .AddXmlSerializerFormatters ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            var filterOptions = new HyperMediaFilterOptions ();
            filterOptions.ObjectContentResponseEnricherList.Add (new UsersTypeEnricher ());
            services.AddSingleton (filterOptions);

            services.AddApiVersioning ();

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info {
                    Title = "Sistema de Utilidades",
                        Version = "v1"
                });
            });

            //Dependency Injection
            services.AddScoped<IUserBusiness, UserBusinessImplementattion> ();
            services.AddScoped<IUserRepository, UserRepositoryImplementattion> ();
            services.AddScoped<IUsersTypeBusiness, UsersTypeBusinessImplementattion> ();
            //Dependency Injection of Generic Repository
            services.AddScoped (typeof (IRepository<>), typeof (GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
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
    }
}