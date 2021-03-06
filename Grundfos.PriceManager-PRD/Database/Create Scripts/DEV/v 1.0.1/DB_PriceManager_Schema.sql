/****** Object:  Table [dbo].[Currency]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Currency]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[Value] [decimal](18, 3) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Discount]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[MaxDiscount] [decimal](18, 3) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[Selection]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Selection]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Selection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Selection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[Category]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Category]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Family] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[CtrRange]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtrRange]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[CtrRange](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Min] [decimal](18, 3) NOT NULL,
	[Max] [decimal](18, 3) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_CtrRange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[Product]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Product]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[Description] [nvarchar](1024) COLLATE Latin1_General_BIN NOT NULL,
	[PriceSuggest] [decimal](18, 3) NOT NULL,
	[PriceSuggestCurrencyId] [int] NOT NULL,
	[PricePurchase] [decimal](18, 3) NOT NULL,
	[PricePurchaseCurrencyId] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[PriceList]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PriceList]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[PriceList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[DiscountId] [int] NOT NULL,
	[ProductType] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[ProductPriceAudit]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ProductPriceAudit]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ProductPriceAudit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PriceListId] [int] NOT NULL,
	[PriceSell] [decimal](18, 3) NOT NULL,
	[Price] [decimal](18, 3) NOT NULL,
	[PriceSellCurrencyId] [int] NOT NULL,
	[PriceCurrencyId] [int] NOT NULL,
	[CTM] [decimal](18, 3) NOT NULL,
	[CTR] [decimal](18, 3) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductPriceAudit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
IF NOT EXISTS (SELECT * FROM dbo.sysindexes WHERE id = OBJECT_ID(N'[dbo].[ProductPriceAudit]') AND name = N'IX_ProductPriceAudit')
CREATE NONCLUSTERED INDEX [IX_ProductPriceAudit] ON [dbo].[ProductPriceAudit] 
(
	[ProductId] ASC,
	[PriceListId] ASC,
	[CreatedOn] DESC
)
GO
/****** Object:  Table [dbo].[ProductPrice]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ProductPrice]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ProductPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PriceListId] [int] NOT NULL,
	[PriceSell] [decimal](18, 3) NOT NULL,
	[Price] [decimal](18, 3) NOT NULL,
	[PriceCurrencyId] [int] NOT NULL,
	[PriceSellCurrencyId] [int] NOT NULL,
	[CTM] [decimal](18, 3) NOT NULL,
	[CTR] [decimal](18, 3) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[ProductAudit]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ProductAudit]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ProductAudit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriceSuggest] [decimal](18, 3) NOT NULL,
	[PriceSuggestCurrencyId] [int] NOT NULL,
	[PricePurchase] [decimal](18, 3) NOT NULL,
	[PricePurchaseCurrencyId] [int] NOT NULL,
	[Code] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[FamilyId] [int] NOT NULL,
	[Description] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[CreatedBy] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductAudit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  Table [dbo].[ProductByPriceList]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ProductByPriceList]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ProductByPriceList](
	[ProductId] [int] NOT NULL,
	[PriceListId] [int] NOT NULL,
 CONSTRAINT [PK_ProductByPriceList] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[PriceListId] ASC
)
)
END
GO
/****** Object:  Table [dbo].[ProductBySelection]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ProductBySelection]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ProductBySelection](
	[ProductId] [int] NOT NULL,
	[SelectionId] [int] NOT NULL,
 CONSTRAINT [PK_ProductBySelection] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[SelectionId] ASC
)
)
END
GO
/****** Object:  Table [dbo].[ProductByCategory]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ProductByCategory]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ProductByCategory](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductByCategory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)
)
END
GO
/****** Object:  Table [dbo].[UserAudit]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UserAudit]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[UserAudit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Action] [int] NOT NULL,
	[Comment] [nvarchar](50) COLLATE Latin1_General_BIN NOT NULL,
	[ProductId] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_UserAudit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
END
GO
/****** Object:  View [dbo].[viewLastProductPrice]    Script Date: 04/07/2009 15:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[viewLastProductPrice]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[viewLastProductPrice]
AS
SELECT     PP.Id AS ProductPriceId, PPA.ProductId, PPA.PriceListId, PPA.Price
FROM         dbo.ProductPriceAudit AS PPA INNER JOIN
                          (SELECT     ProductId, PriceListId, MAX(ModifiedOn) AS LastDate
                            FROM          dbo.ProductPriceAudit
                            GROUP BY ProductId, PriceListId) AS TMP ON PPA.ProductId = TMP.ProductId AND PPA.PriceListId = TMP.PriceListId AND 
                      PPA.ModifiedOn = TMP.LastDate INNER JOIN
                      dbo.ProductPrice AS PP ON PP.ProductId = TMP.ProductId AND PP.PriceListId = TMP.PriceListId
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'USER',N'dbo', N'VIEW',N'viewLastProductPrice', NULL,NULL))
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PPA"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PP"
            Begin Extent = 
               Top = 6
               Left = 417
               Bottom = 121
               Right = 569
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TMP"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 106
               Right = 379
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1500
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewLastProductPrice'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'USER',N'dbo', N'VIEW',N'viewLastProductPrice', NULL,NULL))
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewLastProductPrice'
GO
/****** Object:  Default [DF_Family_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Family_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Family_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_Family_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Family_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Family_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_Family_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Family_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Family_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_Family_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Family_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Family_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_CtrRange_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CtrRange_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CtrRange] ADD  CONSTRAINT [DF_CtrRange_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_CtrRange_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CtrRange_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CtrRange] ADD  CONSTRAINT [DF_CtrRange_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_CtrRange_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CtrRange_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CtrRange] ADD  CONSTRAINT [DF_CtrRange_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_CtrRange_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CtrRange_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CtrRange] ADD  CONSTRAINT [DF_CtrRange_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_Currency_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Currency_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_Currency_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Currency_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_Currency_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Currency_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_Currency_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Currency_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Currency] ADD  CONSTRAINT [DF_Currency_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_Discount_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Discount_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [DF_Discount_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_Discount_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Discount_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [DF_Discount_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_Discount_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Discount_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [DF_Discount_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_Discount_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Discount_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Discount] ADD  CONSTRAINT [DF_Discount_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_PriceList_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_PriceList_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_PriceList_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_PriceList_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_PriceList_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_PriceList_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_PriceList_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_PriceList_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_Product_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Product_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_Product_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Product_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_Product_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Product_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_Product_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Product_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_Product_Status]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Product_Status]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Status]  DEFAULT (1) FOR [Status]

END
GO
/****** Object:  Default [DF_ProductAudit_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductAudit_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAudit] ADD  CONSTRAINT [DF_ProductAudit_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_ProductAudit_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductAudit_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAudit] ADD  CONSTRAINT [DF_ProductAudit_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_ProductAudit_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductAudit_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAudit] ADD  CONSTRAINT [DF_ProductAudit_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_ProductAudit_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductAudit_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductAudit] ADD  CONSTRAINT [DF_ProductAudit_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_ProductPrice_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPrice_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPrice] ADD  CONSTRAINT [DF_ProductPrice_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_ProductPrice_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPrice_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPrice] ADD  CONSTRAINT [DF_ProductPrice_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_ProductPrice_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPrice_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPrice] ADD  CONSTRAINT [DF_ProductPrice_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_ProductPrice_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPrice_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPrice] ADD  CONSTRAINT [DF_ProductPrice_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_ProductPriceAudit_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPriceAudit_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPriceAudit] ADD  CONSTRAINT [DF_ProductPriceAudit_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_ProductPriceAudit_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPriceAudit_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPriceAudit] ADD  CONSTRAINT [DF_ProductPriceAudit_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_ProductPriceAudit_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPriceAudit_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPriceAudit] ADD  CONSTRAINT [DF_ProductPriceAudit_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_ProductPriceAudit_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ProductPriceAudit_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProductPriceAudit] ADD  CONSTRAINT [DF_ProductPriceAudit_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_Selection_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Selection_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Selection] ADD  CONSTRAINT [DF_Selection_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_Selection_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Selection_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Selection] ADD  CONSTRAINT [DF_Selection_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_Selection_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Selection_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Selection] ADD  CONSTRAINT [DF_Selection_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_Selection_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_Selection_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Selection] ADD  CONSTRAINT [DF_Selection_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  Default [DF_UserAudit_CreatedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UserAudit_CreatedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserAudit] ADD  CONSTRAINT [DF_UserAudit_CreatedBy]  DEFAULT (newid()) FOR [CreatedBy]

END
GO
/****** Object:  Default [DF_UserAudit_CreatedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UserAudit_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserAudit] ADD  CONSTRAINT [DF_UserAudit_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]

END
GO
/****** Object:  Default [DF_UserAudit_ModifiedBy]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UserAudit_ModifiedBy]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserAudit] ADD  CONSTRAINT [DF_UserAudit_ModifiedBy]  DEFAULT (newid()) FOR [ModifiedBy]

END
GO
/****** Object:  Default [DF_UserAudit_ModifiedOn]    Script Date: 04/07/2009 15:22:03 ******/
IF Not EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_UserAudit_ModifiedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserAudit] ADD  CONSTRAINT [DF_UserAudit_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]

