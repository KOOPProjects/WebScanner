using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebScanner.Models.Database;
using WebScanner.Models.Jobs;
using WebScanner.Models.Providers.Interfaces;
using WebScanner.Models.Services;

namespace WebScanner.Models.Providers
{
    public class ServiceCollectionProvider : IServiceCollectionProvider
    {
        public IServiceCollection Provide()
        {
            var services = new ServiceCollection();
            var connectionString =
               " ";
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString));
            services.AddScoped<ResponseService>();
            services.AddScoped<HtmlOrderJob>();
            services.AddScoped<ServerOrderJob>();
            return services;
        }
    }
}
