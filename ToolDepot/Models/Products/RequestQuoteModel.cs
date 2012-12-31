using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Core.Domain.Products;

namespace ToolDepot.Models.Products
{
    public class RequestQuoteModel
    {
        public RequestAQuote RequestQuote { get; set; }
        public string ProductId { get; set; }
        public SelectList AllProducts { get; set; }
    }
}