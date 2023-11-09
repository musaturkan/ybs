using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ornek1.Models
{
    public class Yorum
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public DateTime EklemeTarihi { get; set; }
        [ForeignKey("Urun")]
        public int? UrunId { get; set; }
        public Models.Urun Urun { get; set; }

        [ForeignKey("Kullanici")]
        public int? KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
