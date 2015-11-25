using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using Microsoft.Reporting.WebForms;

namespace ReportingServices
{
    /// <summary>
    /// for trend chart
    /// </summary>
    public partial class Reports_client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string st = null, et = null, pn = null, pt =null, mi = null;
                foreach(string k in Request.QueryString.AllKeys)
                {
                    if (k == "starttime")
                    {
                        st = Request.QueryString["starttime"];
                    }
                    else if (k == "endtime")
                    {
                        et = Request.QueryString["endtime"];
                    }
                    else if (k == "pname")
                    {
                        pn = Request.QueryString["pname"];
                    }
                    else if (k == "pointtype")
                    {
                        pt = Request.QueryString["pointtype"];
                    }
                    else if (k == "machineid")
                    {
                        mi = Request.QueryString["machineid"];
                    }
                }
                AppSettingsReader asr = new AppSettingsReader();
                string rpturl = (string)asr.GetValue("reporturl", typeof(string));
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(rpturl);
                if(pt=="nox")
                {
                    ReportViewer1.ServerReport.ReportPath = "/pointtendence";
                }
                else if(pt=="so2")
                {
                    ReportViewer1.ServerReport.ReportPath = "/pointtendence2";
                }
                else if(pt=="dust")
                {
                    ReportViewer1.ServerReport.ReportPath = "/pointtendence3";
                }

                List<ReportParameter> rpl = new List<ReportParameter>();
                ReportParameter rpst = new ReportParameter("starttime",st);
                rpl.Add(rpst);
                ReportParameter rpet = new ReportParameter("endtime",et);
                rpl.Add(rpet);
                ReportParameter rppn = new ReportParameter("pointname",pn);
                rpl.Add(rppn);
                ReportParameter rpmi = new ReportParameter("pointid",mi);
                rpl.Add(rpmi);
                ReportViewer1.ServerReport.SetParameters(rpl);
            }
        }
    }
}