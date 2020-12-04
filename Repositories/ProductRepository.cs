using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirlessMediaSimpleCRUD.Data;
using WirlessMediaSimpleCRUD.Models;
using Microsoft.EntityFrameworkCore;
using WirlessMediaSimpleCRUD.Models;

namespace WirlessMediaSimpleCRUD.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private MainContext _context;
        public ProductRepository(MainContext context)
        {
            _context = context;
        }

        async public Task<Product> GetProductAsync(int? id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        async public Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        async public Task UpsertProductAsync(Product product)
        {
            if (product.Id == 0)
            {
                // Create 
                var createSingleProduct = _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Update
                var singleProduct = await _context.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
                if (singleProduct != null)
                {
                    // Add auto mapper
                    singleProduct.Name = product.Name;
                    singleProduct.Description = product.Description;
                    singleProduct.Category = product.Category;
                    singleProduct.Manufacturer = product.Manufacturer;
                    singleProduct.Supplier = product.Supplier;
                    singleProduct.Cost = product.Cost;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
