using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;
        private readonly IWebHostEnvironment _appEnvironment;

        public CatalogController(IProductData ProductData, IWebHostEnvironment appEnvironment)
        {
            _ProductData = ProductData;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;   // количество элементов на странице

            IEnumerable<Product> source = _ProductData.GetProducts();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            AdminCatalogViewModel viewModel = new AdminCatalogViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View("Add", new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile uploadedFile, Product product)
        {
            Image image = new Image();
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/images/shop/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                // Image image = new Image { Name = uploadedFile.FileName, Url = uploadedFile.FileName };
                image.Name = uploadedFile.FileName;
                image.Url = uploadedFile.FileName;                
            }

            await _ProductData.AddProduct(product, image);

            return RedirectToAction(nameof(Index));
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

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile, int productId)
        {            
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/images/shop/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                Image image = new Image { Name = uploadedFile.FileName, Url = uploadedFile.FileName };

                await _ProductData.AddImage(image, productId);
                               
            }
            return RedirectToAction(nameof(Edit), new { id = productId });           
        }
    }
}
