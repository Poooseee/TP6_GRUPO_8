using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP6_GRUPO8.Clases
{
    public class GestionProductos
    {
        public GestionProductos() 
        { 
        }

        public DataTable obtenerTabla(string consultaSQL, string nombreTabla)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adaptador = datos.obtenerAdaptador(consultaSQL);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "nombreTabla");
            return ds.Tables["nombreTabla"];
        }

        public DataTable obtenerTodosLosProductos()
        {
            return obtenerTabla("Neptuno", "Select * From Productos");
        }

    }
}