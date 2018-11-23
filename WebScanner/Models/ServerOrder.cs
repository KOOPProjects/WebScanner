using WebScanner.Models.Interfaces;

namespace WebScanner.Models
{
    public class ServerOrder : Order, IOrder
    {
        public string Question { get; set; }
    }
}
