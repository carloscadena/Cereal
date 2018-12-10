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
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cereal.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminPortalModel : PageModel
    {
        private readonly IBasketItems _basket;
        private readonly IProduct _product;
        private UserManager<ApplicationUser> _userManager;
        private readonly CerealDBContext _context;

        [BindProperty]
        public Cereal.Models.Product Product { get; set; }

        public AdminPortalModel(CerealDBContext context, IProduct product, IBasketItems basket, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _basket = basket;
            _product = product;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var products = await _context.Product.ToListAsync();
            return Page();
        }

        // GET: Product/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _product.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // POST: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Sku,Name,Price, Description, Image")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _product.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Page));
            }
            return Page();
        }

        // GET: Product/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _product.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Page();
        }

        // POST: Product/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction(nameof(Page));
        }

        private bool ProductExists(int id)
        {
            return _product.GetProduct(id) != null;
        }

    }

}