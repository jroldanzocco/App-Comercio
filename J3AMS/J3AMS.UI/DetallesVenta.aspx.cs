using System;
using System.Data.SqlClient;
using System.Data;
using J3AMS.Dominio;
using System.Collections.Generic;

namespace J3AMS.UI
{
    public partial class DetallesVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int Id = Convert.ToInt32(Request.QueryString["Id"]);

                    CargarDetallesVenta(Id);
                }
                else
                {
                    Response.Redirect("BuscarVentas.aspx");
                }
            }
        }

        private void CargarDetallesVenta(int Id)
        {
            List<DetalleVenta> listDetallesVenta = new List<DetalleVenta>();

            string connectionString = "server=.\\SQLEXPRESS; database=J3AMS_DB; integrated security=true";
            string query = "SELECT DV.IdArticulo, DV.Cantidad FROM DetallesVentas DV INNER JOIN Ventas V ON DV.IdVenta = V.Id WHERE V.Id = @VentaId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VentaId", Id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var detalleVenta = new DetalleVenta
                            {
                                IdArticulo = (int)reader["IdArticulo"],
                                Cantidad = (int)reader["Cantidad"]
                            };

                            listDetallesVenta.Add(detalleVenta);
                        }
                    }
                }
            }

            gridDetallesVenta.DataSource = listDetallesVenta;
            gridDetallesVenta.DataBind();
        }
    }
}
