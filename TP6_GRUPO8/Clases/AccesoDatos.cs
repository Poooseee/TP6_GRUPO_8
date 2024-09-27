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

        public SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(rutaBdNeptuno);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex) {
                return null;
                }
        }

        public SqlDataAdapter obtenerAdaptador(string consultaSQL)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, obtenerConexion());
                return adapter;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        

        /*public int ejecutarConsulta(string consultaSQL)
        {
            SqlConnection conexion = new SqlConnection(rutaBdNeptuno);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
            //completar la funcion
        }*/
    }
}