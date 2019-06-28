using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Articulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mostrar();
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            Articulo objArticulo = new Articulo();

            objArticulo.Nombre = txtNombre.Text;
            objArticulo.Descripcion = txtDescripcion.Text;
            objArticulo.Color = txtColor.Text;
            objArticulo.Tamaño = txtTamaño.Text;
            objArticulo.Precio = int.Parse(txtPrecio.Text);
            objArticulo.Coste_u_mayorista = int.Parse(txtCosto.Text);
            objArticulo.Unidades = int.Parse(txtUnidades.Text);

            objArticulo.ingresarArticulo(objArticulo);

            if (objArticulo.Exito == true)
            {
                lblMensaje.Text = "INGRESADO CORRECTAMENTE";
                limpiar();
                mostrar();
            }

        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR " + ex;
        }
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        mostrar();
    }

    public void mostrar()
    {
        try
        {
            Articulo objArticulo = new Articulo();
            objArticulo.listarArticulo(objArticulo);
            dgListar.DataSource = objArticulo.Data;
            dgListar.DataBind();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR " + ex;
        }
    }

    public void limpiar()
    {
        txtNombre.Text = "";
        txtDescripcion.Text = "";
        txtColor.Text = "";
        txtTamaño.Text = "";
        txtPrecio.Text = "";
        txtCosto.Text = "";
        txtUnidades.Text = "";
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Articulo objArticulo = new Articulo();
            objArticulo.Id = int.Parse(txtId.Text);
            objArticulo.eliminarArticulo(objArticulo);

            if (objArticulo.Exito == true)
            {
                lblMensaje.Text = "ELIMINADO CORRECTAMENTE";
            }
            limpiar();
            mostrar();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR " + ex;
        }
    }

    protected void btnAct_Click(object sender, EventArgs e)
    {
        try
        {
            Articulo objArticulo = new Articulo();

            objArticulo.Id = int.Parse(txtId.Text);
            objArticulo.Nombre = txtNombre.Text;
            objArticulo.Descripcion = txtDescripcion.Text;
            objArticulo.Color = txtColor.Text;
            objArticulo.Tamaño = txtTamaño.Text;
            objArticulo.Precio = int.Parse(txtPrecio.Text);
            objArticulo.Coste_u_mayorista = int.Parse(txtCosto.Text);
            objArticulo.Unidades = int.Parse(txtUnidades.Text);

            objArticulo.actualizarArticulo(objArticulo);

            if (objArticulo.Exito == true)
            {
                lblMensaje.Text = "ACTUALIZADO CORRECTAMENTE";
                mostrar();
                limpiar();
            }

        }
        catch (Exception ex)
        {
            lblMensaje.Text = "ERROR " + ex;
        }
    }
}