using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var departmans = c.Deparmans.Where(d => d.DepartmanDurum == true).ToList();
            return View(departmans);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Deparmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var departmanSil = c.Deparmans.Find(id);
            departmanSil.DepartmanDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGuncelle(int id)
        {
            var departman = c.Deparmans.Find(id);
            return View("DepartmanGuncelle", departman);
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = c.Deparmans.Find(d.DepartmanID);
            departman.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personeller = c.Personels.Where(x => x.Departmanid == id).ToList();
            var departman = c.Deparmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.DepartmanAdi = departman;
            return View(personeller);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var personelSatislar = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var personel = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.DepartmanPersonelAdi = personel;
            return View(personelSatislar);
        }
    }
}