<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionDetails.aspx.cs" Inherits="ReportingServices.ExceptionDetails" %>

<%@ Register Assembly="Trirand.Web" Namespace="Trirand.Web.UI.WebControls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ExceptionDetails</title>
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
           function showSubGrid(subgrid_id, row_id) 
           {
               //showSubGrid_jqgrid2(subgrid_id, row_id);
               showSubGrid_Jqgrid2(subgrid_id, row_id);
           }   
    </script>
    <script>
        $(document).ready(function () {
            var datestr = $("#lb_date").html().toString().substr(0, 10);
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
</head>
<body>
    <script>
        function Confirm(msg) {
            $.messager.confirm('确认', msg, function (r) {
                var datestr = $("#lb_date").html().toString().substr(0, 10);
                if (r) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "WSConfirm.asmx/submit",
                        data: "{'datestr':'"+datestr+"'}",
                        dataType: "json",
                        success: function(opermsg)
                        {
                            $.messager.alert('提示', opermsg.d.msg);
                            if (opermsg.d.status == 1) {
                                $("#btn_submit2").attr({ disabled: "disabled" });
                                $("#btn_submit2").attr({ value: "数据已提交" });
                            }
                        },
                        error: function (rps)
                        {
                            var temp = rps;
                        }
                    });
                }
            });
            return false;
        }
        </script>
    <form id="form1" runat="server">
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
        </div>
        <br />
    <div>
        <cc1:JQGrid ID="Jqgrid1" runat="server" Height="500px" Width="1124px">
            <Columns>
                <cc1:JQGridColumn DataField="timestamps" HeaderText="时间" Width="200">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="pointname" HeaderText="计量点名称">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="indicatorname" HeaderText="指标名称">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="unit" HeaderText="计量单位" Visible="false">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="indicatorvalue" HeaderText="环保厅计量值">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="validvalue" HeaderText="有效值">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="loadvalue" HeaderText="负荷值">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="reference" HeaderText="异常判定值">
                </cc1:JQGridColumn>
                 <cc1:JQGridColumn DataField="info" HeaderText="异常信息">
                </cc1:JQGridColumn>
                <cc1:JQGridColumn DataField="relevantcount" HeaderText="关联记录数">
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
</body>
</html>
