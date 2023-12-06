using J3AMS.Dominio;
using System;
using System.Collections.Generic;

namespace J3AMS.Negocio
{
    public class CategoriaIvaNegocio
    {
        private readonly AccesoADatos _datos;

        public CategoriaIvaNegocio()
        {
            _datos = new AccesoADatos();
        }

        public List<CategoriaIva> Listar()
        {
            var listIva = new List<CategoriaIva>();
            try
            {
                _datos.SetConsulta("SELECT Id, Descripcion, PorcentajeIva FROM CategoriasIva");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listIva.Add(new CategoriaIva()
                    {
                        Id = (byte)_datos.Lector["Id"],

                        Descripcion = _datos.Lector["Descripcion"] as string ?? string.Empty,
                        PorcentajeIva = (decimal)_datos.Lector["PorcentajeIva"]
                    });
                }

                return listIva;
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
