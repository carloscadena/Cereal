using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models
{
    public class BasketItems
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public string UserID { get; set; }

        public bool Purchased { get; set; }

        public DateTime Date { get; set; }

        public Product Product { get; set; }
    }
}
