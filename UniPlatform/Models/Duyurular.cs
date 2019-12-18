using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniPlatform.Models
{
    public class Duyurular
    {
        [Key]
        public int ID { get; set; }
        [DataType("datetime2")]
        public DateTime DuyuruTarihi { get; set; }
        public string DuyuruBaslik { get; set; }
        public string Icerik { get; set; }
        public bool OnayliMi { get; set; }

        [ForeignKey("ApplicationUser")]
        public string DuyuranId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<DuyuruYorumlar> DuyuruYorumlar { get; set; }
    }
}