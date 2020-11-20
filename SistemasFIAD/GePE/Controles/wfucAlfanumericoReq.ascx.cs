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
      get { return TbAlfaNumerico.Text.Trim(); }
      set { TbAlfaNumerico.Text = value; }
    }

    public bool Enabled
    {
      set { TbAlfaNumerico.Enabled = value; }
    }
  }
}