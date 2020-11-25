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
            lbHoraClaseMateria.Visible = false;
            lbHoraTallerMateria.Visible = false;
            lbHoraLaboratorioMateria.Visible = false;
            lbHoraExtraClaseMateria.Visible = false;
            lbCreditosMateria.Visible = false;
            lbEtapaFormacionMateria.Visible = false;
            lbCaracteristicasFormacionMateria.Visible = false;
            lbSemestreMateria.Visible = false;
            lbAreaConocimientoMateria.Visible = false;
            lbPathPUAnoOficialMateria.Visible = false;
            lbPathPUAOficialMateria.Visible = false;
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
            TbHoraClaseMateria.Text = string.Empty;
            TbHoraTallerMateria.Text = string.Empty;
            TbHoraLaboratorioMateria.Text = string.Empty;
            TbHoraExtraClaseMateria.Text = string.Empty;
            TbCreditosMateria.Text = string.Empty;
            //TbEtapaFormacionMateria.Text = string.Empty;
            //TbCaracteristicasFormacionMateria.Text = string.Empty;
            //TbSemestreMateria.Text = string.Empty;  
            LstSemestre.Items.Clear();
            LstCaracteristicas.Items.Clear();
            LstEtapaFormacion.Items.Clear();
            LstAreaConocimiento.Items.Clear();
            //TbAreaConocimientoMateria.Text = string.Empty;
            TbPathPUAnoOficialMateria.Text = string.Empty;
            TbPathPUAOficialMateria.Text = string.Empty;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            TbClaveMateria.Enabled = TrueOrFalse;
            TbNombreMateria.Enabled = TrueOrFalse;
            lblNombreAccion.Enabled = TrueOrFalse;
            lblTituloAccion.Enabled = TrueOrFalse;
            TbHoraClaseMateria.Enabled = TrueOrFalse;
            TbHoraTallerMateria.Enabled = TrueOrFalse;
            TbHoraLaboratorioMateria.Enabled = TrueOrFalse;
            TbHoraExtraClaseMateria.Enabled = TrueOrFalse;
            TbCreditosMateria.Enabled = TrueOrFalse;
            //TbEtapaFormacionMateria.Enabled = TrueOrFalse;
            //TbCaracteristicasFormacionMateria.Enabled = TrueOrFalse;
            //TbSemestreMateria.Enabled = TrueOrFalse;
            LstSemestre.Enabled = TrueOrFalse;
            LstCaracteristicas.Enabled = TrueOrFalse;
            LstEtapaFormacion.Enabled = TrueOrFalse;
            //TbAreaConocimientoMateria.Enabled = TrueOrFalse;
            LstAreaConocimiento.Enabled = TrueOrFalse;
            TbPathPUAnoOficialMateria.Enabled = TrueOrFalse;
            TbPathPUAOficialMateria.Enabled = TrueOrFalse;
            //*********Label de materias******************************
            lbNombreMateria.Enabled = TrueOrFalse;
            lbClaveMateria.Enabled = TrueOrFalse;
            lbHoraClaseMateria.Enabled = TrueOrFalse;
            lbHoraTallerMateria.Enabled = TrueOrFalse;
            lbHoraLaboratorioMateria.Enabled = TrueOrFalse;
            lbHoraExtraClaseMateria.Enabled = TrueOrFalse;
            lbCreditosMateria.Enabled = TrueOrFalse;
            lbEtapaFormacionMateria.Enabled = TrueOrFalse;
            lbCaracteristicasFormacionMateria.Enabled = TrueOrFalse;
            lbSemestreMateria.Enabled = TrueOrFalse;
            lbAreaConocimientoMateria.Enabled = TrueOrFalse;
            lbPathPUAnoOficialMateria.Enabled = TrueOrFalse;
            lbPathPUAOficialMateria.Enabled = TrueOrFalse;
            //*******************************************************
        }
        #endregion
        #region Objeto Cliente
        protected E_Materias ControlesWebForm_ObjetoEntidad()
        {
            E_Materias Materia = new E_Materias()
            {
                //accede a la base de datos para hacer la lista
                ClaveMateria = TbClaveMateria.Text,
                NombreMateria = TbNombreMateria.Text,
                SemestreMateria = LstSemestre.SelectedIndex,
                CaracteristicasFormacionMateria = LstCaracteristicas.SelectedItem.Text,
                EtapaFormacionMateria=LstEtapaFormacion.SelectedItem.Text,
                AreaConocimientoMateria=LstAreaConocimiento.SelectedItem.Text,
            };
            return Materia;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdMateria)
        {
            //agrega los datos a la base de datos
            E_Materias Materia = NM.BuscaMateriasPorId(IdMateria);

            TbClaveMateria.Text = Materia.ClaveMateria.Trim();
            TbNombreMateria.Text = Materia.NombreMateria.Trim();
            LstSemestre.SelectedIndex = LstSemestre.SelectedIndex + 1;
            LstSemestre.SelectedIndex = Materia.SemestreMateria;
            LstCaracteristicas.SelectedItem.Value = Materia.CaracteristicasFormacionMateria;
            LstEtapaFormacion.SelectedItem.Value = Materia.EtapaFormacionMateria;
            LstAreaConocimiento.SelectedItem.Value = Materia.AreaConocimientoMateria;
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
            TbHoraClaseMateria.Visible = true;
            TbHoraTallerMateria.Visible = true;
            TbHoraLaboratorioMateria.Visible = true;
            TbHoraExtraClaseMateria.Visible = true;
            TbCreditosMateria.Visible = true;
            //TbEtapaFormacionMateria.Visible = true;
            //TbCaracteristicasFormacionMateria.Visible = true;
            //TbSemestreMateria.Visible = true;
            LstEtapaFormacion.Visible = true;
            ListItem E;
            E = new ListItem("", "1");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("BASICA", "2");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("DISIPLINARIA", "3");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("TERMINAL", "4");
            LstEtapaFormacion.Items.Add(E);
            LstCaracteristicas.Visible = true;
            ListItem c;
            c = new ListItem("", "1");
            LstCaracteristicas.Items.Add(c);
            c = new ListItem("OBLIGATORIA", "2");
            LstCaracteristicas.Items.Add(c);
            c = new ListItem("OPTATIVA", "3");
            LstCaracteristicas.Items.Add(c);
            LstSemestre.Visible = true;           
            ListItem i;
            i = new ListItem("", "1");
            LstSemestre.Items.Add(i);
            i = new ListItem("1.º", "2");
            LstSemestre.Items.Add(i);
            i = new ListItem("2.º", "3");
            LstSemestre.Items.Add(i);
            i = new ListItem("3.º", "4");
            LstSemestre.Items.Add(i);
            i = new ListItem("4.º", "5");
            LstSemestre.Items.Add(i);
            i = new ListItem("5.º", "6");
            LstSemestre.Items.Add(i);
            i = new ListItem("6.º", "7");
            LstSemestre.Items.Add(i);
            i = new ListItem("7.º", "8");
            LstSemestre.Items.Add(i);
            i = new ListItem("8.º", "9");
            LstSemestre.Items.Add(i);
            //TbAreaConocimientoMateria.Visible = true;
            LstAreaConocimiento.Visible = true;
            ListItem a;
            a = new ListItem("", "1");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS BASICAS", "2");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS SOCIALES Y HUMANIDADES", "3");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS ECONOMICAS ADMINISTRATIVAS", "4");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS DE LA INGENIERIA", "5");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("INGENIERIA APLICADA", "6");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("DISEÑO EN INGENIERIA", "7");
            LstAreaConocimiento.Items.Add(a);
            TbPathPUAnoOficialMateria.Visible = true;
            TbPathPUAOficialMateria.Visible = true;
            BtnGrabar.Visible = true;
            BtnCancelar.Visible = true;
            //*************Label Materia*****************
            lbNombreMateria.Visible = true;
            lbClaveMateria.Visible = true;
            lbHoraClaseMateria.Visible = true;
            lbHoraTallerMateria.Visible = true;
            lbHoraLaboratorioMateria.Visible = true;
            lbHoraExtraClaseMateria.Visible = true;
            lbCreditosMateria.Visible = true;
            lbEtapaFormacionMateria.Visible = true;
            lbCaracteristicasFormacionMateria.Visible = true;
            lbSemestreMateria.Visible = true;
            lbAreaConocimientoMateria.Visible = true;
            lbPathPUAnoOficialMateria.Visible = true;
            lbPathPUAOficialMateria.Visible = true;
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
                    //texbox visibles**************************
                    TbClaveMateria.Visible = true;
                    TbNombreMateria.Visible = true;
                    TbHoraClaseMateria.Visible = true;
                    TbHoraTallerMateria.Visible = true;
                    TbHoraLaboratorioMateria.Visible = true;
                    TbHoraExtraClaseMateria.Visible = true;
                    TbCreditosMateria.Visible = true;
                    //TbEtapaFormacionMateria.Visible = true;
                    //TbCaracteristicasFormacionMateria.Visible = true;
                    //TbSemestreMateria.Visible = true;
                    LstSemestre.Visible = true;
                    LstCaracteristicas.Visible = true;
                    LstEtapaFormacion.Visible = true;
                    LstAreaConocimiento.Visible = true;
                    //TbAreaConocimientoMateria.Visible = true;
                    TbPathPUAnoOficialMateria.Visible = true;
                    TbPathPUAOficialMateria.Visible = true;
                    //*******no editable************************
                    TbClaveMateria.Enabled = false;
                    TbNombreMateria.Enabled = false;
                    TbHoraClaseMateria.Enabled = false;
                    TbHoraTallerMateria.Enabled = false;
                    TbHoraLaboratorioMateria.Enabled = false;
                    TbHoraExtraClaseMateria.Enabled = false;
                    TbCreditosMateria.Enabled = false;
                    //TbEtapaFormacionMateria.Enabled = false;
                    //TbCaracteristicasFormacionMateria.Enabled = false;
                    //TbSemestreMateria.Enabled = false;
                    LstSemestre.Enabled = false;
                    LstCaracteristicas.Enabled = false;
                    LstEtapaFormacion.Enabled = false;
                    LstAreaConocimiento.Enabled = false;
                    //TbAreaConocimientoMateria.Enabled = false;
                    TbPathPUAnoOficialMateria.Enabled = false;
                    TbPathPUAOficialMateria.Enabled = false;
                    //********Label materia*********************
                    lbNombreMateria.Visible = true;
                    lbClaveMateria.Visible = true;
                    lbHoraClaseMateria.Visible = true;
                    lbHoraTallerMateria.Visible = true;
                    lbHoraLaboratorioMateria.Visible = true;
                    lbHoraExtraClaseMateria.Visible = true;
                    lbCreditosMateria.Visible = true;
                    lbEtapaFormacionMateria.Visible = true;
                    lbCaracteristicasFormacionMateria.Visible = true;
                    lbSemestreMateria.Visible = true;
                    lbAreaConocimientoMateria.Visible = true;
                    lbPathPUAnoOficialMateria.Visible = true;
                    lbPathPUAOficialMateria.Visible = true;
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
            //texbox no visibles************************
            TbClaveMateria.Visible = false;
            TbNombreMateria.Visible = false;
            TbHoraClaseMateria.Visible = false;
            TbHoraTallerMateria.Visible =false;
            TbHoraLaboratorioMateria.Visible = false;
            TbHoraExtraClaseMateria.Visible = false;
            TbCreditosMateria.Visible = false;
            //TbEtapaFormacionMateria.Visible = false;
            //TbCaracteristicasFormacionMateria.Visible = false;
            //TbSemestreMateria.Visible = false;
            LstSemestre.Visible = false;
            LstCaracteristicas.Visible = false;
            LstEtapaFormacion.Visible = false;
            LstAreaConocimiento.Visible = false;
            //TbAreaConocimientoMateria.Visible = false;
            TbPathPUAnoOficialMateria.Visible = false;
            TbPathPUAOficialMateria.Visible = false;
            //********Label materia*********************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            lbHoraClaseMateria.Visible = false;
            lbHoraTallerMateria.Visible = false;
            lbHoraLaboratorioMateria.Visible = false;
            lbHoraExtraClaseMateria.Visible = false;
            lbCreditosMateria.Visible = false;
            lbEtapaFormacionMateria.Visible = false;
            lbCaracteristicasFormacionMateria.Visible = false;
            lbSemestreMateria.Visible = false;
            lbAreaConocimientoMateria.Visible = false;
            lbPathPUAnoOficialMateria.Visible = false;
            lbPathPUAOficialMateria.Visible = false;
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
            //texbox no visibles**********************
            TbClaveMateria.Visible = false;
            TbNombreMateria.Visible = false;
            TbHoraClaseMateria.Visible = false;
            TbHoraTallerMateria.Visible = false;
            TbHoraLaboratorioMateria.Visible = false;
            TbHoraExtraClaseMateria.Visible = false;
            TbCreditosMateria.Visible = false;
            //TbEtapaFormacionMateria.Visible = false;
            //TbCaracteristicasFormacionMateria.Visible = false;
            //TbSemestreMateria.Visible = false;
            LstSemestre.Visible = false;
            LstCaracteristicas.Visible = false;
            LstEtapaFormacion.Visible = false;
            LstAreaConocimiento.Visible = false;
            //TbAreaConocimientoMateria.Visible = false;
            TbPathPUAnoOficialMateria.Visible = false;
            TbPathPUAOficialMateria.Visible = false;
            //********Label materia*********************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            lbHoraClaseMateria.Visible = false;
            lbHoraTallerMateria.Visible = false;
            lbHoraLaboratorioMateria.Visible = false;
            lbHoraExtraClaseMateria.Visible = false;
            lbCreditosMateria.Visible = false;
            lbEtapaFormacionMateria.Visible = false;
            lbCaracteristicasFormacionMateria.Visible = false;
            lbSemestreMateria.Visible = false;
            lbAreaConocimientoMateria.Visible = false;
            lbPathPUAnoOficialMateria.Visible = false;
            lbPathPUAOficialMateria.Visible = false;
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
            //texbox no visibles**********************
            TbClaveMateria.Visible = false;
            TbNombreMateria.Visible = false;
            TbHoraClaseMateria.Visible = false;
            TbHoraTallerMateria.Visible = false;
            TbHoraLaboratorioMateria.Visible = false;
            TbHoraExtraClaseMateria.Visible = false;
            TbCreditosMateria.Visible = false;
            //TbEtapaFormacionMateria.Visible = false;
            //TbCaracteristicasFormacionMateria.Visible = false;
            //TbSemestreMateria.Visible = false;
            LstSemestre.Visible = false;
            LstCaracteristicas.Visible=false;
            LstEtapaFormacion.Visible = false;
            LstAreaConocimiento.Visible = false;
            //TbAreaConocimientoMateria.Visible = false;
            TbPathPUAnoOficialMateria.Visible = false;
            TbPathPUAOficialMateria.Visible = false;
            //********Label materia*********************
            lbNombreMateria.Visible = false;
            lbClaveMateria.Visible = false;
            lbHoraClaseMateria.Visible = false;
            lbHoraTallerMateria.Visible = false;
            lbHoraLaboratorioMateria.Visible = false;
            lbHoraExtraClaseMateria.Visible = false;
            lbCreditosMateria.Visible = false;
            lbEtapaFormacionMateria.Visible = false;
            lbCaracteristicasFormacionMateria.Visible = false;
            lbSemestreMateria.Visible = false;
            lbAreaConocimientoMateria.Visible = false;
            lbPathPUAnoOficialMateria.Visible = false;
            lbPathPUAOficialMateria.Visible = false;
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
            LstEtapaFormacion.Visible = true;
            ListItem E;
            E = new ListItem("", "1");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("BASICA", "2");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("DISIPLINARIA", "3");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("TERMINAL", "4");
            LstEtapaFormacion.Items.Add(E);
            LstSemestre.Visible = true;
            ListItem i;
            i = new ListItem("", "1");
            LstSemestre.Items.Add(i);
            i = new ListItem("1.º", "2");
            LstSemestre.Items.Add(i);
            i = new ListItem("2.º", "3");
            LstSemestre.Items.Add(i);
            i = new ListItem("3.º", "4");
            LstSemestre.Items.Add(i);
            i = new ListItem("4.º", "5");
            LstSemestre.Items.Add(i);
            i = new ListItem("5.º", "6");
            LstSemestre.Items.Add(i);
            i = new ListItem("6.º", "7");
            LstSemestre.Items.Add(i);
            i = new ListItem("7.º", "8");
            LstSemestre.Items.Add(i);
            i = new ListItem("8.º", "9");
            LstSemestre.Items.Add(i);
            LstCaracteristicas.Visible = true;
            ListItem c;
            c = new ListItem("", "1");
            LstCaracteristicas.Items.Add(c);
            c = new ListItem("OBLIGATORIA", "2");
            LstCaracteristicas.Items.Add(c);
            c = new ListItem("OPTATIVA", "3");
            LstCaracteristicas.Items.Add(c);
            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdMateria.Value));
            ControlesOnOFF(false);
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            TbHoraClaseMateria.Visible = true;
            TbHoraTallerMateria.Visible = true;
            TbHoraLaboratorioMateria.Visible = true;
            TbHoraExtraClaseMateria.Visible = true;
            TbCreditosMateria.Visible = true;
            //TbEtapaFormacionMateria.Visible = true;
            //TbCaracteristicasFormacionMateria.Visible = true;
            //TbSemestreMateria.Visible = true;
            LstSemestre.Visible = true;
            LstCaracteristicas.Visible = true;
            LstEtapaFormacion.Visible = true;
            LstAreaConocimiento.Visible=true;
            //TbAreaConocimientoMateria.Visible = true;
            TbPathPUAnoOficialMateria.Visible = true;
            TbPathPUAOficialMateria.Visible = true;
            //********Label materia*********************
            lbNombreMateria.Visible = true;
            lbClaveMateria.Visible = true;
            lbHoraClaseMateria.Visible = true;
            lbHoraTallerMateria.Visible = true;
            lbHoraLaboratorioMateria.Visible = true;
            lbHoraExtraClaseMateria.Visible = true;
            lbCreditosMateria.Visible = true;
            lbEtapaFormacionMateria.Visible = true;
            lbCaracteristicasFormacionMateria.Visible = true;
            lbSemestreMateria.Visible = true;
            lbAreaConocimientoMateria.Visible = true;
            lbPathPUAnoOficialMateria.Visible = true;
            lbPathPUAOficialMateria.Visible = true;
            //****************************************
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

            LstSemestre.Visible = true;
            ListItem i;
            i = new ListItem("", "1");
            LstSemestre.Items.Add(i);
            i = new ListItem("1.º", "2");
            LstSemestre.Items.Add(i);
            i = new ListItem("2.º", "3");
            LstSemestre.Items.Add(i);
            i = new ListItem("3.º", "4");
            LstSemestre.Items.Add(i);
            i = new ListItem("4.º", "5");
            LstSemestre.Items.Add(i);
            i = new ListItem("5.º", "6");
            LstSemestre.Items.Add(i);
            i = new ListItem("6.º", "7");
            LstSemestre.Items.Add(i);
            i = new ListItem("7.º", "8");
            LstSemestre.Items.Add(i);
            i = new ListItem("8.º", "9");
            LstSemestre.Items.Add(i);
            LstCaracteristicas.Visible = true;
            ListItem c;
            c = new ListItem("", "1");
            LstCaracteristicas.Items.Add(c);
            c = new ListItem("OBLIGATORIA", "2");
            LstCaracteristicas.Items.Add(c);
            c = new ListItem("OPTATIVA", "3");
            LstCaracteristicas.Items.Add(c);
            LstEtapaFormacion.Visible = true;
            ListItem E;
            E = new ListItem("", "1");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("BASICA", "2");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("DISIPLINARIA", "3");
            LstEtapaFormacion.Items.Add(E);
            E = new ListItem("TERMINAL", "4");
            LstEtapaFormacion.Items.Add(E);
            LstAreaConocimiento.Visible = true;
            ListItem a;
            a = new ListItem("", "1");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS BASICAS", "2");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS SOCIALES Y HUMANIDADES", "3");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS ECONOMICAS ADMINISTRATIVAS", "4");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("CIENCIAS DE LA INGENIERIA", "5");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("INGENIERIA APLICADA", "6");
            LstAreaConocimiento.Items.Add(a);
            a = new ListItem("DISEÑO EN INGENIERIA", "7");
            LstAreaConocimiento.Items.Add(a);
            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdMateria.Value));
            ControlesOnOFF(true);
            PnlCapturaDatos.Visible = true;
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            TbClaveMateria.Visible = true;
            TbNombreMateria.Visible = true;
            TbHoraClaseMateria.Visible = true;
            TbHoraTallerMateria.Visible = true;
            TbHoraLaboratorioMateria.Visible = true;
            TbHoraExtraClaseMateria.Visible = true;
            TbCreditosMateria.Visible = true;
            //TbEtapaFormacionMateria.Visible = true;
            //TbCaracteristicasFormacionMateria.Visible = true;
            //TbSemestreMateria.Visible = true;
           
            /*TbAreaConocimientoMateria.Visible = true*/;
            TbPathPUAnoOficialMateria.Visible = true;
            TbPathPUAOficialMateria.Visible = true;
            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;
            //********Label materia*********************
            lbNombreMateria.Visible = true;
            lbClaveMateria.Visible = true;
            lbHoraClaseMateria.Visible = true;
            lbHoraTallerMateria.Visible = true;
            lbHoraLaboratorioMateria.Visible = true;
            lbHoraExtraClaseMateria.Visible = true;
            lbCreditosMateria.Visible = true;
            lbEtapaFormacionMateria.Visible = true;
            lbCaracteristicasFormacionMateria.Visible = true;
            lbSemestreMateria.Visible = true;
            lbAreaConocimientoMateria.Visible = true;
            lbPathPUAnoOficialMateria.Visible = true;
            lbPathPUAOficialMateria.Visible = true;
            //****************************************
        }
        
        #endregion
        protected void GrvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTituloAccion.Text = "AQUI SE ASIGNARA EL PLAN DE ESTUDIOS A LAS MATERIAS";
        }
        

    }

}