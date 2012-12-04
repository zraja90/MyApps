using System.Linq;
using System.Web.Mvc;
using ToolDepot.Filters.Helpers;
using ToolDepot.Models;
using ToolDepot.Services;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderConstructionService _underConstructionService;
        private readonly IProductService _productService;

        public HomeController(IUnderConstructionService underConstructionService,
            IProductService productService)
        {
            _underConstructionService = underConstructionService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            //return RedirectToAction("UnderConstruction");
            var featuredProducts = _productService.GetMany(x => x.IsFeaturedProduct).ToList();
            //var model = featuredProducts.Where(x=>x.to)
            return View();
        }

        public ActionResult UnderConstruction()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpPost]
        public ActionResult UnderConstruction(UnderConstructionModel model)
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
                    this.ErrorNotification("The email address entered is invalid");
                }
            }

            return View();
        }
    }
}
