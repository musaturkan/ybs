using System.ComponentModel.DataAnnotations;

namespace Ornek1.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? KisaAd { get; set; }
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
