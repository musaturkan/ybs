using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Market
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }
        public int? KullaniciId { get; set; }
        public string? Tarayici { get; set; }
        public string? Ip { get; set; }
        public string? TalepYapilanUrl { get; set; }
        public string? Parametre { get; set; }
        public string? MetotAdi { get; set; }
    }
}
