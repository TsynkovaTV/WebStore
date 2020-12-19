using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebStore.Domain.Entities
{
    public class Cart
    {
        public ICollection<CartProduct> Products { get; set; } = new List<CartProduct>();

        public int ProductsCount => Products?.Sum(p => p.ProductCount) ?? 0;

    }
}
