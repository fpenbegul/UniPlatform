using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniPlatform.Models
{
    public class IlanYorumlar
    {
        [Key]
        public int YorumID { get; set; }
        [ForeignKey("Ilanlar")]
        public int IlanID { get; set; }
        public virtual Ilanlar Ilanlar { get; set; }
        public string YorumIcerik { get; set; }
    }
}