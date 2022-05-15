using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVCRocks.Controllers
{
    public class AlternateProductController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public AlternateProductController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public IActionResult Products()
        {
            var products = productService.GetProducts(0);
            return View(products);
        }

        public IActionResult Categories()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
//FAT CONTROLLER