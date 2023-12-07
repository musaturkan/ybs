using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Market
{
    [Table("Kullanici")]
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Parola { get; set; }
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}
