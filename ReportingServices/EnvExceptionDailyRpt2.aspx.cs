using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using System.Data.SqlClient;
using System.Data;

namespace ReportingServices
{
    public partial class EnvExceptionDailyRpt2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_detail.Enabled = false;
                if ((ed.Text == "") && (sd.Text == ""))
                {
                    DateTime enddate = DateTime.Now.Date.AddDays(-2.0);
                    ed.Text = enddate.ToString("yyyy-MM-dd");
                    sd.Text = enddate.AddMonths(-1).ToString("yyyy-MM-dd");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid2_RowSelecting(object sender, Trirand.Web.UI.WebControls.JQGridRowSelectEventArgs e)
        {
            Session["EnvExceptionDailyRpt2_sr"] = ((Trirand.Web.UI.WebControls.JQGrid)sender).SelectedRow;
            btn_detail.Enabled = true;
            //Response.Redirect("ExceptionDetails.aspx?checkdate=" + ((Trirand.Web.UI.WebControls.JQGrid)sender).SelectedRow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_rptqry_Click(object sender, EventArgs e)
        {
            Session["sd_EnvExceptionDailyRpt "] = sd.Text;
            Session["ed_EnvExceptionDailyRpt "] = ed.Text;
            #region
            //if ((sd.Text != "") && (ed.Text != ""))
            //{
            //    DataSet ds = new DataSet();
            //    try
            //    {
            //        using (SqlConnection conn = new SqlConnection("Data Source=MICHAEL-PC2;Initial Catalog=iCEMSDB;Persist Security Info=True;User ID=sa;Password=sa"))
            //        {
            //            conn.Open();
            //            SqlCommand sqlcomm = new SqlCommand("select * from V_EnvException_DayReport where timestamps<='" + ed.Text + "' and timestamps>='" + sd.Text + "' order by timestamps", conn);
            //            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcomm);
            //            sqladapter.Fill(ds);
            //            conn.Close();
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    Jqgrid1.DataSource = ds.Tables[0];
            //    Jqgrid1.DataBind();
            //}
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid2_DataRequesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        {
            string ssd = (string)Session["sd_EnvExceptionDailyRpt "];
            string sed = (string)Session["ed_EnvExceptionDailyRpt "];
            if ((ssd == null) || (sed == null))
            {
                ssd = sd.Text;
                sed = ed.Text;
            }
            if ((ssd != null) && (sed != null)&&(ssd != "") && (sed != ""))
            {
                DataSet ds = new DataSet();
                try
                {
                    AppSettingsReader asr = new AppSettingsReader();
                    string dbconn = (string)asr.GetValue("dbconn", typeof(string));
                    using (SqlConnection conn = new SqlConnection(dbconn))
                    {
                        conn.Open();
                        SqlCommand sqlcomm = new SqlCommand("select * from V_EnvException_DayReport where timestamps<='" + sed + "' and timestamps>='" + ssd + "' order by timestamps desc", conn);
                        SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcomm);
                        sqladapter.Fill(ds);
                        conn.Close();
                    }
                }
                catch (Exception)
                {
                }
                Jqgrid2.DataSource = ds.Tables[0];
                Jqgrid2.DataBind();
            }
        }

        protected void btn_detail_Click(object sender, EventArgs e)
        {
            if (((string)Session["EnvExceptionDailyRpt2_sr"] == "") || ((string)Session["EnvExceptionDailyRpt2_sr"] == null))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$.messager.alert('提示','未选中一行');</script>");
                return;
            }
            string rowid = (string)Session["EnvExceptionDailyRpt2_sr"];
            Session.Remove("EnvExceptionDailyRpt2_sr");
            Response.Redirect("ExceptionDetails2.aspx?checkdate=" + rowid);
        }
    }
}