using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GePE.PaginasMaestras
{
    public partial class SistemasFIAD : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string cadena = HttpContext.Current.Request.Url.AbsoluteUri;
                string[] Separado = cadena.Split('/');
                string Final = Separado[Separado.Length - 1];

                if (Final == "Login.aspx")
                {
                    BtnUserDropDown.Visible = false;
                }
                else
                {
                    BtnUserDropDown.Visible = true;
                }

                if (Convert.ToString(Session["NombreUsuario"]) != "")
                {
                    string NombreUsuario = Convert.ToString(Session["NombreUsuario"]);
                    string TipoUsuario = Convert.ToString(Session["TipoUsuario"]);
                    string CorreoUsuario = Convert.ToString(Session["CorreoUsuario"]);

                    BtnUserDropDown.Text = NombreUsuario;
                    BtnCerrarSesion.Visible = true;

                    BtnIniciarSesion.Visible = false;

                    if (TipoUsuario == "ADMINISTRADOR")
                    {
                        BtnGestionUsuarios.Visible = true;
                    }
                    else
                    {
                        BtnGestionUsuarios.Visible = false;
                    }
                }
                else
                {
                    BtnUserDropDown.Text = "Iniciar sesión";

                    BtnCerrarSesion.Visible = false;
                    BtnIniciarSesion.Visible = true;

                    BtnGestionUsuarios.Visible = false;

                    lbNombreUsuario.Visible = false;
                    lbTipoUsuario.Visible = false;
                    lbCorreoUsuario.Visible = false;

                    lbNombreUsuario.Text = "";
                    lbTipoUsuario.Text = "";
                    lbCorreoUsuario.Text = "";

                    Session["NombreUsuario"] = "";
                    Session["TipoUsuario"] = "";
                    Session["CorreoUsuario"] = "";

                }
            }

        }
        
    }
}