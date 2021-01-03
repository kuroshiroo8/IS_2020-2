using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

using Entidades;
using Negocios;

namespace GePE.usuarios
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InicializaControles();
        }

        #region Métodos generales
        protected void InicializaControles()
        {
            ControlesOFF();
            ControlesClear();
            ControlesOnOFF(true);
        }
        protected void ControlesOFF()
        {
            //Visible Label
            lbCorreoUsuario.Visible = false;
            lbNombreUsuario.Visible = false;
            lbContraseña.Visible = false;
            lbTipoUsuario.Visible = false;
            lbCalveUsuario.Visible = false;
            lbApellidoPaterno.Visible = false;

            //Visible LinkButton
            BtnGrabar.Visible = false;
            BtnBorrar.Visible = false;
            BtnBorrarModal.Visible = false;
            BtnModificar.Visible = false;
            BtnMnuEditar.Visible = false;
            BtnMnuBorrar.Visible = false;
            BtnCancelar.Visible = false;
            BtnAceptar.Visible = false;

            //Visible Panel
            PnlCapturaDatos.Visible = false;
            PnlGrvUsuarios.Visible = false;
        }
        protected void ControlesClear()
        {
            //Clear Label
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;

            //Clear TextBox
            TbCriterioBusqueda.Text = string.Empty;
            TbCorreoUsuario.Text = string.Empty;
            TbNombreUsuario.Text = string.Empty;
            TbContraseñaUsuario1.Text = string.Empty;
            TbnumClaveUsuario1.Text = string.Empty;
            TbApellidoPaterno.Text = string.Empty;
            TbApellidoMaterno.Text = string.Empty;

            //limpiar drop
            ddlTipoUsuario.Items.Clear();
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            //Enabled Label
            lbCorreoUsuario.Enabled = TrueOrFalse;
            lbNombreUsuario.Enabled = TrueOrFalse;
            lbContraseña.Enabled = TrueOrFalse;
            lbTipoUsuario.Enabled = TrueOrFalse;
            lbCalveUsuario.Enabled = TrueOrFalse;
            lbApellidoPaterno.Enabled = TrueOrFalse;
            lbApellidoMaterno.Enabled = TrueOrFalse;

            //Enabled TextBox
            TbCorreoUsuario.Enabled = TrueOrFalse;
            TbNombreUsuario.Enabled = TrueOrFalse;
            TbContraseñaUsuario1.Enabled = TrueOrFalse;
            TbnumClaveUsuario1.Enabled = TrueOrFalse;
            TbApellidoPaterno.Enabled = TrueOrFalse;
            TbApellidoMaterno.Enabled = TrueOrFalse;

            ddlTipoUsuario.Enabled = TrueOrFalse;

        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
            //Visible Label
            lbCorreoUsuario.Visible = TrueOrFalse;
            lbNombreUsuario.Visible = TrueOrFalse;
            lbContraseña.Visible = TrueOrFalse;
            lbTipoUsuario.Visible = TrueOrFalse;
            lbCalveUsuario.Visible = TrueOrFalse;
            lbApellidoPaterno.Visible = TrueOrFalse;
            lbApellidoMaterno.Visible = TrueOrFalse;

            //Visible TextBox
            TbCorreoUsuario.Visible = TrueOrFalse;
            TbNombreUsuario.Visible = TrueOrFalse;
            TbContraseñaUsuario1.Visible = TrueOrFalse;
            TbnumClaveUsuario1.Visible = TrueOrFalse;
            TbApellidoPaterno.Visible = TrueOrFalse;
            TbApellidoMaterno.Visible = TrueOrFalse;

            ddlTipoUsuario.Visible = TrueOrFalse;
        }
        #endregion

        #region Objeto Cliente
        protected E_Usuarios ControlesWebForm_ObjetoEntidad()
        {
            E_Usuarios Usuarios = new E_Usuarios()
            {
                NombreUsuario = TbNombreUsuario.Text,
                CorreoUsuario = TbCorreoUsuario.Text,
                PassUsuario = TbContraseñaUsuario1.Text,
                TipoUsuario = ddlTipoUsuario.SelectedItem.Text,
                ClaveUsuario = TbnumClaveUsuario1.Text,
                ApellidoPaterno = TbApellidoPaterno.Text,
                ApellidoMaterno = TbApellidoMaterno.Text
            };
            return Usuarios;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdUsuario)
        {
            E_Usuarios Usuarios = NU.BuscaUsuarioPorId(IdUsuario);

            TbNombreUsuario.Text = Usuarios.NombreUsuario.Trim();
            TbCorreoUsuario.Text = Usuarios.CorreoUsuario.Trim();
            TbContraseñaUsuario1.Text = Usuarios.PassUsuario.Trim();
            CargaTipoUsuario();
            int index = 0;
            while (ddlTipoUsuario.SelectedItem.Text != Usuarios.TipoUsuario.Trim())
            {
                index = index + 1;
                ddlTipoUsuario.SelectedIndex = index;
            }
            ddlTipoUsuario.SelectedIndex = index;
            TbnumClaveUsuario1.Text = Convert.ToString(Usuarios.ClaveUsuario);
            TbApellidoPaterno.Text = Usuarios.ApellidoPaterno.Trim();
            TbApellidoMaterno.Text = Usuarios.ApellidoMaterno.Trim();
        }
        #endregion

        #region Botones menu de navegación 
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            lblTituloAccion.Text = "Nuevo usuario";
            PnlCapturaDatos.Visible = true;

            CargaTipoUsuario();
            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);
        }
        protected void BtnMnuListado_Click(object sender, EventArgs e)
        {
            InicializaControles();
            N_Usuarios NU = new N_Usuarios();
            GrvUsuarios.DataSource = NU.LstUsuario();
            //GrvCarreras.DataBind();
            //PnlGrvCarreras.Visible = true;

            if (NU.LstUsuario().Count.Equals(0))
            {
                InicializaControles();
                lblNombreAccion.Text = "No se encontraron usuarios para listar";
            }
            else
            {
                GrvUsuarios.DataBind();
                PnlGrvUsuarios.Visible = true;
            }
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Usuarios> LstUsuario = NU.BuscaUsuario(TbCriterioBusqueda.Text.Trim());
                if (LstUsuario.Count.Equals(0))
                {
                    InicializaControles();
                    lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
                }
                else if (LstUsuario.Count.Equals(1))
                {
                    InicializaControles();
                    lblTituloAccion.Text = "Resultado de busqueda";

                    //Aqui se ponen visibles los Label, TextBox y el CheckBox
                    VisibleOnOFF(true);

                    //Aqui se hacen no editables los TextBox
                    //TbClaveUsuario.Enabled = false;
                    TbNombreUsuario.Enabled = false;
                    TbCorreoUsuario.Enabled = false;

                    hfIdUsuario.Value = LstUsuario[0].IdUsuario.ToString();
                    ObjetoEntidad_ControlesWebForm(Convert.ToInt32(hfIdUsuario.Value));

                    ControlesOnOFF(false);

                    BtnMnuEditar.Visible = true;
                    BtnMnuBorrar.Visible = true;

                    PnlCapturaDatos.Visible = true;
                    PnlGrvUsuarios.Visible = false;
                }
                else
                {
                    InicializaControles();
                    GrvUsuarios.DataSource = LstUsuario;
                    GrvUsuarios.DataBind();
                    PnlGrvUsuarios.Visible = true;
                }
            }
        }
        #endregion

        #region Botones IBM (WebForm captura datos del cliente)
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            string R = NU.InsertaUsuario(ControlesWebForm_ObjetoEntidad());
            lblTituloAccion.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(false);

            BtnGrabar.Visible = false;
            BtnCancelar.Visible = false;
            BtnAceptar.Visible = true;

            //string fromname = Convert.ToString(Session["NombreUsuario"]) + " " + Convert.ToString(Session["ApellidoPaterno"]) + " " + Convert.ToString(Session["ApellidoMaterno"]);
            //string toname = TbNombreUsuario.Text + " " + TbApellidoPaterno.Text + " " + TbApellidoMaterno.Text;

            //Response.Write("<script language=javascript>alert('" +
            //    "From Correo: " + Convert.ToString(Session["CorreoUsuario"]) +
            //    "From Nombre: " + fromname +
            //    " From Pass: " + Convert.ToString(Session["PassUsuario"]) +
            //    " To Correo: " + TbCorreoUsuario.Text +
            //    " To Nombre: " + toname +
            //    " To Clave: " + TbnumClaveUsuario1.Text +
            //    " To Pass: " + TbContraseñaUsuario1.Text +
            //    " To Tipo: " + ddlTipoUsuario.SelectedItem.Text +
            //    "');</script>");

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                string fromname = Convert.ToString(Session["NombreUsuario"]) + " " + Convert.ToString(Session["ApellidoPaterno"]) + " " + Convert.ToString(Session["ApellidoMaterno"]);
                string toname = TbNombreUsuario.Text + " " + TbApellidoPaterno.Text + " " + TbApellidoMaterno.Text;
                
                NotificarUsuario(Convert.ToString(Session["CorreoUsuario"]), fromname, Convert.ToString(Session["PassUsuario"]), TbCorreoUsuario.Text, toname, TbnumClaveUsuario1.Text, TbCorreoUsuario.Text, TbContraseñaUsuario1.Text, ddlTipoUsuario.SelectedItem.Text);

                InicializaControles();
            }
        }
        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            string R = NU.BorraUsuario(Convert.ToInt32(hfIdUsuario.Value));
            lblTituloAccion.Text = R;

            if (Convert.ToInt32(hfIdUsuario.Value) == Convert.ToInt32(Session["IdUsuario"]))
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

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(false);

            BtnBorrarModal.Visible = false;
            BtnCancelar.Visible = false;
            BtnAceptar.Visible = true;

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                InicializaControles();
            }
        }
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            E_Usuarios Cliente = ControlesWebForm_ObjetoEntidad();
            Cliente.IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
            string R = NU.ModificaUsuario(Cliente);
            lblTituloAccion.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(false);

            BtnModificar.Visible = false;
            BtnCancelar.Visible = false;
            BtnAceptar.Visible = true;

            //string fromname = Convert.ToString(Session["NombreUsuario"]) + " " + Convert.ToString(Session["ApellidoPaterno"]) + " " + Convert.ToString(Session["ApellidoMaterno"]);
            //string toname = TbNombreUsuario.Text + " " + TbApellidoPaterno.Text + " " + TbApellidoMaterno.Text;

            //Response.Write("<script language=javascript>alert('" +
            //    "From Correo: " + Convert.ToString(Session["CorreoUsuario"]) +
            //    "From Nombre: " + fromname +
            //    " From Pass: " + Convert.ToString(Session["PassUsuario"]) +
            //    " To Correo: " + TbCorreoUsuario.Text +
            //    " To Nombre: " + toname +
            //    " To Clave: " + TbnumClaveUsuario1.Text +
            //    " To Pass: " + TbContraseñaUsuario1.Text +
            //    " To Tipo: " + ddlTipoUsuario.SelectedItem.Text +
            //    "');</script>");

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                string fromname = Convert.ToString(Session["NombreUsuario"]) + " " + Convert.ToString(Session["ApellidoPaterno"]) + " " + Convert.ToString(Session["ApellidoMaterno"]);
                string toname = TbNombreUsuario.Text + " " + TbApellidoPaterno.Text + " " + TbApellidoMaterno.Text;
                
                NotificarUsuario(Convert.ToString(Session["CorreoUsuario"]), fromname, Convert.ToString(Session["PassUsuario"]), TbCorreoUsuario.Text, toname, TbnumClaveUsuario1.Text, TbCorreoUsuario.Text, TbContraseñaUsuario1.Text, ddlTipoUsuario.SelectedItem.Text);
                
                InicializaControles();
            }
        }
        protected void BtnMnuEditar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Modificar Usuario";

            TbCorreoUsuario.Enabled = false;
            //TbnumClaveUsuario1.Enabled = false;

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;
            ControlesOnOFF(true);
        }
        protected void BtnMnuBorrar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Borrar Usuario";
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;

            ControlesOnOFF(false);
        }
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            InicializaControles();
        }
        #endregion

        #region Métodos del GridView
        protected void GrvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ControlesOFF();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdUsuario.Value = GrvUsuarios.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Usuario";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdUsuario.Value));
            ControlesOnOFF(false);

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            PnlCapturaDatos.Visible = true;
            CargaTipoUsuario();
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            InicializaControles();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdUsuario.Value = GrvUsuarios.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Usuario";

            CargaTipoUsuario();
            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdUsuario.Value));
            ControlesOnOFF(true);

            TbCorreoUsuario.Enabled = false;
            //TbnumClaveUsuario1.Enabled = false;

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            GridViewRow row = GrvUsuarios.SelectedRow;
            string valor = Convert.ToString(GrvUsuarios.Rows[row.RowIndex].Cells[2].Text);
            
            List<E_Usuarios> LstUsuarios = NU.BuscaUsuario(valor);

            foreach (var item in LstUsuarios)
            {
                if (item != null)
                {
                    string fromname = Convert.ToString(Session["NombreUsuario"]) + " " + Convert.ToString(Session["ApellidoPaterno"]) + " " + Convert.ToString(Session["ApellidoMaterno"]);
                    string toname = item.NombreUsuario + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno;
                    
                    //Response.Write("<script language=javascript>alert('" +
                    //    "From Correo: " + Convert.ToString(Session["CorreoUsuario"]) +
                    //    "From Nombre: " + fromname +
                    //    " From Pass: " + Convert.ToString(Session["PassUsuario"]) +
                    //    " To Correo: " + item.CorreoUsuario +
                    //    " To Nombre: " + toname +
                    //    " To Clave: " + item.ClaveUsuario +
                    //    " To Pass: " + item.PassUsuario +
                    //    " To Tipo: " + item.TipoUsuario +
                    //    "');</script>");
                    
                    NotificarUsuario(Convert.ToString(Session["CorreoUsuario"]), fromname, Convert.ToString(Session["PassUsuario"]), item.CorreoUsuario, toname, item.ClaveUsuario, item.CorreoUsuario, item.PassUsuario, item.TipoUsuario);

                }
                else
                {

                }
            }
            }
        #endregion

        private void CargaTipoUsuario()
        {
            ListItem i;

            i = new ListItem("<Seleccione>", "");
            ddlTipoUsuario.Items.Add(i);
            i = new ListItem("CAPTURISTA", "1");
            ddlTipoUsuario.Items.Add(i);
            i = new ListItem("INTERNO", "2");
            ddlTipoUsuario.Items.Add(i);
            i = new ListItem("ADMINISTRADOR", "3");
            ddlTipoUsuario.Items.Add(i);
        }

        private void NotificarUsuario(string fromaddress, string fromname, string frompass, string toaddress, string toname, string clave, string correo, string pass, string tipo)
        {
            var fromAddress = new MailAddress(fromaddress, fromname);
            var toAddress = new MailAddress(toaddress, toname);
            string fromPassword = frompass;
            const string subject = "Datos de cuenta";
            string str = "Nombre: " + toname
                + " Clave: " + clave
                + " Correo: " + correo
                + " Contraseña: " + pass
                + " Tipo de usuario: " + tipo;
            string body1 = str;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body1
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    //el mensaje no se envio
                }
            }
        }


    }
}