﻿using System.Web.Mvc;
using ToolDepot.Models;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(UnderConstructionModel model)
        {
            if (ModelState.IsValid)
            {
                var email = model.EmailAddress;
            }

            return View();
        }
    }
}
