<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ReportingServices.Reports" MasterPageFile="~/ReportingServices.Master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="content1" ContentPlaceHolderID="pagecontent" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="1209px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1200px" ProcessingMode="Remote">
            <ServerReport ReportPath="/ReportList"/>
        </rsweb:ReportViewer>
    </div>
    </form>
</asp:Content>