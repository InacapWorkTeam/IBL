<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IngresarPedido.aspx.cs" Inherits="IngresarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            width: 230px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Button ID="btnVolver" runat="server" OnClick="Button2_Click" Text="Volver al menu Pedido" />
    </p>

    <p>
        Estamos en el ingresar Pedido</p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style10">Ingrese Fecha de realizacion</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Ingrese costo total del pedido</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="215px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Seleccione vendedor asociado</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">Seleccione cliente asociado</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>

