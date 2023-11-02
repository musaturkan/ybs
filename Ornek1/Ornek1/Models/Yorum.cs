namespace Ornek1.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public int UrunId { get; set; }
        public Models.Urun Urun { get; set; }
    }
}
