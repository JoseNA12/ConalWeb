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
        private List<Reunion> reuniones = new List<Reunion>();
        private Controlador controlador = new Controlador();
        //true = boletines; false = reuniones
        private static bool eventoActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTablaBoletines(false);
        }

        private void cargarDatos()
        {
            if (eventoActual)
            {
                boletines = controlador.cargarBoletines();
            }
            else
            {
                reuniones = controlador.cargarReuniones();
            }
        }

        private void llenarTablaBoletines(bool filtro)
        {
            eventoActual = true;

            //carga los datos de los boletines
            cargarDatos();

            if (boletines.Count == 0)
            {
                divResultadosBusqueda.Visible = true;
                return;
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
                button.Text = "Ver en Maps";
                button.CssClass = "btn btn-default";

                campo = new TableCell();
                campo.Controls.Add(button);

                //si es el autor puede eliminarlos
                if (boletin.AutorInfo.getId() == ClaseSingleton.USUARIO_ACTUAL.getId())
                {
                    Button buttonEliminar = new Button();
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

        private void llenarTablaReuniones(bool filtro)
        {
            eventoActual = false;

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
                button.Text = "Ver en Maps";
                button.CssClass = "btn btn-default";

                campo = new TableCell();
                campo.Controls.Add(button);

                //si es el autor puede eliminarlos
                if(reunion.AutorInfo.getId() == ClaseSingleton.USUARIO_ACTUAL.getId())
                {
                    Button buttonEliminar = new Button();
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
                    if (reunion.AutorInfo.getId() == ClaseSingleton.USUARIO_ACTUAL.getId())
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

            //no sé por qué pero con eventoActual no valida bien esta parte
            if (btnReuniones.CssClass.Equals("btn bg-red principalButton"))
            {
                llenarTablaReuniones(true);
            }
            else
            {
                llenarTablaBoletines(true);
            }
        }

        protected void btnReuniones_Click(object sender, EventArgs e)
        {
            cambiarColorBotones(false);
            divBuscar.Visible = false;

            //sin filtro
            llenarTablaReuniones(false);
        }

        protected void btnBoletines_Click(object sender, EventArgs e)
        {
            cambiarColorBotones(true);
            divBuscar.Visible = true;

            //sin filtro
            llenarTablaBoletines(false);
        }

        //cambia el color de los botones de reuniones y boletines
        // tipoNoticia: true = boletines, false = reuniones
        private void cambiarColorBotones(bool tipoNoticia)
        {
            if (tipoNoticia)    //seleccionado boletines
            {
                btnBoletines.CssClass = "btn bg-red principalButton";
                btnReuniones.CssClass = "btn bg-red-gradient principalButton";
            }
            else                //seleccionado reuniones
            {
                btnBoletines.CssClass = "btn bg-red-gradient principalButton";
                btnReuniones.CssClass = "btn bg-red principalButton";
            }
        }

    }
}