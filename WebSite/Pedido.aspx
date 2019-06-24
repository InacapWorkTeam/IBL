<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pedido.aspx.cs" Inherits="Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        MENU CRUD PEDIDO</p>
    <table class="auto-style1">
        <tr>
            <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ingresarPedido.aspx">Ingresar Pedido</asp:HyperLink></td>
        </tr>
        <tr>
            <td><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/listarPedido.aspx">Listar Pedido</asp:HyperLink></td>
        </tr>
        <tr>
            <td><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/modificarPedido.aspx">Modificar Pedido</asp:HyperLink></td>
        </tr>
        <tr>
            <td><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/eliminarPedido.aspx">Eliminar Pedido</asp:HyperLink></td>
        </tr>
    </table>
    <p>
        &nbsp;</p>



</asp:Content>

