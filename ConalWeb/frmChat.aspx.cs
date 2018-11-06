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
            if (HttpContext.Current.Session["NOMBRE_COMUNIDAD"].ToString() != null)
            {
                /*Label_comunidad.Text = Session["g"].ToString();
                Label_nombreCuenta.Text = ClaseSingleton.USUARIO_ACTUAL.getNombre();

                g.Value = Session["g"].ToString();
                name.Value = ClaseSingleton.USUARIO_ACTUAL.getNombre();*/
                nombreComunidad.Value = HttpContext.Current.Session["NOMBRE_COMUNIDAD"].ToString();
                nombreUsuario.Value = HttpContext.Current.Session["USUARIO_ACTUAL_NOMBRE"].ToString() + HttpContext.Current.Session["USUARIO_ACTUAL_ID"].ToString();

            }
        }
    }
}