<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvExceptionDailyRpt.aspx.cs" Inherits="ReportingServices.EnvExceptionDailyRpt" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EnvExceptionDailyRpt</title>
    <link rel="stylesheet" type="text/css" media="screen" href="themes/jquery-ui.css"/>
    <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
    <script src="script/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="js/trirand/i18n/grid.locale-cn.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqDatePicker.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqMultiSelect.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqDropDownList.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/demo/demo.css"/>
    <script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>
</head>
<body>
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
        function a()
        {           
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
        <cc1:JQGrid ID="Jqgrid1" runat="server" Width="1024" Height="450" OnDataRequesting="Jqgrid1_DataRequesting" AppearanceSettings-ShrinkToFit="true">
            <Columns>
                <cc1:JQGridColumn  DataField="timestamps" TextAlign="Center" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="confirmed" TextAlign="Center" HeaderText="状态">
                </cc1:JQGridColumn>
            </Columns>
            <PagerSettings PageSize="20" />
            <ToolBarSettings ShowRefreshButton="true"/>
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>
    </div>
    </form>
</body>
</html>
