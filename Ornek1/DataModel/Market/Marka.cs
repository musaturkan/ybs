using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Market
{
    [Table("Marka")]
    public class Marka
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? LogoAdresi { get; set; }
        public string? WebAdresi { get; set; }
        public virtual ICollection<Urun>? Urun { get; set; }
    }
}
