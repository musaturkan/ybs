using Microsoft.EntityFrameworkCore;

namespace Ornek1.Models
{
    public class MarketContext : DbContext
    {
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = Market; Trusted_Connection = True; TrustServerCertificate=True");
        }
    }
}
