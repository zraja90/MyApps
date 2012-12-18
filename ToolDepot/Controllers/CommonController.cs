using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Models.Common;

namespace ToolDepot.Controllers
{
    public class CommonController : Controller
    {
        private readonly IWorkContext _workContext;
        public CommonController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var model = new HeaderModel();
            model.IsLoggedIn = _workContext.IsLoggedIn;
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
