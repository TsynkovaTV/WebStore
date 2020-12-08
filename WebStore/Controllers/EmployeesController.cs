using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("users")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _Employees;

        public EmployeesController(IEmployeesData Employees) => _Employees = Employees;

        public IActionResult Index()
        {
            var employees = _Employees.Get();
            return View(employees);
        }

       // [Route("{id}")]
        public IActionResult Details(int id)
        {
            var employee = _Employees.Get(id);
            if (employee is not null)
                return View(employee);
            return NotFound();
        }

        //[Route("create")]
        public IActionResult Create() => View("Edit", new EmployeesViewModel { EmploymentDate = DateTime.Today });

        //[Route("edit")]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeesViewModel());

            if (id < 0)
                return BadRequest();

            var employee = _Employees.Get((int)id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                Name = employee.FirstName,
                MiddleName = employee.MiddleName,
                Age = employee.Age,
                Phone = employee.Phone,
                City = employee.City,
                Position = employee.Position,
                EmploymentDate = employee.EmploymentDate,
            });
        }

        [HttpPost]
       // [Route("edit")]
        public IActionResult Edit(EmployeesViewModel Model)
        {
            if (Model.LastName == "Иванов" && Model.Name == "Фёдор" && Model.MiddleName == "Петрович")
                ModelState.AddModelError("", "Подозрительная личность");
            
            if (Model.Age == 25)
                ModelState.AddModelError("Age", "Возраст не должен быть равен 25");
           
            if (!ModelState.IsValid) return View(Model);
            
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            var employee = new Employee
            {
                Id = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.Name,
                MiddleName = Model.MiddleName,
                Age = Model.Age,
                Phone = Model.Phone,
                City = Model.City,
                Position = Model.Position,
                EmploymentDate = Model.EmploymentDate,
            };

            if (employee.Id == 0)
                _Employees.Add(employee);
            else
                _Employees.Update(employee);

            return RedirectToAction("Index");
        }

        //[Route("delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _Employees.Get(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                Name = employee.FirstName,
                MiddleName = employee.MiddleName,
                Age = employee.Age,
                Phone = employee.Phone,                
                City = employee.City,
                Position = employee.Position,
                EmploymentDate = employee.EmploymentDate,
            });
        }

        [HttpPost]
       // [Route("deleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _Employees.Delete(id);
            return RedirectToAction("Index");
        }        
    }
}
