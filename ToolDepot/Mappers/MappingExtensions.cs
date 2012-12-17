﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Models;
using ToolDepot.Models.Products;

namespace ToolDepot.Mappers
{
    public static class MappingExtensions
    {
        
        #region Product
        public static ProductWithCategoryModel ToModel(this Product entity)
        {
            return Mapper.Map<Product, ProductWithCategoryModel>(entity);
        }

        public static Product ToEntity(this ProductWithCategoryModel model)
        {
            return Mapper.Map<ProductWithCategoryModel, Product>(model);
        }

        public static Product ToEntity(this ProductWithCategoryModel model, Product destination)
        {
            return Mapper.Map(model, destination);
        }



        #endregion
    }
}