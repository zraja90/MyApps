using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Core.Domain.Security;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Migrations
{
    public class InitMigrationSeed
    {
        public static void Seed(AppContext context)
        {
            /*  InitProduct(context);
              InitProductDescription(context);
              InitProductCategory(context);*/
            //InitBrochure(context);
            InitRoles(context);
            InitPermissions(context);
            InitCustomers(context);
            
            
        }

        public static void InitBrochure(AppContext context)
        {
            var brochure = new List<Brochure>
                               {
                                   new Brochure
                                       {
                                           
                                       }
                               };
            if (!context.Set<Brochure>().Any())
            {
                brochure.ForEach(x => context.Set<Brochure>().Add(x));
            }
            context.SaveChanges();

        }
        private static void InitCustomers(AppContext context)
        {
            var customer = new Customer()
            {
                UserName = "super@unigo.com",
                Email = "super@unigo.com",
                Password = "AJr8zm5tyOB2NDsch4xx5u17SmJTS1DPOjjBQ4m6FJJSxxcBSSkQXAHGhCgyUKIL5A==",

                FirstName = "unigo",
                LastName = "unigo",
                Active = true,
                Deleted = false,
                CreatedOnUtc = DateTime.UtcNow,
                LastActivityDateUtc = DateTime.UtcNow
            };


            if (context.Set<Customer>().Any())
                return;

            var customrole = context.Set<CustomerRole>().FirstOrDefault(x => x.SystemName == "Admin");

            customer.CustomerRoles.Add(customrole);
            
            context.Set<Customer>().AddOrUpdate(customer);

            context.SaveChanges();
        }

        private static void InitPermissions(AppContext context)
        {

            var settings = new List<PermissionRecord>
                               {
                                   new PermissionRecord
                                       {
                                           Name = "Access admin area",
                                           SystemName = "AccessAdminPanel",
                                           Category = "Standard"
                                       }
                               };
            if (!context.Set<PermissionRecord>().Any())
            {
                settings.ForEach(x => context.Set<PermissionRecord>().Add(x));
            }


            context.SaveChanges();

        }

        private static void InitRoles(AppContext context)
        {

            var settings = new List<CustomerRole>
                               {
                                   new CustomerRole
                                       {
                                           Name = "Tool Depot Admin",
                                           Active = true,
                                           IsSystemRole = true,
                                           SystemName = "Admin",
                                           IsGlobal = true
                                       }
                               };
            if (!context.Set<CustomerRole>().Any(x => x.SystemName == SystemCustomerRoleNames.Admin))
            {
                settings.ForEach(x => context.Set<CustomerRole>().AddOrUpdate(x));

            }
            context.SaveChanges();
        }

        /*
        private static void InitProduct(AppContext context)
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

        private static void InitProductDescription(AppContext context)
        {
            var desciption = new List<ProductSpecs>
                              {
                                  new ProductSpecs
                                      {
                                          ProductId = 1,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                      new ProductSpecs
                                      {
                                          ProductId = 2,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                       new ProductSpecs
                                      {
                                          ProductId = 3,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs"
                                      },
                                      new ProductSpecs
                                      {
                                          ProductId = 4,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                      new ProductSpecs
                                      {
                                          ProductId = 5,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs",
                                      },
                                       new ProductSpecs
                                      {
                                          ProductId = 6,
                                          Description = "Description",
                                          OwnersManual = "Owners",
                                          ProductFeatures = "Features",
                                          ProductSpecs = "Specs"
                                      }
                              };
            if (!context.Set<ProductSpecs>().Any())
            {
                desciption.ForEach(x => context.Set<ProductSpecs>().Add(x));
            }
            context.SaveChanges();
        }

        private static void InitProductCategory(AppContext context)
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
         * */
    }
}