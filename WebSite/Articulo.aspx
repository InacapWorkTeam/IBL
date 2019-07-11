<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Articulo.aspx.cs" Inherits="Articulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style10 {
            text-align: center;
        }
        .auto-style11 {
            width: 320px;
        }
        .auto-style12 {
            width: 65%;
            height: 265px;
            margin-left: 232px;
        }
        .auto-style13 {
            height: 22px;
            width: 95px;
        }
        .auto-style14 {
            width: 320px;
            height: 22px;
        }
        .auto-style15 {
            margin-left: 8px;
        }
        .auto-style16 {
            margin-left: 18px;
        }
        .auto-style17 {
            margin-left: 20px;
        }
        .auto-style18 {
            margin-left: 19px;
        }
        .auto-style19 {
            width: 95px;
        }
        .auto-style21 {
            margin-left: 346px;
        }
    .auto-style22 {
        text-align: center;
        width: 766px;
        color: #000000;
        height: 36px;
        font-size: large;
        background-color: #ED1C24;
    }
    .auto-style23 {
        margin-left: 39px;
    }
        .auto-style24 {
            margin-left: 152px;
        }
        .auto-style25 {
            width: 95px;
            height: 23px;
        }
        .auto-style26 {
            width: 320px;
            color: #000000;
            height: 23px;
        }
        .auto-style27 {
            margin-left: 48px;
        }
        .auto-style28 {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="auto-style22">
        INGRESO DE NUEVOS ARTICULOS</p>
    <p>
        <table class="auto-style12">
            <tr>
                <td class="auto-style13">Nombre :</td>
                <td class="auto-style14">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="auto-style16" Width="181px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-z &amp; A-Z]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Descripción : </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="auto-style17" Height="50px" Width="178px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-z &amp; A-Z]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Color :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtColor" runat="server" CssClass="auto-style17" Width="115px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtColor" ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-z &amp; A-Z]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Tamaño :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtTamaño" runat="server" CssClass="auto-style18" Width="114px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTamaño" ErrorMessage="SOLO LETRAS" ValidationExpression="^[a-z &amp; A-Z]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Precio :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="auto-style18" Width="116px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPrecio" ErrorMessage="SOLO NUMEROS" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Costo :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtCosto" runat="server" CssClass="auto-style16" Width="115px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="SOLO NUMEROS" ControlToValidate="txtCosto" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">Unidades : </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtUnidades" runat="server" CssClass="auto-style16" Width="50px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtUnidades" ErrorMessage="SOLO NUMEROS" ValidationExpression="^\d*\d$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style25"></td>
                <td class="auto-style26">
                    <asp:Label ID="lblMensaje" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Button ID="btnIngresar" runat="server" CssClass="auto-style15" OnClick="btnIngresar_Click" Text="INGRESAR" Width="228px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">ID :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtID" runat="server" Width="40px"></asp:TextBox>
&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtID" ErrorMessage="SOLO NUMEROS" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btnEliminar" runat="server" CssClass="auto-style23" Height="21px" Text="ELIMINAR" Width="94px" OnClick="btnEliminar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style19">Buscar :</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtBuscar" runat="server" Height="19px" Width="40px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtBuscar" ErrorMessage="SOLO NUMEROS" ValidationExpression="^[0-9]*$">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btnBuscarDato" runat="server" CssClass="auto-style27" Height="22px" Text="BUSCAR" Width="93px" OnClick="btnBuscarDato_Click" />
&nbsp;&nbsp; <span class="auto-style28">*BUSCAR POR ID*</span></td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnActualizar" runat="server" CssClass="auto-style21" OnClick="btnActualizar_Click" Text="ACTUALIZAR TABLA" Width="315px" />
    </p>
    <p>
        <asp:GridView ID="dgListar" runat="server" CellPadding="4" CssClass="auto-style24" EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="624px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

