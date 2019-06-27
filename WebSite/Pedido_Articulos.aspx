﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pedido_Articulos.aspx.cs" Inherits="Pedido_Articulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            width: 16%;
        }
        .auto-style11 {
            width: 16%;
            height: 24px;
        }
        .auto-style12 {
            height: 24px;
        }
        .auto-style14 {
            width: 99%;
        }
        .auto-style16 {
            width: 731px;
            height: 23px;
        }
        .auto-style17 {
            width: 31%;
        }
        .auto-style18 {
            width: 8%;
        }
        .auto-style20 {
            height: 24px;
            width: 119px;
        }
        .auto-style21 {
            width: 119px;
        }
        .auto-style22 {
            width: 41%;
        }
        .auto-style23 {
            height: 24px;
            width: 41%;
        }
        .auto-style24 {
            text-align: center;
        }
        .auto-style25 {
            height: 24px;
            width: 31%;
        }
        .auto-style26 {
            width: 103px;
        }
        .auto-style28 {
            width: 319px;
        }
        .auto-style29 {
            width: 24px;
            text-align: center;
        }
        .auto-style30 {
            width: 695px;
            height: 23px;
        }
        .auto-style31 {
            width: 690px;
            height: 23px;
        }
        .auto-style32 {
            width: 492px;
            height: 23px;
        }
        .auto-style33 {
            width: 103px;
            height: 26px;
        }
        .auto-style34 {
            width: 24px;
            text-align: center;
            height: 26px;
        }
        .auto-style35 {
            width: 319px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="6">
                <div class="auto-style24">
                <asp:Label ID="Label1" runat="server" Text="Listar"></asp:Label>
                <br />
                </div>
                <table class="auto-style14">
                    <tr>
                        <td class="auto-style10">
                            <asp:Label ID="Label5" runat="server" Text="Ingresar 0 o un ID para listar:"></asp:Label>
                        </td>
                        <td class="auto-style17">
                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtId" ErrorMessage="Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style18">
                            &nbsp;</td>
                        <td class="auto-style21">
                            <asp:Label ID="Label6" runat="server" Text="Ingresar ID Pedido:"></asp:Label>
                        </td>
                        <td class="auto-style22">
                            <asp:TextBox ID="txtIdPedido" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtIdPedido" ErrorMessage="Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="lblMensaje" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style25">
                            <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click1" />
                        </td>
                        <td class="auto-style12">
                            &nbsp;</td>
                        <td class="auto-style20">
                            <asp:Label ID="lblMensajeListaPedido" runat="server" Text="[lblMensaje]"></asp:Label>
                        </td>
                        <td class="auto-style23">
                            <asp:Button ID="btnListarPorPedido" runat="server" OnClick="btnListarPorPedido_Click" Text="Listar por pedido" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12" colspan="5">
                            <asp:GridView ID="tblListado" runat="server" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="421px">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style16" colspan="4">
                <asp:Label ID="Label3" runat="server" Text="Ingresar"></asp:Label>
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style26">ID Pedido Asoc.</td>
                        <td class="auto-style29">
                            <h4><strong>:</strong></h4>
                        </td>
                        <td class="auto-style28">
                            <asp:DropDownList ID="dropListPedidos" runat="server" Height="16px" Width="125px" OnSelectedIndexChanged="dropListPedidos_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">ID Articulo</td>
                        <td class="auto-style29">
                            <h4><strong>:</strong></h4>
                        </td>
                        <td class="auto-style28">
                            <asp:DropDownList ID="droplistArticulos" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="droplistArticulos_SelectedIndexChanged" Width="128px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">Tamaño</td>
                        <td class="auto-style29">
                            <h4><strong>:</strong></h4>
                        </td>
                        <td class="auto-style28">
                            <asp:TextBox ID="txtTamano" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">Color:</td>
                        <td class="auto-style29">
                            <h4><strong>:</strong></h4>
                        </td>
                        <td class="auto-style28">
                            <asp:TextBox ID="txtColor" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">Unidades</td>
                        <td class="auto-style29">
                            <h4><strong>:</strong></h4>
                        </td>
                        <td class="auto-style28">
                            <asp:TextBox ID="txtUnidades" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUnidades" ErrorMessage="Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style33">Precio</td>
                        <td class="auto-style34">
                            <h4><strong>:</strong></h4>
                        </td>
                        <td class="auto-style35">
                            <asp:TextBox ID="txtPrecio" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style29">
                            &nbsp;</td>
                        <td class="auto-style28">
                            <asp:Label ID="lblMensajeIngreso" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style29">
                            &nbsp;</td>
                        <td class="auto-style28">
                            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" Width="111px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="auto-style16">
            </td>
            <td class="auto-style5">
                </td>
        </tr>
        <tr>
            <td class="auto-style32">
                &nbsp;</td>
            <td class="auto-style31">
                &nbsp;</td>
            <td class="auto-style30">
                &nbsp;</td>
            <td class="auto-style16">
                &nbsp;</td>
            <td class="auto-style16">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style16" colspan="4">
                </td>
            <td class="auto-style16">
                </td>
            <td class="auto-style5">
                </td>
        </tr>
        <tr>
            <td class="auto-style16" colspan="5">
                <asp:Label ID="Label2" runat="server" Text="Modificar"></asp:Label>
            </td>
            <td class="auto-style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style16" colspan="5">
                <asp:Label ID="Label4" runat="server" Text="Eliminar"></asp:Label>
            </td>
            <td class="auto-style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style16" colspan="5">
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

