using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSistem1.Models.Entity;

namespace MvcSistem1.Controllers
{
    public class OgrenciController : Controller
    {
        MvcSistem1Entities2 db = new MvcSistem1Entities2();
        // GET: Ogrenci
        public ActionResult OgrenciIndex(string p)
        {
            var degerler = from d in db.tbOgrenci select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Ad.Contains(p));

            }
            return View(degerler.ToList());
            //var degerler = db.tbOgrenci.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(tbOgrenci p1)
        {
            db.tbOgrenci.Add(p1);
            db.SaveChanges();
            return RedirectToAction("OgrenciIndex");


        }

        public ActionResult OgrenciSil(int id)
        {
            var ogrencisil = db.tbOgrenci.Find(id);
            db.tbOgrenci.Remove(ogrencisil);
            db.SaveChanges();
            return RedirectToAction("OgrenciIndex");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrn = db.tbOgrenci.Find(id);
            return View("OgrenciGetir", ogrn);
        }

        public ActionResult OgrenciGuncelle(tbOgrenci p2)
        {
            var ogrenci = db.tbOgrenci.Find(p2.id);
            ogrenci.Ad = p2.Ad;
            ogrenci.Soyad = p2.Soyad;
            ogrenci.No = p2.No;
         
            db.SaveChanges();
            return RedirectToAction("OgrenciIndex");
        }

    }
}