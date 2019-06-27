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
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Ingrese costo total del pedido</td>
            <td>
                <asp:TextBox ID="txtTotal" runat="server" Width="215px"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTotal" ErrorMessage="Ingrese un campo valido" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Seleccione vendedor asociado</td>
            <td>
                <asp:DropDownList ID="DropVendedor" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="222px">
                </asp:DropDownList>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="DropVendedor" ErrorMessage="Seleccione un campo" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Seleccione cliente asociado</td>
            <td>
                <asp:DropDownList ID="DropCliente" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Width="223px">
                </asp:DropDownList>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="DropCliente" ErrorMessage="Seleccione un campo" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="btnRegistrar" runat="server" Height="52px" Text="Registrar Pedido" Width="105px" OnClick="btnRegistrar_Click" />
        <asp:Label ID="lblaviso" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

