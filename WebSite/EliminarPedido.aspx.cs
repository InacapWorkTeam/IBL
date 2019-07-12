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
        //Ocultar mensaje para la captura de errores
        lblAviso.Visible = false;
        
        if (!IsPostBack)
        {
            //Funcion para rellenar el droplist con Pedidos
            definirDropListPedido();
            
        }
    }

    private void definirDropListPedido()
    {
        //TRY Y CATCH para la captura de errores
        try
        {
            //uso de la BD por entity
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropPedido.Items.Add("-- Seleccione un item --");
                //creacion de la variable que contendra los pedidos
                var listaIDPedido = db.tblPedido;
                //recorrer los datos de la tabla Pedido para ser guardado en el dropList
                foreach (var objPedido in listaIDPedido)
                {
                    //Se guarda el id de pedido en el DropList siempre y cuando exista
                    if (objPedido.existencia == 1)
                    {
                        DropPedido.Items.Add(objPedido.id_pedido + "");
                    }   
                }
            }
        }
        catch (Exception ex)
        {
            lblAviso.Text = "" + ex;
            lblAviso.Visible = true;
        }

        /*
         * Antigua Conexion
        PedidoN objPedido = new PedidoN();
        objPedido.listarPedido(objPedido);
        DropPedido.Items.Add("-- Selecionar Item --");


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
        */
    }

    //Vuelta al menu
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
        //try y catch por excepcion
        try
        {
            //coneccion a la bd
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {

                //si el usuario elige una opcion distinto a 0 (ID del pedido) se produce la siguiente funcion
                if (DropPedido.SelectedIndex != 0)
                {
                    //Creacion del objPedido para guardar los nuevos datos
                    tblPedido objPedido = new tblPedido();
                    //Se obtiene el Id del Pedido para tener un eliminado logico
                    objPedido.id_pedido = Convert.ToInt32(DropPedido.SelectedItem.ToString());
                    //Se busca el registro seleccionado en la base de datos y se instancia en un objeto;
                    objPedido = db.tblPedido.Find(objPedido.id_pedido);
                    //Se hace un eliminado Logico, modificando la existencia a 0
                    objPedido.existencia = 0;

                    //Se guardan los cambios realizados en la base de datos
                    db.SaveChanges();

                    //Mensaje de aviso por ingreso Correcto
                    lblAviso.Text = "Pedido Eliminado Correctamente";
                    lblAviso.Visible = true;
                    //Limpieza de drop para actualizacion
                    DropPedido.Items.Clear();
                    definirDropListPedido();
                    
                }
                else{
                    //Si el usuario no ha elegido una opcion, se mostrara un msje diciendo que eliga opcion
                    lblAviso.Text= "Campo Vacio, Eliga una opcion";
                    lblAviso.Visible=true;
                }
                

            }
        }
        catch (Exception ex)
        {
            //captura de errores por conexion
            lblAviso.Text = ex.Message;
            lblAviso.Visible = true;
        }


        /*
         * Antigua Conexion
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
        */
    }

    protected void DropPedido_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}