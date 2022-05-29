using BilgeAdam.Common.Contracts;
using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Concretes
{
    internal class CategoryService : ICategoryService
    {
        private readonly NorthwindContext context;
        private readonly RegionalParameters regionalParameters;

        public CategoryService(NorthwindContext context, RegionalParameters regionalParameters)
        {
            this.context = context;
            this.regionalParameters = regionalParameters;
        }

        public List<CategoryListDTO> GetCategories()
        {
            return context.Categories
                          .Where(f => !regionalParameters.ExcludedCategories.Contains(f.CategoryID))
                          .Select(s => new CategoryListDTO
                          {
                              Id = s.CategoryID,
                              Name = s.CategoryName
                          }).ToList();
        }

        public List<OptionDTO> Options()
        {
            return context.Categories
                          .Where(f => !regionalParameters.ExcludedCategories.Contains(f.CategoryID))
                          .Select(s => new OptionDTO
                          {
                              Value = s.CategoryID.ToString(),
                              Text = s.CategoryName
                          }).ToList();
        }
    }
}