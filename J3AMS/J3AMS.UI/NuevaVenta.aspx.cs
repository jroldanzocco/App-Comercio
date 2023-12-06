using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class NuevaVenta : Page
    {
        private bool productoAgregado = false;
        private ClienteNegocio _clienteNegocio;
        private FacturaVentaNegocio _facturaVentaNegocio;
        private VentaNegocio _ventaNegocio;
        private ProductoNegocio _productoNegocio;
        private List<Producto> ListaProductosSeleccionados
        {
            get
            {
                if (Session["ListaProductosSeleccionados"] == null)
                {
                    Session["ListaProductosSeleccionados"] = new List<Producto>();
                }
                return (List<Producto>)Session["ListaProductosSeleccionados"];
            }
            set
            {
                Session["ListaProductosSeleccionados"] = value;
            }
        }
        private List<Producto> ProductosVendidos
        {
            get
            {
                if (Session["ProductosVendidos"] == null)
                {
                    Session["ProductosVendidos"] = new List<Producto>();
                }
                return (List<Producto>)Session["ProductosVendidos"];
            }
            set
            {
                Session["ProductosVendidos"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _clienteNegocio = new ClienteNegocio();
            _facturaVentaNegocio = new FacturaVentaNegocio();
            _ventaNegocio = new VentaNegocio();
            _productoNegocio = new ProductoNegocio();
            if (!IsPostBack)
            {
                CargarClientes();
                CargarProductos();
            }
        }
        private void CargarClientes()
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                List<Cliente> listaClientes = clienteNegocio.ObtenerClientes();

                ddlClientes.DataSource = listaClientes;
                ddlClientes.DataValueField = "Id";
                ddlClientes.DataTextField = "NombreCompleto";
                ddlClientes.DataBind();
                ddlClientes.Items.Insert(0, new ListItem("Seleccione un cliente", "0"));
            }
            catch (Exception ex)
            {
                Response.Write($"Error al cargar los clientes: {ex.Message}");
            }
        }
        private void CargarProductos()
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                List<Producto> listaProductos = productoNegocio.Listar();

                ddlProductos.DataSource = listaProductos;
                ddlProductos.DataValueField = "Id";
                ddlProductos.DataTextField = "Descripcion";
                ddlProductos.DataBind();
                ddlProductos.Items.Insert(0, new ListItem("Seleccione un producto", "0"));
            }
            catch (Exception ex)
            {
                Response.Write($"Error al cargar los productos: {ex.Message}");
            }
        }
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int idProducto = ObtenerIdProductoSeleccionado();
            Producto productoEnStock = ObtenerProductoPorId(idProducto);

            if (productoEnStock != null)
            {
                int cantidad = ObtenerCantidad();

                if (cantidad > 0 && productoEnStock.Stock >= cantidad)
                {
                    if (!ProductosVendidos.Any(p => p.Id == idProducto))
                    {
                        ProductosVendidos.Add(productoEnStock);
                        ddlClientes.Enabled = false;
                    }
                    else
                    {
                        Response.Write("El producto ya ha sido vendido.");
                        return;
                    }
                    productoEnStock.Cantidad = cantidad;
                    ListaProductosSeleccionados.Add(productoEnStock);
                    productoEnStock.Stock = productoEnStock.Stock - cantidad;
                    _productoNegocio.Update(productoEnStock);

                    CargarProductosSeleccionados();
                    productoAgregado = true;
                }
                else
                {
                    Response.Write("La cantidad solicitada supera el stock disponible.");
                }
            }
            else
            {
                Response.Write("Error al obtener información del producto desde la base de datos.");
            }
        }
        
        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productoAgregado)
            {
                ddlClientes.Enabled = false;
            }
            else
            {
                ddlClientes.Enabled = true;
            }
        }
        private void CargarProductosSeleccionados()
        {
            repProductosSeleccionados.DataSource = ListaProductosSeleccionados;
            repProductosSeleccionados.DataBind();
        }
        private int ObtenerIdProductoSeleccionado()
        {
            if (int.TryParse(ddlProductos.SelectedValue, out int idProducto))
            {
                return idProducto;
            }
            return 0;
        }
        private int ObtenerCantidad()
        {
            if (int.TryParse(txtCantidad.Text, out int cantidad))
            {
                return cantidad;
            }
            return 0;
        }
        private Producto ObtenerProductoPorId(int id)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            return negocio.ObtenerPorId(id);
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            ProductosVendidos.Clear();
            ListaProductosSeleccionados.Clear();
            ddlClientes.Enabled = true;
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (ProductosVendidos.Count != 0)
            {

            
            try
            {
                Cliente clienteSeleccionado = ObtenerClienteSeleccionado();

                if (clienteSeleccionado != null)
                {
                    Venta venta = new Venta();

                    foreach (Producto producto in ListaProductosSeleccionados)
                    {
                        DetalleVenta detalle = new DetalleVenta
                        {
                            IdArticulo = producto.Id,
                            Cantidad = producto.Cantidad,
                            PrecioUnitario = producto.PrecioVenta
                        };

                        venta.DetallesVenta.Add(detalle);
                    }

                    FacturaVenta facturaVenta = new FacturaVenta
                    {
                        IdCliente = clienteSeleccionado.Id,
                        Importe = CalcularMontoTotal(venta.DetallesVenta)
                    };

                    _facturaVentaNegocio.Add(facturaVenta, Session["usuario"].ToString());
                    _ventaNegocio.Add(venta);

                    LimpiarControles();
                    ProductosVendidos.Clear();
                    ListaProductosSeleccionados.Clear();

                    ddlClientes.Enabled = true;
                }
                else
                {
                    Response.Write("Seleccione un cliente antes de generar la factura.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error al generar la factura: {ex.Message}");
            }
            }
        }
        private Cliente ObtenerClienteSeleccionado()
        {
            Cliente clienteSeleccionado = null;

            if (ddlClientes.SelectedIndex > 0)
            {
                int idClienteSeleccionado = Convert.ToInt32(ddlClientes.SelectedValue);
                clienteSeleccionado = _clienteNegocio.Get(idClienteSeleccionado);
            }

            return clienteSeleccionado;
        }
        public decimal CalcularMontoTotal(List<DetalleVenta> detallesVenta)
        {
            decimal montoTotal = 0;
            foreach (DetalleVenta detalle in detallesVenta)
            {
                montoTotal += detalle.Cantidad * detalle.PrecioUnitario;
            }
            return montoTotal;
        }
        private void LimpiarControles()
        {
            ddlClientes.SelectedIndex = 0;
            ddlProductos.SelectedIndex = 0;
            txtCantidad.Text = string.Empty;
            repProductosSeleccionados.DataSource = null;
            repProductosSeleccionados.DataBind();
            productoAgregado = false;
        }
       
       
       
    }
}
