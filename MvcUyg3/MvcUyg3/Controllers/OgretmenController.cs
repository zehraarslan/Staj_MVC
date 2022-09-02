using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg3.Models.Entity;

namespace MvcUyg3.Controllers
{
    public class OgretmenController : Controller
    {
        // GET: Ogretmen
        testEntities1 db = new testEntities1();
        public ActionResult OgretmenIndex()
        {
            var degerler = db.tblogretmen.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OgretmenEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgretmenEkle(tblogretmen p1)
        {
            db.tblogretmen.Add(p1);
            db.SaveChanges();
            return RedirectToAction("OgretmenIndex");
        }

        public ActionResult OgretmenSil(int id)
        {
            var ogrtmnsil = db.tblogretmen.Find(id);
            db.tblogretmen.Remove(ogrtmnsil);
            db.SaveChanges();
            return RedirectToAction("OgretmenIndex");
        }

        public ActionResult OgretmenGetir(int id)
        {
            var ogrtmen = db.tblogretmen.Find(id);
            return View("OgretmenGetir", ogrtmen);
        }

        public ActionResult OgretmenGuncelle(tblogretmen p2)
        {
            var ogretmen = db.tblogretmen.Find(p2.ogretmenid);
            ogretmen.ogretmenad = p2.ogretmenad;
            ogretmen.ogretmensoyad = p2.ogretmensoyad;
            ogretmen.ogretmenders = p2.ogretmenders;
            db.SaveChanges();
            return RedirectToAction("OgretmenIndex");
        }
    }
}