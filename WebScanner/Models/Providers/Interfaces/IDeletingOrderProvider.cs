using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Providers.Interfaces
{
    public interface IDeletingOrderProvider
    {
        Task DeleteOrder(int id);
    }
}
