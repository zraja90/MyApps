using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Domain.Products;

namespace ToolDepot.Models
{
    public class FeaturedProductCategoriesModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }
        public bool IsFeatured { get; set; }
    }
}