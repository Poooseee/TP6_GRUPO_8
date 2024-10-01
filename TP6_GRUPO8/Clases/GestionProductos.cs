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
            return datos.obtenerTabla(consulta, "Productos");
        }

        private void armarParametrosEliminar(ref SqlCommand comando, Producto producto)
        {
            SqlParameter sqlparametro = new SqlParameter();
            sqlparametro = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlparametro.Value = producto.idProducto;
        }

        private void armarParametros(ref SqlCommand comando, Producto producto)
        {
            SqlParameter sqlparametros = new SqlParameter();

            //completar
        }

        public bool ActualizarProducto(Producto prod)
        {
            SqlCommand comando = new SqlCommand();
            armarParametros(ref comando, prod);

            //completar
        }

        public bool EliminarProducto(Producto prod)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosEliminar(ref comando, prod);
            int filasCambiadas = datos.ejecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
            if (filasCambiadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}