using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Domain.Products
{
    public class ProductReviews : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Rating { get; set; }
        public string Review { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
    }
}