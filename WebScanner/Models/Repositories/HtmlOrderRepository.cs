using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Database;
using WebScanner.Models.Repositories.Interfaces;

namespace WebScanner.Models.Repositories
{
    public class HtmlOrderRepository : GenericRepository<HtmlOrder>, IHtmlOrderRepository
    {
        public HtmlOrderRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
