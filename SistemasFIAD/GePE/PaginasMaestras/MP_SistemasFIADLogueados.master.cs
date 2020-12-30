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
            string cadena = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] Separado = cadena.Split('/');
            string Final = Separado[Separado.Length - 1];

            if (Final == "Login.aspx")
            {
                lbNombreUsuario.Visible = false;
            }
            else
            {
                lbNombreUsuario.Visible = true;
            }

            if (Convert.ToString(Session["NombreUsuario"]) != "")
            {
                string NombreUsuario = Convert.ToString(Session["NombreUsuario"]);
                string TipoUsuario = Convert.ToString(Session["TipoUsuario"]);
                string CorreoUsuario = Convert.ToString(Session["CorreoUsuario"]);

                //Response.Write("<script language=javascript>alert('" + mensaje + "');</script>");

                lbNombreUsuario.Text = "Nombre: " + NombreUsuario;
                lbCerrarSesion.Visible = true;
                //lbIniciarSesion.Visible = false;
                BtnIniciarSesion.Visible = false;

                if (TipoUsuario== "ADMINISTRADOR")
                {
                    lbGestionUsuarios.Visible = true;
                }
                else
                {
                    lbGestionUsuarios.Visible = false;
                }
            }
            else
            {
                lbNombreUsuario.Text = "Iniciar sesión";

                lbCerrarSesion.Visible = false;
                BtnIniciarSesion.Visible = true;
                //lbIniciarSesion.Visible = true;
                lbGestionUsuarios.Visible = false;
            }
        }

        protected void BtnCancelarCerrarSesion_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            string cadena = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] Separado = cadena.Split('/');
            string Final = Separado[Separado.Length - 1];

            Session["NombreUsuario"] = string.Empty;
            Session["TipoUsuario"] = string.Empty;
            Session["CorreoUsuario"] = string.Empty;

            lbNombreUsuario.Text = "Iniciar sesión";
            lbCerrarSesion.Visible = false;
            BtnIniciarSesion.Visible = true;

            lbGestionUsuarios.Visible = false;

            Response.Redirect(Final);

        }

        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            string cadena = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] Separado = cadena.Split('/');
            string Final = Separado[Separado.Length - 1];

            Session["URL"] = cadena;

            Response.Redirect("../Login/Login.aspx");

        }
    }
}