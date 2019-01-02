using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebScanner.Models.Database;
using WebScanner.Models.Providers;

namespace WebScanner
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
            var serviceCollection = new ServiceCollectionProvider().Provide();
            foreach(var service in serviceCollection)
            {
                services.Add(service);
            }
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //CORS CONFIG
            services.AddCors(options => options.AddPolicy("AllowAllOrigins",
               builder =>
               {
                   builder.AllowAnyOrigin();
            }));
            var schedulerConfigurator = new StartupConfigurator(services.BuildServiceProvider().GetService<DatabaseContext>());
            schedulerConfigurator.Configurate();
           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}
