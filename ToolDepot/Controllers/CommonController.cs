using System.Web.Mvc;

namespace ToolDepot.Controllers
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
