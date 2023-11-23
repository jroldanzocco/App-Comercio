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
    public partial class NuevaCompra : System.Web.UI.Page
    {
        public List<Producto> ListaVenta
        {
            get
            {
                if (Session["ListaVenta"] == null)
                {
                    Session["ListaVenta"] = new List<Producto>();
                }
                return (List<Producto>)Session["ListaVenta"];
            }
            set
            {
                Session["ListaVenta"] = value;
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
                CargarProductos();
            }
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
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            int idProducto = ObtenerIdProductoSeleccionado(sender);

            if (idProducto > 0)
            {
                Producto producto = ObtenerProductoPorId(idProducto);
                Producto productoEnLista = ListaVenta.FirstOrDefault(p => p.Id == idProducto);

                if (productoEnLista != null)
                {
                    productoEnLista.Cantidad++;
                }
                else
                {
                    producto.Cantidad = 1;
                    ListaVenta.Add(producto);
                }
                CargarProductosCompradoss();
            }
        }
        private void CargarProductosCompradoss()
        {
            repProductosComprados.DataSource = ListaVenta;
            repProductosComprados.DataBind();
        }
        private Producto ObtenerProductoPorId(int id)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            return negocio.ObtenerPorId(id);
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            //Restaurarar Stock
            Response.Redirect("PaginaPrincipal.aspx");
        }
        private void CargarProductos()
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
                Response.Write($"Error al cargar los productos: {ex.Message}");
            }
        }
        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int idProductoEliminar = ObtenerIdProductoSeleccionado(sender);

            if (idProductoEliminar > 0)
            {
                Producto productoEnLista = ListaVenta.FirstOrDefault(p => p.Id == idProductoEliminar);

                if (productoEnLista != null)
                {
                    if (productoEnLista.Cantidad > 1)
                    {
                        productoEnLista.Cantidad--;
                    }
                    else
                    {
                        ListaVenta.Remove(productoEnLista);
                    }
                    CargarProductosComprados(); // Cambiar a CargarProductosComprados
                }
            }
        }
        private void CargarProductosComprados()
        {
            repProductosComprados.DataSource = ListaVenta;
            repProductosComprados.DataBind();
        }
        private void ActualizarInterfazUsuario()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Response.Write($"Error al actualizar la interfaz de usuario: {ex.Message}");
            }
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
        private int ObtenerIdProductoAEliminar()
        {
            return 1;
        }
        protected void btnConfirmarGuardarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaVenta.Count > 0)
                {
                    ProductoNegocio negocioProducto = new ProductoNegocio();
                    CompraNegocio compraNegocio = new CompraNegocio();

                    foreach (var producto in ListaVenta)
                    {
                        Compra compra = new Compra
                        {
                            IdArticulo = producto.Id,
                            Cantidad = producto.Cantidad,
                            NumeroFactura = 0,
                            Facturada = false,
                            Activo = true
                        };

                        compraNegocio.Add(compra);

                        negocioProducto.ActualizarStock(producto, producto.Cantidad);
                    }
                    ListaVenta.Clear();

                    Response.Redirect("PaginaPrincipal.aspx");
                }
                else
                {
                    Response.Write("No hay productos para confirmar y guardar.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error al confirmar y guardar la compra: {ex.Message}");
            }
        }
    }
}