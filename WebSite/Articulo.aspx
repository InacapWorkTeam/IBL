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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-4" style="left: 254px; top: 0px; width: 719px">
            <p>
                &nbsp;<table style="width: 65%;">
                    <tr>
                        <td style="width: 99px">Nombre :</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">Descripcion :</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">Color :</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">Tamaño :</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtTamaño" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">Precio :</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrecio" ErrorMessage="* Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">Coto unitario:</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCosto" ErrorMessage="* Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">Unidades :</td>
                        <td style="width: 328px">
                            <asp:TextBox ID="txtUnidades" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUnidades" ErrorMessage="* Solo numeros" ValidationExpression="^\d*\d$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">&nbsp;</td>
                        <td style="width: 328px">
                            <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">&nbsp;</td>
                        <td style="width: 328px">
                            <asp:Button ID="btnIngresar" runat="server" Text="GUARDAR" Width="126px" OnClick="btnIngresar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">&nbsp;</td>
                        <td style="width: 328px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 99px">&nbsp;</td>
                        <td style="width: 328px">
                            <asp:Button ID="btnActualizarDatos" runat="server" OnClick="btnActualizarDatos_Click" Text="ACTUALIZAR DATOS" Width="164px" />
                        </td>
                    </tr>
                </table>
            </p>
            <p>
                &nbsp;</p>
            <table style="width: 83%;">
                <tr>
                    <td style="width: 56px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 56px">ID :</td>
                    <td>
                        <asp:TextBox ID="txtID" runat="server" Width="68px"></asp:TextBox>
                        <asp:Button ID="btnEliminar" runat="server" Height="21px" OnClick="btnEliminar_Click" style="margin-left: 50px" Text="ELIMINAR" Width="122px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 56px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 56px">Buscar :</td>
                    <td>&nbsp;<asp:TextBox ID="txtBuscar" runat="server" Width="69px"></asp:TextBox>
                        <asp:Button ID="btnBuscarDato" runat="server" Height="21px" OnClick="btnBuscarDato_Click" style="margin-left: 50px" Text="BUSCAR" Width="120px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 56px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="dgListar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="596px">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;<asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" style="margin-left: 176px" Text="ACTUALIZAR TABLA" Width="206px" />
            </p>
            <p>
                <table style="width:100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </p>
        </div>
    </div>
</asp:Content>

