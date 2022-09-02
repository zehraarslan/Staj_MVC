using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg3.Models.Entity;

namespace MvcUyg3.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        testEntities1 db = new testEntities1();
        public ActionResult OgrenciIndex(string p)
        {

            var degerler = from d in db.tblogrenci select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.ogrenciad.Contains(p));

            }
            return View(degerler.ToList());
            //var degerler = db.tblogrenci.ToList();
            //return View(degerler);
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
            var ogrn = db.tblogrenci.Find(id);
            return View("OgrenciGetir", ogrn);
        }

        public ActionResult OgrenciGuncelle(tblogrenci p2)
        {
            var ogrenci = db.tblogrenci.Find(p2.ogrenciid);
            ogrenci.ogrenciad = p2.ogrenciad;
            ogrenci.ogrencisoyad = p2.ogrencisoyad;
            ogrenci.ogrencisinif = p2.ogrencisinif;
            ogrenci.ogrencitel = p2.ogrencitel;
            db.SaveChanges();
            return RedirectToAction("OgrenciIndex");
        }
    }
}