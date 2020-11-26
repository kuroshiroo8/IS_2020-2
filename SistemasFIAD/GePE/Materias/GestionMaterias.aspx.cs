using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace GePE.Materias
{
    public partial class GestionMaterias : System.Web.UI.Page
    {
        N_Materias NM = new N_Materias();
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
            BtnGrabar.Visible = false;
            BtnBorrar.Visible = false;
            BtnBorrarModal.Visible = false;
            BtnModificar.Visible = false;
            BtnMnuEditar.Visible = false;
            BtnMnuBorrar.Visible = false;
            BtnCancelar.Visible = false;
            BtnAceptar.Visible = false;

            lbClaveMateria.Visible = false;
            lbNombreMateria.Visible = false;
            lbHC.Visible = false;
            lbHL.Visible = false;
            lbHT.Visible = false;
            lbHE.Visible = false;
            lbHPP.Visible = false;
            lbCR.Visible = false;
            lbEstadoMateria.Visible = false;
            lbPathPUA.Visible = false;
            lbPathPUAnoOficial.Visible = false;

            PnlCapturaDatos.Visible = false;
            PnlGrvMateria.Visible = false;
        }
        protected void ControlesClear()
        {
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;

            TbCriterioBusqueda.Text = string.Empty;

            //Clear TextBox
            TbClaveMateria.Text = string.Empty;
            TbNombreMateria.Text = string.Empty;
            TbHC.Text = string.Empty;
            TbHL.Text = string.Empty;
            TbHT.Text = string.Empty;
            TbHE.Text = string.Empty;
            TbHPP.Text = string.Empty;
            TbCR.Text = string.Empty;
            TbPathPUA.Text = string.Empty;
            TbPathPUAnoOficial.Text = string.Empty;

            //Clear CheckBox
            cbEstadoMateria.Checked = false;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            lblNombreAccion.Enabled = TrueOrFalse;
            lblTituloAccion.Enabled = TrueOrFalse;

            //Enabled Labels
            lbClaveMateria.Enabled = TrueOrFalse;
            lbNombreMateria.Enabled = TrueOrFalse;
            lbHC.Enabled = TrueOrFalse;
            lbHL.Enabled = TrueOrFalse;
            lbHT.Enabled = TrueOrFalse;
            lbHE.Enabled = TrueOrFalse;
            lbHPP.Enabled = TrueOrFalse;
            lbCR.Enabled = TrueOrFalse;
            lbEstadoMateria.Enabled = TrueOrFalse;
            lbPathPUA.Enabled = TrueOrFalse;
            lbPathPUAnoOficial.Enabled = TrueOrFalse;

            //Enabled TextBox
            TbClaveMateria.Enabled = TrueOrFalse;
            TbNombreMateria.Enabled = TrueOrFalse;
            TbHC.Enabled = TrueOrFalse;
            TbHL.Enabled = TrueOrFalse;
            TbHT.Enabled = TrueOrFalse;
            TbHE.Enabled = TrueOrFalse;
            TbHPP.Enabled = TrueOrFalse;
            TbCR.Enabled = TrueOrFalse;
            TbPathPUA.Enabled = TrueOrFalse;
            TbPathPUAnoOficial.Enabled = TrueOrFalse;

            //Enabled CheckBox
            cbEstadoMateria.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
            //Visible Labels
            lbClaveMateria.Visible = TrueOrFalse;
            lbNombreMateria.Visible = TrueOrFalse;
            lbHC.Visible = TrueOrFalse;
            lbHL.Visible = TrueOrFalse;
            lbHT.Visible = TrueOrFalse;
            lbHE.Visible = TrueOrFalse;
            lbHPP.Visible = TrueOrFalse;
            lbCR.Visible = TrueOrFalse;
            lbEstadoMateria.Visible = TrueOrFalse;
            lbPathPUA.Visible = TrueOrFalse;
            lbPathPUAnoOficial.Visible = TrueOrFalse;

            //Visible TextBox
            TbClaveMateria.Visible = TrueOrFalse;
            TbNombreMateria.Visible = TrueOrFalse;
            TbHC.Visible = TrueOrFalse;
            TbHL.Visible = TrueOrFalse;
            TbHT.Visible = TrueOrFalse;
            TbHE.Visible = TrueOrFalse;
            TbHPP.Visible = TrueOrFalse;
            TbCR.Visible = TrueOrFalse;
            TbPathPUA.Visible = TrueOrFalse;
            TbPathPUAnoOficial.Visible = TrueOrFalse;

            //Visible CheckBox
            cbEstadoMateria.Visible = TrueOrFalse;
        }
        #endregion

        #region Objeto Cliente
        protected E_Materias ControlesWebForm_ObjetoEntidad()
        {
            E_Materias Materia = new E_Materias()
            {
                ClaveMateria = TbClaveMateria.Text,
                NombreMateria = TbNombreMateria.Text,
                //HC = TbHC.Text.Trim,
                //HL = TbHL.Text,
                //HT = TbHT.Text,
                //HE = TbHE.Text,
                //CR = TbCR.Text,
                EstadoMateria = cbEstadoMateria.Checked,
                PathPUA = TbPathPUA.Text,
                PathPUAnoOficial = TbPathPUAnoOficial.Text
            };
            return Materia;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdMateria)
        {
            //agrega los datos a la base de datos
            E_Materias Materia = NM.BuscaMateriasPorId(IdMateria);

            TbClaveMateria.Text = Materia.ClaveMateria.Trim();
            TbNombreMateria.Text = Materia.NombreMateria.Trim();
            //TbHC.Text = Materia.HC;
            //TbHL.Text = Materia.HL;
            //TbHT.Text = Materia.HT;
            //TbHE.Text = Materia.HE;
            //TbCR.Text = Materia.CR;
            cbEstadoMateria.Checked = Materia.EstadoMateria;
            TbPathPUA.Text = Materia.PathPUA.Trim();
            TbPathPUAnoOficial.Text = Materia.PathPUAnoOficial.Trim();
        }
        #endregion

        #region Botones menu de navegación
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            lblTituloAccion.Text = "Nueva materia";
            PnlCapturaDatos.Visible = true;

            //aqui se hacen visible los Label, Textbox y los DropDownList
            VisibleOnOFF(true);

            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void BtnMnuListado_Click(object sender, EventArgs e)
        {
            InicializaControles();
            N_Materias NM = new N_Materias();
            GrvMateria.DataSource = NM.LstMaterias();
            GrvMateria.DataBind();
            PnlGrvMateria.Visible = true;
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_Materias> LstMateria = NM.BuscaMateria(TbCriterioBusqueda.Text.Trim());
                if (LstMateria.Count.Equals(0))
                {
                    InicializaControles();
                    lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
                }
                else if (LstMateria.Count.Equals(1))
                {
                    InicializaControles();
                    lblTituloAccion.Text = "Resultado de busqueda";

                    //Aqui se hacen visible los Label, TextBox y el CheckBox
                    VisibleOnOFF(true);

                    //Aqui se hacen no editables los Label, TextBox y el CheckBox
                    TbClaveMateria.Enabled = false;
                    TbNombreMateria.Enabled = false;
                    TbHC.Enabled = false;
                    TbHL.Enabled = false;
                    TbHT.Enabled = false;
                    TbHE.Enabled = false;
                    TbHPP.Enabled = false;
                    TbCR.Enabled = false;
                    TbPathPUA.Enabled = false;
                    TbPathPUAnoOficial.Enabled = false;
                    cbEstadoMateria.Enabled = false;

                    hfIdMateria.Value = LstMateria[0].IdMateria.ToString();
                    ObjetoEntidad_ControlesWebForm(Convert.ToInt32(hfIdMateria.Value));
                    PnlCapturaDatos.Visible = true;
                    BtnMnuEditar.Visible = true;
                    BtnMnuBorrar.Visible = true;
                    PnlGrvMateria.Visible = false;
                }
                else
                {
                    InicializaControles();
                    GrvMateria.DataSource = LstMateria;
                    GrvMateria.DataBind();
                    PnlGrvMateria.Visible = true;
                }
            }
        }
        #endregion

        #region Botones IBM (WebForm captura datos del cliente)
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            string R = NM.InsertaMaterias(ControlesWebForm_ObjetoEntidad());
            lblTituloAccion.Text = R;

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
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
            string R = NM.BorraMaterias(Convert.ToInt32(hfIdMateria.Value));
            lblTituloAccion.Text = R;

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
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
            E_Materias Cliente = ControlesWebForm_ObjetoEntidad();
            Cliente.IdMateria = Convert.ToInt32(hfIdMateria.Value);
            string R = NM.ModificaMaterias(Cliente);
            lblTituloAccion.Text = R;

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
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
            lblTituloAccion.Text = "Modificar Materia";
            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;
            ControlesOnOFF(true);
        }
        protected void BtnMnuBorrar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Borrar Materia";
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
        protected void GrvMaterias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ControlesOFF();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdMateria.Value = GrvMateria.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Materia";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdMateria.Value));
            ControlesOnOFF(false);

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            PnlCapturaDatos.Visible = true;
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvMaterias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            InicializaControles();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdMateria.Value = GrvMateria.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Materia";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdMateria.Value));
            ControlesOnOFF(true);

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
        }
        #endregion

        protected void GrvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "AQUI SE ASIGNARA EL PLAN DE ESTUDIOS A LAS MATERIAS";
        }


    }

}