using BilgeAdam.Data.Context;
using BilgeAdam.Data.Entities;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BilgeAdam.Services.Concretes
{
    internal class ProductService : IProductService
    {
        private readonly NorthwindContext context;

        public ProductService(NorthwindContext context)
        {
            this.context = context;
        }

        public List<ProductListDTO> GetPagedProducts(int count, int page)
        {
            return context.Products
                .Skip((page - 1) * count)
                .Take(count)
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

        public void Save(NewProductDTO data)
        {
            var entity = new Product
            { 
                ProductName = data.Name,
                UnitPrice = data.Price,
                UnitsInStock = data.Stock,
                CategoryID = data.CategoryID,
                SupplierID = data.SupplierID
            };
            context.Products.Add(entity);
            context.SaveChanges();
        }
    }
}