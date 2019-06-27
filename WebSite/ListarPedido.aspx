<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListarPedido.aspx.cs" Inherits="ListarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Button ID="btnVolver" runat="server" OnClick="Button2_Click" Text="Volver al menu Pedido" />
    </p>

    <p>
        Estamos en el listar pedido</p>
    <p>
        Ingrese el rut que desea buscar (0 para buscar todos) = <asp:TextBox ID="txtId" runat="server" Width="136px"></asp:TextBox><asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" /></p>
    <p>
        <asp:GridView ID="tblListado" runat="server" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="421px">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            </asp:GridView></p>

</asp:Content>

