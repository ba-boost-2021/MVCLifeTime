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

        public List<ProductListDTO> Filter(FilterProductDTO data)
        {
            var query = context.Products.AsQueryable();
            if (data.CategoryId.HasValue)
            {
                query = query.Where(f => f.CategoryID == data.CategoryId.Value);
            }
            if (data.SupplierId.HasValue)
            {
                query = query.Where(f => f.SupplierID == data.SupplierId.Value);
            }
            if (!string.IsNullOrWhiteSpace(data.Name))
            {
                query = query.Where(f => f.ProductName.StartsWith(data.Name.Trim()));
            }
            return query.Select(s => new ProductListDTO
            {
                Id = s.ProductID,
                Name = s.ProductName,
                Category = s.Category != null ? s.Category.CategoryName : null,
                Price = s.UnitPrice,
                Stock = s.UnitsInStock
            }).ToList();
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

        public bool Save(NewProductDTO data)
        {
            var categoryExist = context.Categories.Any(f => f.CategoryID == data.CategoryID);
            if (!categoryExist)
            {
                return false;
            }
            var entity = new Product
            { 
                ProductName = data.Name,
                UnitPrice = data.Price,
                UnitsInStock = data.Stock,
                CategoryID = data.CategoryID,
                SupplierID = data.SupplierID
            };
            context.Products.Add(entity);
            var result = context.SaveChanges();
            return result > 0;
        }
    }
}