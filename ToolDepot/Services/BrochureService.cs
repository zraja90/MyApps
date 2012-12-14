using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Data;

namespace ToolDepot.Services
{
    public class BrochureService: CrudService<Brochure>, IBrochureService
    {
        public BrochureService(IRepository<Brochure> repo) : base(repo)
        {
        }
    }
}