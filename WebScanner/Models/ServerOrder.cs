using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models
{
    public class ServerOrder : Order, IOrder
    {
        public string Question { get; set; }
    }
}
