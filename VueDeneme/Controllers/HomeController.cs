using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueDeneme.Models;

namespace VueDeneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Product> _products = new List<Product>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product
                {
                    Id = i + 1,
                    Price = 1000,
                    Stock = 20,
                    ProductName = "deneme " + (i + 1)
                };
                _products.Add(product);
            }

        }

        public IActionResult Index()
        {
            var products = _products.ToList();
            return View(products);
        }

        public IActionResult Privacy()
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
