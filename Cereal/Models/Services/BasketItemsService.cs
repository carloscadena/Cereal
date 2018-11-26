using Cereal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cereal.Models.Interfaces;

namespace Cereal.Models.Services
{
    public class BasketItemsService : IBasketItems
    {
        private CerealDBContext _context;

        public BasketItemsService(CerealDBContext context)
        {
            _context = context;
        }

        public async Task AddItem(BasketItems basketItems)
        {
            _context.BasketItems.Add(basketItems);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBasketItems(int id)
        {
            var basketItems = await GetBasketItem(id);
            _context.BasketItems.Remove(basketItems);
            await _context.SaveChangesAsync();
        }

        public async Task<BasketItems> GetBasketItem(int? id)
        {
            return await _context.BasketItems.FirstOrDefaultAsync(BasketItems => BasketItems.ID == id);
        }

        public async Task<BasketItems> GetBasketItem(int productID, string userID)
        {
            return await _context.BasketItems.FirstOrDefaultAsync(BasketItems => BasketItems.ProductID == productID && BasketItems.UserID == userID);
        }

        //get product, if exists, update
        public async Task<IEnumerable<BasketItems>> GetBasketItems()
        {
            return await _context.BasketItems.ToListAsync();
        }

        public async Task UpdateBasketItems(BasketItems basketItems)
        {
            _context.BasketItems.Update(basketItems);
            await _context.SaveChangesAsync();
        }
    }
}
