using J3AMS.Dominio;
using System;
using System.Collections.Generic;

namespace J3AMS.Negocio
{
    public class ClienteNegocio : IABML<Cliente>
    {
        private readonly AccesoADatos _datos;
        public ClienteNegocio()
        {
            _datos = new AccesoADatos();
        }
        public List<Cliente> Listar(string id = "")
        {
            var listClientes = new List<Cliente>();

            try
            {
                _datos.SetConsulta("SELECT C.Id AS ClienteId, Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, Activo, PlazoPago, I.Id AS IvaId, I.PorcentajeIva AS Porcentaje, I.Descripcion AS CategoriaIva FROM Clientes C" +
                    "\r\nINNER JOIN CategoriasIva I ON IdCategoriaIva = I.Id");

                if (id != "")
                {
                    _datos.SetConsulta("SELECT C.Id AS ClienteId, Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, Activo, PlazoPago, I.Id AS IvaId, I.PorcentajeIva AS Porcentaje, I.Descripcion AS CategoriaIva FROM Clientes C" +
                    "\r\nINNER JOIN CategoriasIva I ON IdCategoriaIva = I.Id " +
                    "WHERE C.Id = @Id");
                    _datos.SetParametro("@Id", id);
                }

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    listClientes.Add(new Cliente()
                    {
                        Id = (int)_datos.Lector["ClienteId"],
                        Apellidos = _datos.Lector["Apellidos"] as string ?? string.Empty,
                        Nombres = _datos.Lector["Nombres"] as string ?? string.Empty,
                        DNI = _datos.Lector["DNI"] as string ?? string.Empty,
                        Domicilio = _datos.Lector["Domicilio"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Celular = _datos.Lector["Celular"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,
                        Plazo = (byte)_datos.Lector["PlazoPago"],
                        Activo = (bool)_datos.Lector["Activo"],
                        categoriaIva = new CategoriaIva()
                        {
                            Id = (byte)_datos.Lector["IvaId"],
                            Descripcion = _datos.Lector["CategoriaIva"] as string ?? string.Empty,
                            PorcentajeIva = (decimal)_datos.Lector["Porcentaje"]
                        }

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
        public void Add(Cliente newEntity)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("INSERT INTO Clientes(Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)" +
                    "\r\nVALUES(@Apellido, @Nombre, @DNI, @Domicilio, @Telefono, @Celular, @Email, @IdIva, @Plazo, 1)");
                datos.SetParametro("@Apellido", newEntity.Apellidos);
                datos.SetParametro("@Nombre", newEntity.Nombres);
                datos.SetParametro("@DNI", newEntity.DNI);
                datos.SetParametro("@Domicilio", newEntity.Domicilio);
                datos.SetParametro("@Telefono", newEntity.Telefono);
                datos.SetParametro("@Celular", newEntity.Celular);
                datos.SetParametro("@Email", newEntity.Email);
                datos.SetParametro("@IdIva", newEntity.categoriaIva.Id);
                datos.SetParametro("@Plazo", newEntity.Plazo);

                datos.EjecutarLectura();
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
        public void Delete(Cliente Entity)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetParametro("@id", Entity.Id);
                datos.SetConsulta("DELETE FROM Clientes WHERE Id = @id");
                datos.EjecutarLectura();

                Console.WriteLine("Cliente eliminado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el cliente.");
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void LogicDelete(Cliente Entity)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("UPDATE Clientes SET Activo = 0 WHERE id = @id");
                datos.SetParametro("@id", Entity.Id);
                datos.EjecutarLectura();
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
        public void Update(Cliente aux)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetConsulta("UPDATE Clientes SET Apellidos = @Apellido, Nombres = @Nombre, DNI = @Dni, Domicilio = @Domicilio, Telefono = @Telefono, Celular = @Celular, Email = @Email, IdCategoriaIva = @CategoriaIva, PlazoPago = @PlazoPago" +
                    "\r\nWHERE Id = @Id");
                datos.SetParametro("@Apellido", aux.Apellidos);
                datos.SetParametro("@Nombre", aux.Nombres);
                datos.SetParametro("@Dni", aux.DNI);
                datos.SetParametro("@Domicilio", aux.Domicilio);
                datos.SetParametro("@Telefono", aux.Telefono);
                datos.SetParametro("@Celular", aux.Celular);
                datos.SetParametro("@Email", aux.Email);
                datos.SetParametro("@CategoriaIva", aux.categoriaIva.Id);
                datos.SetParametro("@PlazoPago", aux.Plazo);
                datos.SetParametro("@Id", aux.Id);

                datos.EjecutarLectura();
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

        public Cliente Get(int id)
        {
            try
            {
                Cliente aux = null;

                _datos.SetConsulta("SELECT C.Id AS ClienteId, Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, Activo, PlazoPago, I.Id AS IvaId, I.PorcentajeIva AS Porcentaje, I.Descripcion AS CategoriaIva FROM Clientes C" +
                    "\r\nINNER JOIN CategoriasIva I ON IdCategoriaIva = I.Id " +
                    "WHERE C.Id = @Id");
                _datos.SetParametro("@Id", id);

                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    aux = new Cliente()
                    {
                        Id = (int)_datos.Lector["ClienteId"],
                        Apellidos = _datos.Lector["Apellidos"] as string ?? string.Empty,
                        Nombres = _datos.Lector["Nombres"] as string ?? string.Empty,
                        DNI = _datos.Lector["DNI"] as string ?? string.Empty,
                        Domicilio = _datos.Lector["Domicilio"] as string ?? string.Empty,
                        Telefono = _datos.Lector["Telefono"] as string ?? string.Empty,
                        Celular = _datos.Lector["Celular"] as string ?? string.Empty,
                        Email = _datos.Lector["Email"] as string ?? string.Empty,
                        Plazo = (byte)_datos.Lector["PlazoPago"],
                        Activo = (bool)_datos.Lector["Activo"],
                        categoriaIva = new CategoriaIva()
                        {
                            Id = (byte)_datos.Lector["IvaId"],
                            Descripcion = _datos.Lector["CategoriaIva"] as string ?? string.Empty,
                            PorcentajeIva = (decimal)_datos.Lector["Porcentaje"]
                        }

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

        public List<Cliente> ObtenerClientes()
        {
            var listaClientes = new List<Cliente>();
            try
            {
                _datos.SetConsulta("Select Id, Apellidos, Nombres From Clientes");
                _datos.EjecutarLectura();

                while (_datos.Lector.Read())
                {
                    var cliente = new Cliente
                    {
                        Id = (int)_datos.Lector["Id"],
                        Apellidos = _datos.Lector["Apellidos"].ToString(),
                        Nombres = _datos.Lector["Nombres"].ToString()
                    };
                    listaClientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes desde la base de datos", ex);
            }
            finally
            {
                _datos.CerrarConexion();
            }
            return listaClientes;
        }
    }
}
