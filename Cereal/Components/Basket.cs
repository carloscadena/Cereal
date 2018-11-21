using Cereal.Data;
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

        public Basket(CerealDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var items = await _context.BasketItems.ToListAsync();

            return View(items);
        }

    }
}
