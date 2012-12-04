using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core;
using ToolDepot.Domain.Products;
using ToolDepot.Services;

namespace ToolDepot.Infrastructure
{
    public partial class ProductContext : IProductContext
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductContext(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public IList<Product> GetAllProducts()
        {
            var products = _productService.GetAll().ToList();
            return products;
        }

        public IList<ProductCategory> GetAllProductCategories()
        {
            var categories = _productCategoryService.GetAll().ToList();
            return categories;
        }

        public IList<FeaturedProducts> GetFeaturedProductsWithCategories()
        {
            var products = GetAllProducts();
            var productCategories = GetAllProductCategories();

            //IList<FeaturedProducts> featuredProducts = new List<FeaturedProducts>();

            var featuredProducts = (from p in products
                               join pc in productCategories on p.Category equals pc.Id
                               orderby pc.Id
                               select new FeaturedProducts
                                          {
                                              CategoryId = pc.Id,
                                              CategoryName = pc.CategoryName,
                                              Products = p
                                          }).ToList();

            //return featuredProducts;
            return featuredProducts;
        }

        public IList<ProductCategory> AllProductCategory
        {
            get { return GetAllProductCategories(); }
        }

        public IList<Product> AllProducts
        {
            get { return GetAllProducts(); }
        }
        public IList<FeaturedProducts> AllFeaturedProducts
        {
            get { return GetFeaturedProductsWithCategories(); }
        }


    }
}