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