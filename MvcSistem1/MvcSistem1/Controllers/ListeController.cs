using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSistem1.Models.Entity;
namespace MvcSistem1.Controllers
{
    public class ListeController : Controller
    {
        MvcSistem1Entities2 db = new MvcSistem1Entities2();
        // GET: Liste
        public ActionResult ListeIndex()
        {
            var degerler = db.tbListe.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult ListeEkle()
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


            List<SelectListItem> degerler2 = (from i in db.tbOgrenci.ToList()
                                              select new SelectListItem //bu yeni listeyi şeç
                                              {
                                                  //bu şeçmiş olduğn listenin text ve value değeri:
                                                  Text = i.Ad,
                                                  Value = i.id.ToString()
                                              }).ToList();


            ViewBag.dgr2 = degerler2;
            return View();
        }

        [HttpPost]
        public ActionResult ListeEkle(tbListe p1)
        {
            //linq sorgusu
            var ad = db.tbOgrenci.Where(m => m.id == p1.tbOgrenci.id).FirstOrDefault(); 
            var snf = db.tbSinif.Where(m => m.id == p1.tbSinif.id).FirstOrDefault();
            var snf1 = db.tbSinif.Where(m => m.id == p1.tbSinif1.id).FirstOrDefault();
            var snf2 = db.tbSinif.Where(m => m.id == p1.tbSinif2.id).FirstOrDefault();
            var snf3 = db.tbSinif.Where(m => m.id == p1.tbSinif3.id).FirstOrDefault();
            var snf4 = db.tbSinif.Where(m => m.id == p1.tbSinif4.id).FirstOrDefault();

          

            p1.tbSinif = snf;
            p1.tbSinif1 = snf1;
            p1.tbSinif2 = snf2;
            p1.tbSinif3 = snf3;
            p1.tbSinif4 = snf4;
            p1.tbOgrenci = ad;
            db.tbListe.Add(p1);
            db.SaveChanges();
            return RedirectToAction("ListeIndex");
        }


        public ActionResult ListeSil(int id)
        {
            var sil = db.tbListe.Find(id); //
            db.tbListe.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("ListeIndex");
        }

        public ActionResult ListeGetir(int id)
        {
            var ogrn = db.tbListe.Find(id);

            List<SelectListItem> degerler = (from i in db.tbSinif.ToList()    //siniflar
                                             select new SelectListItem //bu yeni listeyi şeç
                                             {
                                                 //bu şeçmiş olduğn listenin text ve value değeri:
                                                 Text = i.Ad,
                                                 Value = i.id.ToString()
                                             }).ToList();


            ViewBag.dgr = degerler; //ViewBag ile diğer sayfaya veri taşırız 


            List<SelectListItem> degerler2 = (from i in db.tbOgrenci.ToList()  //Öğrenci adları
                                              select new SelectListItem //bu yeni listeyi şeç
                                              {
                                                  //bu şeçmiş olduğn listenin text ve value değeri:
                                                  Text = i.Ad,
                                                  Value = i.id.ToString()
                                              }).ToList();


            ViewBag.dgr2 = degerler2;

            return View("ListeGetir", ogrn);
        }

        public ActionResult ListeGuncelle(tbListe p2)
        {

            var lst = db.tbListe.Find(p2.id);
           // lst.id = p2.id;   /
       
            var snf = db.tbSinif.Where(m => m.id == p2.tbSinif.id).FirstOrDefault();
            var snf1 = db.tbSinif.Where(m => m.id == p2.tbSinif1.id).FirstOrDefault();
            var snf2 = db.tbSinif.Where(m => m.id == p2.tbSinif2.id).FirstOrDefault();
            var snf3 = db.tbSinif.Where(m => m.id == p2.tbSinif3.id).FirstOrDefault();
            var snf4 = db.tbSinif.Where(m => m.id == p2.tbSinif4.id).FirstOrDefault();

            //lst.KisiId = p2.KisiId;
            lst.SinifId1 = snf.id;
            lst.SinifId2 = snf1.id;
            lst.SinifId3 = snf2.id;
            lst.SinifId4 = snf3.id;
            lst.SinifId5 = snf4.id;




            db.SaveChanges();
            return RedirectToAction("ListeIndex");
        }

    }
}