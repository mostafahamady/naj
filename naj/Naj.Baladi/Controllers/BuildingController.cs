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
            INajUow uow = new NajUow(new RepositoryProvider(new RepositoryFactories()));
            ViewData["Page"] = uow.Pages.GetByID(Guid.Parse("5e41de76-0d6f-4f0d-81b1-2722d30723c8"));
            return View();
        }
    }
}