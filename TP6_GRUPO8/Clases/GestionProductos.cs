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

        private void armarParametrosProductos(ref SqlCommand comando, Producto producto)
        {
            SqlParameter sqlparametros = new SqlParameter();
            sqlparametros = comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlparametros.Value = producto.idProducto;
            sqlparametros = comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar, 40);
            sqlparametros.Value = producto.nombreProducto;
            sqlparametros = comando.Parameters.Add("@CantidadPorUnidad", SqlDbType.NVarChar, 20);
            sqlparametros.Value = producto.cantidadXunidad;
            sqlparametros = comando.Parameters.Add("@PrecioUnidad", SqlDbType.Money);
            sqlparametros.Value = producto.precioXunidad;
        }

        public bool ActualizarProducto(Producto prod)
        {         
            SqlCommand comando = new SqlCommand();
            armarParametrosProductos(ref comando, prod);
            AccesoDatos ad = new AccesoDatos();
            int filasInsertadas = ad.ejecutarProcedimientoAlmacenado(comando, "spActualizarProducto");
            if (filasInsertadas == 1)
                return true;
            else
                return false;
        }

        public bool EliminarProducto(Producto prod)
        {
            SqlCommand comando = new SqlCommand();
            armarParametrosEliminar(ref comando, prod);
            AccesoDatos ad = new AccesoDatos();
            int filasInsertadas = ad.ejecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
            if (filasInsertadas == 1)
                return true;
            else
                return false;
        }
    }
}
