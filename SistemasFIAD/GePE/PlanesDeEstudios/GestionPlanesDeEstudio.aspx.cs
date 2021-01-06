using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

using Entidades;
using Negocios;

namespace GePE.PlanesDeEstudios
{
    public partial class GestionPlanesDeEstudio : System.Web.UI.Page
    {
        string PlanesDeEstudioEstatus = "";
        int PlanesDeEstudioIdEstatus = 0;

        string PlanEstudioMateriaEstatus = "";

        N_Usuarios NU = new N_Usuarios();
        N_Carreras NC = new N_Carreras();
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
            {
                InicializaControles();
            }

            if (Convert.ToString(Session["TipoUsuario"]) == "ADMINISTRADOR")
            {
                //Se quita la columna Revisar
                GrvPlanEstudio.Columns[12].Visible = false;
                //Se quita la columna Publicar
                GrvPlanEstudio.Columns[13].Visible = false;

                BtnMnuListadoEstatus.Visible = false;
                BtnBuscarEstatus.Visible = false;

            }
            else if (Convert.ToString(Session["TipoUsuario"]) == "CAPTURISTA")
            {
                //Se quita la columna Generar mapa curricular
                GrvPlanEstudio.Columns[4].Visible = false;
                //Se quita la columna Mas detalles
                GrvPlanEstudio.Columns[5].Visible = false;
                //Se quita la columna Aprobar
                GrvPlanEstudio.Columns[10].Visible = false;
                //Se quita la columna Recaptura
                GrvPlanEstudio.Columns[11].Visible = false;

                BtnMnuListadoEstatus.Visible = false;
                BtnBuscarEstatus.Visible = false;
            }
            else if (Convert.ToString(Session["TipoUsuario"]) == "INTERNO")
            {
                GrvPlanEstudio.Columns[3].Visible = false;
                GrvPlanEstudio.Columns[5].Visible = false;
                GrvPlanEstudio.Columns[6].Visible = false;
                GrvPlanEstudio.Columns[7].Visible = false;
                GrvPlanEstudio.Columns[8].Visible = false;
                GrvPlanEstudio.Columns[9].Visible = false;
                GrvPlanEstudio.Columns[10].Visible = false;
                GrvPlanEstudio.Columns[11].Visible = false;
                GrvPlanEstudio.Columns[12].Visible = false;
                GrvPlanEstudio.Columns[13].Visible = false;

                BtnMnuNuevo.Visible = false;
                BtnMnuListado.Visible = false;
                BtnMnuListadoEstatus.Visible = true;
                
                BtnBuscar.Visible = false;
                BtnBuscarEstatus.Visible = true;

                BtnMnuEditar.Visible = false;
                BtnMnuBorrar.Visible = false;
            }
            else if (Convert.ToString(Session["TipoUsuario"]) == "")
            {
                GrvPlanEstudio.Columns[3].Visible = false;
                GrvPlanEstudio.Columns[5].Visible = false;
                GrvPlanEstudio.Columns[6].Visible = false;
                GrvPlanEstudio.Columns[7].Visible = false;
                GrvPlanEstudio.Columns[8].Visible = false;
                GrvPlanEstudio.Columns[9].Visible = false;
                GrvPlanEstudio.Columns[10].Visible = false;
                GrvPlanEstudio.Columns[11].Visible = false;
                GrvPlanEstudio.Columns[12].Visible = false;
                GrvPlanEstudio.Columns[13].Visible = false;

                BtnMnuNuevo.Visible = false;
                BtnMnuListado.Visible = false;
                BtnMnuListadoEstatus.Visible = true;

                BtnBuscar.Visible = false;
                BtnBuscarEstatus.Visible = true;

                BtnMnuEditar.Visible = false;
                BtnMnuBorrar.Visible = false;
            }

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

            //Visible datos correo
            PnlCapturaDatosPlanEstudioMateria.Visible = false;
            PnlGrvPlanEstudioMateria.Visible = false;

            lbDestinatario.Visible = false;
            lbRemitente.Visible = false;
            lbAsunto.Visible = false;
            lbObservaciones.Visible = false;

