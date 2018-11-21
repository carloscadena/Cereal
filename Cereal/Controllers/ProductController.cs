using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cereal.Models;
using Cereal.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cereal.Controllers
{    
    public class ProductController : Controller
    {
        private readonly IBasketItems _basket;
        private readonly IProduct _product;
        private UserManager<ApplicationUser> _userManager;

        public ProductController(IProduct product, IBasketItems basket, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _product = product;
            _userManager = userManager;
            
        }

        //Get: Products
        public async Task<IActionResult> Index()
        {
            return View(await _product.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var product = await _product.GetProducts();
            product = product.Where(p => p.Name.Contains(searchString));
            return View(product);
        }

        [HttpGet]
        //Get: Product/Details
        public async Task<IActionResult> Details(int? id)
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
            return View(product);
        }

        [HttpPost]
        //Get: Product/Details
        public async Task<IActionResult> Details(int id, int quantity)
        {
            BasketItems item = new BasketItems();
            item.ProductID = id;
            item.Quantity = quantity;
            var userID = _userManager.GetUserId(User);
            item.UserID = userID;
            await _basket.AddItem(item);
            var product = await _product.GetProduct(id);
            return View(product);
        }

        //Get: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Sku,Name,Price, Description, Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _product.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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
            return View(product);
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
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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

            return View(product);
        }

        // POST: Hotels/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _product.GetProduct(id) != null;
        }

    }
}