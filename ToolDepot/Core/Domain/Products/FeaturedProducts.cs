using System.Collections.Generic;

namespace ToolDepot.Core.Domain.Products
{
    public class FeaturedProducts
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; }
    }
}