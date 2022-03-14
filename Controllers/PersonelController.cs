using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personeller = c.Personels.ToList();
            return View(personeller);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departman = (from x in c.Deparmans.Where(d => d.DepartmanDurum == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.departmancombobox = departman;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Images/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            List<SelectListItem> departman = (from x in c.Deparmans.Where(i => i.DepartmanDurum == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.departmancombobox = departman;
            var personel = c.Personels.Find(id);
            return View("PersonelGuncelle", personel);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel per)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                per.PersonelGorsel = "/Images/" + dosyaadi + uzanti;
            }
            var personel = c.Personels.Find(per.PersonelID);
            personel.PersonelAd = per.PersonelAd;
            personel.PersonelSoyad = per.PersonelSoyad;
            personel.PersonelGorsel = per.PersonelGorsel;
            personel.Departmanid = per.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var personel = c.Personels.ToList();
            return View(personel);
        }
    }
}