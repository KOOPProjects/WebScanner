using System;

namespace WebScanner.Models
{
    public class Response : DbEntity
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
