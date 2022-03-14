using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var toplamCari = c.Carilers.Count().ToString();
            ViewBag.toplamCari = toplamCari;

            var toplamUrun = c.Uruns.Count().ToString();
            ViewBag.toplamUrun = toplamUrun;

            var toplamPersonel = c.Personels.Count().ToString();
            ViewBag.toplamPersonel = toplamPersonel;

            var toplamKategori = c.Kategoris.Count().ToString();
            ViewBag.toplamKategori = toplamKategori;

            var toplamStok = c.Uruns.Sum(x => x.UrunStok).ToString();
            ViewBag.toplamStok = toplamStok;

            var markaSayisi = (from x in c.Uruns select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.markaSayisi = markaSayisi;

            var toplamKritikSeviye = c.Uruns.Count(x => x.UrunStok <= 20).ToString();
            ViewBag.toplamKritikSeviye = toplamKritikSeviye;

            var maxFiyatliUrun = (from x in c.Uruns orderby x.UrunSatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.maxFiyatliUrun = maxFiyatliUrun;

            var minFiyatliUrun = (from x in c.Uruns orderby x.UrunSatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.minFiyatliUrun = minFiyatliUrun;

            var maxMarka = c.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(z => z.Count()).Select(y => y.Key)
                .FirstOrDefault();
            ViewBag.maxMarka = maxMarka;

            var toplamBuzdolabiSayisi = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.toplamBuzdolabiSayisi = toplamBuzdolabiSayisi;

            var toplamLaptopSayisi = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.toplamLaptopSayisi = toplamLaptopSayisi;

            var maxSatanUrun = c.Uruns.Where(u => u.UrunID == (c.SatisHarekets.GroupBy(x => x.Urunid)
                .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()))
                    .Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.maxSatanUrun = maxSatanUrun;

            var toplamKasaTutar = c.SatisHarekets.Sum(x => x.SatisToplamTutar).ToString("#,##0.00");
            ViewBag.toplamKasaTutar = toplamKasaTutar;

            DateTime bugun = DateTime.Now.Date;
            var bugunkuSatislar = c.SatisHarekets.Count(x => x.SatisTarih == bugun).ToString();
            var bugunkuKasa = c.SatisHarekets.Where(x => x.SatisTarih == bugun).Sum(y => y.SatisToplamTutar).ToString("#,##0.00");
            //Yukarı Çalışmazsa yarın aşağıdakini ekle
            //var bugunkuKasa = c.SatisHarekets.Where(x => x.SatisTarih == bugun).Sum(y => (decimal?)y.SatisToplamTutar).ToString();

            if (bugunkuSatislar == "0")
            {
                bugunkuKasa = "0";
            }

            ViewBag.bugunkuSatislar = bugunkuSatislar;
            ViewBag.bugunkuKasa = bugunkuKasa;

            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = (from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Ad = g.Key.ToString(),
                            Sayi = g.Count()
                        }).OrderByDescending(y=>y.Sayi).ToList();


            return View(sorgu);
        }

        public PartialViewResult DepartmanPersonelSayi()
        {
            var sorgu = (from x in c.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new SinifGrup2
                        {
                            Depart = g.Key,
                            Sayi = g.Count()
                        }).OrderByDescending(y => y.Sayi).ToList();

            return PartialView(sorgu);
        }

        public PartialViewResult CariSayi()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult UrunSayi()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult UrunMarkaGrup()
        {
            var sorgu = (from x in c.Uruns
                         group x by x.UrunMarka into g
                         select new SinifGrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         }).OrderByDescending(y => y.sayi).ToList();

            return PartialView(sorgu);
        }

        public PartialViewResult PersonelSatis()
        {
            return PartialView();
        }
    }
}