using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Naj.www.Areas.MediaCenter.Controllers
{
    public class PressKitController : Controller
    {
        // GET: MediaCenter/PressKit
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult All()
        {
            var pressKits = new[]
            {
                new
                {
                    Title = "الملف الصحفي 1111111",
                    URL = "/MediaCenter/PressKit/Detail/1",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "جمادي الاولي",
                    Date = "18",
                    Year = "1437",
                    Details =@"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الملف الصحفي 2222222",
                    URL = "/MediaCenter/PressKit/Detail/2",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "رجب",
                    Date = "19",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                }
            };

            return Json(pressKits, JsonRequestBehavior.AllowGet);
        }

        public ViewResult Detail()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Detail(int Id)
        {
            var newObj =
                new
                {
                    Title = "الملف الصحفي 1111111",
                    URL = "/MediaCenter/PressKit/Detail/1",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "جمادي الاولي",
                    Date = "18",
                    Year = "1437",
                    Details =
                        @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                };
            return Json(newObj);
        }

        // GET: MediaCenter/PressKit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaCenter/PressKit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaCenter/PressKit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaCenter/PressKit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaCenter/PressKit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaCenter/PressKit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}