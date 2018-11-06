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
    public partial class PanelReuniones : System.Web.UI.Page
    {
        private List<Reunion> reuniones = new List<Reunion>();
        private Controlador controlador = new Controlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTablaReuniones(false); // false
        }

        private void cargarDatos()
        {
            reuniones = controlador.cargarReuniones();
        }

        private void llenarTablaReuniones(bool filtro)
        {
            //carga los datos de las reuniones
            cargarDatos();

            if(reuniones.Count == 0)
            {
                divResultadosBusqueda.Visible = true;
                return;
            }

            //limpia la tabla para meter los nuevos valores
            tblBoletines.Rows.Clear();

            //comienza a crear la tabla
            TableRow row = new TableRow();
            TableCell campo = new TableCell();

            foreach (Reunion reunion in reuniones)
            {
                row = new TableRow();

                //AGREGA EL MAPA DEL EVENTO
                campo = new TableCell();
                Image mapa = new Image();
                mapa.ImageUrl = reunion.LinkImagenGPS;
                campo.Controls.Add(mapa);
                campo.Attributes.Add("Style", "width: 30%");
                row.Cells.Add(campo);

                //AGREGA LA INFORMACION DEL EVENTO
                campo = new TableCell();
                campo.Text = "<b><h3>" + reunion.Titular + "</h3></b> " + reunion.Provincia + "<br/>" +
                    "<i>" + reunion.Autor + " " + reunion.Fecha + " " + reunion.Hora + "</i><br/><br/>" +
                    "<b>Descripción: </b>" + reunion.Descripcion;
                campo.Attributes.Add("Style", "width: 40%");
                row.Cells.Add(campo);

                //AGREGA EL BOTON
                Button button = new Button();
                button.Text = "Ver mapa";
                button.CssClass = "btn btn-default botonCelda";
                button.Click += delegate
                {
                    //Response.Write("<script> window.open('" + boletin.LinkImagenGPS + "','_blank'); </script>");
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + reunion.LinkImagenGPS + "','_newtab');", true);
                };

                campo = new TableCell();
                campo.Controls.Add(button);

                //si es el autor puede eliminarlos
                if (reunion.AutorInfo.getId().ToString() == HttpContext.Current.Session["USUARIO_ACTUAL_ID"].ToString())
                {
                    Button buttonEliminar = new Button();
                    buttonEliminar.Click += delegate
                    {
                        //(sender, EventArgs) => { btnEliminarReunion_Click(sender, EventArgs, reunion.IdReunion); };
                        btnEliminarReunion_Click(reunion.IdReunion);
                    };
                    buttonEliminar.Text = "Eliminar";
                    buttonEliminar.CssClass = "btn btn-danger  botonCelda";
                    buttonEliminar.Attributes.Add("Style", "margin-left: 10%");
                    campo.Controls.Add(buttonEliminar);
                }

                campo.Attributes.Add("Style", "width: 20%; text-align: center;");
                row.Cells.Add(campo);

                //con filtro muestra solo los que son del usuario actual
                if (filtro)
                {
                    if (reunion.AutorInfo.getId().ToString() == HttpContext.Current.Session["USUARIO_ACTUAL_ID"].ToString())
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
            if (btnMisPublicaciones.CssClass.Equals("btn bg-green-gradient"))
            {
                btnMisPublicaciones.CssClass = "btn bg-green";
            }
            else
            {
                btnMisPublicaciones.CssClass = "btn bg-green-gradient";
            }

            llenarTablaReuniones(true);
        }

        private void btnEliminarReunion_Click(String pIdReunion)
        {
            Boolean respuesta = controlador.eliminarReunion(pIdReunion);

            if (respuesta)
            {
                //MsgBox("Se ha eliminado la reunión!");
                ClientScript.RegisterStartupScript(Page.GetType(),
                    "alert",
                    "alert('Se ha eliminado la reunión!');window.location='" + "frmReuniones" + ".aspx';", true);
            }
            else
            {
                MsgBox("No ha sido posible eliminar la reunión!");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        public void MsgBox(String ex)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = this.GetType();
            ClientScriptManager cs = this.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        private void println(String msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}