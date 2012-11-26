using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class UnderConstructionService : CrudService<UnderConstructionModel>, IUnderConstructionService
    {
        public UnderConstructionService(IRepository<UnderConstructionModel> repo)
            : base(repo)
        {
            
        }
    }
}