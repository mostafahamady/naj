using Naj.Data;
using System;
using System.Web.Mvc;

namespace Naj.Baladi.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public ViewResult Requests()
        {
            NajUow uow = new NajUow();
            ViewData["Page"] = uow.Pages.GetById(Guid.Parse("5e41de76-0d6f-4f0d-81b1-2722d30723c8"));
            return View();
        }
    }
}