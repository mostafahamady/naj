using System.Web.Mvc;

namespace Naj.www.Controllers
{
    public class AboutNajranController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: OverviewOfNajran
        public ActionResult Overview()
        {
            return View();
        }

        // GET: NajranGuide
        public ActionResult Guide()
        {
            return View();
        }

        // GET: PhotoGallery
        public ActionResult PhotoGallery()
        {
            return View();
        }
    }
}