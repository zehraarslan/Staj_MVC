using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSistem1.Models.Entity;

namespace MvcSistem1.Controllers
{
    public class SinifController : Controller
    {
        MvcSistem1Entities2 db = new MvcSistem1Entities2();
        // GET: Sinif
        public ActionResult SinifIndex()
        {
            var degerler = db.tbSinif.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SinifEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SinifEkle (tbSinif p1)
        {
            db.tbSinif.Add(p1);
            db.SaveChanges();
            return RedirectToAction("SinifIndex");
        }

        public ActionResult SinifSil(int id)
        {
            var sil = db.tbSinif.Find(id);
            db.tbSinif.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("SinifIndex");
        }

        public ActionResult SinifGetir(int id)
        {
            var snf = db.tbSinif.Find(id);
            return View("SinifGetir", snf);
        }

        public ActionResult SinifGuncelle(tbSinif p2)
        {
            var snf = db.tbSinif.Find(p2.id);
            snf.Ad = p2.Ad;
            
            db.SaveChanges();
            return RedirectToAction("SinifIndex");
        }
    }
}