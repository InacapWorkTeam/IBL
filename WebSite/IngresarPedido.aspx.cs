using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;

public partial class IngresarPedido : System.Web.UI.Page
{

    int edad;
    bool vacio;
    string[] valores;


    protected void Page_Load(object sender, EventArgs e)
    {
       /// valores = new string[] { txtboxrut.Text, txtboxnombre.Text,  // se inicializa un array valores con los textbox
          //                       txtboxpaterno.Text, txtboxmaterno.Text,
         //                        txtboxdireccion.Text, txtboxcomuna.Text,
            //                     txtboxfono.Text, txtboxemail.Text };
        //vacio = false;
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
        //barra de despliegue que mostrara los vendedores
       // Pedido objPedido = new Pedido();
        //objPedido.Rut = txtRut.Text;
      //  objVendedor = objVendedor.listarPedido(objAmistades);
       // dgListar.DataSource = objAmistades.Ds;
       // dgListar.DataBind();

    }//fin 

    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}