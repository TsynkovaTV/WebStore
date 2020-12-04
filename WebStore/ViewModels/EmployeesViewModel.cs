using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeesViewModel
    {
        public int Id { get; set; }

        /// <summary>Имя</summary>
        [Required(ErrorMessage = "Не указано имя")]
        [RegularExpression(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$", ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }

        /// <summary>Фамилия</summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        [RegularExpression(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$", ErrorMessage = "Некорректная фамилия")]
        public string LastName { get; set; }

        /// <summary>Отчество</summary>
        [RegularExpression(@"([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$", ErrorMessage = "Некорректное отчество")]
        public string MiddleName { get; set; }

        /// <summary>Возраст</summary>
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(18, 110, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        /// <summary>Телефон</summary>
        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }

        /// <summary>Город</summary>
        [Required(ErrorMessage = "Не указан город")]
        public string City { get; set; }

        /// <summary>Должность</summary>
        [Required(ErrorMessage = "Не указана должность")]
        public string Position { get; set; }

        /// <summary>Дата трудоустройства</summary>
        [Required(ErrorMessage = "Не указана дата трудоустройства")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EmploymentDate { get; set; }
    }
}

