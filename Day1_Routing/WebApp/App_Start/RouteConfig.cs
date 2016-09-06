using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using WebApp.Infrastructure;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();   //mspec tests don't work with attribute routes, comment this line 

            routes.MapRoute(
                name: "StaticSerment",
                url: "Static/Index",
                defaults: new { controller = "Action", action = "Static" }
            );

            routes.MapRoute(
                name: "CustomConstraints",
                url: "Action/{action}/{id}",
                defaults: new {controller = "Action"},
                constraints: new
                {
                    custom = new SimpleNumberIdConstraint()
                }
            );

            routes.MapRoute(
                name: "IndexFromOtherAssembly",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new
                {
                    id = new RangeRouteConstraint(1, 40),
                },
                namespaces: new[] { "WebApp.Controllers" }
            );

            routes.MapRoute(
                name: "IndexWebApp",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { id = UrlParameter.Optional},
                constraints: new
                {
                    controller = "^H.*",
                    action = "Index"
                },
                namespaces: new[] { "CustomLibrary" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{*catchall}",
                defaults: new { controller = "Action", action = "Default" }
            );
        }
    }
}
