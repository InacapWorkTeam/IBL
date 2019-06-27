using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Data;

public partial class Pedido_Articulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            definirDropListIDPedidos();
            definirDropListArticulos();

        }
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
            else
            {
                lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
                lblMensajeListaPedido.Visible = true;

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

    public void definirDropListIDPedidos()
    {

        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        objPedidoArticulos.listarPedidosListBox(objPedidoArticulos);

        if (objPedidoArticulos.Exito)
        {
            DataSet ds = objPedidoArticulos.Ds;
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                dropListPedidos.Items.Add(Convert.ToString(row[0]));
            }
        
        }
        else
        {
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }

    }


    public void definirDropListArticulos()
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        objPedidoArticulos.listarArticulosDropList(objPedidoArticulos);


        if (objPedidoArticulos.Exito)
        {
           
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                droplistArticulos.Items.Add(Convert.ToString(row[0])+". "+Convert.ToString(row[1]));
            }

        }
        else
        {
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }

    }

    protected void droplistArticulos_SelectedIndexChanged(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        string articulo = droplistArticulos.SelectedItem.ToString();

        objPedidoArticulos.Id_articulo = Convert.ToInt32(articulo.Substring(0, 1));
        objPedidoArticulos.listarDatosArticulo(objPedidoArticulos);

        if (objPedidoArticulos.Exito)
        {

            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                txtColor.Text = Convert.ToString(row[3]);
                txtTamano.Text = Convert.ToString(row[4]);
                txtPrecio.Text = Convert.ToString(row[5]);
            } 
        }
        else
        {
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }
       
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        if (!(txtUnidades.Text.Equals("")))
        {

            objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListPedidos.SelectedItem.ToString());
            objPedidoArticulos.Id_articulo = Convert.ToInt32(droplistArticulos.SelectedItem.ToString().Substring(0, 1));
            objPedidoArticulos.Tamano_articulo = txtTamano.Text;
            objPedidoArticulos.Color_articulo = txtColor.Text;
            objPedidoArticulos.Unidades_articulo = Convert.ToInt32(txtUnidades.Text);
            objPedidoArticulos.Precio_u_articulo = Convert.ToInt32(txtPrecio.Text);

            objPedidoArticulos.ingresar(objPedidoArticulos);

            if (objPedidoArticulos.Exito)
            {

                lblMensajeIngreso.Text = "Se ha ingresado el articulo al pedido exitosamente";
                lblMensajeIngreso.Visible = true;
                txtTamano.Text = "";
                txtColor.Text = "";
                txtUnidades.Text = "";
                txtPrecio.Text = "";

            }else
            {

                lblMensajeIngreso.Text = objPedidoArticulos.Mensaje;
                lblMensajeIngreso.Visible = true;
            }

        }
        else
        {
            lblMensajeIngreso.Text = "No pueden quedar campos vacios";
            lblMensajeIngreso.Visible = true;
        }

    }

    protected void dropListPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}