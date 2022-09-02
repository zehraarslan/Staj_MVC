using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg1.Models.Entity;

namespace MvcUyg1.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcUyg1Entities db = new MvcUyg1Entities();
        public ActionResult UrunIndex()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            // List<SelectListItem> =LİSTEDEN ÖĞE ŞEÇ
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList() //TBLURUNLER listesini çek ve bunu i değişkenine ata
                                             select new SelectListItem //bu yeni listeyi şeç
                                             {
                                                 //bu şeçmiş olduğn listenin text ve value değeri:
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            
            ViewBag.dgr = degerler; //ViewBag ile diğer sayfaya veri taşırız
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            //linq sorgusu
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("UrunIndex");
        }

        
        public ActionResult UrunSil(int id)
        {
            var urunsil = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunsil);
            db.SaveChanges();
            return RedirectToAction("UrunIndex");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList() //TBLURUNLER listesini çek ve bunu i değişkenine ata
                                             select new SelectListItem //bu yeni listeyi şeç
                                             {
                                                 //bu şeçmiş olduğn listenin text ve value değeri:
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler; //ViewBag ile diğer sayfaya veri taşırız

            return View("UrunGetir", urun);

        }

        public ActionResult UrunGuncelle(TBLURUNLER p2)
        {
            var urn = db.TBLURUNLER.Find(p2.URUNID);
            urn.URUNAD = p2.URUNAD;
            urn.MARKA = p2.MARKA;
     
            urn.FIYAT = p2.FIYAT;
            urn.STOK = p2.STOK;
            //urn.URUNKATEGORI = p2.URUNKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p2.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urn.URUNKATEGORI = ktg.KATEGORIID; //kategoriyi bu şekilde yazdırıyoruz.

            db.SaveChanges();
            return RedirectToAction("UrunIndex");
        }
    }
}