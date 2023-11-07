﻿using J3AMS.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3AMS.Negocio
{
    public class ProveedorNegocio : IABML<Proveedor>
    {
        private readonly AccesoADatos _datos;

        public ProveedorNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Proveedor> Listar()
        {
            var listProveedores = new List<Proveedor>();

            try
            {
                _datos.SetConsulta("SELECT ProveedorID, Nombre, Direccion, Telefono, Email FROM Proveedores");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProveedores.Add(new Proveedor()
                    {
                        Id = (int)_datos.Lector["ProveedorID"],
                        Nombre = _datos.Lector["Nombre"] as string ?? string.Empty,
                        Direccion = _datos.Lector["Direccion"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,

                    });
                }
                return listProveedores;
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
