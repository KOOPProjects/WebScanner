using Microsoft.Extensions.DependencyInjection;

namespace WebScanner.Models.Providers.Interfaces
{
    public interface IServiceCollectionProvider
    {
        IServiceCollection Provide();
    }
}
