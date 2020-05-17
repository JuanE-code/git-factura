using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Facturacion
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }


            //);
            //config.Routes.MapHttpRoute(
            //    name: "ConsultarClientesRoute",
            //    routeTemplate: "{controller}/{action}",
            //    new { controller = "ClienteAPI", action = "ConsultarClientes" }
            //);
            config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "{controller}/{action}",
             defaults: new { id = RouteParameter.Optional }
         );


            //config.Routes.MapHttpRoute(
            //    name: "ConsultarClientesRoute",
            //    routeTemplate: "{controller}/{action}",
            //    new { controller = "ClienteAPI", action = "ConsultarClientes" }
            //);
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "ConsultarClientesRoute",
            //    routeTemplate: "{controller}",
            //    new { controller = "ClienteAPI", action = "ConsultarClientes" }
            //);
        }
    }
}
