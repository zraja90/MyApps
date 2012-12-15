using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Core.Domain;
using ToolDepot.Filters.Helpers;
using ToolDepot.Models;
using ToolDepot.Models.Products;
using ToolDepot.Services;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderConstructionService _underConstructionService;
        private readonly IProductContext _productContext;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBrochureService _brochureService;
        public HomeController(IUnderConstructionService underConstructionService,
            IProductContext productContext,IProductService productService, IProductCategoryService productCategoryService, IBrochureService brochureService)
        {
            _underConstructionService = underConstructionService;
            _productContext = productContext;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _brochureService = brochureService;
        }



        public ActionResult Index1()
        {
            //var product = _productContext.AllProducts;
            return RedirectToAction("Index");
            var products = _productService.GetAll();
            
            return View(products);
        }
        public ActionResult Index()
        {
            var model = new BrochureModel();
            model.Brochures = _brochureService.GetAll().ToList();
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult ProductCategories()
        {
            return RedirectToAction("Index");
            var productCategories = _productCategoryService.GetAll().OrderBy(x=>x.CategoryName).ToList();

            

            return PartialView(productCategories);
        }

        [ChildActionOnly]
        public ActionResult FeaturedProductCategory()
        {
            return RedirectToAction("Index");
            var featuredProducts = _productContext.FeaturedProducts;
            
            return PartialView(featuredProducts);
        }

        public ActionResult UnderConstruction()
        {
            return RedirectToAction("Index");
            var model = new UnderConstructionModel();

            model.Brochure = _brochureService.GetAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult UnderConstruction(UnderConstruction model)
        {
            return RedirectToAction("Index");
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
