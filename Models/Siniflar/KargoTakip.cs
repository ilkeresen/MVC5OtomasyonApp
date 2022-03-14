using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargaTakipID { get; set; }

        [Column(TypeName="VarChar")]
        [StringLength(10)]
        public string KargoTakipKodu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string KargoTakipAciklama { get; set; }

        public DateTime KargoTakipTarih { get; set; }
    }
}