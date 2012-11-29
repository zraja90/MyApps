using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolDepot.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult RequestQuote()
        {
            return View();
        }

    }
}
