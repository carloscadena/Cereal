using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models
{
    public class Cart
    {
        public int BasketID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public bool Purchased { get; set; }

        public string UsedID { get; set; }

    }
}
