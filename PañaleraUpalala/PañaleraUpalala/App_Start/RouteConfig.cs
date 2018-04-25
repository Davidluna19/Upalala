using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PañaleraUpalala
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Createproducto",
                url: "Producto/Create/",
                defaults: new { controller = "ProductoCreateView", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditarPoducto",
                url: "Producto/Edit/{id}",
                defaults: new { controller = "ProductoCreateView", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
