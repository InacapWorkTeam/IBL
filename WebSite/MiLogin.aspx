<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MiLogin.aspx.cs" Inherits="MiLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 24%;
        }
        .auto-style2 {
            width: 179px;
        }
        .auto-style4 {
            font-size: large;
            text-align: center;
            width: 16px;
        }
        .auto-style6 {
            width: 179px;
            height: 24px;
        }
        .auto-style7 {
            font-size: large;
            text-align: center;
            width: 16px;
            height: 24px;
        }
        .auto-style8 {
            height: 24px;
            width: 334px;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style10 {
            width: 334px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style9" colspan="3">LOGIN</td>
            </tr>
            <tr>
                <td class="auto-style6">Username:</td>
                <td class="auto-style7"><strong>:</strong></td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td class="auto-style4"><strong>:</strong></td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lblMensaje" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="btnLogIn" runat="server" OnClick="btnLogIn_Click" Text="Log in" Width="109px" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
