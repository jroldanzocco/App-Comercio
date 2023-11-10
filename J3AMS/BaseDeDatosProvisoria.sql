USE MASTER
GO
CREATE DATABASE J3AMS_DB
GO
USE J3AMS_DB
GO
CREATE TABLE CategoriasIva (
    Id TINYINT PRIMARY KEY IDENTITY (1, 1),
    Descripcion NVARCHAR(255) NOT NULL,
    PorcentajeIva DECIMAL(3,1) NOT NULL
)
CREATE TABLE Proveedores (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    RazonSocial NVARCHAR(255) NOT NULL,
    NombreFantasia NVARCHAR(255) NULL,
	CUIT NVARCHAR(255) NOT NULL UNIQUE,
	Domicilio NVARCHAR(255),
	Telefono NVARCHAR(255),
	Celular NVARCHAR(255),
	Email NVARCHAR(255),
    IdCategoriaIva TINYINT NOT NULL foreign key references CategoriasIva(Id),
    PlazoPago TINYINT NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Apellidos NVARCHAR(255) NOT NULL,
    Nombres NVARCHAR(255) NOT NULL,
    DNI NVARCHAR(255) NOT NULL UNIQUE,
	Domicilio NVARCHAR(255),
	Telefono NVARCHAR(255),
	Celular NVARCHAR(255),
	Email NVARCHAR(255),
    IdCategoriaIva TINYINT NOT NULL foreign key references CategoriasIva(Id),
    PlazoPago TINYINT NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Marcas (
    Id TINYINT PRIMARY KEY IDENTITY (1, 1),
    Descripcion NVARCHAR(255) NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Tipos (
    Id TINYINT PRIMARY KEY IDENTITY (1, 1),
    Descripcion NVARCHAR(255) NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Productos (
	Id INT PRIMARY KEY IDENTITY (1, 1),
    Descripcion NVARCHAR(255) NOT NULL,
    IdTipo TINYINT NULL foreign key references Tipos(Id),
    IdMarca TINYINT NULL foreign key references Marcas(Id),
    IdProveedor INT NULL foreign key references Proveedores(Id),
	PrecioCosto MONEY NOT NULL,
	PrecioVenta MONEY NOT NULL,
    Stock INT NOT NULL,
    StockMinimo INT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE FacturasCompras (
	Numero INT PRIMARY KEY IDENTITY (1, 1),
	IdProveedor INT FOREIGN KEY REFERENCES Proveedores(Id),
	Importe MONEY NOT NULL,
	Activo BIT NOT NULL
) 
CREATE TABLE FacturasVentas (
	Numero INT PRIMARY KEY IDENTITY (1, 1),
	IdCliente INT FOREIGN KEY REFERENCES Clientes(Id),
	Importe MONEY NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Compras (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	IdArticulo INT NOT NULL foreign key references Productos(Id),
	Cantidad INT NOT NULL,
	NumeroFactura INT NOT NULL foreign key references FacturasCompras(Numero),
	Facturada BIT NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Ventas (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Articulo INT NOT NULL foreign key references Productos(Id),
	Cantidad INT NOT NULL,
	NumeroFactura INT NOT NULL foreign key references FacturasVentas(Numero),
	Facturada BIT NOT NULL,
	Activo BIT NOT NULL
)
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    NombreUsuario NVARCHAR(255) NOT NULL UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL
)
--Marcas
INSERT INTO Marcas (Descripcion, Activo)
VALUES ('Marca 1', 1);
INSERT INTO Marcas (Descripcion, Activo)
VALUES ('Marca 2', 1);
INSERT INTO Marcas (Descripcion, Activo)
VALUES ('Marca 3', 1);
INSERT INTO Marcas (Descripcion, Activo)
VALUES ('Marca 4', 1);
INSERT INTO Marcas (Descripcion, Activo)
VALUES ('Marca 5', 1);
--Tipos
INSERT INTO Tipos(Descripcion, Activo)
VALUES ('Tipo 1', 1);
INSERT INTO Tipos (Descripcion, Activo)
VALUES ('Tipo 2', 1);
INSERT INTO Tipos (Descripcion, Activo)
VALUES ('Tipo 3', 1);
INSERT INTO Tipos (Descripcion, Activo)
VALUES ('Tipo 4', 1);
INSERT INTO Tipos (Descripcion, Activo)
VALUES ('Tipo 5', 1);
--Categoria IVA
INSERT INTO CategoriasIva (Descripcion, PorcentajeIva)
VALUES ('IVA General', 21.0);
INSERT INTO CategoriasIva (Descripcion, PorcentajeIva)
VALUES ('IVA Reducido', 10.5);
--Proveedores
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Proveedor 1 Razón Social', 'Proveedor 1 Nombre Fantasía', '12345678901', 'Domicilio 1', '1234567890', '9876543210', 'proveedor1@email.com', 1, 30, 1);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Proveedor 2 Razón Social', 'Proveedor 2 Nombre Fantasía', '98765432109', 'Domicilio 2', '9876543210', '1234567890', 'proveedor2@email.com', 2, 45, 1);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Proveedor 3 Razón Social', 'Proveedor 3 Nombre Fantasía', '78901234567', 'Domicilio 3', '5555555555', '6666666666', 'proveedor3@email.com', 1, 60, 1);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Proveedor 4 Razón Social', 'Proveedor 4 Nombre Fantasía', '34567890123', 'Domicilio 4', '4444444444', '7777777777', 'proveedor4@email.com', 2, 30, 1);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Proveedor 5 Razón Social', 'Proveedor 5 Nombre Fantasía', '90123456789', 'Domicilio 15', '3333333333', '8888888888', 'proveedor5@email.com', 1, 45, 1);
--PARA ALTA PRODUCTO
INSERT INTO Productos (Descripcion, IdTipo, IdMarca, IdProveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, Activo)
VALUES ('Pera', 1, 1, 1, 1, 2, 10, 0, 1)
INSERT INTO Productos (Descripcion, IdTipo, IdMarca, IdProveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, Activo)
VALUES ('Durazno', 1, 1, 1, 1, 2, 10, 0, 1)
--PARA CONSULTA PRODUCTO
SELECT 
	A.Id,
	A.Codigo,
	A.Descripcion,
	T.Descripcion AS Tipo,
	M.Descripcion AS Marca,
	P.NombreFantasia AS Proveedor,
	A.PrecioCosto, 
	A.Stock, 
	A.StockMinimo
FROM Productos A
left join Marcas M on A.IdMarca = M.Id
left join Tipos T on A.IdTipo = T.Id
left join Proveedores P on A.IdProveedor = P.Id
--CONSULTAS
SELECT * FROM Marcas
SELECT * FROM Tipos
SELECT * FROM Proveedores
SELECT * FROM Productos
SELECT * FROM Clientes
--PARA ALTA USUARIO
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, CategoriaIva, PlazoPago,Activo)
VALUES (@Descripcion, @Nombres, @DNI, @Domicilio, @Telefono, @Celular, @Email, @CategoriaIva, @PlazoPago, 1)