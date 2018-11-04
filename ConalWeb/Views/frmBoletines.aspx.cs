using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ConalWeb.Models;
using ConalWeb.Controllers;

namespace ConalWeb
{
    public partial class PanelBoletines : System.Web.UI.Page
    {
        private List<Boletin> boletines = new List<Boletin>();
        private Controlador controlador = new Controlador();
        //true = boletines; false = reuniones

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTablaBoletines(false, false); // false
        }

        private void cargarDatos(Boolean busca)
        {
            if (!busca)
            {
                boletines = controlador.cargarBoletines();
            }
            else
            {
                boletines = controlador.cargarBoletines_por_busqueda(txtBuscar.Text.ToString());
            }
            
        }

        private void llenarTablaBoletines(bool filtro, bool busca)
        {
            //carga los datos de los boletines
            cargarDatos(busca);

            if (boletines.Count == 0)
            {
                //divResultadosBusqueda.Visible = true;
                //return;
            }

            //limpia la tabla para meter los nuevos valores
            tblBoletines.Rows.Clear();

            //comienza a crear la tabla
            TableRow row = new TableRow();
            TableCell campo = new TableCell();

            foreach (Boletin boletin in boletines)
            {
                row = new TableRow();

                //AGREGA EL MAPA DEL EVENTO
                campo = new TableCell();
                Image mapa = new Image();
                mapa.ImageUrl = boletin.LinkImagenGPS;
                campo.Controls.Add(mapa);
                campo.Attributes.Add("Style", "width: 30%");
                row.Cells.Add(campo);

                //AGREGA LA INFORMACION DEL EVENTO
                campo = new TableCell();
                campo.Text = "<b><h3>" + boletin.Titular + "</h3></b> " + boletin.Provincia + "<br/>" +
                    "<i>" + boletin.Autor + " " + boletin.Fecha + " " + boletin.Hora + "</i><br/><br/>" +
                    "<b>Sospechosos: </b>" + boletin.Sospechosos + "<br/>" +
                    "<b>Armas usadas: </b>" + boletin.ArmasSosp + "<br/>" +
                    "<b>Vehículos usados: </b>" + boletin.VehiculosSosp;
                campo.Attributes.Add("Style", "width: 40%");
                row.Cells.Add(campo);

                //AGREGA EL BOTON
                Button button = new Button();
                button.Text = "Ver mapa";
                button.CssClass = "btn btn-default";
                button.Click += delegate
                    {
                        //Response.Write("<script> window.open('" + boletin.LinkImagenGPS + "','_blank'); </script>");
                        Page.ClientScript.RegisterStartupScript(
                        this.GetType(), "OpenWindow", "window.open('"+ boletin.LinkImagenGPS + "','_newtab');", true);
                    };
                campo = new TableCell();
                campo.Controls.Add(button);

                //si es el autor puede eliminarlos
                if (boletin.AutorInfo.getId() == ClaseSingleton.USUARIO_ACTUAL.getId())
                {
                    Button buttonEliminar = new Button();
                    buttonEliminar.Click += delegate
                        {
                            btnEliminarBoletin_Click(boletin.IdBoletin);
                            // (sender, EventArgs) => { btnEliminarBoletin_Click(sender, EventArgs, boletin.IdBoletin); };
                        };
                    buttonEliminar.Text = "Eliminar";
                    buttonEliminar.CssClass = "btn btn-danger";
                    buttonEliminar.Attributes.Add("Style", "margin-left: 10%");
                    
                 
                    campo.Controls.Add(buttonEliminar);
                }

                campo.Attributes.Add("Style", "width: 20%");
                row.Cells.Add(campo);


                row.Attributes.Add("Style", "height:60px");

                //con filtro muestra solo los que son del usuario actual
                if (filtro)
                {
                    if (boletin.AutorInfo.getId() == ClaseSingleton.USUARIO_ACTUAL.getId())
                    {
                        tblBoletines.Rows.Add(row);
                    }
                }
                else
                {
                    tblBoletines.Rows.Add(row);
                }
            }
        }

        protected void btnMisPublicaciones_Click(object sender, EventArgs e)
        {
            if(btnMisPublicaciones.CssClass.Equals("btn bg-green-gradient"))
            {
                btnMisPublicaciones.CssClass = "btn bg-green";
            }
            else
            {
                btnMisPublicaciones.CssClass = "btn bg-green-gradient";
            }

            llenarTablaBoletines(true, false);
        }

        private void btnEliminarBoletin_Click(String pIdBoletin)
        {
            Boolean respuesta = controlador.eliminarBoletin(pIdBoletin);

            if (respuesta)
            {
                //RecargarPagina();
                //MsgBox("Se ha eliminado el boletín!");
                ClientScript.RegisterStartupScript(Page.GetType(), 
                    "alert",
                    "alert('Se ha eliminado el boletín!');window.location='" + "frmBoletines" + ".aspx';", true);

            }
            else
            {
                MsgBox("No ha sido posible eliminar!");
            }
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            llenarTablaBoletines(false, true);
        }

        public void MsgBox(String ex)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = this.GetType();
            ClientScriptManager cs = this.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        private void RecargarPagina()
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void println(String msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }

    }
}