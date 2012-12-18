using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Areas.Admin.Models;
using ToolDepot.Areas.Admin.Models.Products;
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
            var model = new AllProductsListModel {Products = _productService.GetAll().ToList()};


            return View(model);
        }

        public ActionResult AddSpecsFeatures(int id=0)
        {
            var model = new ProductFeaturesSpecsModel();
            return View();
        }

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(int id=0)
        {
            var model = new ProductDetailModel();
            model.Product = _productService.GetById(id);
            return View(model);
        }

        //
        // GET: /Admin/Product/Create

        public ActionResult Create()
        {
            var model = new CreateProductModel();
            model.AllCategories = _productCategoryService.GetProductCategorySelectList(model.CategoryName, GlobalHelper.SelectListDefaultOption);
            return View(model);
        }
        
        //
        // POST: /Admin/Product/Create

        [HttpPost]
        public ActionResult Create(CreateProductModel model)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    var entity = model.ToEntity();
                    _productService.Add(entity);
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Product/Edit/5

        public ActionResult Edit(int id=0)
        {
            var product = _productService.GetById(id);
            var model = new CreateProductModel
                            {
                                Id = product.Id,
                                Name = product.Name,
                                Description = product.Description,
                                Image = product.Description,
                                IsFeatured = product.IsFeatured,
                                CategoryId = product.CategoryId
                            };
            model.AllCategories = _productCategoryService.GetProductCategorySelectList(model.CategoryName, GlobalHelper.SelectListDefaultOption);

            return View(model);
        }

        //
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        public ActionResult Edit(CreateProductModel model)
        {
            try
            {
                var product = _productService.GetById(model.Id);
                product.Name = model.Name;
                product.Description = model.Description;
                product.IsFeatured = model.IsFeatured;
                product.Image = model.Image;
                product.CreatedDate = model.CreatedDate;
                product.CategoryId = model.CategoryId;

                _productService.Update(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
