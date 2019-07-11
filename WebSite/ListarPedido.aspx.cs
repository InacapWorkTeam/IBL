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
        //Llamado al Contexto de la base de datos
        using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
        {
            try
            {
                //Se conprueba que el ID no venga vacio
                if (!(txtId.Text == ""))
                {
                    //Si equivale a un numero distinto de 0 lista el registro filtrado
                    if (txtId.Text != "0")
                    {

                        //Creacion del objPedido
                        tblPedido objPedido = new tblPedido();
                        //Captura del dato ID ingresado por el usario
                        objPedido.id_pedido = int.Parse(txtId.Text);
                        //Guarda los registros en una variable
                        var filtro = db.tblPedido.Find(objPedido.id_pedido);
                        //Si la existencia es nulla, no se deben mostrar los datos
                        //Captura de existencia
                        bool existencia = Convert.ToBoolean(filtro.existencia);
                        
                        //Si la existencia es falsa se muestra un mensaje de Pedido eliminado 
                        if (existencia == false)
                        {
                            //Muestra msje de dato eliminado
                            lblAviso.Text = "Este dato esta eliminado";
                            lblAviso.Visible = true;

                            //Refresco de datos de la tabla
                            tblListado.DataSource = new List<tblPedido> {};
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
                    else if (txtId.Text == "0")
                    {
                        //Obtiene todos los registros de la tabla
                        var listado = db.tblPedido;
                        //Instancia un nuevo objeto List para guardar los registros
                        List<tblPedido> array = new List<tblPedido> { };
                        
                        //Se recorren los resultados de la consulta
                        foreach (var objPedido in listado)
                        {
                            //si la existencia es verdadera, se guardan los datos en mi array
                            if (objPedido.existencia == 1)
                            {
                                //Se añade cada registro al List
                                array.Add(objPedido);
                            }
                        }

                        //Se ingresan los registros obtenidos de una lista accesible por el DataSource
                        tblListado.DataSource = array;
                        tblListado.DataBind();
                    }//Fin Else-IF
                }else {
                    lblAviso.Text = "Campo Vacio, Ingrese un ID";
                    lblAviso.Visible = true;
                }//fin else-if
                    
            }
            catch (Exception ex)
            {
                lblAviso.Text = "DATO NO EXISTENTE O ELIMINADO <br/> MAS INFO=" + ex;
                lblAviso.Visible = true;
            }//Fin Try-Catch

        }//Fin using


        /*
        //Antigua conexion 
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
        */
    }
}