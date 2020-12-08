using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Db;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InDbCartData : ICartData
    {
        public IEnumerable<CartProduct> GetCartProducts()
        {
            using (WebStoreDbContext db = new WebStoreDbContext())
            {                
                return db.CartProducts.ToList();
            }               
        }
    }
}
