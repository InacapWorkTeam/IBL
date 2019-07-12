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
        lblaviso.Visible = false;
        if (!IsPostBack){
            definirDropListCliente();
            definirDropListVendedor();
            Calendar1.SelectedDate = System.DateTime.Today;
        }
    

    }

    private void definirDropListVendedor()
    {
        try
        {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropVendedor.Items.Add("-- Seleccione un item --");

                var listaIDVendedor = db.Vendedor;

                foreach (var objPedido in listaIDVendedor)
                {
                    
                        DropVendedor.Items.Add(objPedido.id_vendedor + ".- "+objPedido.nombre);
                }

            }

        }
        catch (Exception ex)
        {
            lblaviso.Text = "" + ex;
            lblaviso.Visible = true;
        }
    }

    private void definirDropListCliente()
    {
        try
        {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {
                //Definición del primer item
                DropCliente.Items.Add("-- Seleccione un item --");

                var listaIDCliente = db.Cliente;

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

        try
        {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities db = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities())
            {

                tblPedido objPedido = new tblPedido();
                if (!(txtTotal.Text.Trim().Equals("") ||DropVendedor.SelectedIndex.Equals(0)|| DropCliente.SelectedIndex.Equals(0)))
                {
                    
                    objPedido.fecha = Calendar1.SelectedDate;
                    objPedido.total = Convert.ToInt32(txtTotal.Text);
                    objPedido.id_vendedor = Convert.ToInt32(regexNumerico(DropVendedor.SelectedItem.ToString()));
                    objPedido.id_cliente = Convert.ToInt32(regexNumerico(DropCliente.SelectedItem.ToString()));
                    objPedido.existencia = 1;

                    db.tblPedido.Add(objPedido);
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
                    //Caso contrario se informa
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