using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyPortfolio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("HomePage", "", new { controller = "Home", action = "Index" },new[] { "MyPortfolio.Controllers" });
            routes.MapRoute(name: "ResumeRoute", url: "{action}/{id}",
                            defaults: new {controller = "Home", action = "Resume", id = UrlParameter.Optional},
                            namespaces: new[] {"MyPortfolio.Controllers"});
            routes.MapRoute(name: "Default",url: "{controller}/{action}/{id}",defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },namespaces: new[] { "MyPortfolio.Controllers" });
        }
    }
}