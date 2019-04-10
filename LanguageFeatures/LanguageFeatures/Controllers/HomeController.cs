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
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }
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

            Func<Product, bool> nameFilter = delegate (Product product)
             {
                 return product?.Name[0] == 'P';
             };

            var cartTotal = cart
                .Filter(FilterByPrice)
                .TotalPrices();

            var arrayTotal = productArray
                .Filter(nameFilter)
                .TotalPrices();

            return View(new string[] {
                $"Total cart cost: {cartTotal:C2}",
                $"Total array cost: {arrayTotal:C2}"
            });
        }
    }
}