using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            config.MapHttpAttributeRoutes();



            // config.Routes.MapHttpRoute(
            //    name: "ConsultarSiniestrosAfiliacionRoute",
            //    routeTemplate: "{controller}/{nroAfiliacion}",
            //    new { controller = "ConsultaSiniestroNotificacion", action = "ConsultarSiniestrosAfiliacion" }
            //);

            // config.Routes.MapHttpRoute(
            //     name: "GetAllCausalRoute",
            //     routeTemplate: "{controller}",
            //     new { controller = "ConsultaSiniestroNotificacion", action = "GetAllCausal" }
            // );
            // Rutas de API web
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //  config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "{controller}/{action}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            //config.Routes.MapHttpRoute(
            //    name: "ConsultarClientesRoute",
            //    routeTemplate: "{controller}/{action}",
            //    new { controller = "Clientes", action = "ConsultarClientes" }
            //);
        }
    }
}
