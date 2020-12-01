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

namespace WirlessMediaSimpleCRUD.Controllers
{
    public class ProductsJSONController : Controller
    {
        private readonly ILogger<ProductsJSONController> _logger;

        public ProductsJSONController(ILogger<ProductsJSONController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"Files\\{"Products.json"}");
            var fileRead = System.IO.File.ReadAllText(filePath);
            var fileReadList = JsonConvert.DeserializeObject<List<Product>>(fileRead);

            return View(fileReadList);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
