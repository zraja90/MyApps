﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolDepot.Areas.Admin.Models.Products;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Models;
using ToolDepot.Models.Common;
using ToolDepot.Models.Products;

namespace ToolDepot.Mappers
{
    public static class MappingExtensions
    {
        
        #region Product
        public static CreateProductModel ToModel(this Product entity)
        {
            return Mapper.Map<Product, CreateProductModel>(entity);
        }

        public static Product ToEntity(this CreateProductModel model)
        {
            return Mapper.Map<CreateProductModel, Product>(model);
        }

        public static Product ToEntity(this CreateProductModel model, Product destination)
        {
            return Mapper.Map(model, destination);
        }

        public static CreateCategoryModel ToModel(this ProductCategory entity)
        {
            return Mapper.Map<ProductCategory, CreateCategoryModel>(entity);
        }

        public static ProductCategory ToEntity(this CreateCategoryModel model)
        {
            return Mapper.Map<CreateCategoryModel, ProductCategory>(model);
        }

        public static ProductCategory ToEntity(this CreateCategoryModel model, ProductCategory destination)
        {
            return Mapper.Map(model, destination);
        }


        public static SubscriptionModel ToModel(this EmailSubscription entity)
        {
            return Mapper.Map<EmailSubscription, SubscriptionModel>(entity);
        }

        public static EmailSubscription ToEntity(this SubscriptionModel model)
        {
            return Mapper.Map<SubscriptionModel, EmailSubscription>(model);
        }

        public static EmailSubscription ToEntity(this SubscriptionModel model, EmailSubscription destination)
        {
            return Mapper.Map(model, destination);
        }



        #endregion
    }
}