using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Areas.Admin.Models.Products
{
    public class ProductFeaturesSpecsModel
    {
        public Product Product { get; set; }
        public IList<string> Specs { get; set; }
        public IList<string> Features { get; set; }
    }
}