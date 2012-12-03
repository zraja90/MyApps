using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class ProductService : CrudService<ProductModel>, IProductService
    {
        public ProductService(IRepository<ProductModel> repo) : base(repo)
        {
        }
    }
}