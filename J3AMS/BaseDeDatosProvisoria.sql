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
	Activo BIT NOT NULL DEFAULT 1
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
	Activo BIT NOT NULL DEFAULT 1
)
CREATE TABLE Marcas (
    Id TINYINT PRIMARY KEY IDENTITY (1, 1),
    Descripcion NVARCHAR(255) NOT NULL,
	Activo BIT NOT NULL DEFAULT 1
)
CREATE TABLE Tipos (
    Id TINYINT PRIMARY KEY IDENTITY (1, 1),
    Descripcion NVARCHAR(255) NOT NULL,
	Activo BIT NOT NULL DEFAULT 1
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
	Activo BIT NOT NULL DEFAULT 1
)
CREATE TABLE FacturasCompras (
	Numero INT PRIMARY KEY IDENTITY (1, 1),
	IdProveedor INT FOREIGN KEY REFERENCES Proveedores(Id),
	Importe MONEY NOT NULL,
	Activo BIT NOT NULL DEFAULT 1
) 
CREATE TABLE FacturasVentas (
	Numero INT PRIMARY KEY IDENTITY (1, 1),
	IdCliente INT FOREIGN KEY REFERENCES Clientes(Id),
	Importe MONEY NOT NULL,
	Activo BIT NOT NULL DEFAULT 1
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
	Activo BIT NOT NULL DEFAULT 1
)
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    UserName NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
	IdRol TINYINT DEFAULT 2
)
--Marcas
INSERT INTO Marcas (Descripcion)
VALUES ('Marca 1');
INSERT INTO Marcas (Descripcion)
VALUES ('Marca 2');
INSERT INTO Marcas (Descripcion)
VALUES ('Marca 3');
INSERT INTO Marcas (Descripcion)
VALUES ('Marca 4');
INSERT INTO Marcas (Descripcion)
VALUES ('Marca 5');
--Tipos
INSERT INTO Tipos(Descripcion)
VALUES ('Tipo 1');
INSERT INTO Tipos (Descripcion)
VALUES ('Tipo 2');
INSERT INTO Tipos (Descripcion)
VALUES ('Tipo 3');
INSERT INTO Tipos (Descripcion)
VALUES ('Tipo 4');
INSERT INTO Tipos (Descripcion, Activo)
VALUES ('Tipo 5', 1);
--Categoria IVA
INSERT INTO CategoriasIva (Descripcion, PorcentajeIva)
VALUES ('IVA General', 21.0);
INSERT INTO CategoriasIva (Descripcion, PorcentajeIva)
VALUES ('IVA Reducido', 10.5);
--Proveedores
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago)
VALUES ('Proveedor 1 Razón Social', 'Proveedor 1 Nombre Fantasía', '12345678901', 'Domicilio 1', '1234567890', '9876543210', 'proveedor1@email.com', 1, 30);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago)
VALUES ('Proveedor 2 Razón Social', 'Proveedor 2 Nombre Fantasía', '98765432109', 'Domicilio 2', '9876543210', '1234567890', 'proveedor2@email.com', 2, 45);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago)
VALUES ('Proveedor 3 Razón Social', 'Proveedor 3 Nombre Fantasía', '78901234567', 'Domicilio 3', '5555555555', '6666666666', 'proveedor3@email.com', 1, 60);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago)
VALUES ('Proveedor 4 Razón Social', 'Proveedor 4 Nombre Fantasía', '34567890123', 'Domicilio 4', '4444444444', '7777777777', 'proveedor4@email.com', 2, 30);
INSERT INTO Proveedores (RazonSocial, NombreFantasia, CUIT, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago)
VALUES ('Proveedor 5 Razón Social', 'Proveedor 5 Nombre Fantasía', '90123456789', 'Domicilio 15', '3333333333', '8888888888', 'proveedor5@email.com', 1, 45);
--Clientes
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('López', 'Juan', '12345678', 'Calle 123', '555-1234', '999-5678', 'juan@email.com', 1, 30, 1);
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Martínez', 'Ana', '98765432', 'Avenida 456', '555-5678', '999-8765', 'ana@email.com', 2, 15, 1);
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Gómez', 'Carlos', '34567890', 'Calle 789', '555-9876', '999-4321', 'carlos@email.com', 2, 45, 1);
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Rodríguez', 'Laura', '56789012', 'Avenida 012', '555-3456', '999-1234', 'laura@email.com', 1, 60, 1);
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, IdCategoriaIva, PlazoPago, Activo)
VALUES ('Pérez', 'Miguel', '09876543', 'Calle 234', '555-6789', '999-2345', 'miguel@email.com', 2, 30, 1);
--Usuarios
INSERT INTO Usuarios (UserName, Password, IdRol)
VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f',1);
INSERT INTO Usuarios (UserName, Password)
VALUES ('test', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08');
--PARA ALTA PRODUCTO
INSERT INTO Productos (Descripcion, IdTipo, IdMarca, IdProveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo)
VALUES ('Pera', 1, 1, 1, 1, 2, 10, 0)
INSERT INTO Productos (Descripcion, IdTipo, IdMarca, IdProveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo)
VALUES ('Durazno', 1, 1, 1, 1, 2, 10, 0)
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
SELECT * FROM Usuarios
--PARA ALTA USUARIO
INSERT INTO Clientes (Apellidos, Nombres, DNI, Domicilio, Telefono, Celular, Email, CategoriaIva, PlazoPago)
VALUES (@Descripcion, @Nombres, @DNI, @Domicilio, @Telefono, @Celular, @Email, @CategoriaIva, @PlazoPago)
--PARA ALTA USUARIO
INSERT INTO Usuarios (UserName,Password)
VALUES (@user, @pass)