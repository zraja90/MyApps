﻿using AutoMapper;
using ToolDepot.Domain.Products;
using ToolDepot.Models;
using ToolDepot.Models.Products;

namespace ToolDepot.Mappers
{
    public class MappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "MappingProfile"; }
        }
        protected override void Configure()
        {
            //Product
            Mapper.CreateMap<Product, ProductWithCategoryModel>();
            Mapper.CreateMap<ProductWithCategoryModel, Product>();

            Mapper.CreateMap<FeaturedProducts, FeaturedProductCategoriesModel>();
            Mapper.CreateMap<FeaturedProductCategoriesModel, FeaturedProducts>();
        }
    }
}