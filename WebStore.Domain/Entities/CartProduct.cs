﻿

namespace WebStore.Domain.Entities
{
    public class CartProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductCount { get; set; }
    }
}
