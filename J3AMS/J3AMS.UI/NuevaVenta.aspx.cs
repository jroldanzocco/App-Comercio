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

            if (!ProductosVendidos.Any(p => p.Id == idProducto))
            {
                Producto producto = ObtenerProductoPorId(idProducto);
                ProductosVendidos.Add(producto);
                ddlClientes.Enabled = false;
            }
            else
            {
                Response.Write("El producto ya ha sido vendido.");
                return;
            }

            int cantidad = ObtenerCantidad();

            if (cantidad > 0)
            {
                Producto producto = ObtenerProductoPorId(idProducto);
                producto.Cantidad = cantidad;
                ListaProductosSeleccionados.Add(producto);
                CargarProductosSeleccionados();
            }
            productoAgregado = true;
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
            Response.Redirect("PaginaPrincipal.aspx");
        }
        protected void btnGenerarFactura_Click(object sender, EventArgs e)
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

                    GuardarFacturaVentaEnBaseDeDatos(facturaVenta);
                    GuardarVentaEnBaseDeDatos(venta);

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
        private Cliente ObtenerClienteSeleccionado()
        {
            Cliente clienteSeleccionado = null;

            if (ddlClientes.SelectedIndex > 0)
            {
                int idClienteSeleccionado = Convert.ToInt32(ddlClientes.SelectedValue);
                clienteSeleccionado = ObtenerClientePorId(idClienteSeleccionado);
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
        }
        public Cliente ObtenerClientePorId(int idCliente)
        {
            Cliente clienteEncontrado = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=J3AMS_DB; integrated security=true"))
                {
                    conexion.Open();
                    string consultaSql = "SELECT Id, Nombres, Apellidos FROM Clientes WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", idCliente);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                clienteEncontrado = new Cliente
                                {
                                    Id = (int)lector["Id"],
                                    Apellidos = lector["Apellidos"].ToString(),
                                    Nombres = lector["Nombres"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cliente por ID desde la base de datos", ex);
            }
            return clienteEncontrado;
        }
        public void GuardarFacturaVentaEnBaseDeDatos(FacturaVenta facturaVenta)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=J3AMS_DB; integrated security=true"))
                {
                    conexion.Open();

                    string consultaSql = "INSERT INTO FacturasVentas (IdCliente, Importe, FechaEmision, Activo) " +
                                         "VALUES (@IdCliente, @Importe, GETDATE(), 1)";

                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdCliente", facturaVenta.IdCliente);
                        comando.Parameters.AddWithValue("@Importe", facturaVenta.Importe);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la factura en la base de datos", ex);
            }
        }
        public void GuardarVentaEnBaseDeDatos(Venta newEntity)
        {
                AccesoADatos datos = new AccesoADatos();
            try
            {

                datos.SetConsulta("SELECT MAX(Numero) AS UltimaFactura FROM FacturasVentas ");
                datos.EjecutarLectura();

                int IdVenta = 0;

                if(datos.Lector.Read())
                {
                    IdVenta = (int)datos.Lector["UltimaFactura"];
                }


                if(IdVenta > 0)
                {
                    foreach (var detalle in newEntity.DetallesVenta)
                    {
                        AccesoADatos datosDetalle = new AccesoADatos();

                        datosDetalle.SetConsulta("INSERT INTO DetallesVentas (IdVenta, IdArticulo, Cantidad, PrecioUnitario) VALUES (@IdVenta, @IdArticulo, @Cantidad, @Precio)");

                        datosDetalle.SetParametro("@IdVenta", IdVenta);
                        datosDetalle.SetParametro("@IdArticulo", detalle.IdArticulo);
                        datosDetalle.SetParametro("@Cantidad", detalle.Cantidad);
                        datosDetalle.SetParametro("@Precio", detalle.PrecioUnitario);

                        datosDetalle.EjecutarLectura();
                        datosDetalle.CerrarConexion();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
