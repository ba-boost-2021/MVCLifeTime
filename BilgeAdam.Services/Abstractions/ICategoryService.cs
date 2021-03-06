using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface ICategoryService
    {
        List<CategoryListDTO> GetCategories();
        List<OptionDTO> Options();
    }
}