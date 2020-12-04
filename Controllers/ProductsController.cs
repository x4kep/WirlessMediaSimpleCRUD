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
using WirlessMediaSimpleCRUD.ViewsModel;
using WirlessMediaSimpleCRUD.Data;
using Microsoft.EntityFrameworkCore;
using WirlessMediaSimpleCRUD.Repositories;

namespace WirlessMediaSimpleCRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _dbContext;
        private readonly IProductJSONRepository _jsonContext;


        public ProductsController(ILogger<ProductsController> logger, IProductRepository dbContext, IProductJSONRepository jsonContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _jsonContext = jsonContext;
        }

        public async Task<IActionResult> Index(string store)
        {
            var viewModel = new ProductModel();
            viewModel.Store = store;

            try
            {
                if (store == "JSON")
                    viewModel.Products = await _jsonContext.GetProductsAsync();
                else
                    viewModel.Products = await _dbContext.GetProductsAsync();

                return View(viewModel);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id, string store)
        {
            var viewModel = new ProductModel();
            viewModel.Store = store;

            if (id == null)
                return NotFound();

            try
            {
                if (store == "JSON")
                    viewModel.Product = await _jsonContext.GetProductAsync(id);
                else
                    viewModel.Product = await _dbContext.GetProductAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View(viewModel);
        }

        public IActionResult Create(string store)
        {
            var viewModel = new ProductModel();
            viewModel.Store = store;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert([FromForm]Product product, [FromForm]string store)
        {
            var viewModel = new ProductModel();
            viewModel.Store = store;
            viewModel.Product = product;

            if (!ModelState.IsValid)
            {
                if(product.Id == 0)
                    return View("Create", viewModel);
                else
                    return View("Edit", viewModel);
            }

            try
            {
                if (store == "JSON")
                    await _jsonContext.UpsertProductAsync(product);
                else
                    await _dbContext.UpsertProductAsync(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", new { store = store});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
