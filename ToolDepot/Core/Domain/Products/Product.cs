using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain.Products
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsFeatured { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }

        private ProductCategory _category;
        public virtual ProductCategory Category
        {
            get { return _category ?? (_category = new ProductCategory()); }
            protected set { _category = value; }
        }
        
        //Product Featuers
        //Product Specs
        //Incudes
        //Manuals

    }

    


}