
namespace WebStore.Models
{
    /// <summary>Товар</summary>
    public class Product
    {
        public int Id { get; set; }

        /// <summary>Описание</summary>
        public string Description { get; set; }

        public string WebId { get; set; }

        /// <summary>Цена</summary>
        public decimal Price { get; set; }

        /// <summary>Ссылка на фото</summary>
        public string Image { get; set; }
    }
}
