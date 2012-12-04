using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToolDepot.Domain.Products;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public interface IProductCategoryService : ICrudService<ProductCategory>
    {
        SelectList GetProductCategorySelectList(string selectedValue = null, string extraItem = null);
    }
}
