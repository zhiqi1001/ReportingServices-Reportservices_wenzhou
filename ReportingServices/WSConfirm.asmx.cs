using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Trirand.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Configuration;

using Envir_ExceptionGroup;

namespace ReportingServices
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService] 
    public class WSConfirm : System.Web.Services.WebService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date">所要提交的日数据日期</param>
        [WebMethod(Description = "提交日数据")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public opermsg submit(string datestr)
        {
            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                string dbconn = (string)asr.GetValue("dbconn", typeof(string));
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand sqlcomm = new SqlCommand("insert into Exception_DayConfirm(timestamps,confirmed) values('" + datestr + "',1)", conn);
                    sqlcomm.ExecuteNonQuery();
                    conn.Close();
                }
                return new opermsg { status = 1, msg = "该日数据已提交" };
            }
            catch (Exception ex)
            {
                return new opermsg { status = 0, msg = ex.Message };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datestr"></param>
        /// <returns></returns>
        [WebMethod(Description = "查看提交状态")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int checkdaysubmitstatus(string datestr)
        {
            DataSet ds = new DataSet();
            try
            {
                int count;
                AppSettingsReader asr = new AppSettingsReader();
                string dbconn = (string)asr.GetValue("dbconn", typeof(string));
                using (SqlConnection conn = new SqlConnection(dbconn))
                {
                    conn.Open();
                    SqlCommand sqlcomm = new SqlCommand("select count(*) from Exception_DayConfirm where timestamps='" + datestr + "'", conn);
                    count = (int)sqlcomm.ExecuteScalar();
                    conn.Close();
                }
                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <param name="et"></param>
        /// <returns></returns>
        [WebMethod(Description = "小时均值分组操作")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int houravggroup(DateTime st, DateTime et)
        {
            return (new Envir_ExceptionGroup.Common()).houravggroup(st, et);
        }

    }
}
