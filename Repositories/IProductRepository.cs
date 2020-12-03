using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirlessMediaSimpleCRUD.Models;

namespace WirlessMediaSimpleCRUD.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(int? id);
        Task<List<Product>> GetProductsAsync();
        Task UpsertProductAsync(Product product);
    }
}
