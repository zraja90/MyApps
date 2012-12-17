using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Data.Mapping.Products
{
    public class ProductSpecsMap : EntityTypeConfiguration<ProductSpecs>
    {
        public ProductSpecsMap()
        {
            this.ToTable("ProductSpecs");
            this.Property(t => t.Specs);

            HasRequired(t => t.Product)
                .WithMany(p => p.ProductSpecs)
                .HasForeignKey(t => t.ProductId);
        }
    }
}