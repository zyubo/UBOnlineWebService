using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace UBOnlineWebApiTest2.Controllers
{
    //public class MyHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
    //{
    //    public MyHttpControllerHandler(RouteData routeData)
    //        : base(routeData)
    //    { }
    //}

    //public class MyHttpControllerRouteHandler : HttpControllerRouteHandler
    //{
    //    protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
    //    {
    //        return new MyHttpControllerHandler(requestContext.RouteData);
    //    }
    //}

    public class SessionFacade
    {
        static readonly string _USERNAME = "USERNAME";
        public static string USERNAME
        {
            get
            {
                string res = null;
                if (System.Web.HttpContext.Current.Session[_USERNAME] != null)
                    res = (string)System.Web.HttpContext.Current.Session[_USERNAME];
                return res;
            }
            set
            {
                //if (HttpContext.Current.Session[_USERNAME] == null)
                //{
                //    HttpContext.Current.Session[_USERNAME] = new object();
                //}
                //if (HttpContext.Current.Session == null)
                //    HttpContext.Current.Session = new System.Web.SessionState.HttpSessionState();
                System.Web.HttpContext.Current.Session[_USERNAME] = value;
            }
        }

        static readonly string _CHECKINGACCTNUM = "CHECKINGACCOUNTNUM";
        public static string CHECKINGACCTNUM
        {
            get
            {
                string res = null;
                if (HttpContext.Current.Session[_CHECKINGACCTNUM] != null)
                    res = (string)HttpContext.Current.Session[_CHECKINGACCTNUM];
                return res;
            }
            set
            {
                HttpContext.Current.Session[_CHECKINGACCTNUM] = value;
            }
        }

        static readonly string _PAGEREQUESTED = "PAGEREQUESTED";
        public static string PAGEREQUESTED
        {
            get
            {
                string res = null;
                if (HttpContext.Current.Session[_PAGEREQUESTED] != null)
                    res = (string)HttpContext.Current.Session[_PAGEREQUESTED];
                return res;
            }
            set
            {
                HttpContext.Current.Session[_PAGEREQUESTED] = value;
            }
        }
    }
}