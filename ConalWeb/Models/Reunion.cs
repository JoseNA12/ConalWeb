using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConalWeb.Models
{
    public class Reunion
    {
        public String IdReunion { get; set; }
        public String Autor { get; set; }
        public String Titular { get; set; }
        public String Provincia { get; set; }
        public String Canton { get; set; }
        public String Distrito { get; set; }
        public String Fecha { get; set; }
        public String Hora { get; set; }
        public String Descripcion { get; set; }
        public String LinkImagenGPS { get; set; }
        public Persona AutorInfo { get; set; }
        public String IdComunidad { get; set; }
    
        private String tipoInforme { get; set; }

        public Reunion(String id, String autor, String titular, String provincia, String fecha, String hora, String linkImagenGPS, String descrpcion, String canton, Persona autorInfo, String idComunidad, String pTipoInforme)
        {
            this.IdReunion = id;
            this.Autor = autor;
            this.Titular = titular;
            this.Provincia = provincia;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Descripcion = descrpcion;
            this.LinkImagenGPS = linkImagenGPS;
            this.Canton = canton;
            this.AutorInfo = autorInfo;
            this.IdComunidad = idComunidad;

            this.tipoInforme = pTipoInforme;
        }
    }
}