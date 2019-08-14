
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YGP.IdentityService.Configurations;

namespace YGP.IdentityService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(options =>
            {
                options.MySqlConnectionString = Configuration[AppDefaults.ConnectionString];
            });

            services.Configure<DefaultOptions>(options =>
            {
                options.ConnectionString = Configuration[AppDefaults.ConnectionString];
                options.LogstashUri = Configuration[AppDefaults.LogstashUri];
                options.PasswordHashSalt = Configuration[AppDefaults.PasswordHashSalt];
            });

            services.SetupIdentityServer(options => {
                Configuration.GetSection("Clients").Bind(options);
            });

            services.AddWebApiMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
