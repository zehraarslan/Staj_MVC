using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg2.Models.Entity;

namespace MvcUyg2.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        testEntities1 db = new testEntities1();
        public ActionResult OgrenciIndex()
        {
            var degerler = db.tblogrenci.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(tblogrenci p1)
        {
            db.tblogrenci.Add(p1);
            db.SaveChanges();
            return RedirectToAction("OgrenciIndex");
        }

        public ActionResult OgrenciSil(int id)
        {
            var ogrencisil = db.tblogrenci.Find(id);
            db.tblogrenci.Remove(ogrencisil);
            db.SaveChanges();
            return RedirectToAction("OgrenciIndex");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.tblogrenci.Find(id);
            return View("OgrenciGetir", ogrenci);
        }
    }
}