using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Git4Me
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           // var config = new HttpConfiguration();
            // This next line could stay if you want xml formatting
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // This next commented out line was causing the problem
            //var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            // This next line was the solution
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.UseDataContractJsonSerializer = false; // defaults to false, but no harm done
            //jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            //jsonFormatter.SerializerSettings.Formatting = Formatting.None;
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Add(jsonFormatter);
            //// remaining irrelevant code commented out
            //return config;
        }
    }
}
