using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repo) : base(repo)
        {
        }
        
      
    }
}