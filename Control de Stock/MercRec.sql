if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MercRec]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MercRec]
GO

CREATE TABLE [dbo].[MercRec] (
	[NroOC] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NroLinea] [char] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Codigo] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CantRec] [numeric](20, 8) NOT NULL ,
	[FechaRec] [datetime] NOT NULL ,
	[Despacho] [char] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CostoUnitLoc] [numeric](28, 8) NOT NULL ,
	[CostoUnitExp] [numeric](28, 8) NOT NULL ,
	[PrecioCpra] [numeric](28, 8) NOT NULL ,
	[MonedaCpra] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DescMonedaCpra] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SobreCostoLoc] [numeric](14, 8) NOT NULL ,
	[SobreCostoExp] [numeric](14, 8) NOT NULL ,
	[PrecioUnitProv] [numeric](18, 3) NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MercRec] WITH NOCHECK ADD 
	CONSTRAINT [DF_MercRec_CostoUnitLoc] DEFAULT (0) FOR [CostoUnitLoc],
	CONSTRAINT [DF_MercRec_CostoUnitExp] DEFAULT (0) FOR [CostoUnitExp],
	CONSTRAINT [DF_MercRec_PrecioCpra] DEFAULT (0) FOR [PrecioCpra],
	CONSTRAINT [DF_MercRec_SobreCostoLoc] DEFAULT (0) FOR [SobreCostoLoc],
	CONSTRAINT [DF_MercRec_SobreCostoExp] DEFAULT (0) FOR [SobreCostoExp],
	CONSTRAINT [DF_MercRec_PrecioUnitProv] DEFAULT (0) FOR [PrecioUnitProv]
GO

