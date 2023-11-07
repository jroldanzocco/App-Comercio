using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class TipoNegocio : IABML<Tipo>
    {
        private readonly AccesoADatos _datos;

        public TipoNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Tipo> Listar()
        {
            var listTipos = new List<Tipo>();

            try
            {
                _datos.SetConsulta("SELECT Id, Descripcion FROM Tipos");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listTipos.Add(new Tipo()
                    {
                        Id = (int)_datos.Lector["Id"],
                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                    });
                }
                return listTipos;
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
