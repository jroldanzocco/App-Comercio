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
                _datos.SetConsulta("SELECT Id, Apellidos, Nombres, Domicilio, Telefono, Celular, Email FROM Clientes");
                _datos.EjecutarLectura();

                while(_datos.Lector.Read())
                {
                    listClientes.Add(new Cliente()
                    {
                        Id = (int)_datos.Lector["Id"],
                        Apellidos = _datos.Lector["Apellidos"] as string ?? string.Empty,
                        Nombres = _datos.Lector["Nombres"] as string ?? string.Empty,
                        Domicilio = _datos.Lector["Domicilio"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Celular = _datos.Lector["Celular"] as string ?? string.Empty,
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
