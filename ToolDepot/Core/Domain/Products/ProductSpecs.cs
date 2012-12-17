using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductSpecs : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Specs { get; set; }
    }
}