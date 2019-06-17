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
               "User ID=webscanner;Password=eCCxufUi3KmZX4DRuxDpdpZZFO8qJm8G;Host=s2.ptrd.pl;Port=5432;Database=webscanner;Pooling=true;";
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString));
            services.AddScoped<ResponseService>();
            services.AddScoped<HtmlOrderJob>();
            services.AddScoped<ServerOrderJob>();
            return services;
        }
    }
}
