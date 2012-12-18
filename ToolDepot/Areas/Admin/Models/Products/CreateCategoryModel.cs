using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Areas.Admin.Models.Products
{
    public class CreateCategoryModel
    {
        public CreateCategoryModel()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public string CategoryName { get; set; }
        public bool IsFeatured { get; set; }
        public string CategoryImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}