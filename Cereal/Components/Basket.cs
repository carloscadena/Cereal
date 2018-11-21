using Cereal.Data;
using Cereal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Components
{
    public class Basket : ViewComponent
    {
        private CerealDBContext _context;
        private UserManager<ApplicationUser> _userManager;

        public Basket(CerealDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var ID = user.Id;
            var basket = _context.BasketItems.Where(u => u.UserID == ID).ToList();

            return View(basket);
        }

    }
}
