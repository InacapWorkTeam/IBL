using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MiLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {


        if (FormsAuthentication.Authenticate(txtUsername.Text,txtPassword.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);
        }
        else
        {
            lblMensaje.Text = "Usuario o Clave incorrecto";
            lblMensaje.Visible = true;
        }
    }
}