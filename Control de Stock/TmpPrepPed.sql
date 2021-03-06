if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TmpPrepPed1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TmpPrepPed1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TmpPrepPed2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TmpPrepPed2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TmpPrepPed3]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TmpPrepPed3]
GO

CREATE TABLE [dbo].[TmpPrepPed1] (
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

CREATE TABLE [dbo].[TmpPrepPed2] (
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

CREATE TABLE [dbo].[TmpPrepPed3] (
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

