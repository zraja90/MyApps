using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Data.Mapping.Products
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Log");
            this.HasKey(l => l.Id);
            this.Property(l => l.Name);
           
            this.Property(l => l.Description);
            this.Property(l => l.IsFeatured);
            this.Property(l => l.CreatedDate);

            HasRequired(t => t.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(t => t.CategoryId);
                
            
        }
    }
}