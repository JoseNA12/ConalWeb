using ConalWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConalWeb.Views
{
    public partial class frmChat : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombreComunidad"] != null)
            {
                /*Label_comunidad.Text = Session["g"].ToString();
                Label_nombreCuenta.Text = ClaseSingleton.USUARIO_ACTUAL.getNombre();

                g.Value = Session["g"].ToString();
                name.Value = ClaseSingleton.USUARIO_ACTUAL.getNombre();*/
                nombreComunidad.Value = Session["nombreComunidad"].ToString();
                nombreUsuario.Value = ClaseSingleton.USUARIO_ACTUAL.getNombre();

            }
        }
    }
}