using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;


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
