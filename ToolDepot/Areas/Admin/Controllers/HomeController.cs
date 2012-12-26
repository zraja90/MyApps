using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Filters;

namespace ToolDepot.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
