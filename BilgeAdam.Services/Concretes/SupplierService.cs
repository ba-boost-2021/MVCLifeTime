using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Concretes
{
    internal class SupplierService : ISupplierService
    {
        private readonly NorthwindContext context;

        public SupplierService(NorthwindContext context)
        {
            this.context = context;
        }
        public List<OptionDTO> Options()
        {
            return context.Suppliers
                          .Select(s => new OptionDTO
                          {
                              Value = s.SupplierID.ToString(),
                              Text = s.CompanyName
                          }).ToList();
        }
    }
}