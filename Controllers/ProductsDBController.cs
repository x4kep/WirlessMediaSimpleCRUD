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
using WirlessMediaSimpleCRUD.Repositories;

namespace WirlessMediaSimpleCRUD.Controllers
{
    public class ProductsDBController : Controller
    {
        private readonly ILogger<ProductsJSONController> _logger;
        private readonly IProductRepository _context;

        public ProductsDBController(ILogger<ProductsJSONController> logger, IProductRepository context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var getProducts = new List<Product>();
            try
            {
                getProducts = await _context.GetProductsAsync();
                return View(getProducts);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return View(getProducts);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var getProduct = new Product();
            if (id == null)
            {
                return NotFound();
            }

            getProduct = await _context.GetProductAsync(id);

            return View(getProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Product product)
        {
            if (!ModelState.IsValid)
            {
                if(product.Id == 0)
                    return View("Create", product);
                else
                    return View("Edit", product);
            }

            await _context.UpsertProductAsync(product);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
