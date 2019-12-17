using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniPlatform.Models
{
    public class DuyuruYorumlar
    {
        [Key]
        public int YorumID { get; set; }
        [ForeignKey("Duyurular")]
        public int DuyuruID { get; set; }
        public virtual Duyurular Duyurular { get; set; }
        public string YorumIcerik { get; set; }
        
        
    }
}