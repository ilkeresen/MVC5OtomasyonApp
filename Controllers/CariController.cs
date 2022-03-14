using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cariler = c.Carilers.Where(x => x.CariDurum == true).ToList();
            return View(cariler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler f)
        {
            if (!ModelState.IsValid)
            {
                return View("CariEkle");
            }
            f.CariDurum = true;
            c.Carilers.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var carisil = c.Carilers.Find(id);
            carisil.CariDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGuncelle(int id)
        {
            var guncelleme = c.Carilers.Find(id);
            return View("CariGuncelle", guncelleme);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler f)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGuncelle");
            }
            var cari = c.Carilers.Find(f.CariID);
            cari.CariAd = f.CariAd;
            cari.CariSoyad = f.CariSoyad;
            cari.CariSehir = f.CariSehir;
            cari.CariMail = f.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariMusteriSatis(int id)
        {
            var satislar = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cariadsoyad = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariMusteriAdi = cariadsoyad;
            return View(satislar);
        }
    }
}