using System.Linq;
using System.Web.Mvc;
using ToolDepot.Core.Domain;
using ToolDepot.Mailers;
using ToolDepot.Models;
using ToolDepot.Models.Products;
using ToolDepot.Services;
using ToolDepot.Services.Products;

namespace ToolDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderConstructionService _underConstructionService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBrochureService _brochureService;
        private readonly IUserMailer _userMailer;
        public HomeController(IUnderConstructionService underConstructionService,
           IProductService productService, IProductCategoryService productCategoryService, IUserMailer userMailer, IBrochureService brochureService)
        {
            _underConstructionService = underConstructionService;
            _userMailer = userMailer;
            _productService = productService;
            _productCategoryService = productCategoryService;
            _brochureService = brochureService;
        }
        public ActionResult Index()
        {
            var model = new BrochureModel { Brochures = _brochureService.GetAll().ToList() };
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult ProductCategories()
        {
            //return RedirectToAction("Index");
            var categories = new CategoriesModel
                                 {Categories = _productCategoryService.GetAll().OrderBy(x => x.CategoryName).ToList()};

            return PartialView(categories);
        }

        [ChildActionOnly]
        public ActionResult FeaturedProductCategory()
        {
            var model = new FeaturedCategoriesModel();
            model.FeaturedCategory = _productCategoryService.GetMany(x=>x.IsFeaturedCategory).ToList();
            
            return PartialView(model);
        }

        public ActionResult UnderConstruction()
        {
            return RedirectToAction("Index");
            /*var model = new UnderConstructionModel();

            model.Brochure = _brochureService.GetAll();
            return View(model);*/
        }

        [HttpPost]
        public ActionResult UnderConstruction(UnderConstruction model)
        {
            return RedirectToAction("Index");
            /*if (ModelState.IsValid)
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

            return View();*/
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}
