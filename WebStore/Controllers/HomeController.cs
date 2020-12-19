using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _Configuration;
        private readonly ICartService _CartData;

        public HomeController(IConfiguration Configuration, ICartService CartData) 
        {
            _Configuration = Configuration;
            _CartData = CartData;
        }

        public IActionResult Index() => View();
       

        public IActionResult Employees()
        {
            return View(TestData.Employees);
        }

        public IActionResult Blogs() => View();

        public IActionResult BlogSingle() => View();

       /* public IActionResult Cart()
        {
            var cartProducts = _CartData.GetCartProducts();

            return View(new CartViewModel
            {
                    Products = cartProducts                   
                   .Select(cp => new CartProductViewModel
                   {
                       Id = cp.Id,
                       ProductCount = cp.ProductCount,
                       Product = TestData.Products
                            .Where(p => p.Id == cp.ProductId)
                            .Select(p => new ProductViewModel
                            { 
                                Id = p.Id,
                                Name = p.Name,
                                ImageUrl = p.ImageUrl,
                                Price = p.Price,
                            })
                            .FirstOrDefault(),                       
                   })                       
            });
        }

        public IActionResult Checkout()
        {
            {
                var cartProducts = _CartData.GetCartProducts();

                return View(new CartViewModel
                {
                    Products = cartProducts
                       .Select(cp => new CartProductViewModel
                       {
                           Id = cp.Id,
                           ProductCount = cp.ProductCount,
                           Product = TestData.Products
                                .Where(p => p.Id == cp.ProductId)
                                .Select(p => new ProductViewModel
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    ImageUrl = p.ImageUrl,
                                    Price = p.Price,
                                })
                                .FirstOrDefault(),
                       })
                });
            }
        }*/

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult Shop() => View();

        public IActionResult Error404() => View();
    }
}
