using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ornek1.Models
{
    [Table("UrunKategori")]
    public class UrunKategori
    {
        [Key]
        public int Id { get; set; }
        public int? KategoriId { get; set; }
        public int? UrunId { get; set; } 

        [ForeignKey("UrunId")]
        public virtual Urun? Urun { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori? Kategori { get; set; }

    }
}
