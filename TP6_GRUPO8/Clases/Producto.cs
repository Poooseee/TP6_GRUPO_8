using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_GRUPO8.Clases
{
    public class Producto
    {
        private int IdProducto;
        private string NombreProducto;
        private int IdProveedor;
        private string CantidadPorUnidad;
        private decimal PrecioUnidad;

        public Producto()
        {
        }

        public Producto(int idProducto, string nombreProducto, int idProveedor, string cantidadPorUnidad, decimal precioUnidad)
        {
            IdProducto = idProducto;
            NombreProducto = nombreProducto;
            IdProveedor = idProveedor;
            CantidadPorUnidad = cantidadPorUnidad;
            PrecioUnidad = precioUnidad;
        }

        public int idProducto
        {
            get { return IdProducto; }
            set { IdProducto = value; }
        }
        public int idProveedor
        {
            get { return IdProveedor; }
            set { IdProveedor = value; }
        }
        public string nombreProducto
        {
            get { return NombreProducto; }
            set { NombreProducto = value; }
        }
        public string cantidadXunidad
        {
            get { return CantidadPorUnidad; }
            set { CantidadPorUnidad = value; }
        }
        public decimal precioXunidad
        {
            get { return PrecioUnidad; }
            set { PrecioUnidad = value; }
        }
    }
}