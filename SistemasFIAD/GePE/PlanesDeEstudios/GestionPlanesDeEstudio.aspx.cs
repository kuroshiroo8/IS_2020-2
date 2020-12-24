using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace GePE.PlanesDeEstudios
{
    public partial class GestionPlanesDeEstudio : System.Web.UI.Page
    {
        N_PlanEstudio PE = new N_PlanEstudio();
        N_PlanEstudioMateria NPEM = new N_PlanEstudioMateria();
        public int entra = 1;
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
            lbPnlGrvMapaCurricularNombreCarrera.Visible = false;
            lbPnlGrvMapaCurricularPlanEstudio.Visible = false;
            PnlGrvMapaCurricular.Visible = false;

            //Visible Label
            lbIdNivelAcademico.Visible = false;
            lbClavePlanEstudio.Visible = false;
            lbPlanEstudio.Visible = false;
            lbProgramaEducativo.Visible = false;
            lbFechaCreacion.Visible = false;
            lbTotalCreditos.Visible = false;
            lbEstadoPlanEstudios.Visible = false;
            lbComentarios.Visible = false;
            lbPerfilDeIngreso.Visible = false;
            lbPerfilDeEgreso.Visible = false;
            lbCampoOcupacional.Visible = false;
            lbUnidadAcademica.Visible = false;
            //lbEstatus.Visible = false;

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
            PnlGrvPlanEstudio.Visible = false;

            //Visible Label
            lbIdPlanEstudio.Visible = false;
            lbIdMateria.Visible = false;
            lbIdTipoMateria.Visible = false;
            lbIdEtapa.Visible = false;
            lbIdAreaConocimiento.Visible = false;
            lbSemestre.Visible = false;
            lbSeriada.Visible = false;

            //Visible LinkButton
            BtnGrabarPlanEstudioMateria.Visible = false;
            BtnBorrarPlanEstudioMateria.Visible = false;
            BtnBorrarModalPlanEstudioMateria.Visible = false;
            BtnModificarPlanEstudioMateria.Visible = false;
            BtnMnuEditarPlanEstudioMateria.Visible = false;
            BtnMnuBorrarPlanEstudioMateria.Visible = false;
            BtnCancelarPlanEstudioMateria.Visible = false;
            BtnAceptarPlanEstudioMateria.Visible = false;

            //Visible Panel
            PnlCapturaDatosPlanEstudioMateria.Visible = false;
            PnlGrvPlanEstudioMateria.Visible = false;

        }
        protected void ControlesClear()
        {
            lbPnlGrvMapaCurricularNombreCarrera.Text = string.Empty;
            lbPnlGrvMapaCurricularPlanEstudio.Text = string.Empty;

            //Clear Label
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;

            //Clear TextBox
            TbClavePlanEstudio.Text = string.Empty;
            TbPlanEstudio.Text = string.Empty;
            TbFechaCreacion.Text = string.Empty;
            TbTotalCreditos.Text = string.Empty;
            TbComentarios.Text = string.Empty;
            TbPerfilDeIngreso.Text = string.Empty;
            TbPerfilDeEgreso.Text = string.Empty;
            TbCampoOcupacional.Text = string.Empty;

            //Clear DropDownList
            ddlIdNivelAcademico.Items.Clear();
            ddlProgramaEducativo.Items.Clear();
            ddlUnidadAcademica.Items.Clear();
            ddlEstatus.Items.Clear();

            //Clear CheckBox
            cbEstadoPlanEstudios.Checked = false;

            //Clear Label
            lblNombreAccion.Text = string.Empty;
            lblTituloAccionPlanEstudioMateria.Text = string.Empty;

            //Clear DropDownList
            ddlIdPlanEstudio.Items.Clear();
            ddlIdMateria.Items.Clear();
            ddlIdTipoMateria.Items.Clear();
            ddlIdEtapa.Items.Clear();
            ddlIdAreaConocimiento.Items.Clear();
            ddlSemestre.Items.Clear();
            ddlMateriaSeriada.Items.Clear();

            //Clear CheckBox
            cbSeriada.Checked = false;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            //Enabled Label
            lbIdNivelAcademico.Enabled = TrueOrFalse;
            lbClavePlanEstudio.Enabled = TrueOrFalse;
            lbPlanEstudio.Enabled = TrueOrFalse;
            lbProgramaEducativo.Enabled = TrueOrFalse;
            lbFechaCreacion.Enabled = TrueOrFalse;
            lbTotalCreditos.Enabled = TrueOrFalse;
            lbEstadoPlanEstudios.Enabled = TrueOrFalse;
            lbComentarios.Enabled = TrueOrFalse;
            lbPerfilDeIngreso.Enabled = TrueOrFalse;
            lbPerfilDeEgreso.Enabled = TrueOrFalse;
            lbCampoOcupacional.Enabled = TrueOrFalse;
            lbUnidadAcademica.Enabled = TrueOrFalse;
            //lbEstatus.Enabled = TrueOrFalse;

            //Clear TextBox
            TbClavePlanEstudio.Enabled = TrueOrFalse;
            TbPlanEstudio.Enabled = TrueOrFalse;
            TbFechaCreacion.Enabled = TrueOrFalse;
            TbTotalCreditos.Enabled = TrueOrFalse;
            TbComentarios.Enabled = TrueOrFalse;
            TbPerfilDeIngreso.Enabled = TrueOrFalse;
            TbPerfilDeEgreso.Enabled = TrueOrFalse;
            TbCampoOcupacional.Enabled = TrueOrFalse;

            //Clear DropDownList
            ddlIdNivelAcademico.Enabled = TrueOrFalse;
            ddlProgramaEducativo.Enabled = TrueOrFalse;
            ddlUnidadAcademica.Enabled = TrueOrFalse;
            ddlEstatus.Enabled = TrueOrFalse;

            //Clear CheckBox
            cbEstadoPlanEstudios.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
            //Visible Label
            lbIdNivelAcademico.Visible = TrueOrFalse;
            lbClavePlanEstudio.Visible = TrueOrFalse;
            lbPlanEstudio.Visible = TrueOrFalse;
            lbProgramaEducativo.Visible = TrueOrFalse;
            lbFechaCreacion.Visible = TrueOrFalse;
            lbTotalCreditos.Visible = TrueOrFalse;
            lbEstadoPlanEstudios.Visible = TrueOrFalse;
            lbComentarios.Visible = TrueOrFalse;
            lbPerfilDeIngreso.Visible = TrueOrFalse;
            lbPerfilDeEgreso.Visible = TrueOrFalse;
            lbCampoOcupacional.Visible = TrueOrFalse;
            lbUnidadAcademica.Visible = TrueOrFalse;
            //lbEstatus.Visible = TrueOrFalse;

            //Visible TextBox
            TbClavePlanEstudio.Visible = TrueOrFalse;
            TbPlanEstudio.Visible = TrueOrFalse;
            TbFechaCreacion.Visible = TrueOrFalse;
            TbTotalCreditos.Visible = TrueOrFalse;
            TbComentarios.Visible = TrueOrFalse;
            TbPerfilDeIngreso.Visible = TrueOrFalse;
            TbPerfilDeEgreso.Visible = TrueOrFalse;
            TbCampoOcupacional.Visible = TrueOrFalse;

            //Visible DropDownList
            ddlIdNivelAcademico.Visible = TrueOrFalse;
            ddlProgramaEducativo.Visible = TrueOrFalse;
            ddlUnidadAcademica.Visible = TrueOrFalse;
            ddlEstatus.Visible = TrueOrFalse;

            //Visible CheckBox
            cbEstadoPlanEstudios.Visible = TrueOrFalse;
        }
        private void CargarDatosListasPlanEstudio()
        {
            ddlProgramaEducativo.Items.Clear();
            DroplistProgramaEducativo();

            ddlEstatus.Items.Clear();
            DroplistEstatus();

            ddlIdNivelAcademico.Items.Clear();
            DroplistGradoAcademico();

            ddlUnidadAcademica.Items.Clear();
            DroplistUnidadAcademica();

            ddlMateriaSeriada.Items.Clear();
            DroplistMateriaSeriada();
        }
        #endregion

        #region Métodos generales Plan Estudio - Materia
        protected void InicializaControlesPlanEstudioMateria()
        {
            ControlesOFF();
            ControlesClear();
            ControlesOnOFFPlanEstudioMateria(true);
        }
        protected void ControlesOnOFFPlanEstudioMateria(bool TrueOrFalse)
        {
            //Enabled Label
            lbIdPlanEstudio.Enabled = TrueOrFalse;
            lbIdMateria.Enabled = TrueOrFalse;
            lbIdTipoMateria.Enabled = TrueOrFalse;
            lbIdEtapa.Enabled = TrueOrFalse;
            lbIdAreaConocimiento.Enabled = TrueOrFalse;
            lbSemestre.Enabled = TrueOrFalse;
            lbSeriada.Enabled = TrueOrFalse;
            lbMateriaSeriada.Enabled = TrueOrFalse;

            //Clear DropDownList
            ddlIdPlanEstudio.Enabled = TrueOrFalse;
            ddlIdMateria.Enabled = TrueOrFalse;
            ddlIdTipoMateria.Enabled = TrueOrFalse;
            ddlIdEtapa.Enabled = TrueOrFalse;
            ddlIdAreaConocimiento.Enabled = TrueOrFalse;
            ddlSemestre.Enabled = TrueOrFalse;
            ddlMateriaSeriada.Enabled = TrueOrFalse;

            cbSeriada.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFFPlanEstudioMateria(bool TrueOrFalse)
        {
            //Visible Label
            lbIdPlanEstudio.Visible = TrueOrFalse;
            lbIdMateria.Visible = TrueOrFalse;
            lbIdTipoMateria.Visible = TrueOrFalse;
            lbIdEtapa.Visible = TrueOrFalse;
            lbIdAreaConocimiento.Visible = TrueOrFalse;
            lbSemestre.Visible = TrueOrFalse;
            lbSeriada.Visible = TrueOrFalse;
            lbMateriaSeriada.Visible = TrueOrFalse;

            //Visible DropDownList
            ddlIdPlanEstudio.Visible = TrueOrFalse;
            ddlIdMateria.Visible = TrueOrFalse;
            ddlIdTipoMateria.Visible = TrueOrFalse;
            ddlIdEtapa.Visible = TrueOrFalse;
            ddlIdAreaConocimiento.Visible = TrueOrFalse;
            ddlSemestre.Visible = TrueOrFalse;
            ddlMateriaSeriada.Visible = TrueOrFalse;

            cbSeriada.Visible = TrueOrFalse;
        }
        private void CargarDatosListasPlanEstudioMateria()
        {
            ddlIdPlanEstudio.Items.Clear();
            DroplistPlanEstudio();

            ddlIdMateria.Items.Clear();
            DroplistMateria();

            ddlIdTipoMateria.Items.Clear();
            DroplistTipoMateria();

            ddlIdEtapa.Items.Clear();
            DroplistEtapa();

            ddlIdAreaConocimiento.Items.Clear();
            DroplistAreaConocimiento();

            ddlSemestre.Items.Clear();
            DroplistSemestre();

            ddlMateriaSeriada.Items.Clear();
            DroplistMateriaSeriada();
        }
        #endregion

        #region Objeto Cliente
        protected E_PlanEstudio ControlesWebForm_ObjetoEntidad()
        {
            E_PlanEstudio PlanEstudio = new E_PlanEstudio()
            {
                IdNivelAcademico = ddlIdNivelAcademico.SelectedIndex,
                IdCarrera = Convert.ToInt32(ddlProgramaEducativo.SelectedValue),
                ClavePlanEstudio = TbClavePlanEstudio.Text,
                PlanEstudio = TbPlanEstudio.Text,
                ProgramaEducativo = ddlProgramaEducativo.SelectedItem.Value,
                FechaCreacion = TbFechaCreacion.Text,
                TotalCreditos = Convert.ToInt32(TbTotalCreditos.Text),
                EstadoPlanEstudios = cbEstadoPlanEstudios.Checked,
                Comentarios = TbComentarios.Text,
                PerfilDeIngreso = TbPerfilDeIngreso.Text,
                PerfilDeEgreso = TbPerfilDeEgreso.Text,
                CampoOcupacional = TbCampoOcupacional.Text,
                UnidadAcademica = ddlUnidadAcademica.SelectedItem.Value,
                Estatus = ddlEstatus.SelectedItem.Text,
                IdEstatus = ddlEstatus.SelectedIndex,
                NombreCarrera = ddlProgramaEducativo.SelectedItem.Text
            };
            return PlanEstudio;

        }
        protected void ObjetoEntidad_ControlesWebForm(int IdPlanEstudio)
        {
            E_PlanEstudio planEstudio = PE.BuscaPlanEstudioPorId(IdPlanEstudio);

            ddlIdNivelAcademico.SelectedValue = Convert.ToString(planEstudio.IdNivelAcademico);
            TbClavePlanEstudio.Text = planEstudio.ClavePlanEstudio.Trim();
            TbPlanEstudio.Text = planEstudio.PlanEstudio.Trim();
            ddlProgramaEducativo.SelectedValue = Convert.ToString(planEstudio.ProgramaEducativo);//--------------
            TbFechaCreacion.Text = planEstudio.FechaCreacion.Trim();
            TbTotalCreditos.Text = Convert.ToString(planEstudio.TotalCreditos);
            cbEstadoPlanEstudios.Checked = planEstudio.EstadoPlanEstudios;
            TbComentarios.Text = planEstudio.Comentarios.Trim();
            TbPerfilDeIngreso.Text = planEstudio.PerfilDeIngreso.Trim();
            TbPerfilDeEgreso.Text = planEstudio.PerfilDeEgreso.Trim();
            TbCampoOcupacional.Text = planEstudio.CampoOcupacional.Trim();
            ddlUnidadAcademica.SelectedValue = Convert.ToString(planEstudio.UnidadAcademica);//------------------
            ddlEstatus.SelectedValue = Convert.ToString(planEstudio.IdEstatus);
        }
        #endregion

        #region Objeto Cliente Plan Estudio - Materia
        protected E_PlanEstudioMateria ControlesWebForm_ObjetoEntidad2()
        {

            if (cbSeriada.Checked && ddlMateriaSeriada.SelectedIndex !=0)
            {
                E_PlanEstudioMateria PlanEstudioMateria = new E_PlanEstudioMateria()
                {
                    IdPlanEstudio = Convert.ToInt32(ddlIdPlanEstudio.SelectedItem.Value),
                    IdMateria = Convert.ToInt32(ddlIdMateria.SelectedItem.Value),
                    IdTipoMateria = Convert.ToInt32(ddlIdTipoMateria.SelectedItem.Value),
                    IdEtapa = Convert.ToInt32(ddlIdEtapa.SelectedItem.Value),
                    IdAreaConocimiento = Convert.ToInt32(ddlIdAreaConocimiento.SelectedItem.Value),
                    Semestre = Convert.ToInt32(ddlSemestre.SelectedItem.Value),
                    NombrePlanEstudio = ddlIdPlanEstudio.SelectedItem.Text,
                    NombreMateria = ddlIdMateria.SelectedItem.Text,
                    NombreTipoMateria = ddlIdTipoMateria.SelectedItem.Text,
                    NombreEtapa = ddlIdEtapa.SelectedItem.Text,
                    NombreArea = ddlIdAreaConocimiento.SelectedItem.Text,
                    IdMateriaSeriada = Convert.ToInt32(ddlMateriaSeriada.SelectedItem.Value),
                    EstadoMateriaSeriada = cbSeriada.Checked,
                    ClavePlanEstudio = TbClavePlanEstudio.Text
                };
                return PlanEstudioMateria;
            }
            else
            {
                E_PlanEstudioMateria PlanEstudioMateria = new E_PlanEstudioMateria()
                {
                    IdPlanEstudio = Convert.ToInt32(ddlIdPlanEstudio.SelectedItem.Value),
                    IdMateria = Convert.ToInt32(ddlIdMateria.SelectedItem.Value),
                    IdTipoMateria = Convert.ToInt32(ddlIdTipoMateria.SelectedItem.Value),
                    IdEtapa = Convert.ToInt32(ddlIdEtapa.SelectedItem.Value),
                    IdAreaConocimiento = Convert.ToInt32(ddlIdAreaConocimiento.SelectedItem.Value),
                    Semestre = Convert.ToInt32(ddlSemestre.SelectedItem.Value),
                    NombrePlanEstudio = ddlIdPlanEstudio.SelectedItem.Text,
                    NombreMateria = ddlIdMateria.SelectedItem.Text,
                    NombreTipoMateria = ddlIdTipoMateria.SelectedItem.Text,
                    NombreEtapa = ddlIdEtapa.SelectedItem.Text,
                    NombreArea = ddlIdAreaConocimiento.SelectedItem.Text,
                    EstadoMateriaSeriada = false,
                    ClavePlanEstudio = TbClavePlanEstudio.Text
                };
                return PlanEstudioMateria;
            }



        }
        protected void ObjetoEntidad_ControlesWebForm2(int IdPlanEstudioMateria)
        {
            E_PlanEstudioMateria PlanEstudioMateria = NPEM.BuscaPlanEstudioMateriaPorId(IdPlanEstudioMateria);
            if (PlanEstudioMateria.EstadoMateriaSeriada != false)
            {
                string nombreplan = Convert.ToString(PlanEstudioMateria.NombrePlanEstudio);
                ddlIdMateria.SelectedValue = Convert.ToString(PlanEstudioMateria.IdMateria);
                ddlIdTipoMateria.SelectedIndex = PlanEstudioMateria.IdTipoMateria;
                ddlIdEtapa.SelectedIndex = PlanEstudioMateria.IdEtapa;
                ddlIdAreaConocimiento.SelectedIndex = PlanEstudioMateria.IdAreaConocimiento;
                ddlSemestre.SelectedIndex = PlanEstudioMateria.Semestre;
                cbSeriada.Checked = PlanEstudioMateria.EstadoMateriaSeriada;

                TbClavePlanEstudio.Text = PlanEstudioMateria.ClavePlanEstudio.Trim();

                //se creo un indice para recorrer el dropdownlist y comparar el texto
                int index = 0;//1
                while (ddlIdPlanEstudio.SelectedItem.Text != nombreplan)
                {
                    index = index + 1;
                    ddlIdPlanEstudio.SelectedIndex = index;
                }
                ddlIdPlanEstudio.SelectedIndex = index;
                DroplistMateriaSeriada();
                ddlMateriaSeriada.SelectedValue = Convert.ToString(PlanEstudioMateria.IdMateriaSeriada);
                
            }
            else
            {
                string nombreplan = Convert.ToString(PlanEstudioMateria.NombrePlanEstudio);
                ddlIdMateria.SelectedValue = Convert.ToString(PlanEstudioMateria.IdMateria);
                ddlIdTipoMateria.SelectedIndex = PlanEstudioMateria.IdTipoMateria;
                ddlIdEtapa.SelectedIndex = PlanEstudioMateria.IdEtapa;
                ddlIdAreaConocimiento.SelectedIndex = PlanEstudioMateria.IdAreaConocimiento;
                ddlSemestre.SelectedIndex = PlanEstudioMateria.Semestre;
                cbSeriada.Checked = PlanEstudioMateria.EstadoMateriaSeriada;

                //se creo un indice para recorrer el dropdownlist y comparar el texto
                int index = 0;//1
                while (ddlIdPlanEstudio.SelectedItem.Text != nombreplan)
                {
                    index = index + 1;
                    ddlIdPlanEstudio.SelectedIndex = index;
                }
                ddlIdPlanEstudio.SelectedIndex = index;
                TbClavePlanEstudio.Text = PlanEstudioMateria.ClavePlanEstudio.Trim();
            }

        }
        #endregion

        #region Botones menu de navegación 
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            lblTituloAccion.Text = "Nuevo plan de estudio";
            PnlCapturaDatos.Visible = true;

            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudio();

            lbEstatus.Visible = false;
            ddlEstatus.Visible = false;
        }
        protected void BtnMnuListado_Click(object sender, EventArgs e)
        {
            InicializaControles();
            N_PlanEstudio PE = new N_PlanEstudio();
            GrvPlanEstudio.DataSource = PE.LstPlanEstudio();
            //GrvPlanEstudio.DataBind();
            //PnlGrvPlanEstudio.Visible = true;

            if (PE.LstPlanEstudio().Count.Equals(0))
            {
                InicializaControles();
                lblNombreAccion.Text = "No se encontraron planes para listar";
            }
            else
            {
                GrvPlanEstudio.DataBind();
                PnlGrvPlanEstudio.Visible = true;
            }
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudio(TbCriterioBusqueda.Text.Trim());
                if (LstPlanEstudio.Count.Equals(0))
                {
                    InicializaControles();
                    lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
                }
                else if (LstPlanEstudio.Count.Equals(1))
                {
                    InicializaControles();
                    lblTituloAccion.Text = "Resultado de busqueda";

                    VisibleOnOFF(true);

                    //Aqui se cargan los datos de las listas de plan estudio materia
                    CargarDatosListasPlanEstudio();

                    //Aqui se hacen no editables los TextBox
                    ControlesOnOFF(false);

                    hfIdPlanEstudio.Value = LstPlanEstudio[0].IdPlanEstudio.ToString();
                    ObjetoEntidad_ControlesWebForm(Convert.ToInt32(hfIdPlanEstudio.Value));

                    BtnMnuEditar.Visible = true;
                    BtnMnuBorrar.Visible = true;

                    PnlCapturaDatos.Visible = true;
                    PnlGrvPlanEstudio.Visible = false;
                }
                else
                {
                    InicializaControles();
                    GrvPlanEstudio.DataSource = LstPlanEstudio;
                    GrvPlanEstudio.DataBind();
                    PnlGrvPlanEstudio.Visible = true;
                }
            }
        }
        #endregion

        #region Botones menu de navegación Plan Estudio - Materia
        protected void BtnMnuNuevoPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            InicializaControlesPlanEstudioMateria();
            lblTituloAccionPlanEstudioMateria.Text = "Nuevo plan de estudio";
            PnlCapturaDatosPlanEstudioMateria.Visible = true;

            BtnGrabarPlanEstudioMateria.Visible = true;
            BtnCancelarPlanEstudioMateria.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(true);

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudioMateria();

            lbMateriaSeriada.Visible = false;
            ddlMateriaSeriada.Visible = false;

        }
        protected void BtnMnuListadoPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            InicializaControlesPlanEstudioMateria();
            N_PlanEstudioMateria NPEM = new N_PlanEstudioMateria();
            GrvPlanEstudioMateria.DataSource = NPEM.LstPlanEstudioMateria();
            GrvPlanEstudioMateria.DataBind();
            PnlGrvPlanEstudioMateria.Visible = true;
        }
        #endregion

        #region Botones IBM (WebForm captura datos del cliente)
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            string R = PE.InsertaPlanEstudio(ControlesWebForm_ObjetoEntidad());
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
            string R = PE.BorraPlanEstudio(Convert.ToInt32(hfIdPlanEstudio.Value));
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
            E_PlanEstudio Cliente = ControlesWebForm_ObjetoEntidad();
            Cliente.IdPlanEstudio = Convert.ToInt32(hfIdPlanEstudio.Value);
            string R = PE.ModificaPlanEstudio(Cliente);
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
            lblTituloAccion.Text = "Modificar plan de estudio";

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;

            ControlesOnOFF(true);
        }
        protected void BtnMnuBorrar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Borrar Plan de estudio";
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

        #region Botones IBM (WebForm captura datos del cliente) Plan Estudio - Materia
        protected void BtnGrabarPlanEstudioMateria_Click(object sender, EventArgs e)
        {

            string str1 = Convert.ToString(ddlIdPlanEstudio.SelectedItem.Value);
            string str2 = Convert.ToString(ddlIdMateria.SelectedItem.Value);
            string str3 = Convert.ToString(ddlIdTipoMateria.SelectedItem.Value);
            string str4 = Convert.ToString(ddlIdEtapa.SelectedItem.Value);
            string str5 = Convert.ToString(ddlIdAreaConocimiento.SelectedItem.Value);
            string str6 = Convert.ToString(ddlSemestre.SelectedItem.Value);
            string str7 = Convert.ToString(ddlIdPlanEstudio.SelectedItem.Text);
            string str8 = Convert.ToString(ddlIdMateria.SelectedItem.Text);
            string str9 = Convert.ToString(ddlIdTipoMateria.SelectedItem.Text);
            string str10 = Convert.ToString(ddlIdEtapa.SelectedItem.Text);
            string str11 = Convert.ToString(ddlIdAreaConocimiento.SelectedItem.Text);
            string str12 = Convert.ToString(ddlMateriaSeriada.SelectedItem.Value);
            string str13 = Convert.ToString(cbSeriada.Checked);
            Response.Write("<script language=javascript>alert('" +
                "IdPlanEstudio: " + str1 +
                " IdMateria: " + str2 +
                " IdTipoMateria: " + str3 +
                " IdEtapa: " + str4 +
                " IdAreaConocimiento: " + str5 +
                " Semestre: " + str6 +
                " NombrePlanEstudio: " + str7 +
                " NombreMateria: " + str8 +
                " NombreTipoMateria: " + str9 +
                " NombreEtapa: " + str10 +
                " NombreArea: " + str11 +
                " IdMateriaSeriada: " + str12 +
                " EstadoMateriaSeriada: " + str13 +
                " ');</script>");
            string R = NPEM.InsertaPlanEstudioMateria(ControlesWebForm_ObjetoEntidad2());
            lblTituloAccionPlanEstudioMateria.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(false);

            BtnGrabarPlanEstudioMateria.Visible = false;
            BtnCancelarPlanEstudioMateria.Visible = false;
            BtnAceptarPlanEstudioMateria.Visible = true;

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                InicializaControles();
            }
        }
        protected void BtnBorrarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            string R = NPEM.BorraPlanEstudioMateria(Convert.ToInt32(hfIdPlanEstudio.Value));

            lblTituloAccionPlanEstudioMateria.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(false);

            BtnBorrarModalPlanEstudioMateria.Visible = false;
            BtnCancelarPlanEstudioMateria.Visible = false;
            BtnAceptarPlanEstudioMateria.Visible = true;

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                InicializaControles();
            }
        }
        protected void BtnModificarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            E_PlanEstudioMateria Cliente = ControlesWebForm_ObjetoEntidad2();
            Cliente.IdPlanEstudioMateria = Convert.ToInt32(hfIdPlanEstudio.Value);
            string R = NPEM.ModificaPlanEstudioMateria(Cliente);
            lblTituloAccionPlanEstudioMateria.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(false);

            BtnModificarPlanEstudioMateria.Visible = false;
            BtnCancelarPlanEstudioMateria.Visible = false;
            BtnAceptarPlanEstudioMateria.Visible = true;

            if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
            {
                InicializaControlesPlanEstudioMateria();
            }
        }
        protected void BtnMnuEditarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            lblTituloAccionPlanEstudioMateria.Text = "Modificar materia de plan de estudio";

            BtnModificarPlanEstudioMateria.Visible = true;
            BtnCancelarPlanEstudioMateria.Visible = true;
            BtnMnuBorrarPlanEstudioMateria.Visible = false;
            BtnMnuEditarPlanEstudioMateria.Visible = false;

            ControlesOnOFFPlanEstudioMateria(true);
            ddlIdPlanEstudio.Enabled = false;
            ddlMateriaSeriada.Enabled = true;
        }
        protected void BtnMnuBorrarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            lblTituloAccionPlanEstudioMateria.Text = "Borrar materia de plan de estudio";
            BtnBorrarPlanEstudioMateria.Visible = true;
            BtnBorrarModalPlanEstudioMateria.Visible = true;
            BtnCancelarPlanEstudioMateria.Visible = true;
            BtnMnuBorrarPlanEstudioMateria.Visible = false;
            BtnMnuEditarPlanEstudioMateria.Visible = false;

            ControlesOnOFFPlanEstudioMateria(false);
        }
        protected void BtnCancelarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            InicializaControles();
        }
        #endregion

        #region Métodos del GridView
        protected void GrvPlanEstudio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            ControlesOFF();

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudio();

            e.Cancel = true; //Deshabilitar las ediciones del registro

            hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Plan de estudio";
            DroplistMateriaSeriada();
            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));
            ControlesOnOFF(false);

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            TbTotalCreditos.Enabled = false;
            lbEstatus.Visible = false;
            ddlEstatus.Visible = false;

            PnlCapturaDatos.Visible = true;
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvPlanEstudio_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            InicializaControles();

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudio();

            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Plan de estudio";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));
            ControlesOnOFF(true);

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            TbClavePlanEstudio.Enabled = false;

            lbEstatus.Visible = false;
            ddlEstatus.Visible = false;

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;

        }
        protected void GrvPlanEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            InicializaControlesPlanEstudioMateria();

            lblTituloAccionPlanEstudioMateria.Text = "Agregar Materia";

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudioMateria();
            TbClavePlanEstudio.Visible = false;
            ControlesOnOFFPlanEstudioMateria(true);

            PnlCapturaDatosPlanEstudioMateria.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(true);

            GridViewRow row = GrvPlanEstudio.SelectedRow;
            string valor = Convert.ToString(GrvPlanEstudio.Rows[row.RowIndex].Cells[1].Text);

            string valor2 = Convert.ToString(GrvPlanEstudio.Rows[row.RowIndex].Cells[0].Text);
            TbClavePlanEstudio.Text = valor.Trim();

            int index = 0;
            while (ddlIdPlanEstudio.SelectedItem.Text != valor2)
            {
                index = index + 1;
                ddlIdPlanEstudio.SelectedIndex = index;
            }
            ddlIdPlanEstudio.SelectedIndex = index;
            ddlIdPlanEstudio.Enabled = false;
            lbIdEtapa.Text = "Seleccione tipo materia primero para ver Etapas";
            lbSemestre.Text = "Seleccione Etapa para ver Semestres";
            cbSeriada.Enabled = false;
            //lbMateriaSeriada.Enabled = false;
            ddlMateriaSeriada.Enabled = false;
            //lbMateriaSeriada.Visible = false;
            //ddlMateriaSeriada.Visible = false;

            BtnGrabarPlanEstudioMateria.Visible = true;
            BtnCancelarPlanEstudioMateria.Visible = true;

        }
        protected void GrvPlanEstudio_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            if (e.CommandName == "MapaCurricular")
            {
                //Esto es para saber a que plan de estudio nos referimos
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];
                string str = row.Cells[0].Text;

                //Esto son los encabezados 
                lbPnlGrvMapaCurricularNombreCarrera.Visible = true;
                lbPnlGrvMapaCurricularNombreCarrera.Text = "Nombre De La Carrera";

                lbPnlGrvMapaCurricularPlanEstudio.Visible = true;
                lbPnlGrvMapaCurricularPlanEstudio.Text = "Plan De Estudio";

                //Aqui se crean las columnas
                GrvPlanEstudio.HeaderRow.Cells[0].Text = "I";
                GrvPlanEstudio.HeaderRow.Cells[1].Text = "II";
                GrvPlanEstudio.HeaderRow.Cells[2].Text = "III";
                GrvPlanEstudio.HeaderRow.Cells[3].Text = "IV";
                GrvPlanEstudio.HeaderRow.Cells[4].Text = "V";
                GrvPlanEstudio.HeaderRow.Cells[5].Text = "VI";
                GrvPlanEstudio.HeaderRow.Cells[6].Text = "VII";
                GrvPlanEstudio.HeaderRow.Cells[7].Text = "VIII";
                GrvPlanEstudio.HeaderRow.Cells[8].Visible = false;
                GrvPlanEstudio.HeaderRow.Cells[9].Visible = false;

                for (int i = 0; i <= 7; i++)
                {
                    row.Cells[i].Text = "semestre " + (i + 1);
                }
                row.Cells[8].Visible = false;
                row.Cells[9].Visible = false;

                GrvMapaCurricular.DataBind();
                PnlGrvMapaCurricular.Visible = true;

                List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(str);
                int contador = 1;
                foreach (var item in LstPlanEstudioMateria)
                {
                    if (item != null)
                    {
                        Response.Write("<script language=javascript>alert(' " +
                            "Materias agregadas a plan de estudio: " + contador +
                            "IdPlanEstudioMateria: " + item.IdPlanEstudioMateria +
                            "IdPlanEstudio: " + item.IdPlanEstudio +
                            "IdMateria: " + item.IdMateria +
                            "IdTipoMateria: " + item.IdTipoMateria +
                            "IdEtapa: " + item.IdEtapa +
                            "IdAreaConocimiento: " + item.IdAreaConocimiento +
                            "Semestre: " + item.Semestre +
                            "NombrePlanEstudio: " + item.NombrePlanEstudio +
                            "NombreMateria: " + item.NombreMateria +
                            "NombreTipoMateria: " + item.NombreTipoMateria +
                            "NombreEtapa: " + item.NombreEtapa +
                            "NombreArea: " + item.NombreArea +
                            "IdMateriaSeriada: " + item.IdMateriaSeriada +
                            "EstadoMateriaSeriada: " + item.EstadoMateriaSeriada +
                            "ClavePlanEstudio: " + item.ClavePlanEstudio +
                            "');</script>");
                        contador = contador + 1;
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('List element has null value.');</script>");
                    }
                }

                //if (LstPlanEstudioMateria.Count.Equals(0))
                //{
                //    InicializaControles();
                //    lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
                //}
                //else
                //{
                //    InicializaControles();
                //    GrvPlanEstudioMateria.DataSource = LstPlanEstudioMateria;
                //    GrvPlanEstudioMateria.DataBind();
                //    PnlGrvPlanEstudioMateria.Visible = true;
                //}

            }
            if (e.CommandName == "VerDetalles")
            {
                ControlesOFF();

                //Aqui se cargan los datos de las listas de plan estudio materia
                CargarDatosListasPlanEstudio();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];

                hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[row.RowIndex].Value.ToString();
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));

                lblTituloAccion.Text = "Mas detalles de plan de estudio";

                ControlesOnOFF(false);

                //Aqui se hacen no visible los Label, TextBox y el CheckBox
                VisibleOnOFF(true);

                TbTotalCreditos.Enabled = false;

                lbEstatus.Visible = true;
                ddlEstatus.Visible = true;

                PnlCapturaDatos.Visible = true;
                BtnAceptar.Visible = true;

            }
            if (e.CommandName == "ListarMaterias")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];
                string str = row.Cells[0].Text;
                //Response.Write("<script language=javascript>alert(' Gridview seleccionado " + str + "');</script>");
                //hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[row.RowIndex].Value.ToString();

                List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(str);

                if (LstPlanEstudioMateria.Count.Equals(0))
                {
                    InicializaControles();
                    lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
                }
                else
                {
                    InicializaControles();
                    GrvPlanEstudioMateria.DataSource = LstPlanEstudioMateria;
                    GrvPlanEstudioMateria.DataBind();
                    PnlGrvPlanEstudioMateria.Visible = true;
                }
            }
        }
        #endregion

        #region Métodos del GridView Plan Estudio - Materia
        protected void GrvPlanEstudioMateria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            ControlesOFF();

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudioMateria();

            e.Cancel = true; //Deshabilitar las ediciones del registro

            hfIdPlanEstudio.Value = GrvPlanEstudioMateria.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Materia de plan de estudio";

            ObjetoEntidad_ControlesWebForm2(Convert.ToInt16(hfIdPlanEstudio.Value));

            ControlesOnOFFPlanEstudioMateria(false);

            VisibleOnOFFPlanEstudioMateria(true);

            PnlCapturaDatosPlanEstudioMateria.Visible = true;

            lbMateriaSeriada.Enabled = false;
            ddlMateriaSeriada.Enabled = false;

            BtnBorrarPlanEstudioMateria.Visible = true;
            BtnBorrarModalPlanEstudioMateria.Visible = true;
            BtnCancelarPlanEstudioMateria.Visible = true;
        }
        protected void GrvPlanEstudioMateria_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }
            InicializaControlesPlanEstudioMateria();

            //Aqui se cargan los datos de las listas de plan estudio materia
            CargarDatosListasPlanEstudioMateria();

            e.Cancel = true; //Deshabilitar las ediciones del registro

            hfIdPlanEstudio.Value = GrvPlanEstudioMateria.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccionPlanEstudioMateria.Text = "Modificar materia de plan de estudio";

            ObjetoEntidad_ControlesWebForm2(Convert.ToInt16(hfIdPlanEstudio.Value));

            ControlesOnOFFPlanEstudioMateria(true);

            PnlCapturaDatosPlanEstudioMateria.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(true);
            //se creo un indice para recorrer el dropdownlist y comparar el texto

            ddlIdPlanEstudio.Enabled = false;
            ddlIdMateria.Enabled = false;

            if (cbSeriada.Checked)
            {
                lbMateriaSeriada.Enabled = true;
                ddlMateriaSeriada.Enabled = true;
            }
            else
            {
                lbMateriaSeriada.Enabled = false;
                ddlMateriaSeriada.Enabled = false;
            }

            

            BtnModificarPlanEstudioMateria.Visible = true;
            BtnCancelarPlanEstudioMateria.Visible = true;
        }
        protected void GrvPlanEstudioMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

        }
        protected void GrvPlanEstudioMateria_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

        }
        #endregion

        #region Cargar DropDownList
        //Plan Estudio
        private void DroplistProgramaEducativo()
        {
            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdCarrera, NombreCarrera FROM Propuesta.dbo.Carreras", con);
                    adapter.Fill(subjects);
                    ddlProgramaEducativo.DataSource = subjects;
                    ddlProgramaEducativo.DataTextField = "NombreCarrera";
                    ddlProgramaEducativo.DataValueField = "IdCarrera";
                    ddlProgramaEducativo.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlProgramaEducativo.Items.Insert(0, new ListItem("<Seleccione Carrera>", ""));
        }
        private void DroplistEstatus()
        {
            //carga datos para estatus

            ListItem i;

            i = new ListItem("<Seleccione>", "");
            ddlEstatus.Items.Add(i);
            i = new ListItem("APROBADO", "1");
            ddlEstatus.Items.Add(i);
            i = new ListItem("REVISION", "2");
            ddlEstatus.Items.Add(i);
            i = new ListItem("RECAPTURA", "3");
            ddlEstatus.Items.Add(i);
            i = new ListItem("EN ESPERA", "4");
            ddlEstatus.Items.Add(i);
            i = new ListItem("PUBLICADO", "5");
            ddlEstatus.Items.Add(i);
        }
        private void DroplistGradoAcademico()
        {
            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdNivelAcademico, NombreNivelAcademico FROM Propuesta.dbo.NivelAcademico", con);
                    adapter.Fill(subjects);
                    ddlIdNivelAcademico.DataSource = subjects;
                    ddlIdNivelAcademico.DataTextField = "NombreNivelAcademico";
                    ddlIdNivelAcademico.DataValueField = "IdNivelAcademico";
                    ddlIdNivelAcademico.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlIdNivelAcademico.Items.Insert(0, new ListItem("<Seleccione Nivel>", ""));
        }
        private void DroplistUnidadAcademica()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdUnidadAcademica, UnidadAcademica FROM Propuesta.dbo.UnidadAcademica", con);
                    adapter.Fill(subjects);
                    ddlUnidadAcademica.DataSource = subjects;
                    ddlUnidadAcademica.DataTextField = "UnidadAcademica";
                    ddlUnidadAcademica.DataValueField = "IdUnidadAcademica";
                    ddlUnidadAcademica.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlUnidadAcademica.Items.Insert(0, new ListItem("<Seleccione Uidad Academica>", ""));
        }
        //Plan Estudio - Materia
        private void DroplistPlanEstudio()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdPlanEstudio, ClavePlanEstudio FROM Propuesta.dbo.PlanEstudio", con);
                    adapter.Fill(subjects);
                    ddlIdPlanEstudio.DataSource = subjects;
                    ddlIdPlanEstudio.DataTextField = "ClavePlanEstudio";
                    ddlIdPlanEstudio.DataValueField = "IdPlanEstudio";
                    ddlIdPlanEstudio.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlIdPlanEstudio.Items.Insert(0, new ListItem("<Seleccione>", ""));
        }
        private void DroplistMateria()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdMateria, NombreMateria FROM Propuesta.dbo.Materias", con);
                    adapter.Fill(subjects);
                    ddlIdMateria.DataSource = subjects;
                    ddlIdMateria.DataTextField = "NombreMateria";
                    ddlIdMateria.DataValueField = "IdMateria";
                    ddlIdMateria.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlIdMateria.Items.Insert(0, new ListItem("<Seleccione Materia>", ""));
        }
        private void DroplistMateriaSeriada()
        {
            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdMateria, NombreMateria FROM Propuesta.dbo.PlanEstudioMateria WHERE NombrePlanEstudio='"+ddlIdPlanEstudio.SelectedItem.Text+ "' AND Semestre > '" + ddlSemestre.SelectedItem.Value + "'", con);
                    adapter.Fill(subjects);
                    ddlMateriaSeriada.DataSource = subjects;
                    ddlMateriaSeriada.DataTextField = "NombreMateria";
                    ddlMateriaSeriada.DataValueField = "IdMateria";
                    ddlMateriaSeriada.DataBind();

                    string valor = ddlIdMateria.SelectedValue;
                    ListItem itemToRemove = ddlIdMateria.Items.FindByValue(valor);
                    if (itemToRemove != null)
                    {
                        ddlMateriaSeriada.Items.Remove(itemToRemove);
                    }
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlMateriaSeriada.Items.Insert(0, new ListItem("<Seleccione Materia Seriada>", ""));
        }
        private void DroplistTipoMateria()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdTipoMateria, NombreTipoMateria FROM Propuesta.dbo.TipoMateria", con);
                    adapter.Fill(subjects);
                    ddlIdTipoMateria.DataSource = subjects;
                    ddlIdTipoMateria.DataTextField = "NombreTipoMateria";
                    ddlIdTipoMateria.DataValueField = "IdTipoMateria";
                    ddlIdTipoMateria.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlIdTipoMateria.Items.Insert(0, new ListItem("<Selecione Tipo>", ""));
        }
        private void DroplistEtapa()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdEtapa, NombreEtapa FROM Propuesta.dbo.Etapas WHERE NombreEtapa = 'BASICA "+ddlIdTipoMateria.SelectedItem.Text+ "' OR NombreEtapa = 'DISCIPLINARIA " + ddlIdTipoMateria.SelectedItem.Text + "' OR NombreEtapa = 'TERMINAL " + ddlIdTipoMateria.SelectedItem.Text + "' ", con);
                    adapter.Fill(subjects);
                    ddlIdEtapa.DataSource = subjects;
                    ddlIdEtapa.DataTextField = "NombreEtapa";
                    ddlIdEtapa.DataValueField = "IdEtapa";
                    ddlIdEtapa.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlIdEtapa.Items.Insert(0, new ListItem("<Seleccione Etapa>", ""));
        }
        private void DroplistAreaConocimiento()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdAreaConocimiento, DescripcionAreaConocimiento FROM Propuesta.dbo.AreaConocimiento", con);
                    adapter.Fill(subjects);
                    ddlIdAreaConocimiento.DataSource = subjects;
                    ddlIdAreaConocimiento.DataTextField = "DescripcionAreaConocimiento";
                    ddlIdAreaConocimiento.DataValueField = "IdAreaConocimiento";
                    ddlIdAreaConocimiento.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlIdAreaConocimiento.Items.Insert(0, new ListItem("<Seleccione Area de Conocimiento>", ""));
        }
        private void DroplistSemestre()
        {
            ddlSemestre.Items.Clear();
            //carga datos para estatus
            ListItem i;
            i = new ListItem("<Seleccione>", "");
            if (ddlIdEtapa.SelectedItem.Text == "BASICA OBLIGATORIA"||
               ddlIdEtapa.SelectedItem.Text == "BASICA OPTATIVA")
            {
               
                ddlSemestre.Items.Add(i);
                i = new ListItem("1.º", "1");
                ddlSemestre.Items.Add(i);
                i = new ListItem("2.º", "2");
                ddlSemestre.Items.Add(i);
                i = new ListItem("3.º", "3");
                ddlSemestre.Items.Add(i);
            }
            if (ddlIdEtapa.SelectedItem.Text== "DISCIPLINARIA OBLIGATORIA"||
               ddlIdEtapa.SelectedItem.Text == "DISCIPLINARIA OPTATIVA")
            {
        
                ddlSemestre.Items.Add(i);
                i = new ListItem("4.º", "4");
                ddlSemestre.Items.Add(i);
                i = new ListItem("5.º", "5");
                ddlSemestre.Items.Add(i);
                i = new ListItem("6.º", "6");
                ddlSemestre.Items.Add(i);
            }
            if (ddlIdEtapa.SelectedItem.Text == "TERMINAL OBLIGATORIA"||
                ddlIdEtapa.SelectedItem.Text == "TERMINAL OPTATIVA")
            {
               
                ddlSemestre.Items.Add(i);
                i = new ListItem("7.º", "7");
                ddlSemestre.Items.Add(i);
                i = new ListItem("8.º", "8");
                ddlSemestre.Items.Add(i);
            }
        }
        //se ejecutara cuando un elemento en el dropdownlist de materias cambie
        //eliminando la materia seleccionada de las que se pueden seriar
        protected void ItemSelected(Object sender, EventArgs e)//para el ddlIdMateria
        {
            if (ddlIdMateria.SelectedIndex == 0)
            {
                cbSeriada.Enabled = false;
                cbSeriada.Checked = false;
                ddlMateriaSeriada.Enabled = false;
                DroplistMateriaSeriada();
            }
            else
            {
                cbSeriada.Enabled = true;
            }
            DroplistMateriaSeriada();
        }
        protected void On_Check(Object sender, EventArgs e)
        {
            if (cbSeriada.Checked && ddlSemestre.SelectedIndex > 0)
            {
                ddlMateriaSeriada.Enabled = true;
                DroplistMateriaSeriada();
                cbSeriada.Text=string.Empty;
            }
            else
            {
                ddlMateriaSeriada.Enabled = false;
                cbSeriada.Checked = false;
                DroplistMateriaSeriada();
                cbSeriada.Text = " Asegure que un semestre este seleccionado";
            }
        }
        protected void Index_Changed(object sender, EventArgs e)//cuando se seleccione etapa
        {
            lbSemestre.Text = "Semestre";
            DroplistSemestre();
        }
        protected void TipoChange(object sender, EventArgs e)
        {
            lbIdEtapa.Text = "Etapa";
            DroplistEtapa();
        }
        #endregion


    }
}