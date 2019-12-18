using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniPlatform.Models
{
    public class Ilanlar
    {
        [Key]
        public int ID { get; set; }
        [DataType("datetime2")]
        public DateTime IlanTarihi { get; set; }
        public string IlanBaslik { get; set; }
        public string Icerik { get; set; }
        public string ResimYol { get; set; }
        public decimal Fiyat { get; set; }
        public bool OnayliMi { get; set; }


        [ForeignKey("ApplicationUser")]
        public string IlanSahibiId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<IlanYorumlar> IlanYorumlar { get; set; }
    }
}