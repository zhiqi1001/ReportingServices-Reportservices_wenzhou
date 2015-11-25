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
    public partial class EnvExceptionDailyRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        protected void Jqgrid1_RowSelecting(object sender, Trirand.Web.UI.WebControls.JQGridRowSelectEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_rptqry_Click(object sender, EventArgs e)
        {
            Session["sd_EnvExceptionDailyRpt"] = sd.Text;
            Session["ed_EnvExceptionDailyRpt"] = ed.Text;
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
        protected void Jqgrid1_DataRequesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        {
            string ssd = (string)Session["sd_EnvExceptionDailyRpt"];
            string sed = (string)Session["ed_EnvExceptionDailyRpt"];
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
                Jqgrid1.DataSource = ds.Tables[0];
                Jqgrid1.DataBind();
            }
        }

        protected void btn_detail_Click(object sender, EventArgs e)
        {
            if(Jqgrid1.SelectedRow == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$.messager.alert('提示','未选中一行');</script>");
                return;
            }
            Response.Redirect("ExceptionDailyInfo.aspx?checkdate=" + Jqgrid1.SelectedRow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //string temp = Jqgrid1.Row;
        }
    }
}