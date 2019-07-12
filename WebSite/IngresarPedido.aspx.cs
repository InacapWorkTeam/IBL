using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Data;
using System.Text.RegularExpressions;

public partial class IngresarPedido : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        //Se oculta el msje para posteriores errores
        lblaviso.Visible = false;
        if (!IsPostBack){
            //Funciones para llenar los Drop list de Clientes y Vendedores
            definirDropListCliente();
            definirDropListVendedor();
            //Se define el calendar como predeterminado para el dia de hoy
            Calendar1.SelectedDate = System.DateTime.Today;
        }
    }

    private void definirDropListVendedor()
    {
        //try y catch para la captura de errores
        try
        {
            //Uso de la bd para su uso de datos con entity
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropVendedor.Items.Add("-- Seleccione un item --");

                var listaIDVendedor = db.Vendedor;
                //Se recorren todos los vendedores con su ID y nombre
                foreach (var objPedido in listaIDVendedor)
                {
                        DropVendedor.Items.Add(objPedido.id_vendedor + ".- "+objPedido.nombre);
                }

            }

        }
        catch (Exception ex)
        {
            lblaviso.Text = "Ocurrio un error en la conexion MAS INFO:" + ex;
            lblaviso.Visible = true;
        }
    }

    private void definirDropListCliente()
    {
        //TRY Y CATCH para la captura de errores 
        try
        {
            //uso de la BD para capturar los datos con entity
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropCliente.Items.Add("-- Seleccione un item --");

                var listaIDCliente = db.Cliente;
                //recorrido de la tabla cliente para obtener su id y nombre
                foreach (var objPedido in listaIDCliente)
                {

                    DropCliente.Items.Add(objPedido.id_cliente + ".- " + objPedido.nombre);
                }

            }

        }
        catch (Exception ex)
        {
            lblaviso.Text = "" + ex;
            lblaviso.Visible = true;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //para volver al menu
        Response.Redirect("Pedido.aspx");
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
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
        //TRY Y CATCH para la captura de errores
        try
        {
            //uso de la BD para la captura de datos necesarios
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //creacion del objPedido segun la tabla pedido
                tblPedido objPedido = new tblPedido();
                //Si los campos no estan vacios, hacer la siguiente funcion
                if (!(txtTotal.Text.Trim().Equals("") ||DropVendedor.SelectedIndex.Equals(0)|| DropCliente.SelectedIndex.Equals(0)))
                {
                    
                    //Captura de los datos ingresados para su guardado en el objPedido
                    objPedido.fecha = Calendar1.SelectedDate;
                    objPedido.total = Convert.ToInt32(txtTotal.Text);
                    objPedido.id_vendedor = Convert.ToInt32(regexNumerico(DropVendedor.SelectedItem.ToString()));
                    objPedido.id_cliente = Convert.ToInt32(regexNumerico(DropCliente.SelectedItem.ToString()));
                    objPedido.existencia = 1;

                    //Se ingresan los datos ingresados en nuestra tabla
                    db.tblPedido.Add(objPedido);
                    //Se guardan los cambios en nuestra bd
                    db.SaveChanges();

                    //Confirmacion Pedido ingresado
                    lblaviso.Text = "Pedido Ingresado Correctamente";
                    lblaviso.Visible = true;
                    //limpieza de datos
                    txtTotal.Text = "";
                    DropCliente.SelectedIndex = 0;
                    DropVendedor.SelectedIndex = 0;

                }
                else
                {
                    //Error por datos vacios (no ingresados)
                    lblaviso.Text = "No pueden quedar campos vacios";
                    lblaviso.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblaviso.Text = ex.Message;
            lblaviso.Visible = true;
        }

        /*
        //Antigua Conexion
        try
        {

            PedidoN objPedido = new PedidoN();
            
            objPedido.Fecha = Calendar1.SelectedDate;
            objPedido.Total = Convert.ToInt32(txtTotal.Text);
            objPedido.Id_vendedor = Convert.ToInt32(regexNumerico(DropVendedor.SelectedItem.ToString().Substring(0, 1)));
            objPedido.Id_cliente = Convert.ToInt32(regexNumerico(DropCliente.SelectedItem.ToString().Substring(0, 1)));

            objPedido.ingresarPedido(objPedido);
            lblaviso.Text = objPedido.Mensaje;
            if (objPedido.Exito)
            {
                lblaviso.Visible = true ;
                lblaviso.Text = "Pedido ingresado";
            }
            else
            {
                lblaviso.Visible = true;
                lblaviso.Text = objPedido.Mensaje;
            }
        }
        catch(Exception ex)
        {
            lblaviso.Visible = true;
            lblaviso.Text = "Excepcion Capturar: " + ex.Message;
        }
        */

    }
}