﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        Section GetSectionById(int id);

        IEnumerable<Brand> GetBrands();

        Brand GetBrandById(int id);

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int id);

        Task AddProduct(Product product, Image image);

        Task EditProduct(Product product);

        Task DeleteProduct(int id);

        Task AddImage(Image image, int productId);
    }
}
