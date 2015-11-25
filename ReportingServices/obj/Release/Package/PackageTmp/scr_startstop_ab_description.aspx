<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scr_startstop_ab_description.aspx.cs" Inherits="ReportingServices.scr_startstop_ab_description" MasterPageFile="~/Site1.Master" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%# Eval("description") %>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="JsPlug/AmazeUI/css/amazeui.min.css" />
    <link rel="stylesheet" href="JsPlug/AmazeUI/css/admin.css" />
    <script type="text/javascript" src="JsPlug/AmazeUI/js/jquery.min.js"></script>
    <script type="text/javascript" src="JsPlug/AmazeUI/js/amazeui.min.js"></script>
    <div style="width: 1000px">
        <div class="am-g am-g-fixed" style="margin-bottom: 10px; margin-left: -16px">
            <div class="am-u-sm-3">
                <input type="text" class="am-form-field" placeholder="开始时间" id="my-start-2" value="<%=startTime %>" readonly />
                <asp:HiddenField ID="hidStart" runat="server" />
            </div>
            <div class="am-u-sm-3">
                <input type="text" class="am-form-field" placeholder="结束时间" id="my-end-2" value="<%=endTime %>" readonly />
                <asp:HiddenField ID="hidEnd" runat="server" />
            </div>
            <div class="am-u-sm-3">
                <asp:CheckBoxList ID="chkboxlist" CssClass="am-tabler" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="3#" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4#" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5#" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6#" Value="6"></asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="am-u-sm-3">
                <asp:Button ID="btn_query" CssClass="am-btn am-btn-primary btn-loading-example" data-am-loading="{loadingText: '查询中...'}" Text="查询" runat="server" OnClick="btn_query_Click" />
            </div>
        </div>
        <table class="am-table am-table-bordered am-table-centered">
            <tr>
                <th width="25%">标定计量点</th>
                <th width="20%">撤出时间</th>
                <th width="20%">投运时间</th>
                <th width="25%">描述</th>
                <th width="10%">操作</th>
            </tr>
            <asp:Repeater ID="rpt_RulelogS_Des" runat="server">
                <ItemTemplate>
                    <tr>
                        <td pointname="<%# Eval("pointname") %>"><%# Eval("name") %> <input type="text" id="id" hidden="hidden" value="<%# Eval("id") %>" /></td>
                        <td starttime="<%# Eval("starttime") %>"><%# Eval("starttime") %></td>
                        <td endtime="<%# Eval("endtime") %>"><%# Eval("endtime") %></td>
                        <td>
                            <textarea class="" disabled="disabled" cols="30" rows="1"><%# Eval("description") %></textarea></td>
                        <td>
                            <div class="am-btn-toolba">
                                <div class="am-btn-group am-btn-group-xs">
                                    <button name="btn-edit" class="am-btn am-btn-default am-btn-xs am-text-secondary am-center">编辑</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
            PagingButtonLayoutType="UnorderedList" CssClass="am-pagination am-pagination-right" CurrentPageButtonClass="am-active"
            OnPageChanging="AspNetPager1_PageChanging" OnPageChanged="AspNetPager1_PageChanged" CurrentPageButtonPosition="Center"
            Width="100%" HorizontalAlign="Right" AlwaysShowFirstLastPageNumber="true" PagingButtonSpacing="10" TextBeforePageIndexBox="转到"
            TextAfterPageIndexBox="页" SubmitButtonText="Go" ShowFirstLast="False" ShowPageIndexBox="Never">
        </webdiyer:AspNetPager>
    </div>
    <!-- modal开始 -->
    <div class="am-modal am-modal-alert" tabindex="-1" id="alert">
        <div class="am-modal-dialog">
            <div class="am-modal-hd">保存成功</div>
            <%--<div class="am-modal-bd">
                Hello world！
            </div>--%>
            <div class="am-modal-footer">
                <span class="am-modal-btn">确定</span>
            </div>
        </div>
    </div>

    <div class="am-modal am-modal-loading am-modal-no-btn" tabindex="-1" id="modal-loading">
        <div class="am-modal-dialog">
            <div class="am-modal-hd">正在保存...</div>
            <div class="am-modal-bd">
                <span class="am-icon-spinner am-icon-spin"></span>
            </div>
        </div>
    </div>
    <!-- modal结束 -->

    <script type="text/javascript">
        $(document).ready(function () {
            $alert = $("#alert");
            $modal = $("#modal-loading");
            $("button[name='btn-edit']").click(function () {
                var isedit = $(this).text() == "编辑" ? true : false;
                if (isedit) {
                    $(this).parents("tr").first().find("textarea").attr("disabled", !isedit);
                    $(this).text("保存");
                } else {
                    $item = $(this).parents("tr").first();
                    $item.find("textarea").attr("disabled", !isedit);
                    id = $item.find("input#id").val();
                    description = $item.find("textarea").val();
                    $.ajax({
                        type: 'POST',
                        url: '/api/Rulelog/',
                        data: { id: id, description: description, typeid: 0 },
                        datatype: "json",
                        beforeSend: function () {
                            $modal.modal();
                        },
                        success: function (data) {
                            //if (data.id)
                            //    $alert.find(".am-modal-hd").text("保存成功");
                            //else
                            //    $alert.find(".am-modal-hd").text("保存失败");
                            $alert.find(".am-modal-hd").text("保存成功");
                            $alert.modal();
                        },
                        complete: function (XMLHttpRequest, textStatus) {
                            $modal.modal('close');
                        },
                        error: function () {
                            alert('error')
                            $alert.find(".am-modal-hd").text("保存失败");
                            $alert.modal();
                            //请求出错处理
                        }
                    });
                    $(this).text("编辑");
                }
                return false;
            })

            $('.btn-loading-example').click(function () {
                var $btn = $(this)
                $btn.button('loading');
            });
            
            $(".am-checkbox-inline input[type='checkbox']").click(function () {
                alert($(this).is(':checked') );
            })

            var nowTemp = new Date();
            var now = new Date(1990, 1, 1, 0, 0, 0, 0);
            var $myStart2 = $('#my-start-2');

            var checkin = $myStart2.datepicker({
                onRender: function (date) {
                    return date.valueOf() < now.valueOf() ? 'am-disabled' : '';
                }
            }).on('changeDate.datepicker.amui', function (ev) {
                if (ev.date.valueOf() > checkout.date.valueOf()) {
                    var newDate = new Date(ev.date)
                    newDate.setDate(newDate.getDate() + 1);
                    checkout.setValue(newDate);
                    $("#ContentPlaceHolder1_hidEnd").val(newDate.Format("yyyy-MM-dd"));
                }
                checkin.close();
                $('#my-end-2')[0].focus();
                $("#ContentPlaceHolder1_hidStart").val(ev.date.Format("yyyy-MM-dd"));
            }).data('amui.datepicker');

            var checkout = $('#my-end-2').datepicker({
                onRender: function (date) {
                    return date.valueOf() <= checkin.date.valueOf() ? 'am-disabled' : '';
                }
            }).on('changeDate.datepicker.amui', function (ev) {
                checkout.close();
                $("#ContentPlaceHolder1_hidEnd").val(ev.date.Format("yyyy-MM-dd"));
            }).data('amui.datepicker');
        })


        // 对Date的扩展，将 Date 转化为指定格式的String   
        // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
        // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
        // 例子：   
        // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
        // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
        Date.prototype.Format = function (fmt) { //author: meizz   
            var o = {
                "M+": this.getMonth() + 1,                 //月份   
                "d+": this.getDate(),                    //日   
                "h+": this.getHours(),                   //小时   
                "m+": this.getMinutes(),                 //分   
                "s+": this.getSeconds(),                 //秒   
                "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
                "S": this.getMilliseconds()             //毫秒   
            };
            if (/(y+)/.test(fmt))
                fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o)
                if (new RegExp("(" + k + ")").test(fmt))
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            return fmt;
        }

    </script>
</asp:Content>
