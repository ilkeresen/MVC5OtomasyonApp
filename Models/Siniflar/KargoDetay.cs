using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string KargoDetayAciklama { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string KargoDetayTakipKodu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KargoDetayPersonel { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string KargoDetayAlici { get; set; }

        public DateTime KargoTarih { get; set; }
    }
}