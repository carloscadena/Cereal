using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Sku is required")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

    }
}
