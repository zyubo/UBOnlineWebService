using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace UBOnlineWebApiTest2
{
    //public class WebApiSessionControllerHandler : HttpControllerHandler, IRequiresSessionState
    //{
    //    public WebApiSessionControllerHandler(RouteData routeData) : base(routeData) { }
    //}

    //public class WebApiSessionRouteHandler : HttpControllerRouteHandler
    //{
    //    protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
    //    {
    //        return new WebApiSessionControllerHandler(requestContext.RouteData);
    //    }
    //}

    //public static class HttpRouteExtensions
    //{
    //    public static Route MapHttpRoute(this RouteCollection routes, string name, string routeTemplate, object defaults, IRouteHandler routeHandler)
    //    {
    //        object constraints = null;
    //        HttpMessageHandler handler = null;
    //        var route = routes.MapHttpRoute(name, routeTemplate, defaults, constraints, handler);
    //        if (routeHandler != null)
    //        {
    //            route.RouteHandler = routeHandler;
    //        }
    //        return route;
    //    }
    //}

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Al },
            //    routeHandler: new WebApiSessionRouteHandler()
            //);
            //var route = config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Al }
            //);
            //route.Handler = new WebApiSessionRouteHandler(); 

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
