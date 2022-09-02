using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg1.Models.Entity;

namespace MvcUyg1.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcUyg1Entities db = new MvcUyg1Entities();
        public ActionResult MusteriIndex(string p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER p1)
        {
            if(!ModelState.IsValid) //doğrulama işlemi yapılmadıysa yani boş veya 50 karakterden fazla ise
            {
                return View("MusteriEkle");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }

        public ActionResult MusteriSil(int id)
        {
            var musterisil = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musterisil);
            db.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mstr);
        }

        public ActionResult MusteriGuncelle(TBLMUSTERILER p2)
        {
            var mstr = db.TBLMUSTERILER.Find(p2.MUSTERIID);
            mstr.MUSTERIAD = p2.MUSTERIAD;
            mstr.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("MusteriIndex");
        }
    }
}