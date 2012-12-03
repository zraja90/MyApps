using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Models
{
    public class FeaturedProductModel
    {
        public IList<ProductModel> Products { get; set; }
    }
}