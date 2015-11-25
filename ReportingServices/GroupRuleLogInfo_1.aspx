<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupRuleLogInfo_1.aspx.cs" Inherits="ReportingServices.GroupRuleLogInfo_1" MasterPageFile="~/Site1.Master" %>

<%@ Register Src="~/head1.ascx" TagName="head" TagPrefix="site" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <site:head runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<title>分组规则信息</title>--%>
    <link rel="stylesheet" type="text/css" media="screen" href="themes/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
    <%--<script src="script/jquery-1.11.1.js" type="text/javascript"></script>--%>
    <script src="js/trirand/i18n/grid.locale-cn.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqDatePicker.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqMultiSelect.min.js" type="text/javascript"></script>
    <script src="js/trirand/jquery.jqDropDownList.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="easyui/demo/demo.css" />
    <script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/comm.css" />
    <script type="text/javascript" src="script/jquery.autocomplete.min.js"></script>
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
    <script type="text/javascript">
        function refreshclick() {
            //setTimeout(null, 3000);
            if ($("#autorefresh")[0].checked) {
                var l = setInterval('$("#refresh_Jqgrid1_top").click()', 60000); //300000
                $("#timerinside")[0].value = l;
            }
            else {
                clearInterval($("#timerinside")[0].value);
            }
        }
        //$.ready(refreshclick());
            </script>
    <div style="width: 1280px">
        <asp:Label ID="Label1" runat="server" Text="起始日期:"></asp:Label>&nbsp;&nbsp;
           
        <asp:TextBox class="easyui-datetimebox" ID="sd" runat="server" data-options="formatter:ww3,parser:w3" Width="180"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;<%--data-options="formatter:myformatter,parser:myparser"--%>
        <asp:Label ID="Label2" runat="server" Text="结束时间:"></asp:Label>&nbsp;&nbsp;
           
        <asp:TextBox class="easyui-datetimebox" ID="ed" runat="server" data-options="formatter:ww3,parser:w3" Width="180"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%-- data-options="formatter:myformatter,parser:myparser"--%>
        <asp:Label ID="Label3" runat="server" Text="机组:"></asp:Label>&nbsp;&nbsp;
           
        <asp:DropDownList ID="machine" runat="server" Width="100">
            <asp:ListItem Text="3号机组" Value="3"></asp:ListItem>
            <asp:ListItem Text="4号机组" Value="4"></asp:ListItem>
            <asp:ListItem Text="5号机组" Value="5"></asp:ListItem>
            <asp:ListItem Text="6号机组" Value="6"></asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
        <asp:Button ID="btn_rptqry" runat="server" Text="查询" OnClick="btn_rptqry_Click" class="easyui-linkbutton" Width="50" Height="25" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
        <asp:Button ID="btn_validate" runat="server" Text="批量确认" OnClick="btn_validate_Click" class="easyui-linkbutton" Width="80" Height="25" Visible="true" OnClientClick="if(confirm('确实要批量确认?')!=true) return false;" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
        <asp:Label ID="Label4" runat="server" Text="自动刷新:"></asp:Label>
        <input id="autorefresh" type="checkbox" onchange="refreshclick()" checked="checked" />
        <%--            <asp:Label runat="server" Text="显示:"></asp:Label>&nbsp;
            <asp:CheckBox ID="CheckBox_validvalue" runat="server" Text="有效值" />
            <asp:CheckBox ID="CheckBox_load" runat="server" Text="负荷" />--%>
    </div>
    <br />
    <br />
    <div>
        <cc1:JQGrid ID="Jqgrid1" runat="server" Width="1124" Height="500" OnDataRequesting="Jqgrid1_DataRequesting" OnRowEditing="Jqgrid1_RowEditing" ClientIDMode="Static" RenderingMode="Optimized" ScrollToSelectedRow="True" OnCellBinding="Jqgrid1_CellBinding" OnRowAdding="Jqgrid1_RowAdding" OnRowDeleting="Jqgrid1_RowDeleting">
            <Columns>
                <cc1:JQGridColumn DataField="id" TextAlign="Center" Visible="false" PrimaryKey="true" HeaderText="ID号" DataType="Int">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn TextAlign="Center" HeaderText="" DataType="String" Width="20" Editable="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="rulename" TextAlign="Center" HeaderText="点名" DataType="String" Width="160" Editable="true" EditType="DropDown" EditorControlID="PointsDownList">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="machineid" TextAlign="Center" HeaderText="机组" DataType="Int" Width="30" Editable="false" EditType="DropDown" EditorControlID="Machine_ddl">
                    <%-- EditorControlID="Machine_ddl"--%>
                </cc1:JQGridColumn>
                <%--<cc1:JQGridColumn DataField="alarmlog" TextAlign="Center" HeaderText="自动分组" DataType="String" Width="70" Editable="false">
                </cc1:JQGridColumn>--%>
                <cc1:JQGridColumn DataField="timelog" TextAlign="Center" HeaderText="发生时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Width="130" Editable="true" DataType="DateTime" EditType="DatePicker" EditorControlID="DatePicker1">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="timelogend" TextAlign="Center" HeaderText="结束时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Width="150" Editable="false" DataType="DateTime" Visible="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="alarmdis" TextAlign="Center" HeaderText="描述" DataType="String" Width="220" Editable="true" EditType="TextArea">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="cemstype" TextAlign="Center" HeaderText="CEMS类型" DataType="String" Width="50" Editable="true" EditType="DropDown" EditorControlID="CemsType_ddl">
                    <%-- EditorControlID="CemsType_ddl"--%>
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="confirmedgroup" TextAlign="Center" HeaderText="确认分组" DataType="String" Width="50" Editable="true" EditType="DropDown" EditorControlID="GroupType_ddl">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="validatedgroup" TextAlign="Center" HeaderText="审核分组" DataType="String" Width="50" Editable="false" EditType="DropDown" EditorControlID="GroupType_ddl" Visible="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="groupstatus" TextAlign="Center" HeaderText="状态" DataType="String" Width="40" Editable="true" EditType="DropDown" EditorControlID="GroupStatus_ddl">
                    <%-- EditorControlID="CemsType_ddl"--%>
                </cc1:JQGridColumn>
                <cc1:JQGridColumn HeaderText="编辑" Width="25" Sortable="False">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn HeaderText="保存" Width="25" Sortable="False">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn HeaderText="取消" Width="25" Sortable="False">
                </cc1:JQGridColumn>
                <%--                <cc1:JQGridColumn  DataField="pointid" TextAlign="Center" HeaderText="机组" Width="50" DataType="String">
                </cc1:JQGridColumn>--%>
            </Columns>
            <EditDialogSettings CloseAfterEditing="True" />
            <AddDialogSettings CloseAfterAdding="True" />
            <SearchDialogSettings MultipleSearch="True" CloseAfterSearch="True" />
            <PagerSettings PageSize="30" PageSizeOptions="[30,50]" />

            <ToolBarSettings ShowRefreshButton="True" ShowSearchButton="True" ToolBarPosition="TopAndBottom" ShowAddButton="true" ShowDeleteButton="true">
                <%-- ShowEditButton="True"--%>
            </ToolBarSettings>

            <%--            <HierarchySettings HierarchyMode="Parent" />

            <ClientSideEvents SubGridRowExpanded="showSubGrid" />--%>

            <PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>

        <cc1:JQDatePicker
            runat="server"
            ID="DatePicker1"
            DateFormat="yyyy-MM-dd 00:00:00"
            DisplayMode="ControlEditor"
            ShowOn="Focus" />

        <%--<asp:TextBox class="easyui-datetimebox" id="DatePicker1" runat="server" data-options="formatter:ww3,parser:w3" Width="180"></asp:TextBox>--%>

        <asp:DropDownList ID="Machine_ddl" runat="server" Visible="false">
            <asp:ListItem Text="3" Value="3">3</asp:ListItem>
            <asp:ListItem Text="4" Value="4">4</asp:ListItem>
            <asp:ListItem Text="5" Value="5">5</asp:ListItem>
            <asp:ListItem Text="6" Value="6">6</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="CemsType_ddl" runat="server" Visible="true">
            <%--<asp:ListItem>FGD</asp:ListItem>--%>
            <asp:ListItem>SCR</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="GroupStatus_ddl" runat="server" Visible="true">
            <asp:ListItem Text="已确认" Value="2" Selected="True" />
            <asp:ListItem Text="未确认" Value="1" />
            <%--<asp:ListItem Text="已审核" Value="3"/>--%>
            <%-- <asp:ListItem Text="4" Value="4"/>--%>
        </asp:DropDownList>
        <asp:DropDownList ID="GroupType_ddl" runat="server" Visible="true">
            <asp:ListItem Text="仪表标定" Value="1" />
            <asp:ListItem Text="标定结束" Value="2" />
            <asp:ListItem Text="SCR投运" Value="3" />
            <asp:ListItem Text="SCR撤出" Value="4" />
            <asp:ListItem Text="特殊工况" Value="5" />
            <asp:ListItem Text="机组停机" Value="6" />
            <asp:ListItem Text="机组并网" Value="7" />
            <%--<asp:ListItem Text="FGD投运" Value="8"/>
            <asp:ListItem Text="FGD撤出" Value="9"/>--%>
            <%-- <asp:ListItem Text="4" Value="4"/>--%>
        </asp:DropDownList>
        <asp:DropDownList ID="PointsDownList" runat="server" Visible="true">
        </asp:DropDownList>
        <br />

        <asp:Button ID="Export" runat="server" Text="导出Excel" class="easyui-linkbutton" OnClick="Export_Click" Width="90" Height="25" Visible="false" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Button ID="ChartDetail" runat="server" Text="查看历史曲线" class="easyui-linkbutton" Width="90" Height="25" OnClick="ChartDetail_Click" Visible="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Button ID="ChartDetail2" runat="server" Text="HighChart曲线" class="easyui-linkbutton" Width="90" Height="25" OnClick="ChartDetail_Click2" Visible="true" />
        <input id="Button1" type="button" value="button" onclick="refreshclick()" hidden="hidden" />
        <input id="timerinside" type="text" hidden="hidden" />
    </div>
    <script type="text/javascript">
        $.ready(refreshclick());






        var texts = [
        { name: "PH计检修", value: "PH计检修" },
        { name: "PH计定期冲洗", value: "PH计定期冲洗" },
        { name: "排出泵检修", value: "排出泵检修" },
        { name: "石膏排出泵出口母管检修", value: "石膏排出泵出口母管检修" },
        { name: "密度计检修", value: "密度计检修" }
        ];
        $(function () {
            var sial = setInterval(function () {
                if ($("#add_Jqgrid1_top").length > 0) {
                    clearInterval(sial);
                    $("#add_Jqgrid1_top").click(function () {
                        $("#alarmdis").autocomplete(texts, {
                            minChars: 0,//自动完成激活之前填入的最小字符
                            max: 12,//列表条目数
                            width: 400,//提示的宽度
                            scrollHeight: 300,//提示的高度
                            matchContains: true,//是否只要包含文本框里的就可以
                            autoFill: false,//自动填充
                            formatItem: function (data, i, max) {//格式化列表中的条目 row:条目对象,i:当前条目数,max:总条目数
                                return data.name;//i + '/' + max + ':"' + data.name + '"[' + data.value + ']';
                            },
                            formatMatch: function (data, i, max) {//配合formatItem使用，作用在于，由于使用了formatItem，所以条目中的内容有所改变，而我们要匹配的是原始的数据，所以用formatMatch做一个调整，使之匹配原始数据
                                return data.name + data.value;
                            },
                            formatResult: function (data) {//定义最终返回的数据，比如我们还是要返回原始数据，而不是formatItem过的数据
                                return data.value;
                            }
                        });
                    })
                }
            }, 1000)
        })
    </script>

</asp:Content>
