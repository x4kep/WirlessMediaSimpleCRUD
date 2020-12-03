using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WirlessMediaSimpleCRUD.Models;
using WirlessMediaSimpleCRUD.Data;
using Microsoft.EntityFrameworkCore;

namespace WirlessMediaSimpleCRUD.Controllers
{
    public class ProductsDBController : Controller
    {
        private readonly ILogger<ProductsJSONController> _logger;
        private readonly ProductContext _context;

        public ProductsDBController(ILogger<ProductsJSONController> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dbReadList = await _context.Products.ToListAsync();

            return View(dbReadList);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getSingleProduct = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            return View(getSingleProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Product product)
        {
            if(product.Id == 0)
            {
                // Create 
                var createSingleProduct = _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Update
                var singleProduct = await _context.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
                if(singleProduct != null)
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

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
