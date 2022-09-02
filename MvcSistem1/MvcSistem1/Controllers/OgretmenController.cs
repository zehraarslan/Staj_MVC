using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSistem1.Models.Entity;
namespace MvcSistem1.Controllers
{
    public class OgretmenController : Controller
    {
        MvcSistem1Entities2 db = new MvcSistem1Entities2();
        // GET: Ogretmen
        public ActionResult OgretmenIndex()
        {
            var degerler = db.tbOgretmen.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OgretmenEkle()
        {
            // List<SelectListItem> =LİSTEDEN ÖĞE ŞEÇ
            List<SelectListItem> degerler = (from i in db.tbSinif.ToList()
                                             select new SelectListItem //bu yeni listeyi şeç
                                             {
                                                 //bu şeçmiş olduğn listenin text ve value değeri:
                                                 Text = i.Ad,
                                                 Value = i.id.ToString()
                                             }).ToList();


            ViewBag.dgr = degerler; //ViewBag ile diğer sayfaya veri taşırız

            return View();
        }

        [HttpPost]
        public ActionResult OgretmenEkle(tbOgretmen p1)
        {
            var snf = db.tbSinif.Where(m => m.id == p1.tbSinif.id).FirstOrDefault();
            var snf1 = db.tbSinif.Where(m => m.id == p1.tbSinif1.id).FirstOrDefault();
            p1.tbSinif = snf;
            p1.tbSinif1 = snf1;
            db.tbOgretmen.Add(p1);
            db.SaveChanges();
            return RedirectToAction("OgretmenIndex");
        }

        public ActionResult OgretmenSil(int id)
        {
            var sil = db.tbOgretmen.Find(id);
            db.tbOgretmen.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("OgretmenIndex");
        }

        public ActionResult OgretmenGetir(int id)
        {
            var ogrtmn = db.tbOgretmen.Find(id);

            List<SelectListItem> degerler = (from i in db.tbSinif.ToList()    //siniflar
                                             select new SelectListItem //bu yeni listeyi şeç
                                             {
                                                 //bu şeçmiş olduğn listenin text ve value değeri:
                                                 Text = i.Ad,
                                                 Value = i.id.ToString()
                                             }).ToList();


            ViewBag.dgr = degerler; //ViewBag ile diğer sayfaya veri taşırız


            return View("OgretmenGetir", ogrtmn);
        }

        public ActionResult OgretmenGuncelle(tbOgretmen p2)
        {
            var ogretmen = db.tbOgretmen.Find(p2.id);
            ogretmen.Ad = p2.Ad;
            ogretmen.Soyad = p2.Soyad;
            ogretmen.Tel = p2.Tel;
            ogretmen.Maas = p2.Maas;

            var snf = db.tbSinif.Where(m => m.id == p2.tbSinif.id).FirstOrDefault();
            var snf1 = db.tbSinif.Where(m => m.id == p2.tbSinif1.id).FirstOrDefault();

            ogretmen.Brans1 = snf.id;
            ogretmen.Brans2 = snf1.id;

            db.SaveChanges();
            return RedirectToAction("OgretmenIndex");
        }

    }
}