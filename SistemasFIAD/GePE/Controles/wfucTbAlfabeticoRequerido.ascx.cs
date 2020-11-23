using System;

namespace Presentacion.Controles
{
    public partial class _Ganancia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String Text
        {
            get { return TbAlfabeticoRequerido.Text.Trim(); }
            set { TbAlfabeticoRequerido.Text = value; }
        }

        public bool Enabled
        {
            set { TbAlfabeticoRequerido.Enabled = value; }
        }
    }
}