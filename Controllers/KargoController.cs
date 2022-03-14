using System;
using System.Collections.Generic;
using System.Linq;
using MVC5TicariOtomasyon.Models.Siniflar;
using System.Web;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index()
        {
            var kargo = c.KargoDetays.ToList();
            return View(kargo);
        }
        [HttpGet]
        public ActionResult KargoDetayEkle()
        {
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()

                                                }).ToList();
            ViewBag.Personeller = personeller;

            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CariAd + " " + x.CariSoyad,
                                                    Value = x.CariID.ToString()

                                                }).ToList();
            ViewBag.Cariler = cariler;

            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);//10->3 1 2 1 2 1
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.KargoTakipKod = kod;

            return View();
        }
        [HttpPost]
        public ActionResult KargoDetayEkle(KargoDetay d)
        {
            var personeladgetir = c.Personels.Where(x => x.PersonelID.ToString() == d.KargoDetayPersonel).FirstOrDefault();
            d.KargoDetayPersonel = personeladgetir.PersonelAd + " " + personeladgetir.PersonelSoyad;
            var cariadgetir = c.Carilers.Where(x => x.CariID.ToString() == d.KargoDetayAlici).FirstOrDefault();
            d.KargoDetayAlici = cariadgetir.CariAd + " " + cariadgetir.CariSoyad;
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakipDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
            return View(degerler);
        }
    }
}