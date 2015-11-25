<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PiDasComparisions.aspx.cs" Inherits="ReportingServices.PiDasComparisions" MasterPageFile="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<%--    <title>DAS与偏差小时均值偏差信息</title>--%>
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
        function showSubGrid(subgrid_id, row_id) {
            //showSubGrid_jqgrid2(subgrid_id, row_id);
            showSubGrid_Jqgrid2(subgrid_id, row_id);
        }
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
        <div style="width:1280px">
            <asp:Label ID="Label1" runat="server" Text="起始日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datetimebox" id="sd" data-options="formatter:ww3,parser:w3" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="结束日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datetimebox" id="ed" data-options="formatter:ww3,parser:w3" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="机组:"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList  id="machine" runat="server"  Width="100">
                <asp:ListItem Text="3号机组" Value="3"></asp:ListItem>
                <asp:ListItem Text="4号机组" Value="4"></asp:ListItem>
                <asp:ListItem Text="5号机组" Value="5"></asp:ListItem>
                <asp:ListItem Text="6号机组" Value="6"></asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="项目:"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="ItemType" runat="server" Visible="true" class="easyui-combobox" Width="90px">
            <asp:ListItem>NOX</asp:ListItem>
            <asp:ListItem>SO2</asp:ListItem>
            <asp:ListItem>DUST</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_rptqry" runat="server" Text="查询" OnClick="btn_rptqry_Click" class="easyui-linkbutton" width="50" Height="25"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--            <asp:Label runat="server" Text="显示:"></asp:Label>&nbsp;
            <asp:CheckBox ID="CheckBox_validvalue" runat="server" Text="有效值" />
            <asp:CheckBox ID="CheckBox_load" runat="server" Text="负荷" />--%>
        </div>
                <br /><br />
    <div>

    <cc1:JQGrid ID="Jqgrid1" runat="server"  Width="1124" Height="500" OnDataRequesting="Jqgrid1_DataRequesting" OnRowEditing="Jqgrid1_RowEditing" ClientIDMode="Static" RenderingMode="Optimized" ScrollToSelectedRow="True">
            <Columns> 
                <cc1:JQGridColumn  DataField="id" TextAlign="Center" HeaderText="id"  Width="160"  PrimaryKey="true" Visible="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="timestamps" TextAlign="Center" HeaderText="时间标签" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Width="180"  Editable="false" DataType="DateTime">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="item" TextAlign="Center" HeaderText="项目" DataType="Int" Width="80" Editable="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="pointid" TextAlign="Center" HeaderText="机组" DataType="Int" Width="80" Editable="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="vdas" TextAlign="Center" HeaderText="DAS小时均值" DataType="Float" Width="130" Editable="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="vpi" TextAlign="Center" HeaderText="PI小时均值" DataType="Float" Width="130" Editable="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="diffstatus" TextAlign="Center" HeaderText="偏差状态" DataType="String" Width="150" Editable="false" >
                </cc1:JQGridColumn>
<%--                <cc1:JQGridColumn  DataField="pointid" TextAlign="Center" HeaderText="机组" Width="50" DataType="String">
                </cc1:JQGridColumn>--%>               
            </Columns>
            <EditDialogSettings CloseAfterEditing="True" />
            <SearchDialogSettings MultipleSearch="True" CloseAfterSearch="True" />
            <PagerSettings PageSize="30" PageSizeOptions="[30,50]" />
            <ToolBarSettings ShowRefreshButton="True" ShowSearchButton="True" ShowEditButton="False" ToolBarPosition="TopAndBottom">              
            </ToolBarSettings>
            <HierarchySettings HierarchyMode="Parent" />
            <ClientSideEvents SubGridRowExpanded="showSubGrid" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>

        <cc1:JQGrid ID="Jqgrid2" runat="server" OnDataRequesting="Jqgrid2_DataRequesting">
            <Columns> 
            <cc1:JQGridColumn  DataField="id" TextAlign="Center" Visible="false" PrimaryKey="true" HeaderText="ID号" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="item" TextAlign="Center" HeaderText="对象" DataType="String" Width="300">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="status" TextAlign="Center" HeaderText="状态" DataType="Int" Width="300">
                </cc1:JQGridColumn>
                </Columns>
            <HierarchySettings HierarchyMode="Child" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>
    </div>
</asp:Content>
