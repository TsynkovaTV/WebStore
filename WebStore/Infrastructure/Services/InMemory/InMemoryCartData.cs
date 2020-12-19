using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryCartData : ICartService
    {
        public void AddToCart(int id)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void DecrementFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartProduct> GetCartProducts()
        {
            var query = TestData.CartProducts;

            return query;
        }

        public void RemoveFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public CartViewModel TransformFromCart()
        {
            throw new NotImplementedException();
        }
    }
}
