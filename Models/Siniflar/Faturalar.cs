using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public enum Ilceler
    {
        Adalar = 1,
        Arnavutköy = 2,
        Ataşehir = 3,
        Avcılar = 4,
        Bağcılar = 5,
        Bahçelievler = 6,
        Bakırköy = 7,
        Başakşehir = 8,
        Bayrampaşa = 9,
        Beşiktaş = 10,
        Beykoz = 11,
        Beylikdüzü = 12,
        Beyoğlu = 13,
        Büyükçekmece = 14,
        Çatalca = 15,
        Çekmeköy = 16,
        Esenler = 17,
        Esenyurt = 18,
        Eyüp = 19,
        Fatih = 20,
        Gaziosmanpaşa = 21,
        Güngören = 22,
        Kadıköy = 23,
        Kâğıthane = 24,
        Kartal = 25,
        Küçükçekmece = 26,
        Maltepe = 27,
        Pendik = 28,
        Sancaktepe = 29,
        Sarıyer = 30,
        Silivri = 31,
        Sultanbeyli = 32,
        Sultangazi = 33,
        Şile = 34,
        Şişli = 35,
        Tuzla = 36,
        Ümraniye = 37,
        Üsküdar = 38,
        Zeytinburnu = 39
    }

    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6, ErrorMessage = "En Fazla 6 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string FaturaSiraNo { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public DateTime FaturaTarih { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public Ilceler FaturaVergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5, ErrorMessage = "En Fazla 5 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string FaturaSaat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string FaturaTeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public string FaturaTeslimAlan { get; set; }

        public decimal FaturaToplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}