using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Data;
using ToolDepot.Models;

namespace ToolDepot.Services
{
    public class ProductCategoryService : CrudService<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(IRepository<ProductCategory> repo)
            : base(repo)
        {

        }
        public SelectList GetProductCategorySelectList(string extraItem = null)
        {
            var list = GetAll();

            if (!string.IsNullOrEmpty(extraItem))
            {
                var categoryField = new ProductCategory
                    {
                        CategoryId = 0,
                        CategoryName = "Please Select"
                    };
                //list.Insert(0, categoryField);
            }




            var selectList = new SelectList(list, "CategoryId", "CategoryName", 0);

            return selectList;
        }
    }
}