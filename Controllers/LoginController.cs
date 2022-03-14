using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CariKayitForm()
        {
            //var sehirler = Cariler.Sehirler.Adana;
            //ViewBag.CariSehir = sehirler;
            return View();
        }

        [HttpPost]
        public ActionResult CariKayitForm(Cariler cari)
        {
            if (!ModelState.IsValid || cari.CariSehir == 0)
            {
                return View("CariKayitForm");
            }
            c.Carilers.Add(cari);
            c.SaveChanges();
            return View("CariGirisForm");
        }

        [HttpGet]
        public ActionResult CariGirisForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariGirisForm(Cariler caris)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == caris.CariMail && 
            x.CariSifre == caris.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AdminGirisForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGirisForm(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == ad.KullaniciAd &&
            x.KullaniciSifre == ad.KullaniciSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["AdminKullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            return View();
        }
    }
}