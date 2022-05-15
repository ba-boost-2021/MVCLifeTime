using BilgeAdam.Services.Contracts;

namespace BilgeAdam.MVCRocks.Models
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Items = new List<ProductListDTO>();
        }
        public List<ProductListDTO> Items { get; set; }
        public bool IsEmpty => !Items.Any();
    }
}
