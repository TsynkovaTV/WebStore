﻿using System;

namespace WebStore.Models
{ 
    /// <summary>Сотрудник</summary>
    public class Employee
    {
        public int Id { get; set; }

        /// <summary>Имя</summary>
        public string FirstName { get; set; }

        /// <summary>Фамилия</summary>
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        public string Patronymic { get; set; }

        /// <summary>Возраст</summary>
        public int Age { get; set; }

        /// <summary>Телефон</summary>
        public string Phone { get; set; }

        /// <summary>Город</summary>
        public string City { get; set; }
       
        /// <summary>Должность</summary>
        public string Position { get; set; }

        /// <summary>Дата трудоустройства</summary>
        public DateTime EmploymentDate { get; set; }

    }
}
