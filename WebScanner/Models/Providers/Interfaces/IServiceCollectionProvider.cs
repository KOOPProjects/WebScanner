using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Providers.Interfaces
{
    public interface IServiceCollectionProvider
    {
        IServiceCollection Provide();
    }
}
