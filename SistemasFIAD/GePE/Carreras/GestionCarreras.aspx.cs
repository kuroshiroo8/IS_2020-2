using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace GePE.Carreras
{
    public partial class GestionCarreras : System.Web.UI.Page
    {
        N_Carreras NC = new N_Carreras();
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
            lbClaveCarrera.Visible = false;
            lbAliasCarrera.Visible = false;
            lbNombreCarrera.Visible = false;

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
            PnlGrvCarreras.Visible = false;
        }
        protected void ControlesClear()
        {
            //Clear Label
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;

            //Clear TextBox
            TbCriterioBusqueda.Text = string.Empty;
            TbClaveCarrera.Text = string.Empty;
            TbNombreCarrera.Text = string.Empty;
            TbAliasCarrera.Text = string.Empty;

            //Clear CheckBox
            cbActivaCarrera.Checked = false;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            //Enabled Label
            lbAliasCarrera.Enabled = TrueOrFalse;
            lbNombreCarrera.Enabled = TrueOrFalse;
            lbClaveCarrera.Enabled = TrueOrFalse;

            //Enabled TextBox
            TbClaveCarrera.Enabled = TrueOrFalse;
            TbNombreCarrera.Enabled = TrueOrFalse;
            TbAliasCarrera.Enabled = TrueOrFalse;

            //Enabled CheckBox
            cbActivaCarrera.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
            //Visible Label
            lbAliasCarrera.Visible = TrueOrFalse;
            lbNombreCarrera.Visible = TrueOrFalse;
            lbClaveCarrera.Visible = TrueOrFalse;

            //Visible TextBox
            TbClaveCarrera.Visible = TrueOrFalse;
            TbNombreCarrera.Visible = TrueOrFalse;
            TbAliasCarrera.Visible = TrueOrFalse;

            //Visible CheckBox
            cbActivaCarrera.Visible = TrueOrFalse;
        }
        #endregion

        #region Objeto Cliente
        protected E_Carreras ControlesWebForm_ObjetoEntidad()
        {
            E_Carreras Carrera = new E_Carreras()
            {
                ClaveCarrera = TbClaveCarrera.Text,
                NombreCarrera = TbNombreCarrera.Text,
                AliasCarrera = TbAliasCarrera.Text,
                EstadoCarrera = cbActivaCarrera.Checked
            };
            return Carrera;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdCarrera)
        {
            E_Carreras Carrera = NC.BuscaCarrerasPorId(IdCarrera);

            TbClaveCarrera.Text = Carrera.ClaveCarrera.Trim();
            TbNombreCarrera.Text = Carrera.NombreCarrera.Trim();
            TbAliasCarrera.Text = Carrera.AliasCarrera.Trim();
            cbActivaCarrera.Checked = Carrera.EstadoCarrera;
        }
        #endregion

        #region Botones menu de navegación 
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            lblTituloAccion.Text = "Nueva carrera";
            PnlCapturaDatos.Visible = true;

            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);
        }
        protected void BtnMnuListado_Click(object sender, EventArgs e)
        {
            InicializaControles();
            N_Carreras NC = new N_Carreras();
            GrvCarreras.DataSource = NC.LstCarreras();
            GrvCarreras.DataBind();
            PnlGrvCarreras.Visible = true;
        }
        protected void BtnMnuPDF_Click(object sender, EventArgs e)
        {
            lblNombreAccion.Text = "Aquí van las acciones del botón BtnMnuPDF";
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Carreras> LstCarrera = NC.BuscaCarrera(TbCriterioBusqueda.Text.Trim());
                if (LstCarrera.Count.Equals(0))
                {
                    InicializaControles();
                    lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
                }
                else if (LstCarrera.Count.Equals(1))
                {
                    InicializaControles();
                    lblTituloAccion.Text = "Resultado de busqueda";

                    //Aqui se ponen visibles los Label, TextBox y el CheckBox
                    VisibleOnOFF(true);

                    //Aqui se hacen no editables los TextBox
                    TbClaveCarrera.Enabled = false;
                    TbNombreCarrera.Enabled = false;
                    TbAliasCarrera.Enabled = false;

                    //Aqui se hacen no editables el CheckBox
                    cbActivaCarrera.Enabled = false;

                    hfIdCarrera.Value = LstCarrera[0].IdCarrera.ToString();
                    ObjetoEntidad_ControlesWebForm(Convert.ToInt32(hfIdCarrera.Value));

                    BtnMnuEditar.Visible = true;
                    BtnMnuBorrar.Visible = true;

                    PnlCapturaDatos.Visible = true;
                    PnlGrvCarreras.Visible = false;
                }
                else
                {
                    InicializaControles();
                    GrvCarreras.DataSource = LstCarrera;
                    GrvCarreras.DataBind();
                    PnlGrvCarreras.Visible = true;
                }
            }
        }
        #endregion

        protected void BtnMnuAsignaPlanDeEstudio_Click(object sender, EventArgs e)
        {
            lblNombreAccion.Text = "Aquí van las acciones del botón BtnMnuAsignaPlanDeEstudio";
        }

        #region Botones IBM (WebForm captura datos del cliente)
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            string R = NC.InsertaCarreras(ControlesWebForm_ObjetoEntidad());
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
            string R = NC.BorraCarreras(Convert.ToInt32(hfIdCarrera.Value));
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
            E_Carreras Cliente = ControlesWebForm_ObjetoEntidad();
            Cliente.IdCarrera = Convert.ToInt32(hfIdCarrera.Value);
            string R = NC.ModificaCarreras(Cliente);
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
            lblTituloAccion.Text = "Modificar Carrera";
            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;
            ControlesOnOFF(true);
        }
        protected void BtnMnuBorrar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Borrar Carrera";
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
        protected void GrvCarreras_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ControlesOFF();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdCarrera.Value = GrvCarreras.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Carrera";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdCarrera.Value));
            ControlesOnOFF(false);

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            PnlCapturaDatos.Visible = true;
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvCarreras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            InicializaControles();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdCarrera.Value = GrvCarreras.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Carrera";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdCarrera.Value));
            ControlesOnOFF(true);

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
        }

        #endregion

        protected void GrvCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "AQUI SE ASIGNARA EL PLAN DE ESTUDIOS A LAS CARRERAS";
        }
    }
}