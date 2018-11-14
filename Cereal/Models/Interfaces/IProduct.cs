using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Models.Interfaces
{
    public interface IProduct
    {
        Task CreateProduct(Product product);

        Task<Product> GetProduct(int? id);

        Task<IEnumerable<Product>> GetProducts();

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
