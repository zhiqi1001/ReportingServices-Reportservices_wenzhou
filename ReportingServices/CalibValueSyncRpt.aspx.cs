using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using Microsoft.Reporting.WebForms;

using EPASync;


namespace ReportingServices
{
    public partial class CalibValueSyncRpt : System.Web.UI.Page
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
            string sst = (string)Session["st_calibvaluesync"];
            string set = (string)Session["et_calibvaluesync"];

            if ((sst == null) || (set == null))
            {
                Session["st_calibvaluesync"] = sd.Text;
                Session["et_calibvaluesync"] = ed.Text;
                sst = (string)Session["st_calibvaluesync"];
                set = (string)Session["et_calibvaluesync"];
            }

            try
            {
                ComparerEngine ce = new ComparerEngine();
                ce.InitCrvls(DateTime.Parse(sst), DateTime.Parse(set), 2);
                ce.InitCrls(DateTime.Parse(sst), DateTime.Parse(set), 2);

                ce.MarkCrvls();
                ce.MarkCrls();

                ce.CommitCrvls();
                ce.CommitCrls();

                List<ReportParameter> rpl = new List<ReportParameter>();
                ReportParameter rpst = new ReportParameter("starttime", sst);
                rpl.Add(rpst);
                ReportParameter rpet = new ReportParameter("endtime", set);
                rpl.Add(rpet);
                ReportParameter rpcg = new ReportParameter("category", category.SelectedItem.Value);
                rpl.Add(rpcg);
                ReportViewer1.ServerReport.SetParameters(rpl);
            }
            catch (Exception ex)
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

            Session["st_calibvaluesync"] = sd.Text;
            Session["et_calibvaluesync"] = ed.Text;
            string sst = (string)Session["st_calibvaluesync"];
            string set = (string)Session["et_calibvaluesync"];

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