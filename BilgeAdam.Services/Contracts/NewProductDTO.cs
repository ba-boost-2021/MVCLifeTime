namespace BilgeAdam.Services.Contracts
{
    public class NewProductDTO
    {
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public short? Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
