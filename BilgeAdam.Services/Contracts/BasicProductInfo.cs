namespace BilgeAdam.Services.Contracts
{
    public class BasicProductInfo
    {
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
    }

    public class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
