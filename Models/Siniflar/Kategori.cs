using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string KategoriAD { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}