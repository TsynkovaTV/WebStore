using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeesViewModel
    {
        [HiddenInput(DisplayValue = false)]       
        public int Id { get; set; }

        /// <summary>Имя</summary>
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Не указано имя")]
        [RegularExpression(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$", ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }

        /// <summary>Фамилия</summary>
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Не указана фамилия")]
        [RegularExpression(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$", ErrorMessage = "Некорректная фамилия")]
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        [Display(Name = "Отчество")]
        [RegularExpression(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$", ErrorMessage = "Некорректное отчество")]
        public string MiddleName { get; set; }

        /// <summary>Возраст</summary>
        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(18, 110, ErrorMessage = "Возраст сотрудников должен быть от 18 до 110 лет")]
        public int Age { get; set; }

        /// <summary>Телефон</summary>
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }

        /// <summary>Город</summary>
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Не указан город")]
        public string City { get; set; }

        /// <summary>Должность</summary>
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Не указана должность")]
        public string Position { get; set; }

        /// <summary>Дата трудоустройства</summary>
        [Display(Name = "Дата трудоустройства")]
        [Required(ErrorMessage = "Не указана дата трудоустройства")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EmploymentDate { get; set; }
    }
}

