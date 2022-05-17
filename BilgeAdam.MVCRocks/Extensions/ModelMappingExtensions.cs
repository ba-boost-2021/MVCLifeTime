using BilgeAdam.MVCRocks.Models;
using BilgeAdam.Services.Contracts;

namespace BilgeAdam.MVCRocks.Extensions
{
    public static class ModelMappingExtensions
    {
        public static NewProductDTO ToDTO(this NewProductViewModel model)
        {
            return new NewProductDTO
            {
                Name = model.Name,
                CategoryID = model.CategoryId,
                Price = model.Price,
                Stock = model.Stock,
                SupplierID = model.SupplierId
            };
        }
    }
}
