CREATE TABLE [dbo].[Products] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Description]   NVARCHAR (MAX) NOT NULL,
    [Brand]         NVARCHAR (MAX) NOT NULL,
    [UnitOfMeasure] NVARCHAR (MAX) NOT NULL,
    [Photo]         NVARCHAR (MAX) NOT NULL,
    [SupplierId]    INT            NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TABLE [dbo].[Suppliers] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [CNPJ]    NVARCHAR (MAX) NOT NULL,
    [Address] NVARCHAR (MAX) NOT NULL,
    [Phone]   NVARCHAR (MAX) NOT NULL,
    [CEP]     NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
);


GO

CREATE NONCLUSTERED INDEX [IX_Products_SupplierId]
    ON [dbo].[Products]([SupplierId] ASC);


GO

CREATE LOGIN [userdb]
    WITH PASSWORD = N'kinFbyleytlf|qJk?d6{{k|zmsFT7_&#$!~<enl4vedpdowg';


GO

CREATE USER [userdb] FOR LOGIN [userdb];


GO

ALTER ROLE [db_owner] ADD MEMBER [userdb];


GO

CREATE PROCEDURE dbo.ListProducts
AS
BEGIN
    SELECT ID, Description, Brand, UnitOfMeasure, Photo, SupplierId
    FROM dbo.Products;
END;

GO


INSERT INTO Products (Description, Brand, UnitOfMeasure, Photo, SupplierId)
VALUES 
    ('Camiseta', 'Nike', 'Unidade', 'caminho/para/foto1.jpg', 1),
    ('Calça Jeans', 'Levis', 'Unidade', 'caminho/para/foto2.jpg', 2),
    ('Tênis', 'Adidas', 'Unidade', 'caminho/para/foto3.jpg', 3),
    ('Mochila', 'JanSport', 'Unidade', 'caminho/para/foto4.jpg', 4),
    ('Boné', 'New Era', 'Unidade', 'caminho/para/foto5.jpg', 5);

INSERT INTO Suppliers (Name, CNPJ, Address, Phone)
VALUES 
    ('Fornecedor 1', '12.345.678/0001-01', 'Rua A, 123', '(11) 1234-5678'),
    ('Fornecedor 2', '98.765.432/0001-02', 'Rua B, 456', '(22) 9876-5432'),
    ('Fornecedor 3', '23.456.789/0001-03', 'Rua C, 789', '(33) 2345-6789'),
    ('Fornecedor 4', '45.678.901/0001-04', 'Rua D, 987', '(44) 5678-9012'),
    ('Fornecedor 5', '67.890.123/0001-05', 'Rua E, 654', '(55) 6789-0123');
