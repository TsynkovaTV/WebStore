using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _Configuration;

        private static readonly List<Employee> __Employees = new()
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

        public HomeController(IConfiguration configuration) 
        {
            _Configuration = configuration;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View(__Employees);
        }

        public IActionResult Details(int employeeId)
        {
            var employee = __Employees.First(e => e.Id == employeeId);
            return View(employee);
        }
    }
}
