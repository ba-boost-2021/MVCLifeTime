using System.ComponentModel.DataAnnotations.Schema;

namespace BilgeAdam.Data.Entities
{
    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }

        [ForeignKey(nameof(SupplierID))]
        public Supplier Supplier { get; set; }
    }
}