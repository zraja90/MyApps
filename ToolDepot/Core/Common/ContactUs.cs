using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolDepot.Core.Common
{
    public class ContactUs
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}