            PnlCapturaDatosCorreo.Visible = false;

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

            lblTituloAccionCorreo.Text = string.Empty;
            ddlDestinatario.Items.Clear();
            TbRemitente.Text = string.Empty;
            TbAsunto.Text = string.Empty;
            TbObservaciones.Text = string.Empty;
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

        #region Métodos generales DatosCorreo
        protected void InicializaControlesDatosCorreo()
        {
            ControlesOFF();
            ControlesClear();
            ControlesOnOFFDatosCorreo(true);
        }
        protected void ControlesOnOFFDatosCorreo(bool TrueOrFalse)
        {
            lbDestinatario.Enabled = TrueOrFalse;
            lbRemitente.Enabled = TrueOrFalse;
            lbAsunto.Enabled = TrueOrFalse;
            lbObservaciones.Enabled = TrueOrFalse;

            ddlDestinatario.Enabled = TrueOrFalse;
            TbRemitente.Enabled = TrueOrFalse;
            TbAsunto.Enabled = TrueOrFalse;
            TbObservaciones.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFFDatosCorreo(bool TrueOrFalse)
        {
            lbDestinatario.Visible = TrueOrFalse;
            lbRemitente.Visible = TrueOrFalse;
            lbAsunto.Visible = TrueOrFalse;
            lbObservaciones.Visible = TrueOrFalse;

            ddlDestinatario.Visible = TrueOrFalse;
            TbRemitente.Visible = TrueOrFalse;
            TbAsunto.Visible = TrueOrFalse;
            TbObservaciones.Visible = TrueOrFalse;
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
                Estatus = PlanesDeEstudioEstatus,
                IdEstatus = PlanesDeEstudioIdEstatus,
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
            ddlProgramaEducativo.SelectedValue = Convert.ToString(planEstudio.ProgramaEducativo);
            TbFechaCreacion.Text = planEstudio.FechaCreacion.Trim();
            TbTotalCreditos.Text = Convert.ToString(planEstudio.TotalCreditos);
            cbEstadoPlanEstudios.Checked = planEstudio.EstadoPlanEstudios;
            TbComentarios.Text = planEstudio.Comentarios.Trim();
            TbPerfilDeIngreso.Text = planEstudio.PerfilDeIngreso.Trim();
            TbPerfilDeEgreso.Text = planEstudio.PerfilDeEgreso.Trim();
            TbCampoOcupacional.Text = planEstudio.CampoOcupacional.Trim();
            ddlUnidadAcademica.SelectedValue = Convert.ToString(planEstudio.UnidadAcademica);
            ddlEstatus.SelectedValue = Convert.ToString(planEstudio.IdEstatus);
            PlanesDeEstudioEstatus = planEstudio.Estatus;
            PlanesDeEstudioIdEstatus = planEstudio.IdEstatus;
        }
        protected E_PlanEstudio Actualizar_PlanEstudio(string ClavePlanEstudio, string estatus, int idestatus)
        {
            List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudioPorClave(ClavePlanEstudio);
            foreach (var item in LstPlanEstudio)
            {
                if (item != null)
                {
                    E_PlanEstudio PlanEstudio = new E_PlanEstudio()
                    {
                        IdNivelAcademico = item.IdNivelAcademico,
                        IdCarrera = item.IdCarrera,
                        ClavePlanEstudio = item.ClavePlanEstudio,
                        PlanEstudio = item.PlanEstudio,
                        ProgramaEducativo = item.ProgramaEducativo,
                        FechaCreacion = item.FechaCreacion,
                        TotalCreditos = item.TotalCreditos,
                        EstadoPlanEstudios = item.EstadoPlanEstudios,
                        Comentarios = item.Comentarios,
                        PerfilDeIngreso = item.PerfilDeIngreso,
                        PerfilDeEgreso = item.PerfilDeEgreso,
                        CampoOcupacional = item.CampoOcupacional,
                        UnidadAcademica = item.UnidadAcademica,
                        Estatus = estatus,
                        IdEstatus = idestatus,
                        NombreCarrera = item.NombreCarrera

                    };
                    return PlanEstudio;
                }
            }
            E_PlanEstudio PlanEstudioNull = null;
            return PlanEstudioNull;
        }
        protected E_Carreras Actualizar_Carrera(string NombreCarrera, int IdCarrera, string estatus)
        {
            List<E_Carreras> LstCarreras = NC.BuscaCarrera(NombreCarrera);
            foreach (var item in LstCarreras)
            {
                if (item != null)
                {
                    if (item.IdCarrera == IdCarrera)
                    {
                        E_Carreras Carrera = new E_Carreras()
                        {
                            ClaveCarrera = item.ClaveCarrera,
                            NombreCarrera = item.NombreCarrera,
                            AliasCarrera = item.AliasCarrera,
                            EstadoCarrera = item.EstadoCarrera,
                            Estatus = estatus
                        };
                        return Carrera;
                    }
                }
            }
            E_Carreras CarreraNull = null;
            return CarreraNull;
        }
        protected E_Materias Actualizar_Materia(string NombreMateria, int IdMateria, string estatus)
        {
            List<E_Materias> LstMaterias = NM.BuscaMateria(NombreMateria);
            foreach (var item in LstMaterias)
            {
                if (item != null)
                {
                    if (item.IdMateria == IdMateria)
                    {
                        //agrega los datos a la base de datos
                        E_Materias Materia = new E_Materias()
                        {
                            ClaveMateria = item.ClaveMateria,
                            NombreMateria = item.NombreMateria,
                            HC = item.HC,
                            HL = item.HL,
                            HT = item.HT,
                            HE = item.HE,
                            HPP = item.HPP,
                            CR = item.CR,
                            PathPUA = item.PathPUA,
                            PathPUAnoOficial = item.PathPUAnoOficial,
                            Estatus = estatus
                        };
                        return Materia;
                    }
                }
            }

            E_Materias MateriaNull = null;
            return MateriaNull;
        }
        protected E_PlanEstudioMateria Actualizar_PlanEstudioMateria(string NombrePlanEstudio, int IdMateria, string estatus)
        {
            List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(NombrePlanEstudio);
            foreach (var item in LstPlanEstudioMateria)
            {
                if (item != null)
                {
                    if (item.IdMateria == IdMateria)
                    {
                        //agrega los datos a la base de datos
                        E_PlanEstudioMateria PlanEstudioMateria = new E_PlanEstudioMateria()
                        {
                            IdPlanEstudio = item.IdPlanEstudio,
                            IdMateria = item.IdMateria,
                            IdTipoMateria = item.IdTipoMateria,
                            IdEtapa = item.IdEtapa,
                            IdAreaConocimiento = item.IdAreaConocimiento,
                            Semestre = item.Semestre,
                            NombrePlanEstudio = item.NombrePlanEstudio,
                            NombreMateria = item.NombreMateria,
                            NombreTipoMateria = item.NombreTipoMateria,
                            NombreEtapa = item.NombreEtapa,
                            NombreArea = item.NombreArea,
                            IdMateriaSeriada = item.IdMateriaSeriada,
                            EstadoMateriaSeriada = item.EstadoMateriaSeriada,
                            ClavePlanEstudio = item.ClavePlanEstudio,
                            NombreMateriaSeriada = item.NombreMateriaSeriada,
                            Estatus = estatus
                        };
                        return PlanEstudioMateria;
                    }
                }
            }

            E_PlanEstudioMateria PlanEstudioMateriaNull = null;
            return PlanEstudioMateriaNull;
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
                    NombreMateriaSeriada = ddlMateriaSeriada.SelectedItem.Text,
                    Estatus = PlanEstudioMateriaEstatus
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
                    ClavePlanEstudio = TbClavePlanEstudio.Text,
                    Estatus = PlanEstudioMateriaEstatus
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
                int index = 0;
                while (ddlIdPlanEstudio.SelectedItem.Text != nombreplan)
                {
                    index = index + 1;
                    ddlIdPlanEstudio.SelectedIndex = index;
                }
                ddlIdPlanEstudio.SelectedIndex = index;
                DroplistMateriaSeriada();
                ddlMateriaSeriada.SelectedValue = Convert.ToString(PlanEstudioMateria.IdMateriaSeriada);
                PlanEstudioMateriaEstatus = PlanEstudioMateria.Estatus;
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
                int index = 0;
                while (ddlIdPlanEstudio.SelectedItem.Text != nombreplan)
                {
                    index = index + 1;
                    ddlIdPlanEstudio.SelectedIndex = index;
                }
                ddlIdPlanEstudio.SelectedIndex = index;
                TbClavePlanEstudio.Text = PlanEstudioMateria.ClavePlanEstudio.Trim();
                PlanEstudioMateriaEstatus = PlanEstudioMateria.Estatus;
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
        protected void BtnMnuListadoEstatus_Click(object sender, EventArgs e)
        {

            List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudioPorEstatus("EN PUBLICADO");
            if (LstPlanEstudio.Count.Equals(0))
            {
                InicializaControles();
                lblNombreAccion.Text = "No se encontraron planes para listar";
            }
            else
            {
                InicializaControles();
                GrvPlanEstudio.DataSource = LstPlanEstudio;
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

                    if (Convert.ToString(Session["TipoUsuario"]) == "")
                    {
                        BtnMnuEditar.Visible = false;
                        BtnMnuBorrar.Visible = false;
                    }
                    else
                    {
                        BtnMnuEditar.Visible = true;
                        BtnMnuBorrar.Visible = true;
                    }

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
        protected void BtnBuscarEstatus_Click(object sender, EventArgs e)
        {
            if (TbCriterioBusqueda.Text.Trim() != string.Empty)
            {
                List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudioConCriterioEstatus(TbCriterioBusqueda.Text.Trim(),"EN PUBLICADO");
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

                    if (Convert.ToString(Session["TipoUsuario"]) == "")
                    {
                        BtnMnuEditar.Visible = false;
                        BtnMnuBorrar.Visible = false;
                    }
                    else
                    {
                        BtnMnuEditar.Visible = true;
                        BtnMnuBorrar.Visible = true;
                    }

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
            PlanesDeEstudioEstatus = "EN ESPERA";
            PlanesDeEstudioIdEstatus = 4;

            string R = PE.InsertaPlanEstudio(ControlesWebForm_ObjetoEntidad());
            lblTituloAccion.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(false);

            BtnGrabar.Visible = false;
            BtnCancelar.Visible = false;
            BtnAceptar.Visible = true;

            PlanesDeEstudioEstatus = "";
            PlanesDeEstudioIdEstatus = 0;

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
            PlanEstudioMateriaEstatus = "EN ESPERA";

            string R = NPEM.InsertaPlanEstudioMateria(ControlesWebForm_ObjetoEntidad2());
            lblTituloAccionPlanEstudioMateria.Text = R;

            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
            VisibleOnOFFPlanEstudioMateria(false);

            BtnGrabarPlanEstudioMateria.Visible = false;
            BtnCancelarPlanEstudioMateria.Visible = false;
            BtnAceptarPlanEstudioMateria.Visible = true;

            PlanEstudioMateriaEstatus = "";

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

        #region Botones IBM Datos Correo
        protected void BtnEnviarPnlCapturaDatosCorreo_Click(object sender, EventArgs e)
        {
            string toname = "";
            lblTituloAccionCorreo.Text = "Correo enviado.";

            CambiarStatus(Convert.ToInt32(Session["hfIdPlanEstudioDatosCorreo"]), Convert.ToString(Session["EstatusDatosCorreo"]), Convert.ToInt32(Session["IdEstatus"]), Convert.ToString(Session["strDatosCorreo"]));

            string fromname = Convert.ToString(Session["NombreUsuario"]) + " " + Convert.ToString(Session["ApellidoPaterno"]) + " " + Convert.ToString(Session["ApellidoMaterno"]);


            List<E_Usuarios> LstUsuarios = NU.BuscaUsuario(ddlDestinatario.SelectedItem.Text);

            foreach (var item in LstUsuarios)
            {
                if (item != null)
                {
                    toname = item.NombreUsuario + " " + item.ApellidoPaterno + " " + item.ApellidoMaterno;
                }
            }



            string subject = TbAsunto.Text;
            string body = TbObservaciones.Text;

            NotificarUsuario(Convert.ToString(Session["CorreoUsuario"]), fromname, Convert.ToString(Session["PassUsuario"]), ddlDestinatario.SelectedItem.Text, toname, subject, body);

            Session["hfIdPlanEstudioDatosCorreo"] = "";
            Session["strDatosCorreo"] = "";
            Session["EstatusDatosCorreo"] = "";
            Session["IdEstatus"] = "";

            PlanesDeEstudioEstatus = "";
            PlanesDeEstudioIdEstatus = 0;

            VisibleOnOFFDatosCorreo(false);

            BtnEnviarPnlCapturaDatosCorreo.Visible = false;
            BtnCancelarPnlCapturaDatosCorreo.Visible = false;
            BtnAceptarPnlCapturaDatosCorreo.Visible = true;
        }
        protected void BtnCancelarPnlCapturaDatosCorreo_Click(object sender, EventArgs e)
        {
            Session["hfIdPlanEstudioDatosCorreo"] = "";
            Session["strDatosCorreo"] = "";
            Session["EstatusDatosCorreo"] = "";
            Session["IdEstatus"] = "";

            PlanesDeEstudioEstatus = "";
            PlanesDeEstudioIdEstatus = 0;
            InicializaControles();
        }
        protected void BtnAceptarPnlCapturaDatosCorreo_Click(object sender, EventArgs e)
        {
            Session["hfIdPlanEstudioDatosCorreo"] = "";
            Session["strDatosCorreo"] = "";
            Session["EstatusDatosCorreo"] = "";
            Session["IdEstatus"] = "";

            PlanesDeEstudioEstatus = "";
            PlanesDeEstudioIdEstatus = 0;

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

            //aqui se hace la validacion de estatus de carrera*****************************************************************************
            String str = GrvPlanEstudio.Rows[e.RowIndex].Cells[1].Text;

            List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudio(str);

            foreach (var item in LstPlanEstudio)
            {
                if (item != null)
                {
                    if (item.ClavePlanEstudio == GrvPlanEstudio.Rows[e.RowIndex].Cells[0].Text)
                    {
                        if (item.Estatus == "EN REVISION")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Plan de estudio con estatus \"EN REVISION\", no se puede borrar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN RECAPTURA")
                        {
                            //si se puede borrar

                        }
                        else if (item.Estatus == "EN ESPERA")
                        {
                            //si se puede borrar
                        }
                        else if (item.Estatus == "EN PUBLICADO")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Plan de estudio con estatus \"EN PUBLICADO\", no se puede borrar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN APROBADO")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Plan de estudio con estatus \"EN APROBADO\", no se puede borrar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                    }
                }
            }
            //aqui se hace la validacion de estatus de carrera*****************************************************************************

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

            //aqui se hace la validacion de estatus de carrera*****************************************************************************
            String str = GrvPlanEstudio.Rows[e.NewEditIndex].Cells[1].Text;

            List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudio(str);

            foreach (var item in LstPlanEstudio)
            {
                if (item != null)
                {
                    if (item.ClavePlanEstudio == GrvPlanEstudio.Rows[e.NewEditIndex].Cells[0].Text)
                    {
                        if (item.Estatus == "EN REVISION")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Plan de estudio con estatus \"EN REVISION\", no se puede modificar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN RECAPTURA")
                        {
                            //si se puede modificar
                        }
                        else if (item.Estatus == "EN ESPERA")
                        {
                            //si se puede modificar
                        }
                        else if (item.Estatus == "EN PUBLICADO")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Plan de estudio con estatus \"EN PUBLICADO\", no se puede modificar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN APROBADO")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Plan de estudio con estatus \"EN APROBADO\", no se puede modificar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                    }
                }
            }
            //aqui se hace la validacion de estatus de carrera*****************************************************************************

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

            PlanEstudioMateriaEstatus = "EN ESPERA";

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
            ddlMateriaSeriada.Enabled = false;

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
            if (e.CommandName == "Aprobar")
            {
                lblTituloAccionCorreo.Text = "Enviar plan de estudio a aprobado";

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];
                string str = row.Cells[0].Text;

                hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[row.RowIndex].Value.ToString();
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));

                PlanesDeEstudioEstatus = "EN APROBADO";
                PlanesDeEstudioIdEstatus = 1;

                Session["hfIdPlanEstudioDatosCorreo"] = Convert.ToInt16(hfIdPlanEstudio.Value);
                Session["strDatosCorreo"] = str;
                Session["EstatusDatosCorreo"] = PlanesDeEstudioEstatus;
                Session["IdEstatus"] = PlanesDeEstudioIdEstatus;

                //Aqui se cargan los datos de el remitente
                DroplistUsuarios();

                //Aqui se hacen no visible los Label, TextBox y el CheckBox
                VisibleOnOFFDatosCorreo(true);

                TbRemitente.Text = Convert.ToString(Session["CorreoUsuario"]);
                TbRemitente.Enabled = false;

                PnlCapturaDatosCorreo.Visible = true;

                PnlGrvPlanEstudio.Visible = false;

                BtnEnviarPnlCapturaDatosCorreo.Visible = true;
                BtnCancelarPnlCapturaDatosCorreo.Visible = true;
                BtnAceptarPnlCapturaDatosCorreo.Visible = false;
            }
            if (e.CommandName == "Recaptura")
            {
                lblTituloAccionCorreo.Text = "Enviar plan de estudio a recaptura";

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];
                string str = row.Cells[0].Text;

                hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[row.RowIndex].Value.ToString();
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));

