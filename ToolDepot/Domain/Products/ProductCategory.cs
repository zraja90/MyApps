using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        public ProductCategory()
        {
            CreatedDate = DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public int Value { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}