using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

 using DevExpress.Web.ASPxTreeView;


namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //private bool nodeclicked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuthority();
                
                //set management flow authority signal
                Session["ManagementFlowAuthorityCtl"] = "0";

                TreeViewNode tvn2 = new TreeViewNode("浙能集团");
                TreeViewNode tvn = new TreeViewNode("温州电厂");

                TreeViewNode tvn_icemsgroup = new TreeViewNode("环保工况信息管理流");
                TreeViewNode tvn_minimum = new TreeViewNode("环保超低排放管理");
                TreeViewNode tvn_fgdscr = new TreeViewNode("脱硫脱硝工况分析");
                TreeViewNode tvn_epasync = new TreeViewNode("EPA数据上传更新");
                TreeViewNode tvn_sourcedata = new TreeViewNode("源数据分析");

                TreeViewNode tvn_overlimits = new TreeViewNode("月超限值明细分析");

                TreeViewNode tvn_reports_instrumentrunning = new TreeViewNode("环保设施运行报表");
                TreeViewNode tvn_reports_inout = new TreeViewNode("环保设施投撤记录表");
                TreeViewNode tvn_reports_abnormalrunning = new TreeViewNode("环保非正常运行记录表");

                tvn_overlimits.Nodes.Add("脱硝月明细", "OverLimits_Nox", null, "~/OverLimits_Nox_Month.aspx");
                tvn_overlimits.Nodes.Add("脱硫月明细", "OverLimits_So2", null, "~/OverLimits_So2_Month.aspx");
                tvn_overlimits.Nodes.Add("除尘月明细", "OverLimits_Dust", null, "~/OverLimits_Dust_Month.aspx");

                tvn_fgdscr.Nodes.Add("脱硝工况分析", "scr_startstop_ab", null, "~/scr_startstop_ab.aspx");
                tvn_fgdscr.Nodes.Add("脱硫工况分析", "machine_startstop", null, "~/machine_startstop.aspx");

                tvn.Nodes.Add("环保数据异常统计", "EnvStatisticYQ", null, "~/Reports2.aspx");
                tvn.Nodes.Add("仪表标定及支撑材料", "EnvCalibSpanYQ", null, "~/CalibSpan.aspx");

                tvn.Nodes.Add(tvn_fgdscr);

                #region not used
                //tvn.Nodes.Add("环保规则值查询", "EnvRuleValueYQ", null, "~/CalibValue.aspx");
                //tvn.Nodes.Add("排放均值数据横向对比", "EnvRuleValueYQ", null, "~/ComprehensiveData.aspx");
                //tvn.Nodes.Add("异常分类及支撑材料", "groupYQ", null, "~/Reports.aspx");
                #endregion

                tvn.Nodes.Add("DAS/PI数据图形对比", "das_pi_chart_YQ", null, "~/daspi_watchdog.aspx");                        
                tvn.Nodes.Add("环保信息管理", "unitcomparisionYQ", null, "~/unitcomparision.aspx");              
                tvn.Nodes.Add("历史数据追溯", "das_hisYQ", null, "~/dashis.aspx");
                

                if ((string)Session["authority"] == "1")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "2")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "3")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "4")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("值长审核", "GroupRuleLogInfo_Total", null, "~/GroupRuleLogInfo_Total.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "5")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("值长审核", "GroupRuleLogInfo_Total", null, "~/GroupRuleLogInfo_Total.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "6")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("值长审核", "GroupRuleLogInfo_Total", null, "~/GroupRuleLogInfo_Total.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "7")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("值长审核", "GroupRuleLogInfo_Total", null, "~/GroupRuleLogInfo_Total.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }
                if ((string)Session["authority"] == "8")
                {
                    tvn_icemsgroup.Nodes.Add("二期集控", "terriority1", null, "~/GroupRuleLogInfo_1.aspx");
                    tvn_icemsgroup.Nodes.Add("三期集控", "terriority2", null, "~/GroupRuleLogInfo_2.aspx");
                    tvn_icemsgroup.Nodes.Add("灰硫控制室", "terriority3", null, "~/GroupRuleLogInfo_3.aspx");
                    tvn_icemsgroup.Nodes.Add("值长审核", "GroupRuleLogInfo_Total", null, "~/GroupRuleLogInfo_Total.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硝运行专工", "fieldinfoYQ_SCR", null, "~/GroupRuleLogInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("脱硫运行专工", "fieldinfoYQ_FGD", null, "~/GroupRuleLogInfo_FGD.aspx");
                    tvn_icemsgroup.Nodes.Add("环保专工(环保排污核查)", "exceptioninfoYQ", null, "~/ExceptionInfo.aspx");
                    tvn_icemsgroup.Nodes.Add("仪控专工(DAS/PI双重校验)", "das_piYQ", null, "~/PiDasComparisions.aspx");
                    tvn_icemsgroup.Nodes.Add("SCR非同步原因分析", "scr_startstop_des", null, "~/scr_startstop_ab_description.aspx");
                    tvn_icemsgroup.Nodes.Add("机组启停原因分析", "machine_startstop_des", null, "~/machine_startstop_ab_description.aspx");
                }

                tvn_minimum.Nodes.Add("超低排放PI指标日数据统计", "minimumYQ_PI", null, "~/MinimumRelease_pi.aspx");
                tvn_minimum.Nodes.Add("超低排放PI指标月数据统计", "minimumYQ_PI_Month", null, "~/MinimumRelease_pi_month.aspx");
                tvn_minimum.Nodes.Add("超低排放DAS指标统计", "minimumYQ", null, "~/MinimumRelease.aspx");

                tvn_reports_instrumentrunning.Nodes.Add("基本情况", "instrumentrunning_basic", null, "~/instrumentrunning_basic.aspx");
                tvn_reports_instrumentrunning.Nodes.Add("脱硝设施", "instrumentrunning_nox", null, "~/instrumentrunning_nox.aspx");
                tvn_reports_instrumentrunning.Nodes.Add("脱硫设施", "instrumentrunning_so2", null, "~/instrumentrunning_so2.aspx");
                tvn_reports_instrumentrunning.Nodes.Add("除尘设施", "instrumentrunning_dust", null, "~/instrumentrunning_dust.aspx");

                tvn_reports_inout.Nodes.Add("月机组启停记录", "machine_startstop_rd", null, "~/machine_startstop_rd_month.aspx");
                tvn_reports_inout.Nodes.Add("月非同步运行记录", "scr_startstop_async", null, "~/scr_startstop_sync_month.aspx");
                tvn_reports_inout.Nodes.Add("机组启停记录", "machine_startstop_rd", null, "~/machine_startstop_rd.aspx");
                tvn_reports_inout.Nodes.Add("非同步运行记录", "scr_startstop_async", null, "~/scr_startstop_sync.aspx");

                tvn_reports_abnormalrunning.Nodes.Add("脱硝非正常运行", "abnormalrunning_nox", null, "~/abnormalrunning_nox.aspx");
                tvn_reports_abnormalrunning.Nodes.Add("脱硫非正常运行", "abnormalrunning_so2", null, "~/abnormalrunning_so2.aspx");
                tvn_reports_abnormalrunning.Nodes.Add("除尘非正常运行", "abnormalrunning_dust", null, "~/abnormalrunning_dust.aspx");

                tvn.Nodes.Add(tvn_minimum);
                tvn.Nodes.Add(tvn_icemsgroup);

                if ((string)Session["authority"] == "6")
                {
                    tvn_epasync.Nodes.Add("异常分组EPA上传更新", "ExceptionDataGroup_Sync", null, "~/ExceptionDataGroupSyncRpt.aspx");
                    tvn_epasync.Nodes.Add("标定均值EPA上传更新", "CalibValue_Sync", null, "~/CalibValueSyncRpt.aspx");
                    tvn.Nodes.Add(tvn_epasync);
                }

                tvn_sourcedata.Nodes.Add("DAS/WEB/PI源数据对比", "MonitorDataCom", null, "~/MonitorDataComparision.aspx");
                tvn_sourcedata.Nodes.Add("分组指标源数据状态", "GroupMonDataStatus", null, "~/GroupMonitorDataStatus.aspx");
                tvn.Nodes.Add(tvn_sourcedata);

                tvn.Nodes.Add(tvn_reports_instrumentrunning);
                tvn.Nodes.Add(tvn_reports_inout);
                tvn.Nodes.Add(tvn_reports_abnormalrunning);
                tvn.Nodes.Add(tvn_overlimits);

                tvn2.Nodes.Add(tvn);
                ASPxTreeView1.Nodes.Add(tvn2);
                
                string currentnodename = (string)Session["CurrentNode"];
                if (currentnodename == null)
                {
                    if ((string)Session["authority"] == "1")
                    {
                        currentnodename = "terriority1";
                    }
                    if ((string)Session["authority"] == "2")
                    {
                        currentnodename = "terriority2";
                    }
                    if ((string)Session["authority"] == "3")
                    {
                        currentnodename = "terriority3";
                    }
                    if ((string)Session["authority"] == "4")
                    {
                        currentnodename = "fieldinfoYQ_SCR";
                    }
                    if ((string)Session["authority"] == "5")
                    {
                        currentnodename = "fieldinfoYQ_FGD";
                    }
                    if ((string)Session["authority"] == "6")
                    {
                        currentnodename = "exceptioninfoYQ";
                    }
                    if ((string)Session["authority"] == "7")
                    {
                        currentnodename = "das_piYQ";
                    }
                    //TreeViewNodeEventArgs tvnea = new TreeViewNodeEventArgs(tvn.Nodes[3]);
                    //ASPxTreeView1_NodeClick(null, tvnea);
                }
                NodesExpand(currentnodename, ASPxTreeView1.Nodes);
                //try
                //{
                //    headtext.InnerText = ASPxTreeView1.SelectedNode.Text;
                //}
                //catch(Exception ex)
                //{ }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        protected void ASPxTreeView1_NodeClick(object s, TreeViewNodeEventArgs e)
        {
            Session["CurrentNode"] = e.Node.Name;
            //breadcrumb.Text = e.Node.Text;
            //NodesExpand(e.Node.Name, ASPxTreeView1.Nodes);
            //ReportingServices.Global.nodeclicked = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="nc"></param>
        protected bool NodesExpand(string nodename, TreeViewNodeCollection nc)
        {
            bool isexist = false;
            foreach (TreeViewNode tvn in nc)
            {
                if (tvn.Name != nodename)
                {
                    if (tvn.Nodes.Count > 0)
                    {
                        isexist = NodesExpand(nodename, tvn.Nodes);
                        if(isexist)
                        {
                            //tvn.Parent.Expanded = true;
                            return true;
                        }
                    }
                }
                else
                {
                    tvn.TreeView.ExpandToNode(tvn);
                    return true;
                }
            }
            return isexist;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void CheckAuthority()
        {
            if (Session["authority"] == null)
            {
                Response.Redirect("logon.aspx");
            }
        }

        protected void ASPxTreeView1_PreRender(object sender, EventArgs e)
        {
            ASPxTreeView1.ExpandToNode(ASPxTreeView1.SelectedNode);
        }
    }
}