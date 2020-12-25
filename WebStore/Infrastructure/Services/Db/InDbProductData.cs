using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InDbProductData : IProductData
    {
        private readonly WebStoreDbContext _db;

        public InDbProductData(WebStoreDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Brand> GetBrands()
        {
            return _db.Brands.Include(brand => brand.Products);        
        }

        public IEnumerable<Section> GetSections()
        {            
                return _db.Sections.Include(section => section.Products); 
        }

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products
                .Include(p => p.Brand)
                .Include(p => p.Section)
                .Include(p => p.Image);

            if (Filter?.Ids?.Length > 0)
            {
                query = query.Where(product => Filter.Ids.Contains(product.Id));
            }
            else 
            {
                if (Filter?.SectionId is { } section_id) // сопоставление с образцом
                    query = query.Where(product => product.SectionId == section_id);

                if (Filter?.BrandId != null)
                    query = query.Where(product => product.BrandId == Filter.BrandId);
            }

                

                return query;            
        }
              
        public Section GetSectionById(int id)
        {
            //return _db.Sections.Find(id);

            //альтернатива Find, но Find более оптимизированный
            return _db.Sections
                    .Include(section => section.Products)
                    .FirstOrDefault(s => s.Id == id);
        }


        public Brand GetBrandById(int id)
        {
            return _db.Brands
                    .Include(brand => brand.Products)
                    .FirstOrDefault(b => b.Id == id);
        }

        public Product GetProductById(int id)
        {
            return _db.Products
                    .Include(p => p.Brand)
                    .Include(p => p.Section)
                    .Include(p => p.Image)
                    .FirstOrDefault(p => p.Id == id);
        }

        public async Task EditProduct(Product product)
        {
            Product dbProduct = GetProductById(product.Id);

            dbProduct.Name = product.Name;
            dbProduct.Order = product.Order;
            dbProduct.BrandId = product.BrandId;
            dbProduct.SectionId = product.SectionId;
            dbProduct.ImageId = product.ImageId;
            dbProduct.Price = product.Price;
            dbProduct.WebId = product.WebId;

            _db.Products.Update(dbProduct);
            await _db.SaveChangesAsync();

            return;
        }

        public async Task DeleteProduct(int id)
        {
            Product dbProduct = GetProductById(id);            

            _db.Products.Remove(dbProduct);
            await _db.SaveChangesAsync();

            return;
        }

        public async Task AddImage(Image image, int productId)
        {
            Product dbProduct = GetProductById(productId);

            if (dbProduct is null)
            {
                throw new InvalidOperationException("Товар не найден");
            }
            
            await using var transaction = await _db.Database.BeginTransactionAsync();

            await _db.Images.AddAsync(image);

            await _db.SaveChangesAsync();

            dbProduct.ImageId = image.Id;

            await _db.SaveChangesAsync();

            await transaction.CommitAsync();

            return;
        }
    }
}
