using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CommonController : Controller
    {
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
