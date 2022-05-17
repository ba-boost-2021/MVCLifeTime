using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.MVCRocks.Models
{
    public class NewProductViewModel
    {
        public string Name { get; set; }
        public short? Stock { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
