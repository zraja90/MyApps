using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Domain.Products;

namespace ToolDepot.Core
{
    public interface IWorkContext
    {
        ProductCategory CurrentCategory { get; set; }
        Product Products { get; }
        bool IsLoggedIn { get; }
    }
}