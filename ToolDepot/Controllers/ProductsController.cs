using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Core;
using ToolDepot.Services;

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
            var products = _productService.GetMany(x => x.Id == id);

            return View(products);
        }

        public ActionResult RequestAQuote()
        {
            return View();
        }


    }
}
