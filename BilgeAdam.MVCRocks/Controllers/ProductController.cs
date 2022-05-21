using BilgeAdam.MVCRocks.Extensions;
using BilgeAdam.MVCRocks.Models;
using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVCRocks.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Products([FromServices] IProductService productService, int? categoryId)
        {
            var products = productService.GetProducts(categoryId);
            var vm = new ProductListViewModel
            {
                Items = products
            };
            return View(vm);
        }

        public IActionResult ProductsWithAjax()
        {
            return View("AjaxPage");
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NewProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var dto = model.ToDTO();
            productService.Save(dto);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult PagedProducts(int count, int page)
        {
            var products = productService.GetPagedProducts(count, page);
            return Json(products);
        }
    }
}

//FAT CONTROLLER