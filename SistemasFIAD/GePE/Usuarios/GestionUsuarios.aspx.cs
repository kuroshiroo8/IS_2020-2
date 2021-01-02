using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            TbContraseñaUsuario.Text = string.Empty;
            TbClaveUsuario.Text = string.Empty;

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

            //Enabled TextBox
            TbCorreoUsuario.Enabled = TrueOrFalse;
            TbNombreUsuario.Enabled = TrueOrFalse;
            TbContraseñaUsuario.Enabled = TrueOrFalse;
            TbClaveUsuario.Enabled = TrueOrFalse;

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

            //Visible TextBox
            TbCorreoUsuario.Visible = TrueOrFalse;
            TbNombreUsuario.Visible = TrueOrFalse;
            TbContraseñaUsuario.Visible = TrueOrFalse;
            TbClaveUsuario.Visible = TrueOrFalse;

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
                PassUsuario = TbContraseñaUsuario.Text,
                TipoUsuario = ddlTipoUsuario.SelectedItem.Text,
                ClaveUsuario = Convert.ToInt32 (TbClaveUsuario.Text)
            };
            return Usuarios;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdUsuario)
        {
            E_Usuarios Usuarios = NU.BuscaUsuarioPorId(IdUsuario);

            TbNombreUsuario.Text = Usuarios.NombreUsuario.Trim();
            TbCorreoUsuario.Text = Usuarios.CorreoUsuario.Trim();
            TbContraseñaUsuario.Text = Usuarios.PassUsuario.Trim();
            CargaTipoUsuario();
            int index = 0;
            while (ddlTipoUsuario.SelectedItem.Text != Usuarios.TipoUsuario.Trim())
            {
                index = index + 1;
                ddlTipoUsuario.SelectedIndex = index;
            }
            ddlTipoUsuario.SelectedIndex = index;
            TbClaveUsuario.Text = Convert.ToString( Usuarios.ClaveUsuario);
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

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                InicializaControles();
            }
        }
        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            string R = NU.BorraUsuario(Convert.ToInt32(hfIdUsuario.Value));
            lblTituloAccion.Text = R;

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

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                InicializaControles();
            }
        }
        protected void BtnMnuEditar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Modificar Usuario";
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

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
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
    }
}