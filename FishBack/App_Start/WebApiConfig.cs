using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FishBack
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ImageApi",
                routeTemplate: "api/images/{id}.{ext}"
                //constraints: new { id = "[^\\.]+", ext = "[^\\.]+"}
            );

            config.Routes.MapHttpRoute(
                name: "ImagePost",
                routeTemplate: "api/fishevent/{fishEventId}/{controller}/",
                defaults: new { controller = "Images" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
