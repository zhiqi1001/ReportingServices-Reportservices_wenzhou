using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using EPASync;

using Microsoft.Reporting.WebForms;


namespace ReportingServices
{
    public partial class ExceptionDataGroupSyncRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((ed.Text == "") && (sd.Text == ""))
                {
                    DateTime enddate = DateTime.Now.Date;
                    ed.Text = enddate.ToString("yyyy-MM-01 00:00:00");
                    sd.Text = enddate.AddMonths(-1).ToString("yyyy-MM-01 00:00:00");
                }

                AppSettingsReader asr = new AppSettingsReader();
                string rpturl = (string)asr.GetValue("reporturl", typeof(string));
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(rpturl);

                List<ReportParameter> rpl = new List<ReportParameter>();
                ReportParameter rpst = new ReportParameter("starttime", sd.Text);
                rpl.Add(rpst);
                ReportParameter rpet = new ReportParameter("endtime", ed.Text);
                rpl.Add(rpet);
                ReportParameter rpcg = new ReportParameter("category", category.SelectedItem.Value);
                rpl.Add(rpcg);
                ReportViewer1.ServerReport.SetParameters(rpl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_checkin_Click(object sender, EventArgs e)
        {
            string sst = (string)Session["st_exceptiondatagroupsync"];
            string set = (string)Session["et_exceptiondatagroupsync"];

            if ((sst == null) || (set == null))
            {
                Session["st_exceptiondatagroupsync"] = sd.Text;
                Session["et_exceptiondatagroupsync"] = ed.Text;
                sst = (string)Session["st_exceptiondatagroupsync"];
                set = (string)Session["et_exceptiondatagroupsync"];
            }

            try
            {
                ComparerEngine ce = new ComparerEngine();
                ce.InitEgls(DateTime.Parse(sst), DateTime.Parse(set), 2);
                ce.InitErmls(DateTime.Parse(sst), DateTime.Parse(set), 2);

                ce.MarkEgls();
                ce.MarkErmls();

                ce.CommitEgls();
                ce.CommitErmls();

                List<ReportParameter> rpl = new List<ReportParameter>();
                ReportParameter rpst = new ReportParameter("starttime", sst);
                rpl.Add(rpst);
                ReportParameter rpet = new ReportParameter("endtime", set);
                rpl.Add(rpet);
                ReportParameter rpcg = new ReportParameter("category", category.SelectedItem.Value);
                rpl.Add(rpcg);
                ReportViewer1.ServerReport.SetParameters(rpl);
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_rptqry_Click(object sender, EventArgs e)
        {
            AppSettingsReader asr = new AppSettingsReader();
            string rpturl = (string)asr.GetValue("reporturl", typeof(string));
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(rpturl);

            Session["st_exceptiondatagroupsync"] = sd.Text;
            Session["et_exceptiondatagroupsync"] = ed.Text;
            string sst = (string)Session["st_exceptiondatagroupsync"];
            string set = (string)Session["et_exceptiondatagroupsync"];

            List<ReportParameter> rpl = new List<ReportParameter>();
            ReportParameter rpst = new ReportParameter("starttime", sst);
            rpl.Add(rpst);
            ReportParameter rpet = new ReportParameter("endtime", set);
            rpl.Add(rpet);
            ReportParameter rpcg = new ReportParameter("category", category.SelectedItem.Value);
            rpl.Add(rpcg);
            ReportViewer1.ServerReport.SetParameters(rpl);
        }
    }
}