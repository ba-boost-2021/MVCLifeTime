using BilgeAdam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.Data.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}