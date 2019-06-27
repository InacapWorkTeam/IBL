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
        /*
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
        */

        lblaviso.Visible = false;
        if (!IsPostBack)
        {
            definirDropListCliente();
            definirDropListVendedor();
        }

    }
    private void definirDropListVendedor()
    {
        PedidoN objPedido = new PedidoN();
        objPedido.listarVendedor(objPedido);

        if (objPedido.Exito)
        {
            foreach (DataRow row in objPedido.Ds.Tables[0].Rows)
            {
                DropVendedor.Items.Add(Convert.ToString(row[0]) + ". " + Convert.ToString(row[1]));

            }
        }
        else
        {
            lblaviso.Text = objPedido.Mensaje;
            lblaviso.Visible = true;
        }
    }

    private void definirDropListCliente()
    {
        PedidoN objPedido = new PedidoN();
        objPedido.listarCliente(objPedido);

        if (objPedido.Exito)
        {
            foreach (DataRow row in objPedido.Ds.Tables[0].Rows)
            {
                DropCliente.Items.Add(Convert.ToString(row[0]) + ". " + Convert.ToString(row[1]));

            }
        }
        else
        {
            lblaviso.Text = objPedido.Mensaje;
            lblaviso.Visible = true;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
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
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
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
            }*/

        }
        catch (Exception ex)
        {
            lblaviso.Visible = true;
            lblaviso.Text = "Excepcion Capturar: " + ex.Message;
        }
    }
}