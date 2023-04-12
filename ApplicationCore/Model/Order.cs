using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Total { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }
    }
}
