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
            cargarDatos();
        }

        protected void btnIngresarSalaChat_Click(object sender, EventArgs e)
        {
            Session["nombreComunidad"] = DropDownList_comunidades.SelectedItem.Value;
            Response.Redirect("frmChat.aspx", false);
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