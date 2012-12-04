using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Models;

namespace ToolDepot.Migrations
{
    public class InitMigrationSeed
    {
        public static void Seed(UsersContext context)
        {
            InitProduct(context);
            InitProductCategory(context);
        }

        private static void InitProduct(UsersContext context)
        {
            var product = new List<Product>
                              {
                                  new Product
                                      {
                                          Name = "Tool",
                                          Description = "Description",
                                          Category = "Category",
                                          Image = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs"
                                      }
                              };
            if (!context.Set<Product>().Any())
            {
                product.ForEach(x => context.Set<Product>().Add(x));
            }
            context.SaveChanges();
        }
        private static void InitProductCategory(UsersContext context)
        {
            var category = new List<ProductCategory>
                               {
                                   new ProductCategory
                                       {
                                           CategoryName = "Power Tools",
                                           IsFeaturedCategory = true,
                                           CreatedDate = DateTime.UtcNow
                                       },
                                new ProductCategory
                                       {
                                           CategoryName = "Machinery Tools",
                                           IsFeaturedCategory = false,
                                           CreatedDate = DateTime.UtcNow
                                       }
                               };
            if (!context.Set<ProductCategory>().Any())
            {
                category.ForEach(x => context.Set<ProductCategory>().Add(x));
            }
            context.SaveChanges();
        }
    }
}