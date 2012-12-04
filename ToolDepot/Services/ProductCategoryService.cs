using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Data;
using ToolDepot.Domain.Products;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class ProductCategoryService : CrudService<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IRepository<ProductCategory> repo)
            : base(repo)
        {

        }
        public SelectList GetProductCategorySelectList(string selectedValue, string extraItem = null)
        {
            var list = GetAll().ToList();

            if (!string.IsNullOrEmpty(extraItem))
            {
                var categoryField = new ProductCategory
                    {
                        Id = 0,
                        CategoryName = extraItem
                    };
                list.Insert(0, categoryField);
            }
            var selectedIndex = 0;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                selectedIndex = list.FindIndex(x => Convert.ToString(x.Id) == selectedValue);
            }

            var selectList = new SelectList(list, "Id", "CategoryName", selectedIndex);

            return selectList;
        }
    }
}