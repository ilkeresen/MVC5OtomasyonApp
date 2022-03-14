using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            //cariler
            var cariler = c.Carilers.Count().ToString();
            ViewBag.cariler = cariler;
            //ürünler
            var urunler = c.Uruns.Count().ToString();
            ViewBag.urunler = urunler;
            //kategoriler
            var kategoriler = c.Kategoris.Count().ToString();
            ViewBag.kategoriler = kategoriler;
            //personeller
            var personeller = c.Personels.Count().ToString();
            ViewBag.personeller = personeller;


            var Sorgu = c.Yapilacaks.ToList();
            return View(Sorgu);
        }
    }
}