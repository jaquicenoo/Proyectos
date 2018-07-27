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
            name: "ValidarUsuario",
            routeTemplate: "api/Usuarios/ValidarUsuario",
            defaults: new { controller = "Usuarios", action = "ValidarUsuario" }
            );
            config.Routes.MapHttpRoute(
            name: "PostUsuarios",
            routeTemplate: "api/Usuarios/PostUsuarios",
            defaults: new { controller = "Usuarios", action = "PostUsuarios" }
            );
            config.Routes.MapHttpRoute(
                name: "GetAllVuelos",
                routeTemplate: "api/Vuelos/GetAllVuelos",
                defaults: new { controller = "Vuelos", action = "GetAllVuelos"}
             );
            config.Routes.MapHttpRoute(
                name: "GetVuelo",
                routeTemplate: "api/Vuelos/GetVuelo/{id}",
                defaults: new { controller = "Vuelos", action = "GetVuelo", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "GetAllAerolineas",
                routeTemplate: "api/Vuelos/GetAllAerolineas",
                defaults: new { controller = "Vuelos", action = "GetAllAerolineas"}
             );
            config.Routes.MapHttpRoute(
                name: "GetAllCiudades",
                routeTemplate: "api/Vuelos/GetAllCiudades",
                defaults: new { controller = "Vuelos", action = "GetAllCiudades" }
            );
        }
    }
}
