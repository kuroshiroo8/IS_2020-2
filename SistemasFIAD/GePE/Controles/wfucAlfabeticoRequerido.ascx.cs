using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GePE.Controles
{
  public partial class wfucAlfabeticoRequerido : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public String Text
    {
      get { return TbAlfabetico.Text.Trim(); }
      set { TbAlfabetico.Text = value; }
    }

    public bool Enabled
    {
      set { TbAlfabetico.Enabled = value; }
    }
  }
}