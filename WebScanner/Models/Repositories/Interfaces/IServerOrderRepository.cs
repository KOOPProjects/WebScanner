using System.Collections.Generic;

namespace WebScanner.Models.Repositories.Interfaces
{
    public interface IServerOrderRepository
    {
        IEnumerable<ServerOrder> GetServersByRequestType(string requestType);
    }
}
