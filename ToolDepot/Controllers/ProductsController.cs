using System.Web.Mvc;
using ToolDepot.Services;
using ToolDepot.Services.Products;

namespace ToolDepot.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductsController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }
        //
        // GET: /Products/

        public ActionResult Index(int id = 0)
        {

            return View();
        }

        public ActionResult AllCategories()
        {
            var categories = _productCategoryService.GetAll();
            return View(categories);
        }

        public ActionResult Category(int id = 0)
        {
            var model = _productCategoryService.GetById(id);

            return View(model);
        }

        public ActionResult RequestAQuote()
        {
            return View();
        }

        public ActionResult Product(int id = 0)
        {
            var model = _productService.GetById(id);
            return View(model);
        }

    }
}
