using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TicariOtomasyon.Models.Siniflar;

namespace MVC5TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var faturalar = c.Faturalars.ToList();
            return View(faturalar);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FaturaGuncelle(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGuncelle", fatura);
        }
        [HttpPost]
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var yenifatura = c.Faturalars.Find(f.FaturaID);
            yenifatura.FaturaSiraNo = f.FaturaSiraNo;
            yenifatura.FaturaSeriNo = f.FaturaSeriNo;
            yenifatura.FaturaSaat = f.FaturaSaat;
            yenifatura.FaturaTarih = f.FaturaTarih;
            yenifatura.FaturaTeslimEden = f.FaturaTeslimEden;
            yenifatura.FaturaTeslimAlan = f.FaturaTeslimAlan;
            yenifatura.FaturaVergiDairesi = f.FaturaVergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var faturakalemler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            var faturaserino = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSeriNo).FirstOrDefault();
            var faturasirano = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSiraNo).FirstOrDefault();
            ViewBag.FaturaSeriNo = faturaserino;
            ViewBag.FaturaSiraNo = faturasirano;
            return View(faturakalemler);
        }
        [HttpGet]
        public ActionResult KalemEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KalemEkle(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DinamikFatura()
        {
            //var EntityState = new SelectList(Enum.GetValues(typeof(Ilceler)).Cast<Ilceler>().Select(v => new SelectListItem
            //{
            //    Text = v.ToString(),
            //    Value = ((int)v).ToString()
            //}).ToList(), "Value", "Text");

            //ViewBag.Ilceler = EntityState;

            //List<Ilceler> ılcelers = Enum.GetValues(typeof(Ilceler))
            //                .Cast<Ilceler>()
            //                .ToList();
            //ViewBag.Ilceler = ılcelers.ToString();

            DinamikFatura df = new DinamikFatura();
            df.deger1 = c.Faturalars.ToList();
            df.deger2 = c.FaturaKalems.ToList();
            return View(df);
        }

        //public ActionResult DinamikFaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime FaturaTarih, string FaturaVergiDairesi, string FaturaSaat, string FaturaTeslimEden, string FaturaTeslimAlan, string FaturaToplam, FaturaKalem[] kalemler)
        //{
        //    Faturalar f = new Faturalar();
        //    f.FaturaSeriNo = FaturaSeriNo;
        //    f.FaturaSiraNo = FaturaSiraNo;
        //    f.FaturaTarih = FaturaTarih;
        //    f.FaturaVergiDairesi = FaturaVergiDairesi;
        //    f.FaturaSaat = FaturaSaat;
        //    f.FaturaTeslimEden = FaturaTeslimEden;
        //    f.FaturaTeslimAlan = FaturaTeslimAlan;
        //    f.FaturaToplam = decimal.Parse(FaturaToplam);
        //    c.Faturalars.Add(f);
        //    c.SaveChanges();
        //    return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        //}
    }
}