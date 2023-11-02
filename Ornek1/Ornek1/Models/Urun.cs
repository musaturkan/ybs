namespace Ornek1.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Fiyat { get; set; }
        public string Aciklama { get; set; }
        public int MarkaId { get; set; }
        public string ImageAdres { get; set; }
        public Models.Marka Marka { get; set; }
        public ICollection<Yorum> Yorum { get; set; }
    }
}
