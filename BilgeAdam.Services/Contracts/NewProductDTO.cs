using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.Services.Contracts
{
    public class NewProductDTO
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public short Stock { get; set; }
        public decimal Price { get; set; }
    }

    public class FilterProductDTO
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public string Name { get; set; }
    }
}
