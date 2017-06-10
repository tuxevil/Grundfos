using System;
using System.Collections;
using System.Globalization;
using System.Threading;
using Grundfos.ScalaConnector;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PartnerNet.Common;
using PartnerNet.Domain;
using PartnerNet.Providers.Stock;
using Product=Grundfos.ScalaConnector.Product;
using PurchaseOrder=Grundfos.ScalaConnector.PurchaseOrder;
using PurchaseOrderItem=Grundfos.ScalaConnector.PurchaseOrderItem;


namespace Grundfos.StockForecast
{
    public partial class test : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = ControllerManager.Product.FilterByGroup(TextBox1.Text);
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = ControllerManager.ProductDetail.FilterByLocation(TextBox1.Text);
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "0")
            { this.GridView1.DataSource = ControllerManager.PurchaseOrder.FilterByMonth(Config.CurrentDate.Year, Config.CurrentDate.Month); }
            else
            { this.GridView1.DataSource = ControllerManager.SaleOrder.FilterByMonth(Config.CurrentDate.Year, Config.CurrentDate.Month); }
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DateTime endDate = Config.CurrentDate;
            DateTime startDate = Config.CurrentDate.AddDays(-7);

            //int week = Config.CurrentWeek;
            //TextBox1.Text = week.ToString();
            if (RadioButtonList1.SelectedValue == "0")
            {this.GridView1.DataSource = ControllerManager.PurchaseOrder.FilterByWeek(startDate, endDate);}
            else
            {this.GridView1.DataSource = ControllerManager.SaleOrder.FilterByWeek(Config.CurrentDate.Year, endDate, startDate);}
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DateTime endDate = Config.CurrentDate;
            DateTime startDate = Config.CurrentDate.AddDays(-7);
            this.GridView1.DataSource = ControllerManager.PurchaseOrderItem.GetMonthlyTransaction(Config.CurrentDate.Year, Config.CurrentDate.Month);
            this.GridView2.DataSource = ControllerManager.SaleOrderItem.GetMonthlyTransaction(Config.CurrentDate.Year, Config.CurrentDate.Month);
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Product prod = ControllerManager.Product.GetProductInfo("59539502");
            DateTime endDate = Config.CurrentDate;
            DateTime startDate = Config.CurrentDate.AddDays(-7);

            IList<PartnerNet.Domain.TransactionHistoryWeekly> translist = new List<PartnerNet.Domain.TransactionHistoryWeekly>();

            //aca va un for por cada producto de la lista de productos
            {
                PartnerNet.Domain.TransactionHistoryWeekly transax = new TransactionHistoryWeekly();

                IList<Transactions> trans = ControllerManager.Transactions.GetTransaction(startDate, endDate, prod);
                IList<PurchaseOrder> pol = ControllerManager.PurchaseOrder.FilterByWeek(startDate, endDate);

                int purchases = 0;
                int sales = 0;
                int purchaseorders = 0;
                int stock = 0;

                stock = prod.StockQ;

                foreach (Transactions transaction in trans)
                {
                    if (transaction.Quantity > 0)
                        purchases = purchases + transaction.Quantity;
                    else if (transaction.Quantity < 0)
                        sales = sales + (-transaction.Quantity);
                }
                foreach (PurchaseOrder po in pol)
                {
                    PurchaseOrderItem poi = ControllerManager.PurchaseOrderItem.GetPurchaseOrderInfo(prod, po);
                    if (poi != null)
                        purchaseorders = purchaseorders + poi.Quantity;
                }

                transax.ProductID = PartnerNet.Business.ControllerManager.Product.GetProductInfo(prod.Id);
                transax.Purchase = purchases;
                transax.Sale = sales;
                transax.PurchaseOrders = purchaseorders;
                transax.Stock = stock;
                transax.Year = Config.CurrentDate.Year;
                transax.Week = Config.CurrentWeek;
                //borrar esta propiedad!!!
                transax.ProductCode = prod.Id;

                translist.Add(transax);
            }

            GridView1.DataSource = translist;
            GridView1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            PartnerNet.Business.ControllerManager.Forecast.CalculateForecast(PartnerNet.Business.ControllerManager.Product.GetById(12940), Config.CurrentWeek, Config.CurrentDate.Year);
//            StockManager.GetMonthHistoricTransaction();
        }
    }

}
