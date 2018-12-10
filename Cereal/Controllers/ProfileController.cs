using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cereal.Models;
using Cereal.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cereal.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IBasketItems _basket;
        private readonly IProduct _product;
        private UserManager<ApplicationUser> _userManager;

        public ProfileController(IProduct product, IBasketItems basket, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _product = product;
            _userManager = userManager;

        }
        public IActionResult Index()
        {

            return View();
        }
    }
}