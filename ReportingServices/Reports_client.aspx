<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports_client.aspx.cs" Inherits="ReportingServices.Reports_client"%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<body>
    <div>
        <form id="form1" runat="server" style="align-content:center">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="1209px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1270px" ProcessingMode="Remote">
            <%--<ServerReport ReportPath="/异常分组统计20141108"/>--%>
        </rsweb:ReportViewer>
            </form>
    </div>
    <script src="js/jquery.report.js" type="text/javascript"></script>
</body>