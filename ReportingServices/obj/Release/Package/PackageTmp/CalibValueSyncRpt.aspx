<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalibValueSyncRpt.aspx.cs" Inherits="ReportingServices.CalibValueSyncRpt" MasterPageFile="~/Site1.Master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <div style="text-align:center;font-family:'Microsoft JhengHei'">
        <h2>排 污 达 标 管 理 系 统</h2>
    </div>--%>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <%--<title>分组规则信息</title>--%>
    <link rel="stylesheet" type="text/css" media="screen" href="themes/jquery-ui.css"/>
    <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
    <%--<script src="script/jquery-1.11.1.js" type="text/javascript"></script>--%>
    <script src="js/trirand/i18n/grid.locale-cn.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqDatePicker.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqMultiSelect.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqDropDownList.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/demo/demo.css"/>
    <script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        //function showSubGrid(subgrid_id, row_id) {
        //    //showSubGrid_jqgrid2(subgrid_id, row_id);
        //    showSubGrid_Jqgrid2(subgrid_id, row_id);
        //}
        //function showSubGrid3(subgrid_id, row_id) {
        //    //showSubGrid_jqgrid2(subgrid_id, row_id);
        //    showSubGrid_Jqgrid3(subgrid_id, row_id);
        //}
    </script>

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

        function ww3(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            var h = date.getHours();
            var min = date.getMinutes();
            var sec = date.getSeconds();
            var str = y + '/' + (m < 10 ? ('0' + m) : m) + '/' + (d < 10 ? ('0' + d) : d) + ' ' + (h < 10 ? ('0' + h) : h) + ':' + (min < 10 ? ('0' + min) : min) + ':' + (sec < 10 ? ('0' + sec) : sec);
            return str;
        }
        function w3(s) {
            if (!s) return new Date();
            var y = s.substr(0, 4);
            var m = s.substr(5, 2);
            var d = s.substr(8, 2);
            var h = s.substr(11, 2);
            var min = s.substr(14, 2);
            var sec = s.substr(17, 2);
            if (!isNaN(y) && !isNaN(m) && !isNaN(d) && !isNaN(h) && !isNaN(min) && !isNaN(sec)) {
                return new Date(y, m - 1, d, h, min, sec);
            } else {
                return new Date();
            }
        }
        </script>
    <div>
         <asp:Label ID="Label1" runat="server" Text="起始日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datetimebox" id="sd"  runat="server" data-options="formatter:ww3,parser:w3" Width="180"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;<%--data-options="formatter:myformatter,parser:myparser"--%>
            <asp:Label ID="Label2" runat="server" Text="结束时间:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datetimebox" id="ed" runat="server" data-options="formatter:ww3,parser:w3" Width="180"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%-- data-options="formatter:myformatter,parser:myparser"--%>
        <asp:Label ID="Label3" runat="server" Text="类别:"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList  id="category" runat="server"  Width="100">
                <asp:ListItem Text="不匹配项" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="所有项" Value="2"></asp:ListItem>
<%--                <asp:ListItem Text="3号机组" Value="3"></asp:ListItem>
                <asp:ListItem Text="4号机组" Value="4"></asp:ListItem>--%>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_rptqry" runat="server" Text="查询" OnClick="btn_rptqry_Click" class="easyui-linkbutton" width="50" Height="25"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_checkin" runat="server" Text="上传更新至EPA服务器" OnClick="btn_checkin_Click" class="easyui-linkbutton" width="140" Height="25" Visible="true" OnClientClick="if(confirm('确实要上传更新至EPA服务器?')!=true) return false;"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
        <br /><br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="1209px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1270px" ProcessingMode="Remote">
            <ServerReport ReportPath="/CalibRuleValue_Sync"/>
        </rsweb:ReportViewer>
    </div>
</asp:Content>