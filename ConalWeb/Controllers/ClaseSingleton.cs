using ConalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConalWeb.Controllers
{
    public class ClaseSingleton
    {
        private static ClaseSingleton instancia;

        private ClaseSingleton()
        {
        }

        public static ClaseSingleton getInstance()
        {
            if (instancia == null)
            {
                instancia = new ClaseSingleton();
            }
            return instancia;
        }

        public static String linkImagenGPSNoDisponible = "https://firebasestorage.googleapis.com/v0/b/conalapp-74fc6.appspot.com/o/images%2Fimagen_gps_no_disponible.jpg?alt=media&token=54d7d602-087a-402f-a688-257e5195c93d";

        // -------------------------------------------------------------------------------- //

        /**
         * Gmail: conalapp@gmail.com
         * Passw: conalapptec123
         * <p>
         * 000webhost: conalapp@gmail.com
         * Passw: conalapptec123
         * <p>
         * BaseDatos: conalappbd
         * Passw: conalapptec123
         */

        // Usuario Actual
        public static Persona USUARIO_ACTUAL = new Persona();

        // IP del servidor
        private static String URL_HOST = "http://conalapp.000webhostapp.com/";

        /* PHP usuarios */
        public static String GET_USER_PASS = URL_HOST + "archivosPHP/select_usuario_iniciar_sesion.php";
        public static String SELECT_USER_BY_ID = URL_HOST + "archivosPHP/select_usuario_by_id.php";

        // PHP Boletin
        public static String SELECT_ALL_BOLETIN = URL_HOST + "archivosPHP/boletin_select_all.php";

        // PHP Reunion
        public static String SELECT_ALL_REUNION = URL_HOST + "archivosPHP/reunion_select_all.php";
    

        // PHP Comunidades
        public static String SELECT_ALL_COMUNIDAD = URL_HOST + "archivosPHP/comunidad_select_all.php";
        public static String SELECT_ALL_COMUNIDAD_WITH_COUNT_BOLETINES = URL_HOST + "archivosPHP/comunidad_count_boletines.php";
        public static String SELECT_ALL_COMUNIDAD_WITH_COUNT_REUNIONES = URL_HOST + "archivosPHP/comunidad_count_reunones.php";

        // TODOS LOS NOMBRES DE COMUNIDAD Y SU COUNT DE REUNIONES
        public static String SELECT_ALL_COMUNIDAD_WITH_COUNT_REUNIONES_ALL = URL_HOST + "archivosPHP/comunidad_count_reunones_all.php";

        // TODOS LOS NOMBRES DE COMUNIDAD Y SU COUNT DE BOLETINES
        public static String SELECT_ALL_COMUNIDAD_WITH_COUNT_BOLETINES_ALL = URL_HOST + "archivosPHP/comunidad_count_boletines_all.php";
        public static String SELECT_ALL_COUNT_BOLETINES_BY_ID = URL_HOST + "archivosPHP/comunidad_select_boletines_by_persona.php"; // el ID es de la personas
        public static String SELECT_ALL_COUNT_REUNIONES_BY_ID = URL_HOST + "archivosPHP/comunidad_select_reuniones_by_persona.php"; // el ID es de la persona

        public static String SELECT_ALL_COUNT_BOLETINES_BY_ID_COMUNIDAD = URL_HOST + "archivosPHP/comunidad_count_boletines.php"; // el ID es de comunidad
        public static String SELECT_ALL_COUNT_REUNIONES_BY_ID_COMUNIDAD = URL_HOST + "archivosPHP/comunidad_count_reunones.php"; // el ID es de comunidad

        // WEB
        public static String DELETE_BOLETIN_BY_IDUSER_IDBOLETIN = URL_HOST + "archivosPHP/boletin_delete_by_IdBoletin_IdPersona.php"; // recibe ID persona e ID boletin
        public static String DELETE_REUNION_BY_IDUSER_IDREUNION = URL_HOST + "archivosPHP/reunion_delete_by_IdReunion_IdPersona.php";
        public static String SEARCH_SOSPECHOSOS = URL_HOST + "archivosPHP/buscar_sospechosos.php"; // recibe un string de la descripción
    }
}