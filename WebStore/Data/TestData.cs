using System;
using System.Collections.Generic;
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
                Patronymic = "Иванович",
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
                Patronymic = "Петрович",
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
                Patronymic = "Сидорович",
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
                Product = new Product
                {
                    Id = 1,
                    Image = "images/cart/one.png",
                    Description = "Colorblock Scuba",
                    WebId = "1089772",
                    Price = 59,
                },
                Count = 2,
                TotalSum = 118,
            },
            new CartProduct
            {
                Id = 2,
                Product = new Product
                {
                    Id = 1,
                    Image = "images/cart/two.png",
                    Description = "Colorblock Scuba",
                    WebId = "1089772",
                    Price = 59,
                },
                Count = 1,
                TotalSum = 59,
            },
            new CartProduct
            {
                Id = 3,
                Product = new Product
                {
                    Id = 1,
                    Image = "images/cart/three.png",
                    Description = "Colorblock Scuba",
                    WebId = "1089772",
                    Price = 59,
                },
                Count = 1,
                TotalSum = 59,
            },
        };
    }
}
