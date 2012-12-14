using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain.Products
{
    [Table("Brochure")]
    public class Brochure : BaseEntity
    {
        public Brochure()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Ordinal { get; set; }
        public bool IsActive { get; set; }
        public string ProductImage  { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}