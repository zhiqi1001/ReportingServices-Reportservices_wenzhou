using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportingServices
{
    public partial class logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void logon_btn_Click(object sender, EventArgs e)
        {
            if (user_ddl.SelectedItem.Value == "1")
            {
                if (psw.Text == "1001")
                {
                    Session["authority"] = "1";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/GroupRuleLogInfo_1.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (user_ddl.SelectedItem.Value == "2")
            {
                if (psw.Text == "2002")
                {
                    Session["authority"] = "2";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/GroupRuleLogInfo_2.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (user_ddl.SelectedItem.Value == "3")
            {
                if (psw.Text == "3003")
                {
                    Session["authority"] = "3";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/GroupRuleLogInfo_3.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (user_ddl.SelectedItem.Value == "4")
            {
                if (psw.Text == "4004")
                {
                    Session["authority"] = "4";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/GroupRuleLogInfo.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (user_ddl.SelectedItem.Value == "5")
            {
                if (psw.Text == "4114")
                {
                    Session["authority"] = "5";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/GroupRuleLogInfo_FGD.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (user_ddl.SelectedItem.Value == "6")
            {
                if (psw.Text == "6006")
                {
                    Session["authority"] = "6";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/ExceptionInfo.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (user_ddl.SelectedItem.Value == "7")
            {
                if (psw.Text == "7007")
                {
                    Session["authority"] = "7";
                    //Server.Transfer("~/pidascomparisions.aspx");
                    Response.Redirect("~/PiDasComparisions.aspx");
                }
                else
                {
                    msg.Text = "密码不正确";
                    msg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

    }
}