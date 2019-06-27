using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Data;
using System.Text.RegularExpressions;

public partial class Pedido_Articulos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            definirDropListIDPedidos();
            definirDropListArticulos();
            definirDropListPedidoArticulos();

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


    #region Listar
    public void definirDropListIDPedidos()
    {

        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        objPedidoArticulos.listarPedidosListBox(objPedidoArticulos);

        if (objPedidoArticulos.Exito)
        {

            dropListIDPedidoModificar.Items.Add("-- Seleccione un item --");

            DataSet ds = objPedidoArticulos.Ds;
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                dropListPedidos.Items.Add(Convert.ToString(row[0]));
                dropListIDPedidoModificar.Items.Add(Convert.ToString(row[0]));
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


        droplistArticulos.Items.Add("-- Seleccione un item --");
        dropListArticuloModificar.Items.Add("--Seleccione un item--");

        if (objPedidoArticulos.Exito)
        {
           
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                droplistArticulos.Items.Add(Convert.ToString(row[0])+". "+Convert.ToString(row[1]));
                dropListArticuloModificar.Items.Add(Convert.ToString(row[0]) + ". " + Convert.ToString(row[1]));
            }

        }
        else
        {
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }

    }


    public void definirDropListPedidoArticulos()
    {

        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        objPedidoArticulos.Id_pedido_articulos = 0;

        objPedidoArticulos.listar(objPedidoArticulos);


        dropListIDPedidoArticulosModificar.Items.Add("-- Seleccionar item -- ");

        dropListIDPedidoArticulosEliminar.Items.Add("-- Seleccionar item -- ");

        if (objPedidoArticulos.Exito)
        {

            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                dropListIDPedidoArticulosModificar.Items.Add(Convert.ToString(row[0]));

                dropListIDPedidoArticulosEliminar.Items.Add(Convert.ToString(row[0]));
            }

        }
        else
        {
            lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
            lblMensajeModificar.Visible = true;

        }

    }

    /// <summary>
    /// Listener de droplistArticulos el cual carga los datos asociados Articulos en 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void droplistArticulos_SelectedIndexChanged(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        string articulo = droplistArticulos.SelectedItem.ToString();

        objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(articulo));
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

    /// <summary>
    /// Listener botón ingresar el cual carga los datos ingresados en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        if (!(txtUnidades.Text.Trim().Equals("")))
        {

            objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListPedidos.SelectedItem.ToString());
            objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(droplistArticulos.SelectedItem.ToString()));
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

                lblMensajeIngreso.Text = "No pueden quedar campos vacios";
                lblMensajeIngreso.Visible = true;
            }

        }
        else
        {
            lblMensajeIngreso.Text = "No pueden quedar campos vacios";
            lblMensajeIngreso.Visible = true;
        }

    }

    #endregion

    #region Modificar

    /// <summary>
    /// Listener de dropListIDPedidoArticulosModificar el cual precarga los datos en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dropListIDPedidoArticulosModificar_SelectedIndexChanged(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        string pedido_articulo = dropListIDPedidoArticulosModificar.SelectedItem.ToString();

        if (dropListIDPedidoArticulosModificar.SelectedIndex == 0)
        {
          //  lblMensajeModificar.Text = "Seleccionar un ID Pedido Articulo Válido";
            //lblMensajeModificar.Visible = true;
        }
        else
        {
            objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(regexNumerico(pedido_articulo));
            objPedidoArticulos.listar(objPedidoArticulos);


            if (objPedidoArticulos.Exito)
            {

                foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
                {
                    txtTamanoModificar.Text = Convert.ToString(row[3]);
                    txtColorModificar.Text = Convert.ToString(row[4]);
                    txtUnidadesModificar.Text = Convert.ToString(row[5]);
                    txtPrecioModificar.Text = Convert.ToString(row[6]);


                    //dropListArticuloModificar.Items.FindByText(Convert.ToString(row[2])).Selected = true;
                }
            }
            else
            {
                lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
                lblMensajeModificar.Visible = true;

            }
        }
    }


    /// <summary>
    /// Listener de la selección del dropListArticuloModificar el cual carga los datos asociados al articulo en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dropListArticuloModificar_SelectedIndexChanged(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        if (dropListArticuloModificar.SelectedIndex == 0)
        {

            //No hacer nada
        }
        else
        {
            string articulo = dropListArticuloModificar.SelectedItem.ToString();

            objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(articulo));
            objPedidoArticulos.listarDatosArticulo(objPedidoArticulos);

            if (objPedidoArticulos.Exito)
            {

                foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
                {
                    txtColorModificar.Text = Convert.ToString(row[3]);
                    txtTamanoModificar.Text = Convert.ToString(row[4]);
                    txtPrecioModificar.Text = Convert.ToString(row[5]);
                }
            }
            else
            {
                lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
                lblMensajeModificar.Visible = true;

            }

        }
    }

    /// <summary>
    /// Listener del botón para modificar un registro en la tabla Pedido_Articulos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        if (!(txtUnidadesModificar.Text.Trim().Equals(""))) {

            objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosModificar.SelectedItem.ToString());
            objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListIDPedidoModificar.SelectedItem.ToString());
            objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(dropListArticuloModificar.SelectedItem.ToString()));
            objPedidoArticulos.Tamano_articulo = txtTamanoModificar.Text;
            objPedidoArticulos.Color_articulo = txtColorModificar.Text;
            objPedidoArticulos.Unidades_articulo = Convert.ToInt32(txtUnidadesModificar.Text);
            objPedidoArticulos.Precio_u_articulo = Convert.ToInt32(txtPrecioModificar.Text);


            objPedidoArticulos.modificar(objPedidoArticulos);

            if (objPedidoArticulos.Exito)
            {

                lblMensajeModificar.Text = "Se ha modificado exitosamente";
                lblMensajeModificar.Visible = true;

            }else
            {
                lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
                lblMensajeModificar.Visible = true;
            }


        }
        else
        {
            lblMensajeModificar.Text = "No pueden quedar campos vacios";
            lblMensajeModificar.Visible = true;
        }

    }


    #endregion


    #region Eliminar

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        if (dropListIDPedidoArticulosEliminar.SelectedIndex == 0)
        {
            //No hacer nada
        }
        else
        {
            objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosEliminar.SelectedItem.ToString());
            objPedidoArticulos.eliminar(objPedidoArticulos);

            if (objPedidoArticulos.Exito)
            {
                lblMensajeEliminar.Text = "Se ha eliminado el registro exitosamente";
                lblMensajeEliminar.Visible = true;
            }
            else
            {
                lblMensajeEliminar.Text = objPedidoArticulos.Mensaje;
                lblMensajeEliminar.Visible = true;
            }

        }

    }

    #endregion





    /// <summary>
    /// Metodo que devuelve solo los valores numericos de un string
    /// </summary>
    /// <param name="input">String a procesar</param>
    /// <returns>El valor numerico que contiene el string</returns>
    public string regexNumerico(string input)
    {
        string output;

        output = Regex.Replace(input, @"[^\d]", ""); 

        return output;
    }


}