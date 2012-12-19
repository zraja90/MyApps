using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services.Products
{
    public class RequestQuoteService : CrudService<RequestAQuoteModel>, IRequestQuoteService
    {
        public RequestQuoteService(IRepository<RequestAQuoteModel> repo) : base(repo)
        {
        }
    }
}