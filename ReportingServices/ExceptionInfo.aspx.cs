using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

using System.Configuration;

//database
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ReportingServices
{
    public partial class ExceptionInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((ed.Text == "") && (sd.Text == ""))
                {
                    //DateTime enddate = DateTime.Now.Date.AddDays(-2.0);
                    DateTime enddate = DateTime.Now.Date;
                    ed.Text = enddate.ToString("yyyy-MM-01 00:00:00");
                    sd.Text = enddate.AddMonths(-1).ToString("yyyy-MM-01 00:00:00");
                }
                GroupType_ddl.Items.Clear();
                GroupType_ddl.Items.Add(new ListItem("SCR启停", "1"));
                GroupType_ddl.Items.Add(new ListItem("特殊工况", "2"));
                GroupType_ddl.Items.Add(new ListItem("仪表标定", "3"));
                GroupType_ddl.Items.Add(new ListItem("机组启停", "15"));
            }
        }

        protected void btn_rptqry_Click(object sender, EventArgs e)
        {
            Session["sd_ExceptionInfo"] = sd.Text;
            Session["ed_ExceptionInfo"] = ed.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid1_DataRequesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        {
            string ssd = (string)Session["sd_ExceptionInfo"];
            string sed = (string)Session["ed_ExceptionInfo"];
            if ((ssd == null) || (sed == null))
            {
                ssd = sd.Text;
                sed = ed.Text;
            }
            if ((ssd != null) && (sed != null) && (ssd != "") && (sed != ""))
            {
                DataSet ds;
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select t.*,iif(t.lockedstatus=0,'未锁定','锁定') as lockedstatustext from V_abnormal_valid_load t where ");
                    sb.Append("t.timestamps <= '" + sed + "' and ");
                    sb.Append("t.timestamps >= '" + ssd + "' order by t.timestamps,t.pointid");
                    Database db = DatabaseFactory.CreateDatabase("dbconn");
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    ds = db.ExecuteDataSet(dbc);
                }
                catch (Exception ex)
                {
                    ds = null;
                }
                #region
                //if (!CheckBox_validvalue.Checked)
                //{
                //    Jqgrid1.Columns[5].Width = 0;
                //}
                //if (!CheckBox_load.Checked)
                //{
                //    Jqgrid1.Columns[6].Visible = false;
                //}
                #endregion
                Jqgrid1.DataSource = ds.Tables[0];
                Jqgrid1.DataBind();
                Session["gridFilterPageState_exceptioninfo"] = Jqgrid1.GetState();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid1_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            try
            {
                //modified 2015/04/23
                string lockedstatus = e.RowData["lockedstatustext"];
                

                string typeid = e.RowData["groupname"];
                StringBuilder sb = new StringBuilder();
                sb.Append("select count(*) from exceptiondata_group t where t.envir_id = " + e.RowKey);
                Database db = DatabaseFactory.CreateDatabase("dbconn");
                System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                int rcount = (int)db.ExecuteScalar(dbc);

                //modified 20150917
                string typecontent = e.RowData["typecontent"];
                if (typecontent == null)
                {
                    typecontent = "";
                }

                if (rcount > 0)
                {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("update exceptiondata_group set typeid = " + typeid + ", typecontent='" + typecontent + "', locked=" + lockedstatus + ", mconfirm = 0 where envir_id = " + e.RowKey);
                    System.Data.Common.DbCommand dbc2 = db.GetSqlStringCommand(sb2.ToString());
                    db.ExecuteNonQuery(dbc2);
                }
                else
                {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("insert into exceptiondata_group(envir_id,typeid,typecontent,mconfirm,locked) values(");
                    sb2.Append(e.RowKey);
                    sb2.Append(",");
                    sb2.Append(typeid);
                    sb2.Append(",'");
                    sb2.Append(typecontent);
                    sb2.Append("',0," + lockedstatus + ")");
                    System.Data.Common.DbCommand dbc2 = db.GetSqlStringCommand(sb2.ToString());
                    db.ExecuteNonQuery(dbc2);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid2_DataRequesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("groupname");
            dt.Columns.Add("rcount");
            try
            {
                Database db = DatabaseFactory.CreateDatabase("dbconn");
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= 16; i++)
                {
                    string groupname = GetTypeNameById(i);
                    sb.Clear();
                    sb.Append("select count(*) from envirexception_rulelog_match t where t.isshowed = 1 and t.envir_id = ");
                    sb.Append(e.ParentRowKey + " and t.typeid = ");
                    sb.Append(i.ToString());
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    int count = (int)db.ExecuteScalar(dbc);
                    if (count > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["id"] = e.ParentRowKey + "_" + i.ToString();
                        dr["groupname"] = groupname;
                        dr["rcount"] = count;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch(Exception ex)
            {
                dt = null;
            }
            finally
            {
                Jqgrid2.DataSource = dt;
                Jqgrid2.DataBind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid3_DataRequesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        {
            DataSet ds = null;
            try
            {
                long envirid = long.Parse(e.ParentRowKey.Split('_')[0]);
                int typeid = int.Parse(e.ParentRowKey.Split('_')[1]);
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from V_Exception_Rulelog_Type t where ");
                sb.Append("t.envir_id = " + envirid + " and ");
                sb.Append("t.typeid = " + typeid + " and t.isshowed = 1");
                Database db = DatabaseFactory.CreateDatabase("dbconn");
                System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                ds = db.ExecuteDataSet(dbc);
            }
            catch(Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (ds != null)
                {
                    Jqgrid3.DataSource = ds.Tables[0];
                    Jqgrid3.DataBind();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetTypeNameById(int id)
        {
            if (id == 1)
            {
                return "SCR启停";
            }
            else if (id == 2)
            {
                return "特殊工况";
            }
            else if (id == 3)
            {
                return "仪表标定";
            }
            else if(id == 999)
            {
                return "无关联记录";
            }
            else if(id == 15)
            {
                return "机组启停";
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Export_Click(object sender, EventArgs e)
        {
            Trirand.Web.UI.WebControls.JQGridState gridState = Session["gridFilterPageState_exceptioninfo"] as Trirand.Web.UI.WebControls.JQGridState;
            Jqgrid1.ExportSettings.ExportDataRange = Trirand.Web.UI.WebControls.ExportDataRange.Filtered;
            Jqgrid1.ExportToExcel("export.xls", gridState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChartDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Jqgrid1.SelectedRow))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$.messager.alert('提示','未选中一行日志明细');</script>");
                return;
            }

            //DateTime timestamps;
            //starttime,endtime,pointname,pointtype,machineid
            string st = null, et = null, pn = null, pt = null, mi = null;
            try
            {
                DataSet ds;
                StringBuilder sb = new StringBuilder();
                sb.Append("select timestamps,indicatorid,pointid from V_EnvirIndicatorValue_abnormal t where ");
                sb.Append("t.id = " + Jqgrid1.SelectedRow);
                Database db = DatabaseFactory.CreateDatabase("dbconn");
                System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                //timestamps = DateTime.Parse(db.ExecuteScalar(dbc).ToString());
                ds = db.ExecuteDataSet(dbc);
                st = DateTime.Parse(ds.Tables[0].Rows[0]["timestamps"].ToString()).AddHours(-3).ToString("yyyy-MM-dd HH:mm:ss");
                et = DateTime.Parse(ds.Tables[0].Rows[0]["timestamps"].ToString()).AddHours(3).ToString("yyyy-MM-dd HH:mm:ss");
                pn = "aaa";
                mi = ds.Tables[0].Rows[0]["pointid"].ToString();
                if (ds.Tables[0].Rows[0]["indicatorid"].ToString() == "3")
                {
                    pt = "nox";
                }
                else if (ds.Tables[0].Rows[0]["indicatorid"].ToString() == "1")
                {
                    pt = "so2";
                }
                else if (ds.Tables[0].Rows[0]["indicatorid"].ToString() == "2")
                {
                    pt = "dust";
                }
            }
            catch(Exception ex)
            {
                return;
            }
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "detail chart", "window.open('http://10.150.124.140:8088?xyz=iahbhy&tagtypeid=3&TimeFrom=" + timestamps.AddHours(-3.0).ToString("yyyy/MM/dd HH:mm:ss") + "&TimeTo=" + timestamps.AddHours(3.0).ToString("yyyy/MM/dd HH:mm:ss") + "')", true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "detail chart", "window.open('reports_client.aspx?pname=" + pn + "&pointtype=" + pt + "&machineid=" + mi + "&starttime=" + st + "&endtime=" + et + "')", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChartDetail_Click2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Jqgrid1.SelectedRow))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>$.messager.alert('提示','未选中一行日志明细');</script>");
                return;
            }

            //DateTime timestamps;          
            //starttime,endtime,pointname,pointtype,machineid
            string st = null, et = null, pn = null, pt = null, mi = null;
            try
            {
                DataSet ds;
                StringBuilder sb = new StringBuilder();
                sb.Append("select timestamps,indicatorid,pointid from V_EnvirIndicatorValue_abnormal t where ");
                sb.Append("t.id = " + Jqgrid1.SelectedRow);
                Database db = DatabaseFactory.CreateDatabase("dbconn");
                System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                //timestamps = DateTime.Parse(db.ExecuteScalar(dbc).ToString());
                ds = db.ExecuteDataSet(dbc);
                st = DateTime.Parse(ds.Tables[0].Rows[0]["timestamps"].ToString()).AddHours(-3).ToString("yyyy-MM-dd HH:mm:ss");
                et = DateTime.Parse(ds.Tables[0].Rows[0]["timestamps"].ToString()).AddHours(3).ToString("yyyy-MM-dd HH:mm:ss");
                //pn = ds.Tables[0].Rows[0]["rulename"].ToString();
                mi = ds.Tables[0].Rows[0]["pointid"].ToString();
                //if (ds.Tables[0].Rows[0]["cemstype"].ToString() == "SCR")
                //{
                //    pt = "nox";
                //}
                //else if (ds.Tables[0].Rows[0]["cemstype"].ToString() == "FGD")
                //{
                //    pt = "so2";
                //}
                //else if (ds.Tables[0].Rows[0]["cemstype"].ToString() == "DUST")
                //{
                //    pt = "dust";
                //}
            }
            catch (Exception ex)
            {
                return;
            }

            string ttid = "";
            if (mi == "1")
            {
                ttid = "3";
            }
            else if (mi == "2")
            {
                ttid = "22";
            }
            else if (mi == "3")
            {
                ttid = "23";
            }
            else if (mi == "4")
            {
                ttid = "24";
            }

            AppSettingsReader asr = new System.Configuration.AppSettingsReader();

            string highchartpath = "";
            try
            {
                highchartpath = ((string)asr.GetValue("HighChartPath", typeof(string)));
            }
            catch (Exception ex)
            {

            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "detail chart", "window.open('" + highchartpath + "?xyz=iahbhy&tagtypeid=" + ttid + "&TimeFrom=" + st + "&TimeTo=" + et + "')", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "detail chart", "window.open('reports_client.aspx?pname=" + pn + "&pointtype=" + pt + "&machineid=" + mi + "&starttime=" + st + "&endtime=" + et + "')", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_group_Click(object sender, EventArgs e)
        {
            
            WSConfirm ws = new WSConfirm();
            ws.houravggroup(DateTime.Parse(sd.Text), DateTime.Parse(ed.Text));
            btn_rptqry_Click(null, null);
        }

    }
}