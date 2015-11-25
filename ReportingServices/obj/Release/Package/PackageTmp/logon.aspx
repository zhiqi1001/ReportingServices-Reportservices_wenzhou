<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logon.aspx.cs" Inherits="ReportingServices.logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="script/jquery-2.1.3.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" media="screen" href="themes/jquery-ui.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="easyui/demo/demo.css"/>
    <script type="text/javascript" src="easyui/jquery.easyui.min.js"></script>
    <title>温州电厂工况日志管理</title>
</head>
<body>
    <table style="width:100%; text-align:center">
        <tr>
            <td style="width:50%"><img src="images/znlogo.png" /></td>
            <td style="width:50%"><img src="images/zqlogo.png" /></td>
        </tr>
    </table>
    <form id="form1" runat="server" style="align-content:center">
        <br /><br />
        <div  style="text-align:center;font-family:'Microsoft JhengHei';font-size:xx-large;font-weight:bolder">温州电厂工况日志管理</div>
        <br /><br /><br /><br />
    <div style="text-align:center">
        <label>用户:</label>&nbsp&nbsp&nbsp&nbsp
        <asp:DropDownList ID="user_ddl" runat="server" Width="150" Height="25">
            <asp:ListItem Text="一期集控" Value="1"></asp:ListItem>
            <asp:ListItem Text="二期集控" Value="2"></asp:ListItem>
            <asp:ListItem Text="脱硫集控" Value="3"></asp:ListItem>
            <asp:ListItem Text="脱硝运行专工" Value="4"></asp:ListItem>
            <asp:ListItem Text="脱硫运行专工" Value="5"></asp:ListItem>
            <asp:ListItem Text="环保专工" Value="6"></asp:ListItem>
            <asp:ListItem Text="仪控专工" Value="7"></asp:ListItem>
        </asp:DropDownList>
    </div>
        <br /><br /><br />
        <div  style="text-align:center">
        <label>密码:</label>&nbsp&nbsp&nbsp&nbsp
            <asp:TextBox ID="psw" runat="server" TextMode="Password" Width="150" Height="20"></asp:TextBox>
    </div>
        <br /><br /><br /><br /><br /><br />
        <div  style="text-align:center">
            <asp:Button  Text="进入管理流" class="easyui-linkbutton" width="80" Height="25" runat="server" OnClick="logon_btn_Click" ID="logon_btn"/>
        </div>

        <br /><br />
        <div  style="text-align:center">
            <asp:Label runat="server" ID="msg"></asp:Label>
        </div>
        <br /><br />
        <br /><br />
        <br /><br />
        <br /><br />
        <br /><br />
        <div  style="text-align:center;font-weight:bold">
            智企信息 Copyright 2014-2015
        </div>
    </form>
</body>
</html>
