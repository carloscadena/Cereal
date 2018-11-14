using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cereal.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cereal.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        //Get: Products
        public async Task<IActionResult> Index()
        {
            return View(await _product.GetProducts());
        }

        [HttpPost]
        public async Task<Iaction>
    }
}