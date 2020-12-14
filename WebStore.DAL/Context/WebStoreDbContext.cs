using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
//using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;

namespace WebStore.DAL.Context
{
    public class WebStoreDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options) : base(options) { }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=webstoredb;Trusted_Connection=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          /*  modelBuilder.Entity<Section>().HasData(TestData.Sections);

            modelBuilder.Entity<Brand>().HasData(TestData.Brands);

            modelBuilder.Entity<Product>().HasData(TestData.Products);

            modelBuilder.Entity<CartProduct>().HasData(TestData.CartProducts);*/
        }
    }
}
