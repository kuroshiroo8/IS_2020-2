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
            lbEstatus.Visible = false;

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
        }
        protected void ControlesClear()
        {
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
            lbEstatus.Enabled = TrueOrFalse;

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
            lbEstatus.Visible = TrueOrFalse;

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
        #endregion

        #region Métodos generales Plan Estudio - Materia
        protected void InicializaControlesPlanEstudioMateria()
        {
            ControlesOFFPlanEstudioMateria();
            ControlesClearPlanEstudioMateria();
            ControlesOnOFFPlanEstudioMateria(true);
        }
        protected void ControlesOFFPlanEstudioMateria()
        {
            //Visible Label
            lbIdPlanEstudio.Visible = false;
            lbIdMateria.Visible = false;
            lbIdTipoMateria.Visible = false;
            lbIdEtapa.Visible = false;
            lbIdAreaConocimiento.Visible = false;
            lbSemestre.Visible = false;

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
        protected void ControlesClearPlanEstudioMateria()
        {
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

            //Clear DropDownList
            ddlIdPlanEstudio.Enabled = TrueOrFalse;
            ddlIdMateria.Enabled = TrueOrFalse;
            ddlIdTipoMateria.Enabled = TrueOrFalse;
            ddlIdEtapa.Enabled = TrueOrFalse;
            ddlIdAreaConocimiento.Enabled = TrueOrFalse;
            ddlSemestre.Enabled = TrueOrFalse;
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

            //Visible DropDownList
            ddlIdPlanEstudio.Visible = TrueOrFalse;
            ddlIdMateria.Visible = TrueOrFalse;
            ddlIdTipoMateria.Visible = TrueOrFalse;
            ddlIdEtapa.Visible = TrueOrFalse;
            ddlIdAreaConocimiento.Visible = TrueOrFalse;
            ddlSemestre.Visible = TrueOrFalse;
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
                ProgramaEducativo = ddlProgramaEducativo.SelectedItem.Text,
                FechaCreacion = TbFechaCreacion.Text,
                TotalCreditos = Convert.ToInt32(TbTotalCreditos.Text),
                EstadoPlanEstudios = cbEstadoPlanEstudios.Checked,
                Comentarios = TbComentarios.Text,
                PerfilDeIngreso = TbPerfilDeIngreso.Text,
                PerfilDeEgreso = TbPerfilDeEgreso.Text,
                CampoOcupacional = TbCampoOcupacional.Text,
                UnidadAcademica = ddlUnidadAcademica.SelectedItem.Text,
                Estatus = ddlEstatus.SelectedItem.Text
            };
            return PlanEstudio;

        }
        protected void ObjetoEntidad_ControlesWebForm(int IdPlanEstudio)
        {
            E_PlanEstudio planEstudio = PE.BuscaPlanEstudioPorId(IdPlanEstudio);

            ddlIdNivelAcademico.SelectedIndex = planEstudio.IdNivelAcademico;
            TbClavePlanEstudio.Text = planEstudio.ClavePlanEstudio.Trim();
            TbPlanEstudio.Text = planEstudio.PlanEstudio.Trim();
            ddlProgramaEducativo.SelectedItem.Text = planEstudio.ProgramaEducativo;
            TbFechaCreacion.Text = planEstudio.FechaCreacion.Trim();
            TbTotalCreditos.Text = Convert.ToString(planEstudio.TotalCreditos);
            cbEstadoPlanEstudios.Checked = planEstudio.EstadoPlanEstudios;
            TbComentarios.Text = planEstudio.Comentarios.Trim();
            TbPerfilDeIngreso.Text = planEstudio.PerfilDeIngreso.Trim();
            TbPerfilDeEgreso.Text = planEstudio.PerfilDeEgreso.Trim();
            TbCampoOcupacional.Text = planEstudio.CampoOcupacional.Trim();
            ddlUnidadAcademica.SelectedItem.Text = planEstudio.UnidadAcademica;
            ddlEstatus.SelectedItem.Text = planEstudio.Estatus;
        }
        #endregion

        #region Objeto Cliente Plan Estudio - Materia
        protected E_PlanEstudioMateria ControlesWebForm_ObjetoEntidad2()
        {
            E_PlanEstudioMateria PlanEstudioMateria = new E_PlanEstudioMateria()
            {
                IdPlanEstudioMateria = ddlIdPlanEstudio.SelectedIndex,
                IdMateria = ddlIdMateria.SelectedIndex,
                IdTipoMateria = ddlIdTipoMateria.SelectedIndex,
                IdEtapa = ddlIdEtapa.SelectedIndex,
                IdAreaConocimiento = ddlIdAreaConocimiento.SelectedIndex,
                Semestre = Convert.ToInt32(ddlSemestre.SelectedItem.Text)
            };
            return PlanEstudioMateria;

        }
        protected void ObjetoEntidad_ControlesWebForm2(int IdPlanEstudioMateria)
        {
            E_PlanEstudioMateria PlanEstudioMateria = NPEM.BuscaPlanEstudioMateriaPorId(IdPlanEstudioMateria);

            ddlIdPlanEstudio.SelectedIndex = PlanEstudioMateria.IdPlanEstudioMateria;
            ddlIdMateria.SelectedIndex = PlanEstudioMateria.IdMateria;
            ddlIdTipoMateria.SelectedIndex = PlanEstudioMateria.IdTipoMateria;
            ddlIdEtapa.SelectedIndex = PlanEstudioMateria.IdEtapa;
            ddlIdAreaConocimiento.SelectedIndex = PlanEstudioMateria.IdAreaConocimiento;
            ddlSemestre.SelectedItem.Text = Convert.ToString(PlanEstudioMateria.Semestre);
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

            ddlProgramaEducativo.Items.Clear();
            DroplistProgramaEducativo();

            ddlEstatus.Items.Clear();
            DroplistEstatus();

            ddlIdNivelAcademico.Items.Clear();
            DroplistGradoAcademico();

            ddlUnidadAcademica.Items.Clear();
            DroplistUnidadAcademica();

        }
        protected void BtnMnuListado_Click(object sender, EventArgs e)
        {
            InicializaControles();
            N_PlanEstudio PE = new N_PlanEstudio();
            GrvPlanEstudio.DataSource = PE.LstPlanEstudio();
            GrvPlanEstudio.DataBind();
            PnlGrvPlanEstudio.Visible = true;
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

                    ddlProgramaEducativo.Items.Clear();
                    DroplistProgramaEducativo();

                    ddlEstatus.Items.Clear();
                    DroplistEstatus();

                    ddlIdNivelAcademico.Items.Clear();
                    DroplistGradoAcademico();

                    ddlUnidadAcademica.Items.Clear();
                    DroplistUnidadAcademica();

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
        }
        protected void BtnMnuListadoPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            InicializaControlesPlanEstudioMateria();
            N_PlanEstudioMateria NPEM = new N_PlanEstudioMateria();
            GrvPlanEstudioMateria.DataSource = NPEM.LstPlanEstudioMateria();
            GrvPlanEstudioMateria.DataBind();
            PnlGrvPlanEstudioMateria.Visible = true;
        }
        //protected void BtnBuscarPlanEstudioMateria_Click(object sender, EventArgs e)
        //{
        //    if (TbCriterioBusqueda.Text.Trim() != string.Empty)
        //    {
        //        List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMateriaPorId(TbCriterioBusqueda.Text.Trim());
        //        if (LstPlanEstudioMateria.Count.Equals(0))
        //        {
        //            InicializaControlesPlanEstudioMateria();
        //            lblNombreAccion.Text = "No se encontraron datos con el criterio de busqueda";
        //        }
        //        else if (LstPlanEstudioMateria.Count.Equals(1))
        //        {
        //            InicializaControlesPlanEstudioMateria();
        //            lblTituloAccionPlanEstudioMateria.Text = "Resultado de busqueda";

        //            VisibleOnOFFPlanEstudioMateria(true);

        //            ddlIdPlanEstudio.Items.Clear();
        //            DroplistPlanEstudio();

        //            ddlIdMateria.Items.Clear();
        //            DroplistMateria();

        //            ddlIdTipoMateria.Items.Clear();
        //            DroplistTipoMateria();

        //            ddlIdEtapa.Items.Clear();
        //            DroplistEtapa();

        //            ddlIdAreaConocimiento.Items.Clear();
        //            DroplistAreaConocimiento();

        //            ddlSemestre.Items.Clear();
        //            DroplistSemestre();

        //            //Aqui se hacen no editables los TextBox
        //            ControlesOnOFFPlanEstudioMateria(false);

        //            hfIdPlanEstudioMateria.Value = LstPlanEstudioMateria[0].IdPlanEstudioMateria.ToString();
        //            ObjetoEntidad_ControlesWebForm2(Convert.ToInt32(hfIdPlanEstudioMateria.Value));

        //            BtnMnuEditarPlanEstudioMateria.Visible = true;
        //            BtnMnuBorrarPlanEstudioMateria.Visible = true;

        //            PnlCapturaDatosPlanEstudioMateria.Visible = true;
        //            PnlGrvPlanEstudioMateria.Visible = false;
        //        }
        //        else
        //        {
        //            InicializaControlesPlanEstudioMateria();
        //            GrvPlanEstudioMateria.DataSource = LstPlanEstudioMateria;
        //            GrvPlanEstudioMateria.DataBind();
        //            PnlGrvPlanEstudioMateria.Visible = true;
        //        }
        //    }
        //}
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

        #region Botones IBM (WebForm captura datos del cliente) PlanEstudioMateria
        protected void BtnGrabarPlanEstudioMateria_Click(object sender, EventArgs e)
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
        protected void BtnBorrarPlanEstudioMateria_Click(object sender, EventArgs e)
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
        protected void BtnModificarPlanEstudioMateria_Click(object sender, EventArgs e)
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
        protected void BtnMnuEditarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Modificar plan de estudio";

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;

            ControlesOnOFF(true);
        }
        protected void BtnMnuBorrarPlanEstudioMateria_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Borrar Plan de estudio";
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;

            ControlesOnOFF(false);
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

            ddlProgramaEducativo.Items.Clear();
            DroplistProgramaEducativo();

            ddlEstatus.Items.Clear();
            DroplistEstatus();

            ddlIdNivelAcademico.Items.Clear();
            DroplistGradoAcademico();

            ddlUnidadAcademica.Items.Clear();
            DroplistUnidadAcademica();

            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Plan de estudio";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));
            ControlesOnOFF(false);

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

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

            ddlProgramaEducativo.Items.Clear();
            DroplistProgramaEducativo();

            ddlEstatus.Items.Clear();
            DroplistEstatus();

            ddlIdNivelAcademico.Items.Clear();
            DroplistGradoAcademico();

            ddlUnidadAcademica.Items.Clear();
            DroplistUnidadAcademica();

            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Plan de estudio";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));
            ControlesOnOFF(true);

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;

        }
        #endregion

        protected void GrvPlanEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "AQUI SE ASIGNARA EL PLAN DE ESTUDIOS A LAS MATERIAS";

        }

        #region Cargar DropDownList
        //Plan Estudio
        private void DroplistProgramaEducativo()
        {
            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
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
            ddlProgramaEducativo.Items.Insert(0, new ListItem("<Selecciona Carrera>", "0"));
        }
        private void DroplistEstatus()
        {
            //carga datos para estatus

            ListItem i;

            i = new ListItem("<Selecciona>", "0");
            ddlEstatus.Items.Add(i);
            i = new ListItem("APROVADO", "1");
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
            ddlIdNivelAcademico.Items.Insert(0, new ListItem("<Selecciona Nivel Academico>", "0"));
        }
        private void DroplistUnidadAcademica()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
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
            ddlUnidadAcademica.Items.Insert(0, new ListItem("<Selecciona Unidad Academica>", "0"));
        }
        //Plan Estudio - Materia
        private void DroplistPlanEstudio()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdPlanEstudio, PlanEstudio FROM Propuesta.dbo.PlanEstudio", con);
                    adapter.Fill(subjects);
                    ddlIdPlanEstudio.DataSource = subjects;
                    ddlIdPlanEstudio.DataTextField = "PlanEstudio";
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
            ddlIdPlanEstudio.Items.Insert(0, new ListItem("<Selecciona plan estudio>", "0"));
        }
        private void DroplistMateria()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
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
            ddlIdMateria.Items.Insert(0, new ListItem("<Selecciona materia>", "0"));
        }
        private void DroplistTipoMateria()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
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
            ddlIdTipoMateria.Items.Insert(0, new ListItem("<Selecciona tipo de materia>", "0"));
        }
        private void DroplistEtapa()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdEtapa, NombreEtapa FROM Propuesta.dbo.Etapas", con);
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
            ddlIdEtapa.Items.Insert(0, new ListItem("<Selecciona etapa>", "0"));
        }
        private void DroplistAreaConocimiento()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
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
            ddlIdAreaConocimiento.Items.Insert(0, new ListItem("<Selecciona area de conocimiento>", "0"));
        }
        private void DroplistSemestre()
        {
            //carga datos para estatus
            ListItem i;
            i = new ListItem("", "1");
            ddlSemestre.Items.Add(i);
            i = new ListItem("1.º", "2");
            ddlSemestre.Items.Add(i);
            i = new ListItem("2.º", "3");
            ddlSemestre.Items.Add(i);
            i = new ListItem("3.º", "4");
            ddlSemestre.Items.Add(i);
            i = new ListItem("4.º", "5");
            ddlSemestre.Items.Add(i);
            i = new ListItem("5.º", "6");
            ddlSemestre.Items.Add(i);
            i = new ListItem("6.º", "7");
            ddlSemestre.Items.Add(i);
            i = new ListItem("7.º", "8");
            ddlSemestre.Items.Add(i);
            i = new ListItem("8.º", "9");
            ddlSemestre.Items.Add(i);
        }
        #endregion

    }
}