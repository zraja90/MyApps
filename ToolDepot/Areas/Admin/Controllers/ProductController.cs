using System;
using System.Linq;
using System.Web.Mvc;
using ToolDepot.Areas.Admin.Models;
using ToolDepot.Areas.Admin.Models.Products;
using ToolDepot.Filters;
using ToolDepot.Helpers;
using ToolDepot.Mappers;
using ToolDepot.Services;
using ToolDepot.Services.Products;

namespace ToolDepot.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IProductSpecsService _productSpecsService;
        private readonly IProductFeaturesService _productFeaturesService;

        public ProductController(IProductCategoryService productCategoryService, IProductService productService, IProductSpecsService productSpecsService, IProductFeaturesService productFeaturesService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _productSpecsService = productSpecsService;
            _productFeaturesService = productFeaturesService;
        }

        public ActionResult Index()
        {
            var model = new AllProductsListModel
                            {
                                Products = _productService.GetAll().ToList(),
                                AllCategories = _productCategoryService.GetAll().ToList()
                            };

            return View(model);
        }

        public ActionResult CreateCategory()
        {
            var model = new CreateCategoryModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCategory(CreateCategoryModel model)
        {
            var entity = model.ToEntity();
            _productCategoryService.Add(entity);
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(int id = 0)
        {
            var model = new ProductDetailModel {Product = _productService.GetById(id)};
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
                if (ModelState.IsValid)
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

        public ActionResult Edit(int id = 0)
        {
            var product = _productService.GetById(id);
            var model = new EditProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Description,
                IsFeatured = product.IsFeatured,
                CategoryId = product.CategoryId,
                Product = product,
                ProductSpecs = product.ProductSpecs.ToList(),
                ProductFeatures = product.ProductFeatures.ToList()

            };

            model.AllCategories = _productCategoryService.GetProductCategorySelectList(model.CategoryName, GlobalHelper.SelectListDefaultOption);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(EditProductModel model)
        {
            var product = _productService.GetById(model.Id);
            product.Name = model.Name;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.IsFeatured = model.IsFeatured;
            product.Image = model.Image;
            product.CreatedDate = DateTime.UtcNow;

            _productService.Update(product);

            return RedirectToAction("Edit", "Product",new {id=model.Id});
        }

        [HttpPost]
        public ActionResult EditSpecs(EditProductModel model)
        {
            var specs = _productSpecsService.GetMany(x => x.ProductId == model.Id).ToList();
            if (specs.Any())
            {
                foreach (var spec in specs)
                {
                    _productSpecsService.Delete(spec);
                }
                foreach (var spec in model.ProductSpecs)
                {
                    if (spec.ProductId == 0) spec.ProductId = model.Id;
                    _productSpecsService.Add(spec);
                }
            }
            else
            {
                foreach (var spec in model.ProductSpecs)
                {
                    spec.ProductId = model.Id;
                    _productSpecsService.Add(spec);
                }
            }
            return RedirectToAction("Edit", "Product",new {id=model.Id});
        }

        [HttpPost]
        public ActionResult EditFeatured(EditProductModel model)
        {
            var features = _productFeaturesService.GetMany(x => x.ProductId == model.Id).ToList();
            if (features.Any())
            {
                foreach (var feature in features)
                {
                    _productFeaturesService.Delete(feature);
                }
                foreach (var feature in model.ProductFeatures)
                {
                    if (feature.ProductId == 0) feature.ProductId = model.Id;
                    _productFeaturesService.Add(feature);
                }
            }
            else
            {
                foreach (var feature in model.ProductFeatures)
                {
                    feature.ProductId = model.Id;
                    _productFeaturesService.Add(feature);
                }
            }
            return RedirectToAction("Edit", "Product", new { id = model.Id });
        }
    }

}
