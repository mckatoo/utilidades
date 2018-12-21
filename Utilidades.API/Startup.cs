using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Utilidades.API.Business;
using Utilidades.API.Business.Implementattions;
using Utilidades.API.Model.Context;

namespace Utilidades.API {
    public class Startup {
        private readonly ILogger _logger;
        private readonly string _connectionString;
        public IHostingEnvironment _environment{get;}
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

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
            services.AddApiVersioning();
            //Dependency Injection
            services.AddScoped<IUserBusiness, UserBusinessImplementattion> ();
            services.AddScoped<IUserRepository, UserRepositoryImplementattion> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();

                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString);
                    var evolve = new Evolve.Evolve("evolve.json",
                        evolveConnection, msg => _logger.LogInformation(msg)
                    ){
                        Locations = new List<string> {"db/migrations"},
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migation failed.", ex);
                    throw;
                }
                
            } else {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}