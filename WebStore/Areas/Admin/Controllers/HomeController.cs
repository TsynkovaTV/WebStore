using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class HomeController : Controller
    {
        private readonly IProductData _ProductData;

        public HomeController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
