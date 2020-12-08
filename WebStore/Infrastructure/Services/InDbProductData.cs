using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Db;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InDbProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands()
        {
            using (WebStoreDbContext db = new WebStoreDbContext())
            {
                return db.Brands.ToList();
            }

        }

        public IEnumerable<Section> GetSections()
        {
            using (WebStoreDbContext db = new WebStoreDbContext())
            {
                return db.Sections.ToList();
            }

        }

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            using (WebStoreDbContext db = new WebStoreDbContext())
            {
                var query = TestData.Products;

                if (Filter?.SectionId is { } section_id) // сопоставление с образцом
                    query = query.Where(product => product.SectionId == section_id);

                if (Filter?.BrandId != null)
                    query = query.Where(product => product.BrandId == Filter.BrandId);

                return query.ToList();
            }
        }
    }
}
