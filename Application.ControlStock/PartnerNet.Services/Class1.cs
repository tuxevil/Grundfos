using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using PartnerNet.Business;
using PartnerNet.Domain;

namespace PartnerNet.Services
{
    public class Class1
    {
        public void GetTransactionHistory(IList<Grundfos.ScalaConnector.Product> prodlist, DateTime startDate, DateTime endDate)
        {
            foreach (Grundfos.ScalaConnector.Product prod in prodlist)
            {
                PartnerNet.Domain.TransactionHistoryWeekly transax = new TransactionHistoryWeekly();

                IList<Grundfos.ScalaConnector.Transactions> trans = Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(DateTime.Today.Year, endDate, startDate, prod);
                IList<Grundfos.ScalaConnector.PurchaseOrder> pol = Grundfos.ScalaConnector.ControllerManager.PurchaseOrder.FilterByWeek(DateTime.Today.Year, endDate, startDate);

                int purchases = 0;
                int sales = 0;
                int purchaseorders = 0;
                int stock = 0;

                stock = prod.StockQ;

                foreach (Grundfos.ScalaConnector.Transactions transaction in trans)
                {
                    if (transaction.Quantity > 0)
                        purchases = purchases + transaction.Quantity;
                    else if (transaction.Quantity < 0)
                        sales = sales + (-transaction.Quantity);
                }
                foreach (Grundfos.ScalaConnector.PurchaseOrder po in pol)
                {
                    Grundfos.ScalaConnector.PurchaseOrderItem poi = Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetPurchaseOrderInfo(prod, po);
                    if (poi != null)
                        purchaseorders = purchaseorders + poi.Quantity;
                }

                transax.ProductID = ControllerManager.Product.GetProductInfo(prod.Id);
                transax.Purchase = purchases;
                transax.Sale = sales;
                transax.PurchaseOrders = purchaseorders;
                transax.Stock = stock;
                transax.Year = DateTime.Today.Year;
                transax.Week = Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
                //borrar esta propiedad!!!
                transax.ProductCode = prod.Id;

                this.Save(transax);
            }
        }
    }
}
