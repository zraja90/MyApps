using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Email;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Core.Domain.Security;
using ToolDepot.Core.Domain.Tasks;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Migrations
{
    public class InitMigrationSeed
    {
        public static void Seed(AppContext context)
        {
           // InitCategory(context);
           //InitProduct(context);

           
          /*  InitPermissions(context);
            InitRoles(context);
            InitCustomers(context);
           */
            InitEmailAccount(context);
            InitScheduleTask(context);
        }

        private static void InitScheduleTask(AppContext context)
        {
            var settings = new List<ScheduleTask>
                               {
                                   new ScheduleTask
                                       {
                                           Name = "Send Emails",
                                           Seconds = 60,
                                           Type = "ToolDepot.Services.Messages.QueuedMessagesSendTask, ToolDepot.Services",
                                           Enabled = true,
                                           StopOnError = false,
                                           LastStartUtc = null,
                                           LastEndUtc = null,
                                           LastSuccessUtc = null
                                       },
                                   new ScheduleTask
                                       {
                                           Name = "Keep alive",
                                           Seconds = 300,
                                           Type = "ToolDepot.Services.Common.KeepAliveTask, ToolDepot.Services",
                                           Enabled = true,
                                           StopOnError = false,
                                           LastStartUtc = null,
                                           LastEndUtc = null,
                                           LastSuccessUtc = null
                                       }
                               };
            if (!context.Set<ScheduleTask>().Any())
            {
                settings.ForEach(x => context.Set<ScheduleTask>().Add(x));
            }
            context.SaveChanges();
        }

        private static void InitEmailAccount(AppContext context)
        {
            var settings = new List<EmailAccount>
                               {
                                   new EmailAccount
                                       {
                                           DisplayName = "Tool Depot",
                                           Email = "zeeshan@unigo.com",
                                           Host = "127.0.0.1",
                                           Port = 25,
                                           EnableSsl = false,
                                           IsDefault = true,
                                           Username = "zeeshan@unigo.com",
                                           Password = "aa",
                                           UseDefaultCredentials = true
                                       }
                               };
            if (!context.Set<EmailAccount>().Any())
            {
                settings.ForEach(x => context.Set<EmailAccount>().Add(x));
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
                                           Id = 1,
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
        private static void InitCategory(AppContext context)
        {
            var category = new List<ProductCategory>
                               {
                                   new ProductCategory
                                       {
                                           Id = 1,
                                           CategoryName = "Lifts",
                                           CategoryImage = "/Content/images/Brochure/BoomLift.jpg",
                                           IsFeaturedCategory = false,
                                           CreatedDate = DateTime.UtcNow
                                       },
                                       new ProductCategory
                                       {
                                           Id = 2,
                                           CategoryName = "Saws",
                                           CategoryImage = "/Content/images/Brochure/BoomLift.jpg",
                                           IsFeaturedCategory = false,
                                           CreatedDate = DateTime.UtcNow
                                       },
                                       new ProductCategory
                                       {
                                           Id = 2,
                                           CategoryName = "Drills",
                                           CategoryImage = "/Content/images/Brochure/BoomLift.jpg",
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

        private static void InitProduct(AppContext context)
        {
            var product = new List<Product>
                              {
                                  new Product
                                      {
                                          Id = 1,
                                          Name = "JLG Boom Lift",
                                          CategoryId = 4,
                                          Image = "/Content/images/Brochure/BoomLift.jpg",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeatured= true
                                      },
                                      new Product
                                      {
                                          Id = 2,
                                          Name = "Scissor Lift",
                                          CategoryId = 4,
                                          Image = "/Content/images/Brochure/ScissorLift.jpg",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeatured= true
                                      },
                                       new Product
                                      {
                                          Id = 3,
                                          Name = "Core Drill",
                                          CategoryId = 6,
                                          Image = "/Content/images/Brochure/CoreDrill.jpg",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeatured= true
                                      },
                                      new Product
                                      {
                                          Id = 4,
                                         Name = "Rotary Drill",
                                          CategoryId =6,
                                          Image = "/Content/images/Brochure/RotaryDrill.jpg",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeatured= true
                                      },
                                      new Product
                                      {
                                          Id = 5,
                                          Name = "14 inch Portable Cut Off Saw",
                                          CategoryId = 5,
                                          Image = "/Content/images/Brochure/14inPortableCutoffSaw.jpg",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeatured= false
                                      },
                                       new Product
                                      {
                                          Id = 6,
                                          Name = "Walk Behind Saw",
                                          CategoryId = 5,
                                          Image = "/Content/images/Brochure/WalkBehindSaw.jpg",
                                          CreatedDate = DateTime.UtcNow,
                                          IsFeatured= false
                                      }
                              };
            if (!context.Set<Product>().Any())
            {
                product.ForEach(x => context.Set<Product>().Add(x));
            }
            context.SaveChanges();
        }


    }
}