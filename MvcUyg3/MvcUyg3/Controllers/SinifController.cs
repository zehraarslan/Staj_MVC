using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg3.Models.Entity;

namespace MvcUyg3.Controllers
{
    public class SinifController : Controller
    {
        // GET: Sinif

        testEntities1 db = new testEntities1();
        public ActionResult SinifIndex()
        {
            var degerler = db.tblsinif.ToList();
            return View(degerler);
        }

        
        public ActionResult SinifGetir(int id)
        {
            var sinif = db.tblogretmen.Find(id);
            return View("SinifGetir", sinif);
        }

        public ActionResult SinifGuncelle(tblsinif p1)
        {
            var snf = db.tblsinif.Find(p1.sinifad);
            snf.sinifad = p1.sinifad;
            db.SaveChanges();
            return RedirectToAction("SinifIndex");
        }
        public ActionResult SinifSil(string id)
        {
            var snf = db.tblsinif.Find(id);
            db.tblsinif.Remove(snf);
            db.SaveChanges();
            return RedirectToAction("SinifIndex");
        }
    }
}