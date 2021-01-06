using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace GePE.Materias
{
    public partial class GestionMaterias : System.Web.UI.Page
    {
        string MateriaEstatus = "";

        N_Materias NM = new N_Materias();
        N_PlanEstudioMateria NPEM = new N_PlanEstudioMateria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializaControles();
            }
                

            if (Convert.ToString(Session["TipoUsuario"]) == "ADMINISTRADOR")
            {

            }
            else if (Convert.ToString(Session["TipoUsuario"]) == "CAPTURISTA")
            {

            }
            else if (Convert.ToString(Session["TipoUsuario"]) == "INTERNO")
            {

            }
            else if (Convert.ToString(Session["TipoUsuario"]) == "")
            {
                GrvMateria.Columns[8].Visible = false;
                GrvMateria.Columns[10].Visible = false;
                GrvMateria.Columns[11].Visible = false;

                BtnMnuNuevo.Visible = false;

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

            lbPathPUA.Visible = false;
            FuPathPUA.Visible = false;
            lbStatusPathPUA.Visible = false;

            lbPathPUAnoOficial.Visible = false;
            FuPathPUAnoOficial.Visible = false;
            lbStatusPathPUAnoOficial.Visible = false;

            PnlCapturaDatos.Visible = false;
            PnlGrvMateria.Visible = false;
        }
        protected void ControlesClear()
        {
            //Clear Labels
            lblNombreAccion.Text = string.Empty;
            lblTituloAccion.Text = string.Empty;

            //Clear Textbox
            TbCriterioBusqueda.Text = string.Empty;

            TbClaveMateria.Text = string.Empty;
            TbNombreMateria.Text = string.Empty;
            TbHC.Text = string.Empty;
            TbHL.Text = string.Empty;
            TbHT.Text = string.Empty;
            TbHE.Text = string.Empty;
            TbHPP.Text = string.Empty;
            TbCR.Text = string.Empty;

            //Clear Fileupload FuPathPUA
            FuPathPUA.Dispose();
            lbStatusPathPUA.Text = string.Empty;

            //Clear Fileupload FuPathPUAnoOficial
            FuPathPUAnoOficial.Dispose();
            lbStatusPathPUAnoOficial.Text = string.Empty;

            lbStatusCR.Text = string.Empty;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            //Enabled Labels
            lblNombreAccion.Enabled = TrueOrFalse;
            lblTituloAccion.Enabled = TrueOrFalse;

            lbClaveMateria.Enabled = TrueOrFalse;
            lbNombreMateria.Enabled = TrueOrFalse;
            lbHC.Enabled = TrueOrFalse;
            lbHL.Enabled = TrueOrFalse;
            lbHT.Enabled = TrueOrFalse;
            lbHE.Enabled = TrueOrFalse;
            lbHPP.Enabled = TrueOrFalse;
            lbCR.Enabled = TrueOrFalse;

            //Enabled Textbox
            TbClaveMateria.Enabled = TrueOrFalse;
            TbNombreMateria.Enabled = TrueOrFalse;
            TbHC.Enabled = TrueOrFalse;
            TbHL.Enabled = TrueOrFalse;
            TbHT.Enabled = TrueOrFalse;
            TbHE.Enabled = TrueOrFalse;
            TbHPP.Enabled = TrueOrFalse;
            TbCR.Enabled = TrueOrFalse;

            //Enabled Fileupload PathPUA
            lbPathPUA.Enabled = TrueOrFalse;
            FuPathPUA.Enabled = TrueOrFalse;
            lbStatusPathPUA.Enabled = TrueOrFalse;

            //Enabled Fileupload PathPUAnoOficial
            lbPathPUAnoOficial.Enabled = TrueOrFalse;
            FuPathPUAnoOficial.Enabled = TrueOrFalse;
            lbStatusPathPUAnoOficial.Enabled = TrueOrFalse;

            lbStatusCR.Enabled = TrueOrFalse;
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

            //Visible TextBox
            TbClaveMateria.Visible = TrueOrFalse;
            TbNombreMateria.Visible = TrueOrFalse;
            TbHC.Visible = TrueOrFalse;
            TbHL.Visible = TrueOrFalse;
            TbHT.Visible = TrueOrFalse;
            TbHE.Visible = TrueOrFalse;
            TbHPP.Visible = TrueOrFalse;
            TbCR.Visible = TrueOrFalse;

            //El TextBox de CR se hace no editable
            TbCR.Enabled = false;

            //Hacer visible el PathPUA
            lbPathPUA.Visible = TrueOrFalse;
            FuPathPUA.Visible = TrueOrFalse;
            lbStatusPathPUA.Visible = TrueOrFalse;

            //Hacer visible el PathPUAnoOficial
            lbPathPUAnoOficial.Visible = TrueOrFalse;
            FuPathPUAnoOficial.Visible = TrueOrFalse;
            lbStatusPathPUAnoOficial.Visible = TrueOrFalse;

            lbStatusCR.Visible = TrueOrFalse;
        }
        protected int ActualizarCR()
        {
            if (TbHC.Text != "" &&
                TbHL.Text != "" &&
                TbHT.Text != "" &&
                TbHE.Text != "" &&
                TbHPP.Text != "")
            {
                int CR = 0;
                CR = (Convert.ToInt32(TbHC.Text) * 2)
                    + (Convert.ToInt32(TbHL.Text) * 1)
                    + (Convert.ToInt32(TbHT.Text) * 1)
                    + (Convert.ToInt32(TbHE.Text) * 0)
                    + (Convert.ToInt32(TbHPP.Text) * 1);
                TbCR.Text = Convert.ToString(CR);
                return 0;
            }
            else
            {
                Console.WriteLine("Por favor llena los campos de horas");
                return 1;
            }

        }
        protected int AgregarPathPUA()
        {
            //Especifique la ruta en el servidor para guardar el archivo subido.
            string savePath = @"../FilesSection/";
            //string savePath = @"../puaOFICIAL/";
            //Antes de intentar guardar el archivo, compruebe que el control FileUpload contiene un archivo.
            if (FuPathPUA.HasFile)
            {
                // Consigue el nombre del archivo para subirlo.
                string fileName = Server.HtmlEncode(FuPathPUA.FileName);
                // Obtener la extensión del archivo subido.
                string extension = System.IO.Path.GetExtension(fileName);
                // Obtener el tamaño en bytes del archivo a subir.
                int fileSize = FuPathPUA.PostedFile.ContentLength;
                //Permita que sólo se suban archivos con extensiones .doc o .xls.
                if (extension == ".pdf")
                {
                    // Permitir sólo archivos de menos de 4,000,000 de bytes (aproximadamente 4 MB) para ser subidos.
                    if (fileSize < 4000000)
                    {
                        // Añade el nombre del archivo subido a la ruta.
                        savePath += fileName;
                        //Llama al método SaveAs para guardar el archivo cargado en la ruta especificada.
                        //Si ya existe un archivo con el mismo nombre en la ruta especificada, el archivo cargado lo sobrescribe.
                        FuPathPUA.SaveAs(Server.MapPath("../FilesSection/" + FuPathPUA.FileName));
                        //FuPathPUA.SaveAs(Server.MapPath("../puaOFICIAL/" + FuPathPUA.FileName));
                        // Notificar al usuario que el archivo fue subido con éxito.
                        lbStatusPathPUA.Text = "~/FilesSection/" + FuPathPUA.FileName;
                        //lbStatusPathPUA.Text = "../puaOFICIAL/" + FuPathPUA.FileName;
                        return 0;
                    }
                    else
                    {
                        // Notificar al usuario por qué su archivo no fue subido.
                        lbStatusPathPUA.Text = "Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                        return 1;
                    }
                }
                else
                {
                    // Notificar al usuario por qué su archivo no fue subido.
                    lbStatusPathPUA.Text = "Tu archivo no fue subido porque no tiene una extensión .pdf";
                    return 2;
                }
            }
            else
            {
                if (lbStatusPathPUA.Text != "~/FilesSection/PUAnoexistente.pdf")
                //if (lbStatusPathPUA.Text != "../puaOFICIAL/PUAnoexistente.pdf")
                {

                }
                else
                {
                    lbStatusPathPUA.Text = "~/FilesSection/PUAnoexistente.pdf";
                    //lbStatusPathPUA.Text = "../puaOFICIAL/PUAnoexistente.pdf";
                }
                return 3;
            }
        }
        protected int AgregarPathPUAnoOficial()
        {
            //Especifique la ruta en el servidor para guardar el archivo subido.
            string savePath = @"../FilesSection/";
            //string savePath = @"../puaNO/";
            //Antes de intentar guardar el archivo, compruebe que el control FileUpload contiene un archivo.
            if (FuPathPUAnoOficial.HasFile)
            {
                // Consigue el nombre del archivo para subirlo.
                string fileName = Server.HtmlEncode(FuPathPUAnoOficial.FileName);
                // Obtener la extensión del archivo subido.
                string extension = System.IO.Path.GetExtension(fileName);
                // Obtener el tamaño en bytes del archivo a subir.
                int fileSize = FuPathPUAnoOficial.PostedFile.ContentLength;
                //Permita que sólo se suban archivos con extensiones .doc o .xls.
                if (extension == ".pdf")
                {
                    // Permitir sólo archivos de menos de 4,000,000 de bytes (aproximadamente 4 MB) para ser subidos.
                    if (fileSize < 4000000)
                    {
                        // Añade el nombre del archivo subido a la ruta.
                        savePath += fileName;
                        //Llama al método SaveAs para guardar el archivo cargado en la ruta especificada.
                        //Si ya existe un archivo con el mismo nombre en la ruta especificada, el archivo cargado lo sobrescribe.
                        //FuPathPUAnoOficial.SaveAs(savePath);
                        FuPathPUAnoOficial.SaveAs(Server.MapPath("../FilesSection/" + FuPathPUAnoOficial.FileName));
                        //FuPathPUAnoOficial.SaveAs(Server.MapPath("../puaNO/" + FuPathPUAnoOficial.FileName));
                        // Notificar al usuario que el archivo fue subido con éxito.
                        lbStatusPathPUAnoOficial.Text = "~/FilesSection/" + FuPathPUAnoOficial.FileName;
                        //lbStatusPathPUAnoOficial.Text = "../puaNO/" + FuPathPUAnoOficial.FileName;
                        //lbStatusPathPUAnoOficial.Text = "Tu archivo fue subido con éxito.";
                        return 0;
                    }
                    else
                    {
                        // Notificar al usuario por qué su archivo no fue subido.
                        lbStatusPathPUAnoOficial.Text = "Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                        return 1;
                    }
                }
                else
                {
                    // Notificar al usuario por qué su archivo no fue subido.
                    lbStatusPathPUAnoOficial.Text = "Tu archivo no fue subido porque no tiene una extensión .pdf";
                    return 2;
                }
            }
            else
            {
                if (lbStatusPathPUAnoOficial.Text != "~/FilesSection/PUAnoexistente.pdf")
                //if (lbStatusPathPUAnoOficial.Text != "../puaNO/PUAnoexistente.pdf")
                {

                }
                else
                {
                    lbStatusPathPUAnoOficial.Text = "~/FilesSection/PUAnoexistente.pdf";
                    //lbStatusPathPUAnoOficial.Text = "../puaNO/PUAnoexistente.pdf";
                }
                return 3;
            }
        }
        #endregion

        #region Objeto Cliente
        protected E_Materias ControlesWebForm_ObjetoEntidad()
        {
            //agrega los datos a la base de datos
            E_Materias Materia = new E_Materias()
            {
                ClaveMateria = TbClaveMateria.Text,
                NombreMateria = TbNombreMateria.Text,
                HC = Convert.ToInt32(TbHC.Text),
                HL = Convert.ToInt32(TbHL.Text),
                HT = Convert.ToInt32(TbHT.Text),
                HE = Convert.ToInt32(TbHE.Text),
                HPP = Convert.ToInt32(TbHPP.Text),
                CR = (Convert.ToInt32(TbHC.Text) * 2) +
                    (Convert.ToInt32(TbHL.Text) * 1) +
                    (Convert.ToInt32(TbHT.Text) * 1) +
                    (Convert.ToInt32(TbHE.Text) * 0) +
                    (Convert.ToInt32(TbHPP.Text) * 1),
                //EstadoMateria = cbEstadoMateria.Checked,

                PathPUA = lbStatusPathPUA.Text,
                PathPUAnoOficial = lbStatusPathPUAnoOficial.Text,
                Estatus = MateriaEstatus
            };
            return Materia;
        }
        protected void ObjetoEntidad_ControlesWebForm(int IdMateria)
        {
            //Poner los datos de la base de datos en los objetos
            E_Materias Materia = NM.BuscaMateriasPorId(IdMateria);

            TbClaveMateria.Text = Materia.ClaveMateria.Trim();
            TbNombreMateria.Text = Materia.NombreMateria.Trim();
            TbHC.Text = Convert.ToString(Materia.HC);
            TbHL.Text = Convert.ToString(Materia.HL);
            TbHT.Text = Convert.ToString(Materia.HT);
            TbHE.Text = Convert.ToString(Materia.HE);
            TbHPP.Text = Convert.ToString(Materia.HPP);
            TbCR.Text = Convert.ToString(Materia.CR);
            //cbEstadoMateria.Checked = Materia.EstadoMateria;
            lbStatusPathPUA.Text = Materia.PathPUA;
            lbStatusPathPUAnoOficial.Text = Materia.PathPUAnoOficial;
            MateriaEstatus = Materia.Estatus;
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
            //GrvMateria.DataBind();
            //PnlGrvMateria.Visible = true;

            if (NM.LstMaterias().Count.Equals(0))
            {
                InicializaControles();
                lblNombreAccion.Text = "No se encontraron materias para listar";
            }
            else
            {
                GrvMateria.DataBind();
                PnlGrvMateria.Visible = true;
            }

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
                    FuPathPUA.Enabled = false;
                    FuPathPUAnoOficial.Enabled = false;
                    //cbEstadoMateria.Enabled = false;

                    hfIdMateria.Value = LstMateria[0].IdMateria.ToString();
                    ObjetoEntidad_ControlesWebForm(Convert.ToInt32(hfIdMateria.Value));

                    PnlCapturaDatos.Visible = true;

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
            int RespuestaCR = 0;
            int RespuestaFuPathPUA = 0;
            int RespuestaFuPathPUAnoOficial = 0;
            int SumaRespuestaCR = 0;
            int SumaRespuestaFuPathPUA = 0;
            int SumaRespuestaFuPathPUAnoOficial = 0;

            RespuestaCR = ActualizarCR();
            if (RespuestaCR == 0)
            {
                SumaRespuestaCR = 0;
            }
            else if (RespuestaCR == 1)
            {
                lbStatusCR.Text = "Por favor llena los campos de horas.";
                SumaRespuestaCR = 1;
                lblTituloAccion.Text = "Error: Por favor llena los campos de horas.";
                return;
            }

            RespuestaFuPathPUA = AgregarPathPUA();
            if (RespuestaFuPathPUA == 0)
            {
                SumaRespuestaFuPathPUA = 0;
            }
            else if (RespuestaFuPathPUA == 1)
            {
                lbStatusPathPUA.Text = "Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                SumaRespuestaFuPathPUA = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                FuPathPUA.Dispose();
                FuPathPUA.PostedFile.InputStream.Dispose();
                FuPathPUA.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUA == 2)
            {
                lbStatusPathPUA.Text = "Tu archivo no fue subido porque no tiene una extensión .pdf";
                SumaRespuestaFuPathPUA = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque no tiene una extensión .pdf";
                FuPathPUA.Dispose();
                FuPathPUA.PostedFile.InputStream.Dispose();
                FuPathPUA.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUA == 3)
            {

                lbStatusPathPUA.Text = "~/FilesSection/PUAnoexistente.pdf";
                //lbStatusPathPUA.Text = "../puaOFICIAL/PUAnoexistente.pdf";

            }

            RespuestaFuPathPUAnoOficial = AgregarPathPUAnoOficial();
            if (RespuestaFuPathPUAnoOficial == 0)
            {
                SumaRespuestaFuPathPUAnoOficial = 0;
            }
            else if (RespuestaFuPathPUAnoOficial == 1)
            {
                lbStatusPathPUAnoOficial.Text = "Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                SumaRespuestaFuPathPUAnoOficial = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                FuPathPUAnoOficial.Dispose();
                FuPathPUAnoOficial.PostedFile.InputStream.Dispose();
                FuPathPUAnoOficial.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUAnoOficial == 2)
            {
                lbStatusPathPUAnoOficial.Text = "Tu archivo no fue subido porque no tiene una extensión .pdf";
                SumaRespuestaFuPathPUAnoOficial = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque no tiene una extensión .pdf";
                FuPathPUAnoOficial.Dispose();
                FuPathPUAnoOficial.PostedFile.InputStream.Dispose();
                FuPathPUAnoOficial.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUAnoOficial == 3)
            {

                lbStatusPathPUAnoOficial.Text = "~/FilesSection/PUAnoexistente.pdf";
                //lbStatusPathPUAnoOficial.Text = "../puaNO/PUAnoexistente.pdf";
            }

            if (SumaRespuestaCR == 0 && SumaRespuestaFuPathPUA == 0 && SumaRespuestaFuPathPUAnoOficial == 0)
            {
                MateriaEstatus = "EN ESPERA";

                string R = NM.InsertaMaterias(ControlesWebForm_ObjetoEntidad());
                lblTituloAccion.Text = R;

                //Aqui se hacen no visible los Label, TextBox y el CheckBox
                VisibleOnOFF(false);

                BtnGrabar.Visible = false;
                BtnCancelar.Visible = false;
                BtnAceptar.Visible = true;

                MateriaEstatus = "";

                if (R.Contains("Las acciones se completaron con exito"))/*"Exito"*/
                {
                    lblTituloAccion.Text = R;
                    InicializaControles();
                }
            }
            else
            {
                lblTituloAccion.Text = "Error";
                FuPathPUA.Dispose();
                FuPathPUA.PostedFile.InputStream.Dispose();
                FuPathPUA.Attributes.Clear();
                FuPathPUAnoOficial.Dispose();
                FuPathPUAnoOficial.PostedFile.InputStream.Dispose();
                FuPathPUAnoOficial.Attributes.Clear();
                return;
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
            int RespuestaCR = 0;
            int RespuestaFuPathPUA = 0;
            int RespuestaFuPathPUAnoOficial = 0;
            int SumaRespuestaCR = 0;
            int SumaRespuestaFuPathPUA = 0;
            int SumaRespuestaFuPathPUAnoOficial = 0;

            RespuestaCR = ActualizarCR();
            if (RespuestaCR == 0)
            {
                SumaRespuestaCR = 0;
            }
            else if (RespuestaCR == 1)
            {
                lbStatusCR.Text = "Por favor llena los campos de horas.";
                SumaRespuestaCR = 1;
                lblTituloAccion.Text = "Error: Por favor llena los campos de horas.";
                return;
            }

            RespuestaFuPathPUA = AgregarPathPUA();
            if (RespuestaFuPathPUA == 0)
            {
                SumaRespuestaFuPathPUA = 0;
            }
            else if (RespuestaFuPathPUA == 1)
            {
                lbStatusPathPUA.Text = "Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                SumaRespuestaFuPathPUA = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                FuPathPUA.Dispose();
                FuPathPUA.PostedFile.InputStream.Dispose();
                FuPathPUA.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUA == 2)
            {
                lbStatusPathPUA.Text = "Tu archivo no fue subido porque no tiene una extensión .pdf";
                SumaRespuestaFuPathPUA = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque no tiene una extensión .pdf";
                FuPathPUA.Dispose();
                FuPathPUA.PostedFile.InputStream.Dispose();
                FuPathPUA.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUA == 3)
            {
                //Si lo que esta en la base de datos es diferente a ~/FilesSection/PUAnoexistente.pdf
                //no hagas nada, quedate con ese dato.
                if (lbStatusPathPUA.Text != "~/FilesSection/PUAnoexistente.pdf")
                //if (lbStatusPathPUA.Text != "../puaOFICIAL/PUAnoexistente.pdf")
                {

                }
                else
                {
                    lbStatusPathPUA.Text = "~/FilesSection/PUAnoexistente.pdf";
                    //lbStatusPathPUA.Text = "../puaOFICIAL/PUAnoexistente.pdf";
                }
            }

            RespuestaFuPathPUAnoOficial = AgregarPathPUAnoOficial();
            if (RespuestaFuPathPUA == 0)
            {
                SumaRespuestaFuPathPUAnoOficial = 0;
            }
            else if (RespuestaFuPathPUAnoOficial == 1)
            {
                lbStatusPathPUAnoOficial.Text = "Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                SumaRespuestaFuPathPUAnoOficial = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque excede el límite de tamaño de 4 MB.";
                FuPathPUAnoOficial.Dispose();
                FuPathPUAnoOficial.PostedFile.InputStream.Dispose();
                FuPathPUAnoOficial.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUAnoOficial == 2)
            {
                lbStatusPathPUAnoOficial.Text = "Tu archivo no fue subido porque no tiene una extensión .pdf";
                SumaRespuestaFuPathPUAnoOficial = 1;
                lblTituloAccion.Text = "Error: Tu archivo no fue subido porque no tiene una extensión .pdf";
                FuPathPUAnoOficial.Dispose();
                FuPathPUAnoOficial.PostedFile.InputStream.Dispose();
                FuPathPUAnoOficial.Attributes.Clear();
                return;
            }
            else if (RespuestaFuPathPUAnoOficial == 3)
            {
                //Si lo que esta en la base de datos es diferente a ~/FilesSection/PUAnoexistente.pdf
                //no hagas nada, quedate con ese dato.
                if (lbStatusPathPUAnoOficial.Text != "~/FilesSection/PUAnoexistente.pdf")
                //if (lbStatusPathPUAnoOficial.Text != "../puaNO/PUAnoexistente.pdf")
                {

                }
                else
                {
                    lbStatusPathPUAnoOficial.Text = "~/FilesSection/PUAnoexistente.pdf";
                    //lbStatusPathPUAnoOficial.Text = "../puaNO/PUAnoexistente.pdf";
                }
            }

            if (SumaRespuestaCR == 0 && SumaRespuestaFuPathPUA == 0 && SumaRespuestaFuPathPUAnoOficial == 0)
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
                    lblTituloAccion.Text = R;
                    InicializaControles();
                }
            }
            else
            {
                lblTituloAccion.Text = "Error";
                FuPathPUA.Dispose();
                FuPathPUA.PostedFile.InputStream.Dispose();
                FuPathPUA.Attributes.Clear();
                FuPathPUAnoOficial.Dispose();
                FuPathPUAnoOficial.PostedFile.InputStream.Dispose();
                FuPathPUAnoOficial.Attributes.Clear();
                return;
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

            TbCR.Enabled = false;
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

            //aqui se hace la validacion de estatus de carrera*****************************************************************************
            String str = GrvMateria.Rows[e.RowIndex].Cells[1].Text;
            
            List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMateriasPorMateria(str);
            foreach (var item in LstPlanEstudioMateria)
            {
                if (item != null)
                {
                    //si se puede modificar
                    lblTituloAccion.Text = "Materia asociada a plan de estudio con nombre \"" + item.NombrePlanEstudio + "\" y clave \"" + item.ClavePlanEstudio + "\", no se puede borrar.";

                    PnlCapturaDatos.Visible = true;

                    //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                    VisibleOnOFF(false);

                    BtnModificar.Visible = false;
                    BtnCancelar.Visible = false;
                    BtnAceptar.Visible = true;

                    return;
                }
            }

            List<E_Materias> LstMaterias = NM.BuscaMateria(str);

            foreach (var item in LstMaterias)
            {
                if (item != null)
                {
                    //Response.Write("<script language=javascript>alert(' Si encontro carreras');</script>");
                    if (item.ClaveMateria == GrvMateria.Rows[e.RowIndex].Cells[0].Text)
                    {
                        //Response.Write("<script language=javascript>alert(' Si encontro una carrera con la misma clave');</script>");

                        if (item.Estatus == "EN REVISION")
                        {
                            //no se puede borrar
                            lblTituloAccion.Text = "Materia asociada a plan de estudio con estatus \"EN REVISION\", no se puede borrar.";

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
                            lblTituloAccion.Text = "Materia asociada a plan de estudio con estatus \"EN PUBLICADO\", no se puede borrar.";

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
                            lblTituloAccion.Text = "Materia asociada a plan de estudio con estatus \"EN APROBADO\", no se puede borrar.";

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

            //aqui se hace la validacion de estatus de carrera*****************************************************************************
            String str = GrvMateria.Rows[e.NewEditIndex].Cells[1].Text;

            List<E_PlanEstudioMateria> LstPlanEstudioMateria = NPEM.BuscaPlanEstudioMateriasPorMateria(str);
            foreach (var item in LstPlanEstudioMateria)
            {
                if (item != null)
                {
                    //si se puede modificar
                    lblTituloAccion.Text = "Materia asociada a plan de estudio con nombre \"" + item.NombrePlanEstudio + "\" y clave \"" + item.ClavePlanEstudio + "\", no se puede modificar.";

                    PnlCapturaDatos.Visible = true;

                    //Aqui se ponen no visibles los Label, TextBox y el CheckBox
                    VisibleOnOFF(false);

                    BtnModificar.Visible = false;
                    BtnCancelar.Visible = false;
                    BtnAceptar.Visible = true;

                    return;
                }
            }

            List<E_Materias> LstMaterias = NM.BuscaMateria(str);

            foreach (var item in LstMaterias)
            {
                if (item != null)
                {
                    if (item.ClaveMateria == GrvMateria.Rows[e.NewEditIndex].Cells[0].Text)
                    {
                        if (item.Estatus == "EN REVISION")
                        {
                            //si se puede modificar
                            lblTituloAccion.Text = "Materia asociada a plan de estudio con estatus \"EN REVISION\", no se puede modificar.";

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
                                lblTituloAccion.Text = "Materia asociada a plan de estudio con estatus \"EN PUBLICADO\", no se puede modificar.";

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
                            lblTituloAccion.Text = "Materia asociada a plan de estudio con estatus \"EN APROBADO\", no se puede modificar.";

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