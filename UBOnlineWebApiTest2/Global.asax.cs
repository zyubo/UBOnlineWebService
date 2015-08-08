using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace UBOnlineWebApiTest2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public static class Global
    {
        public static List<string> USERSIN = new List<string>();
    }

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("json", "true", "application/json")); // later added
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //HttpContext.Application["USERNAME"] = new object();
            Global.USERSIN.Add("user2");
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += WebApiApplication_PostAuthenticateRequest;
            base.Init();
        }

        void WebApiApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(
                SessionStateBehavior.Required);
        }
    }
}