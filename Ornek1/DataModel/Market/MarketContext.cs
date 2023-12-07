using Microsoft.EntityFrameworkCore;


namespace DataModel.Market
{
    public class MarketContext : DbContext
    {
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<UrunKategori> UrunKategori { get;set; }
        public DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = Market; Trusted_Connection = True; TrustServerCertificate=True");
        }
    }
}
