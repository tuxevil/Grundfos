set xact_abort on
go

begin transaction
go

alter table dbo.Currency alter column
  Description nvarchar(50) not null
go

alter table dbo.ProductAudit alter column
  Code nvarchar(50) not null
go

alter table dbo.ProductAudit alter column
  Description nvarchar(50) not null
go

alter table dbo.ProductAudit drop
  constraint DF_ProductAudit_CreatedBy 
go

alter table dbo.ProductAudit alter column
  CreatedBy nvarchar(50) not null
go

alter table dbo.ProductAudit drop
  constraint DF_ProductAudit_ModifiedBy 
go

alter table dbo.ProductAudit alter column
  ModifiedBy nvarchar(50) not null
go

alter table dbo.ProductAudit add
  constraint DF_ProductAudit_CreatedBy default (newid()) for CreatedBy,
  constraint DF_ProductAudit_ModifiedBy default (newid()) for ModifiedBy,
  constraint FK_ProductAudit_SuggestCurrency foreign key(PriceSuggestCurrencyId) references dbo.Currency(Id)
go

alter table dbo.ProductBySelection add
  constraint FK_ProductBySelection_Product foreign key(ProductId) references dbo.Product(Id)
go

alter table dbo.Discount alter column
  Description nvarchar(50) not null
go

alter table dbo.ProductPrice add
  constraint FK_ProductPrice_Currency foreign key(PriceCurrencyId) references dbo.Currency(Id),
  constraint FK_ProductPrice_Currency1 foreign key(PriceSellCurrencyId) references dbo.Currency(Id),
  constraint FK_ProductPrice_Product foreign key(ProductId) references dbo.Product(Id)
go

alter table dbo.PriceList alter column
  Description nvarchar(50) not null
go

alter table dbo.ProductByPriceList add
  constraint FK_ProductByPriceList_ProductByPriceList foreign key(ProductId) references dbo.Product(Id)
go

alter table dbo.ProductPriceAudit add
  constraint FK_ProductPriceAudit_PriceCurrency foreign key(PriceCurrencyId) references dbo.Currency(Id),
  constraint FK_ProductPriceAudit_SellCurrency foreign key(PriceSellCurrencyId) references dbo.Currency(Id),
  constraint FK_ProductPriceAudit_Product foreign key(ProductId) references dbo.Product(Id)
go

alter table dbo.Selection alter column
  Description nvarchar(50) not null
go

alter table dbo.UserAudit alter column
  Comment nvarchar(50) not null
go

alter table dbo.UserAudit add
  constraint FK_UserAudit_Products foreign key(ProductId) references dbo.Product(Id)
go

alter table dbo.Product alter column
  Code nvarchar(50) not null
go

alter table dbo.Product alter column
  Description nvarchar(1024) not null
go

update dbo.Product set Status = 1 where Status is null
go

alter table dbo.Product alter column
  Status int not null
go

alter table dbo.Product add
  constraint DF_Product_Status default (1) for Status
go

alter table dbo.ProductByCategory drop
  constraint FK_ProductByCategory_Family 
go

alter table dbo.Category drop
  constraint DF_Family_CreatedBy ,
  constraint DF_Family_CreatedOn ,
  constraint DF_Family_ModifiedBy ,
  constraint DF_Family_ModifiedOn 
go

exec sp_rename 'dbo.PK_Family', 'tmp__PK_Family', 'OBJECT'
go

exec sp_rename 'dbo.Category', 'tmp__Category_1', 'OBJECT'
go

create table dbo.Category(
  Id          int              not null identity constraint PK_Family primary key,
  Parent      int              not null,
  [Name]      nvarchar(50)     not null,
  Description nvarchar(250),
  CreatedBy   uniqueidentifier not null constraint DF_Family_CreatedBy default (newid()),
  CreatedOn   datetime         not null constraint DF_Family_CreatedOn default (getdate()),
  ModifiedBy  uniqueidentifier not null constraint DF_Family_ModifiedBy default (newid()),
  ModifiedOn  datetime         not null constraint DF_Family_ModifiedOn default (getdate())
)
go

set identity_insert dbo.Category on
go

insert into dbo.Category(Id,Parent,[Name],Description,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn) select Id,Parent,N'',convert(nvarchar(250), Description),CreatedBy,CreatedOn,ModifiedBy,ModifiedOn from dbo.tmp__Category_1
go

set identity_insert dbo.Category off
go

drop table dbo.tmp__Category_1
go

set ANSI_NULLS on
go

create PROCEDURE dbo.sp_DiscountModification 
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

	set PriceSell = (((PP.Price * CP.Value) * (100 - D.MaxDiscount)/100) / CPS.Value),
	CTM = ((PP.PriceSell * CP.Value) - (P.PricePurchase * CPP.Value)),
	CTR = ((PP.CTM * 100) / (P.PricePurchase * CPP.Value)),
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

begin transaction
go

alter table dbo.ProductByCategory add
  constraint FK_ProductByCategory_Family foreign key(CategoryId) references dbo.Category(Id)
go

alter table dbo.ProductAudit add
  constraint FK_ProductAudit_Family foreign key(FamilyId) references dbo.Category(Id)
go

commit
go


