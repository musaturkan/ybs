﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Market
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        public string? Ad { get; set; }
        public decimal? Fiyat { get; set; }
        public string? Aciklama { get; set; }

        [ForeignKey("Marka")]
        public int? MarkaId { get; set; }
        public string? ImageAdres { get; set; }
        public Marka? Marka { get; set; }
        public virtual ICollection<Yorum>? Yorum { get; set; }
        public virtual ICollection<UrunKategori>? UrunKategori { get; set; }

    }
}
