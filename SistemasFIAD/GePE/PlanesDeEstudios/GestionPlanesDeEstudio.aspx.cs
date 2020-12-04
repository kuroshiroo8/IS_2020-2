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
        N_NivelAcademico NV = new N_NivelAcademico();
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
            lbClavePlanEstudio.Visible = false;
            lbNombrePlanEstudio.Visible = false;
            lbProgramaPlanEstudio.Visible = false;
            lbEstatus.Visible = false;
            lbCheckPlan.Visible = false;
            lbFecha.Visible = false;
            lbGradoAcademico.Visible = false;
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
            PnlGrvPlanesEstudio.Visible = false;
        }
        protected void ControlesClear()
        {
            //Clear Label
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;
            

            //Clear TextBox
            TbCriterioBusqueda.Text = string.Empty;
            TbClavePlanEstudio.Text = string.Empty;
            TbNombrePlanEstudio.Text = string.Empty;
            TbFechaPlanEstudio.Text = string.Empty;
            TbGradoAcademico.Text = string.Empty;
            TbCampoOcupacional.Text = string.Empty;
            TbUnidadAcademica.Text = string.Empty;

            //Clear CheckBox
            cbActivaPlan.Checked = false;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            //Enabled Label
            lbClavePlanEstudio.Enabled = TrueOrFalse;
            lbNombrePlanEstudio.Enabled = TrueOrFalse;
            lbProgramaPlanEstudio.Enabled = TrueOrFalse;
            lbEstatus.Enabled = TrueOrFalse;
            lbCheckPlan.Enabled = TrueOrFalse;
            lbFecha.Enabled = TrueOrFalse;
            lbGradoAcademico.Enabled = TrueOrFalse;
            lbCampoOcupacional.Enabled = TrueOrFalse;
            lbUnidadAcademica.Enabled = TrueOrFalse;

            //Enabled TextBox
            TbClavePlanEstudio.Enabled = TrueOrFalse;
            TbNombrePlanEstudio.Enabled = TrueOrFalse;
            TbFechaPlanEstudio.Enabled = TrueOrFalse;
            TbCampoOcupacional.Enabled = TrueOrFalse;
            TbUnidadAcademica.Enabled = TrueOrFalse;

            //Enabled DropDownList
            ddlProgramaPlanEstudio.Enabled = TrueOrFalse;
            ddlEstatus.Enabled = TrueOrFalse;

            //Enabled CheckBox
            cbActivaPlan.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
            //Visible Label
            lbClavePlanEstudio.Visible = TrueOrFalse;
            lbNombrePlanEstudio.Visible = TrueOrFalse;
            lbProgramaPlanEstudio.Visible = TrueOrFalse;
            lbEstatus.Visible = TrueOrFalse;
            lbCheckPlan.Visible = TrueOrFalse;
            lbFecha.Visible = TrueOrFalse;
            lbGradoAcademico.Visible = TrueOrFalse;
            lbCampoOcupacional.Visible = TrueOrFalse;
            lbUnidadAcademica.Visible = TrueOrFalse;

            //Visible TextBox
            TbClavePlanEstudio.Visible = TrueOrFalse;
            TbNombrePlanEstudio.Visible = TrueOrFalse;
            TbFechaPlanEstudio.Visible = TrueOrFalse;
            TbGradoAcademico.Visible = TrueOrFalse;
            TbCampoOcupacional.Visible = TrueOrFalse;
            TbUnidadAcademica.Visible = TrueOrFalse;

            //Visible DropDownList
            ddlProgramaPlanEstudio.Visible = TrueOrFalse;
            ddlEstatus.Visible = TrueOrFalse;

            //Visible CheckBox
            cbActivaPlan.Visible = TrueOrFalse;
        }
        #endregion

        #region Objeto Cliente
        protected E_PlanEstudio ControlesWebForm_ObjetoEntidad()
        {
            E_PlanEstudio PlanEstudio = new E_PlanEstudio()
            {
                
                ClavePlanEstudio = TbClavePlanEstudio.Text,
                PlanEstudio = TbNombrePlanEstudio.Text,
                ProgramaEducativo = ddlProgramaPlanEstudio.SelectedItem.Text,
                Estatus=ddlEstatus.SelectedItem.Text,
                EstadoPlanEstudios = cbActivaPlan.Checked,
                //nivel no se puso porque en la bd esta como int
                CampoOcupacional=TbCampoOcupacional.Text,
                FechaCreacion = TbFechaPlanEstudio.Text,
                IdNivelAcademico = Convert.ToInt32(1),
                IdCarrera= Convert.ToInt32(ddlProgramaPlanEstudio.SelectedValue)
            };
            return PlanEstudio;
            
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdPlanEstudio)
        {
            E_PlanEstudio  planEstudio = PE.BuscaPlanEstudioPorId(IdPlanEstudio);

            TbClavePlanEstudio.Text = planEstudio.ClavePlanEstudio.Trim();
            TbNombrePlanEstudio.Text = planEstudio.PlanEstudio.Trim();



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
            DroplistProgramaEducativo();
            DroplistEstatus();
        }
        protected void BtnMnuListado_Click(object sender, EventArgs e)
        {
            InicializaControles();
            N_PlanEstudio PE = new N_PlanEstudio();
            GrvPlanesEstudio.DataSource = PE.LstPlanEstudio();
            GrvPlanesEstudio.DataBind();
            PnlGrvPlanesEstudio.Visible = true;
        }
        protected void BtnMnuPDF_Click(object sender, EventArgs e)
        {
            lblNombreAccion.Text = "Aquí van las acciones del botón BtnMnuPDF";
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

                    //Aqui se ponen visibles los Label, TextBox y el CheckBox
                    

                    hfIdPlanesEStudio.Value = LstPlanEstudio[0].IdCarrera.ToString();
                    ObjetoEntidad_ControlesWebForm(Convert.ToInt32(hfIdPlanesEStudio.Value));

                    BtnMnuEditar.Visible = true;
                    BtnMnuBorrar.Visible = true;

                    PnlCapturaDatos.Visible = true;
                    PnlGrvPlanesEstudio.Visible = false;
                }
                else
                {
                    InicializaControles();
                    GrvPlanesEstudio.DataSource = LstPlanEstudio;
                    GrvPlanesEstudio.DataBind();
                    PnlGrvPlanesEstudio.Visible = true;
                }
            }
        }
        //carga los datos de la base de datos y los pone en dropdownlist
        private void DroplistProgramaEducativo()
        {

            DataTable subjects = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Propuesta;Integrated Security=True"))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT IdCarrera, NombreCarrera FROM Propuesta.dbo.Carreras", con);
                    adapter.Fill(subjects);

                    ddlProgramaPlanEstudio.DataSource = subjects;
                    ddlProgramaPlanEstudio.DataTextField = "NombreCarrera";
                    ddlProgramaPlanEstudio.DataValueField = "IdCarrera";
                    ddlProgramaPlanEstudio.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle the error 
                }

            }

            // Add the initial item - you can add this even if the options from the 
            // db were not successfully loaded 
            ddlProgramaPlanEstudio.Items.Insert(0, new ListItem("<Selecciona Carrera>", "0"));
        }
        //carga datos para estatus
        private void DroplistEstatus()
        {
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
            string R = PE.BorraPlanEstudio(Convert.ToInt32(hfIdPlanesEStudio.Value));
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
           
        }
        protected void BtnMnuEditar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Modificar plan de estudio";
            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            BtnMnuBorrar.Visible = false;
            BtnMnuEditar.Visible = false;
            ControlesOnOFF(true);

            //TbCR.Enabled = false;
            //para que aparescan
            //BtnActualizarCR.Visible = true;
            //BtnPathPUA.Visible = true;
            //BtnPathPUAnoOficial.Visible = true;

        }
        protected void BtnMnuBorrar_Click(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "Borrar pland e estudio";
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
        protected void GrvPlanesEstudio_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ControlesOFF();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdPlanesEStudio.Value = GrvPlanesEstudio.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Plan de estudio";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanesEStudio.Value));
            ControlesOnOFF(false);

            //Aqui se hacen no visible los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            //BtnActualizarCR.Visible = false;
            //BtnPathPUA.Visible = false;
            //BtnPathPUAnoOficial.Visible = false;

            PnlCapturaDatos.Visible = true;
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvPlanesEstudio_RowEditing(object sender, GridViewEditEventArgs e)
        {
            InicializaControles();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdPlanesEStudio.Value = GrvPlanesEstudio.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Plan de estudio";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdPlanesEStudio.Value));
            ControlesOnOFF(true);

            PnlCapturaDatos.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
        }
        #endregion

        protected void GrvPlanesEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "AQUI SE ASIGNARA EL PLAN DE ESTUDIOS A LAS MATERIAS";
        }
    }
}