using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    public class Product : NamedEntity, IOrderedEntity
    {
        [Display(Name = "Порядковый номер")]
        [Required(ErrorMessage = "Не указан порядковый номер")]
        public int Order { get; set; }

        [Display(Name = "Идентификатор секции")]
        [Required(ErrorMessage = "Не указан идентификатор секции")]
        public int SectionId { get; set; }

        [Display(Name = "Секция")]
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }

        [Display(Name = "Бренд")]
        public int? BrandId { get; set; }

        [Display(Name = "Бренд")]
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        /*
         [Display(Name = "Фото товара")]
         [Required(ErrorMessage = "Не указано имя файла с фотографией товара")]
         public string ImageUrl { get; set; }
        */

        [Display(Name = "Фото товара")]
        public int? ImageId { get; set; }

        [Display(Name = "Фото товара")]
        [ForeignKey(nameof(ImageId))]
        public Image Image { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Не указана цена")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Артикул")]
        [Required(ErrorMessage = "Не указан артикул")]
        public int WebId { get; set; }
    }
}
