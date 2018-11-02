using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConalWeb.Models
{
    public class Boletin
    {
        public String IdBoletin { get; set; }
        public String Autor { get; set; }
        public String Titular { get; set; }
        public String Provincia { get; set; }
        public String Canton { get; set; }
        public String Fecha { get; set; }
        public String Hora { get; set; }
        public String Descripcion { get; set; }
        public String Sospechosos { get; set; }
        public String ArmasSosp { get; set; }
        public String VehiculosSosp { get; set; }
        public String LinkImagenGPS { get; set; }
        public Persona AutorInfo { get; set; }
        public String IdComunidad { get; set; }

        private String tipoInforme { get; set; }

        public Boletin(String id, String autor, String titular, String provincia, String canton, String fecha, String hora, String descripcion, String sospechosos, String armasSosp, String vehiculosSosp, String linkImagenGPS, Persona autorInfo, String idComunidad, String pTipoInforme)
        {
            this.IdBoletin = id;
            this.Autor = autor;
            this.Titular = titular;
            this.Provincia = provincia;
            this.Canton = canton;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Descripcion = descripcion;
            this.Sospechosos = sospechosos;
            this.ArmasSosp = armasSosp;
            this.VehiculosSosp = vehiculosSosp;
            this.LinkImagenGPS = linkImagenGPS;
            this.AutorInfo = autorInfo;
            this.IdComunidad = idComunidad;

            this.tipoInforme = pTipoInforme;
        }
    }
}