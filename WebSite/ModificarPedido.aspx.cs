using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Text.RegularExpressions;
using System.Data;

public partial class ModificarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //msjes de errores ocultos para su posible captura
        lblaviso.Visible = false;
        lblAviso2.Visible = false;
        if (!IsPostBack)
        {
            //relleno de datos de los drop
            definirDropListCliente();
            definirDropListVendedor();
            definirDropListPedido();
            //Calendario predeterminado para hoy
            Calendar1.SelectedDate = System.DateTime.Today;
        }
        

    }

    private void definirDropListPedido()
    {
        //try y catch para captura de errores
        try
        {
            //uso de la bd con entity 
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropDownListPedido.Items.Add("-- Seleccione un item --");
                //guardado de datos en una variable
                var listaIDPedido = db.tblPedido;
                //recorrer los datos de la tabla pedido
                foreach (var objPedido in listaIDPedido)
                {
                    //Guardar datos en nuestro DropDownList siempre que sean existentes
                    if (objPedido.existencia == 1)
                    {
                        DropDownListPedido.Items.Add(objPedido.id_pedido + "");
                    }
                    

                }

            }

        }
        //captura de errores
        catch (Exception ex)
        {
            lblaviso.Text = "" + ex;
            lblaviso.Visible = true;
        }
    }

    private void definirDropListVendedor()
    {
        //try y catch para captura de errores
        try
        {
            //uso de la bd con entity 
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropVendedor.Items.Add("-- Seleccione un item --");
                //guardado de datos en una variable
                var listaIDVendedor = db.Vendedor;
                //recorrer los datos de la tabla pedido
                foreach (var objPedido in listaIDVendedor)
                {
                    //Guardar datos en nuestro DropDownList, con el id vendedor y su nombre
                    DropVendedor.Items.Add(objPedido.id_vendedor + ".- "+objPedido.nombre);
                    
                }

            }

        }
        //captura de errores
        catch (Exception ex)
        {
            lblaviso.Text = "" + ex;
            lblaviso.Visible = true;
        }
    }

    private void definirDropListCliente()
    {

        //try y catch para captura de errores
        try
        {
            //uso de la bd con entity 
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropCliente.Items.Add("-- Seleccione un item --");
                //guardado de datos en una variable
                var listaIDCliente = db.Cliente;
                //recorrer los datos de la tabla pedido
                foreach (var objPedido in listaIDCliente)
                {
                    //Guardar datos en nuestro DropDownList, con el id vendedor y su nombre
                    DropCliente.Items.Add(objPedido.id_cliente + ".- " + objPedido.nombre);

                }

            }

        }
        //captura de errores
        catch (Exception ex)
        {
            lblaviso.Text = "" + ex;
            lblaviso.Visible = true;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //vuelta al menu Pedido
        Response.Redirect("Pedido.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    public string regexNumerico(string input)
    {
        string output;

        output = Regex.Replace(input, @"[^\d]", "");

        return output;
    }
    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        //Try catch para la captura de errores
        try
        {
            //Aqui se estan modificando los datos
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Si ninguno de los datos es nullo hacer la siguiente funcion
                if (!(DropDownListPedido.SelectedIndex.Equals(0)||txtTotal.Text.Trim().Equals("") ||DropVendedor.SelectedIndex.Equals(0)|| DropCliente.SelectedIndex.Equals(0)))
                {
                    //Creacion del objPedido segun la tabla pedido
                    tblPedido objPedido = new tblPedido();

                    //Se obtiene el registro con el id_pedido correspondiente
                    objPedido.id_pedido = Convert.ToInt32(DropDownListPedido.SelectedItem.ToString());
                    objPedido = db.tblPedido.Find(objPedido.id_pedido);

                    //Se instancian los nuevos atributos para la tabla Pedido
                    objPedido.fecha = Calendar1.SelectedDate;
                    objPedido.total = Convert.ToInt32(txtTotal.Text);
                    objPedido.id_cliente = Convert.ToInt32(regexNumerico(DropCliente.SelectedItem.ToString()));
                    objPedido.id_vendedor = Convert.ToInt32(regexNumerico(DropVendedor.SelectedItem.ToString()));

                    //Se guardan los cambios generados a la instancia en la base de datos
                    db.SaveChanges();
                    //Aviso de dato Ingresado
                    lblaviso.Text = "Pedido modificado exitosamente";
                    lblaviso.Visible = true;

                }
                //Captura de error por datos vacios
                else
                {
                    lblaviso.Text = "Campos Vacio, debe llenar todos";
                    lblaviso.Visible = true;
                }
            }
        }
        //Captura de error por conexion
        catch (Exception ex)
        {
            lblaviso.Text = ex.Message;
            lblaviso.Visible = true;
        }

        //Actualizacion de datos luego de haber modificado
        if (!(DropDownListPedido.SelectedIndex.Equals(0)))
        {
            //Uso de la bd por entity
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //try y catch para la captura de datos
                try
                {
                    //Se conprueba que el ID no venga vacio
                    if (!(DropDownListPedido.Text == ""))
                    {
                        //Si equivale a un numero distinto de 0 lista el registro filtrado
                        if (DropDownListPedido.Text != "0")
                        {

                            //Creacion del objPedido
                            tblPedido objPedido = new tblPedido();
                            //Captura del dato ID ingresado por el usario
                            objPedido.id_pedido = int.Parse(DropDownListPedido.Text);
                            //Guarda los registros en una variable
                            var filtro = db.tblPedido.Find(objPedido.id_pedido);
                            //Si la existencia es nulla, no se deben mostrar los datos
                            //Captura de existencia
                            bool existencia = Convert.ToBoolean(filtro.existencia);

                            //Si la existencia es falsa se muestra un mensaje de Pedido eliminado 
                            if (existencia == false)
                            {
                                //Muestra msje de dato eliminado
                                lblaviso.Text = "Este dato esta eliminado";
                                lblaviso.Visible = true;

                                //Refresco de datos de la tabla
                                tblListado.DataSource = new List<tblPedido> { };
                                tblListado.DataBind();
                            }
                            else
                            {
                                //Se ingresan los datos obtenidos en una lista accesible por el DataSource
                                tblListado.DataSource = new List<tblPedido> { filtro };
                                tblListado.DataBind();
                            }

                            //Si equivale a 0 lista todos los registros de la tabla
                        }

                    }//Fin IF
                }
                catch (Exception ex)
                {
                    lblaviso.Text = "DATO NO EXISTENTE O ELIMINADO <br/> MAS INFO=" + ex;
                    lblaviso.Visible = true;
                }//Fin Try-Catch
            }
        

            /*
             * Antigua Conexion
            try
            {

                PedidoN objPedido = new PedidoN();

                objPedido.Id_pedido = Convert.ToInt32(txtId.Text);
                objPedido.Fecha = Calendar1.SelectedDate;
                objPedido.Total = Convert.ToInt32(txtTotal.Text);
                objPedido.Id_vendedor = Convert.ToInt32(regexNumerico(DropVendedor.SelectedItem.ToString().Substring(0, 1)));
                objPedido.Id_cliente = Convert.ToInt32(regexNumerico(DropCliente.SelectedItem.ToString().Substring(0, 1)));

                objPedido.modificarPedido(objPedido);
                lblaviso.Text = objPedido.Mensaje;
                if (objPedido.Exito)
                {
                    lblaviso.Visible = true;
                    lblaviso.Text = "Pedido modificado";
                }
                else
                {
                    lblaviso.Visible = true;
                    lblaviso.Text = objPedido.Mensaje;
                }
            }
            catch (Exception ex)
            {
                lblaviso.Visible = true;
                lblaviso.Text = "Excepcion Capturar: " + ex.Message;
            }
            */
             }
        }

    //boton para ver los datos del ID seleccionado por el usuario
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //try y catch para captura de error por conexion
        try
        {
        //Llamado al Contexto de la base de datos
        using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
        {
            //try y catch para la captura de errores por ingreso
            try
            {
                //Se conprueba que el ID no venga vacio
                if (!(DropDownListPedido.Text == ""))
                {
                    //Si equivale a un numero distinto de 0 lista el registro filtrado
                    if (DropDownListPedido.SelectedIndex != 0)
                    {

                        //Creacion del objPedido
                        tblPedido objPedido = new tblPedido();
                        //Captura del dato ID ingresado por el usario
                        objPedido.id_pedido = int.Parse(DropDownListPedido.Text);
                        //Guarda los registros en una variable
                        var filtro = db.tblPedido.Find(objPedido.id_pedido);
                        //Si la existencia es nulla, no se deben mostrar los datos
                        //Captura de existencia
                        bool existencia = Convert.ToBoolean(filtro.existencia);
                        
                        //Si la existencia es falsa se muestra un mensaje de Pedido eliminado 
                        if (existencia == false)
                        {
                            //Muestra msje de dato eliminado
                            lblaviso.Text = "Este dato esta eliminado";
                            lblaviso.Visible = true;

                            //Refresco de datos de la tabla
                            tblListado.DataSource = new List<tblPedido> { };
                            tblListado.DataBind();
                        }
                        else
                        {
                            //Se ingresan los datos obtenidos en una lista accesible por el DataSource
                            tblListado.DataSource = new List<tblPedido> { filtro };
                            tblListado.DataBind();
                        }

                        //Si equivale a 0 lista todos los registros de la tabla
                    }else
                    {
                        lblAviso2.Text = "Campo Vacio, ingrese una opcion";
                        lblAviso2.Visible = true;
                    }
                    
                }//Fin IF
            }
            catch (Exception ex)
            {
                lblaviso.Text = "DATO NO EXISTENTE O ELIMINADO <br/> MAS INFO=" + ex;
                lblaviso.Visible = true;
            }//Fin Try-Catch

        }//Fin using
        }catch(Exception ex)
        {
            lblaviso.Text = "Error en la conexion MAS INFO="+ex;
            lblaviso.Visible = true;
        }
        /*
         * Antigua Conexion
        try
        {
            PedidoN objPedido = new PedidoN();
            objPedido.Id_pedido = int.Parse(txtId.Text);
            objPedido = objPedido.listarPedido(objPedido);
            tblListado.DataSource = objPedido.Ds;
            tblListado.DataBind();

            

            lblCliente.Visible = true;
            lblCosto.Visible = true;
            lblFecha.Visible = true;
            lblVendedor.Visible = true;
            Calendar1.Visible = true;
            txtTotal.Visible = true;
            DropCliente.Visible = true;
            DropVendedor.Visible = true;
            btnModificar.Visible = true;

            //lblaviso.Text = "El id "+objPedido.Id_pedido +" tiene existencia "+objPedido.Estado;
            /*
            if (objPedido.Estado==true)
            {

                lblCliente.Visible = true;
                lblCosto.Visible = true;
                lblFecha.Visible = true;
                lblVendedor.Visible = true;
                Calendar1.Visible = true;
                txtTotal.Visible = true;
                DropCliente.Visible = true;
                DropVendedor.Visible = true;
                btnModificar.Visible = true;
                
            }
            else
            {
                //El dato no existe, no se puede modificar
                lblaviso.Visible = false;
                lblCliente.Visible = false;
                lblCosto.Visible = false;
                lblFecha.Visible = false;
                lblVendedor.Visible = false;
                Calendar1.Visible = false;
                txtTotal.Visible = false;
                DropCliente.Visible = false;
                DropVendedor.Visible = false;
                btnModificar.Visible = false;
                lblaviso.Visible = true;
                //lblaviso.Text = "Este dato no existe o esta eliminado";
            }

        }
        catch (Exception ex)
        {
            lblaviso.Visible = true;
            lblaviso.Text = "Excepcion Capturar: " + ex.Message;
        }
        */

    }

    protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
    {
        
    }
}