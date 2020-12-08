using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.Data;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _Configuration;       

        public HomeController(IConfiguration configuration) 
        {
            _Configuration = configuration;
        }

        public IActionResult Index() => View();
       

        public IActionResult Employees()
        {
            return View(TestData.Employees);
        }

        public IActionResult Blogs() => View();

        public IActionResult BlogSingle() => View();

        public IActionResult Cart() => View(TestData.CartProducts);

        public IActionResult Checkout() => View(TestData.CartProducts);

        public IActionResult ContactUs() => View();

        public IActionResult Login() => View();

        public IActionResult ProductDetails() => View();

        public IActionResult Shop() => View();

        public IActionResult Error404() => View();
    }
}
