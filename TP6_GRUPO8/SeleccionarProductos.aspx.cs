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
           
            
        }

        public void agregarProductosASession(Producto pr)
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

            bool productoAgregado = false;
            foreach(DataRow row in dt.Rows)
            {
                if ((int)row["idProducto"] == pr.idProducto)
                {
                    productoAgregado = true;
                }
            }
            if (productoAgregado == true)
            {
                lblMensaje.Text = "Este producto ya está seleccionado";
            }
            else
            {
                DataRow newRow = dt.NewRow();
                newRow["IdProducto"] = pr.idProducto;
                newRow["NombreProducto"] = pr.nombreProducto;
                newRow["IdProveedor"] = pr.idProveedor;
                newRow["PrecioUnidad"] = pr.precioXunidad;

                dt.Rows.Add(newRow);
                Session["ProductosSeleccionados"] = dt;
            }
        }

        
        protected void grdSeleccionar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSeleccionar.PageIndex = e.NewPageIndex;
            cargarGridView();
        }

        protected void grdSeleccionar_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grdSeleccionar.SelectedIndex = e.NewSelectedIndex;
            cargarGridView();
           
            GridViewRow selectedRow = grdSeleccionar.SelectedRow;

            Producto pr = new Producto();

            if (selectedRow != null)
            {
                pr.nombreProducto = ((Label)selectedRow.FindControl("lbl_it_NombreProducto")).Text;
                pr.idProveedor = Convert.ToInt32(((Label)selectedRow.FindControl("lbl_it_IdProveedor")).Text);
                pr.precioXunidad = Convert.ToDecimal(((Label)selectedRow.FindControl("lbl_it_PrecioUnitario")).Text);
                pr.idProducto = Convert.ToInt32(((Label)selectedRow.FindControl("lbl_it_IdProducto")).Text);
                
                lblMensaje.Text = pr.nombreProducto;

                agregarProductosASession(pr);
            }
        }
    }
}