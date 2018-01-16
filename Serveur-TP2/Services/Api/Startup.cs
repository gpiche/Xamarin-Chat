using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization() 
                .AddJsonFormatters();

    

            //the authentication services:
            //  validate the incoming token to make sure it is coming from a trusted issuer
            //  validate that the token is valid to be used with this api(aka scope)
            services.AddAuthentication("Bearer") //adds the authentication services to DI and configures "Bearer"
                .AddIdentityServerAuthentication(
                    options => //adds the IdentityServer access token validation handler into DI for use by the authentication services.
                    {
                        //options.Authority = $"{Configuration["EXTERNAL_IDENTITY_SERVER_URL"]}";
                        options.Authority = "http://localhost:55167/";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "api1";
                    });

            services.AddSingleton<InMemoryRepository>();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication(); // adds the authentication middleware to the pipeline so authentication will be performed automatically on every call into the host.

    

            app.UseMvc();
        }
    }
}
