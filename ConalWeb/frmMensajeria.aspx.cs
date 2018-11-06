using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConalWeb.Models;
using ConalWeb.Controllers;

namespace ConalWeb
{
    public partial class frmMensajeriaCliente : System.Web.UI.Page
    {
        private List<Comunidad> comunidades = new List<Comunidad>();
        private Controlador controlador = new Controlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session[ClaseSingleton.sessionKey_usuarioID] != null) // evitar saltarse el inicio de sesion
            {
                cargarDatos();
            }
            else
            {
                Response.Redirect("Views/frmIniciarSesion.aspx", false);
            }
        }

        protected void btnIngresarSalaChat_Click(object sender, EventArgs e)
        {
            if (DropDownList_comunidades.SelectedItem != null)
            {
                HttpContext.Current.Session[ClaseSingleton.sessionKey_comunidad] = DropDownList_comunidades.SelectedItem.Value;
                Response.Redirect("frmChat.aspx", false);
            }
            else
            {
                Response.Write("<script>alert('Debe seleccionar una comunidad o grupo.')</script>");
            }
            
        }

        private void cargarDatos()
        {
            comunidades = controlador.cargarComunidadesDeUsuario();

            foreach (Comunidad i in comunidades)
            {
                ListItem item = new ListItem(i.getNombre(), i.getNombre(), true);
                DropDownList_comunidades.Items.Add(item);
            }
        }
    }
}