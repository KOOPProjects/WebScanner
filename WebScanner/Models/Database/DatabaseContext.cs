using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<HtmlOrder> HtmlOrders { get; set; }
        public DbSet<ServerOrder> ServerOrders { get; set; }
        public DbSet<Response> Responses { get; set; }
        
    }
}
