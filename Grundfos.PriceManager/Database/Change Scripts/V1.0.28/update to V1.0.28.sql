
begin transaction
go

alter table dbo.Category alter column
  [Name] nvarchar(512) not null
go

alter table dbo.Category alter column
  Description nvarchar(512)
go

alter table dbo.Product alter column
  Code nvarchar(50) not null
go

update dbo.Product set Description = convert(nvarchar(256), Description)
go

alter table dbo.Product alter column
  Description nvarchar(256) not null
go

create index IX_Product on dbo.Product(Code,Description)
go

create unique index IX_Code on dbo.Product(Code)
go

create index IX_Description on dbo.Product(Description)
go

create index IX_ProductPrice on dbo.ProductPrice(CTR)
go

create index IX_ProductType on dbo.PriceList(ProductType)
go

drop index dbo.ProductPriceAudit.IX_ProductPriceAudit_Unique
go

drop index dbo.ProductPriceAudit.IX_ProductPriceAudit
go

create unique index IX_ProductPriceAudit on dbo.ProductPriceAudit(ProductId,PriceListId,ModifiedOn)
go

alter PROCEDURE dbo.sp_DiscountModification 
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
	CTR = CASE WHEN (PriceSell = 0) THEN 0 ELSE (1 - ((P.PricePurchase * CPP.Value) / (PP.PriceSell * CPS.Value))) * 100 END,
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
go

commit
go
