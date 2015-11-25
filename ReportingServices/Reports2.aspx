<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports2.aspx.cs" Inherits="ReportingServices.Reports2" MasterPageFile="~/Site1.Master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <div style="text-align:center;font-family:'Microsoft JhengHei'">
        <h2>排 污 达 标 管 理 系 统</h2>
    </div>--%>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="1209px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1270px" ProcessingMode="Remote">
            <ServerReport ReportPath="/nonpenaltystatistic_total"/>
        </rsweb:ReportViewer>
    </div>
    <script src="js/jquery.report.js" type="text/javascript"></script>
</asp:Content>