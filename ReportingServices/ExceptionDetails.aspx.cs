using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Trirand.Web.UI.WebControls;
using System.Configuration;

using System.Web.Services;
using System.Web.Script.Services;

namespace ReportingServices
{
    /// <summary>
    /// 
    /// </summary>
    public class opermsg
    {
        public int status { get; set; }
        public string msg { get; set; }
    }

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService] 
    public partial class ExceptionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string checkdate = Request.QueryString["checkdate"];
                if (checkdate != null)
                {
                    lb_date.Text = checkdate+" 异常信息";
                    DataSet ds = new DataSet();
                    try
                    {
                        AppSettingsReader asr = new AppSettingsReader();
                        string dbconn = (string)asr.GetValue("dbconn", typeof(string));
                        using (SqlConnection conn = new SqlConnection(dbconn))
                        {
                            conn.Open();
                            SqlCommand sqlcomm = new SqlCommand("select * from EnvirIndicatorValue_abnormal_extended where timestamps>='" + checkdate + "' and timestamps<'" + (new DateTime(int.Parse(checkdate.Split('-')[0]), int.Parse(checkdate.Split('-')[1]), int.Parse(checkdate.Split('-')[2]))).AddDays(1.0).ToString("yyyy-MM-dd") + "' order by timestamps", conn);
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
                //btn_submit.Attributes.Add("onclick ", "return confirm( '确认要修改吗？');");
                //Button1.Attributes.Add("onclick ", "return Confirm( '确认要修改吗?',this);");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void JQGrid2_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                string dbconn = (string)asr.GetValue("dbconn", typeof(string));
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand sqlcomm = new SqlCommand("select * from v_abnormal_NOXSO2_Relevant2 where id2 = '" + e.ParentRowKey.ToString() + "'", conn);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid2_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                string dbconn = (string)asr.GetValue("dbconn", typeof(string));
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand sqlcomm = new SqlCommand("update t_RulelogS set alarmlog = '"+ e.RowData["AlarmLog"] +"', alarmdis = '" + e.RowData["AlarmDis"] + "'  where id = " + e.RowKey.ToString() + "", conn);
                    sqlcomm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            btn_submit.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        [WebMethod(Description = "提交日数据")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public opermsg submit(string date)
        {
            return new opermsg { status = 0, msg = "failed" };
        }
    }
}