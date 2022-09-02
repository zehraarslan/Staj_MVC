using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcUyg1.Models.Entity;

namespace MvcUyg1.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcUyg1Entities db = new MvcUyg1Entities();
        public ActionResult SatisIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(TBLSATISLAR p1)
        {
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return View("SatisIndex");


        }
    }
}