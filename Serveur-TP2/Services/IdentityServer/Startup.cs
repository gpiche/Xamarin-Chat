using IdentityServer;
using IdentityServer.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace IdentityServerQuickStarts
{
    public class Startup
    {
   

        public IConfigurationRoot Configuration { get; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Filename=C:\\Users\\Guillaume\\Documents\\GitHub\\521-eq-tp2-remhel_guipich\\Serveur-TP2\\Services\\IdentityServer\\dev-chat.sqlite")
            );

            services.AddSingleton<IAuthRepository, AuthRepository>();
            services.AddSingleton<ICryptoService, CryptoService>();

            services.AddTransient<IResourceOwnerPasswordValidator, RessourceOwnerPasswordValidator>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IAuthRepository, AuthRepository>();


            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer() //registers the IdentityServer services in DI
                .AddDeveloperSigningCredential() //creates temporary key material for signing tokens
                .AddInMemoryClients(Config.GetClients())
                .AddInMemoryApiResources(Config.GetApiResources());

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}
