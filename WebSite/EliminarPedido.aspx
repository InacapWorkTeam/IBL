<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EliminarPedido.aspx.cs" Inherits="EliminarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Button ID="btnVolver" runat="server" OnClick="Button2_Click" Text="Volver al menu Pedido" />
    </p>

    <p>
        Estamos en Eliminar Pedido&nbsp; </p>
    <p>
        Eliga el pedido que desea eliminar&nbsp;
        <asp:DropDownList ID="DropPedido" runat="server" Height="16px" Width="144px" AutoPostBack="True" OnSelectedIndexChanged="DropPedido_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblAviso" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnEliminar" runat="server" Height="35px" Text="Eliminar" Width="90px" OnClick="btnEliminar_Click" />
    </p>
    
</asp:Content>


