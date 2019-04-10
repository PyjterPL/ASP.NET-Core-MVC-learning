using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            var total = 0M;
            foreach (var prod in products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }
        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnumerable,
                    Func<Product, bool> selector)
        {
            foreach (var product in productEnumerable)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }
    }
}
