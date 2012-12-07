using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Domain.Products;
using ToolDepot.Models.Products;

namespace ToolDepot.Core
{
    public interface IProductContext
    {
        List<FeaturedProducts> FeaturedProducts { get; }
        ProductWithCategoryModel GetProductInfoById { get; }
        int Id { get; set; }
    }
}