<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pedido_Articulos.aspx.cs" Inherits="Pedido_Articulos" %>

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
        .auto-style29 {
            width: 24px;
            text-align: center;
        }
        .auto-style33 {
            width: 103px;
            height: 26px;
        }
        .auto-style34 {
            width: 24px;
            text-align: center;
            height: 26px;
        font-size: x-large;
    }
        .auto-style35 {
            height: 26px;
        }
        .auto-style36 {
            height: 277px;
        }
        .auto-style43 {
            width: 164px;
            height: 23px;
            text-align: left;
        }
        .auto-style44 {
            width: 164px;
            text-align: left;
        }
        .auto-style49 {
            width: 164px;
            text-align: left;
            height: 26px;
        }
        .auto-style55 {
            width: 296px;
        }
    .auto-style56 {
        width: 30px;
    }
    .auto-style57 {
        height: 26px;
        width: 30px;
        text-align: center;
        font-size: x-large;
    }
    .auto-style58 {
        width: 30px;
        text-align: center;
        font-size: x-large;
    }
    .auto-style59 {
        font-size: x-large;
    }
    .auto-style60 {
        width: 24px;
        text-align: center;
        font-size: x-large;
    }
    .auto-style61 {
        height: 26px;
        width: 296px;
    }
    .auto-style62 {
            width: 295px;
        }
    .auto-style63 {
        height: 26px;
        width: 295px;
    }
    .auto-style65 {
        width: 22px;
    }
    .auto-style66 {
        height: 26px;
        width: 22px;
    }
    .auto-style67 {
        width: 131px;
    }
    .auto-style68 {
        height: 26px;
        width: 131px;
    }
    .auto-style69 {
        width: 22px;
        text-align: center;
        font-size: x-large;
    }
    .auto-style70 {
        width: 103px;
        height: 30px;
    }
    .auto-style71 {
        width: 24px;
        text-align: center;
        font-size: x-large;
        height: 30px;
    }
    .auto-style72 {
            width: 296px;
            height: 30px;
        }
    .auto-style73 {
        width: 164px;
        text-align: left;
        height: 30px;
    }
    .auto-style74 {
        width: 30px;
        text-align: center;
        font-size: x-large;
        height: 30px;
    }
    .auto-style75 {
            width: 295px;
            height: 30px;
        }
    .auto-style76 {
        width: 131px;
        height: 30px;
    }
    .auto-style77 {
        width: 22px;
        height: 30px;
    }
    .auto-style78 {
        height: 30px;
    }
    .auto-style79 {
        width: 24px;
        text-align: center;
        height: 30px;
    }
    .auto-style80 {
        width: 30px;
        height: 30px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style36" style="font-family: Tahoma">
                <div class="auto-style24" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                <asp:Label ID="Label1" runat="server" Text="Listar"></asp:Label>
                <br />
                </div>
                <table class="auto-style14" border="1">
                    <tr>
                        <td class="auto-style10" style="background-color: #FFFFFF">
                            <asp:Label ID="Label5" runat="server" Text="Ingresar 0 o un ID para listar:"></asp:Label>
                        </td>
                        <td class="auto-style17" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtId" ErrorMessage="*Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style18">
                            &nbsp;</td>
                        <td class="auto-style21">
                            <asp:Label ID="Label6" runat="server" Text="Ingresar ID Pedido:"></asp:Label>
                        </td>
                        <td class="auto-style22" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                            <asp:TextBox ID="txtIdPedido" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtIdPedido" ErrorMessage="*Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="lblMensaje" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style25">
                            <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click1" Width="95px" BackColor="#1F366B" BorderColor="White" BorderWidth="1px" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                        </td>
                        <td class="auto-style12">
                            &nbsp;</td>
                        <td class="auto-style20">
                            <asp:Label ID="lblMensajeListaPedido" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style23">
                            <asp:Button ID="btnListarPorPedido" runat="server" OnClick="btnListarPorPedido_Click" Text="Listar por pedido" BackColor="#1F366B" BorderColor="White" BorderWidth="1px" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style12" colspan="5">
                            <asp:GridView ID="tblListado" runat="server" CellPadding="3" EnableModelValidation="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="421px" >
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
        </table>
<br />
                <table class="auto-style1" border="0" style="font-family: tahoma">
                    <tr>
                        <td class="auto-style24" colspan="3" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                <asp:Label ID="Label3" runat="server" Text="Ingresar"></asp:Label>
                        </td>
                        <td class="auto-style24" colspan="3" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                <asp:Label ID="Label2" runat="server" Text="Modificar"></asp:Label>
                        </td>
                        <td class="auto-style24" colspan="3" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold;">
                <asp:Label ID="Label4" runat="server" Text="Eliminar"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">ID Pedido Asoc.</td>
                        <td class="auto-style60">
                            <h4 class="auto-style59"><strong>:</strong></h4>
                        </td>
                        <td class="auto-style55">
                            <asp:DropDownList ID="dropListPedidos" runat="server" Height="16px" Width="176px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style43">ID Pedido Articulos</td>
                        <td class="auto-style58">
                            <strong>:</strong></td>
                        <td class="auto-style62">
                            <asp:DropDownList ID="dropListIDPedidoArticulosModificar" runat="server" AutoPostBack="True" Height="22px" OnSelectedIndexChanged="dropListIDPedidoArticulosModificar_SelectedIndexChanged" Width="164px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style67" style="table-layout: auto">
                            ID Pedido Articulo</td>
                        <td class="auto-style69" style="table-layout: auto">
                            <strong>:</strong></td>
                        <td style="table-layout: auto">
                            <asp:DropDownList ID="dropListIDPedidoArticulosEliminar" runat="server" Height="16px" Width="172px" OnSelectedIndexChanged="dropListIDPedidoArticulosEliminar_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">ID Articulo</td>
                        <td class="auto-style60">
                            <h4 class="auto-style59"><strong>:</strong></h4>
                        </td>
                        <td class="auto-style55">
                            <asp:DropDownList ID="droplistArticulos" runat="server" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="droplistArticulos_SelectedIndexChanged" Width="176px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style43">ID Pedido</td>
                        <td class="auto-style58">
                            <strong>:</strong></td>
                        <td class="auto-style62">
                            <asp:DropDownList ID="dropListIDPedidoModificar" runat="server" AutoPostBack="True" Height="16px" Width="163px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style67" style="table-layout: auto">
                            &nbsp;</td>
                        <td class="auto-style65" style="table-layout: auto">
                            &nbsp;</td>
                        <td style="table-layout: auto">
                            <asp:Label ID="lblMensajeEliminar" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style70">Tamaño</td>
                        <td class="auto-style71">
                            <h4 class="auto-style59"><strong>:</strong></h4>
                        </td>
                        <td class="auto-style72">
                            <asp:TextBox ID="txtTamano" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style73">ID Articulo</td>
                        <td class="auto-style74">
                            <strong>:</strong></td>
                        <td class="auto-style75">
                            <asp:DropDownList ID="dropListArticuloModificar" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="dropListArticuloModificar_SelectedIndexChanged" Width="164px">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style76" style="table-layout: auto">
                        </td>
                        <td class="auto-style77" style="table-layout: auto">
                        </td>
                        <td class="auto-style78" style="table-layout: auto">
                            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" BackColor="#1F366B" BorderColor="White" BorderWidth="1px" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style26">Color:</td>
                        <td class="auto-style60">
                            <h4 class="auto-style59"><strong>:</strong></h4>
                        </td>
                        <td class="auto-style55">
                            <asp:TextBox ID="txtColor" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style43">Tamaño</td>
                        <td class="auto-style58">
                            <strong>:</strong></td>
                        <td class="auto-style62">
                            <asp:TextBox ID="txtTamanoModificar" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style67" style="table-layout: auto">
                            &nbsp;</td>
                        <td class="auto-style65" style="table-layout: auto">
                            &nbsp;</td>
                        <td style="table-layout: auto">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style26">Unidades</td>
                        <td class="auto-style60">
                            <h4 class="auto-style59"><strong>:</strong></h4>
                        </td>
                        <td class="auto-style55" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                            <asp:TextBox ID="txtUnidades" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUnidades" ErrorMessage="*Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style43">Color</td>
                        <td class="auto-style58">
                            <strong>:</strong></td>
                        <td class="auto-style62">
                            <asp:TextBox ID="txtColorModificar" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style67">
                            &nbsp;</td>
                        <td class="auto-style65">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style33">Precio</td>
                        <td class="auto-style34">
                            <h4 class="auto-style59"><strong>:</strong></h4>
                        </td>
                        <td class="auto-style61">
                            <asp:TextBox ID="txtPrecio" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style49">Unidades</td>
                        <td class="auto-style57">
                            <strong>:</strong></td>
                        <td class="auto-style63" style="font-family: tahoma; font-size: large; color: #993300; font-weight: bold">
                            <asp:TextBox ID="txtUnidadesModificar" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtUnidadesModificar" ErrorMessage="*Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style68">
                            &nbsp;</td>
                        <td class="auto-style66">
                            &nbsp;</td>
                        <td class="auto-style35">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style29">
                            &nbsp;</td>
                        <td class="auto-style55">
                            <asp:Label ID="lblMensajeIngreso" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style44">Precio Unitario</td>
                        <td class="auto-style58">
                            <strong>:</strong></td>
                        <td class="auto-style62">
                            <asp:TextBox ID="txtPrecioModificar" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="auto-style67">
                            &nbsp;</td>
                        <td class="auto-style65">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style26">&nbsp;</td>
                        <td class="auto-style29">
                            &nbsp;</td>
                        <td class="auto-style55">
                            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" Width="111px" BackColor="#1F366B" BorderColor="White" BorderWidth="1px" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="auto-style56">
                            &nbsp;</td>
                        <td class="auto-style62">
                            <asp:Label ID="lblMensajeModificar" runat="server" Text="[lblMensaje]" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style67">
                            &nbsp;</td>
                        <td class="auto-style65">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style70"></td>
                        <td class="auto-style79">
                            </td>
                        <td class="auto-style72">
                        </td>
                        <td class="auto-style78">
                        </td>
                        <td class="auto-style80">
                        </td>
                        <td class="auto-style75">
                            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" Width="116px" BackColor="#1F366B" BorderColor="White" BorderWidth="1px" Font-Bold="True" Font-Italic="True" ForeColor="White" />
                        </td>
                        <td class="auto-style76">
                        </td>
                        <td class="auto-style77">
                        </td>
                        <td class="auto-style78">
                        </td>
                    </tr>
                </table>
            </asp:Content>

