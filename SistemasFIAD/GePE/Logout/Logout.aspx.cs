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
            Session["IdUsuario"] = "";
            Session["NombreUsuario"] = "";
            Session["CorreoUsuario"] = "";
            Session["PassUsuario"] = "";
            Session["TipoUsuario"] = "";
            Session["ClaveUsuario"] = "";
            Session["ApellidoPaterno"] = "";
            Session["ApellidoMaterno"] = "";

            Response.Redirect("../Carreras/GestionCarreras.aspx");
        }
    }
}