using J3.AMS.Common;
using J3AMS.Dominio;
using System;
using System.Collections.Generic;

namespace J3AMS.Negocio
{
    public class ProveedorNegocio : IABML<Proveedor>
    {
        private readonly AccesoADatos _datos;

        public ProveedorNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Proveedor> Listar(string id = "")
        {
            var listProveedores = new List<Proveedor>();

            try
            {
                var query = "SELECT Id, " +
                            "RazonSocial, " +
                            "NombreFantasia, " +
                            "CUIT, " +
                            "Domicilio, " +
                            "Telefono, " +
                            "Celular, " +
                            "Email, " +
                            "IdCategoriaIva, " +
                            "PlazoPago, " +
                            "Activo " +
                            "FROM Proveedores";

                _datos.SetConsulta(query);
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listProveedores.Add(new Proveedor()
                    {
                        Id = (int)_datos.Lector["Id"],
                        RazonSocial = _datos.Lector["RazonSocial"] as string ?? string.Empty,
                        NombreFantasia = _datos.Lector["NombreFantasia"] as string ?? string.Empty,
                        CUIT = _datos.Lector["CUIT"] as string ?? string.Empty,
                        Domicilio = _datos.Lector["Domicilio"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Celular = _datos.Lector["Celular"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,
                        IdCategoriaIva = (byte)_datos.Lector["IdCategoriaIva"],
                        PlazoPago = (byte)_datos.Lector["PlazoPago"],
                        Activo = (bool)_datos.Lector["Activo"]
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


        public void Add(Proveedor newEntity)
        {

            try
            {
                if (ValidatorsDA.TryValidateModel(newEntity))
                {
                    _datos.SetConsulta("INSERT INTO Proveedores(RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo) " +
                                       "VALUES(@Razon, @Nombre, @CUIT, @Domicilio, @Telefono, @Celular, @Email, @Iva, @Plazo, 1)");
                    _datos.SetParametro("@Razon", newEntity.RazonSocial);
                    _datos.SetParametro("@Nombre", newEntity.NombreFantasia);
                    _datos.SetParametro("@CUIT", newEntity.CUIT);
                    _datos.SetParametro("@Domicilio", newEntity.Domicilio);
                    _datos.SetParametro("@Telefono", newEntity.Telefono);
                    _datos.SetParametro("@Celular", newEntity.Telefono);
                    _datos.SetParametro("@Email", newEntity.Telefono);
                    _datos.SetParametro("@Iva", newEntity.CategoriaIva.Id);
                    _datos.SetParametro("@Plazo", newEntity.PlazoPago);
                    _datos.SetParametro("@Activo", true);
                    _datos.EjecutarLectura();
                }
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
        public void Delete(int id)
        {
            try
            {
                _datos.SetParametro("@id", id);
                _datos.SetConsulta("DELETE FROM Proveedores WHERE Id = @id");
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

        public void LogicDelete(int id)
        {
            try
            {
                _datos.SetConsulta("UPDATE Proveedores SET Activo = 0 WHERE id = @idDelete");
                _datos.SetParametro("@idDelete", id);
                _datos.EjecutarLectura();
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

        public Proveedor Get(int id)
        {


            try
            {
                Proveedor aux = null;
                _datos.SetConsulta("SELECT P.Id, RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, C.Id IdCategoriaIva, C.Descripcion Iva, C.PorcentajeIva, PlazoPago, Activo " +
                                   "FROM Proveedores P LEFT JOIN CategoriasIva C ON P.IdCategoriaIva = C.Id WHERE P.Id = @ID");

                _datos.SetParametro("ID", id);

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    aux = new Proveedor()
                    {
                        Id = (int)_datos.Lector["Id"],
                        RazonSocial = _datos.Lector["RazonSocial"] as string ?? string.Empty,
                        NombreFantasia = _datos.Lector["NombreFantasia"] as string ?? string.Empty,
                        CUIT = _datos.Lector["CUIT"] as string ?? string.Empty,
                        Domicilio = _datos.Lector["Domicilio"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Celular = _datos.Lector["Celular"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,
                        CategoriaIva = new CategoriaIva()
                        {
                            Id = (byte)_datos.Lector["IdCategoriaIva"],
                            Descripcion = _datos.Lector["Iva"] as string ?? string.Empty,
                            PorcentajeIva = (decimal)_datos.Lector["PorcentajeIva"],
                        },
                        PlazoPago = (byte)_datos.Lector["PlazoPago"],
                        Activo = (bool)_datos.Lector["Activo"],
                    };

                }
                return aux;
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

        public void Update(Proveedor entity)
        {
            try
            {
                _datos.SetConsulta("UPDATE Proveedores SET RazonSocial = @RazonSocial, NombreFantasia = @Nombre, " +
                            "CUIT = @CUIT, Domicilio = @Domicilio, Telefono = @Telefono, " +
                            "Celular = @Celular, Email = @Email, IdCategoriaIva = @IdIva, PlazoPago = @PlazoPago " +
                            "WHERE Id = @ID");

                _datos.SetParametro("@ID", entity.Id);
                _datos.SetParametro("@RazonSocial", entity.RazonSocial);
                _datos.SetParametro("@Nombre", entity.NombreFantasia);
                _datos.SetParametro("@CUIT", entity.CUIT);
                _datos.SetParametro("@Domicilio", entity.Domicilio);
                _datos.SetParametro("@Telefono", entity.Telefono);
                _datos.SetParametro("@Celular", entity.Celular);
                _datos.SetParametro("@Email", entity.Email);
                _datos.SetParametro("@IdIva", entity.CategoriaIva.Id);
                _datos.SetParametro("@PlazoPago", entity.PlazoPago);

                _datos.EjecutarLectura();
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
