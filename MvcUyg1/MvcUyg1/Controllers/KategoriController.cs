using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg1.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcUyg1.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcUyg1Entities db = new MvcUyg1Entities(); //tablolara ulaşmak için kullanıyoruz.

        public ActionResult KategoriIndex()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }



        [HttpGet] //sayfa yüklendiği zaman sadece sayfayı döndür
        public ActionResult KategoriEkle()
        {
            return View();//sayfayı geri döndür
        }


        [HttpPost] //sayfada post işlemi yapıldığı zaman
        public ActionResult KategoriEkle(TBLKATEGORILER p1)
        {
            if(!ModelState.IsValid) //doğrulama işlemi yapılmadıysa yani boş geldiyse
            {
                return View("KategoriEkle");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("KategoriIndex");
        }


        public ActionResult KategoriSil(int id)
        {
            var kategorisil = db.TBLKATEGORILER.Find(id);  //id değşikenini tabloda bul ve kategori değişkenine ata
            db.TBLKATEGORILER.Remove(kategorisil); //kategori değerini tablodan sil
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori= db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(TBLKATEGORILER p2)
        {
            var ktg = db.TBLKATEGORILER.Find(p2.KATEGORIID);
            ktg.KATEGORIAD = p2.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("KategoriIndex");
        }
    }
}