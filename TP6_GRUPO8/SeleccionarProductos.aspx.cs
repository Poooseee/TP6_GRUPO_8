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
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        GestionProductos gp = new GestionProductos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarGridView();
                
            }
        }
        public void cargarGridView()
        {
            grdSeleccionar.DataSource = gp.obtenerTodosLosProductos();
            grdSeleccionar.DataBind();
        }
        protected void grdSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GestionProductos gp = new GestionProductos();
            GridViewRow selectedRow = grdSeleccionar.SelectedRow;

            string nombreProducto;
            decimal precioUnidad;
            int idProveedor;
            int idProducto;

            if(selectedRow != null)
            {
                nombreProducto = selectedRow.Cells[2].Text;
                idProveedor = Convert.ToInt32(selectedRow.Cells[3].Text);
                precioUnidad = Convert.ToDecimal(selectedRow.Cells[4].Text);
                idProducto = Convert.ToInt32(selectedRow.Cells[1].Text);

                lblMensaje.Text = nombreProducto;

                agregarProductosASession(idProducto, nombreProducto, idProveedor, precioUnidad);
            }
        }

        public void agregarProductosASession(int idProducto, string nombreProducto, int idProveedor , decimal precioUnidad)
        {
            DataTable dt;
            if (Session["ProductosSeleccionados"] == null)
            {
                //SI NO EXISTE
                dt = new DataTable();
                dt.Columns.Add("IdProducto" , typeof(int));
                dt.Columns.Add("NombreProducto" , typeof(String));
                dt.Columns.Add("IdProveedor" , typeof(int));
                dt.Columns.Add("PrecioUnidad" , typeof(decimal));            
            }
            else
            {
                dt = (DataTable)Session["ProductosSeleccionados"];
            }

            DataRow newRow = dt.NewRow();
            newRow["IdProducto"] = idProducto;
            newRow["NombreProducto"] = nombreProducto;
            newRow["IdProveedor"] = idProveedor;
            newRow["PrecioUnidad"] = precioUnidad;

            dt.Rows.Add(newRow);
            Session["ProductosSeleccionados"] = dt;
        }

        
        protected void grdSeleccionar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSeleccionar.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}