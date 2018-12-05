using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models.ViewModels
{
    public class BasketViewModel
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public string UserID { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }

        public bool Purchased { get; set; }

        public Product Product { get; set; }
    }
}
