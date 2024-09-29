using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO8.Clases;

namespace TP6_GRUPO8
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        GestionProductos gp = new GestionProductos();
        string consulta = "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                grdSeleccionar.DataSource = gp.obtenerTabla(consulta, "grdProductos");
                grdSeleccionar.DataBind();
            }
        }
    }
}