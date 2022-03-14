using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.UrunDurum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> kategori = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAD,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.kategoricombobox = kategori;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            p.UrunDurum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.UrunDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kategori = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAD,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.kategoricombobox = kategori;
            var urun = c.Uruns.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = c.Uruns.Find(p.UrunID);
            urun.UrunAd = p.UrunAd;
            urun.UrunAciklama = p.UrunAciklama;
            urun.UrunMarka = p.UrunMarka;
            urun.UrunStok = p.UrunStok;
            urun.UrunAlisFiyat = p.UrunAlisFiyat;
            urun.UrunSatisFiyat = p.UrunSatisFiyat;
            urun.UrunDurum = p.UrunDurum;
            urun.UrunGorsel = p.UrunGorsel;
            urun.Kategoriid = p.Kategoriid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        public ActionResult UrunDetay(int id)
        {
            var urun = c.Uruns.Where(x => x.UrunID == id).ToList();
            return View(urun);
        }
        [HttpGet]
        public ActionResult UrunSat(int id)
        {
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

            ViewBag.Personeller = personeller;
            ViewBag.Cariler = cariler;
            var urunid = c.Uruns.Find(id);
            ViewBag.Urun = urunid.UrunID;
            ViewBag.UrunSatisFiyat = urunid.UrunSatisFiyat;

            return View();
        }
        [HttpPost]
        public ActionResult UrunSat(SatisHareket p)
        {
            p.SatisTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}