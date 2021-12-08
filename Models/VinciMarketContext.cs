using Microsoft.EntityFrameworkCore;

namespace PFEBackend.Models
{
    public class VinciMarketContext : DbContext
    {
        public VinciMarketContext(DbContextOptions<VinciMarketContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Media> Media { get; set; }
    }
}
