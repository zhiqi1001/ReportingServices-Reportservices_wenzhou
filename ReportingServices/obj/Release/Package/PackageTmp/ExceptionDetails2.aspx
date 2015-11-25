<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionDetails2.aspx.cs" Inherits="ReportingServices.ExceptionDetails2"  MasterPageFile="~/ReportingServices.Master"%>
<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="pagecontent">
        <link rel="stylesheet" type="text/css" media="screen" href="themes/ui.jqgrid.css" />
        <script src="js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>
        <script src="js/trirand/i18n/grid.locale-cn.js" type="text/javascript"></script>
    
    <form id="form1" runat="server">
        <script type="text/javascript">
            function showSubGrid(subgrid_id, row_id) {
                //showSubGrid_jqgrid2(subgrid_id, row_id);
                showSubGrid_Jqgrid2(subgrid_id, row_id);
            }
    </script>
    <script>
        $(document).ready(function () {
            var datestr = $("#pagecontent_lb_date").html().toString().substr(0, 10);
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "WSConfirm.asmx/checkdaysubmitstatus",
                data: "{'datestr':'" + datestr + "'}",
                dataType: "json",
                success: function (result) {
                    //$.messager.alert('提示', opermsg.d.msg);
                    if (result.d == 1) {
                        $("#btn_submit2").attr({ disabled: "disabled" });
                        $("#btn_submit2").attr({ value: "数据已提交" });
                    }
                },
                error: function (rps) {
                    var temp = rps;
                }
            });
        });
        </script>
    <script>
        function Confirm(msg) {
            $.messager.confirm('确认', msg, function (r) {
                var datestr = $("#pagecontent_lb_date").html().toString().substr(0, 10);
                if (r) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "WSConfirm.asmx/submit",
                        data: "{'datestr':'" + datestr + "'}",
                        dataType: "json",
                        success: function (opermsg) {
                            $.messager.alert('提示', opermsg.d.msg);
                            if (opermsg.d.status == 1) {
                                $("#btn_submit2").attr({ disabled: "disabled" });
                                $("#btn_submit2").attr({ value: "数据已提交" });
                            }
                        },
                        error: function (rps) {
                            var temp = rps;
                        }
                    });
                }
            });
            return false;
        }
        </script>
        <div>
        <asp:Label ID="lb_date" runat="server" style="font-family:'Microsoft YaHei';font-size:larger"></asp:Label></div>
        <div style="width:1380px">
            &nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_submit" runat="server" Text="确认该日数据" class="easyui-linkbutton" width="120" Height="25" Visible="false" OnClick="btn_submit_Click"/>
            <input id="btn_submit2" type="button" value="确认该日数据" class="easyui-linkbutton" style="width:120px;height:25px" onclick="Confirm('确认该日数据？')"/>
            <asp:Button ID="btn_return" runat="server" Text="返回" class="easyui-linkbutton" width="120" Height="25" OnClick="btn_return_Click"/>
        </div>
        <br />
    <div>
        <cc1:JQGrid ID="Jqgrid1" runat="server" Height="500px" Width="1024px">
            <Columns>
                <cc1:JQGridColumn DataField="timestamps" HeaderText="时间">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="pointname" HeaderText="计量点名称">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="indicatorname" HeaderText="指标名称">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="unit" HeaderText="计量单位">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="indicatorvalue" HeaderText="指标值">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="reference" HeaderText="参考值">
                </cc1:JQGridColumn>
                 <cc1:JQGridColumn DataField="info" HeaderText="信息">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="id2" PrimaryKey="true" Visible="false">
                </cc1:JQGridColumn>
            </Columns>
            <PagerSettings PageSize="20" PageSizeOptions="[10,20,30]" />
            <HierarchySettings HierarchyMode="Parent" />
            <ClientSideEvents SubGridRowExpanded="showSubGrid" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>
        <cc1:JQGrid ID="Jqgrid2" runat="server"  OnDataRequesting="JQGrid2_DataRequesting" OnRowEditing="Jqgrid2_RowEditing" Width="850">
            <Columns>
                <cc1:JQGridColumn DataField="logid" PrimaryKey="true" HeaderText="记录id">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="timelog" Editable="false" HeaderText="时间">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="Alarmlog" Editable="true" HeaderText="报警日志">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="AlarmDis" Editable="true" HeaderText="报警描述" Width="320">
                </cc1:JQGridColumn>
            </Columns>
            <EditDialogSettings Modal="True" CloseAfterEditing="True" />
            <HierarchySettings HierarchyMode="Child" />
            <ToolBarSettings ShowEditButton="true" />
<PivotSettings RowTotals="False" RowTotalsText="Total" ColTotals="False" GroupSummary="True" GroupSummaryPosition="Header" FrozenStaticCols="False"></PivotSettings>
        </cc1:JQGrid>
    </div>
    </form>
</asp:Content>