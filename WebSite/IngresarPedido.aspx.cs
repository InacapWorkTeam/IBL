﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IngresarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pedido.aspx");
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text=DateTime.
    }
}