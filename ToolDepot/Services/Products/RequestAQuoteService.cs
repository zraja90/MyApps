using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services.Products
{
    public class RequestAQuoteService: CrudService<RequestAQuote>, IRequestAQuoteService
    {
        public RequestAQuoteService(IRepository<RequestAQuote> repo)
            : base(repo)
        {
        }
    }
}