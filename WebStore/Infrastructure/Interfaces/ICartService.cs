﻿using System.Collections.Generic;
using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Interfaces
{
    public interface ICartService
    {
        void AddToCart(int id);

        void DecrementFromCart(int id);

        void RemoveFromCart(int id);

        void Clear();

        CartViewModel TransformFromCart();
        
       // IEnumerable<CartProduct> GetCartProducts();
    }
}