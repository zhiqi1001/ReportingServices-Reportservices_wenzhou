using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

//database
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ReportingServices
{
    public partial class PiDasComparisions : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((ed.Text == "") && (sd.Text == ""))
                {
                    DateTime enddate = DateTime.Now.Date.AddDays(-2.0);
                    ed.Text = enddate.ToString("yyyy-MM-dd 00:00:00");
                    sd.Text = enddate.AddDays(-2.0).ToString("yyyy-MM-dd 00:00:00");
                    ItemType.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_rptqry_Click(object sender, EventArgs e)
        {
            Session["sd_PiDasComparisions"] = sd.Text;
            Session["ed_PiDasComparisions"] = ed.Text;
            Session["item_PiDasComparisions"] = ItemType.SelectedItem.Text;
            Session["machine_PiDasComparisions"] = machine.SelectedItem.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid1_DataRequesting(object sender, Trirand.Web.UI.WebControls.JQGridDataRequestEventArgs e)
        {
            string ssd = (string)Session["sd_PiDasComparisions"];
            string sed = (string)Session["ed_PiDasComparisions"];
            string sit = (string)Session["item_PiDasComparisions"];
            string machineid = (string)Session["machine_PiDasComparisions"];
            if ((ssd == null) || (sed == null) || (sit == null) || (machineid == null))
            {
                ssd = sd.Text;
                sed = ed.Text;
                sit = ItemType.SelectedItem.Text;
                machineid = machine.SelectedItem.Value;
            }
            if ((ssd != null) && (sed != null) && (ssd != "") && (sed != ""))
            {
                DataSet ds = null;
                try
                {
                    if (sit == "NOX")
                    {
                        StringBuilder sb = new StringBuilder();
                        //iif(2<1,iif(0=0,'0',iif(1=1,1,2)),iif(0=0,'0',iif(1=1,3,4)))
                        sb.Append("select convert(varchar,timestamps,112)+substring(convert(varchar,timestamps,108),1,2)+'NOX'+convert(varchar,pointid) as id, t.timestamps,'NOX' as item,vnox as vpi,vnox_pi as vdas,pointid,iif(vnox>=vnox_pi,iif(vnox_pi=0,'',iif(abs((vnox-vnox_pi)/vnox_pi)>=0.2,'偏差过大','')),iif(vnox_pi=0,'',iif(abs((vnox-vnox_pi)/vnox_pi)>=0.1,'偏差过大',''))) as diffstatus from V_DAS_PI_HourAverage_Combined3 t where ds='PI' and ");
                        sb.Append("t.timestamps <= '" + sed + "' and ");
                        sb.Append("t.timestamps >= '" + ssd + "' and t.pointid=" + machineid + " order by t.timestamps desc,t.pointid asc");
                        Database db = DatabaseFactory.CreateDatabase("dbconn");
                        System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                        //dbc.CommandTimeout = 100000;
                        ds = db.ExecuteDataSet(dbc);
                    }
                    else if (sit == "SO2")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("select convert(varchar,timestamps,112)+substring(convert(varchar,timestamps,108),1,2)+'SO2'+convert(varchar,pointid) as id,t.timestamps,'SO2' as item,vso2 as vpi,vso2_pi as vdas,pointid,iif(vso2>=vso2_pi,iif(vso2_pi=0,'',iif(abs((vso2-vso2_pi)/vso2_pi)>=0.2,'偏差过大','')),iif(vso2_pi=0,'',iif(abs((vso2-vso2_pi)/vso2_pi)>=0.1,'偏差过大',''))) as diffstatus from V_DAS_PI_HourAverage_Combined3 t where ds='PI' and ");
                        sb.Append("t.timestamps <= '" + sed + "' and ");
                        sb.Append("t.timestamps >= '" + ssd + "' and t.pointid=" + machineid + " order by t.timestamps desc,t.pointid asc");
                        Database db = DatabaseFactory.CreateDatabase("dbconn");
                        System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                        //dbc.CommandTimeout = 100000;
                        ds = db.ExecuteDataSet(dbc);
                    }
                    else if (sit == "DUST")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("select convert(varchar,timestamps,112)+substring(convert(varchar,timestamps,108),1,2)+'DUST'+convert(varchar,pointid) as id, t.timestamps,'DUST' as item,vdust as vpi,vdust_pi as vdas,pointid,iif(vdust>=vdust_pi,iif(vdust_pi=0,'',iif(abs((vdust-vdust_pi)/vdust_pi)>=0.2,'偏差过大','')),iif(vdust_pi=0,'',iif(abs((vdust-vdust_pi)/vdust_pi)>=0.1,'偏差过大',''))) as diffstatus from V_DAS_PI_HourAverage_Combined3 t where ds='PI' and ");
                        sb.Append("t.timestamps <= '" + sed + "' and ");
                        sb.Append("t.timestamps >= '" + ssd + "' and t.pointid=" + machineid + " order by t.timestamps desc,t.pointid asc");
                        Database db = DatabaseFactory.CreateDatabase("dbconn");
                        System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                        //dbc.CommandTimeout = 100000;
                        ds = db.ExecuteDataSet(dbc);
                    }
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
                //Session["gridFilterPageState_exceptioninfo"] = Jqgrid1.GetState();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Jqgrid1_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
           
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
            dt.Columns.Add("item");
            dt.Columns.Add("status");

            DataSet ds = null;
            try
            {
                string sit = (string)Session["item_PiDasComparisions"];

                if ((sit == null) || (sit == ""))
                {
                    sit = "NOX";
                }

                DateTime ts = new DateTime(int.Parse(e.ParentRowKey.Substring(0, 4)), int.Parse(e.ParentRowKey.Substring(4, 2)), int.Parse(e.ParentRowKey.Substring(6, 2)), int.Parse(e.ParentRowKey.Substring(8, 2)), 0, 0);
                if (sit == "NOX")
                {
                    StringBuilder sb = new StringBuilder();
                    //iif(2<1,iif(0=0,'0',iif(1=1,1,2)),iif(0=0,'0',iif(1=1,3,4)))
                    sb.Append("select convert(varchar,timestamps,112)+substring(convert(varchar,timestamps,108),1,2)+'NOX'+convert(varchar,pointid) as id, t.timestamps,'NOX' as item,vnox as vpi,vnox_pi as vdas,pointid,iif(vnox>=vnox_pi,iif(vnox_pi=0,'',iif(abs((vnox-vnox_pi)/vnox_pi)>=0.2,'偏差过大','')),iif(vnox_pi=0,'',iif(abs((vnox-vnox_pi)/vnox_pi)>=0.1,'偏差过大',''))) as diffstatus from V_DAS_PI_HourAverage_Combined3 t where ds='PI' and ");
                    sb.Append("t.timestamps = '" + ts.ToString("yyyy-MM-dd HH:mm:ss") + "' and pointid="+e.ParentRowKey.Substring(e.ParentRowKey.Length-1,1));
                    Database db = DatabaseFactory.CreateDatabase("dbconn");
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    ds = db.ExecuteDataSet(dbc);
                }
                else if (sit == "SO2")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select convert(varchar,timestamps,112)+substring(convert(varchar,timestamps,108),1,2)+'SO2'+convert(varchar,pointid) as id,t.timestamps,'SO2' as item,vso2 as vpi,vso2_pi as vdas,pointid,iif(vso2>=vso2_pi,iif(vso2_pi=0,'',iif(abs((vso2-vso2_pi)/vso2_pi)>=0.2,'偏差过大','')),iif(vso2_pi=0,'',iif(abs((vso2-vso2_pi)/vso2_pi)>=0.1,'偏差过大',''))) as diffstatus from V_DAS_PI_HourAverage_Combined3 t where ds='PI' and ");
                    sb.Append("t.timestamps = '" + ts.ToString("yyyy-MM-dd HH:mm:ss") + "' and pointid=" + e.ParentRowKey.Substring(e.ParentRowKey.Length - 1, 1));
                    Database db = DatabaseFactory.CreateDatabase("dbconn");
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    ds = db.ExecuteDataSet(dbc);
                }
                else if (sit == "DUST")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select convert(varchar,timestamps,112)+substring(convert(varchar,timestamps,108),1,2)+'DUST'+convert(varchar,pointid) as id, t.timestamps,'DUST' as item,vdust as vpi,vdust_pi as vdas,pointid,iif(vdust>=vdust_pi,iif(vdust_pi=0,'',iif(abs((vdust-vdust_pi)/vdust_pi)>=0.2,'偏差过大','')),iif(vdust_pi=0,'',iif(abs((vdust-vdust_pi)/vdust_pi)>=0.1,'偏差过大',''))) as diffstatus from V_DAS_PI_HourAverage_Combined3 t where ds='PI' and ");
                    sb.Append("t.timestamps = '" + ts.ToString("yyyy-MM-dd HH:mm:ss") + "' and pointid=" + e.ParentRowKey.Substring(e.ParentRowKey.Length - 1, 1));
                    Database db = DatabaseFactory.CreateDatabase("dbconn");
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    ds = db.ExecuteDataSet(dbc);
                }
               
                DataRow dr2 = dt.NewRow();
                dr2["id"] = "1";
                dr2["item"] = "DAS";
                dr2["status"] = "未知";
                dt.Rows.Add(dr2);

                if (ds.Tables[0].Rows[0]["diffstatus"].ToString() == "")
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = "2";
                    dr["item"] = "PI";
                    dr["status"] = "正常";
                    dt.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = "3";
                    dr["item"] = "PI";
                    dr["status"] = "通信故障";
                    dt.Rows.Add(dr);
                }

                if (sit == "NOX")
                {
                    StringBuilder sb = new StringBuilder();
                    //iif(2<1,iif(0=0,'0',iif(1=1,1,2)),iif(0=0,'0',iif(1=1,3,4)))
                    sb.Append("select top 1 * from V_RuleResult_StartStop t where ");
                    sb.Append("t.timelog < '" + ts.ToString("yyyy-MM-dd HH:mm:ss") + "' and machineid=" + e.ParentRowKey.Substring(e.ParentRowKey.Length - 1, 1)+" order by t.TimeLog desc");
                    Database db = DatabaseFactory.CreateDatabase("dbconn");
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    ds = db.ExecuteDataSet(dbc);

                    DataRow dr3 = dt.NewRow();
                    dr3["id"] = "3";
                    dr3["item"] = e.ParentRowKey.Substring(e.ParentRowKey.Length - 1, 1)+"号机组";
                    dr3["status"] = ds.Tables[0].Rows.Count>0?ds.Tables[0].Rows[0]["AlarmLog"].ToString():"未知";
                    dt.Rows.Add(dr3);
                }
                else if (sit == "SO2")
                {
                    StringBuilder sb = new StringBuilder();
                    //iif(2<1,iif(0=0,'0',iif(1=1,1,2)),iif(0=0,'0',iif(1=1,3,4)))
                    sb.Append("select top 1 * from V_RuleResult_StartStop_FGD t where ");
                    sb.Append("t.timelog < '" + ts.ToString("yyyy-MM-dd HH:mm:ss") + "' and machineid=" + e.ParentRowKey.Substring(e.ParentRowKey.Length - 1, 1) + " order by t.TimeLog desc");
                    Database db = DatabaseFactory.CreateDatabase("dbconn");
                    System.Data.Common.DbCommand dbc = db.GetSqlStringCommand(sb.ToString());
                    ds = db.ExecuteDataSet(dbc);

                    DataRow dr3 = dt.NewRow();
                    dr3["id"] = "3";
                    dr3["item"] = e.ParentRowKey.Substring(e.ParentRowKey.Length - 1, 1) + "号机组";
                    dr3["status"] = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["AlarmLog"].ToString() : "未知";
                    dt.Rows.Add(dr3);
                }
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                Jqgrid2.DataSource = dt;
                Jqgrid2.DataBind();
            }

        }
    }
}