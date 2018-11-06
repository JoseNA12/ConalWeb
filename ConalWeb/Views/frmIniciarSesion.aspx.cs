using ConalWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace ConalWeb.Views
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        private string usuario;
        private string contrasena;

        protected void Page_Load(object sender, EventArgs e)
        {
            //VALIDAR
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            this.usuario = txtUsuario.Text;
            this.contrasena = txtContrasena.Text;

            Controlador controlador = new Controlador();

            if (controlador.iniciarSesion(usuario, contrasena))
            {
                Session["USUARIO_ACTUAL"] = ClaseSingleton.USUARIO_ACTUAL.getNombre();
                Response.Redirect("frmBoletines.aspx", false);
            }
            else
            {
                Response.Write("<script>alert('Nombre de usuario o contrasena incorrecta.')</script>");
            }
           
        }
    }
}