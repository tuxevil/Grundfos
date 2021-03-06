set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_DiscountModification] 
	@discountid int,
	@userid uniqueidentifier,
	@moddate datetime

AS
BEGIN
	SET NOCOUNT ON;

	insert into  ProductPriceAudit(ProductId, PriceListId, PriceSell, Price, PriceSellCurrencyId, PriceCurrencyId, CTM, CTR, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) 
	select PP.ProductId, PP.PriceListId, PP.PriceSell, PP.Price, PP.PriceSellCurrencyId, PP.PriceCurrencyId, PP.CTM, PP.CTR, PP.CreatedBy, PP.CreatedOn, PP.ModifiedBy, PP.ModifiedOn
	from ProductPrice PP
	inner join PriceList PL
	on PP.PriceListId = PL.Id
	inner join Product P
	on PP.ProductId = P.Id
	inner join Discount D
	on PL.DiscountId = D.Id
	inner join Currency CP
	on PP.PriceCurrencyId = CP.Id
	inner join Currency CPS
	on PP.PriceSellCurrencyId = CPS.Id
	inner join Currency CPP
	on P.PricePurchaseCurrencyId = CPP.Id

	where D.Id = @discountid
-------------------------------------------------------------------------------------------------------------------
    update ProductPrice

	set PriceSell = (((PP.Price * CP.Value) / 100 * (100 - D.MaxDiscount)) / CPS.Value),
	CTM = (((((PP.Price * CP.Value) * (100 - D.MaxDiscount)/100) / CPS.Value) * CPS.Value) - (P.PricePurchase * CPP.Value)),
	CTR = (((((((PP.Price * CP.Value) * (100 - D.MaxDiscount)/100) / CPS.Value) * CPS.Value) - (P.PricePurchase * CPP.Value)) * 100) / (P.PricePurchase * CPP.Value)),
	ModifiedBy = @userid,
	ModifiedOn = @moddate

	from ProductPrice PP
	inner join PriceList PL
	on PP.PriceListId = PL.Id
	inner join Product P
	on PP.ProductId = P.Id
	inner join Discount D
	on PL.DiscountId = D.Id
	inner join Currency CP
	on PP.PriceCurrencyId = CP.Id
	inner join Currency CPS
	on PP.PriceSellCurrencyId = CPS.Id
	inner join Currency CPP
	on P.PricePurchaseCurrencyId = CPP.Id

	where D.Id = @discountid
END




