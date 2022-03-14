using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string DepartmanAd { get; set; }

        public bool DepartmanDurum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}