using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface IProductService
    {
        List<ProductListDTO> GetProducts(int? categoryId);
        void Save(NewProductDTO data);
    }
}