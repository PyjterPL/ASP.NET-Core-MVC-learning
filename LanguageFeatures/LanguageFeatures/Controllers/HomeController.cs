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
        //public ViewResult Index()
        //{
        //    var results = new List<string>();

        //    foreach (var p in Product.GetProducts())
        //    {
        //        var name = p?.Name ?? "<none>";
        //        var price = p?.Price ?? 0;
        //        var relatedName = p?.Related?.Name ?? "<none>";
        //        results.Add($"Product: {name}, price: {price:C2}, relation: {relatedName}");
        //    }

        //    return View(results);
        //}

        //public ViewResult Index()
        //{
        //    Dictionary<string, Product> products = new Dictionary<string, Product>
        //    {
        //        { "Kayak", new Product { Name = "Kayak", Price = 275M } },
        //        { "Lifejacket", new Product { Name = "Life jacket", Price = 48.95M } }
        //    };
        //    return View(products.Keys);
        //}

        //public ViewResult Index()
        //{
        //    var data = new object[] { 275M, 29.95M, "Apples", "Oranges", 100, 10 };
        //    var total = 0M;
        //    foreach (var item in data)
        //    {
        //        if (item is decimal d)
        //        {
        //            total += d;
        //        }
        //    }
        //    return View("Index", new string[] { $"Total: {total:C2}" });
        //}

        //public ViewResult Index()
        //{
        //    Dictionary<string, Product> products = new Dictionary<string, Product>
        //    {
        //        ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
        //        ["Lifejacket"] = new Product { Name = "Life jacket", Price = 48.95M }
        //    };
        //    return View(products.Keys);
        //}

        //public ViewResult Index()
        //{
        //    var data = new object[] { 275M, 29.95M, "Apples", "Oranges", 100, 10 };
        //    var total = 0M;
        //    foreach (var item in data)
        //    {
        //        switch (item)
        //        {
        //            case decimal decimalValue:
        //                total += decimalValue;
        //                break;
        //            case int intValue when intValue > 50:
        //                total += intValue;
        //                break;
        //        }
        //    }
        //    return View("Index", new string[] { $"Total: {total:C2}" });
        //}

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

            var cartTotal = cart.TotalPrices();
            var arrayTotal = productArray.FilterByPrice(20M).TotalPrices();
            return View(new string[] {
                $"Total cart cost: {cartTotal:C2}",
                $"Total array cost: {arrayTotal:C2}"
            });
        }
    }
}