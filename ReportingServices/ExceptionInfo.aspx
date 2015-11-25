<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionInfo.aspx.cs" Inherits="ReportingServices.ExceptionInfo" MasterPageFile="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<div>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <%--<title>环保数据异常信息</title>--%>
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
        function showSubGrid3(subgrid_id, row_id) {
            //showSubGrid_jqgrid2(subgrid_id, row_id);
            showSubGrid_Jqgrid3(subgrid_id, row_id);
        }
    </script>

    <script type="text/javascript">

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

        function chartdetails() {
            var griditems = jQuery("[aria-selected=true]");
            var logid;
            griditems.each(function (index) {
                if (this.id.split("_").length == 3) {
                    logid = this.id.split("_")[1];
                }
            }
            );
            if (logid)
                alert("Selected row primary key is: " + logid);
            else
                alert("未选中日志明细");
        }
    </script>
        <div style="width:auto">
            <asp:Label ID="Label1" runat="server" Text="起始日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datetimebox" id="sd" data-options="formatter:ww3,parser:w3" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="结束日期:"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox class="easyui-datetimebox" id="ed" data-options="formatter:ww3,parser:w3" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_rptqry" runat="server" Text="查询" OnClick="btn_rptqry_Click" class="easyui-linkbutton" width="50" Height="25"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btn_group" runat="server" Text="异常分组" OnClick="btn_group_Click" class="easyui-linkbutton" width="85" Height="25" OnClientClick="if(confirm('确实要重新分组?')!=true) return false;"/>
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
                <cc1:JQGridColumn  DataField="validvalue" TextAlign="Center" HeaderText="有效值" DataType="Decimal" Visible="false">
                </cc1:JQGridColumn>        
                <cc1:JQGridColumn  DataField="loadvalue" TextAlign="Center" HeaderText="负荷" DataType="Decimal">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="caution" TextAlign="Center" HeaderText="严重程度" Width="80" DataType="String" Visible="false">
                </cc1:JQGridColumn>          
               <cc1:JQGridColumn  DataField="msconfirm" TextAlign="Center" HeaderText="人工确认" Width="80" DataType="String" Visible="false">
                </cc1:JQGridColumn>  
                <cc1:JQGridColumn  DataField="groupname" TextAlign="Center" HeaderText="归属类型" Width="100" DataType="String" Editable="true"  EditType="DropDown" EditorControlID="GroupType_ddl">
                </cc1:JQGridColumn>               
                <cc1:JQGridColumn  DataField="relatedlogcount" TextAlign="Center" HeaderText="关联记录数" Width="100" DataType="Int">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="lockedstatustext" TextAlign="Center" HeaderText="锁定状态" Width="100" DataType="String"  EditType="DropDown" EditorControlID="LockStatus_ddl" Editable="true">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="typecontent" TextAlign="Center" HeaderText="原因分析" Width="120" DataType="String"  EditType="TextArea" Editable="true">
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
        <cc1:JQGrid ID="Jqgrid2" runat="server" OnDataRequesting="Jqgrid2_DataRequesting" Width="1000px" Height="300px" ClientIDMode="Static">
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
        <cc1:JQGrid ID="Jqgrid3" runat="server" OnDataRequesting="Jqgrid3_DataRequesting" Width="900px" ClientIDMode="Static">
            <Columns>
                <cc1:JQGridColumn  DataField="id" TextAlign="Center" Visible="true" PrimaryKey="true" HeaderText="ID号" DataType="String">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="Timelog" TextAlign="Center" HeaderText="时间标签" DataType="DateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Width="100">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="alarmlog" TextAlign="Center" HeaderText="异常类型" DataType="String" Width="90">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn  DataField="alarmdis" TextAlign="Center" HeaderText="异常描述" DataType="String">
                </cc1:JQGridColumn>
            </Columns>
            <ToolBarSettings ShowRefreshButton="True">
                
            </ToolBarSettings>
            <HierarchySettings HierarchyMode="Child" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>

        </cc1:JQGrid>
    </div>
        <asp:DropDownList ID="GroupType_ddl" runat="server" Visible="true"></asp:DropDownList>
    <asp:DropDownList ID="LockStatus_ddl" runat="server" Visible="true">
        <asp:ListItem Value="0" Text="未锁定"></asp:ListItem>
        <asp:ListItem Value="1" Text="锁定"></asp:ListItem>
    </asp:DropDownList>
        <br />
        <asp:Button ID="Export" runat="server" Text="导出Excel"  class="easyui-linkbutton" OnClick="Export_Click"  width="90" Height="25"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ChartDetail" runat="server" Text="查看历史曲线"  class="easyui-linkbutton" width="90" Height="25" OnClick="ChartDetail_Click" Visible="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ChartDetail2" runat="server" Text="HighChart曲线"  class="easyui-linkbutton" width="90" Height="25" OnClick="ChartDetail_Click2" Visible="true" />
        <%--<input id="ChartDetail2" type="button" value="历史曲线" class="easyui-linkbutton" onclick="chartdetails()" style="width:90px;height:25px" visible="false"/>--%>
    </div>
</asp:Content>

