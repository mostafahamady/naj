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
    public class IndividualController : Controller
    {
        IEnumerable<Page> Pages
        {
            get
            {
                return new NajUow().Menus.GetAll().SelectMany(m => m.Pages);
            }
        }

        // GET: Home
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public PartialViewResult VocationalRequests()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/VocationalRequests").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Transactions()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Transactions").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Donations()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Donations").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Bills()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Bills").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult BuildingLicenses()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/BuildingLicenses").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Jobs()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Jobs").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Violations()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Violations").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Contracts()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Contracts").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Licenses()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Licenses").FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult Incedints()
        {
            ViewData["Page"] = Pages.Where(p => p.URL == "Individual/Incedints").FirstOrDefault();
            return PartialView();
        }
    }
}
