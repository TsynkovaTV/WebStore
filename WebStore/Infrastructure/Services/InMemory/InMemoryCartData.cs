using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryCartData : ICartData
    {
        public IEnumerable<CartProduct> GetCartProducts()
        {
            var query = TestData.CartProducts;

            return query;
        }
    }
}
