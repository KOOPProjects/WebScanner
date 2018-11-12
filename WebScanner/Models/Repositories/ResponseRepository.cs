using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Database;

namespace WebScanner.Models.Repositories
{
    public class ResponseRepository : GenericRepository<Response>
    {
        public ResponseRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
