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
                                          IsFeatured = true,
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs"
                                      }
                              };
            if (!context.Set<Product>().Any())
            {
                product.ForEach(x=>context.Set<Product>().Add(x));
            }
            context.SaveChanges();
        }
    }
}