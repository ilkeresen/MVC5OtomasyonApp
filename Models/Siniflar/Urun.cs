using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunAciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunMarka { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public short UrunStok { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public decimal UrunAlisFiyat { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public decimal UrunSatisFiyat { get; set; }
        public bool UrunDurum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En Fazla 250 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string UrunGorsel { get; set; }

        public int Kategoriid { get; set; }

        public virtual Kategori Kategori { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}