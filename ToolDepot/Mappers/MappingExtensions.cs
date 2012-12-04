using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolDepot.Domain.Products;
using ToolDepot.Models;
using ToolDepot.Models.Products;

namespace ToolDepot.Mappers
{
    public static class MappingExtensions
    {
        
        #region Product
        public static ProductModel ToModel(this Product entity)
        {
            return Mapper.Map<Product, ProductModel>(entity);
        }

        public static Product ToEntity(this ProductModel model)
        {
            return Mapper.Map<ProductModel, Product>(model);
        }

        public static Product ToEntity(this ProductModel model, Product destination)
        {
            return Mapper.Map(model, destination);
        }



        public static FeaturedProductCategoriesModel ToModel(this FeaturedProducts entity)
        {
            return Mapper.Map<FeaturedProducts, FeaturedProductCategoriesModel>(entity);
        }

        public static FeaturedProducts ToEntity(this FeaturedProductCategoriesModel model)
        {
            return Mapper.Map<FeaturedProductCategoriesModel, FeaturedProducts>(model);
        }

        public static FeaturedProducts ToEntity(this FeaturedProductCategoriesModel model, FeaturedProducts destination)
        {
            return Mapper.Map(model, destination);
        }




        #endregion
    }
}