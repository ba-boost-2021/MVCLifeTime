using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Concretes
{
    internal class ProductService : IProductService
    {
        private readonly NorthwindContext context;

        public ProductService(NorthwindContext context)
        {
            this.context = context;
        }
        public List<ProductListDTO> GetProducts()
        {
            return context.Products
                          .Select(s => new ProductListDTO
                          {
                              Id = s.ProductID,
                              Name = s.ProductName,
                              Category = s.Category != null ? s.Category.CategoryName : null,
                              Price = s.UnitPrice,
                              Stock = s.UnitsInStock
                          })
                          .ToList();
        }
    }
}