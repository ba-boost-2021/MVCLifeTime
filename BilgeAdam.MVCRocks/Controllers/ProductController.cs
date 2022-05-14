using BilgeAdam.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.MVCRocks.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext context;

        public ProductController(NorthwindContext context)
        {
            this.context = context;
        }

        public IActionResult Products()
        {
            return View(); 
        }
    }
}
