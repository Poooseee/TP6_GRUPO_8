using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_GRUPO8.Clases;

namespace TP6_GRUPO8
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        GestionProductos gp = new GestionProductos();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGridView();
            }
        }

      public void cargarGridView()
        {
           grdProductos.DataSource = gp.obtenerTodosLosProductos();
           grdProductos.DataBind();
        }
        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProductos.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProductos.EditIndex = -1;
            cargarGridView();
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Producto pr = new Producto();  
            pr.idProducto = Convert.ToInt32(((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_eit_IdProducto")).Text);
            pr.nombreProducto = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_eit_NombreProducto")).Text;
            pr.cantidadXunidad = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadPorUnidad")).Text;
            pr.precioXunidad = Convert.ToDecimal(((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad")).Text);

            

        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Producto prod = new Producto();

            
            Label lblIdProductos = (Label)grdProductos.Rows[e.RowIndex].FindControl("lblIdProductos");
            if (lblIdProductos != null)
            {
                string s_idProd = lblIdProductos.Text;
                prod.idProducto = Convert.ToInt32(s_idProd);

                // Intentar eliminar el producto
                bool eliminado = gp.EliminarProducto(prod);

                if (eliminado)
                {
                    // Recargar el GridView si se eliminó correctamente
                    cargarGridView();
                }
                else
                {
                    // Mostrar un mensaje si el producto no fue eliminado
                    MostrarMensaje("No se pudo eliminar el producto.");
                }
            }
            else
            {
                // Mostrar un mensaje si no se encontró el ID del producto
                MostrarMensaje("No se encontró el producto.");
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            // Lógica para mostrar el mensaje en la pantalla (puedes ajustarlo según necesites)
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + mensaje + "');", true);
        }


        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}