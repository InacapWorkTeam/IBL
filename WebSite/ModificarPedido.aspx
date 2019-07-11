<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarPedido.aspx.cs" Inherits="ModificarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style11 {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:Button ID="btnVolver" runat="server" OnClick="Button2_Click" Text="Volver al menu Pedido" />
    </p>
    <p>
        Estamos en el modificar pedido</p>
    
    <p>
        Ingrese el ID del pedido que desea modificar =
        &nbsp;<asp:DropDownList ID="DropDownListPedido" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged2" Width="168px">
        </asp:DropDownList>
        
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="DropDownListPedido" ErrorMessage="Ingrese un Id valido EJ: 1 " ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
    </p>
    
    <p>
        <asp:GridView ID="tblListado" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" Width="421px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style11"><asp:Label ID="lblFecha" runat="server" Text="Ingrese la nueva Fecha de realizacion"></asp:Label>
            </td>
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
            <td class="auto-style11"><asp:Label ID="lblCosto" runat="server" Text="Ingrese el nuevo costo total del pedido"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTotal" runat="server" Width="215px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style11"><asp:Label ID="lblVendedor" runat="server" Text="Seleccione el nuevo vendedor asociado"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropVendedor" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="222px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style11"><asp:Label ID="lblCliente" runat="server" Text="Seleccione el nuevo cliente asociado"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropCliente" runat="server" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Width="223px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="btnModificar" runat="server" Height="52px" Text="Modificar" Width="105px" OnClick="btnRegistrar_Click" />
        <asp:Label ID="lblaviso" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

