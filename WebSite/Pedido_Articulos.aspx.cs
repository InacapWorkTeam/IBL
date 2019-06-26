using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;

public partial class Pedido_Articulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void btnListar_Click1(object sender, EventArgs e)
    {
   
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        if (!(txtId.Text == ""))
        {

            objPedidoArticulos.Id_pedido_articulos = int.Parse(txtId.Text);

            objPedidoArticulos.listar(objPedidoArticulos);

            if (objPedidoArticulos.Exito)
            {
                tblListado.DataSource = objPedidoArticulos.Ds;
                tblListado.DataBind();
                limpiar();

            }
            else
            {
                lblMensaje.Text = objPedidoArticulos.Mensaje;
                lblMensaje.Visible = true;

            }

        }
        else
        {
            lblMensaje.Text = "No se puede listar con el campo vacío";
            lblMensaje.Visible = true;

        }
    }

    protected void btnListarPorPedido_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();


        if (!(txtIdPedido.Text == ""))
        {
            objPedidoArticulos.Id_pedido = int.Parse(txtIdPedido.Text);

            objPedidoArticulos.listarPorPedido(objPedidoArticulos);

            if (objPedidoArticulos.Exito)
            {
                tblListado.DataSource = objPedidoArticulos.Ds;
                tblListado.DataBind();
                limpiar();
            }

        }
        else
        {
            lblMensajeListaPedido.Text = "No se puede listar con el campo vacío";
            lblMensajeListaPedido.Visible = true;
        }
    }


    public void limpiar()
    {
        txtId.Text = "";
        txtIdPedido.Text = "";
        lblMensajeListaPedido.Visible = false;
        lblMensaje.Visible = false;
    }
}