using MVC5TicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC5TicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult DonutChart()
        {
            var urunler = c.Uruns.Select(x => x.UrunAd).ToList();
            var urunadet = c.Uruns.Select(x => x.UrunStok).ToList();
            ViewBag.UrunIsim = urunler;
            ViewBag.Urunadet = urunadet;

            return View();
        }

        public ActionResult AreaChart()
        {
            var urunler = c.Uruns.Select(x => x.UrunAd).ToList();
            var urunadet = c.Uruns.Select(x => x.UrunStok).ToList();
            ViewBag.UrunIsim = urunler;
            ViewBag.Urunadet = urunadet;

            return View();
        }

        public ActionResult PieChart()
        {
            var urunler = c.Uruns.Select(x => x.UrunAd).ToList();
            var urunadet = c.Uruns.Select(x => x.UrunStok).ToList();
            ViewBag.UrunIsim = urunler;
            ViewBag.Urunadet = urunadet;

            return View();
        }

        public ActionResult LineChart()
        {
            var urunler = c.Uruns.Select(x => x.UrunAd).ToList();
            var urunadet = c.Uruns.Select(x => x.UrunStok).ToList();
            ViewBag.UrunIsim = urunler;
            ViewBag.Urunadet = urunadet;

            return View();
        }

        public ActionResult BarChart()
        {
            var urunler = c.Uruns.Select(x => x.UrunAd).ToList();
            var urunadet = c.Uruns.Select(x => x.UrunStok).ToList();
            ViewBag.UrunIsim = urunler;
            ViewBag.Urunadet = urunadet;

            return View();
        }
    }
}