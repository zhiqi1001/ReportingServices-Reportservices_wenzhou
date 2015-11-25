using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trirand.Web.UI.WebControls;

namespace ReportingServices
{
    public partial class ReportingServices : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //JQTreeNode jqtn = new JQTreeNode();
            //// jqtn.Enabled = true;
            //jqtn.Url = "~/logon.aspx";
            //jqtn.Text = "test";        
            ////JQTreeView1.Nodes.Clear();
            //JQTreeView1.Nodes.Add(jqtn);
        }

        protected void JQTreeView1_NodesRequested(object sender, JQTreeViewNodesRequestedEventArgs e)
        {

        }
    }
}