﻿using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
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
