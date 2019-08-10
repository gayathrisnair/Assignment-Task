using ArrayMinAPI.DbAccess;
using ArrayMinAPI.ServiceContracts;
using ArrayMinAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ArrayMinAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            var container = new UnityContainer();
            container.RegisterType<IRequestLogDbAccess, RequestLogDbAccess>(new HierarchicalLifetimeManager());
            container.RegisterType<IArrayMinService, ArrayMinService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
