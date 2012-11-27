using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Demo1");

            //return View();
        }
        public ActionResult Demo1()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Demo2()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Demo3()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
