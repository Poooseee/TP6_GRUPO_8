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
            /*
            SqlCommand comando = new SqlCommand();
            armarParametros(ref comando, prod);

            //completar
            */
            return false; //borrar
        }

        public bool EliminarProducto(Producto prod)
        {
            // Definir la consulta SQL para eliminar el producto
            string consulta = "DELETE FROM Productos WHERE idProducto = @idProducto";

            using (SqlConnection conexion = datos.obtenerConexion()) // Usa tu clase de acceso a datos para obtener la conexión
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idProducto", prod.idProducto);

                try
                {
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();

                    // Si una fila fue afectada, el producto fue eliminado
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    // Manejar excepciones (registro de errores, etc.)
                    Console.WriteLine("Error al eliminar el producto: " + ex.Message);
                    return false;
                }
                finally
                {
                    // Asegurarse de cerrar la conexión
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            
        }


        // SqlCommand comando = new SqlCommand();
        //armarParametrosEliminar(ref comando, prod);
        //int filasCambiadas = datos.ejecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
        //if (filasCambiadas == 1)
        //{
        //   return true;
        //}
        //else
        //{
        //  return false;
    }


    //  }
}
}