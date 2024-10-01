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
        AccesoDatos datos = new AccesoDatos();
        public GestionProductos() 
        { 

        }

        

        public DataTable obtenerTodosLosProductos()
        {
            string consulta = "SELECT IdProducto, NombreProducto,IdProveedor, CantidadPorUnidad, PrecioUnidad FROM Productos";
            return  datos.obtenerTabla(consulta,"Productos");
        }

       //public int EliminarProducto() {

          //  string consulta
         //       }

    }
}