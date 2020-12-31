using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace GePE.Logout
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = "";
            Session["TipoUsuario"] = "";
            Session["CorreoUsuario"] = "";

            Response.Redirect("../Carreras/GestionCarreras.aspx");
        }
    }
}