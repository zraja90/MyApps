using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Domain.Products
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
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsFeaturedCategory { get; set; }
        public string CategoryAvatar { get; set; }
        public DateTime CreatedDate { get; set; }

        
    }
}