using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestVuelos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           config.Routes.MapHttpRoute(
                name: "VuelosEntrantes",
                routeTemplate: "api/Vuelos/VuelosEntrantes",
                defaults: new { controller = "Vuelos", action = "GetVuelosEntrantes", id = RouteParameter.Optional }
        );
        }
    }
}
