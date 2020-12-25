﻿using System;
using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.Models;

namespace WebStore.Data
{
    public class TestData
    {
        public static List<Employee> Employees { get;  } = new()
        {
            new Employee
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Age = 35,
                Phone = "+79000000000",
                City = "Москва",
                Position = "Генеральный директор",
                EmploymentDate = new DateTime(2010, 12, 1)
            },
            new Employee
            {
                Id = 2,
                LastName = "Петров",
                FirstName = "Пётр",
                MiddleName = "Петрович",
                Age = 30,
                Phone = "+79111111111",
                City = "Санкт-Петербург",
                Position = "Менеджер",
                EmploymentDate = new DateTime(2018, 8, 15)
            },
            new Employee
            {
                Id = 3,
                LastName = "Сидоров",
                FirstName = "Сидор",
                MiddleName = "Сидорович",
                Age = 20,
                Phone = "+79222222222",
                City = "Санкт-Петербург",
                Position = "Экспедитор",
                EmploymentDate = new DateTime(2020, 6, 10)
            },
        };      

       public static List<CartProduct> CartProducts { get; } = new()
        {
            new CartProduct
            {
                Id = 1,
                ProductId = 2,
                ProductCount = 2,                
            },
            new CartProduct
            {
                Id = 2,
                ProductId = 3,
                ProductCount = 1,                
            },
            new CartProduct
            {
                Id = 3,
                ProductId = 4,
                ProductCount = 1,                
            },
        };

        public static IEnumerable<Section> Sections { get; } = new[]
      {
              new Section { Id = 1, Name = "Спорт", Order = 0 },
              new Section { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
              new Section { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
              new Section { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
              new Section { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
              new Section { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
              new Section { Id = 7, Name = "Для мужчин", Order = 1 },
              new Section { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
              new Section { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
              new Section { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
              new Section { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
              new Section { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
              new Section { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
              new Section { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
              new Section { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
              new Section { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
              new Section { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
              new Section { Id = 18, Name = "Для женщин", Order = 2 },
              new Section { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
              new Section { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
              new Section { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
              new Section { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
              new Section { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
              new Section { Id = 24, Name = "Для детей", Order = 3 },
              new Section { Id = 25, Name = "Мода", Order = 4 },
              new Section { Id = 26, Name = "Для дома", Order = 5 },
              new Section { Id = 27, Name = "Интерьер", Order = 6 },
              new Section { Id = 28, Name = "Одежда", Order = 7 },
              new Section { Id = 29, Name = "Сумки", Order = 8 },
              new Section { Id = 30, Name = "Обувь", Order = 9 },
        };

        public static IEnumerable<Brand> Brands { get; } = new[]
        {
            new Brand { Id = 1, Name = "Acne", Order = 0 },
            new Brand { Id = 2, Name = "Grune Erde", Order = 1 },
            new Brand { Id = 3, Name = "Albiro", Order = 2 },
            new Brand { Id = 4, Name = "Ronhill", Order = 3 },
            new Brand { Id = 5, Name = "Oddmolly", Order = 4 },
            new Brand { Id = 6, Name = "Boudestijn", Order = 5 },
            new Brand { Id = 7, Name = "Rosch creative culture", Order = 6 },
        };

        public static IEnumerable<Image> Images { get; } = new[]
       {
            new Image { Id = 1, Url = "product1.jpg", Name = "product1.jpg" },
            new Image { Id = 2, Url = "product2.jpg", Name = "product2.jpg" },
            new Image { Id = 3, Url = "product3.jpg", Name = "product3.jpg" },
            new Image { Id = 4, Url = "product4.jpg", Name = "product4.jpg" },
            new Image { Id = 5, Url = "product5.jpg", Name = "product5.jpg" },
            new Image { Id = 6, Url = "product6.jpg", Name = "product6.jpg" },
            new Image { Id = 7, Url = "product7.jpg", Name = "product7.jpg" },
            new Image { Id = 8, Url = "product8.jpg", Name = "product8.jpg" },
            new Image { Id = 9, Url = "product9.jpg", Name = "product9.jpg" },
            new Image { Id = 10, Url = "product10.jpg", Name = "product10.jpg" },
            new Image { Id = 11, Url = "product11.jpg", Name = "product11.jpg" },
            new Image { Id = 12, Url = "product12.jpg", Name = "product12.jpg" },
        };

        public static IEnumerable<Product> Products { get; } = new[]
        {
            new Product { Id = 1, Name = "Белое платье", Price = 1025, ImageId = 1, Order = 0, SectionId = 2, BrandId = 1, WebId = 0000111 },
            new Product { Id = 2, Name = "Розовое платье", Price = 1025, ImageId = 2, Order = 1, SectionId = 2, BrandId = 1, WebId = 0000112 },
            new Product { Id = 3, Name = "Красное платье", Price = 1025, ImageId = 3, Order = 2, SectionId = 2, BrandId = 1, WebId = 0000113 },
            new Product { Id = 4, Name = "Джинсы", Price = 1025, ImageId = 4, Order = 3, SectionId = 2, BrandId = 1, WebId = 0000114 },
            new Product { Id = 5, Name = "Лёгкая майка", Price = 1025, ImageId = 5, Order = 4, SectionId = 2, BrandId = 2, WebId = 0000115 },
            new Product { Id = 6, Name = "Лёгкое голубое поло", Price = 1025, ImageId = 6, Order = 5, SectionId = 2, BrandId = 1, WebId = 0000116 },
            new Product { Id = 7, Name = "Платье белое", Price = 1025, ImageId = 7, Order = 6, SectionId = 2, BrandId = 1, WebId = 0000117 },
            new Product { Id = 8, Name = "Костюм кролика", Price = 1025, ImageId = 8, Order = 7, SectionId = 25, BrandId = 1, WebId = 0000118 },
            new Product { Id = 9, Name = "Красное китайское платье", Price = 1025, ImageId = 9, Order = 8, SectionId = 25, BrandId = 1, WebId = 0000119 },
            new Product { Id = 10, Name = "Женские джинсы", Price = 1025, ImageId = 10, Order = 9, SectionId = 25, BrandId = 3, WebId = 0000120 },
            new Product { Id = 11, Name = "Джинсы женские", Price = 1025, ImageId = 11, Order = 10, SectionId = 25, BrandId = 3, WebId = 0000121 },
            new Product { Id = 12, Name = "Летний костюм", Price = 1025, ImageId = 12, Order = 11, SectionId = 25, BrandId = 3, WebId = 0000122 },
        };

       
    }
}
