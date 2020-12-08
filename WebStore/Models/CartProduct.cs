
namespace WebStore.Models
{
    /// <summary>Товар, добавленный в корзину</summary>
    public class CartProduct
    {
        public int Id { get; set; }

        /// <summary>id товара</summary>
        public Product Product { get; set; }

        /// <summary>Количество единиц товара</summary>
        public int Count { get; set; }

        /// <summary>Общая стоимость</summary>
        public decimal TotalSum { get; set; }
    }
}
