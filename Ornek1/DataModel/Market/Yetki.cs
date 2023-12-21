using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Market
{
    [Table("Yetki")]
    public class Yetki
    {
        [Key]
        public int Id { get; set; }
        public int MetotId { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public virtual Rol Rol { get; set; }

        [ForeignKey("MetotId")]
        public virtual Metot Metot { get; set; }
    }
}
