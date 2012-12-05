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

        public List<FeaturedProducts> GetFeaturedProducts()
        {
            var featuredCategory = _productCategoryService.GetMany(x => x.IsFeaturedCategory).ToList();
            var featuredProduct = _productService.GetMany(x => x.IsFeaturedProduct).ToList();

            var featuredProductsWithCategory = new List<FeaturedProducts>();

            for (int i = 0; i < featuredCategory.Count; i++)
            {
                var featured = new FeaturedProducts
                                   {
                                       CategoryId = featuredCategory[i].Id,
                                       CategoryName = featuredCategory[i].CategoryName,
                                       Products = new List<Product>()
                                   };

                foreach (var t in featuredProduct)
                {
                    if(t.Category == featuredCategory[i].Id)
                    {
                        var product = t;
                        featured.Products.Add(product);
                    }
                }
                featuredProduct.RemoveAll(x => x.Category == featuredCategory[i].Id);
                featuredProductsWithCategory.Add(featured);
            }
            return (List<FeaturedProducts>) featuredProductsWithCategory;
        }

        public List<FeaturedProducts> FeaturedProducts { get { return GetFeaturedProducts(); } }
    }
}