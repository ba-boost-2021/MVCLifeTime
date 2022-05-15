using BilgeAdam.Data.Context;
using BilgeAdam.MVCRocks.Models;
using BilgeAdam.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVCRocks.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Products([FromServices] IProductService productService, int? categoryId)
        {
            var products = productService.GetProducts(categoryId);
            var vm = new ProductListViewModel
            {
                Items = products
            };
            return View(vm);
    }
}
}
//FAT CONTROLLER