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
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="False" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Ingrese costo total del pedido</td>
            <td>
                <asp:TextBox ID="txtTotal" runat="server" Width="215px"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTotal" ErrorMessage="Ingrese un campo valido EJ: 20000 " ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Seleccione vendedor asociado</td>
            <td>
                <asp:DropDownList ID="DropVendedor" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="222px">
                </asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Seleccione cliente asociado</td>
            <td>
                <asp:DropDownList ID="DropCliente" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Width="223px">
                </asp:DropDownList>
                
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="btnRegistrar" runat="server" Height="52px" Text="Registrar Pedido" Width="105px" OnClick="btnRegistrar_Click" />
        <asp:Label ID="lblaviso" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

