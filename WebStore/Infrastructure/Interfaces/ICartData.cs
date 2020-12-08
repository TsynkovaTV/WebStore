using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    public interface ICartData
    {
        IEnumerable<CartProduct> GetCartProducts();
    }
}
