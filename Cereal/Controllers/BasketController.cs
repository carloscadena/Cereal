using Cereal.Models;
using Cereal.Models.Interfaces;
using Cereal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IBasketItems _basket;
        private readonly IProduct _product;
        private UserManager<ApplicationUser> _userManager;

        public BasketController(IProduct product, IBasketItems basket, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _product = product;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userid = _userManager.GetUserId(User);
            var baskets = await _basket.GetBasketItems(userid);
            List<Product> products = new List<Product>();
            foreach (var item in baskets)
            {
                var product = await _product.GetProduct(item.ProductID);
                products.Add(product);

            }
            var combo = baskets.Zip(products, (x, y) => new { BasketItem = x, Product = y });

            
            List<BasketViewModel> BasketList = new List<BasketViewModel>();
            foreach (var item in combo)
            {
                BasketViewModel BasketVM = new BasketViewModel();
                BasketVM.Sku = item.Product.Sku;
                BasketVM.Name = item.Product.Name;
                BasketVM.Price = item.Product.Price;
                BasketVM.Description = item.Product.Description;
                BasketVM.Image = item.Product.Image;
                BasketVM.ProductID = item.Product.ProductID;

                BasketVM.Quantity = item.BasketItem.Quantity;
                BasketVM.ID = item.BasketItem.ID;
                BasketList.Add(BasketVM);
            }
            return View(BasketList);
            //return View(await _basket.GetBasketItems());
        }

        [HttpPost]
        //
        public async Task<IActionResult> Index(int id, int quantity)
        {
            var userID = _userManager.GetUserId(User);

            BasketItems item = await _basket.GetBasketItem(id, userID);
            
            item.Quantity = quantity;
            await _basket.UpdateBasketItems(item);

            var baskets = await _basket.GetBasketItems(userID);
            List<Product> products = new List<Product>();
            foreach (var prod in baskets)
            {
                var product = await _product.GetProduct(prod.ProductID);
                products.Add(product);

            }
            var combo = baskets.Zip(products, (x, y) => new { BasketItem = x, Product = y });


            List<BasketViewModel> BasketList = new List<BasketViewModel>();
            foreach (var prod in combo)
            {
                BasketViewModel BasketVM = new BasketViewModel();
                BasketVM.Sku = prod.Product.Sku;
                BasketVM.Name = prod.Product.Name;
                BasketVM.Price = prod.Product.Price;
                BasketVM.Description = prod.Product.Description;
                BasketVM.Image = prod.Product.Image;
                BasketVM.ProductID = prod.Product.ProductID;

                BasketVM.Quantity = prod.BasketItem.Quantity;
                BasketVM.ID = prod.BasketItem.ID;
                BasketList.Add(BasketVM);
            }
            return View(BasketList);
        }

        //// GET: Product/Delete
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _product.GetProduct(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // POST: BasketItem/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _basket.DeleteBasketItems(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
