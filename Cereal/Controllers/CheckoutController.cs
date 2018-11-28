﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cereal.Data;
using Cereal.Models;
using Cereal.Models.Interfaces;
using Cereal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cereal.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IBasketItems _basket;
        private readonly IProduct _product;
        private UserManager<ApplicationUser> _userManager;
        private CerealDBContext _context;
        private EmailSender _email;

        public CheckoutController(IProduct product, IBasketItems basket, UserManager<ApplicationUser> userManager, CerealDBContext context)
        {
            _basket = basket;
            _product = product;
            _userManager = userManager;
            _context = context;

        }

        public async Task<IActionResult> Receipt()
        {
            var baskets = await _basket.GetBasketItems();
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

            //string subject = "Order Confirmation";

            //string msg = "<table><th>Product</th><th>Quantity</th><th>Price</th>";

            //decimal total = 0m;

            //foreach (var item in BasketList)
            //{
            //    var product = await _product.GetProduct(item.ProductID);
            //    total += (product.Price * item.Quantity);
            //    msg += $"<tr><td>{product.Name}</td><td>{item.Quantity}</td><td>${product.Price}</td></tr>";
            //    await _email.SendEmailAsync(RegisterViewModel., subject, msg);


                return View(BasketList);

        }
    }
}