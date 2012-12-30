﻿using System.Linq;
using System.Web.Mvc;
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

        public ProductsController(IProductService productService, IProductCategoryService productCategoryService,
            IBrochureService brochureService, IWorkflowMessageService workflowMessageService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _brochureService = brochureService;
            _workflowMessageService = workflowMessageService;
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

        public ActionResult RequestAQuote()
        {
            var model = new RequestQuoteModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult RequestAQuote(RequestQuoteModel model)
        {
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