using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirlessMediaSimpleCRUD.Data;
using WirlessMediaSimpleCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace WirlessMediaSimpleCRUD.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private MainContext _productContext;
        public ProductRepository(MainContext context)
        {
            _productContext = context;
        }

        async public Task<Product> GetProductAsync(int? id)
        {
            return await _productContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        async public Task<List<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        async public Task UpsertProductAsync(Product product)
        {
            if (product.Id == 0)
            {
                // Create 
                var createSingleProduct = _productContext.Products.Add(product);
                await _productContext.SaveChangesAsync();
            }
            else
            {
                // Update
                var singleProduct = await _productContext.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
                if (singleProduct != null)
                {
                    // Add auto mapper
                    singleProduct.Name = product.Name;
                    singleProduct.Description = product.Description;
                    singleProduct.Category = product.Category;
                    singleProduct.Manufacturer = product.Manufacturer;
                    singleProduct.Supplier = product.Supplier;
                    singleProduct.Cost = product.Cost;
                    await _productContext.SaveChangesAsync();
                }
            }
        }
    }
}
