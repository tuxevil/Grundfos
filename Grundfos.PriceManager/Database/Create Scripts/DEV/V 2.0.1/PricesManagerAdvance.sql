if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProductByCategory_Category]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProductByCategory] DROP CONSTRAINT FK_ProductByCategory_Category
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Provider_Country]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Provider] DROP CONSTRAINT FK_Provider_Country
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_Currency]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_Currency
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_Currency1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_Currency1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_Currency2]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_Currency2
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_Currency3]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_Currency3
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceAttribute_PriceBase]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceAttribute] DROP CONSTRAINT FK_PriceAttribute_PriceBase
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceAttribute_PriceGroup]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceAttribute] DROP CONSTRAINT FK_PriceAttribute_PriceGroup
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_PriceImport]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_PriceImport
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceImportLog_PriceImport]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceImportLog] DROP CONSTRAINT FK_PriceImportLog_PriceImport
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProductByCategory_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProductByCategory] DROP CONSTRAINT FK_ProductByCategory_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProductByProvider_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProductByProvider] DROP CONSTRAINT FK_ProductByProvider_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PriceBase_Provider]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PriceBase] DROP CONSTRAINT FK_PriceBase_Provider
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ProductByProvider_Provider]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ProductByProvider] DROP CONSTRAINT FK_ProductByProvider_Provider
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_addtosourcecontrol]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_addtosourcecontrol]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_addtosourcecontrol_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_addtosourcecontrol_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_adduserobject]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_adduserobject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_adduserobject_vcs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_adduserobject_vcs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_checkinobject]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_checkinobject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_checkinobject_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_checkinobject_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_checkoutobject]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_checkoutobject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_checkoutobject_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_checkoutobject_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_displayoaerror]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_displayoaerror]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_displayoaerror_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_displayoaerror_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_droppropertiesbyid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_droppropertiesbyid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_dropuserobjectbyid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_dropuserobjectbyid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_generateansiname]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_generateansiname]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_getobjwithprop]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_getobjwithprop]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_getobjwithprop_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_getobjwithprop_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_getpropertiesbyid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_getpropertiesbyid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_getpropertiesbyid_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_getpropertiesbyid_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_getpropertiesbyid_vcs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_getpropertiesbyid_vcs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_getpropertiesbyid_vcs_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_getpropertiesbyid_vcs_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_isundersourcecontrol]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_isundersourcecontrol]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_isundersourcecontrol_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_isundersourcecontrol_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_removefromsourcecontrol]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_removefromsourcecontrol]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_setpropertybyid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_setpropertybyid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_setpropertybyid_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_setpropertybyid_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_validateloginparams]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_validateloginparams]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_validateloginparams_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_validateloginparams_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_vcsenabled]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_vcsenabled]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_verstamp006]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_verstamp006]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_whocheckedout]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_whocheckedout]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dt_whocheckedout_u]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dt_whocheckedout_u]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductList]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ProductList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Category]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Country]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Country]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CtrRange]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CtrRange]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Currency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Currency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Discount]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Discount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceAttribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PriceAttribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceBase]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PriceBase]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PriceGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceImport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PriceImport]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceImportLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PriceImportLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceList]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PriceList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Product]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductAudit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductAudit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductByCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductByCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductByPriceList]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductByPriceList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductByProvider]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductByProvider]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductBySelection]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ProductBySelection]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Provider]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Provider]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Selection]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Selection]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UserAudit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[UserAudit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dtproperties]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[dtproperties]
GO

