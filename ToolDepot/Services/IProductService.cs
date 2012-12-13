using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public interface IProductService : ICrudService<Product>
    {
        
    }
}
