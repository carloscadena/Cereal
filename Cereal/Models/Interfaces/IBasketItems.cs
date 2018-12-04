using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models.Interfaces
{
    public interface IBasketItems
    {
        Task AddItem(BasketItems basketItems);

        Task<BasketItems> GetBasketItem(int? id);

        Task<BasketItems> GetBasketItem(int productID, string userID);

        Task<IEnumerable<BasketItems>> GetBasketItems(string id);

        Task UpdateBasketItems(BasketItems basketItems);

        Task DeleteBasketItems(int id);
    }
}
