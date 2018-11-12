using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner.Models.Interfaces;

namespace WebScanner.Models
{
    public class Order : DbEntity, IOrder
    {
        public int Frequency { get; set; }
        public string TargetAdress { get; set; }
    }
}
