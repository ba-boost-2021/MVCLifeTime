using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface IProductService
    {
        public List<ProductListDTO> GetProducts();
    }
}