END
GO
/****** Object:  ForeignKey [FK_PriceList_Discount]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_PriceList_Discount]') AND type = 'F')
ALTER TABLE [dbo].[PriceList]  WITH NOCHECK ADD  CONSTRAINT [FK_PriceList_Discount] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([Id])
GO
ALTER TABLE [dbo].[PriceList] CHECK CONSTRAINT [FK_PriceList_Discount]
GO
/****** Object:  ForeignKey [FK_Product_Currency]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_Product_Currency]') AND type = 'F')
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [FK_Product_Currency] FOREIGN KEY([PricePurchaseCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Currency]
GO
/****** Object:  ForeignKey [FK_Product_SuggestCurrency]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_Product_SuggestCurrency]') AND type = 'F')
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [FK_Product_SuggestCurrency] FOREIGN KEY([PriceSuggestCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SuggestCurrency]
GO
/****** Object:  ForeignKey [FK_ProductAudit_Family]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductAudit_Family]') AND type = 'F')
ALTER TABLE [dbo].[ProductAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductAudit_Family] FOREIGN KEY([FamilyId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductAudit] CHECK CONSTRAINT [FK_ProductAudit_Family]
GO
/****** Object:  ForeignKey [FK_ProductAudit_SuggestCurrency]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductAudit_SuggestCurrency]') AND type = 'F')
ALTER TABLE [dbo].[ProductAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductAudit_SuggestCurrency] FOREIGN KEY([PriceSuggestCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductAudit] CHECK CONSTRAINT [FK_ProductAudit_SuggestCurrency]
GO
/****** Object:  ForeignKey [FK_ProductByCategory_Family]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductByCategory_Family]') AND type = 'F')
ALTER TABLE [dbo].[ProductByCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductByCategory_Family] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductByCategory] CHECK CONSTRAINT [FK_ProductByCategory_Family]
GO
/****** Object:  ForeignKey [FK_ProductByCategory_Product]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductByCategory_Product]') AND type = 'F')
ALTER TABLE [dbo].[ProductByCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductByCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductByCategory] CHECK CONSTRAINT [FK_ProductByCategory_Product]
GO
/****** Object:  ForeignKey [FK_ProductByPriceList_PriceList]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductByPriceList_PriceList]') AND type = 'F')
ALTER TABLE [dbo].[ProductByPriceList]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductByPriceList_PriceList] FOREIGN KEY([PriceListId])
REFERENCES [dbo].[PriceList] ([Id])
GO
ALTER TABLE [dbo].[ProductByPriceList] CHECK CONSTRAINT [FK_ProductByPriceList_PriceList]
GO
/****** Object:  ForeignKey [FK_ProductByPriceList_ProductByPriceList]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductByPriceList_ProductByPriceList]') AND type = 'F')
ALTER TABLE [dbo].[ProductByPriceList]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductByPriceList_ProductByPriceList] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductByPriceList] CHECK CONSTRAINT [FK_ProductByPriceList_ProductByPriceList]
GO
/****** Object:  ForeignKey [FK_ProductBySelection_Product]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductBySelection_Product]') AND type = 'F')
ALTER TABLE [dbo].[ProductBySelection]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductBySelection_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductBySelection] CHECK CONSTRAINT [FK_ProductBySelection_Product]
GO
/****** Object:  ForeignKey [FK_ProductBySelection_Selection]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductBySelection_Selection]') AND type = 'F')
ALTER TABLE [dbo].[ProductBySelection]  WITH CHECK ADD  CONSTRAINT [FK_ProductBySelection_Selection] FOREIGN KEY([SelectionId])
REFERENCES [dbo].[Selection] ([Id])
GO
ALTER TABLE [dbo].[ProductBySelection] CHECK CONSTRAINT [FK_ProductBySelection_Selection]
GO
/****** Object:  ForeignKey [FK_ProductPrice_Currency]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPrice_Currency]') AND type = 'F')
ALTER TABLE [dbo].[ProductPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductPrice_Currency] FOREIGN KEY([PriceCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrice_Currency]
GO
/****** Object:  ForeignKey [FK_ProductPrice_Currency1]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPrice_Currency1]') AND type = 'F')
ALTER TABLE [dbo].[ProductPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductPrice_Currency1] FOREIGN KEY([PriceSellCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrice_Currency1]
GO
/****** Object:  ForeignKey [FK_ProductPrice_PriceList]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPrice_PriceList]') AND type = 'F')
ALTER TABLE [dbo].[ProductPrice]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductPrice_PriceList] FOREIGN KEY([PriceListId])
REFERENCES [dbo].[PriceList] ([Id])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrice_PriceList]
GO
/****** Object:  ForeignKey [FK_ProductPrice_Product]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPrice_Product]') AND type = 'F')
ALTER TABLE [dbo].[ProductPrice]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductPrice_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrice_Product]
GO
/****** Object:  ForeignKey [FK_ProductPriceAudit_PriceCurrency]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPriceAudit_PriceCurrency]') AND type = 'F')
ALTER TABLE [dbo].[ProductPriceAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductPriceAudit_PriceCurrency] FOREIGN KEY([PriceCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceAudit] CHECK CONSTRAINT [FK_ProductPriceAudit_PriceCurrency]
GO
/****** Object:  ForeignKey [FK_ProductPriceAudit_PriceList]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPriceAudit_PriceList]') AND type = 'F')
ALTER TABLE [dbo].[ProductPriceAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductPriceAudit_PriceList] FOREIGN KEY([PriceListId])
REFERENCES [dbo].[PriceList] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceAudit] CHECK CONSTRAINT [FK_ProductPriceAudit_PriceList]
GO
/****** Object:  ForeignKey [FK_ProductPriceAudit_Product]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPriceAudit_Product]') AND type = 'F')
ALTER TABLE [dbo].[ProductPriceAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductPriceAudit_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceAudit] CHECK CONSTRAINT [FK_ProductPriceAudit_Product]
GO
/****** Object:  ForeignKey [FK_ProductPriceAudit_SellCurrency]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ProductPriceAudit_SellCurrency]') AND type = 'F')
ALTER TABLE [dbo].[ProductPriceAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductPriceAudit_SellCurrency] FOREIGN KEY([PriceSellCurrencyId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ProductPriceAudit] CHECK CONSTRAINT [FK_ProductPriceAudit_SellCurrency]
GO
/****** Object:  ForeignKey [FK_UserAudit_Products]    Script Date: 04/07/2009 15:22:03 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_UserAudit_Products]') AND type = 'F')
ALTER TABLE [dbo].[UserAudit]  WITH NOCHECK ADD  CONSTRAINT [FK_UserAudit_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[UserAudit] CHECK CONSTRAINT [FK_UserAudit_Products]
GO
