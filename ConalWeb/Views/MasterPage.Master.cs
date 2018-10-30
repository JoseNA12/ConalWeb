using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConalWeb.Views
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnMensajeria_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMensajeria.aspx");
        }

        protected void btnChat_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMensajeria.aspx");
        }
    }
}