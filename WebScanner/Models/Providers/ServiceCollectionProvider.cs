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
               "User ID=staging;Password=YWSB14l9TvfB;Host=dev.ptrd.pl;Port=5432;Database=staging;Pooling=true;";
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString));
            services.AddScoped<ResponseService>();
            services.AddScoped<HtmlOrderJob>();
            services.AddScoped<ServerOrderJob>();
            return services;
        }
    }
}
