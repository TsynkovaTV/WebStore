using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    //параметр true в атрибуте Obsolete означает, что при попытке воспользоваться методом должна возникнуть ошибка
    [Obsolete("Класс устарел, потому что данные больше не хранятся в памяти. Пользуйтесь классом InDbProductData", true)]
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;

        public IEnumerable<Section> GetSections() => TestData.Sections;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;

            if (Filter?.SectionId is { } section_id) // сопоставление с образцом
                query = query.Where(product => product.SectionId == section_id);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            return query;
        }

        Section IProductData.GetSectionById(int id)
        {
            throw new NotSupportedException();
        }

        Brand IProductData.GetBrandById(int id)
        {
            throw new NotSupportedException();
        }

        Product IProductData.GetProductById(int id)
        {
            throw new NotSupportedException();
        }

        public Task EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
