CREATE TABLE [dbo].[TmpExped4] (
	[NroOV] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NroLinea] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TipoLinea] [int] NOT NULL ,
	[EstLinea] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Lote] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Desc1] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Desc2] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Almacen] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantOrden] [numeric](20, 8) NOT NULL ,
	[CantPrep] [numeric](20, 8) NOT NULL ,
	[Producto] [numeric](1, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpOArmado4] (
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Desc1] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Desc2] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CantOrden] [numeric](20, 8) NOT NULL ,
	[CantPrep] [numeric](20, 8) NOT NULL ,
	[Stock] [numeric](20, 8) NULL ,
	[Estante] [varchar] (6) COLLATE Latin1_General_BIN NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpPrepPed4] (
	[NroOV] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NroLinea] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TipoLinea] [int] NOT NULL ,
	[EstLinea] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Desc1] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Desc2] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Almacen] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantOrden] [numeric](20, 8) NOT NULL ,
	[CantPrep] [numeric](20, 8) NOT NULL ,
	[CantActual] [numeric](20, 8) NOT NULL ,
	[Stock] [numeric](20, 8) NULL ,
	[Producto] [numeric](1, 0) NULL ,
	[Estante] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cliente] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NomCli] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpRecep4] (
	[NroOC] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PaisOrigen] [char] (11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantRec] [numeric](20, 8) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpExped5] (
	[NroOV] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NroLinea] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TipoLinea] [int] NOT NULL ,
	[EstLinea] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Lote] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Desc1] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Desc2] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Almacen] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantOrden] [numeric](20, 8) NOT NULL ,
	[CantPrep] [numeric](20, 8) NOT NULL ,
	[Producto] [numeric](1, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpOArmado5] (
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Desc1] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Desc2] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CantOrden] [numeric](20, 8) NOT NULL ,
	[CantPrep] [numeric](20, 8) NOT NULL ,
	[Stock] [numeric](20, 8) NULL ,
	[Estante] [varchar] (6) COLLATE Latin1_General_BIN NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpPrepPed5] (
	[NroOV] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NroLinea] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TipoLinea] [int] NOT NULL ,
	[EstLinea] [char] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Desc1] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Desc2] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Almacen] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantOrden] [numeric](20, 8) NOT NULL ,
	[CantPrep] [numeric](20, 8) NOT NULL ,
	[CantActual] [numeric](20, 8) NOT NULL ,
	[Stock] [numeric](20, 8) NULL ,
	[Producto] [numeric](1, 0) NULL ,
	[Estante] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cliente] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NomCli] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TmpRecep5] (
	[NroOC] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PaisOrigen] [char] (11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantRec] [numeric](20, 8) NOT NULL 
) ON [PRIMARY]
GO


