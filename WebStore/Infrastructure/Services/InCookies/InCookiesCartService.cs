using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Mapping;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services.InCookies
{
    public class InCookiesCartService : ICartService
    {
        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly string _CartName;

        private Cart Cart
        {
            get
            {
                var context = _HttpContextAccessor.HttpContext;
                var cookies = context!.Response.Cookies;
                var cart_cookie = context.Request.Cookies[_CartName];
                if (cart_cookie is null)
                {
                    var cart = new Cart();
                    cookies.Append(_CartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }
                ReplaceCookies(cookies, cart_cookie);
                return JsonConvert.DeserializeObject<Cart>(cart_cookie);
            }

            set
            {
                ReplaceCookies(_HttpContextAccessor.HttpContext.Response.Cookies, JsonConvert.SerializeObject(value));
            }
        }

        private void ReplaceCookies(IResponseCookies cookies, string cookie)
        {
            cookies.Delete(_CartName);
            cookies.Append(_CartName, cookie);
        }

        public void AddToCart(int id)
        {
            var cart = Cart;
            var product = cart.Products.FirstOrDefault(p => p.ProductId == id);

            if (product is null)
                cart.Products.Add(new CartProduct { ProductId = id, ProductCount = 1 });
            else
                product.ProductCount++;
            Cart = cart;
        }

        public void DecrementFromCart(int id)
        {
            var cart = Cart;
            var product = cart.Products.FirstOrDefault(p => p.ProductId == id);

            if (product is null)
                return;
            if (product.ProductCount > 1)
                product.ProductCount--;
            else
                cart.Products.Remove(product);
            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var product = cart.Products.FirstOrDefault(p => p.ProductId == id);

            if (product is null)
                return;            
            cart.Products.Remove(product);

            Cart = cart;
        }

        public void Clear()
        {
            var cart = Cart;
            cart.Products.Clear();
            Cart = cart;
        }

        public CartViewModel TransformFromCart()
        {
            var products = _ProductData.GetProducts(new ProductFilter
            {
                Ids = Cart.Products.Select(p => p.ProductId).ToArray()
            });

            var product_view_model = products.ToView().ToDictionary(p => p.Id);
            return new CartViewModel
            {
                Products = Cart.Products.Select(product => (product_view_model[product.ProductId], product.ProductCount))
            };
        }

        public InCookiesCartService(IProductData ProductData, IHttpContextAccessor HttpContextAccessor)
        {
            _ProductData = ProductData;
            _HttpContextAccessor = HttpContextAccessor;

            var user = HttpContextAccessor.HttpContext!.User;
            var user_name = user.Identity!.IsAuthenticated ? $"-{user.Identity.Name}" : null;

            _CartName = $"WebStore.Cart{user_name}";
        }
    }
}
