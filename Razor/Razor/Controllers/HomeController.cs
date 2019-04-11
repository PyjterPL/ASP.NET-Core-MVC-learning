﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var myProduct = new Product
            {
                ProductID = 1,
                Name = "Kayak",
                Description = "One person boat",
                Category = "Water sports",
                Price = 275M
            };
            return View(myProduct);
        }
    }
}