﻿namespace BilgeAdam.Services.Contracts
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public short? Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
