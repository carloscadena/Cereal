using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cereal.Data;
using Cereal.Models;
using Cereal.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cereal.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IBasketItems _basket;
        private readonly IProduct _product;
        private UserManager<ApplicationUser> _userManager;
        private CerealDBContext _context;

        public CheckoutController(IProduct product, IBasketItems basket, UserManager<ApplicationUser> userManager, CerealDBContext context)
        {
            _basket = basket;
            _product = product;
            _userManager = userManager;
            _context = context;

        }

        public async Task<IActionResult> Receipt()
        {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var ID = user.Id;
        var receipt = await _context.BasketItems.Where(x => x.UserID == ID).Include(product => product.Product).ToListAsync();
           
            return View(receipt);
        }
    }
}