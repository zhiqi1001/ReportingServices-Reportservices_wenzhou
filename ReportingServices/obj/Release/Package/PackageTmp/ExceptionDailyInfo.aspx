<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionDailyInfo.aspx.cs" Inherits="ReportingServices.ExceptionDailyInfo" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>环保异常日信息</title>
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
    <script type="text/javascript">
        function showSubGrid(subgrid_id, row_id) {
            //showSubGrid_jqgrid2(subgrid_id, row_id);
            showSubGrid_Jqgrid2(subgrid_id, row_id);
        }
        function showSubGrid3(subgrid_id, row_id) {
            //showSubGrid_jqgrid2(subgrid_id, row_id);
            showSubGrid_Jqgrid3(subgrid_id, row_id);
        }
    </script>

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
        </script>
    <form id="form1" runat="server">
        <div style="width:1280px">
            <asp:Label ID="lb_date" runat="server" style="font-family:'Microsoft YaHei';font-size:larger"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="起始日期:" Visible="false"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datebox" id="sd" data-options="formatter:myformatter,parser:myparser" runat="server" Visible="false"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="结束日期:" Visible="false"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datebox" id="ed" data-options="formatter:myformatter,parser:myparser" runat="server" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_rptqry" runat="server" Text="查询" OnClick="btn_rptqry_Click" class="easyui-linkbutton" width="50" Height="25" Visible="false"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<%--            <asp:Label runat="server" Text="显示:"></asp:Label>&nbsp;
            <asp:CheckBox ID="CheckBox_validvalue" runat="server" Text="有效值" />
            <asp:CheckBox ID="CheckBox_load" runat="server" Text="负荷" />--%>
        </div>
                <br /><br />
    <div>
        <cc1:JQGrid ID="Jqgrid1" runat="server"  Width="1124" Height="500" OnDataRequesting="Jqgrid1_DataRequesting" OnRowEditing="Jqgrid1_RowEditing" ClientIDMode="Static" RenderingMode="Optimized" ScrollToSelectedRow="True">
            <Columns>
                <cc1:JQGridColumn  DataField="id" TextAlign="Center" Visible="false" PrimaryKey="true" HeaderText="ID号" DataType="Int">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="timestamps" TextAlign="Center" HeaderText="时间标签" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Width="200" DataType="DateTime">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="pointid" TextAlign="Center" HeaderText="机组" Width="50" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="indicatorname" TextAlign="Center" HeaderText="指标名称" DataType="String">
                </cc1:JQGridColumn>         
                <cc1:JQGridColumn  DataField="indicatorvalue" TextAlign="Center" HeaderText="指标值" DataType="Decimal">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="validvalue" TextAlign="Center" HeaderText="有效值" DataType="Decimal">
                </cc1:JQGridColumn>        
                <cc1:JQGridColumn  DataField="loadvalue" TextAlign="Center" HeaderText="负荷" DataType="Decimal">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="caution" TextAlign="Center" HeaderText="严重程度" Width="80" DataType="String">
                </cc1:JQGridColumn>          
                <cc1:JQGridColumn  DataField="msconfirm" TextAlign="Center" HeaderText="人工确认" Width="80" DataType="String">
                </cc1:JQGridColumn>   
                <cc1:JQGridColumn  DataField="groupname" TextAlign="Center" HeaderText="归属类型" DataType="String" Editable="true"  EditType="DropDown" EditorControlID="GroupType_ddl">
                </cc1:JQGridColumn>               
                <cc1:JQGridColumn  DataField="relatedlogcount" TextAlign="Center" HeaderText="关联记录数" DataType="Int">
                </cc1:JQGridColumn>         
            </Columns>
            <EditDialogSettings CloseAfterEditing="True" />
            <SearchDialogSettings MultipleSearch="True" CloseAfterSearch="True" />
            <PagerSettings PageSize="30" PageSizeOptions="[30,50]" />

            <ToolBarSettings ShowRefreshButton="True" ShowSearchButton="True" ShowEditButton="True" ToolBarPosition="TopAndBottom">
            </ToolBarSettings>

            <HierarchySettings HierarchyMode="Parent" />

            <ClientSideEvents SubGridRowExpanded="showSubGrid" />

<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>
        <cc1:JQGrid ID="Jqgrid2" runat="server" OnDataRequesting="Jqgrid2_DataRequesting" Width="1000px" Height="300px">
            <Columns>
                <cc1:JQGridColumn  DataField="id" TextAlign="Center" Visible="false" PrimaryKey="true" HeaderText="ID号" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="groupname" TextAlign="Center" HeaderText="归属类型" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="rcount" TextAlign="Center" HeaderText="关联记录数" DataType="Int">
                </cc1:JQGridColumn>
            </Columns>
            <HierarchySettings HierarchyMode="ParentAndChild" />
            <ClientSideEvents SubGridRowExpanded="showSubGrid3" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>

        </cc1:JQGrid>
        <cc1:JQGrid ID="Jqgrid3" runat="server" OnDataRequesting="Jqgrid3_DataRequesting" Width="900px">
            <Columns>
                <cc1:JQGridColumn  DataField="id" TextAlign="Center" Visible="false" PrimaryKey="true" HeaderText="ID号" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="Timelog" TextAlign="Center" HeaderText="时间标签" DataType="DateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Width="100">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="alarmlog" TextAlign="Center" HeaderText="异常类型" DataType="String" Width="90">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="alarmdis" TextAlign="Center" HeaderText="异常描述" DataType="String">
                </cc1:JQGridColumn>
            </Columns>
            <HierarchySettings HierarchyMode="Child" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>

        </cc1:JQGrid>

    </div>

        <asp:DropDownList ID="GroupType_ddl" runat="server" Visible="true"></asp:DropDownList>
        <br />
        <asp:Button ID="Export" runat="server" Text="导出Excel"  class="easyui-linkbutton" OnClick="Export_Click"  width="90" Height="25"/>
    </form>
</body>
</html>
