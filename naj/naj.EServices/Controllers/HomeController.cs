using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Naj.EServices.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Title"] = "الخدمات الألكترونية";
            ViewData["Brief"] = "يمكنك الاستفادة من جميع خدماتنا";
            ViewData["System"] = "الخدمات الألكترونية";
            //ViewData["Feature"] = "الخدمات";
            //ViewData["Page"] = "خدماتنا";
            return View();
        }
    }
}
