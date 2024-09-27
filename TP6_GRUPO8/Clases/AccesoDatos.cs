using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP6_GRUPO8.Clases
{
    public class AccesoDatos
    {
        string rutaBdNeptuno = "Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=False";

        public DataTable obtenerTabla(string consultaSQL, string nombreTabla)
        {
            SqlConnection conexion = new SqlConnection(rutaBdNeptuno);
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consultaSQL, conexion);
            // completar la funcion
        }
    }
}