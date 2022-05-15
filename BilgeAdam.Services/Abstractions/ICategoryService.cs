using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface ICategoryService
    {
        public List<CategoryListDTO> GetCategories();
    }
}