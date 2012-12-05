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

        public IList<FeaturedProducts> GetFeaturedProducts()
        {
            var featuredCategory = _productCategoryService.GetMany(x => x.IsFeaturedCategory).ToList();
            var featuredProduct = _productService.GetMany(x => x.IsFeaturedProduct).ToList();

            IList<FeaturedProducts> featuredProductsWithCategory = new List<FeaturedProducts>();

            for (int i = 0; i < featuredCategory.Count; i++)
            {
                var featured = new FeaturedProducts();
                
                featured.CategoryId = featuredCategory[i].Id;
                featuredProductsWithCategory[i].CategoryName = featuredCategory[0].CategoryName;
                for (int j = 0; j < featuredProduct.Count; j++)
                {
                    featuredProductsWithCategory[i].Products[j] = featuredProduct[j];
                }
                featuredProductsWithCategory.Add(featured);
            }
            return featuredProductsWithCategory;
        }

        public IList<FeaturedProducts> FeaturedProducts { get { return GetFeaturedProducts(); } }
    }
}