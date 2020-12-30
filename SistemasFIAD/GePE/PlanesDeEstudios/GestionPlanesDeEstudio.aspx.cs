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

        N_Materias NM = new N_Materias();
        N_PlanEstudio PE = new N_PlanEstudio();
        N_PlanEstudioMateria NPEM = new N_PlanEstudioMateria();
        public int entra = 1;

        int EBOB = 0;
        int EDOB = 0;
        int ETOB = 0;

        int EBOP = 0;
        int EDOP = 0;
        int ETOP = 0;

        int EBTOT = 0;
        int EDTOT = 0;
        int ETTOT = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InicializaControles();

            //if (Session["mensaje1"] != null)
            //{
            //    string mensaje = Convert.ToString(Session["mensaje1"]);
            //    Response.Write("<script language=javascript>alert('"+mensaje+"');</script>");
            //}
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

            if (cbSeriada.Checked && ddlMateriaSeriada.SelectedIndex != 0)
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
                    ClavePlanEstudio = TbClavePlanEstudio.Text,
                    NombreMateriaSeriada = ddlMateriaSeriada.SelectedItem.Text
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
                DroplistEtapa();
                ddlIdEtapa.SelectedValue = Convert.ToString(PlanEstudioMateria.IdEtapa);
                ddlIdAreaConocimiento.SelectedIndex = PlanEstudioMateria.IdAreaConocimiento;
                DroplistSemestre();
                ddlSemestre.SelectedValue = Convert.ToString(PlanEstudioMateria.Semestre);
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
                DroplistEtapa();
                ddlIdEtapa.SelectedValue = Convert.ToString(PlanEstudioMateria.IdEtapa);
                ddlIdAreaConocimiento.SelectedIndex = PlanEstudioMateria.IdAreaConocimiento;
                DroplistSemestre();
                ddlSemestre.SelectedValue = Convert.ToString(PlanEstudioMateria.Semestre);
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

            //string str1 = Convert.ToString(ddlIdPlanEstudio.SelectedItem.Value);
            //string str2 = Convert.ToString(ddlIdMateria.SelectedItem.Value);
            //string str3 = Convert.ToString(ddlIdTipoMateria.SelectedItem.Value);
            //string str4 = Convert.ToString(ddlIdEtapa.SelectedItem.Value);
            //string str5 = Convert.ToString(ddlIdAreaConocimiento.SelectedItem.Value);
            //string str6 = Convert.ToString(ddlSemestre.SelectedItem.Value);
            //string str7 = Convert.ToString(ddlIdPlanEstudio.SelectedItem.Text);
            //string str8 = Convert.ToString(ddlIdMateria.SelectedItem.Text);
            //string str9 = Convert.ToString(ddlIdTipoMateria.SelectedItem.Text);
            //string str10 = Convert.ToString(ddlIdEtapa.SelectedItem.Text);
            //string str11 = Convert.ToString(ddlIdAreaConocimiento.SelectedItem.Text);
            //string str12 = Convert.ToString(ddlMateriaSeriada.SelectedItem.Value);
            //string str13 = Convert.ToString(cbSeriada.Checked);
            //Response.Write("<script language=javascript>alert('" +
            //    "IdPlanEstudio: " + str1 +
            //    " IdMateria: " + str2 +
            //    " IdTipoMateria: " + str3 +
            //    " IdEtapa: " + str4 +
            //    " IdAreaConocimiento: " + str5 +
            //    " Semestre: " + str6 +
            //    " NombrePlanEstudio: " + str7 +
            //    " NombreMateria: " + str8 +
            //    " NombreTipoMateria: " + str9 +
            //    " NombreEtapa: " + str10 +
            //    " NombreArea: " + str11 +
            //    " IdMateriaSeriada: " + str12 +
            //    " EstadoMateriaSeriada: " + str13 +
            //    " ');</script>");
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

                List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(str);

                DataTable dt = new DataTable();

                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("I", typeof(string));
                    dt.Columns.Add("II", typeof(string));
                    dt.Columns.Add("III", typeof(string));
                    dt.Columns.Add("IV", typeof(string));
                    dt.Columns.Add("V", typeof(string));
                    dt.Columns.Add("VI", typeof(string));
                    dt.Columns.Add("VII", typeof(string));
                    dt.Columns.Add("VIII", typeof(string));
                }

                DataRow NewRow = dt.NewRow();

                NewRow[0] = "";
                NewRow[1] = "Etapa Basica";
                NewRow[2] = "";
                NewRow[3] = "";
                NewRow[4] = "Etapa Disiplinaria";
                NewRow[5] = "";
                NewRow[6] = "Etapa Terminal";
                NewRow[7] = "";

                dt.Rows.Add(NewRow);

                for (int i = 0; i <= 12; i++)
                {
                    RowGrv(dt);
                }

                GrvMapaCurricular.DataSource = dt;
                GrvMapaCurricular.DataBind();

                int MS1 = 1;
                int MS2 = 1;
                int MS3 = 1;
                int MS4 = 1;
                int MS5 = 1;
                int MS6 = 1;
                int MS7 = 1;
                int MS8 = 1;

                //Obligatorias
                EBOB = 0;
                EDOB = 0;
                ETOB = 0;

                //Optativas
                EBOP = 0;
                EDOP = 0;
                ETOP = 0;

                //Totales
                EBTOT = 0;
                EDTOT = 0;
                ETTOT = 0;

                index = 0;
                EncabezadoEtapaGrv(index, 0, "#641E16");
                EncabezadoEtapaGrv(index, 1, "#641E16");
                EncabezadoEtapaGrv(index, 2, "#641E16");

                EncabezadoEtapaGrv(index, 3, "#7D6608");
                EncabezadoEtapaGrv(index, 4, "#7D6608");
                EncabezadoEtapaGrv(index, 5, "#7D6608");

                EncabezadoEtapaGrv(index, 6, "#4A235A");
                EncabezadoEtapaGrv(index, 7, "#4A235A");

                index = index + 1;

                foreach (var item in LstPlanEstudioMateria)
                {
                    if (item != null)
                    {
                        GrvMapaCurricular.Rows[index].Cells[0].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[1].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[2].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[3].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[4].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[5].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[6].Text = "";
                        GrvMapaCurricular.Rows[index].Cells[7].Text = "";

                        //Response.Write("<script language=javascript>alert(' " +
                        //    " - IdPlanEstudioMateria: " + item.IdPlanEstudioMateria +
                        //    " - IdPlanEstudio: " + item.IdPlanEstudio +
                        //    " - IdMateria: " + item.IdMateria +
                        //    " - IdTipoMateria: " + item.IdTipoMateria +
                        //    " - IdEtapa: " + item.IdEtapa +
                        //    " - IdAreaConocimiento: " + item.IdAreaConocimiento +
                        //    " - Semestre: " + item.Semestre +
                        //    " - NombrePlanEstudio: " + item.NombrePlanEstudio +
                        //    " - NombreMateria: " + item.NombreMateria +
                        //    " - NombreTipoMateria: " + item.NombreTipoMateria +
                        //    " - NombreEtapa: " + item.NombreEtapa +
                        //    " - NombreArea: " + item.NombreArea +
                        //    " - IdMateriaSeriada: " + item.IdMateriaSeriada +
                        //    " - EstadoMateriaSeriada: " + item.EstadoMateriaSeriada +
                        //    " - ClavePlanEstudio: " + item.ClavePlanEstudio +
                        //    "');</script>");

                        if (item.Semestre == 1)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Response.Write("<script language=javascript>alert(' " +
                                    //    "IdMateria: " + itemM.IdMateria +
                                    //    "<br/>ClaveMateria: " + itemM.ClaveMateria +
                                    //    "<br/>NombreMateria: " + itemM.NombreMateria +
                                    //    "<br/>HC: " + itemM.HC +
                                    //    "<br/>HL: " + itemM.HL +
                                    //    "<br/>HT: " + itemM.HT +
                                    //    "<br/>HE: " + itemM.HE +
                                    //    "<br/>HPP: " + itemM.HPP +
                                    //    "<br/>CR: " + itemM.CR +
                                    //    "<br/>EstadoMateria: " + itemM.EstadoMateria +
                                    //    "<br/>PathPUA: " + itemM.PathPUA +
                                    //    "<br/>PathPUAnoOficial: " + itemM.PathPUAnoOficial +
                                    //    "');</script>");

                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS1, 0, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS1].Cells[0].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS1].Cells[0].Text = GrvMapaCurricular.Rows[MS1].Cells[0].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);
                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }

                            MS1 = MS1 + 1;
                        }
                        else if (item.Semestre == 2)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS2, 1, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS2].Cells[1].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS2].Cells[1].Text = GrvMapaCurricular.Rows[MS2].Cells[1].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);

                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS2 = MS2 + 1;
                        }
                        else if (item.Semestre == 3)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS3, 2, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS3].Cells[2].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS3].Cells[2].Text = GrvMapaCurricular.Rows[MS3].Cells[2].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);
                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS3 = MS3 + 1;
                        }
                        else if (item.Semestre == 4)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS4, 3, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS4].Cells[3].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS4].Cells[3].Text = GrvMapaCurricular.Rows[MS4].Cells[3].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);

                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS4 = MS4 + 1;
                        }
                        else if (item.Semestre == 5)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS5, 4, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS5].Cells[4].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS5].Cells[4].Text = GrvMapaCurricular.Rows[MS5].Cells[4].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);

                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS5 = MS5 + 1;
                        }
                        else if (item.Semestre == 6)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS6, 5, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS6].Cells[5].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS6].Cells[5].Text = GrvMapaCurricular.Rows[MS6].Cells[5].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);

                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS6 = MS6 + 1;
                        }
                        else if (item.Semestre == 7)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS7, 6, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS7].Cells[6].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS7].Cells[6].Text = GrvMapaCurricular.Rows[MS7].Cells[6].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);

                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS7 = MS7 + 1;
                        }
                        else if (item.Semestre == 8)
                        {
                            List<E_Materias> LstMaterias = NM.BuscaMateria(item.NombreMateria);
                            foreach (var itemM in LstMaterias)
                            {
                                if (itemM != null)
                                {
                                    //Aqui se crea el hipervinculo de la PUA
                                    string cadena = itemM.PathPUA;
                                    //cadena = cadena.Replace("~/", "");
                                    cadena = cadena.Replace("../", "");
                                    //Aqui se cargan los style
                                    EstilosGrv(MS8, 7, item.NombreArea);

                                    //Aqui se cargan los datos al Grv
                                    GrvMapaCurricular.Rows[MS8].Cells[7].Text =
                                        "<a href = http://vivi.ens.uabc.mx/GePE/" + cadena + " target=\"_blank\" > " + item.NombreMateria + "</a><br/>" +
                                        "<b>HC: </b><i>" + itemM.HC + "</i>" +
                                        " <b>HL: </b><i>" + itemM.HL + "</i>" +
                                        " <b>HT: </b><i>" + itemM.HT + "</i>" +
                                        " <b>HPC: </b><i>" + itemM.HPP + "</i>" +
                                        " <b>CR: </b><i>" + itemM.CR + "</i>";

                                    if (item.EstadoMateriaSeriada == true)
                                    {
                                        GrvMapaCurricular.Rows[MS8].Cells[7].Text = GrvMapaCurricular.Rows[MS8].Cells[7].Text +
                                            "<br/>*Seriada con " + item.NombreMateriaSeriada;
                                    }
                                    else { }

                                    //Aqui se calculan los creditos
                                    CreditosGrv(item.NombreEtapa, itemM.CR);

                                }
                                else
                                {
                                    //Response.Write("<script language=javascript>alert('El elemento de la lista de materias tiene valor nulo.');</script>");
                                }
                            }
                            MS8 = MS8 + 1;
                        }
                        else
                        {
                        }

                        index = index + 1;

                        //Esto son los encabezados 
                        lbPnlGrvMapaCurricularNombreCarrera.Visible = true;
                        lbPnlGrvMapaCurricularPlanEstudio.Visible = true;

                        //Etapa Basica
                        lbEBOB.Visible = true;
                        lbEBOP.Visible = true;
                        lbEBTOT.Visible = true;

                        //Etapa Disiplinaria
                        lbEDOB.Visible = true;
                        lbEDOP.Visible = true;
                        lbEDTOT.Visible = true;

                        //Etepa Terminal
                        lbETOB.Visible = true;
                        lbETOP.Visible = true;
                        lbETTOT.Visible = true;

                        //SubTotal Creditos
                        lbOBTOT.Visible = true;
                        lbOPTOT.Visible = true;
                        lbTOT.Visible = true;

                        //Total Creditos
                        lbTotalOB.Visible = true;
                        lbTotalOP.Visible = true;
                        lbTotalTOT.Visible = true;

                        List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudio(item.ClavePlanEstudio);

                        foreach (var itemP in LstPlanEstudio)
                        {
                            if (itemP != null)
                            {

                                //Response.Write("<script language=javascript>alert(' " +
                                //    " - IdPlanEstudio: " + itemP.IdPlanEstudio +
                                //    " - IdNivelAcademico: " + itemP.IdNivelAcademico +
                                //    " - IdCarrera: " + itemP.IdCarrera +
                                //    " - ClavePlanEstudio: " + itemP.ClavePlanEstudio +
                                //    " - PlanEstudio: " + itemP.PlanEstudio +
                                //    " - ProgramaEducativo: " + itemP.ProgramaEducativo +
                                //    " - FechaCreacion: " + itemP.FechaCreacion +
                                //    " - TotalCreditos: " + itemP.TotalCreditos +
                                //    " - EstadoPlanEstudios: " + itemP.EstadoPlanEstudios +
                                //    " - Comentarios: " + itemP.Comentarios +
                                //    " - PerfilDeIngreso: " + itemP.PerfilDeIngreso +
                                //    " - PerfilDeEgreso: " + itemP.PerfilDeEgreso +
                                //    " - CampoOcupacional: " + itemP.CampoOcupacional +
                                //    " - UnidadAcademica: " + itemP.UnidadAcademica +
                                //    " - Estatus: " + itemP.Estatus +
                                //    " - IdEstatus: " + itemP.IdEstatus +
                                //    " - NombreCarrera: " + itemP.NombreCarrera +
                                //    "');</script>");

                                if (itemP.ClavePlanEstudio == str)
                                {
                                    lbPnlGrvMapaCurricularNombreCarrera.Text = "Nombre de la carrera (\"" + itemP.NombreCarrera + "\")";
                                    lbPnlGrvMapaCurricularPlanEstudio.Text = "Plan de estudio (\"" + itemP.PlanEstudio + "\")";

                                    EBTOT = EBOB + EBOP;
                                    EDTOT = EDOB + EDOP;
                                    ETTOT = ETOB + ETOP;

                                    int TotalOB = 0;
                                    int TotalOP = 0;
                                    int Total = 0;

                                    TotalOB = EBOB + EDOB + ETOB;
                                    TotalOP = EBOP + EDOP + ETOP;
                                    Total = EBTOT + EDTOT + ETTOT;

                                    //Etapa Basica
                                    lbEBOB.Text = Convert.ToString(EBOB);
                                    lbEBOP.Text = Convert.ToString(EBOP);
                                    lbEBTOT.Text = Convert.ToString(EBTOT);

                                    //Etapa Disiplinaria
                                    lbEDOB.Text = Convert.ToString(EDOB);
                                    lbEDOP.Text = Convert.ToString(EDOP);
                                    lbEDTOT.Text = Convert.ToString(EDTOT);

                                    //Etepa Terminal
                                    lbETOB.Text = Convert.ToString(ETOB);
                                    lbETOP.Text = Convert.ToString(ETOP);
                                    lbETTOT.Text = Convert.ToString(ETTOT);

                                    //SubTotal Creditos
                                    lbOBTOT.Text = Convert.ToString(TotalOB);
                                    lbOPTOT.Text = Convert.ToString(TotalOP);
                                    lbTOT.Text = Convert.ToString(Total);

                                    //Total Creditos
                                    lbTotalOB.Text = Convert.ToString(TotalOB + 10);
                                    lbTotalOP.Text = Convert.ToString(TotalOP);
                                    lbTotalTOT.Text = Convert.ToString(Total + 10);

                                }
                            }
                            else
                            {
                                //Response.Write("<script language=javascript>alert('El elemento de la lista PlanEstudio tiene valor nulo.');</script>");
                            }
                        }

                    }
                    else
                    {
                        //Response.Write("<script language=javascript>alert('El elemento de la lista PlanEstudioMateria tiene valor nulo.');</script>");
                    }

                }

                PnlGrvPlanEstudio.Visible = false;
                PnlGrvMapaCurricular.Visible = true;

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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdMateria, NombreMateria FROM Propuesta.dbo.PlanEstudioMateria WHERE NombrePlanEstudio='" + ddlIdPlanEstudio.SelectedItem.Text + "' AND Semestre > '" + ddlSemestre.SelectedItem.Value + "'", con);
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdEtapa, NombreEtapa FROM Propuesta.dbo.Etapas WHERE NombreEtapa = 'BASICA " + ddlIdTipoMateria.SelectedItem.Text + "' OR NombreEtapa = 'DISCIPLINARIA " + ddlIdTipoMateria.SelectedItem.Text + "' OR NombreEtapa = 'TERMINAL " + ddlIdTipoMateria.SelectedItem.Text + "' ", con);
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
            if (ddlIdEtapa.SelectedItem.Value == "1" ||
               ddlIdEtapa.SelectedItem.Value == "2")
            {

                ddlSemestre.Items.Add(i);
                i = new ListItem("1.º", "1");
                ddlSemestre.Items.Add(i);
                i = new ListItem("2.º", "2");
                ddlSemestre.Items.Add(i);
                i = new ListItem("3.º", "3");
                ddlSemestre.Items.Add(i);
            }
            if (ddlIdEtapa.SelectedItem.Value == "3" ||
               ddlIdEtapa.SelectedItem.Value == "4")
            {

                ddlSemestre.Items.Add(i);
                i = new ListItem("4.º", "4");
                ddlSemestre.Items.Add(i);
                i = new ListItem("5.º", "5");
                ddlSemestre.Items.Add(i);
                i = new ListItem("6.º", "6");
                ddlSemestre.Items.Add(i);
            }
            if (ddlIdEtapa.SelectedItem.Value == "5" ||
                ddlIdEtapa.SelectedItem.Value == "6")
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
                cbSeriada.Text = string.Empty;
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
        //Esto es para el Grv de mapa curricular
        protected void EstilosGrv(int MS, int Cell, string NombreArea)
        {
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["text-align"] = "center";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["font-size"] = "12px";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["color"] = "#000000";

            if (NombreArea == "CIENCIAS BÁSICAS                                  ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#D98880";
            }
            else if (NombreArea == "CIENCIAS SOCIALES Y HUMANIDADES                   ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#C39BD3";
            }
            else if (NombreArea == "CIENCIAS DE LA INGENIERÍA                         ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#7FB3D5";
            }
            else if (NombreArea == "INGENIERÍA APLICADA                               ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#7DCEA0";
            }
            else if (NombreArea == "CIENCIAS ECONÓMICAS - ADMINISTRATIVAS             ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#F7DC6F";
            }
            else if (NombreArea == "DISEÑO EN INGENIERÍA                              ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#F0B27A";
            }
            else if (NombreArea == "CURSOS COMPLEMENTARIOS                            ")
            {
                GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = "#B2BABB";
            }
            else { }

        }
        protected void EncabezadoEtapaGrv(int MS, int Cell, string color)
        {
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["text-align"] = "center";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["font-size"] = "12px";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["color"] = "#FFFFFF";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["font-weight"] = "bold";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["vertical-align"] = "middle";
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["background-color"] = color;
            GrvMapaCurricular.Rows[MS].Cells[Cell].Attributes.CssStyle["border-style"] = "none";
        }
        protected void CreditosGrv(string NombreEtapa, int CR)
        {
            if (NombreEtapa == "BASICA OBLIGATORIA")
            {
                EBOB = EBOB + CR;
            }
            else if (NombreEtapa == "BASICA OPTATIVA")
            {
                EBOP = EBOP + CR;
            }
            else if (NombreEtapa == "DISCIPLINARIA OBLIGATORIA")
            {
                EDOB = EDOB + CR;
            }
            else if (NombreEtapa == "DISCIPLINARIA OPTATIVA")
            {
                EDOP = EDOP + CR;
            }
            else if (NombreEtapa == "TERMINAL OBLIGATORIA")
            {
                ETOB = ETOB + CR;
            }
            else if (NombreEtapa == "TERMINAL OPTATIVA")
            {
                ETOP = ETOP + CR;
            }
            else { }
        }
        protected void RowGrv(DataTable dt)
        {
            DataRow NewRow = dt.NewRow();

            NewRow[0] = "";
            NewRow[1] = "";
            NewRow[2] = "";
            NewRow[3] = "";
            NewRow[4] = "";
            NewRow[5] = "";
            NewRow[6] = "";
            NewRow[7] = "";

            dt.Rows.Add(NewRow);
        }
        #endregion


    }
}