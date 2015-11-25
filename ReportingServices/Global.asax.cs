using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Web.Http;
using System.Web.Routing;

namespace ReportingServices
{
    public class Global : System.Web.HttpApplication
    {
        //public static bool nodeclicked = false;
        protected void Application_Start(object sender, EventArgs e)
        {
            // 配置路由
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Response.Write("<div>会话结束</div>");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}