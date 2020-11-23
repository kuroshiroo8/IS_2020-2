using System;

namespace GePE.Controles
{
    public partial class wfucAlfabeticoRequerido : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String Text
        {
            get { return TbAlfanumericoRequerido.Text.Trim(); }
            set { TbAlfanumericoRequerido.Text = value; }
        }

        public bool Enabled
        {
            set { TbAlfanumericoRequerido.Enabled = value; }
        }
    }
}