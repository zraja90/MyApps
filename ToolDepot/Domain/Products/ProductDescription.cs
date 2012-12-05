using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToolDepot.Domain.Products
{
    [Table("ProductDescription")]
    public class ProductDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public string Description { get; set; }
        public string ProductFeatures { get; set; }
        public string ProductSpecs { get; set; }
        public string OwnersManual { get; set; }

    }
}