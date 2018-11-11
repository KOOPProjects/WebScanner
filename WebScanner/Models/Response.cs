using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner.Models
{
    public class Response : DbEntity
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
