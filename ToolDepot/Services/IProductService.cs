using System.Web.Mvc;
using ToolDepot.Domain.Products;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public interface IProductService : ICrudService<Product>
    {
        
    }
}
