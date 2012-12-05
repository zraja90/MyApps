using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Domain.Products;
using ToolDepot.Filters.Helpers;
using ToolDepot.Models;
using ToolDepot.Services;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderConstructionService _underConstructionService;
        private readonly IProductContext _productContext;
        private readonly IProductService _productService;

        public HomeController(IUnderConstructionService underConstructionService,
            IProductContext productContext,IProductService productService)
        {
            _underConstructionService = underConstructionService;
            _productContext = productContext;
            _productService = productService;
        }


        public ActionResult Index()
        {
            //var product = _productContext.AllProducts;
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult FeaturedProductCategory()
        {
            
            var featuredProducts = _productContext.FeaturedProducts;
            
            return PartialView(featuredProducts);
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
