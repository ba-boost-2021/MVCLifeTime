using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface ISupplierService
    {
        List<OptionDTO> Options();
    }
}