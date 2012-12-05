using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolDepot.Domain.Products;
using ToolDepot.Models;

namespace ToolDepot.Migrations
{
    public class InitMigrationSeed
    {
        public static void Seed(UsersContext context)
        {
            InitProduct(context);
            InitProductDescription(context);
            InitProductCategory(context);
        }

        private static void InitProduct(UsersContext context)
        {
            var product = new List<Product>
                              {
                                  new Product
                                      {
                                          Id = 1,
                                          Name = "Tool",
                                          Category = 1,
                                          ProductImage = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          DayPrice = 100,
                                          WeekPrice = 300
                                      },
                                      new Product
                                      {
                                           Id = 2,
                                          Name = "Tool",
                                          Category = 1,
                                          ProductImage = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          DayPrice = 100,
                                          WeekPrice = 300
                                      },
                                       new Product
                                      {
                                           Id = 3,
                                          Name = "Tool",
                                          Category = 1,
                                          ProductImage = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          DayPrice = 100,
                                          WeekPrice = 300
                                      },
                                      new Product
                                      {
                                          Id = 4,
                                          Name = "Tool",
                                          Category = 2,
                                          ProductImage = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          DayPrice = 100,
                                          WeekPrice = 300
                                      },
                                      new Product
                                      {
                                           Id = 5,
                                          Name = "Tool",
                                          Category = 2,
                                          ProductImage = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          DayPrice = 100,
                                          WeekPrice = 300
                                      },
                                       new Product
                                      {
                                           Id = 6,
                                          Name = "Tool",
                                          Category = 2,
                                          ProductImage = "Image",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeaturedProduct = true,
                                          DayPrice = 100,
                                          WeekPrice = 300
                                      }
                              };
            if (!context.Set<Product>().Any())
            {
                product.ForEach(x => context.Set<Product>().Add(x));
            }
            context.SaveChanges();
        }

        private static void InitProductDescription(UsersContext context)
        {
            var desciption = new List<ProductDescription>
                              {
                                  new ProductDescription
                                      {
                                          ProductId = 1,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                      new ProductDescription
                                      {
                                          ProductId = 2,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                       new ProductDescription
                                      {
                                          ProductId = 3,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs"
                                      },
                                      new ProductDescription
                                      {
                                          ProductId = 4,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                      new ProductDescription
                                      {
                                          ProductId = 5,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                       new ProductDescription
                                      {
                                          ProductId = 6,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs"
                                      }
                              };
            if (!context.Set<ProductDescription>().Any())
            {
                desciption.ForEach(x => context.Set<ProductDescription>().Add(x));
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
                                           CategoryName = "Machinery",
                                           IsFeaturedCategory = true,
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