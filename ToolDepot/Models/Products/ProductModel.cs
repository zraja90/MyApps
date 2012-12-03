using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Helpers;
using ToolDepot.Services;

namespace ToolDepot.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ProductFeatures { get; set; }
        public string ProductSpecs { get; set; }
        public string OwnersManual { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }

        public SelectList AllCategory { get; set; }

        public void PopulateSelectList(IProductCategoryService productCategoryService)
        {
            productCategoryService.GetProductCategorySelectList(Category, GlobalHelper.SelectListDefaultOption);
        }
    }
}