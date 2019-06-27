using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNeg;

public partial class Articulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        Negocio objArticulo = new Negocio();
        objArticulo.Nombre = txtNombre.Text;
        objArticulo.Descripcion = txtDescripcion.Text;
        objArticulo.Color = txtColor.Text;
        objArticulo.Tamaño = txtTamaño.Text;
        objArticulo.Precio = int.Parse(txtPrecio.Text);
        objArticulo.Coste_u_mayorista = int.Parse(txtCosto.Text);
        objArticulo.Unidades = int.Parse(txtUnidades.Text);

        objArticulo = objArticulo.ingresarArticulo(objArticulo);
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        Negocio objArticulo = new Negocio();
        objArticulo = objArticulo.listarArticulo(objArticulo);
        dgListar.DataSource = objArticulo.Data;
        dgListar.DataBind();
    }
}