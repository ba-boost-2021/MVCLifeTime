using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery]int id)
        {
            if (id == 0)
            {
                logger.LogWarning("Değer pozitif olmalı");
                return BadRequest();
            }
            if (id < 0)
            {
                logger.LogError("Negatif id sorunsalı");
                return BadRequest();
            }
            var result = new ProductListDTO();
            result.Id = id;
            result.Name = "Can Perk";
            logger.LogInformation("Ürün bilgisi cevabı verildi");
            return Ok(result);
        }

        [HttpGet("list")]
        public IActionResult GetProducts()
        {
            var result = productService.GetProducts();
            return Ok(result);
        }

        [HttpGet("filter-by-category/{categoryId}")]
        public IActionResult FilterByCategory([FromRoute]int categoryId)
        {
            var result = productService.Filter(new FilterProductDTO {  CategoryId = categoryId });
            return Ok(result);
        }

        [HttpPost("filter")]
        public IActionResult FilterProducts([FromBody] FilterProductDTO data)
        {
            var result = productService.Filter(data);
            return Ok(result);
        }

        [HttpGet("filter2")]
        public IActionResult FilterProducts2([FromQuery] FilterProductDTO data)
        {
            var result = productService.Filter(data);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody] NewProductDTO data)
        {
            var saved = productService.Save(data);
            return saved ? Ok() : BadRequest();
        }
    }
}