                PlanesDeEstudioEstatus = "EN RECAPTURA";
                PlanesDeEstudioIdEstatus = 3;

                Session["hfIdPlanEstudioDatosCorreo"] = Convert.ToInt16(hfIdPlanEstudio.Value);
                Session["strDatosCorreo"] = str;
                Session["EstatusDatosCorreo"] = PlanesDeEstudioEstatus;
                Session["IdEstatus"] = PlanesDeEstudioIdEstatus;

                ControlesOFF();

                //Aqui se cargan los datos de el remitente
                DroplistUsuarios();

                //Aqui se hacen no visible los Label, TextBox y el CheckBox
                VisibleOnOFFDatosCorreo(true);

                TbRemitente.Text = Convert.ToString(Session["CorreoUsuario"]);
                TbRemitente.Enabled = false;

                PnlCapturaDatosCorreo.Visible = true;

                PnlGrvPlanEstudio.Visible = false;

                BtnEnviarPnlCapturaDatosCorreo.Visible = true;
                BtnCancelarPnlCapturaDatosCorreo.Visible = true;
                BtnAceptarPnlCapturaDatosCorreo.Visible = false;
            }
            if (e.CommandName == "Revisión")
            {
                lblTituloAccionCorreo.Text = "Enviar plan de estudio a revision";

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];
                string str = row.Cells[0].Text;

                hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[row.RowIndex].Value.ToString();
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));

                PlanesDeEstudioEstatus = "EN REVISION";
                PlanesDeEstudioIdEstatus = 2;

                Session["hfIdPlanEstudioDatosCorreo"] = Convert.ToInt16(hfIdPlanEstudio.Value);
                Session["strDatosCorreo"] = str;
                Session["EstatusDatosCorreo"] = PlanesDeEstudioEstatus;
                Session["IdEstatus"] = PlanesDeEstudioIdEstatus;

                ControlesOFF();

                //Aqui se cargan los datos de el remitente
                DroplistUsuarios();

                //Aqui se hacen no visible los Label, TextBox y el CheckBox
                VisibleOnOFFDatosCorreo(true);

                TbRemitente.Text = Convert.ToString(Session["CorreoUsuario"]);
                TbRemitente.Enabled = false;

                PnlCapturaDatosCorreo.Visible = true;

                PnlGrvPlanEstudio.Visible = false;

                BtnEnviarPnlCapturaDatosCorreo.Visible = true;
                BtnCancelarPnlCapturaDatosCorreo.Visible = true;
                BtnAceptarPnlCapturaDatosCorreo.Visible = false;

            }
            if (e.CommandName == "Publicar")
            {
                lblTituloAccionCorreo.Text = "Enviar plan de estudio a publicar";

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GrvPlanEstudio.Rows[index];
                string str = row.Cells[0].Text;

                hfIdPlanEstudio.Value = GrvPlanEstudio.DataKeys[row.RowIndex].Value.ToString();
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanEstudio.Value));

                PlanesDeEstudioEstatus = "EN PUBLICADO";
                PlanesDeEstudioIdEstatus = 5;

                Session["hfIdPlanEstudioDatosCorreo"] = Convert.ToInt16(hfIdPlanEstudio.Value);
                Session["strDatosCorreo"] = str;
                Session["EstatusDatosCorreo"] = PlanesDeEstudioEstatus;
                Session["IdEstatus"] = PlanesDeEstudioIdEstatus;

                ControlesOFF();

                //Aqui se cargan los datos de el remitente
                DroplistUsuarios();

                //Aqui se hacen no visible los Label, TextBox y el CheckBox
                VisibleOnOFFDatosCorreo(true);

                TbRemitente.Text = Convert.ToString(Session["CorreoUsuario"]);
                TbRemitente.Enabled = false;

                PnlCapturaDatosCorreo.Visible = true;

                PnlGrvPlanEstudio.Visible = false;

                BtnEnviarPnlCapturaDatosCorreo.Visible = true;
                BtnCancelarPnlCapturaDatosCorreo.Visible = true;
                BtnAceptarPnlCapturaDatosCorreo.Visible = false;

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

                        if (item.Semestre == 1)
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

                                }
                            }
                            MS8 = MS8 + 1;
                        }
                        else
                        {
                        }

                        if (index <= 12)
                        {
                            index = index + 1;
                        }

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

                            }
                        }

                    }
                    else
                    {

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

            //aqui se hace la validacion de estatus de carrera*****************************************************************************
            String str = GrvPlanEstudioMateria.Rows[e.RowIndex].Cells[0].Text;

            List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(str);

            foreach (var item in LstPlanEstudioMateria)
            {
                if (item != null)
                {
                    if (item.ClavePlanEstudio == GrvPlanEstudio.Rows[e.RowIndex].Cells[0].Text)
                    {
                        if (item.Estatus == "EN REVISION")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Materia asosiada a plan de estudio con estatus \"EN REVISIÓN\", no se puede borrar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN RECAPTURA")
                        {
                            //si se puede borrar

                        }
                        else if (item.Estatus == "EN ESPERA")
                        {
                            //si se puede borrar
                        }
                        else if (item.Estatus == "EN PUBLICADO")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Materia asosiada a plan de estudio con estatus \"EN PUBLICADO\", no se puede borrar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN APROBADO")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Materia asosiada a plan de estudio con estatus \"EN APROBADO\", no se puede borrar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                    }
                }
            }
            //aqui se hace la validacion de estatus de carrera*****************************************************************************

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

            //aqui se hace la validacion de estatus de carrera*****************************************************************************
            String str = GrvPlanEstudioMateria.Rows[e.NewEditIndex].Cells[0].Text;

            List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(str);

            foreach (var item in LstPlanEstudioMateria)
            {
                if (item != null)
                {
                    if (item.ClavePlanEstudio == GrvPlanEstudio.Rows[e.NewEditIndex].Cells[0].Text)
                    {
                        if (item.Estatus == "EN REVISION")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Materia asosiada a plan de estudio con estatus \"EN REVISION\", no se puede modificar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN RECAPTURA")
                        {
                            //si se puede modificar
                        }
                        else if (item.Estatus == "EN ESPERA")
                        {
                            //si se puede modificar
                        }
                        else if (item.Estatus == "EN PUBLICADO")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Materia asosiada a plan de estudio con estatus \"EN PUBLICADO\", no se puede modificar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                        else if (item.Estatus == "EN APROBADO")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Materia asosiada a plan de estudio con estatus \"EN APROBADO\", no se puede modificar.";

                            PnlCapturaDatos.Visible = true;

                            //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                            VisibleOnOFF(false);

                            BtnModificar.Visible = false;
                            BtnCancelar.Visible = false;
                            BtnAceptar.Visible = true;

                            return;
                        }
                    }
                }
            }
            //aqui se hace la validacion de estatus de carrera*****************************************************************************

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
            i = new ListItem("EN APROBADO", "1");
            ddlEstatus.Items.Add(i);
            i = new ListItem("EN REVISION", "2");
            ddlEstatus.Items.Add(i);
            i = new ListItem("EN RECAPTURA", "3");
            ddlEstatus.Items.Add(i);
            i = new ListItem("EN ESPERA", "4");
            ddlEstatus.Items.Add(i);
            i = new ListItem("EN PUBLICADO", "5");
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

        private void DroplistUsuarios()
        {

            //carga los datos de la base de datos y los pone en dropdownlist

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            //using (SqlConnection con = new SqlConnection("Data Source=WIN-URE2BDKARPV\\SQLEXPRESS;Initial Catalog=Propuesta;Integrated Security=True"))
            {
                if (Convert.ToString(Session["TipoUsuario"]) == "ADMINISTRADOR")
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdUsuario, CorreoUsuario FROM Propuesta.dbo.Usuarios WHERE TipoUsuario='CAPTURISTA'", con);
                        adapter.Fill(subjects);
                        ddlDestinatario.DataSource = subjects;
                        ddlDestinatario.DataTextField = "CorreoUsuario";
                        ddlDestinatario.DataValueField = "IdUsuario";
                        ddlDestinatario.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle the error 
                    }
                }
                else
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdUsuario, CorreoUsuario FROM Propuesta.dbo.Usuarios WHERE TipoUsuario='ADMINISTRADOR'", con);
                        adapter.Fill(subjects);
                        ddlDestinatario.DataSource = subjects;
                        ddlDestinatario.DataTextField = "CorreoUsuario";
                        ddlDestinatario.DataValueField = "IdUsuario";
                        ddlDestinatario.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle the error 
                    }
                }
            }
            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlDestinatario.Items.Insert(0, new ListItem("<Seleccione Destinatario>", ""));
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


        private void NotificarUsuario(string fromaddress, string fromname, string frompass, string toaddress, string toname, string sub, string bod)
        {
            var fromAddress = new MailAddress(fromaddress, fromname);
            var toAddress = new MailAddress(toaddress, toname);
            string fromPassword = frompass;
            string subject = sub;
            string body = bod;

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
                Body = body
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

        private void CambiarStatus(int hfIdPlanEstudio, string estatus, int idestatus, string str)
        {
            string R = "";

            List<E_PlanEstudio> LstPlanEstudio = PE.BuscaPlanEstudioPorClave(str);
            foreach (var item in LstPlanEstudio)
            {
                if (item != null)
                {
                    //plan estudio
                    E_PlanEstudio ClientePlanEstudio = Actualizar_PlanEstudio(item.ClavePlanEstudio, estatus, idestatus);
                    ClientePlanEstudio.IdPlanEstudio = item.IdPlanEstudio;
                    R = PE.ModificaPlanEstudio(ClientePlanEstudio);

                    //carrera
                    E_Carreras ClienteCarrera = Actualizar_Carrera(item.NombreCarrera, item.IdCarrera, estatus);
                    ClienteCarrera.IdCarrera = item.IdCarrera;
                    R = NC.ModificaCarreras(ClienteCarrera);

                }
            }

            List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMaterias(str);
            foreach (var item in LstPlanEstudioMateria)
            {
                if (item != null)
                {
                    //materia
                    E_Materias ClienteMateria = Actualizar_Materia(item.NombreMateria, item.IdMateria, estatus);
                    ClienteMateria.IdMateria = item.IdMateria;
                    R = NM.ModificaMaterias(ClienteMateria);

                    //Plan estudio materia
                    E_PlanEstudioMateria ClientePlanEstudioMateria = Actualizar_PlanEstudioMateria(str, item.IdMateria, estatus);
                    ClientePlanEstudioMateria.IdPlanEstudioMateria = item.IdPlanEstudioMateria;
                    R = NPEM.ModificaPlanEstudioMateria(ClientePlanEstudioMateria);
                }
            }

            PlanesDeEstudioEstatus = "";
            PlanesDeEstudioIdEstatus = 0;
        }

    }
}