using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConalWeb
{
    public partial class frmMensajeriaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresarSalaChat_Click(object sender, EventArgs e)
        {
            Session["g"] = DropDownList_comunidades.SelectedItem.Value;
            Response.Redirect("frmChat.aspx", false);
        }
    }
}