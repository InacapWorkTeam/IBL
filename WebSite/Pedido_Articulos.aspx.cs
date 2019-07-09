using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

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
        //Llamado al Contexto de la base de datos
        using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
            try {
                //Se conprueba que el dato no venga vacio
                if (!(txtId.Text == "")) {
                    //Si equivale a un numero distinto de 0 lista el registro filtrado
                    if (txtId.Text != "0") {
                        //Instanciacio de entidad
                        tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();
                        objPedidoArticulos.id_pedido_articulos = int.Parse(txtId.Text);
                        //Guarda los registros en una variable
                        var filtro = db.tblPedido_Articulos.Find(objPedidoArticulos.id_pedido_articulos);
                   
                        //Se ingresan los registros obtenidos en una lista accesible por el DataSource
                        tblListado.DataSource = new List<tblPedido_Articulos> { filtro };
                        tblListado.DataBind();
                        //Si equivale a 0 lista todos los registros de la tabla
                    } else if (txtId.Text == "0") {
                        //Obtiene todos los registros de la tabla
                        var listado = db.tblPedido_Articulos;
                        //Instancia un nuevo objeto List para guardar los registros
                        List<tblPedido_Articulos> array = new List<tblPedido_Articulos> { };
                        //Se recorren los resultados de la consulta
                        foreach (var objPedido_Articulos in listado) {
                            //Se añade cada registro al List
                            array.Add(objPedido_Articulos);
                        }

                        //Se ingresan los registros obtenidos de una lista accesible por el DataSource
                        tblListado.DataSource = array;
                        tblListado.DataBind();
                    }//Fin Else-IF
                }//Fin IF
            } catch (Exception ex) {
                lblMensaje.Text = "" + ex;
                lblMensaje.Visible = true;
            }//Fin Try-Catch
           
        }//Fin using

        #region deprecated

        //Validación de campo para el txtId
        //if (!(txtId.Text == ""))
        //{


        //    //Parseo
        //    objPedidoArticulos.Id_pedido_articulos = int.Parse(txtId.Text);

        //    //llamado al método para listar el la capa de negocio
        //    objPedidoArticulos.listar(objPedidoArticulos);

        //    //Validación de proceso exitoso
        //    if (objPedidoArticulos.Exito)
        //    {
        //        //Se define el gridview con los datos de retorno
        //        tblListado.DataSource = objPedidoArticulos.Ds;
        //        tblListado.DataBind();
        //        limpiar();

        //    }
        //    else
        //    {
        //        //En caso contrario se infroma error
        //        lblMensaje.Text = objPedidoArticulos.Mensaje;
        //        lblMensaje.Visible = true;

        //    }

        //}
        //else
        //{
        //    //Si el campo esta vacio se informa
        //    lblMensaje.Text = "No se puede listar con el campo vacío";
        //    lblMensaje.Visible = true;

        //}

        #endregion

    }//Fin btnListar


    /// <summary>
    /// Listener boton listar por id pedido
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnListarPorPedido_Click(object sender, EventArgs e)
    {
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
              
                //Se valida que el campo de text no se encuentre vacío
                if (txtIdPedido.Text != "") {
                    //Instanciación de la entidad
                    tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();
                    //Parseo del id_pedido a buscar
                    objPedidoArticulos.id_pedido = int.Parse(txtIdPedido.Text);

                    //Se realiza una consulta a un procedimiento almacenado mediante el uso del EntityFramework para obtener los registros por id_pedido
                    var filtroPedido = db.Database.SqlQuery<tblPedido_Articulos>("pa_listarPedidoArticulosPorPedido @id_pedido",
                        new SqlParameter("@id_pedido", objPedidoArticulos.id_pedido));

                    //Instanciación de un arreglo
                    List<tblPedido_Articulos> array = new List<tblPedido_Articulos> { };

                    //Recorrido de la consulta
                    foreach (var objPedidoArticulo in filtroPedido) {
                        //Ingreso de los registros al arreglo
                        array.Add(objPedidoArticulo);
                    }

                    //Definición del datasource con el arreglo con sus atributos
                    tblListado.DataSource = array;
                    tblListado.DataBind();
                }//Fin IF
            }//Fin using

        } catch (Exception ex) {
            lblMensajeListaPedido.Text = ex.Message;
            lblMensajeListaPedido.Visible = true;

        }//Fin try-catch


        #region deprecated
        // PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Validación de campo vacío
        // if (!(txtIdPedido.Text == ""))
        // {
        //Parseo
        //   objPedidoArticulos.Id_pedido = int.Parse(txtIdPedido.Text);

        //Llamado al método para listar por pedido en la capa de negocio
        //   objPedidoArticulos.listarPorPedido(objPedidoArticulos);

        //Validacion de proceso exitoso
        //   if (objPedidoArticulos.Exito)
        //   {
        //Se define el data view
        //        tblListado.DataSource = objPedidoArticulos.Ds;
        //      tblListado.DataBind();
        //      limpiar();
        //  }
        // else
        // {
        //En caso contrario se informa
        //      lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
        //     lblMensajeListaPedido.Visible = true;

        //   }

        //  }
        //  else
        // {
        //Si esl campo esta vacío se informa
        //     lblMensajeListaPedido.Text = "No se puede listar con el campo vacío";
        //     lblMensajeListaPedido.Visible = true;
        // }
        #endregion


    }//Fin btnListarPorPedido


    /// <summary>
    /// Método que limpia campos de texto y labels de mensaje
    /// 
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
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
                //Definición del primer item
                dropListIDPedidoModificar.Items.Add("-- Seleccione un item --");

                var listaIDPedido = db.tblPedido;

                foreach (var objPedido in listaIDPedido) {
                    dropListPedidos.Items.Add(objPedido.id_pedido + "");
                    dropListIDPedidoModificar.Items.Add(objPedido.id_pedido + "");
                }

            }

        } catch (Exception ex) {
            lblMensajeListaPedido.Text = ""+ex;
            lblMensajeListaPedido.Visible = true;
        }

        #region deprecated
        //    PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        ////Llamado al método de la capa de negocio
        //objPedidoArticulos.listarPedidosListBox(objPedidoArticulos);

        ////Validación de proceso exitoso
        //if (objPedidoArticulos.Exito)
        //{
        //    //Definición del primer item
        //    dropListIDPedidoModificar.Items.Add("-- Seleccione un item --");

        //    DataSet ds = objPedidoArticulos.Ds;

        //    //Definición de los items que contendran el droplist Pedidos y IDPedidosModificar
        //    foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
        //    {
        //        dropListPedidos.Items.Add(Convert.ToString(row[0]));
        //        dropListIDPedidoModificar.Items.Add(Convert.ToString(row[0]));
        //    }

        //}
        //else
        //{
        //    //En caso contrario se informa
        //    lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
        //    lblMensajeListaPedido.Visible = true;

        //}
        #endregion
    }//Fin definirDropListIDPedido


    /// <summary>
    /// Método para definir los items del DropListArticulos que contiene los registros de articulos en la BD
    /// </summary>
    public void definirDropListArticulos()
    {
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                var listaArticulos = db.tblArticulo;
                //Se define el primer item
                droplistArticulos.Items.Add("-- Seleccione un item --");
                dropListArticuloModificar.Items.Add("--Seleccione un item--");

                foreach (var objArticulo in listaArticulos) {

                    droplistArticulos.Items.Add(objArticulo.id_articulo + ". " + objArticulo.nombre);
                    dropListArticuloModificar.Items.Add(objArticulo.id_articulo + ". " + objArticulo.nombre);

                }
            }
        } catch (Exception ex) {
            lblMensajeIngreso.Text = "" + ex;
            lblMensajeIngreso.Visible = true;
        }

        #region deprecated
        //    PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        ////Llamado al método en la capa de negocio
        //objPedidoArticulos.listarArticulosDropList(objPedidoArticulos);

        ////Se define el primer item
        //droplistArticulos.Items.Add("-- Seleccione un item --");
        //dropListArticuloModificar.Items.Add("--Seleccione un item--");

        ////Validacion de proceso exitoso
        //if (objPedidoArticulos.Exito)
        //{

        //    //Definicion de los items de droplistArticulos y dropListArticulosModificar
        //    foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
        //    {
        //        droplistArticulos.Items.Add(Convert.ToString(row[0])+". "+Convert.ToString(row[1]));
        //        dropListArticuloModificar.Items.Add(Convert.ToString(row[0]) + ". " + Convert.ToString(row[1]));
        //    }

        //}
        //else
        //{
        //    //En caso contrario se informa
        //    lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
        //    lblMensajeListaPedido.Visible = true;

        //}
        #endregion
    }//Fin definirDropListArticulos


    /// <summary>
    /// Método que define los items para dropListPedidoArticulos según los registros de la BD
    /// </summary>
    public void definirDropListPedidoArticulos()
    {
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                var listaPedidoArticulo = db.tblPedido_Articulos;

                //Se define el primer item del droplist
                dropListIDPedidoArticulosModificar.Items.Add("-- Seleccionar item -- ");

                //Idem
                dropListIDPedidoArticulosEliminar.Items.Add("-- Seleccionar item -- ");

                foreach (var objPedidoArticulos in listaPedidoArticulo) {

                    dropListIDPedidoArticulosModificar.Items.Add(objPedidoArticulos.id_pedido_articulos + "");

                    dropListIDPedidoArticulosEliminar.Items.Add(objPedidoArticulos.id_pedido_articulos + "");
                }
            }
        } catch (Exception ex) {
            lblMensajeModificar.Text = "" + ex;
            lblMensajeModificar.Visible = true;
        }

        #region deprecated
        //  PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        ////ID_pedido_articulos es definido para poder listar todos los registros
        //objPedidoArticulos.Id_pedido_articulos = 0;

        ////Llamado al método en la capa de negocio
        //objPedidoArticulos.listar(objPedidoArticulos);

        ////Se define el primer item del droplist
        //dropListIDPedidoArticulosModificar.Items.Add("-- Seleccionar item -- ");

        ////Idem
        //dropListIDPedidoArticulosEliminar.Items.Add("-- Seleccionar item -- ");

        ////Validación de proceso exitoso
        //if (objPedidoArticulos.Exito)
        //{

        //    //Definición de items para los dropListIDPedidoArticulosModificar y ..Eliminar
        //    foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
        //    {
        //        dropListIDPedidoArticulosModificar.Items.Add(Convert.ToString(row[0]));

        //        dropListIDPedidoArticulosEliminar.Items.Add(Convert.ToString(row[0]));
        //    }

        //}
        //else
        //{
        //    //En caso contrario se informa
        //    lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
        //    lblMensajeModificar.Visible = true;

        //}
        #endregion
    }//Fin definirDroplistArticulos

    /// <summary>
    /// Listener de droplistArticulos el cual carga los datos asociados Articulos en 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void droplistArticulos_SelectedIndexChanged(object sender, EventArgs e)
    {

        try{
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();
                tblArticulo objArticulos = new tblArticulo();

                string articulo = droplistArticulos.SelectedItem.ToString();

                objArticulos.id_articulo = Convert.ToInt32(regexNumerico(articulo));

                var listaArticulo = db.tblArticulo.Find(objArticulos.id_articulo);

                txtColor.Text = listaArticulo.color;
                txtTamano.Text = listaArticulo.tamano;
                txtPrecio.Text = listaArticulo.precio + "";

            }
        } catch (Exception ex) {
            lblMensajeIngreso.Text = ex.Message;
            lblMensajeIngreso.Visible = true;
        }
        #region deprecated
        //PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //string articulo = droplistArticulos.SelectedItem.ToString();
        //Parseo
        //objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(articulo));

        //objPedidoArticulos.listarDatosArticulo(objPedidoArticulos);

        ////Validación de proceso exitoso
        //if (objPedidoArticulos.Exito)
        //{
        //    //Llenado automatico de los campos de texto
        //    foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
        //    {
        //        txtColor.Text = Convert.ToString(row[3]);
        //        txtTamano.Text = Convert.ToString(row[4]);
        //        txtPrecio.Text = Convert.ToString(row[5]);
        //    } 
        //}
        //else
        //{
        //    //En caso contrario se informa
        //    lblMensajeListaPedido.Text = objPedidoArticulos.Mensaje;
        //    lblMensajeListaPedido.Visible = true;

        //}
        #endregion
    }//Fin definirDroplistArticulos

    /// <summary>
    /// Listener botón ingresar el cual carga los datos ingresados en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnIngresar_Click(object sender, EventArgs e)
    {

        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();
                if (!(txtUnidades.Text.Trim().Equals(""))) {
                    objPedidoArticulos.id_pedido = Convert.ToInt32(dropListPedidos.SelectedItem.ToString());
                    objPedidoArticulos.id_articulo = Convert.ToInt32(regexNumerico(droplistArticulos.SelectedItem.ToString()));
                    objPedidoArticulos.tamano_articulo = txtTamano.Text;
                    objPedidoArticulos.color_articulo = txtColor.Text;
                    objPedidoArticulos.unidades_articulo = Convert.ToInt32(txtUnidades.Text);
                    objPedidoArticulos.precio_u_articulo = Convert.ToInt32(txtPrecio.Text);
                    objPedidoArticulos.estado = true;

                    db.tblPedido_Articulos.Add(objPedidoArticulos);
                    db.SaveChanges();

                    lblMensajeIngreso.Text = "Se ha ingresado el articulo al pedido exitosamente";
                    lblMensajeIngreso.Visible = true;
                    txtTamano.Text = "";
                    txtColor.Text = "";
                    txtUnidades.Text = "";
                    txtPrecio.Text = "";
                } else {
                    //Caso contrario se informa
                    lblMensajeIngreso.Text = "No pueden quedar campos vacios";
                    lblMensajeIngreso.Visible = true;
                }
            }
        }catch(Exception ex) {
            lblMensajeIngreso.Text = ex.Message;
            lblMensajeIngreso.Visible = true;
        }

        #region deprecated
        // PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Se valida que el campo no se encuentre vacio
        // if (!(txtUnidades.Text.Trim().Equals("")))
        // {
        //Parseo
        //objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListPedidos.SelectedItem.ToString());
        //objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(droplistArticulos.SelectedItem.ToString()));
        //objPedidoArticulos.Tamano_articulo = txtTamano.Text;
        //objPedidoArticulos.Color_articulo = txtColor.Text;
        //objPedidoArticulos.Unidades_articulo = Convert.ToInt32(txtUnidades.Text);
        //objPedidoArticulos.Precio_u_articulo = Convert.ToInt32(txtPrecio.Text);

        //LLamado al método en la capa de negocio
        //    objPedidoArticulos.ingresar(objPedidoArticulos);

        //    //Validación de proceso exitoso
        //    if (objPedidoArticulos.Exito)
        //    {
        //        //En caso de exito se informa y se limpian los campos
        //        lblMensajeIngreso.Text = "Se ha ingresado el articulo al pedido exitosamente";
        //        lblMensajeIngreso.Visible = true;
        //        txtTamano.Text = "";
        //        txtColor.Text = "";
        //        txtUnidades.Text = "";
        //        txtPrecio.Text = "";

        //    }else
        //    {
        //        //Caso contrario se informa
        //        lblMensajeIngreso.Text = "No pueden quedar campos vacios";
        //        lblMensajeIngreso.Visible = true;
        //    }

        //}
        //else
        //{
        //    //Caso contrario se informa
        //    lblMensajeIngreso.Text = "No pueden quedar campos vacios";
        //    lblMensajeIngreso.Visible = true;
        // }
        #endregion
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
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                if (dropListIDPedidoArticulosModificar.SelectedIndex != 0) {

                    tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();

                    string pedido_articulo = dropListIDPedidoArticulosModificar.SelectedItem.ToString();
                    objPedidoArticulos.id_pedido_articulos = Convert.ToInt32(regexNumerico(pedido_articulo));

                    objPedidoArticulos = db.tblPedido_Articulos.Find(objPedidoArticulos.id_pedido_articulos);

                    txtTamanoModificar.Text = objPedidoArticulos.tamano_articulo;
                    txtColorModificar.Text = objPedidoArticulos.color_articulo;
                    txtUnidadesModificar.Text = objPedidoArticulos.unidades_articulo + "";
                    txtPrecioModificar.Text = objPedidoArticulos.precio_u_articulo + "";

                }

            }
        } catch (Exception ex) {
            lblMensajeModificar.Text = ex.Message;
            lblMensajeModificar.Visible = true;
        }

        #region deprecated
        //  PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //string pedido_articulo = dropListIDPedidoArticulosModificar.SelectedItem.ToString();

        //Validacion de la seleccion del dropList
        // if (dropListIDPedidoArticulosModificar.SelectedIndex == 0)
        //  {
        //Se es el primer item
        //No hacer nada

        //  }
        //  else
        //  {
        //Caso contrario se obtienen los datos correspondientes
        //objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(regexNumerico(pedido_articulo));

        //Llamado al método en la capa de negocio
        //  objPedidoArticulos.listar(objPedidoArticulos);

        //Validación de proceso exitoso
        // if (objPedidoArticulos.Exito)
        //  {
        //Se cargan los datos correspondientes al registro seleccionado
        //    foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
        //    {
        //        txtTamanoModificar.Text = Convert.ToString(row[3]);
        //        txtColorModificar.Text = Convert.ToString(row[4]);
        //        txtUnidadesModificar.Text = Convert.ToString(row[5]);
        //        txtPrecioModificar.Text = Convert.ToString(row[6]);

        //    }
        //}
        //else
        //  {
        //Caso contrario se informa
        //   lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
        //  lblMensajeModificar.Visible = true;

        //}
        // }

        #endregion
    }//Fin Listener dropListArticuloModificar


    /// <summary>
    /// Listener de la selección del dropListArticuloModificar el cual carga los datos asociados al articulo en el formulario
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dropListArticuloModificar_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                if (dropListArticuloModificar.SelectedIndex != 0) {

                    string articulo = dropListArticuloModificar.SelectedIndex.ToString();

                    tblArticulo objArticulo = new tblArticulo();

                    objArticulo.id_articulo = Convert.ToInt32(regexNumerico(articulo));

                    objArticulo = db.tblArticulo.Find(objArticulo.id_articulo);

                    txtColorModificar.Text = objArticulo.color;
                    txtTamanoModificar.Text = objArticulo.tamano;
                    txtPrecioModificar.Text = objArticulo.precio + "";

                }

            }
        } catch (Exception ex ) {
            lblMensajeModificar.Text = ex.Message;
            lblMensajeModificar.Visible = true;
        }

        #region deprecated
        //    PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        ////Validación de selección dropList
        //if (dropListArticuloModificar.SelectedIndex == 0)
        //{
        //    //En caso de ser seleccionado el primer item
        //    //No hacer nada
        //}
        //else
        //{
        //    //Parseo de datos
        //    string articulo = dropListArticuloModificar.SelectedItem.ToString();

        //    objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(articulo));

        //    //Llamado al método en la capa de negocio
        //    objPedidoArticulos.listarDatosArticulo(objPedidoArticulos);

        //    //Validación de proceso exitoso
        //    if (objPedidoArticulos.Exito)
        //    {
        //        //Se cargan los datos asociados al id_articulo seleccionado
        //        foreach (DataRow row in objPedidoArticulos.Ds.Tables[0].Rows)
        //        {
        //            txtColorModificar.Text = Convert.ToString(row[3]);
        //            txtTamanoModificar.Text = Convert.ToString(row[4]);
        //            txtPrecioModificar.Text = Convert.ToString(row[5]);
        //        }
        //    }
        //    else
        //    {
        //        //Caso contrario se informa
        //        lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
        //        lblMensajeModificar.Visible = true;

        //    }
        #endregion

    }//Fin Listener dropListArticuloModificar

    /// <summary>
    /// Listener del botón para modificar un registro en la tabla Pedido_Articulos
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModificar_Click(object sender, EventArgs e)
    {

        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();

                if (!(txtUnidadesModificar.Text.Trim().Equals("")) ) {

                    //Parseo de datos
                    objPedidoArticulos.id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosModificar.SelectedItem.ToString());

                    //Se obtiene el registro con el id_pedido_articulos correspondiente
                    objPedidoArticulos = db.tblPedido_Articulos.Find(objPedidoArticulos.id_pedido_articulos);

                    //Se instancian los nuevos atributos para la instancia
                    objPedidoArticulos.id_pedido = Convert.ToInt32(dropListIDPedidoModificar.SelectedItem.ToString());
                    objPedidoArticulos.id_articulo = Convert.ToInt32(regexNumerico(dropListArticuloModificar.SelectedItem.ToString()));
                    objPedidoArticulos.tamano_articulo = txtTamanoModificar.Text;
                    objPedidoArticulos.color_articulo = txtColorModificar.Text;
                    objPedidoArticulos.unidades_articulo = Convert.ToInt32(txtUnidadesModificar.Text);
                    objPedidoArticulos.precio_u_articulo = Convert.ToInt32(txtPrecioModificar.Text);

                    //Se guardan los cambios generados a la instancia en la base de datos
                    db.SaveChanges();

                    lblMensajeModificar.Text = "Registro modificado exitosamente";
                    lblMensajeModificar.Visible = true;

                }else {
                    lblMensajeModificar.Text = "No pueden quedar campos vacios";
                    lblMensajeModificar.Visible = true;
                }

            }
        } catch (Exception ex) {
            lblMensajeModificar.Text = ex.Message;
            lblMensajeModificar.Visible = true;
        }


        #region deprecated
        // PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        //Validación si el campo se encuentra vacio
        //if (!(txtUnidadesModificar.Text.Trim().Equals(""))) {

        //    //Parseo de datos
        //    objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosModificar.SelectedItem.ToString());
        //    objPedidoArticulos.Id_pedido = Convert.ToInt32(dropListIDPedidoModificar.SelectedItem.ToString());
        //    objPedidoArticulos.Id_articulo = Convert.ToInt32(regexNumerico(dropListArticuloModificar.SelectedItem.ToString()));
        //    objPedidoArticulos.Tamano_articulo = txtTamanoModificar.Text;
        //    objPedidoArticulos.Color_articulo = txtColorModificar.Text;
        //    objPedidoArticulos.Unidades_articulo = Convert.ToInt32(txtUnidadesModificar.Text);
        //    objPedidoArticulos.Precio_u_articulo = Convert.ToInt32(txtPrecioModificar.Text);

        //    //Llamado al método
        //    objPedidoArticulos.modificar(objPedidoArticulos);

        //    //Validación de proceso exitoso
        //    if (objPedidoArticulos.Exito)
        //    {
        //        //Se informa exito
        //        lblMensajeModificar.Text = "Se ha modificado exitosamente";
        //        lblMensajeModificar.Visible = true;

        //    }else
        //    {
        //        //Caso contrario se informa
        //        lblMensajeModificar.Text = objPedidoArticulos.Mensaje;
        //        lblMensajeModificar.Visible = true;
        //    }


        //}
        //else
        //{
        //    //Caso contrario se informa
        //    lblMensajeModificar.Text = "No pueden quedar campos vacios";
        //    lblMensajeModificar.Visible = true;
        //}

        #endregion
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
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
                
                if (dropListIDPedidoArticulosEliminar.SelectedIndex != 0) {

                    tblPedido_Articulos objPedidoArticulos = new tblPedido_Articulos();
                    //Se obtiene el id del registro a "Eliminar"
                    objPedidoArticulos.id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosEliminar.SelectedItem.ToString());
                    //Se busca el registro seleccionado en la base de datos y se instancia en un objeto;
                    objPedidoArticulos = db.tblPedido_Articulos.Find(objPedidoArticulos.id_pedido_articulos);
                    //Se define la variable estado con valor "false"
                    objPedidoArticulos.estado = false;
                    //Se guardan los cambios realizados en la base de datos
                    db.SaveChanges();

                    lblMensajeEliminar.Text = "Registro Eliminado Correctamente";
                    lblMensajeEliminar.Visible = true;
                }

            }
        } catch (Exception ex) {
            lblMensajeEliminar.Text = ex.Message;
            lblMensajeEliminar.Visible = true;
        }

        #region deprecated
        //    //PedidoArticulos objPedidoArticulos = new PedidoArticulos();

        ////Se valida la selección de item del dropList
        //if (dropListIDPedidoArticulosEliminar.SelectedIndex == 0)
        //{
        //    //No hacer nada
        //}
        //else
        //{
        //    //Parseo
        //    objPedidoArticulos.Id_pedido_articulos = Convert.ToInt32(dropListIDPedidoArticulosEliminar.SelectedItem.ToString());

        //    //Llamado al método
        //    objPedidoArticulos.eliminar(objPedidoArticulos);

        //    //Validación de proceso exitoso
        //    if (objPedidoArticulos.Exito)
        //    {
        //        //Se informa
        //        lblMensajeEliminar.Text = "Se ha eliminado el registro exitosamente";
        //        lblMensajeEliminar.Visible = true;
        //    }
        //    else
        //    {
        //        //Caso contrario se informa
        //        lblMensajeEliminar.Text = objPedidoArticulos.Mensaje;
        //        lblMensajeEliminar.Visible = true;
        //    }

        //}

        #endregion

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