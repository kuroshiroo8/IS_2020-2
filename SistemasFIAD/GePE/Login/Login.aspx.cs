using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GePE.Login
{
    public partial class Login : System.Web.UI.Page
    {
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
            
            
        }
        protected void ControlesClear()
        {
            cbAlumno.Checked = false;
            cbAdministrador.Checked = false;
            cbCapturista.Checked = false;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
           
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
           
        }
        #endregion

        private void Check_selected(object sender, EventArgs e)//cuando se selecciona algun checkbox 
            //de tipo de usuario actualizara los demas checkbox
        {
            if (cbAlumno.Checked)
            {
                cbAdministrador.Checked = false;
                cbCapturista.Checked = false;
            }
            if (cbAdministrador.Checked)
            {
                cbAlumno.Checked = false;
                cbCapturista.Checked = false;
            }
            if (cbCapturista.Checked)
            {
                cbAdministrador.Checked = false;
                cbAlumno.Checked = false;
            }
        }

    }
}