using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Order;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services.Db
{
    public class InDbOrderService : IOrderService
    {
        private readonly WebStoreDbContext _db;
        private readonly UserManager<User> _userManager;

        public InDbOrderService(WebStoreDbContext db, UserManager<User> UserManager)
        {
            _db = db;
            _userManager = UserManager;
        }

        public async Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user is null)
                throw new InvalidOperationException($"Пользователь {UserName} не найден");

            await using var transaction = await _db.Database.BeginTransactionAsync();

            var order = new Order
            {
                Name = OrderModel.Name,
                Address = OrderModel.Address,
                Phone = OrderModel.Phone,
                User = user,
                Date = DateTime.Now,
            };

            foreach (var (product_model, count) in Cart.Products)
            {
                var product = await _db.Products.FindAsync(product_model.Id);
                if (product is null) continue;

                var order_item = new OrderItem
                {
                    Order = order,
                    Product = product,
                    Count = count,
                    Price = product.Price,
                };
                order.Items.Add(order_item);                                
            }

            await _db.Orders.AddAsync(order);

            await _db.SaveChangesAsync();

            await transaction.CommitAsync();

            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _db.Orders
               .Include(order => order.User)
               .Include(order => order.Items)
               .FirstOrDefaultAsync(order => order.Id == id);               
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string UserName)
        {
            return await _db.Orders
                .Include(order => order.User)
                .Include(order => order.Items)
                .Where(order => order.User.UserName == UserName)
                .ToArrayAsync();
        }
    }
}
