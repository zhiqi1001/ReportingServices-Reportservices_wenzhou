<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvExceptionDailyRpt2.aspx.cs" Inherits="ReportingServices.EnvExceptionDailyRpt2" MasterPageFile="~/ReportingServices.Master"%>
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:content runat="server" ID="content2" ContentPlaceHolderID="pagecontent">
        <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
        <script src="js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>
        <script src="js/trirand/i18n/grid.locale-cn.js" type="text/javascript"></script>
         <script type="text/javascript">
             function myformatter(date) {
                 var y = date.getFullYear();
                 var m = date.getMonth() + 1;
                 var d = date.getDate();
                 return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
             }
             function myparser(s) {
                 if (!s) return new Date();
                 var ss = (s.split('-'));
                 var y = parseInt(ss[0], 10);
                 var m = parseInt(ss[1], 10);
                 var d = parseInt(ss[2], 10);
                 if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                     return new Date(y, m - 1, d);
                 } else {
                     return new Date();
                 }
             }
             function a() {
             }
</script>
    <form id="form1" runat="server">
        <div style="width:1280px">
            <asp:Label ID="Label1" runat="server" Text="起始日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datebox" id="sd" data-options="formatter:myformatter,parser:myparser" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="结束日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datebox" id="ed" data-options="formatter:myformatter,parser:myparser" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_rptqry" runat="server" Text="查询" OnClick="btn_rptqry_Click" class="easyui-linkbutton" width="50" Height="25"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_detail" runat="server" Text="查看详情" OnClick="btn_detail_Click" class="easyui-linkbutton" width="80" Height="25"/>
        </div>
        <br /><br />
    <div>
        <!--report for each day checking status-->
        <cc1:JQGrid ID="Jqgrid2" runat="server" Width="1024" Height="450" OnDataRequesting="Jqgrid2_DataRequesting" AppearanceSettings-ShrinkToFit="true" OnRowSelecting="Jqgrid2_RowSelecting">
            <Columns>
                <cc1:JQGridColumn  DataField="timestamps" TextAlign="Center" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="confirmed" TextAlign="Center" HeaderText="状态" DataType="String">
                </cc1:JQGridColumn>
            </Columns>
            <PagerSettings PageSize="20" />
            <ToolBarSettings ShowRefreshButton="true" ShowSearchButton="true"/>
        <PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>
    </div>
    </form>
</asp:content>

