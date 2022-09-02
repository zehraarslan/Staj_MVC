using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

       // bu kısmın çalışması için uzantııye Urun/Index eklemeliyiz
        public string Index()
        {
            return "Ürün index";
        }

        //bu kısmın çalışması için uzantııye Urun/Liste eklemeliyiz
        public ViewResult Liste() 
        {
            return View() ;
        }

    }
}