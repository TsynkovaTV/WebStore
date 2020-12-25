﻿using System.ComponentModel.DataAnnotations;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
