using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirlessMediaSimpleCRUD.Data;
using WirlessMediaSimpleCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json;

namespace WirlessMediaSimpleCRUD.Repositories
{
    public class ProductJSONRepository : IProductJSONRepository
    {

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"Data\\JSON\\{"Products.json"}");
        async public Task<List<Product>> GetProductsJSON()
        {
            var fileRead = await System.IO.File.ReadAllTextAsync(filePath);
            var fileReadList = JsonConvert.DeserializeObject<List<Product>>(fileRead);
            return fileReadList;
        }

        async public Task<Product> GetProductAsync(int? id)
        {
            var fileReadList = await GetProductsJSON();
            return fileReadList.Where(p => p.Id == id).SingleOrDefault();
        }

        async public Task<List<Product>> GetProductsAsync()
        {
            var fileReadList = await GetProductsJSON();
            return fileReadList;
        }

        async public Task UpsertProductAsync(Product product)
        {
            var fileReadList = await GetProductsJSON();

            if (product.Id == 0)
            {
                // Create 
                product.Id = fileReadList.Count + 1;
                fileReadList.Add(product);
            }
            else
            {
                // Update
                fileReadList.Where(p => p.Id == product.Id).Select( p => {
                    p.Name = product.Name;
                    p.Description = product.Description;
                    p.Category = product.Category;
                    p.Manufacturer = product.Manufacturer;
                    p.Supplier = product.Supplier;
                    p.Cost = product.Cost;
                    return p;
                }).ToList();
            }

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, fileReadList);
            }
        }
    }
}
