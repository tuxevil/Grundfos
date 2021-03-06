SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewProductInfo]
AS
SELECT DISTINCT 
	PB.Id as Id, 
	PB.Id as PriceBaseId,
	(PB.PriceBaseSell * CPS.Value) - (PB.PricePurchase * CPP.Value) AS CTM, 
	CASE WHEN (PB.PriceBaseSell = 0) THEN 0 ELSE (1 - ((PB.PricePurchase * CPP.Value) / (PB.PriceBaseSell * CPS.Value))) * 100 END AS CTR,
	CASE WHEN (PB.PriceSuggest = 0) THEN 0 ELSE (1 - ((PB.PriceBaseSell * CPS.Value) / (PB.PriceSuggest * CPSG.Value))) * 100 END AS [Index]

FROM dbo.PriceBase AS PB 
	LEFT JOIN dbo.Currency AS CPP ON PB.PricePurchaseCurrencyId = CPP.Id 
	LEFT JOIN dbo.Currency AS CPS ON PB.PriceBaseSellCurrencyId = CPS.Id 
	LEFT JOIN dbo.Currency AS CPSG ON PB.PriceSuggestCurrencyId = CPS.Id 
GO
CREATE VIEW [dbo].[viewProductInfoByGroup]
AS
SELECT DISTINCT 
	PB.Id as Id,
	PB.Id as PriceBaseId,
	PA.PriceGroupId as PriceGroupId,
	(PA.PriceSell * CPS.Value) - (PB.PricePurchase * CPP.Value) AS CTM, 
	CASE WHEN (PA.PriceSell = 0) THEN 0 ELSE (1 - ((PB.PricePurchase * CPP.Value) / (PA.PriceSell * CPS.Value))) * 100 END AS CTR,
	CASE WHEN (PB.PriceSuggest = 0) THEN 0 ELSE (1 - ((PA.PriceSell * CPS.Value) / (PB.PriceSuggest * CPSG.Value))) * 100 END AS [Index]
					
FROM dbo.PriceBase AS PB 
	LEFT JOIN dbo.PriceAttribute PA on PA.BasePriceId = PB.Id
	LEFT JOIN dbo.Currency AS CPP ON PB.PricePurchaseCurrencyId = CPP.Id 
	LEFT JOIN dbo.Currency AS CPS ON PA.PriceSellCurrencyId = CPS.Id 
	LEFT JOIN dbo.Currency AS CPSG ON PB.PriceSuggestCurrencyId = CPS.Id 
