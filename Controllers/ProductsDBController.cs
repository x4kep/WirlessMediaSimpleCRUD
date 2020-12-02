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
