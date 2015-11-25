using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.SessionState;

namespace ReportingServices
{
    /// <summary>
    /// LogoutHandler 的摘要说明
    /// </summary>
    public class LogoutHandler : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //string i = context.Session["authority"].ToString();
            context.Session.Clear();
            context.Response.Redirect("logon.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}