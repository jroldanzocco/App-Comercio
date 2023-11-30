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
        private List<Producto> ListaProductosComprados
        {
            get
            {
                if (Session["ListaProductosComprados"] == null)
                {
                    Session["ListaProductosComprados"] = new List<Producto>();
                }
                return (List<Producto>)Session["ListaProductosComprados"];
            }
            set
            {
                Session["ListaProductosComprados"] = value;
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
                CargarProductosComprados();
            }
        }
        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            int idProducto = ObtenerIdProductoSeleccionado(sender);

            if (idProducto > 0)
            {
                Producto producto = ObtenerProductoPorId(idProducto);
                Producto productoEnLista = ListaProductosComprados.FirstOrDefault(p => p.Id == idProducto);

                if (productoEnLista != null)
                {
                    productoEnLista.Cantidad++;
                }
                else
                {
                    producto.Cantidad = 1;
                    ListaProductosComprados.Add(producto);
                }
                CargarProductosComprados();
            }
        }
        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            int idProductoEliminar = ObtenerIdProductoSeleccionado(sender);

            if (idProductoEliminar > 0)
            {
                Producto productoEnLista = ListaProductosComprados.FirstOrDefault(p => p.Id == idProductoEliminar);

                if (productoEnLista != null)
                {
                    if (productoEnLista.Cantidad > 1)
                    {
                        productoEnLista.Cantidad--;
                    }
                    else
                    {
                        ListaProductosComprados.Remove(productoEnLista);
                    }
                    CargarProductosComprados();
                }
            }
        }
        protected void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
        private void CargarProductosComprados()
        {
            repProductosComprados.DataSource = ListaProductosComprados;
            repProductosComprados.DataBind();
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
        protected void btnConfirmarGuardarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaProductosComprados.Count > 0)
                {
                    ProductoNegocio negocioProducto = new ProductoNegocio();
                    CompraNegocio compraNegocio = new CompraNegocio();

                    Compra compra = new Compra
                    {
                        NumeroFactura = 0,
                        Facturada = false,
                        Activo = true
                    };

                    foreach (var producto in ListaProductosComprados)
                    {
                        DetalleCompra detalle = new DetalleCompra
                        {
                            IdArticulo = producto.Id,
                            Cantidad = producto.Cantidad
                        };

                        compra.DetalleCompra.Add(detalle);
                        negocioProducto.ActualizarStock(producto, -producto.Cantidad);
                    }

                    compraNegocio.Add(compra);
                    ListaProductosComprados.Clear();
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