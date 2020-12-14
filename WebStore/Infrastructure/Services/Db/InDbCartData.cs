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

namespace WebStore.Infrastructure.Services
{
    public class InDbCartData : ICartData
    {
        private readonly WebStoreDbContext _db;

        public InDbCartData(WebStoreDbContext db)
        {
            _db = db;
        }
        public IEnumerable<CartProduct> GetCartProducts()
        {
            
            return _db.CartProducts.ToList();
                          
        }
    }
}
