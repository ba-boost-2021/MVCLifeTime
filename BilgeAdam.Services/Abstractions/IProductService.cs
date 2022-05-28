using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface IProductService
    {
        List<ProductListDTO> GetProducts(int? categoryId = null);
        bool Save(NewProductDTO data);
        List<ProductListDTO> GetPagedProducts(int count, int page);
        List<ProductListDTO> Filter(FilterProductDTO data);
        BasicProductInfo GetInformation(int id);
    }
}