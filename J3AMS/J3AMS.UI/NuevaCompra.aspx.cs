﻿using J3AMS.Dominio;
using J3AMS.Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3AMS.UI
{
    public partial class NuevaCompra : Page
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
        private List<Producto> ProductosComprados
        {
            get
            {
                if (Session["ProductosComprados"] == null)
                {
                    Session["ProductosComprados"] = new List<Producto>();
                }
                return (List<Producto>)Session["ProductosComprados"];
            }
            set
            {
                Session["ProductosComprados"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedoress();
                CargarProductos();
            }
        }
        private void CargarProveedoress()
        {
            try
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                List<Proveedor> listaProveedores = proveedorNegocio.ObtenerProveedores();

                ddlProveedores.DataSource = listaProveedores;
                ddlProveedores.DataValueField = "Id";
                ddlProveedores.DataTextField = "NombreCompleto";
                ddlProveedores.DataBind();
                ddlProveedores.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
            }
            catch (Exception ex)
            {
                Response.Write($"Error al cargar los proveedores: {ex.Message}");
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

            if (!ProductosComprados.Any(p => p.Id == idProducto))
            {
                Producto producto = ObtenerProductoPorId(idProducto);
                ProductosComprados.Add(producto);
                ddlProveedores.Enabled = false;
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
        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productoAgregado)
            {
                ddlProveedores.Enabled = false;
            }
            else
            {
                ddlProveedores.Enabled = true;
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
        protected void btnCargarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedorSeleccionado = ObtenerProveedorSeleccionado();

                if (proveedorSeleccionado != null)
                {
                    Compra compra = new Compra();

                    foreach (Producto producto in ListaProductosSeleccionados)
                    {
                        DetalleCompra detalle = new DetalleCompra
                        {
                            IdArticulo = producto.Id,
                            Cantidad = producto.Cantidad,
                            PrecioUnitario = producto.PrecioVenta
                        };

                        compra.DetalleCompra.Add(detalle);
                    }

                    FacturaCompra facturaCompra = new FacturaCompra
                    {
                        IdProveedor = proveedorSeleccionado.Id,
                        Importe = CalcularMontoTotal(compra.DetalleCompra)
                    };

                    GuardarFacturaCompraEnBaseDeDatos(facturaCompra);
                    GuardarCompraEnBaseDeDatos(compra);

                    LimpiarControles();
                    ProductosComprados.Clear();
                    ListaProductosSeleccionados.Clear();

                    ddlProveedores.Enabled = true;
                }
                else
                {
                    Response.Write("Seleccione un proveedor antes de cargar la factura.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Error al cargar la factura: {ex.Message}");
            }
        }
        private Proveedor ObtenerProveedorSeleccionado()
        {
            Proveedor proveedorSeleccionado = null;

            if (ddlProveedores.SelectedIndex > 0)
            {
                int idProveedorSeleccionado = Convert.ToInt32(ddlProveedores.SelectedValue);
                proveedorSeleccionado = ObtenerProveedorPorId(idProveedorSeleccionado);
            }

            return proveedorSeleccionado;
        }
        public decimal CalcularMontoTotal(List<DetalleCompra> detalleCompra)
        {
            decimal montoTotal = 0;
            foreach (DetalleCompra detalle in detalleCompra)
            {
                montoTotal += detalle.Cantidad * detalle.PrecioUnitario;
            }
            return montoTotal;
        }
        private void LimpiarControles()
        {
            ddlProveedores.SelectedIndex = 0;
            ddlProductos.SelectedIndex = 0;
            txtCantidad.Text = string.Empty;
            repProductosSeleccionados.DataSource = null;
            repProductosSeleccionados.DataBind();
        }
        public Proveedor ObtenerProveedorPorId(int idProveedor)
        {
            Proveedor proveedorEncontrado = null;
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=J3AMS_DB; integrated security=true"))
                {
                    conexion.Open();
                    string consultaSql = "SELECT Id, RazonSocial, NombreFantasia FROM Proveedores WHERE Id = @Id";
                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        comando.Parameters.AddWithValue("@Id", idProveedor);
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                proveedorEncontrado = new Proveedor
                                {
                                    Id = (int)lector["Id"],
                                    RazonSocial = lector["RazonSocial"].ToString(),
                                    NombreFantasia = lector["NombreFantasia"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener proveedor por ID desde la base de datos", ex);
            }
            return proveedorEncontrado;
        }
        public void GuardarFacturaCompraEnBaseDeDatos(FacturaCompra facturaCompra)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=J3AMS_DB; integrated security=true"))
                {
                    conexion.Open();

                    string consultaSql = "INSERT INTO FacturasCompras (IdProveedor, Importe, FechaEmision, Comprador, Activo) " +
                                         "VALUES (@IdProveedor, @Importe, GETDATE(), @Comprador, 1)";

                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdProveedor", facturaCompra.IdProveedor);
                        comando.Parameters.AddWithValue("@Importe", facturaCompra.Importe);
                        comando.Parameters.AddWithValue("@Comprador", Session["usuario"].ToString());

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la factura en la base de datos", ex);
            }
        }
        public void GuardarCompraEnBaseDeDatos(Compra newEntity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {

                datos.SetConsulta("SELECT MAX(Numero) AS UltimaFactura FROM FacturasCompras ");
                datos.EjecutarLectura();

                int IdCompra = 0;

                if (datos.Lector.Read())
                {
                    IdCompra = (int)datos.Lector["UltimaFactura"];
                }


                if (IdCompra > 0)
                {
                    foreach (var detalle in newEntity.DetalleCompra)
                    {
                        AccesoADatos datosDetalle = new AccesoADatos();

                        datosDetalle.SetConsulta("INSERT INTO DetallesCompras (IdCompra, IdArticulo, Cantidad, PrecioUnitario) VALUES (@IdCompra, @IdArticulo, @Cantidad, @Precio)");

                        datosDetalle.SetParametro("@IdCompra", IdCompra);
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
