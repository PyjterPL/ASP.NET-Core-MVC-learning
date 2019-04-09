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
        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> products, decimal minimumPrice)
        {
            foreach (var product in products)
            {
                if((product?.Price ?? 0) >= minimumPrice)
                {
                    yield return product;
                }
            }
        }
    }
}
