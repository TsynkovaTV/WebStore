using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                IQueryable<Product> query = _db.Products;

                if (Filter?.SectionId is { } section_id) // сопоставление с образцом
                    query = query.Where(product => product.SectionId == section_id);

                if (Filter?.BrandId != null)
                    query = query.Where(product => product.BrandId == Filter.BrandId);

                return query;            
        }
    }
}
