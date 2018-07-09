USE [master];
GO

CREATE DATABASE [VendasDb];
GO

USE [VendasDb];
GO

CREATE TABLE [dbo].[Usuario]
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
		[Usuario] VARCHAR(50) NOT NULL, 
		[Senha] VARCHAR(50) NOT NULL
	);
GO

CREATE TABLE [dbo].[Produto]
	(
		[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
		[Descricao] VARCHAR(50) NOT NULL, 
		[idUsuario] INT NULL
	)
GO

INSERT 
	INTO [dbo].[Usuario]([Usuario], [Senha])
	VALUES ('tiagopariz', '123456'), 
		   ('jonatanvies', '789012'), 
		   ('alineloas', '345678');
GO

INSERT
	INTO [dbo].[Produto]([Descricao], [idUsuario])
	VALUES ('Pente', 1),
		   ('Escova', 2),
		   ('Bolinho', 2),
		   ('Laranja', 3),
		   ('Maçã', 1),
		   ('Pepsi', 2),
		   ('Fanta', 2),
		   ('Tekitos', 3),
		   ('Prato', 1),
		   ('Sabão', 3),
		   ('Mouse', 1),
		   ('Hub', 3);
GO