using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MesajGonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MesajAlici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MesajKonu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        [AllowHtml]
        public string MesajIcerik { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime MesajTarih { get; set; }
    }
}