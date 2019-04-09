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
            var results = new List<string>();

            foreach (var p in Product.GetProducts())
            {
                var name = p?.Name ?? "<none>";
                var price = p?.Price ?? 0;
                var relatedName = p?.Related?.Name ?? "<none>";
                results.Add($"Product: {name}, price: {price}, relation: {relatedName}");
            }

            return View(results);
        }
    }
}