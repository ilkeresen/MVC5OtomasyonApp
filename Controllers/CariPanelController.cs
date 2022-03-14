using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];

            var mesajdeger = c.Mesajlars.Where(x => x.MesajAlici == mail).ToList();

            var caridegerler = c.Carilers.Where(x => x.CariMail == mail).ToList();
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.Mailid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.Cariid == mailid).Count();
            ViewBag.ToplamSatis = toplamsatis;
            var toplamtutar = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.SatisToplamTutar);
            ViewBag.ToplamTutar = toplamtutar;
            var toplamurunsayi = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.SatisAdet);
            ViewBag.ToplamUrunAdet = toplamurunsayi;
            var cariadsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariAdSoyad = cariadsoyad;
            ViewBag.CariMail = mail;
            return View(mesajdeger);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];

            var id = c.Carilers.Where(x => x.CariMail == mail.ToString())
                .Select(y => y.CariID).FirstOrDefault();
            var caridegerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(caridegerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.MesajAlici == mail).OrderByDescending(x => x.MesajID).ToList();

            var gelenmesaj = c.Mesajlars.Count(x => x.MesajAlici == mail).ToString();
            ViewBag.GelenMesaj = gelenmesaj;
            var gidenmesaj = c.Mesajlars.Count(x => x.MesajGonderici == mail).ToString();
            ViewBag.GidenMesaj = gidenmesaj;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.MesajGonderici == mail).OrderByDescending(x => x.MesajID).ToList();

            var gidenmesaj = c.Mesajlars.Count(x => x.MesajGonderici == mail).ToString();
            ViewBag.GidenMesaj = gidenmesaj;
            var gelenmesaj = c.Mesajlars.Count(x => x.MesajAlici == mail).ToString();
            ViewBag.GelenMesaj = gelenmesaj;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();

            var mail = (string)Session["CariMail"];

            var gidenmesaj = c.Mesajlars.Count(x => x.MesajGonderici == mail).ToString();
            ViewBag.GidenMesaj = gidenmesaj;
            var gelenmesaj = c.Mesajlars.Count(x => x.MesajAlici == mail).ToString();
            ViewBag.GelenMesaj = gelenmesaj;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];

            var gidenmesaj = c.Mesajlars.Count(x => x.MesajGonderici == mail).ToString();
            ViewBag.GidenMesaj = gidenmesaj;
            var gelenmesaj = c.Mesajlars.Count(x => x.MesajAlici == mail).ToString();
            ViewBag.GelenMesaj = gelenmesaj;

            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            m.MesajTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            var mail = (string)Session["CariMail"];
            m.MesajGonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();

            return RedirectToAction("GidenMesajlar");
        }

        public ActionResult KargoTakip(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            kargo = kargo.Where(y => y.KargoDetayTakipKodu.Equals(p));
            //var mail = (string)Session["CariMail"];
            //var cariad = c.Carilers.Where(x=>x.CariMail == mail).Select(x=>x.CariAd).ToString();
            //var carisoyad = c.Carilers.Where(x=>x.CariMail == mail).Select(x=>x.CariSoyad).ToString();
            //ToString yerine FirstOrDefault dene.
            //var cariadsoyad = cariad + " " + carisoyad;

            //var kargo = c.KargoDetays.Where(x=>x.KargoDetayAlici == cariadsoyad.ToString()).ToList();
            return View(kargo.ToList());
        }

        public ActionResult KargoTakipDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.KargoTakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult CariAyarlar()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var cari = c.Carilers.Find(id);
            return PartialView("CariAyarlar",cari);
        }

        public PartialViewResult CariDuyuru()
        {
            var veriler = c.Mesajlars.Where(x => x.MesajGonderici == "admin").ToList();
            return PartialView(veriler);
        }

        public ActionResult CariBilgiGuncelle(Cariler ca)
        {
            var cari = c.Carilers.Find(ca.CariID);
            cari.CariAd = ca.CariAd;
            cari.CariSoyad = ca.CariSoyad;
            cari.CariMail = ca.CariMail;
            cari.CariSehir = ca.CariSehir;
            cari.CariSifre = ca.CariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}