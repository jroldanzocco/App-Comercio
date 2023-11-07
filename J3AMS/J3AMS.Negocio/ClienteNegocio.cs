using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class ClienteNegocio : IABML<Cliente>
    {
        private readonly AccesoADatos _datos;

        public ClienteNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Cliente> Listar()
        {
            var listClientes = new List<Cliente>();

            try
            {
                _datos.SetConsulta("SELECT ClienteID, Nombre, Direccion, Telefono, Email FROM Clientes");
                _datos.EjecutarLectura();

                while(_datos.Lector.Read())
                {
                    listClientes.Add(new Cliente()
                    {
                        Id = (int)_datos.Lector["ClienteID"],
                        Nombre = _datos.Lector["Nombre"] as string ?? string.Empty,
                        Direccion = _datos.Lector["Direccion"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,

                    });
                }
                return listClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.CerrarConexion();
            }

        }
    }
}
