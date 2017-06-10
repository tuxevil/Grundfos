CREATE TABLE [dbo].[Despachos] (
	[Despacho] [char] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NroFCProv] [char] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Despachos] WITH NOCHECK ADD 
	CONSTRAINT [PK_Despachos] PRIMARY KEY  CLUSTERED 
	(
		[Despacho],
		[NroFCProv]
	)  ON [PRIMARY] 
GO

