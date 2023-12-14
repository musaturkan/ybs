using System.ComponentModel.DataAnnotations;

namespace Ornek1.Models
{
    public class Oturum_VM
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string Parola { get; set; }
    }
}
