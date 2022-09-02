using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje1.Controllers
{
    public class HomeController : Controller
    {
        //Controller syafasını oluşturmak için Solution Explorer>Controller>sağa tkla>Add>Controller>1. sıradki

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}