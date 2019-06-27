using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LibNegocio;

public partial class ListarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAviso.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pedido.aspx");
    }

    protected void btnIngresar_Click(object sender, EventArgs e) { 

        try { 
    
        PedidoN objPedido = new PedidoN();
        objPedido.Id_pedido = int.Parse(txtId.Text);
        objPedido = objPedido.listarPedido(objPedido);
        tblListado.DataSource = objPedido.Ds;
        tblListado.DataBind();
        }
        catch(Exception ex)
        {
            lblAviso.Visible = true;
            lblAviso.Text = "Excepcion capturada:   " + ex.Message;
        }
    }
}