using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;
namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] productArray =
            {
                new Product{Name = "Kayak", Price= 275M},
                new Product{Name = "Lifejacket", Price = 48.95M},
                new Product{Name = "Football", Price=19.50M},
                new Product{Name = "Flag", Price = 34.95M}
            };

            var cartTotal = cart
                .Filter(p=>(p?.Price ?? 0) >=20)
                .TotalPrices();

            var arrayTotal = productArray
                .Filter(p=> (p?.Name?[0] == 'P'))
                .TotalPrices();

            return View(new string[] {
                $"Total cart cost: {cartTotal:C2}",
                $"Total array cost: {arrayTotal:C2}"
            });
        }
    }
}