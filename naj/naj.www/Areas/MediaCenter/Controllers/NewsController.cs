using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Naj.www.Areas.MediaCenter.Controllers
{
    public class NewsController : Controller
    {
        #region Views

        // GET: MediaCenter/News
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Detail()
        {
            return View();
        }

        public ViewResult Control()
        {
            return View();
        }

        #endregion

        #region Json

        public JsonResult All()
        {
            var news = new[]
            {
                new
                {
                    Title = "الخبر 111111",
                    URL = "/MediaCenter/News/Detail/1",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "جمادي الاولي",
                    Date = "16",
                    Year = "1437",
                    Details =@"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الخبر 222222",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "رجب",
                    Date = "25",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                }
            };

            return Json(news, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult All(GridOperation Operations)
        {
            var news = new[]
            {
                new
                {
                    NewID=1,
                    Title = "الخبر 111111",
                    URL = "/MediaCenter/News/Detail/1",
                    Image = "/assets/images/AboutNajran.jpg",
                    Date = DateTime.Now.ToString("yyyy/MM/dd"),
                    Details =@"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    NewID=2,
                    Title = "الخبر 222222",
                    URL = "/MediaCenter/News/Detail/2",
                    Image = "/assets/images/AboutNajran.jpg",
                    Date = DateTime.Now.Subtract(new TimeSpan(5,0,0,0)) .ToString("yyyy/MM/dd"),
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                }
            };

            return Json(news.GridOperator(Operations));
        }

        public JsonResult Latest()
        {
            var news = new[]
            {
                new
                {
                    Title = "الخبر 111111",
                    URL = "/MediaCenter/News/Detail/1",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "جمادي الاولي",
                    Date = "16",
                    Year = "1437",
                    Details =@"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الخبر 222222",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "رجب",
                    Date = "25",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الخبر 333333",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "شوال",
                    Date = "9",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                }
            };

            return Json(news, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Bookmarked()
        {
            var news = new[]
            {
                new
                {
                    Title = "",
                    URL = "/MediaCenter/News/Detail/1",
                    ImageURL = "/assets/images/model1.jpg",
                    Month = "جمادي الاولي",
                    Date = "16",
                    Year = "1437",
                    Details =@""
                },
                new
                {
                    Title = "الخبر 222222",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/model2.jpg",
                    Month = "رجب",
                    Date = "25",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الخبر 333333",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/model3.jpg",
                    Month = "شوال",
                    Date = "9",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الخبر 444444",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/model5.jpg",
                    Month = "شوال",
                    Date = "9",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                },
                new
                {
                    Title = "الخبر 555555",
                    URL = "/MediaCenter/News/Detail/2",
                    ImageURL = "/assets/images/model6.jpg",
                    Month = "شوال",
                    Date = "9",
                    Year = "1437",
                    Details = @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                }
            };

            return Json(news, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Detail(int Id)
        {
            var newObj =
                new
                {
                    Title = "الخبر 111111",
                    URL = "/MediaCenter/News/Detail/1",
                    ImageURL = "/assets/images/AboutNajran.jpg",
                    Month = "جمادي الاولي",
                    Date = "16",
                    Year = "1437",
                    Details =
                        @"وضح أمين منطقة نجران المهندس فارس الشفق عن مواصلة العمل في مشروع درء أخطار السيول وتصريف مياه الأمطار بحي الشرفة الغربية"
                };
            return Json(newObj);
        }

        #endregion

        // GET: MediaCenter/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaCenter/News/Create
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

        // GET: MediaCenter/News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaCenter/News/Edit/5
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

        // GET: MediaCenter/News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaCenter/News/Delete/5
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