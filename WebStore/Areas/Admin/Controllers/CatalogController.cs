using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        public IActionResult Index()
        {            
            return View(_ProductData.GetProducts());
        }

        
        public IActionResult Edit(int id)
        {
            if (id < 0)
                return BadRequest();
            
            Product product = _ProductData.GetProductById(id);

            if (product is null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            Product savedProduct = _ProductData.GetProductById(product.Id);

            if (savedProduct is null)
                return NotFound();

            await _ProductData.EditProduct(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _ProductData.GetProductById(id);
            if (product is null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Product savedProduct = _ProductData.GetProductById(id);

            if (savedProduct is null)
                return NotFound();

            await _ProductData.DeleteProduct(id);


            return RedirectToAction(nameof(Index));
        }

    }
}
