using AutoMapper;
using ToolDepot.Areas.Admin.Models.Products;
using ToolDepot.Core.Domain.Customers;
using ToolDepot.Core.Domain.Products;
using ToolDepot.Models;
using ToolDepot.Models.Common;
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
            Mapper.CreateMap<Product, CreateProductModel>();
            Mapper.CreateMap<CreateProductModel, Product>();

            Mapper.CreateMap<ProductCategory, CreateCategoryModel>();
            Mapper.CreateMap<CreateCategoryModel, ProductCategory>();

            Mapper.CreateMap<EmailSubscription, SubscriptionModel>();
            Mapper.CreateMap<SubscriptionModel, EmailSubscription>();

        }
    }
}