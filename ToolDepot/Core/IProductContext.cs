using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Domain.Products;

namespace ToolDepot.Core
{
    public interface IProductContext
    {
        List<FeaturedProducts> FeaturedProducts { get; } 
    }
}