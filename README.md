# MVC5OtomasyonApp
Projeden bir kaç görsel resim <p>
  Bootstrap adminlte ile tasarlandı. <p>
![](https://i.hizliresim.com/jza7rl4.jpg)
![](https://i.hizliresim.com/wsegkz1.jpg)
<p>
     Tema ve Tablolar responsive DataTable ile yapıldı.
  
![](https://i.hizliresim.com/22s9p0v.jpg)
  ![](https://i.hizliresim.com/1h1pwim.jpg)
  ![](https://i.hizliresim.com/awzlkqu.jpg)
  ```javascript
  using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5TicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //Ürün
        //Cari
        //Personel

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public DateTime SatisTarih { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public int SatisAdet { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public decimal SatisFiyat { get; set; }

        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsiniz!")]
        public decimal SatisToplamTutar { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
  ```
  ![](https://i.hizliresim.com/g6ddr7j.jpg)
  ```javascript
  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var satislar = c.SatisHarekets.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();

            ViewBag.Urunler = urunler;
            ViewBag.Cariler = cariler;
            ViewBag.Personeller = personeller;
            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(SatisHareket s)
        {
            s.SatisTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisGuncelle(int id)
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();

            ViewBag.Urunler = urunler;
            ViewBag.Cariler = cariler;
            ViewBag.Personeller = personeller;
            var satis = c.SatisHarekets.Find(id);
            return View("SatisGuncelle", satis);
        }
        [HttpPost]
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var satis = c.SatisHarekets.Find(s.SatisID);
            satis.Urunid = s.Urunid;
            satis.Cariid = s.Cariid;
            satis.Personelid = s.Personelid;
            satis.SatisAdet = s.SatisAdet;
            satis.SatisFiyat = s.SatisFiyat;
            satis.SatisToplamTutar = s.SatisToplamTutar;
            satis.SatisTarih = s.SatisTarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var satislar = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(satislar);
        }
    }
}
  ```
  ![](https://i.hizliresim.com/t5s123p.jpg)
  ![](https://i.hizliresim.com/55yzxk2.jpg)
  ![](https://i.hizliresim.com/mpsyc4p.jpg)
  ```javascript
  USE [dataproje]
GO
/****** Object:  Trigger [dbo].[SatisStokAzalt]    Script Date: 14.03.2022 19:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[SatisStokAzalt]
On [dbo].[SatisHarekets]
After insert
as
Declare @Urunid int
Declare @Adet int
Select @Urunid=Urunid,@Adet=SatisAdet from inserted
Update Uruns set UrunStok = UrunStok-@Adet where UrunID=@Urunid
  ```
