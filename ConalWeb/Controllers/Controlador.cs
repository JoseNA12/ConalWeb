using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using ConalWeb.Models;
using System.Collections.Specialized;
using System.Text;

namespace ConalWeb.Controllers
{
    public class Controlador
    {
        public ClaseSingleton utilidades = ClaseSingleton.getInstance();

        private String executeQuery(String query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string respuesta = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                respuesta = reader.ReadToEnd();
            }
            
            return respuesta;
        }

        public String executeQueryPOST(String query, String caracteristicas)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
            request.Method = "POST";
            byte[] data = Encoding.ASCII.GetBytes($"Caracteristicas={caracteristicas}");

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            //    request.AutomaticDecompression = DecompressionMethods.GZip;


            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            string respuesta = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                respuesta = reader.ReadToEnd();
            }

            return respuesta;
        }

        public bool realizarBusqueda(String carcateristicas)
        {
            String respuesta = "";

            try
            {
                JObject jsonObject = JObject.Parse(respuesta);

                if (jsonObject.Value<string>("status").Equals("false"))
                {
                    return false;
                }
                else
                {
                    return true; // Lo eliminó
                }

            }
            catch (Exception e) { }

            return false;
        }

        public bool iniciarSesion(string correo, string contrasena)
        {
            if (correo.Equals("") || contrasena.Equals(""))
            {
                return false;
            }
            else
            {
                String respuesta = executeQuery(ClaseSingleton.GET_USER_PASS + "?Correo=" + correo + "&Contrasena=" + contrasena);

                try
                {
                    JObject json = JObject.Parse(respuesta);

                    if (json.Value<string>("status").Equals("false"))
                    {
                        return false;
                    }
                    else
                    {
                        JObject subjson = json.Value<JObject>("value");

                        ClaseSingleton.USUARIO_ACTUAL.setId(subjson.Value<int>("IdPersona"));
                        ClaseSingleton.USUARIO_ACTUAL.setCorreo(subjson.Value<string>("Correo"));
                        ClaseSingleton.USUARIO_ACTUAL.setNombre(subjson.Value<string>("Nombre"));
                        ClaseSingleton.USUARIO_ACTUAL.setApellido(subjson.Value<string>("Apellido"));
                        ClaseSingleton.USUARIO_ACTUAL.setFechaNacimiento(subjson.Value<string>("fechaNacimiento"));
                        ClaseSingleton.USUARIO_ACTUAL.setBiografia(subjson.Value<string>("biografia"));
                        ClaseSingleton.USUARIO_ACTUAL.setGenero(subjson.Value<string>("genero"));
                        ClaseSingleton.USUARIO_ACTUAL.setLugarResidencia(subjson.Value<string>("lugarResidencia"));
                        ClaseSingleton.USUARIO_ACTUAL.setSobrenombre(subjson.Value<string>("sobrenombre"));

                        return true;
                    }
                } catch (Exception e) {
                    return false;
                }
            }
        }

        public List<Boletin> cargarBoletines()
        {
            List<Boletin> boletines = new List<Boletin>();

            String respuesta = executeQuery(ClaseSingleton.SELECT_ALL_BOLETIN + "?IdPersona=" + ClaseSingleton.USUARIO_ACTUAL.getId());

            try
            {
                JObject jsonObject = JObject.Parse(respuesta);

                if (!jsonObject.Value<string>("status").Equals("false"))
                {
                    JToken valores = jsonObject.GetValue("value");
                    foreach(JObject json in valores)
                    {
                        String idBoletin = json.Value<string>("IdBoletin");
                        String titular = json.Value<string>("Titular");
                        String provincia = json.Value<string>("Provincia");
                        String canton = json.Value<string>("Canton");
                        String fecha = json.Value<string>("Fecha");
                        String hora = json.Value<string>("Hora");
                        String descripcion = json.Value<string>("Descripcion");
                        String sospechosos = json.Value<string>("Sospechosos");
                        String armasSosp = json.Value<string>("ArmasSosp");
                        String vehiculosSosp = json.Value<string>("VehiculosSosp");
                        String linkImagenGPS = json.Value<string>("EnlaceGPS");
                        String IdComunidad = json.Value<string>("IdComunidad");

                        // Info usuario
                        int idAutor = json.Value<int>("IdPersona");
                        String nombreAutor = json.Value<string>("Nombre");
                        String apellidoAutor = json.Value<string>("Apellido");
                        String correoAutor = json.Value<string>("Correo");
                        String sobrenombreAutor = json.Value<string>("sobrenombre");
                        String lugarResidencia = json.Value<string>("lugarResidencia");
                        String generoAutor = json.Value<string>("genero");
                        String fechaNacimiento = json.Value<string>("fechaNacimiento");
                        String biografia = json.Value<string>("biografia");

                        Persona autor = new Persona();
                        autor.setId(idAutor);
                        autor.setCorreo(correoAutor);
                        autor.setNombre(nombreAutor);
                        autor.setApellido(apellidoAutor);
                        autor.setFechaNacimiento(fechaNacimiento);
                        autor.setBiografia(biografia);
                        autor.setGenero(generoAutor);
                        autor.setLugarResidencia(lugarResidencia);
                        autor.setSobrenombre(sobrenombreAutor);

                        Console.WriteLine(IdComunidad);

                        boletines.Add(
                                new Boletin(idBoletin, autor.getNombre() + autor.getApellido(), titular, provincia, canton, fecha, hora, descripcion,
                                        sospechosos, armasSosp, vehiculosSosp, linkImagenGPS, autor, IdComunidad, "Boletín"));
                    }
                }
                    
            } catch (Exception e) { }

            return boletines;
        }

        public List<Reunion> cargarReuniones()
        {
            List<Reunion> reuniones = new List<Reunion>();

            String respuesta = executeQuery(ClaseSingleton.SELECT_ALL_REUNION + "?IdPersona=" + ClaseSingleton.USUARIO_ACTUAL.getId());

            try
            {
                JObject jsonObject = JObject.Parse(respuesta);

                if (!jsonObject.Value<string>("status").Equals("false"))
                {
                    JToken valores = jsonObject.GetValue("value");
                    foreach (JObject json in valores)
                    {
                        String idReunion = json.Value<string>("IdReunion");
                        String titular = json.Value<string>("Titular");
                        String detalle = json.Value<string>("Detalle");
                        String fecha = json.Value<string>("Fecha");
                        String provincia = json.Value<string>("Provincia");
                        String hora = json.Value<string>("Hora");
                        String canton = json.Value<string>("Canton");
                        String linkImagenGPS = json.Value<string>("EnlaceGPS");
                        String IdComunidad = json.Value<string>("IdComunidad");

                        // Info usuario
                        int idAutor = json.Value<int>("IdPersona");
                        String nombreAutor = json.Value<string>("Nombre");
                        String apellidoAutor = json.Value<string>("Apellido");
                        String correoAutor = json.Value<string>("Correo");
                        String sobrenombreAutor = json.Value<string>("sobrenombre");
                        String lugarResidencia = json.Value<string>("lugarResidencia");
                        String generoAutor = json.Value<string>("genero");
                        String fechaNacimiento = json.Value<string>("fechaNacimiento");
                        String biografia = json.Value<string>("biografia");

                        Persona autor = new Persona();
                        autor.setId(idAutor);
                        autor.setCorreo(correoAutor);
                        autor.setNombre(nombreAutor);
                        autor.setApellido(apellidoAutor);
                        autor.setFechaNacimiento(fechaNacimiento);
                        autor.setBiografia(biografia);
                        autor.setGenero(generoAutor);
                        autor.setLugarResidencia(lugarResidencia);
                        autor.setSobrenombre(sobrenombreAutor);

                        reuniones.Add(new Reunion(idReunion, autor.getNombre() + autor.getApellido(), titular,
                                        provincia, fecha, hora, linkImagenGPS, detalle, canton, autor, IdComunidad, "Reunión"));
                    }
                }

            }
            catch (Exception e) { }

            return reuniones;
        }

        public Boolean eliminarBoletin(String pIdBoletin)
        {
            String respuesta = executeQuery(
                ClaseSingleton.DELETE_BOLETIN_BY_IDUSER_IDBOLETIN + 
                "?IdBoletin=" + pIdBoletin + 
                "&IdPersona=" + ClaseSingleton.USUARIO_ACTUAL.getId());

            try
            {
                JObject jsonObject = JObject.Parse(respuesta);

                if (jsonObject.Value<string>("status").Equals("false"))
                {
                    return false;
                }
                else
                {
                    return true; // Lo eliminó
                }

            }
            catch (Exception e) { }

            return false;
        }

        public Boolean eliminarReunion(int pIdUsuario, String pIdBoletin)
        {
            String respuesta = executeQuery(
                ClaseSingleton.DELETE_REUNION_BY_IDUSER_IDREUNION +
                "?IdReunion=" + pIdBoletin +
                "&IdPersona=" + ClaseSingleton.USUARIO_ACTUAL.getId());

            try
            {
                JObject jsonObject = JObject.Parse(respuesta);

                if (jsonObject.Value<string>("status").Equals("false"))
                {
                    return false;
                }
                else
                {
                    return true; // Lo eliminó
                }

            }
            catch (Exception e) { }

            return false;
        }

        public List<Boletin> cargarBoletines_por_busqueda(String caracteristicas)
        {
            List<Boletin> boletines = new List<Boletin>();

            String respuesta = executeQueryPOST(ClaseSingleton.SEARCH_SOSPECHOSOS, caracteristicas);

            try
            {
                JObject jsonObject = JObject.Parse(respuesta);

                if (!jsonObject.Value<string>("status").Equals("false"))
                {
                    if (jsonObject.Value<string>("status").Equals("none")) { return boletines; }
                    else
                    {
                        JToken valores = jsonObject.GetValue("value");

                        foreach (JObject json in valores)
                        {

                            String idBoletin = json.Value<string>("IdBoletin");
                            String titular = json.Value<string>("Titular");
                            String provincia = json.Value<string>("Provincia");
                            String canton = json.Value<string>("Canton");
                            String fecha = json.Value<string>("Fecha");
                            String hora = json.Value<string>("Hora");
                            String descripcion = json.Value<string>("Descripcion");
                            String sospechosos = json.Value<string>("Sospechosos");
                            String armasSosp = json.Value<string>("ArmasSosp");
                            String vehiculosSosp = json.Value<string>("VehiculosSosp");
                            String linkImagenGPS = json.Value<string>("EnlaceGPS");
                            String IdComunidad = json.Value<string>("IdComunidad");

                            // Info usuario
                            int idAutor = json.Value<int>("IdPersona");
                            String nombreAutor = json.Value<string>("Nombre");
                            String apellidoAutor = json.Value<string>("Apellido");
                            String correoAutor = json.Value<string>("Correo");
                            String sobrenombreAutor = json.Value<string>("sobrenombre");
                            String lugarResidencia = json.Value<string>("lugarResidencia");
                            String generoAutor = json.Value<string>("genero");
                            String fechaNacimiento = json.Value<string>("fechaNacimiento");
                            String biografia = json.Value<string>("biografia");

                            Persona autor = new Persona();
                            autor.setId(idAutor);
                            autor.setCorreo(correoAutor);
                            autor.setNombre(nombreAutor);
                            autor.setApellido(apellidoAutor);
                            autor.setFechaNacimiento(fechaNacimiento);
                            autor.setBiografia(biografia);
                            autor.setGenero(generoAutor);
                            autor.setLugarResidencia(lugarResidencia);
                            autor.setSobrenombre(sobrenombreAutor);

                            Console.WriteLine(IdComunidad);

                            boletines.Add(
                                    new Boletin(idBoletin, autor.getNombre() + autor.getApellido(), titular, provincia, canton, fecha, hora, descripcion,
                                            sospechosos, armasSosp, vehiculosSosp, linkImagenGPS, autor, IdComunidad, "Boletín"));
                        }
                    }
                }

            }
            catch (Exception e) { }


            return boletines;
        }

        
    }
}