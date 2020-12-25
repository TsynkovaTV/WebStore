using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
//using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Order;

namespace WebStore.DAL.Context
{
    public class WebStoreDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        public DbSet<Image> Images { get; set; }

        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);          
        }
    }
}
