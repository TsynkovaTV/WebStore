using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<(ProductViewModel Product, int Count)> Products { get; set; }

        public int ProductsCount => Products?.Sum(p => p.Count) ?? 0;

        public decimal TotalPrice => Products?.Sum(p => p.Product.Price * p.Count) ?? 0m;
    }
}
