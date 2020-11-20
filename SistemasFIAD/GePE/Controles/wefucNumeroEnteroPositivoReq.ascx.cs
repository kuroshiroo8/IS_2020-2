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
      get { return TbNumeroEnteroPositivoReq.Text.Trim(); }
      set { TbNumeroEnteroPositivoReq.Text = value; }
    }

    public bool Enabled
    {
      set { TbNumeroEnteroPositivoReq.Enabled = value; }
    }
  }
}