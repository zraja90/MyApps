﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Domain.Products
{
    public class FeaturedProducts
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Product Products { get; set; }
    }
}