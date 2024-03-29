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

