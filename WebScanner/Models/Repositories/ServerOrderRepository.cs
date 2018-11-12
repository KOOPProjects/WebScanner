using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Database;
using WebScanner.Models.Repositories.Interfaces;

namespace WebScanner.Models.Repositories
{
    public class ServerOrderRepository : GenericRepository<ServerOrder>, IServerOrderRepository
    {
        public ServerOrderRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public IEnumerable<ServerOrder> GetServersByRequestType(string requestType)
        {
            return this.DatabaseContext.ServerOrders.Where(x => x.Question == requestType);
        }
    }
}
