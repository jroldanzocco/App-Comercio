CREATE DATABASE J3AMS;

USE J3AMS;

CREATE TABLE Marca (
    Id INT PRIMARY KEY,
    Descripcion NVARCHAR(255)
);

CREATE TABLE Articulo (
    Codigo INT PRIMARY KEY,
    Descripcion NVARCHAR(255),
    Tipo NVARCHAR(255),
    MarcaId INT,
    Proveedor NVARCHAR(255),
    Stock INT,
    FOREIGN KEY (MarcaId) REFERENCES Marca(Id)
);


INSERT INTO Marca (Id, Descripcion)
VALUES (1, 'Coca Cola');
INSERT INTO Marca (Id, Descripcion)
VALUES (2, 'Pepsi');

INSERT INTO Articulo (Codigo, Descripcion, Tipo, MarcaId, Proveedor, Stock)
VALUES (101, 'Lata chica', 'Lata', 1, 'The Coca-Cola Company', 50);
INSERT INTO Articulo (Codigo, Descripcion, Tipo, MarcaId, Proveedor, Stock)
VALUES (102, 'Botella grande', 'Botella', 2, 'PepsiCo', 75);

Select * From Articulo A
Inner Join Marca M On A.MarcaId = M.Id