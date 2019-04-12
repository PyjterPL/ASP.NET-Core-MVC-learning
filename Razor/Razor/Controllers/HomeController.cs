using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Life jacket", Price = 48.95M},
                new Product {Name = "Football", Price = 19.50M},
                new Product {Name = "Flag", Price = 34.95M},
            };
            return View(productArray);
        }
    }
}