﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ornek1.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? KisaAd { get; set; }
        
        public virtual ICollection<UrunKategori>? UrunKategori { get; set; }
    }
}
