using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Helpers;
using ToolDepot.Mappers;
using ToolDepot.Models;
using ToolDepot.Models.Products;
using ToolDepot.Services;

namespace ToolDepot.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        public ProductController(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();
            IEnumerable<ProductModel> model = products.Select(x => x.ToModel());

            return View(model.ToList());
        }

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Product/Create

        public ActionResult Create()
        {
            var model = new Product
                            {
                                
                            };
            var aa = _productCategoryService.GetProductCategorySelectList(GlobalHelper.SelectListDefaultOption);
            return View(model);
        }
        
        //
        // POST: /Admin/Product/Create

        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Product/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Product/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
