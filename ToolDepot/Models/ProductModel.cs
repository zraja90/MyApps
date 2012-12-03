using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToolDepot.Models
{
    [Table("Products")]
    public class ProductModel
    {
        public ProductModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ProductFeatures { get; set; }
        public string ProductSpecs { get; set; }
        public string OwnersManual { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedDate { get; set; }

        public ProductCategoryModel Category { get; set; }
    }
}