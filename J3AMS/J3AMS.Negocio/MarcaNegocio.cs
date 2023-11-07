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
        public List<Marca> Listar()
        {
            var listMarcas = new List<Marca>();

            try
            {
                _datos.SetConsulta("SELECT MarcaID, Nombre FROM Marcas");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listMarcas.Add(new Marca()
                    {
                        Id = (int)_datos.Lector["MarcaID"],
                        Nombre = _datos.Lector["Nombre"] as string ?? string.Empty,
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
