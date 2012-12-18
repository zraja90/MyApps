using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolDepot.Areas.Admin.Models.Products;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Models;
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



        #endregion
    }
}