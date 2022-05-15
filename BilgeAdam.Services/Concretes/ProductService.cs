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
        public List<ProductListDTO> GetProducts(int? categoryId)
        {
            var query = context.Products.AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(f => f.CategoryID == categoryId.Value);
            }
            return query.Select(s => new ProductListDTO
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