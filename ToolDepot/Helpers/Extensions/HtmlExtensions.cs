using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ToolDepot.Helpers.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString BackLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var sb = new StringBuilder("<a href=\"/");
            sb.Append(controllerName);
            sb.Append("/");
            sb.Append(actionName);
            sb.Append("\" ");
            sb.Append("class=\"btn btn-link\">");
            //sb.Append("<i class=\"icon-chevron-left icon-white\"></i>");
            sb.Append("«&nbsp;");
            if (string.IsNullOrEmpty(linkText))
            {
                linkText = "Take me back to previous page";
            }
            sb.Append(linkText);
            sb.Append("</a>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}