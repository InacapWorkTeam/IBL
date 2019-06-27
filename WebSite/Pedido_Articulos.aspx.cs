﻿using System;
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
        //Impide que se vuelva a cargar datos en los dropList
        if (!IsPostBack)
        {
            definirDropListIDPedidos();
            definirDropListArticulos();
            definirDropListPedidoArticulos();

        }
    }


    /// <summary>
    /// Listener botón Listar que despliega la lista de todos los registros o con criterio por ID
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnListar_Click1(object sender, EventArgs e)
    {
   
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Validación de campo para el txtId
        if (!(txtId.Text == ""))
        {
            //Parseo
            objPedidoArticulos.Id_pedido_articulos = int.Parse(txtId.Text);

            //llamado al método para listar el la capa de negocio
            objPedidoArticulos.listar(objPedidoArticulos);

            //Validación de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //Se define el gridview con los datos de retorno
                tblListado.DataSource = objPedidoArticulos.Ds;
                tblListado.DataBind();
                limpiar();

            }
            else
            {
                //En caso contrario se infroma error
                lblMensaje.Text = objPedidoArticulos.Mensaje;
                lblMensaje.Visible = true;

            }

        }
        else
        {
            //Si el campo esta vacio se informa
            lblMensaje.Text = "No se puede listar con el campo vacío";
            lblMensaje.Visible = true;

        }
    }//Fin btnListar


    /// <summary>
    /// Listener boton listar por id pedido
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnListarPorPedido_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Validación de campo vacío
        if (!(txtIdPedido.Text == ""))
        {
            //Parseo
            objPedidoArticulos.Id_pedido = int.Parse(txtIdPedido.Text);

            //Llamado al método para listar por pedido en la capa de negocio
            objPedidoArticulos.listarPorPedido(objPedidoArticulos);

            //Validacion de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //Se define el data view
                tblListado.DataSource = objPedidoArticulos.Ds;
                tblListado.DataBind();
                limpiar();
            }
            else
            {
                //En caso contrario se informa
                lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
                lblMensajeListaPedido.Visible = true;

            }

        }
        else
        {
            //Si esl campo esta vacío se informa
            lblMensajeListaPedido.Text = "No se puede listar con el campo vacío";
            lblMensajeListaPedido.Visible = true;
        }
    }//Fin btnListarPorPedido


    /// <summary>
    /// Método que limpia campos de texto y labels de mensaje
    /// </summary>
    public void limpiar()
    {
        txtId.Text = "";
        txtIdPedido.Text = "";
        lblMensajeListaPedido.Visible = false;
        lblMensaje.Visible = false;
    }//Fin limpiar


    #region Listar

    /// <summary>
    /// Método para definir los items del droplistIDPedidos
    /// </summary>
    public void definirDropListIDPedidos()
    {

        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Llamado al método de la capa de negocio
        objPedidoArticulos.listarPedidosListBox(objPedidoArticulos);

        //Validación de proceso exitoso
        if (objPedidoArticulos.Exito)
        {
            //Definición del primer item
            dropListIDPedidoModificar.Items.Add("-- Seleccione un item --");

            DataSet ds = objPedidoArticulos.Ds;

            //Definición de los items que contendran el droplist Pedidos y IDPedidosModificar
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                dropListPedidos.Items.Add(Convert.ToString(row[0]));
                dropListIDPedidoModificar.Items.Add(Convert.ToString(row[0]));
            }
        
        }
        else
        {
            //En caso contrario se informa
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }

    }//Fin definirDropListIDPedido

     
    /// <summary>
    /// Método para definir los items del DropListArticulos que contiene los registros de articulos en la BD
    /// </summary>
    public void definirDropListArticulos()
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Llamado al método en la capa de negocio
        objPedidoArticulos.listarArticulosDropList(objPedidoArticulos);

        //Se define el primer item
        droplistArticulos.Items.Add("-- Seleccione un item --");
        dropListArticuloModificar.Items.Add("--Seleccione un item--");

        //Validacion de proceso exitoso
        if (objPedidoArticulos.Exito)
        {
           
            //Definicion de los items de droplistArticulos y dropListArticulosModificar
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                droplistArticulos.Items.Add(Convert.ToString(row[0])+". "+Convert.ToString(row[1]));
                dropListArticuloModificar.Items.Add(Convert.ToString(row[0]) + ". " + Convert.ToString(row[1]));
            }

        }
        else
        {
            //En caso contrario se informa
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }

    }//Fin definirDropListArticulos


    /// <summary>
    /// Método que define los items para dropListPedidoArticulos según los registros de la BD
    /// </summary>
    public void definirDropListPedidoArticulos()
    {

        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //ID_pedido_articulos es definido para poder listar todos los registros
        objPedidoArticulos.Id_pedido_articulos = 0;

        //Llamado al método en la capa de negocio
        objPedidoArticulos.listar(objPedidoArticulos);

        //Se define el primer item del droplist
        dropListIDPedidoArticulosModificar.Items.Add("-- Seleccionar item -- ");

        //Idem
        dropListIDPedidoArticulosEliminar.Items.Add("-- Seleccionar item -- ");

        //Validación de proceso exitoso
        if (objPedidoArticulos.Exito)
        {

            //Definición de items para los dropListIDPedidoArticulosModificar y ..Eliminar
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                dropListIDPedidoArticulosModificar.Items.Add(Convert.ToString(row[0]));

                dropListIDPedidoArticulosEliminar.Items.Add(Convert.ToString(row[0]));
            }

        }
        else
        {
            //En caso contrario se informa
            lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
            lblMensajeModificar.Visible = true;

        }

    }//Fin definirDroplistArticulos

    /// <summary>
    /// Listener de droplistArticulos el cual carga los datos asociados Articulos en 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void droplistArticulos_SelectedIndexChanged(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        string articulo = droplistArticulos.SelectedItem.ToString();
        //Parseo
        objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(articulo));
        objPedidoArticulos.listarDatosArticulo(objPedidoArticulos);

        //Validación de proceso exitoso
        if (objPedidoArticulos.Exito)
        {
            //Llenado automatico de los campos de texto
            foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
            {
                txtColor.Text = Convert.ToString(row[3]);
                txtTamano.Text = Convert.ToString(row[4]);
                txtPrecio.Text = Convert.ToString(row[5]);
            } 
        }
        else
        {
            //En caso contrario se informa
            lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
            lblMensajeListaPedido.Visible = true;

        }
       
    }//Fin definirDroplistArticulos

    /// <summary>
    /// Listener botón ingresar el cual carga los datos ingresados en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Se valida que el campo no se encuentre vacio
        if (!(txtUnidades.Text.Trim().Equals("")))
        {
            //Parseo
            objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListPedidos.SelectedItem.ToString());
            objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(droplistArticulos.SelectedItem.ToString()));
            objPedidoArticulos.Tamano_articulo = txtTamano.Text;
            objPedidoArticulos.Color_articulo = txtColor.Text;
            objPedidoArticulos.Unidades_articulo = Convert.ToInt32(txtUnidades.Text);
            objPedidoArticulos.Precio_u_articulo = Convert.ToInt32(txtPrecio.Text);

            //LLamado al método en la capa de negocio
            objPedidoArticulos.ingresar(objPedidoArticulos);

            //Validación de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //En caso de exito se informa y se limpian los campos
                lblMensajeIngreso.Text = "Se ha ingresado el articulo al pedido exitosamente";
                lblMensajeIngreso.Visible = true;
                txtTamano.Text = "";
                txtColor.Text = "";
                txtUnidades.Text = "";
                txtPrecio.Text = "";

            }else
            {
                //Caso contrario se informa
                lblMensajeIngreso.Text = "No pueden quedar campos vacios";
                lblMensajeIngreso.Visible = true;
            }

        }
        else
        {
            //Caso contrario se informa
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

        //Validacion de la seleccion del dropList
        if (dropListIDPedidoArticulosModificar.SelectedIndex == 0)
        {
            //Se es el primer item
            //No hacer nada

        }
        else
        {
            //Caso contrario se obtienen los datos correspondientes
            objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(regexNumerico(pedido_articulo));

            //Llamado al método en la capa de negocio
            objPedidoArticulos.listar(objPedidoArticulos);

            //Validación de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //Se cargan los datos correspondientes al registro seleccionado
                foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
                {
                    txtTamanoModificar.Text = Convert.ToString(row[3]);
                    txtColorModificar.Text = Convert.ToString(row[4]);
                    txtUnidadesModificar.Text = Convert.ToString(row[5]);
                    txtPrecioModificar.Text = Convert.ToString(row[6]);

                }
            }
            else
            {
                //Caso contrario se informa
                lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
                lblMensajeModificar.Visible = true;

            }
        }
    }//Fin Listener dropListArticuloModificar


    /// <summary>
    /// Listener de la selección del dropListArticuloModificar el cual carga los datos asociados al articulo en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dropListArticuloModificar_SelectedIndexChanged(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Validación de selección dropList
        if (dropListArticuloModificar.SelectedIndex == 0)
        {
            //En caso de ser seleccionado el primer item
            //No hacer nada
        }
        else
        {
            //Parseo de datos
            string articulo = dropListArticuloModificar.SelectedItem.ToString();

            objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(articulo));

            //Llamado al método en la capa de negocio
            objPedidoArticulos.listarDatosArticulo(objPedidoArticulos);

            //Validación de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //Se cargan los datos asociados al id_articulo seleccionado
                foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
                {
                    txtColorModificar.Text = Convert.ToString(row[3]);
                    txtTamanoModificar.Text = Convert.ToString(row[4]);
                    txtPrecioModificar.Text = Convert.ToString(row[5]);
                }
            }
            else
            {
                //Caso contrario se informa
                lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
                lblMensajeModificar.Visible = true;

            }

        }
    }//Fin Listener dropListArticuloModificar

    /// <summary>
    /// Listener del botón para modificar un registro en la tabla Pedido_Articulos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Validación si el campo se encuentra vacio
        if (!(txtUnidadesModificar.Text.Trim().Equals(""))) {
            
            //Parseo de datos
            objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosModificar.SelectedItem.ToString());
            objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListIDPedidoModificar.SelectedItem.ToString());
            objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(dropListArticuloModificar.SelectedItem.ToString()));
            objPedidoArticulos.Tamano_articulo = txtTamanoModificar.Text;
            objPedidoArticulos.Color_articulo = txtColorModificar.Text;
            objPedidoArticulos.Unidades_articulo = Convert.ToInt32(txtUnidadesModificar.Text);
            objPedidoArticulos.Precio_u_articulo = Convert.ToInt32(txtPrecioModificar.Text);

            //Llamado al método
            objPedidoArticulos.modificar(objPedidoArticulos);

            //Validación de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //Se informa exito
                lblMensajeModificar.Text = "Se ha modificado exitosamente";
                lblMensajeModificar.Visible = true;

            }else
            {
                //Caso contrario se informa
                lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
                lblMensajeModificar.Visible = true;
            }


        }
        else
        {
            //Caso contrario se informa
            lblMensajeModificar.Text = "No pueden quedar campos vacios";
            lblMensajeModificar.Visible = true;
        }

    }//Fin Listener btnModificar


    #endregion


    #region Eliminar
    /// <summary>
    /// Listener botón eliminar 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Se valida la selección de item del dropList
        if (dropListIDPedidoArticulosEliminar.SelectedIndex == 0)
        {
            //No hacer nada
        }
        else
        {
            //Parseo
            objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosEliminar.SelectedItem.ToString());

            //Llamado al método
            objPedidoArticulos.eliminar(objPedidoArticulos);

            //Validación de proceso exitoso
            if (objPedidoArticulos.Exito)
            {
                //Se informa
                lblMensajeEliminar.Text = "Se ha eliminado el registro exitosamente";
                lblMensajeEliminar.Visible = true;
            }
            else
            {
                //Caso contrario se informa
                lblMensajeEliminar.Text = objPedidoArticulos.Mensaje;
                lblMensajeEliminar.Visible = true;
            }

        }

    }//Fin Listener btnEliminar

    #endregion


    /// <summary>
    /// Metodo que devuelve solo los valores numericos de un string
    /// </summary>
    /// <param name="input">String a procesar</param>
    /// <returns>El valor numerico que contiene el string</returns>
    public string regexNumerico(string input)
    {
        string output;

        //Se realiza un análisis de Regex al string enviado y se declara el resultado en otra variable
        output = Regex.Replace(input, @"[^\d]", ""); 

        return output;
    }//Fin regexNumerio


}//Fin Pedido_Articulos