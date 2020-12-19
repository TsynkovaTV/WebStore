using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services
{
    [Obsolete("Корзина хранится не в БД, а в cookies")]
    public class InDbCartData : ICartService
    {
        private readonly WebStoreDbContext _db;

        public InDbCartData(WebStoreDbContext db)
        {
            _db = db;
        }

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
            
            return _db.CartProducts.ToList();
                          
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