CREATE TABLE [dbo].[Category] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Parent] [int] NOT NULL ,
	[Name] [nvarchar] (512) COLLATE Latin1_General_BIN NOT NULL ,
	[Description] [nvarchar] (512) COLLATE Latin1_General_BIN NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Country] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CtrRange] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Min] [decimal](18, 3) NOT NULL ,
	[Max] [decimal](18, 3) NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Currency] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[Value] [decimal](18, 3) NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Discount] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[MaxDiscount] [decimal](18, 3) NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PriceAttribute] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Price] [decimal](18, 0) NOT NULL ,
	[PriceCurrency] [int] NOT NULL ,
	[PriceSell] [decimal](18, 0) NOT NULL ,
	[PriceSellCurrency] [int] NOT NULL ,
	[ProductAttribute] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[BasePriceId] [int] NOT NULL ,
	[PriceGroupId] [int] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PriceBase] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[PricePurchase] [decimal](18, 0) NULL ,
	[PricePurchaseCurrencyId] [int] NULL ,
	[PriceSuggest] [decimal](18, 0) NULL ,
	[PriceSuggestCurrencyId] [int] NULL ,
	[ProviderCode] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ProviderId] [int] NOT NULL ,
	[ProductId] [int] NOT NULL ,
	[PriceImportId] [int] NOT NULL ,
	[PriceList] [decimal](18, 0) NULL ,
	[PriceListCurrencyId] [int] NULL ,
	[PriceBaseSell] [decimal](18, 0) NULL ,
	[PriceBaseSellCurrencyId] [int] NULL ,
	[Status] [int] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NULL ,
	[ModifiedOn] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PriceGroup] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PriceImport] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[ImportStatus] [int] NOT NULL ,
	[File] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DateImported] [datetime] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NULL ,
	[ModifiedOn] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PriceImportLog] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[PriceImportId] [int] NOT NULL ,
	[CodGrundfos] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CodProvider] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Model] [varchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Description] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Provider] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Frequency] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TP] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TPCurrency] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GRP] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[GRPCurrency] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PL] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PLCurrency] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cat1] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cat2] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cat3] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[OriginalLine] [varchar] (1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Status] [int] NOT NULL ,
	[Detail] [varchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CreatedBy] [uniqueidentifier] NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NULL ,
	[ModifiedOn] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PriceList] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[DiscountId] [int] NOT NULL ,
	[ProductType] [int] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Code] [nvarchar] (50) COLLATE Latin1_General_BIN NULL ,
	[Description] [nvarchar] (256) COLLATE Latin1_General_BIN NULL ,
	[Status] [int] NOT NULL ,
	[Model] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Keywords] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Type] [int] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NULL ,
	[ModifiedOn] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductAudit] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[PriceSuggest] [decimal](18, 3) NOT NULL ,
	[PriceSuggestCurrencyId] [int] NOT NULL ,
	[PricePurchase] [decimal](18, 3) NOT NULL ,
	[PricePurchaseCurrencyId] [int] NOT NULL ,
	[Code] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[FamilyId] [int] NOT NULL ,
	[Description] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[CreatedBy] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductByCategory] (
	[ProductId] [int] NOT NULL ,
	[CategoryId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductByPriceList] (
	[ProductId] [int] NOT NULL ,
	[PriceListId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductByProvider] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[ProductId] [int] NOT NULL ,
	[ProviderId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductBySelection] (
	[ProductId] [int] NOT NULL ,
	[SelectionId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Provider] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Code] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SaleConditions] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PurchaseConditions] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[City] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CountryId] [int] NOT NULL ,
	[Email] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Telephone] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Contact] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ProviderStatus] [int] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Selection] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[User] [uniqueidentifier] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserAudit] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[UserId] [uniqueidentifier] NOT NULL ,
	[Action] [int] NOT NULL ,
	[Comment] [nvarchar] (50) COLLATE Latin1_General_BIN NOT NULL ,
	[ProductId] [int] NOT NULL ,
	[CreatedBy] [uniqueidentifier] NOT NULL ,
	[CreatedOn] [datetime] NOT NULL ,
	[ModifiedBy] [uniqueidentifier] NOT NULL ,
	[ModifiedOn] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[dtproperties] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[objectid] [int] NULL ,
	[property] [varchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[value] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[uvalue] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[lvalue] [image] NULL ,
	[version] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ProductList
AS
SELECT     P.Code AS Prod_Codigo, P.Description AS Prod_Descripcion, BP.ProviderCode AS BaseP_CodProveedor, PV.Name AS Prov_Nombre, 
                      PG.Name AS PriceG_Nombre, CPP.Description AS Mone_TP, BP.PricePurchase AS BaseP_TP, CPSU.Description AS Mone_GRP, 
                      BP.PriceSuggest AS BaseP_GRP, CP.Description AS Mone_PrecioLista, PA.Price AS PriceA_PrecioLista, CPS.Description AS Mone_PrecioVenta, 
                      PA.PriceSell AS PriceA_PrecioVenta, C.Name AS Pais_Nombre, (PA.Price * CP.Value) * (100 - 20) 
                      / 100 / CPS.Value * CPS.Value - BP.PricePurchase * CPP.Value AS CTM, CASE WHEN (PA.PriceSell = 0) 
                      THEN 0 ELSE (1 - ((BP.PricePurchase * CPP.Value) / (PA.PriceSell * CPS.Value))) * 100 END AS CTR
FROM         dbo.Provider AS PV INNER JOIN
                      dbo.BasePrice AS BP ON PV.Id = BP.ProviderId INNER JOIN
                      dbo.PriceAttribute AS PA ON BP.Id = PA.BasePriceId INNER JOIN
                      dbo.PriceGroup AS PG ON PA.PriceGroupId = PG.Id INNER JOIN
                      dbo.Product AS P ON BP.ProductId = P.Id INNER JOIN
                      dbo.Currency AS CPP ON BP.PricePurchaseCurrencyId = CPP.Id INNER JOIN
                      dbo.Currency AS CPSU ON BP.PriceSuggestCurrencyId = CPSU.Id INNER JOIN
                      dbo.Currency AS CP ON PA.PriceCurrency = CP.Id INNER JOIN
                      dbo.Currency AS CPS ON PA.PriceSellCurrency = CPS.Id INNER JOIN
                      dbo.Country AS C ON PV.CountryId = C.Id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_addtosourcecontrol
    @vchSourceSafeINI varchar(255) = '',
    @vchProjectName   varchar(255) ='',
    @vchComment       varchar(255) ='',
    @vchLoginName     varchar(255) ='',
    @vchPassword      varchar(255) =''

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @iStreamObjectId int
select @iStreamObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

declare @vchDatabaseName varchar(255)
select @vchDatabaseName = db_name()

declare @iReturnValue int
select @iReturnValue = 0

declare @iPropertyObjectId int
declare @vchParentId varchar(255)

declare @iObjectCount int
select @iObjectCount = 0

    exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError


    /* Create Project in SS */
    exec @iReturn = sp_OAMethod @iObjectId,
                                'AddProjectToSourceSafe',
                                NULL,
                                @vchSourceSafeINI,
                                @vchProjectName output,
                                @@SERVERNAME,
                                @vchDatabaseName,
                                @vchLoginName,
                                @vchPassword,
                                @vchComment


    if @iReturn <> 0 GOTO E_OAError

    exec @iReturn = sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT

    if @iReturn <> 0 GOTO E_OAError

    /* Set Database Properties */

    begin tran SetProperties

    /* add high level object */

    exec @iPropertyObjectId = dbo.dt_adduserobject_vcs 'VCSProjectID'

    select @vchParentId = CONVERT(varchar(255),@iPropertyObjectId)

    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSProjectID', @vchParentId , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSProject' , @vchProjectName , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSSourceSafeINI' , @vchSourceSafeINI , NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSSQLServer', @@SERVERNAME, NULL
    exec dbo.dt_setpropertybyid @iPropertyObjectId, 'VCSSQLDatabase', @vchDatabaseName, NULL

    if @@error <> 0 GOTO E_General_Error

    commit tran SetProperties

    declare cursorProcNames cursor for
        select convert(varchar(255), name) from sysobjects where type = 'P' and name not like 'dt_%'
    open cursorProcNames

    while 1 = 1
    begin
        declare @vchProcName varchar(255)
        fetch next from cursorProcNames into @vchProcName
        if @@fetch_status <> 0
            break

        select colid, text into #ProcLines
        from syscomments
        where id = object_id(@vchProcName)
        order by colid

        declare @iCurProcLine int
        declare @iProcLines int
        select @iCurProcLine = 1
        select @iProcLines = (select count(*) from #ProcLines)
        while @iCurProcLine <= @iProcLines
        begin
            declare @pos int
            select @pos = 1
            declare @iCurLineSize int
            select @iCurLineSize = len((select text from #ProcLines where colid = @iCurProcLine))
            while @pos <= @iCurLineSize
            begin
                declare @vchProcLinePiece varchar(255)
                select @vchProcLinePiece = convert(varchar(255),
                    substring((select text from #ProcLines where colid = @iCurProcLine),
                              @pos, 255 ))
                exec @iReturn = sp_OAMethod @iStreamObjectId, 'AddStream', @iReturnValue OUT, @vchProcLinePiece
                if @iReturn <> 0 GOTO E_OAError
                select @pos = @pos + 255
            end
            select @iCurProcLine = @iCurProcLine + 1
        end
        drop table #ProcLines

        exec @iReturn = sp_OAMethod @iObjectId,
                                    'CheckIn_StoredProcedure',
                                    NULL,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sServerName = @@SERVERNAME,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sObjectName = @vchProcName,
                                    @sComment = @vchComment,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword,
                                    @iVCSFlags = 0,
                                    @iActionFlag = 0,
                                    @sStream = ''

        if @iReturn = 0 select @iObjectCount = @iObjectCount + 1

    end

CleanUp:
	close cursorProcNames
	deallocate cursorProcNames
    select @vchProjectName
    select @iObjectCount
    return

E_General_Error:
    /* this is an all or nothing.  No specific error messages */
    goto CleanUp

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    goto CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_addtosourcecontrol_u
    @vchSourceSafeINI nvarchar(255) = '',
    @vchProjectName   nvarchar(255) ='',
    @vchComment       nvarchar(255) ='',
    @vchLoginName     nvarchar(255) ='',
    @vchPassword      nvarchar(255) =''

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @iStreamObjectId int
select @iStreamObjectId = 0

declare @VSSGUID nvarchar(100)
select @VSSGUID = N'SQLVersionControl.VCS_SQL'

declare @vchDatabaseName varchar(255)
select @vchDatabaseName = db_name()

declare @iReturnValue int
select @iReturnValue = 0

declare @iPropertyObjectId int
declare @vchParentId nvarchar(255)

declare @iObjectCount int
select @iObjectCount = 0

    exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError


    /* Create Project in SS */
    exec @iReturn = sp_OAMethod @iObjectId,
                                'AddProjectToSourceSafe',
                                NULL,
                                @vchSourceSafeINI,
                                @vchProjectName output,
                                @@SERVERNAME,
                                @vchDatabaseName,
                                @vchLoginName,
                                @vchPassword,
                                @vchComment


    if @iReturn <> 0 GOTO E_OAError

    exec @iReturn = sp_OAGetProperty @iObjectId, N'GetStreamObject', @iStreamObjectId OUT

    if @iReturn <> 0 GOTO E_OAError

    /* Set Database Properties */

    begin tran SetProperties

    /* add high level object */

    exec @iPropertyObjectId = dbo.dt_adduserobject_vcs 'VCSProjectID'

    select @vchParentId = CONVERT(nvarchar(255),@iPropertyObjectId)

    exec dbo.dt_setpropertybyid_u @iPropertyObjectId, 'VCSProjectID', @vchParentId , NULL
    exec dbo.dt_setpropertybyid_u @iPropertyObjectId, 'VCSProject' , @vchProjectName , NULL
    exec dbo.dt_setpropertybyid_u @iPropertyObjectId, 'VCSSourceSafeINI' , @vchSourceSafeINI , NULL
    exec dbo.dt_setpropertybyid_u @iPropertyObjectId, 'VCSSQLServer', @@SERVERNAME, NULL
    exec dbo.dt_setpropertybyid_u @iPropertyObjectId, 'VCSSQLDatabase', @vchDatabaseName, NULL

    if @@error <> 0 GOTO E_General_Error

    commit tran SetProperties

    declare cursorProcNames cursor for
        select convert(nvarchar(255), name) from sysobjects where type = N'P' and name not like N'dt_%'
    open cursorProcNames

    while 1 = 1
    begin
        declare @vchProcName nvarchar(255)
        fetch next from cursorProcNames into @vchProcName
        if @@fetch_status <> 0
            break

        select colid, text into #ProcLines
        from syscomments
        where id = object_id(@vchProcName)
        order by colid

        declare @iCurProcLine int
        declare @iProcLines int
        select @iCurProcLine = 1
        select @iProcLines = (select count(*) from #ProcLines)
        while @iCurProcLine <= @iProcLines
        begin
            declare @pos int
            select @pos = 1
            declare @iCurLineSize int
            select @iCurLineSize = len((select text from #ProcLines where colid = @iCurProcLine))
            while @pos <= @iCurLineSize
            begin
                declare @vchProcLinePiece nvarchar(255)
                select @vchProcLinePiece = convert(nvarchar(255),
                    substring((select text from #ProcLines where colid = @iCurProcLine),
                              @pos, 255 ))
                exec @iReturn = sp_OAMethod @iStreamObjectId, N'AddStream', @iReturnValue OUT, @vchProcLinePiece
                if @iReturn <> 0 GOTO E_OAError
                select @pos = @pos + 255
            end
            select @iCurProcLine = @iCurProcLine + 1
        end
        drop table #ProcLines

        exec @iReturn = sp_OAMethod @iObjectId,
                                    'CheckIn_StoredProcedure',
                                    NULL,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sServerName = @@SERVERNAME,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sObjectName = @vchProcName,
                                    @sComment = @vchComment,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword,
                                    @iVCSFlags = 0,
                                    @iActionFlag = 0,
                                    @sStream = ''

        if @iReturn = 0 select @iObjectCount = @iObjectCount + 1

    end

CleanUp:
	close cursorProcNames
	deallocate cursorProcNames
    select @vchProjectName
    select @iObjectCount
    return

E_General_Error:
    /* this is an all or nothing.  No specific error messages */
    goto CleanUp

E_OAError:
    exec dbo.dt_displayoaerror_u @iObjectId, @iReturn
    goto CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Add an object to the dtproperties table
*/
create procedure dbo.dt_adduserobject
as
	set nocount on
	/*
	** Create the user object if it does not exist already
	*/
	begin transaction
		insert dbo.dtproperties (property) VALUES ('DtgSchemaOBJECT')
		update dbo.dtproperties set objectid=@@identity 
			where id=@@identity and property='DtgSchemaOBJECT'
	commit
	return @@identity

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create procedure dbo.dt_adduserobject_vcs
    @vchProperty varchar(64)

as

set nocount on

declare @iReturn int
    /*
    ** Create the user object if it does not exist already
    */
    begin transaction
        select @iReturn = objectid from dbo.dtproperties where property = @vchProperty
        if @iReturn IS NULL
        begin
            insert dbo.dtproperties (property) VALUES (@vchProperty)
            update dbo.dtproperties set objectid=@@identity
                    where id=@@identity and property=@vchProperty
            select @iReturn = @@identity
        end
    commit
    return @iReturn



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_checkinobject
    @chObjectType  char(4),
    @vchObjectName varchar(255),
    @vchComment    varchar(255)='',
    @vchLoginName  varchar(255),
    @vchPassword   varchar(255)='',
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0,   /* 0 => AddFile, 1 => CheckIn */
    @txStream1     Text = '', /* There is a bug that if items are NULL they do not pass to OLE servers */
    @txStream2     Text = '',
    @txStream3     Text = ''


as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'


declare @iPropertyObjectId int
select @iPropertyObjectId  = 0

    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        if @iActionFlag = 1
        begin
            /* Procedure Can have up to three streams
            Drop Stream, Create Stream, GRANT stream */

            begin tran compile_all

            /* try to compile the streams */
            exec (@txStream1)
            if @@error <> 0 GOTO E_Compile_Fail

            exec (@txStream2)
            if @@error <> 0 GOTO E_Compile_Fail

            exec (@txStream3)
            if @@error <> 0 GOTO E_Compile_Fail
        end

        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
        if @iReturn <> 0 GOTO E_OAError

        if @iActionFlag = 1
        begin
            exec @iReturn = sp_OAMethod @iObjectId,
                                        'CheckIn_StoredProcedure',
                                        NULL,
                                        @sProjectName = @vchProjectName,
                                        @sSourceSafeINI = @vchSourceSafeINI,
                                        @sServerName = @vchServerName,
                                        @sDatabaseName = @vchDatabaseName,
                                        @sObjectName = @vchObjectName,
                                        @sComment = @vchComment,
                                        @sLoginName = @vchLoginName,
                                        @sPassword = @vchPassword,
                                        @iVCSFlags = @iVCSFlags,
                                        @iActionFlag = @iActionFlag,
                                        @sStream = @txStream2
        end
        else
        begin
            declare @iStreamObjectId int
            declare @iReturnValue int

            exec @iReturn = sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT
            if @iReturn <> 0 GOTO E_OAError

            select colid, text into #ProcLines
            from syscomments
            where id = object_id(@vchObjectName)
            order by colid

            declare @iCurProcLine int
            declare @iProcLines int
            select @iCurProcLine = 1
            select @iProcLines = (select count(*) from #ProcLines)
            while @iCurProcLine <= @iProcLines
            begin
                declare @pos int
                select @pos = 1
                declare @iCurLineSize int
                select @iCurLineSize = len((select text from #ProcLines where colid = @iCurProcLine))
                while @pos <= @iCurLineSize
                begin
                    declare @vchProcLinePiece varchar(255)
                    select @vchProcLinePiece = convert(varchar(255),
                        substring((select text from #ProcLines where colid = @iCurProcLine),
                                  @pos, 255 ))
                    exec @iReturn = sp_OAMethod @iStreamObjectId, 'AddStream', @iReturnValue OUT, @vchProcLinePiece
                    if @iReturn <> 0 GOTO E_OAError
                    select @pos = @pos + 255
                end
                select @iCurProcLine = @iCurProcLine + 1
            end
            drop table #ProcLines

            exec @iReturn = sp_OAMethod @iObjectId,
                                        'CheckIn_StoredProcedure',
                                        NULL,
                                        @sProjectName = @vchProjectName,
                                        @sSourceSafeINI = @vchSourceSafeINI,
                                        @sServerName = @vchServerName,
                                        @sDatabaseName = @vchDatabaseName,
                                        @sObjectName = @vchObjectName,
                                        @sComment = @vchComment,
                                        @sLoginName = @vchLoginName,
                                        @sPassword = @vchPassword,
                                        @iVCSFlags = @iVCSFlags,
                                        @iActionFlag = @iActionFlag,
                                        @sStream = ''
        end

        if @iReturn <> 0 GOTO E_OAError

        if @iActionFlag = 1
        begin
            commit tran compile_all
            if @@error <> 0 GOTO E_Compile_Fail
        end

    end

CleanUp:
    return

E_Compile_Fail:
    declare @lerror int
    select @lerror = @@error
    rollback tran compile_all
    RAISERROR (@lerror,16,-1)
    goto CleanUp

E_OAError:
    if @iActionFlag = 1 rollback tran compile_all
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    goto CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_checkinobject_u
    @chObjectType  char(4),
    @vchObjectName nvarchar(255),
    @vchComment    nvarchar(255)='',
    @vchLoginName  nvarchar(255),
    @vchPassword   nvarchar(255)='',
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0,   /* 0 => AddFile, 1 => CheckIn */
    @txStream1     Text = '', /* There is a bug that if items are NULL they do not pass to OLE servers */
    @txStream2     Text = '',
    @txStream3     Text = ''


as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @VSSGUID nvarchar(100)
select @VSSGUID = N'SQLVersionControl.VCS_SQL'


declare @iPropertyObjectId int
select @iPropertyObjectId  = 0

    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   nvarchar(255)
    declare @vchSourceSafeINI nvarchar(255)
    declare @vchServerName    nvarchar(255)
    declare @vchDatabaseName  nvarchar(255)
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        if @iActionFlag = 1
        begin
            /* Procedure Can have up to three streams
            Drop Stream, Create Stream, GRANT stream */

            begin tran compile_all

            /* try to compile the streams */
            exec (@txStream1)
            if @@error <> 0 GOTO E_Compile_Fail

            exec (@txStream2)
            if @@error <> 0 GOTO E_Compile_Fail

            exec (@txStream3)
            if @@error <> 0 GOTO E_Compile_Fail
        end

        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
        if @iReturn <> 0 GOTO E_OAError

        if @iActionFlag = 1
        begin
            exec @iReturn = sp_OAMethod @iObjectId,
                                        N'CheckIn_StoredProcedure',
                                        NULL,
                                        @sProjectName = @vchProjectName,
                                        @sSourceSafeINI = @vchSourceSafeINI,
                                        @sServerName = @vchServerName,
                                        @sDatabaseName = @vchDatabaseName,
                                        @sObjectName = @vchObjectName,
                                        @sComment = @vchComment,
                                        @sLoginName = @vchLoginName,
                                        @sPassword = @vchPassword,
                                        @iVCSFlags = @iVCSFlags,
                                        @iActionFlag = @iActionFlag,
                                        @sStream = @txStream2
        end
        else
        begin
            declare @iStreamObjectId int
            declare @iReturnValue int

            exec @iReturn = sp_OAGetProperty @iObjectId, N'GetStreamObject', @iStreamObjectId OUT
            if @iReturn <> 0 GOTO E_OAError

            select colid, text into #ProcLines
            from syscomments
            where id = object_id(@vchObjectName)
            order by colid

            declare @iCurProcLine int
            declare @iProcLines int
            select @iCurProcLine = 1
            select @iProcLines = (select count(*) from #ProcLines)
            while @iCurProcLine <= @iProcLines
            begin
                declare @pos int
                select @pos = 1
                declare @iCurLineSize int
                select @iCurLineSize = len((select text from #ProcLines where colid = @iCurProcLine))
                while @pos <= @iCurLineSize
                begin
                    declare @vchProcLinePiece nvarchar(255)
                    select @vchProcLinePiece = convert(nvarchar(255),
                        substring((select text from #ProcLines where colid = @iCurProcLine),
                                  @pos, 255 ))
                    exec @iReturn = sp_OAMethod @iStreamObjectId, N'AddStream', @iReturnValue OUT, @vchProcLinePiece
                    if @iReturn <> 0 GOTO E_OAError
                    select @pos = @pos + 255
                end
                select @iCurProcLine = @iCurProcLine + 1
            end
            drop table #ProcLines

            exec @iReturn = sp_OAMethod @iObjectId,
                                        N'CheckIn_StoredProcedure',
                                        NULL,
                                        @sProjectName = @vchProjectName,
                                        @sSourceSafeINI = @vchSourceSafeINI,
                                        @sServerName = @vchServerName,
                                        @sDatabaseName = @vchDatabaseName,
                                        @sObjectName = @vchObjectName,
                                        @sComment = @vchComment,
                                        @sLoginName = @vchLoginName,
                                        @sPassword = @vchPassword,
                                        @iVCSFlags = @iVCSFlags,
                                        @iActionFlag = @iActionFlag,
                                        @sStream = ''
        end

        if @iReturn <> 0 GOTO E_OAError

        if @iActionFlag = 1
        begin
            commit tran compile_all
            if @@error <> 0 GOTO E_Compile_Fail
        end

    end

CleanUp:
    return

E_Compile_Fail:
    declare @lerror int
    select @lerror = @@error
    rollback tran compile_all
    RAISERROR (@lerror,16,-1)
    goto CleanUp

E_OAError:
    if @iActionFlag = 1 rollback tran compile_all
    exec dbo.dt_displayoaerror_u @iObjectId, @iReturn
    goto CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_checkoutobject
    @chObjectType  char(4),
    @vchObjectName varchar(255),
    @vchComment    varchar(255),
    @vchLoginName  varchar(255),
    @vchPassword   varchar(255),
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0/* 0 => Checkout, 1 => GetLatest, 2 => UndoCheckOut */

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

declare @iReturnValue int
select @iReturnValue = 0

declare @vchTempText varchar(255)

/* this is for our strings */
declare @iStreamObjectId int
select @iStreamObjectId = 0

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        /* Procedure Can have up to three streams
           Drop Stream, Create Stream, GRANT stream */

        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = sp_OAMethod @iObjectId,
                                    'CheckOut_StoredProcedure',
                                    NULL,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sObjectName = @vchObjectName,
                                    @sServerName = @vchServerName,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sComment = @vchComment,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword,
                                    @iVCSFlags = @iVCSFlags,
                                    @iActionFlag = @iActionFlag

        if @iReturn <> 0 GOTO E_OAError


        exec @iReturn = sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        create table #commenttext (id int identity, sourcecode varchar(255))


        select @vchTempText = 'STUB'
        while @vchTempText IS NOT NULL
        begin
            exec @iReturn = sp_OAMethod @iStreamObjectId, 'GetStream', @iReturnValue OUT, @vchTempText OUT
            if @iReturn <> 0 GOTO E_OAError

            if (@vchTempText IS NOT NULL) insert into #commenttext (sourcecode) select @vchTempText
        end

        select 'VCS'=sourcecode from #commenttext order by id
        select 'SQL'=text from syscomments where id = object_id(@vchObjectName) order by colid

    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    GOTO CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_checkoutobject_u
    @chObjectType  char(4),
    @vchObjectName nvarchar(255),
    @vchComment    nvarchar(255),
    @vchLoginName  nvarchar(255),
    @vchPassword   nvarchar(255),
    @iVCSFlags     int = 0,
    @iActionFlag   int = 0/* 0 => Checkout, 1 => GetLatest, 2 => UndoCheckOut */

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID nvarchar(100)
select @VSSGUID = N'SQLVersionControl.VCS_SQL'

declare @iReturnValue int
select @iReturnValue = 0

declare @vchTempText nvarchar(255)

/* this is for our strings */
declare @iStreamObjectId int
select @iStreamObjectId = 0

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   nvarchar(255)
    declare @vchSourceSafeINI nvarchar(255)
    declare @vchServerName    nvarchar(255)
    declare @vchDatabaseName  nvarchar(255)
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        /* Procedure Can have up to three streams
           Drop Stream, Create Stream, GRANT stream */

        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = sp_OAMethod @iObjectId,
                                    N'CheckOut_StoredProcedure',
                                    NULL,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sObjectName = @vchObjectName,
                                    @sServerName = @vchServerName,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sComment = @vchComment,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword,
                                    @iVCSFlags = @iVCSFlags,
                                    @iActionFlag = @iActionFlag

        if @iReturn <> 0 GOTO E_OAError


        exec @iReturn = sp_OAGetProperty @iObjectId, N'GetStreamObject', @iStreamObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        create table #commenttext (id int identity, sourcecode nvarchar(255))


        select @vchTempText = N'STUB'
        while @vchTempText IS NOT NULL
        begin
            exec @iReturn = sp_OAMethod @iStreamObjectId, N'GetStream', @iReturnValue OUT, @vchTempText OUT
            if @iReturn <> 0 GOTO E_OAError

            if (@vchTempText IS NOT NULL) insert into #commenttext (sourcecode) select @vchTempText
        end

        select N'VCS'=sourcecode from #commenttext order by id
        select N'SQL'=text from syscomments where id = object_id(@vchObjectName) order by colid

    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror_u @iObjectId, @iReturn
    GOTO CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.dt_displayoaerror
    @iObject int,
    @iresult int
as

set nocount on

declare @vchOutput      varchar(255)
declare @hr             int
declare @vchSource      varchar(255)
declare @vchDescription varchar(255)

    exec @hr = sp_OAGetErrorInfo @iObject, @vchSource OUT, @vchDescription OUT

    select @vchOutput = @vchSource + ': ' + @vchDescription
    raiserror (@vchOutput,16,-1)

    return


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.dt_displayoaerror_u
    @iObject int,
    @iresult int
as

set nocount on

declare @vchOutput      nvarchar(255)
declare @hr             int
declare @vchSource      nvarchar(255)
declare @vchDescription nvarchar(255)

    exec @hr = sp_OAGetErrorInfo @iObject, @vchSource OUT, @vchDescription OUT

    select @vchOutput = @vchSource + ': ' + @vchDescription
    raiserror (@vchOutput,16,-1)

    return


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Drop one or all the associated properties of an object or an attribute 
**
**	dt_dropproperties objid, null or '' -- drop all properties of the object itself
**	dt_dropproperties objid, property -- drop the property
*/
create procedure dbo.dt_droppropertiesbyid
	@id int,
	@property varchar(64)
as
	set nocount on

	if (@property is null) or (@property = '')
		delete from dbo.dtproperties where objectid=@id
	else
		delete from dbo.dtproperties 
			where objectid=@id and property=@property


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Drop an object from the dbo.dtproperties table
*/
create procedure dbo.dt_dropuserobjectbyid
	@id int
as
	set nocount on
	delete from dbo.dtproperties where objectid=@id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/* 
**	Generate an ansi name that is unique in the dtproperties.value column 
*/ 
create procedure dbo.dt_generateansiname(@name varchar(255) output) 
as 
	declare @prologue varchar(20) 
	declare @indexstring varchar(20) 
	declare @index integer 
 
	set @prologue = 'MSDT-A-' 
	set @index = 1 
 
	while 1 = 1 
	begin 
		set @indexstring = cast(@index as varchar(20)) 
		set @name = @prologue + @indexstring 
		if not exists (select value from dtproperties where value = @name) 
			break 
		 
		set @index = @index + 1 
 
		if (@index = 10000) 
			goto TooMany 
	end 
 
Leave: 
 
	return 
 
TooMany: 
 
	set @name = 'DIAGRAM' 
	goto Leave 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Retrieve the owner object(s) of a given property
*/
create procedure dbo.dt_getobjwithprop
	@property varchar(30),
	@value varchar(255)
as
	set nocount on

	if (@property is null) or (@property = '')
	begin
		raiserror('Must specify a property name.',-1,-1)
		return (1)
	end

	if (@value is null)
		select objectid id from dbo.dtproperties
			where property=@property

	else
		select objectid id from dbo.dtproperties
			where property=@property and value=@value

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Retrieve the owner object(s) of a given property
*/
create procedure dbo.dt_getobjwithprop_u
	@property varchar(30),
	@uvalue nvarchar(255)
as
	set nocount on

	if (@property is null) or (@property = '')
	begin
		raiserror('Must specify a property name.',-1,-1)
		return (1)
	end

	if (@uvalue is null)
		select objectid id from dbo.dtproperties
			where property=@property

	else
		select objectid id from dbo.dtproperties
			where property=@property and uvalue=@uvalue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Retrieve properties by id's
**
**	dt_getproperties objid, null or '' -- retrieve all properties of the object itself
**	dt_getproperties objid, property -- retrieve the property specified
*/
create procedure dbo.dt_getpropertiesbyid
	@id int,
	@property varchar(64)
as
	set nocount on

	if (@property is null) or (@property = '')
		select property, version, value, lvalue
			from dbo.dtproperties
			where  @id=objectid
	else
		select property, version, value, lvalue
			from dbo.dtproperties
			where  @id=objectid and @property=property

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	Retrieve properties by id's
**
**	dt_getproperties objid, null or '' -- retrieve all properties of the object itself
**	dt_getproperties objid, property -- retrieve the property specified
*/
create procedure dbo.dt_getpropertiesbyid_u
	@id int,
	@property varchar(64)
as
	set nocount on

	if (@property is null) or (@property = '')
		select property, version, uvalue, lvalue
			from dbo.dtproperties
			where  @id=objectid
	else
		select property, version, uvalue, lvalue
			from dbo.dtproperties
			where  @id=objectid and @property=property

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create procedure dbo.dt_getpropertiesbyid_vcs
    @id       int,
    @property varchar(64),
    @value    varchar(255) = NULL OUT

as

    set nocount on

    select @value = (
        select value
                from dbo.dtproperties
                where @id=objectid and @property=property
                )


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create procedure dbo.dt_getpropertiesbyid_vcs_u
    @id       int,
    @property varchar(64),
    @value    nvarchar(255) = NULL OUT

as

    set nocount on

    select @value = (
        select uvalue
                from dbo.dtproperties
                where @id=objectid and @property=property
                )


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_isundersourcecontrol
    @vchLoginName varchar(255) = '',
    @vchPassword  varchar(255) = '',
    @iWhoToo      int = 0 /* 0 => Just check project; 1 => get list of objs */

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

declare @iReturnValue int
select @iReturnValue = 0

declare @iStreamObjectId int
select @iStreamObjectId   = 0

declare @vchTempText varchar(255)

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if (@vchProjectName IS NULL) or (@vchSourceSafeINI  IS NULL) or (@vchServerName IS NULL) or (@vchDatabaseName IS NULL)
    begin
        RAISERROR('Not Under Source Control',16,-1)
        return
    end

    if @iWhoToo = 1
    begin

        /* Get List of Procs in the project */
        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = sp_OAMethod @iObjectId,
                                    'GetListOfObjects',
                                    NULL,
                                    @vchProjectName,
                                    @vchSourceSafeINI,
                                    @vchServerName,
                                    @vchDatabaseName,
                                    @vchLoginName,
                                    @vchPassword

        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = sp_OAGetProperty @iObjectId, 'GetStreamObject', @iStreamObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        create table #ObjectList (id int identity, vchObjectlist varchar(255))

        select @vchTempText = 'STUB'
        while @vchTempText IS NOT NULL
        begin
            exec @iReturn = sp_OAMethod @iStreamObjectId, 'GetStream', @iReturnValue OUT, @vchTempText OUT
            if @iReturn <> 0 GOTO E_OAError

            if (@vchTempText IS NOT NULL) insert into #ObjectList (vchObjectlist ) select @vchTempText
        end

        select vchObjectlist from #ObjectList order by id
    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    goto CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_isundersourcecontrol_u
    @vchLoginName nvarchar(255) = '',
    @vchPassword  nvarchar(255) = '',
    @iWhoToo      int = 0 /* 0 => Just check project; 1 => get list of objs */

as

	set nocount on

	declare @iReturn int
	declare @iObjectId int
	select @iObjectId = 0

	declare @VSSGUID nvarchar(100)
	select @VSSGUID = N'SQLVersionControl.VCS_SQL'

	declare @iReturnValue int
	select @iReturnValue = 0

	declare @iStreamObjectId int
	select @iStreamObjectId   = 0

	declare @vchTempText nvarchar(255)

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   nvarchar(255)
    declare @vchSourceSafeINI nvarchar(255)
    declare @vchServerName    nvarchar(255)
    declare @vchDatabaseName  nvarchar(255)
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if (@vchProjectName IS NULL) or (@vchSourceSafeINI  IS NULL) or (@vchServerName IS NULL) or (@vchDatabaseName IS NULL)
    begin
        RAISERROR(N'Not Under Source Control',16,-1)
        return
    end

    if @iWhoToo = 1
    begin

        /* Get List of Procs in the project */
        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = sp_OAMethod @iObjectId,
                                    N'GetListOfObjects',
                                    NULL,
                                    @vchProjectName,
                                    @vchSourceSafeINI,
                                    @vchServerName,
                                    @vchDatabaseName,
                                    @vchLoginName,
                                    @vchPassword

        if @iReturn <> 0 GOTO E_OAError

        exec @iReturn = sp_OAGetProperty @iObjectId, N'GetStreamObject', @iStreamObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        create table #ObjectList (id int identity, vchObjectlist nvarchar(255))

        select @vchTempText = N'STUB'
        while @vchTempText IS NOT NULL
        begin
            exec @iReturn = sp_OAMethod @iStreamObjectId, N'GetStream', @iReturnValue OUT, @vchTempText OUT
            if @iReturn <> 0 GOTO E_OAError

            if (@vchTempText IS NOT NULL) insert into #ObjectList (vchObjectlist ) select @vchTempText
        end

        select vchObjectlist from #ObjectList order by id
    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror_u @iObjectId, @iReturn
    goto CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create procedure dbo.dt_removefromsourcecontrol

as

    set nocount on

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    exec dbo.dt_droppropertiesbyid @iPropertyObjectId, null

    /* -1 is returned by dt_droppopertiesbyid */
    if @@error <> 0 and @@error <> -1 return 1

    return 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	If the property already exists, reset the value; otherwise add property
**		id -- the id in sysobjects of the object
**		property -- the name of the property
**		value -- the text value of the property
**		lvalue -- the binary value of the property (image)
*/
create procedure dbo.dt_setpropertybyid
	@id int,
	@property varchar(64),
	@value varchar(255),
	@lvalue image
as
	set nocount on
	declare @uvalue nvarchar(255) 
	set @uvalue = convert(nvarchar(255), @value) 
	if exists (select * from dbo.dtproperties 
			where objectid=@id and property=@property)
	begin
		--
		-- bump the version count for this row as we update it
		--
		update dbo.dtproperties set value=@value, uvalue=@uvalue, lvalue=@lvalue, version=version+1
			where objectid=@id and property=@property
	end
	else
	begin
		--
		-- version count is auto-set to 0 on initial insert
		--
		insert dbo.dtproperties (property, objectid, value, uvalue, lvalue)
			values (@property, @id, @value, @uvalue, @lvalue)
	end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	If the property already exists, reset the value; otherwise add property
**		id -- the id in sysobjects of the object
**		property -- the name of the property
**		uvalue -- the text value of the property
**		lvalue -- the binary value of the property (image)
*/
create procedure dbo.dt_setpropertybyid_u
	@id int,
	@property varchar(64),
	@uvalue nvarchar(255),
	@lvalue image
as
	set nocount on
	-- 
	-- If we are writing the name property, find the ansi equivalent. 
	-- If there is no lossless translation, generate an ansi name. 
	-- 
	declare @avalue varchar(255) 
	set @avalue = null 
	if (@uvalue is not null) 
	begin 
		if (convert(nvarchar(255), convert(varchar(255), @uvalue)) = @uvalue) 
		begin 
			set @avalue = convert(varchar(255), @uvalue) 
		end 
		else 
		begin 
			if 'DtgSchemaNAME' = @property 
			begin 
				exec dbo.dt_generateansiname @avalue output 
			end 
		end 
	end 
	if exists (select * from dbo.dtproperties 
			where objectid=@id and property=@property)
	begin
		--
		-- bump the version count for this row as we update it
		--
		update dbo.dtproperties set value=@avalue, uvalue=@uvalue, lvalue=@lvalue, version=version+1
			where objectid=@id and property=@property
	end
	else
	begin
		--
		-- version count is auto-set to 0 on initial insert
		--
		insert dbo.dtproperties (property, objectid, value, uvalue, lvalue)
			values (@property, @id, @avalue, @uvalue, @lvalue)
	end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_validateloginparams
    @vchLoginName  varchar(255),
    @vchPassword   varchar(255)
as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchSourceSafeINI varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT

    exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError

    exec @iReturn = sp_OAMethod @iObjectId,
                                'ValidateLoginParams',
                                NULL,
                                @sSourceSafeINI = @vchSourceSafeINI,
                                @sLoginName = @vchLoginName,
                                @sPassword = @vchPassword
    if @iReturn <> 0 GOTO E_OAError

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    GOTO CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_validateloginparams_u
    @vchLoginName  nvarchar(255),
    @vchPassword   nvarchar(255)
as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID nvarchar(100)
select @VSSGUID = N'SQLVersionControl.VCS_SQL'

    declare @iPropertyObjectId int
    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchSourceSafeINI nvarchar(255)
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT

    exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 GOTO E_OAError

    exec @iReturn = sp_OAMethod @iObjectId,
                                N'ValidateLoginParams',
                                NULL,
                                @sSourceSafeINI = @vchSourceSafeINI,
                                @sLoginName = @vchLoginName,
                                @sPassword = @vchPassword
    if @iReturn <> 0 GOTO E_OAError

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror_u @iObjectId, @iReturn
    GOTO CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_vcsenabled

as

set nocount on

declare @iObjectId int
select @iObjectId = 0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

    declare @iReturn int
    exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT
    if @iReturn <> 0 raiserror('', 16, -1) /* Can't Load Helper DLLC */



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
**	This procedure returns the version number of the stored
**    procedures used by the Microsoft Visual Database Tools.
**    Current version is 7.0.00.
*/
create procedure dbo.dt_verstamp006
as
	select 7000

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_whocheckedout
        @chObjectType  char(4),
        @vchObjectName varchar(255),
        @vchLoginName  varchar(255),
        @vchPassword   varchar(255)

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID varchar(100)
select @VSSGUID = 'SQLVersionControl.VCS_SQL'

    declare @iPropertyObjectId int

    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   varchar(255)
    declare @vchSourceSafeINI varchar(255)
    declare @vchServerName    varchar(255)
    declare @vchDatabaseName  varchar(255)
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        declare @vchReturnValue varchar(255)
        select @vchReturnValue = ''

        exec @iReturn = sp_OAMethod @iObjectId,
                                    'WhoCheckedOut',
                                    @vchReturnValue OUT,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sObjectName = @vchObjectName,
                                    @sServerName = @vchServerName,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword

        if @iReturn <> 0 GOTO E_OAError

        select @vchReturnValue

    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror @iObjectId, @iReturn
    GOTO CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

create proc dbo.dt_whocheckedout_u
        @chObjectType  char(4),
        @vchObjectName nvarchar(255),
        @vchLoginName  nvarchar(255),
        @vchPassword   nvarchar(255)

as

set nocount on

declare @iReturn int
declare @iObjectId int
select @iObjectId =0

declare @VSSGUID nvarchar(100)
select @VSSGUID = N'SQLVersionControl.VCS_SQL'

    declare @iPropertyObjectId int

    select @iPropertyObjectId = (select objectid from dbo.dtproperties where property = 'VCSProjectID')

    declare @vchProjectName   nvarchar(255)
    declare @vchSourceSafeINI nvarchar(255)
    declare @vchServerName    nvarchar(255)
    declare @vchDatabaseName  nvarchar(255)
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSProject',       @vchProjectName   OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSourceSafeINI', @vchSourceSafeINI OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLServer',     @vchServerName    OUT
    exec dbo.dt_getpropertiesbyid_vcs_u @iPropertyObjectId, 'VCSSQLDatabase',   @vchDatabaseName  OUT

    if @chObjectType = 'PROC'
    begin
        exec @iReturn = sp_OACreate @VSSGUID, @iObjectId OUT

        if @iReturn <> 0 GOTO E_OAError

        declare @vchReturnValue nvarchar(255)
        select @vchReturnValue = ''

        exec @iReturn = sp_OAMethod @iObjectId,
                                    N'WhoCheckedOut',
                                    @vchReturnValue OUT,
                                    @sProjectName = @vchProjectName,
                                    @sSourceSafeINI = @vchSourceSafeINI,
                                    @sObjectName = @vchObjectName,
                                    @sServerName = @vchServerName,
                                    @sDatabaseName = @vchDatabaseName,
                                    @sLoginName = @vchLoginName,
                                    @sPassword = @vchPassword

        if @iReturn <> 0 GOTO E_OAError

        select @vchReturnValue

    end

CleanUp:
    return

E_OAError:
    exec dbo.dt_displayoaerror_u @iObjectId, @iReturn
    GOTO CleanUp



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

