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
