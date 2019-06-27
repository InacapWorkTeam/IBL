using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Data;
using System.Text.RegularExpressions;

public partial class EliminarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAviso.Visible = false;

        if (!IsPostBack)
        {
            definirDropListPedido();
            
        }
    }

    private void definirDropListPedido()
    {
        PedidoN objPedido = new PedidoN();
        objPedido.listarPedido(objPedido);

        if (objPedido.Exito)
        {
            foreach (DataRow row in objPedido.Ds.Tables[0].Rows)
            {
                DropPedido.Items.Add(Convert.ToString(row[0]) + ". " + Convert.ToString(row[1])+" - $" + Convert.ToString(row[2]));

            }
        }
        else
        {
            lblAviso.Text = objPedido.Mensaje;
            lblAviso.Visible = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pedido.aspx");
    }
    public string regexNumerico(string input)
    {
        string output;

        output = Regex.Replace(input, @"[^\d]", "");

        return output;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        PedidoN objPedido = new PedidoN();

        if (DropPedido.SelectedIndex == 0)
        {
            //No hacer nada
        }
        else
        {
            objPedido.Id_pedido = Convert.ToInt32(regexNumerico(DropPedido.SelectedItem.ToString().Substring(0, 1)));
            objPedido.eliminar(objPedido);

            if (objPedido.Exito)
            {
                lblAviso.Text = "Se ha eliminado el registro exitosamente";
                lblAviso.Visible = true;
                if (!IsPostBack)
                {
                    definirDropListPedido();

                }
            }
            else
            {
                lblAviso.Text = objPedido.Mensaje;
                lblAviso.Visible = true;
            }

        }
    }
}