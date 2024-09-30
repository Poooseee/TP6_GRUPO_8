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

        public int ejecutarConsulta(string consultaSQL)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consultaSQL, conexion);
            int filas = cmd.ExecuteNonQuery();
            conexion.Close();
            return filas;
        }
        public DataTable obtenerTabla(string consultaSQL, string nombreTabla)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adaptador = datos.obtenerAdaptador(consultaSQL);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "nombreTabla");
            return ds.Tables["nombreTabla"];
        }
    }
}