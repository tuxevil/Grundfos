alter table Product
	add Disarm bit not null default 0;
alter table Product
	add AlertRepositionShow bit not null default 1;
alter table Product
	add LowCost bit not null default 0;
alter table Product
	add ScalaRep0 bit not null default 0;
update Product set Disarm = 1 where ProductCode in (select distinct SC06002 from Grundfos_Scala.dbo.SC060100 where SC06001 = 'B');
update Product set ScalaRep0 = 1 where ProductCode in (select distinct SC03001 from Grundfos_Scala.dbo.SC030100 where SC03010 = '0')

alter table AlertProduct
	add Location varchar(2) not null default '00';
alter table AlertProduct
	add ProductId int;
alter table AlertProduct
	drop column ProductCode;
alter table AlertSaleOrder
	add Type int not null default 0;
alter table AlertSaleOrder
	drop column PurchaseOrderCode;
alter table AlertSaleOrder
	drop column PurchaseOrderItemCode;
alter table AlertSaleOrder
	drop column WayOfDelivery;
alter table AlertSaleOrder
	add ProductId int;
alter table AlertSaleOrder
	add CustomerName varchar(100);
alter table AlertPurchaseOrder
	drop column PurchaseOrderItemCode;
alter table AlertPurchaseOrder
	add ProductId int;