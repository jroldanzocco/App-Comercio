using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class NuevaVenta : System.Web.UI.Page
    {
        private List<Producto> ListaProductosVendidos
        {
            get
            {
                if (Session["ListaProductosVendidos"] == null)
                {
                    Session["ListaProductosVendidos"] = new List<Producto>();
                }
                return (List<Producto>)Session["ListaProductosVendidos"];
            }
            set
            {
                Session["ListaProductosVendidos"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No estás logueado");
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {
                CargarProductosDisponibles();
                CargarProductosVendidos();
            }
        }
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            int idProducto = ObtenerIdProductoSeleccionado(sender);

            if (idProducto > 0)
            {
                Producto producto = ObtenerProductoPorId(idProducto);
                Producto productoEnLista = ListaProductosVendidos.FirstOrDefault(p => p.Id == idProducto);

                if (productoEnLista != null)
                {
                    productoEnLista.Cantidad++;
                }
                else
                {
                    producto.Cantidad = 1;
                    ListaProductosVendidos.Add(producto);
                }
                CargarProductosVendidos();
            }
        }
        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int idProductoEliminar = ObtenerIdProductoSeleccionado(sender);

            if (idProductoEliminar > 0)
            {
                Producto productoEnLista = ListaProductosVendidos.FirstOrDefault(p => p.Id == idProductoEliminar);

                if (productoEnLista != null)
                {
                    if (productoEnLista.Cantidad > 1)
                    {
                        productoEnLista.Cantidad--;
                    }
                    else
                    {
                        ListaProductosVendidos.Remove(productoEnLista);
                    }
                    CargarProductosVendidos();
                }
            }
        }

        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            // Restaurarar Stock
            Response.Redirect("PaginaPrincipal.aspx");
        }

        private void CargarProductosVendidos()
        {
            repProductosVendidos.DataSource = ListaProductosVendidos;
            repProductosVendidos.DataBind();
        }

        private void CargarProductosDisponibles()
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> listaProductos = negocio.Listar();

                repArticulosDisponibles.DataSource = listaProductos;
                repArticulosDisponibles.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"Error al cargar los productos disponibles: {ex.Message}");
            }
        }

        private Producto ObtenerProductoPorId(int id)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            return negocio.ObtenerPorId(id);
        }

        private int ObtenerIdProductoSeleccionado(object sender)
        {
            Button btn = (Button)sender;
            string idProductoStr = btn.CommandArgument;

            if (int.TryParse(idProductoStr, out int idProducto))
            {
                return idProducto;
            }

            return -1;
        }
    }
}
