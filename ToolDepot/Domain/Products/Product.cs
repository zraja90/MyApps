using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Domain.Products
{
    [Table("Products")]
    public class Product
    {
        public Product()
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
        public bool IsFeaturedProduct { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DayPrice { get; set; }
        public int WeekPrice { get; set; }
        public int Category { get; set; }

        
    }

    
}