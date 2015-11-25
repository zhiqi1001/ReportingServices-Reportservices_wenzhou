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
    public partial class OverLimits_So2_Month : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppSettingsReader asr = new AppSettingsReader();
                string rpturl = (string)asr.GetValue("reporturl", typeof(string));
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(rpturl);
                //ReportParameter rp = new ReportParameter();
                //ReportViewer1.ServerReport.SetParameters()
                //ReportViewer1.ServerReport.SetParameters()
            }
        }
    }
}