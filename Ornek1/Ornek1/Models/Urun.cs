using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ornek1.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Fiyat { get; set; }
        public string Aciklama { get; set; }

        [ForeignKey("Marka")]
        public int MarkaId { get; set; }
        public string ImageAdres { get; set; }
        public Models.Marka Marka { get; set; }
        public ICollection<Yorum> Yorum { get; set; }
    }
}
