using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
                InicializaControles();
        }

        //por el momento todos las funciones estan en blanco
        #region Métodos generales
        protected void InicializaControles()
        {
            ControlesOFF();
            ControlesClear();
            ControlesOnOFF(true);
        }
        protected void ControlesOFF()
        {
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

        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
           
        }
        #endregion

        #region Objeto Cliente
        protected E_PlanEstudio ControlesWebForm_ObjetoEntidad()
        {
            E_PlanEstudio PlanEstudio = new E_PlanEstudio()
            {
               
            };
            return PlanEstudio;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdPlanEstudio)
        {
            


        }
        #endregion

        #region Botones menu de navegación 
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            lblTituloAccion.Text = "Nueva plan de estudio";


            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;

            //Aqui se ponen visibles los Label, TextBox y el CheckBox
            VisibleOnOFF(true);
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
        #endregion
    }
}