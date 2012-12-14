using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductDescription
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public string ProductFeatures { get; set; }
        public string ProductSpecs { get; set; }
        public string OwnersManual { get; set; }

    }
}