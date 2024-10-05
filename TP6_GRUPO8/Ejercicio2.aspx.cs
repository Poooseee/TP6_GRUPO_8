using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO8
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblEliminado.Text = "";
        }

        protected void lbEliminarProductos_Click(object sender, EventArgs e)
        {
            if(Session["ProductosSeleccionados"] != null)
            {
                lblEliminado.Text = "Se han eliminado los productos seleccionados.";
            }
            else
            {
                lblEliminado.Text = "No hay productos seleccionados ha eliminar";
            }
            Session["ProductosSeleccionados"] = null;
        }
    }
}