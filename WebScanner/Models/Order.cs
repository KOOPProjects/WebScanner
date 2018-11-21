using WebScanner.Models.Interfaces;

namespace WebScanner.Models
{
    public class Order : DbEntity, IOrder
    {
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
    }
}
