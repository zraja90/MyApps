using System.Web.Mvc;
using ToolDepot.Filters.Helpers;
using ToolDepot.Models;
using ToolDepot.Services;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderConstructionService _underConstructionService;

        public HomeController(IUnderConstructionService underConstructionService)
        {
            _underConstructionService = underConstructionService;
        }

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
                if (!string.IsNullOrEmpty(model.EmailAddress))
                {
                    _underConstructionService.Add(model);
                    this.SuccessNotification("Thank You for Subscribing. You will receive an email with updates very soon.");
                }
                else
                {
                    return View();
                }
            }

            return View();
        }
    }
}
