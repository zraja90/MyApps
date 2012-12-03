using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class RequestQuoteService : CrudService<RequestAQuoteModel>, IRequestQuoteService
    {
        public RequestQuoteService(IRepository<RequestAQuoteModel> repo) : base(repo)
        {
        }
    }
}