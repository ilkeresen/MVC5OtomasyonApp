using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En Fazla 100 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string FaturaKalemAciklama { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public int FaturaKalemMiktar { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public decimal FaturaKalemBirimFiyat { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public decimal FaturaKalemTutar { get; set; }
        public int Faturaid { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}