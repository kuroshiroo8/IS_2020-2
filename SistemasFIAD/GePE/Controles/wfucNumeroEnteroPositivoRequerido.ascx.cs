using System;

namespace Presentacion.Controles
{
    public partial class efucNumeroEnteroPositivoReq : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String Text
        {
            get { return TbNumeroEnteroPositivoRequerido.Text.Trim(); }
            set { TbNumeroEnteroPositivoRequerido.Text = value; }
        }

        public bool Enabled
        {
            set { TbNumeroEnteroPositivoRequerido.Enabled = value; }
        }
    }
}