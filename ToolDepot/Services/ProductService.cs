using System.Linq;
using System.Web.Mvc;
using ToolDepot.Data;
using ToolDepot.Domain.Products;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repo) : base(repo)
        {
        }

      
    }
}