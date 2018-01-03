using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Biblioteca
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Livro", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Livros",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Livro", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Editoras",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Editora", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Autores",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Autor", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
