using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibNegocio;
using System.Linq;

public partial class Articulo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        mostrar();
    }

    protected void btnIngresar_Click(object sender, EventArgs e) {
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities BDE = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {

                if (!(txtNombre.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || txtColor.Text.Trim() == "" || txtTamaño.Text.Trim() == ""
                    || txtPrecio.Text.Trim() == "" || txtCosto.Text.Trim() == "" || txtUnidades.Text.Trim() == "")) {
                    tblArticulo objA = new tblArticulo() {
                        nombre = txtNombre.Text,
                        descripcion = txtDescripcion.Text,
                        color = txtColor.Text,
                        tamano = txtTamaño.Text,
                        precio = int.Parse(txtPrecio.Text),
                        coste_u_mayorista = int.Parse(txtCosto.Text),
                        unidades = int.Parse(txtUnidades.Text),
                        eliminado = false
                    };

                    BDE.tblArticulo.Add(objA);
                    BDE.SaveChanges();

                    lblMensaje.Text = "INGRESO EXITOSO";
                    lblMensaje.Visible = true;
                    limpiar();
                    mostrar();
                }else {
                    lblMensaje.Text = "*Campos Vacíos";
                    lblMensaje.Visible = true;
                }
            }
        } catch (Exception ex) {
            lblMensaje.Text = "ERROR " + ex.Message;
            lblMensaje.Visible = true;
        }
    }

    protected void btnActualizar_Click(object sender, EventArgs e) {
        mostrar();
    }

    public void limpiar() {
        txtNombre.Text = "";
        txtDescripcion.Text = "";
        txtColor.Text = "";
        txtTamaño.Text = "";
        txtPrecio.Text = "";
        txtCosto.Text = "";
        txtUnidades.Text = "";
        txtID.Text = "";
        txtBuscar.Text = "";
    }

    public void mostrar() {
        try {
            using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities EF = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
                IQueryable<tblArticulo> articulos = from q in EF.tblArticulo where q.eliminado == false select q;
                List<tblArticulo> lista = articulos.ToList();

                dgListar.DataSource = lista;
                dgListar.DataBind();
            }
        } catch (Exception ex) {
            lblMensaje.Text = "ERROR " + ex;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e) {
        try {
            if (!(txtID.Text.Trim() == "")) {
                int id = Convert.ToInt32(txtID.Text);
                using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities bd = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
                    // var query = (from p in bd.tblArticulo where p.id_articulo == id select p).Single();

                    tblArticulo objArticulo = new tblArticulo();
                    objArticulo.id_articulo = id;
                    objArticulo = bd.tblArticulo.Find(objArticulo.id_articulo);
                    objArticulo.eliminado = true;

                    // bd.tblArticulo.Remove(query);
                    bd.SaveChanges();
                    lblMensaje.Text = "Eliminado correctamente";
                    lblMensaje.Visible = true;
                }
            } else {
                lblMensaje.Text = "*Campo Vacío";
                lblMensaje.Visible = true;
            }
            mostrar();
            limpiar();
        } catch (Exception ex) {
            lblMensaje.Text = "ERROR " + ex.Message;
            lblMensaje.Visible = true;
        }
    }


    protected void btnActualizarDatos_Click(object sender, EventArgs e) {
        try {

            if (!(txtNombre.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || txtColor.Text.Trim() == "" || txtTamaño.Text.Trim() == ""
                || txtPrecio.Text.Trim() == "" || txtCosto.Text.Trim() == "" || txtUnidades.Text.Trim() == "")) {
                int id = int.Parse(txtBuscar.Text);
                using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities bde = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
                    tblArticulo obja = (from q in bde.tblArticulo where q.id_articulo == id select q).First();

                    obja.nombre = txtNombre.Text;
                    obja.descripcion = txtDescripcion.Text;
                    obja.color = txtColor.Text;
                    obja.tamano = txtTamaño.Text;
                    obja.precio = int.Parse(txtPrecio.Text);
                    obja.coste_u_mayorista = int.Parse(txtCosto.Text);
                    obja.unidades = int.Parse(txtUnidades.Text);

                    bde.SaveChanges();
                }
                mostrar();
                limpiar();
                lblMensaje.Text = "DATOS ACTUALIZADOS";
                lblMensaje.Visible = true;
            }else {
                lblMensaje.Text = "*Campos Vacíos";
                lblMensaje.Visible = true;
            }
        } catch (Exception ex) {
            lblMensaje.Text = "ERROR " + ex.Message;
        }
    }

    protected void btnBuscarDato_Click(object sender, EventArgs e) {
        try {
            if (!(txtBuscar.Text.Trim() == "")) {
                int id = int.Parse(txtBuscar.Text);
                using (DB_PAAC4G4ArriagadaSepulvedaVidalEntities DBE = new DB_PAAC4G4ArriagadaSepulvedaVidalEntities()) {
                    IQueryable<tblArticulo> objA = from q in DBE.tblArticulo where q.id_articulo == id select q;
                    List<tblArticulo> lista = objA.ToList();

                    var art = lista[0];

                    txtNombre.Text = art.nombre;
                    txtDescripcion.Text = art.descripcion;
                    txtColor.Text = art.color;
                    txtTamaño.Text = art.tamano;
                    txtPrecio.Text = art.precio.ToString();
                    txtCosto.Text = art.coste_u_mayorista.ToString();
                    txtUnidades.Text = art.unidades.ToString();

                    dgListar.DataSource = lista;
                    dgListar.DataBind();
                }
            }else {
                lblMensaje.Text = "*Campo Vacío";
                lblMensaje.Visible = true;
            }
        } catch (Exception ex) {
            lblMensaje.Text = "ERROR " + ex.Message;
        }
    }

    protected void btnEliminar_Click1(object sender, EventArgs e) {

    }

    protected void btnBuscarDato_Click1(object sender, EventArgs e) {

    }
}