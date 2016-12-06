using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Naj.Data;
using Naj.Entity;
using Naj.Common;

namespace Naj.EServices.Controllers
{
    public class BusinessController : Controller
    {
        IEnumerable<Page> Pages
        {
            get
            {
                return new NajUow(new RepositoryProvider(new RepositoryFactories())).Menus.GetAll().SelectMany(m => m.Pages);
            }
        }

        // GET: Home
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult Invoices()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Business/Invoices").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Contracts()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Business/Contracts").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Insuarances()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Business/Insuarances").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Tenders()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Business/Tenders").FirstOrDefault();
            return PartialView();
        }
    }
}
