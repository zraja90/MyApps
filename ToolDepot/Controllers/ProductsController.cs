using System.Linq;
using System.Web.Mvc;
using ToolDepot.Helpers;
using ToolDepot.Mappers;
using ToolDepot.Models.Products;
using ToolDepot.Services.Email;
using ToolDepot.Services.Products;

namespace ToolDepot.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IBrochureService _brochureService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IRequestAQuoteService _requestAQuoteService;
        public ProductsController(IProductService productService, IProductCategoryService productCategoryService,
            IBrochureService brochureService, IWorkflowMessageService workflowMessageService, IRequestAQuoteService requestAQuoteService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _brochureService = brochureService;
            _workflowMessageService = workflowMessageService;
            _requestAQuoteService = requestAQuoteService;
        }
        //
        // GET: /Products/

        public ActionResult Index(int id = 0)
        {

            return View();
        }

        public ActionResult AllCategories()
        {
            var model = new CategoriesModel {Categories = _productCategoryService.GetAll().ToList()};
            return View(model);
        }

        public ActionResult Category(int id = 0)
        {
            var model = new CategoryWithProductsModel {Category = _productCategoryService.GetById(id)};
            

            return View(model);
        }

        public ActionResult RequestAQuote(string id="0")
        {
            var model = new RequestQuoteModel
                            {
                                ProductId = id,
                                AllProducts = _productService.GetAllProductsSelectList(id,GlobalHelper.SelectListDefaultOption)
                            };
            return View(model);
        }
        [HttpPost]
        public ActionResult RequestAQuote(RequestQuoteModel model)
        {
            if(ModelState.IsValid)
            {
                var entity = model.ToEntity();
                _requestAQuoteService.Add(entity);
            }
            return View(model);
        }

        public ActionResult Product(int id = 0)
        {
            var model = _productService.GetById(id);
            return View(model);
        }

        public ActionResult Featured()
        {
            var model = new BrochureModel
                            {
                                Brochures = _brochureService.GetAll().ToList()
                            };
            return View(model);
        }

        public ActionResult RepairServices()
        {
            return View();
        }
    }
}