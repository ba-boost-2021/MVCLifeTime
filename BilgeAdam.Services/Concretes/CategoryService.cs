using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Concretes
{
    internal class CategoryService : ICategoryService
    {
        private readonly NorthwindContext context;

        public CategoryService(NorthwindContext context)
        {
            this.context = context;
        }

        public List<CategoryListDTO> GetCategories()
        {
            return context.Categories
                          .Select(s => new CategoryListDTO
                          {
                              Id = s.CategoryID,
                              Name = s.CategoryName
                          }).ToList();
        }

        public List<OptionDTO> Options()
        {
            return context.Categories
                          .Select(s => new OptionDTO
                          {
                              Value = s.CategoryID.ToString(),
                              Text = s.CategoryName
                          }).ToList();
        }
    }
}