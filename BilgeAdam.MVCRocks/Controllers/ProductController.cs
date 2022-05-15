using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVCRocks.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Products([FromServices] IProductService productService)
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public IActionResult Categories([FromServices] ICategoryService categoryService)
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
//FAT CONTROLLER