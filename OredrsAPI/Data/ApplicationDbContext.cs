using Microsoft.EntityFrameworkCore;
using OredrsAPI.Data.Models.Order;
using OredrsAPI.Data.Models.Product;

namespace OredrsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<OrderEntry> Orders { get; set; }
        public DbSet<ProductEntry> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
