using System.ComponentModel.DataAnnotations.Schema;

namespace BilgeAdam.Data.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
