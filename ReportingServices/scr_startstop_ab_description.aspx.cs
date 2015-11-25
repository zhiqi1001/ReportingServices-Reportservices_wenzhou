using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.RulelogS;
using Wuqi.Webdiyer;

namespace ReportingServices
{
    public partial class scr_startstop_ab_description : System.Web.UI.Page
    {
        public string startTime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01");
        public string endTime = DateTime.Now.ToString("yyyy-MM-01");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(hidStart.Value)) {
                startTime = DateTime.Parse(hidStart.Value).ToString("yyyy-MM-dd");
            }
            if (!String.IsNullOrEmpty(hidEnd.Value))
            {
                endTime = DateTime.Parse(hidEnd.Value).ToString("yyyy-MM-dd");
            }

            if (!IsPostBack) {
                dataBind(1,10,startTime,endTime);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public void dataBind(int pageIndex = 1, int pageSize = 10,string startTime=null,string endTime=null)
        {
            PetaPoco.Sql sql = new PetaPoco.Sql();
            sql.Select("m.[description] as name,a.*").From("t_AsyncSCR_rd a");
            sql.LeftJoin("Point_Machine_Map m").On("m.pointname=a.pointname");
            if (!String.IsNullOrEmpty(startTime)) {
                sql.Where("a.starttime>@0", startTime);
            }
            if (!String.IsNullOrEmpty(endTime))
            {
                sql.Where("a.starttime<@0", endTime);
            }
            List<int> machineids = new List<int>();
            for (int i = 0; i < chkboxlist.Items.Count; i++) {
                if (chkboxlist.Items[i].Selected) {
                    machineids.Add(int.Parse(chkboxlist.Items[i].Value));
                }
            }
            if (machineids.Count > 1)
                sql.Where("m.machineid in (@0)", machineids);
            else if (machineids.Count == 1)
                sql.Where("m.machineid=@0", machineids[0]);

            sql.OrderBy("a.starttime desc");

            var db = new PetaPoco.Database("dbconn");
            PetaPoco.Page<BootRecordSelect> pageitems = db.Page<BootRecordSelect>(pageIndex, pageSize, sql);
            rpt_RulelogS_Des.DataSource = pageitems.Items;
            rpt_RulelogS_Des.DataBind();
            AspNetPager1.RecordCount = (int)pageitems.TotalItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            //e.NewPageIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            dataBind(AspNetPager1.CurrentPageIndex, 10, startTime, endTime);
        }

        protected void btn_query_Click(object sender, EventArgs e)
        {
            dataBind(AspNetPager1.CurrentPageIndex, 10, startTime, endTime);
        }
    }
}