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

            //*********Label de careras******************************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            //*******************************************************

            PnlCapturaDatos.Visible = false;
            PnlGrvMateria.Visible = false;
        }
        protected void ControlesClear()
        {
            TbCriterioBusqueda.Text = string.Empty;
            TbClaveMateria.Text = string.Empty;
            TbNombreMateria.Text = string.Empty;
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            TbClaveMateria.Enabled = TrueOrFalse;
            TbNombreMateria.Enabled = TrueOrFalse;
            //*********Label de materias******************************
            lbNombreMateria.Enabled = TrueOrFalse;
            lbClaveMateria.Enabled = TrueOrFalse;
            //*******************************************************
        }
        #endregion
        #region Objeto Cliente
        protected E_Materias ControlesWebForm_ObjetoEntidad()
        {
            E_Materias Materia = new E_Materias()
            {
                ClaveMateria = TbClaveMateria.Text,
                NombreMateria = TbNombreMateria.Text,
            };
            return Materia;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdMateria)
        {
            E_Materias Materia = NM.BuscaMateriasPorId(IdMateria);

            TbClaveMateria.Text = Materia.ClaveMateria.Trim();
            TbNombreMateria.Text = Materia.NombreMateria.Trim();
        }
        #endregion
        #region Botones menu de navegación 
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            lblTituloAccion.Text = "Nueva materia";
            PnlCapturaDatos.Visible = true;
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;
            //*************Label Carrera*****************
            lbNombreMateria.Visible = true;
            lbClaveMateria.Visible = true;
            //*********************************************
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
                    TbClaveMateria.Visible = true;
                    TbNombreMateria.Visible = true;
                    //*******no editable************************
                    TbClaveMateria.Enabled = false;
                    TbNombreMateria.Enabled = false;
                    //********Label carrera*********************
                    lbNombreMateria.Visible = true;
                    lbClaveMateria.Visible = true;
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
                #endregion
            }
        }
        #region Botones IBM (WebForm captura datos del cliente)
        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            string R = NM.InsertaMaterias(ControlesWebForm_ObjetoEntidad());
            lblTituloAccion.Text = R;
            TbClaveMateria.Visible = false;
            TbNombreMateria.Visible = false;
            //********Label carrera*********************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            //****************************************
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
            TbClaveMateria.Visible = false;
            TbNombreMateria.Visible = false;
            //********Label carrera*********************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            //****************************************
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
            TbClaveMateria.Visible = false;
            TbNombreMateria.Visible = false;
            //********Label carrera*********************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            //****************************************
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
            hfIdMateria.Value = GrvMateria.DataKeys[e.RowIndex].Value.ToString();
            lblTituloAccion.Text = "Borrar Carrera";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdMateria.Value));
            ControlesOnOFF(false);
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            //********Label carrera*********************
            lbNombreMateria.Visible = true;
            lbClaveMateria.Visible = true;
            //****************************************
            PnlCapturaDatos.Visible = true;
            BtnBorrar.Visible = true;
            BtnBorrarModal.Visible = true;
            BtnCancelar.Visible = true;
        }
        protected void GrvCarreras_RowEditing(object sender, GridViewEditEventArgs e)
        {
            InicializaControles();
            e.Cancel = true; //Deshabilitar las ediciones del registro
            hfIdMateria.Value = GrvMateria.DataKeys[e.NewEditIndex].Value.ToString();
            lblTituloAccion.Text = "Modificar Carrera";

            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdMateria.Value));
            ControlesOnOFF(true);
            PnlCapturaDatos.Visible = true;
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            //********Label carrera*********************
            lbNombreMateria.Visible = true;
            lbClaveMateria.Visible = true;
            //****************************************
        }

        #endregion
    }
}