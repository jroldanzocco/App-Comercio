using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class MarcaNegocio : IABML<Marca>
    {
        private readonly AccesoADatos _datos;

        public MarcaNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Marca> Listar(string id = "")
        {
            var listMarcas = new List<Marca>();

            try
            {
                _datos.SetConsulta("SELECT Id, Descripcion FROM Marcas");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listMarcas.Add(new Marca()
                    {
                        Id = (byte)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                    });
                }
                return listMarcas;
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
