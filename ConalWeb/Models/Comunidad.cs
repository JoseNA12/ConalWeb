using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConalWeb.Models
{
    public class Comunidad
    {
        private string id;
        private string nombre;

        public Comunidad(string pId, String pNombre)
        {
            this.id = pId;
            this.nombre = pNombre;
        }

        public string getId()
        {
            return this.id;
        }

        public string getNombre()
        {
            return this.nombre;
        }
    }
}