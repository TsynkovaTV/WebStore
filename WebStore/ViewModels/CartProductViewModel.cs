using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class CartProductViewModel
    {
        public int Id { get; set; }

        /// <summary>Товар</summary>
        public ProductViewModel Product { get; set; }

        /// <summary>Количество единиц товара</summary>
        public int ProductCount { get; set; }

        /// <summary>Общая стоимость</summary>
        public decimal TotalSum
        {
            get
            {
                return Product.Price * ProductCount;
            }
        }
    }
}
