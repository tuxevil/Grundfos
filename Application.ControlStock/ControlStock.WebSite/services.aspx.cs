using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PartnerNet.Common;
using PartnerNet.Domain;
using ControllerManager=PartnerNet.Business.ControllerManager;
using Product=PartnerNet.Domain.Product;
using PurchaseOrder=PartnerNet.Domain.PurchaseOrder;
using PurchaseOrderItem=PartnerNet.Domain.PurchaseOrderItem;

namespace Grundfos.StockForecast
{
    public partial class services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 3600;
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Seccion de Carga de datos historicos
            DateTime endDate = Config.CurrentDate;
            //DateTime endDate = Calendar1.SelectedDate;
            DateTime startDate = endDate.AddDays(-7);

            //IList<Grundfos.ScalaConnector.Product> prodlist = Grundfos.ScalaConnector.ControllerManager.Product.GetProductList();
            //IList<Grundfos.ScalaConnector.Transactions> trans = Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDate, endDate);
            //IList<Grundfos.ScalaConnector.PurchaseOrderItem> poil = Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetWeeklyTransaction(startDate, endDate);


            //foreach(Grundfos.ScalaConnector.Product prod in prodlist)
            //{
            //    if (ControllerManager.Product.GetProductInfo(prod.Id) != null)
            //    {
            //        PartnerNet.Domain.TransactionHistoryWeekly transax = new TransactionHistoryWeekly();

            //        int stock = 0;
            //        int purchases = 0;
            //        int sales = 0;
            //        int purchaseorders = 0;

            //        stock = prod.StockQ;

            //        foreach (Grundfos.ScalaConnector.Transactions transaction in trans)
            //        {
            //            if (transaction.Product == prod)
            //            {
            //                if (transaction.Quantity > 0)
            //                    purchases = purchases + transaction.Quantity;
            //                else if (transaction.Quantity < 0)
            //                    sales = sales + (-transaction.Quantity);
            //            }
            //        }

            //        foreach (Grundfos.ScalaConnector.PurchaseOrderItem poi in poil)
            //            if (poi.Product == prod)
            //                purchaseorders = poi.Quantity;

            //        transax.ProductID = ControllerManager.Product.GetProductInfo(prod.Id);
            //        transax.Purchase = purchases;
            //        transax.Sale = sales;
            //        transax.PurchaseOrders = purchaseorders;
            //        transax.Stock = stock;
            //        transax.Year = Config.CurrentDate.Year;
            //        transax.Week = Config.CurrentWeek;
            //        //borrar esta propiedad!!!
            //        transax.ProductCode = prod.Id;

            //        ControllerManager.TransactionHistoryWeekly.Save(transax);
            //    }
            //}

            ////Seccion de Calculo de promedios semanales
            //IList<Product> info = ControllerManager.Product.GetProductList();
            //ControllerManager.ProductStatisticWeekly.CleanTable();
            //for (int cont = 1; cont < 6; cont++)
            //{
            //    foreach (Product product in info)
            //    {
            //        ControllerManager.TransactionHistoryWeekly.CalculateStatistic(product, Config.CurrentWeek, Config.CurrentDate.Year, (Period)cont);
            //    }
            //}

            ////Seccion de generacion de Forecast y Ordenes de compras
            //foreach (Product product in info)
                //ControllerManager.Forecast.CalculateForecast(ControllerManager.Product.GetProductInfo(TextBox1.Text), Config.CurrentWeek, Config.CurrentDate.Year);

            IList<Forecast> polist = ControllerManager.Forecast.GetPOList(Config.CurrentWeek +1 , Config.CurrentDate.Year);
            foreach (Forecast forecast in polist)
                ControllerManager.PurchaseOrder.GeneratePO(forecast.Product, Config.CurrentWeek, Config.CurrentDate.Year, (PurchaseOrderType)1, 0);
        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
                ControllerManager.Forecast.CalculateForecast(ControllerManager.Product.GetProductInfo(TextBox1.Text), Config.CurrentWeek, Config.CurrentDate.Year);
            else
            {
                IList<Product> productlist = ControllerManager.Product.GetProductList();
                foreach (Product product in productlist)
                {
                    ControllerManager.Forecast.CalculateForecast(product, Config.CurrentWeek, Config.CurrentDate.Year);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ControllerManager.PurchaseOrder.CleanTable();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            IList<Grundfos.ScalaConnector.Product> productosScala = Grundfos.ScalaConnector.ControllerManager.Product.GetProductList();
            //IList<Product> productos = ControllerManager.Product.GetProductList();
            
            foreach (ScalaConnector.Product product in productosScala)
            {
                bool updated = false;
                Product producto = ControllerManager.Product.GetProductInfo(product.Id);
                if(producto != null)
                {
                    producto.Description = product.Description;
                    producto.Group = product.Group;
                    producto.Provider = ControllerManager.Provider.GetProvider(product.Provider.Id);
                    ControllerManager.Product.SaveOrUpdate(producto);
                    updated = true;
                }
                //foreach (Product producto in productos)
                //{
                //    if(product.Id == producto.ProductCode)
                //    {
                //        producto.Description = product.Description;
                //        producto.Group = product.Group;
                //        producto.Provider = ControllerManager.Provider.GetProvider(product.Provider.Id);
                //        ControllerManager.Product.SaveOrUpdate(producto);
                //        updated = true;
                //        break;
                //    }
                //}
                if(updated==false)
                {
                    Product nuevo = new Product();
                    nuevo.Description = product.Description;
                    nuevo.Group = product.Group;
                    nuevo.Provider = ControllerManager.Provider.GetProvider(product.Provider.Id);
                    nuevo.LeadTime = 11;
                    nuevo.ProductCode = product.Id;
                    nuevo.RepositionLevel = 10;
                    nuevo.RepositionPoint = 10;
                    nuevo.Safety = 6;
                    ControllerManager.Product.SaveOrUpdate(nuevo);
                    updated = true;
                }
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            IList<Grundfos.ScalaConnector.Provider> proveedoresScala = Grundfos.ScalaConnector.ControllerManager.Provider.GetProviderList();
            IList<Provider> proveedores = ControllerManager.Provider.GetProviderList();

            foreach (ScalaConnector.Provider provider in proveedoresScala)
            {
                bool updated = false;
                foreach (Provider proveedor in proveedores)
                {
                    if (provider.Id == proveedor.ProviderCode)
                    {
                        proveedor.Name = provider.Name;
                        updated = true;
                        break;
                    }
                }
                if (updated == false)
                {
                    Provider nuevo = new Provider();
                    nuevo.Name = provider.Name;
                    nuevo.ProviderCode = provider.Id;
                    ControllerManager.Provider.SaveOrUpdate(nuevo);
                    updated = true;
                }
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Seccion de Carga de datos historicos
            //DateTime endDate = Config.CurrentDate;
            DateTime endDate = Calendar1.SelectedDate;
            DateTime startDate = endDate.AddDays(-7);

            IList<Grundfos.ScalaConnector.Product> prodlist =
                Grundfos.ScalaConnector.ControllerManager.Product.GetProductList(
                    ControllerManager.Product.GetProductList());
            IList<Grundfos.ScalaConnector.Transactions> trans =
                Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDate, endDate);
            IList<Grundfos.ScalaConnector.PurchaseOrderItem> poil =
                Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetWeeklyTransaction(startDate, endDate);


            foreach (Grundfos.ScalaConnector.Product prod in prodlist)
            {
                if (ControllerManager.Product.GetProductInfo(prod.Id) != null)
                {
                    PartnerNet.Domain.TransactionHistoryWeekly transax = new TransactionHistoryWeekly();

                    int stock = 0;
                    int purchases = 0;
                    int sales = 0;
                    int purchaseorders = 0;

                    stock = prod.StockQ;

                    foreach (Grundfos.ScalaConnector.Transactions transaction in trans)
                    {
                        if (transaction.Product == prod)
                        {
                            if (transaction.Quantity > 0)
                                purchases = purchases + transaction.Quantity;
                            else if (transaction.Quantity < 0)
                                sales = sales + (-transaction.Quantity);
                        }
                    }

                    foreach (Grundfos.ScalaConnector.PurchaseOrderItem poi in poil)
                        if (poi.Product == prod)
                            purchaseorders = poi.Quantity;

                    transax.ProductID = ControllerManager.Product.GetProductInfo(prod.Id);
                    transax.Purchase = purchases;
                    transax.Sale = sales;
                    transax.PurchaseOrders = purchaseorders;
                    transax.Stock = stock;
                    transax.Year = endDate.Year;
                    transax.Week = Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(endDate,CalendarWeekRule.FirstFourDayWeek,DayOfWeek.Sunday);
                    //borrar esta propiedad!!!
                    transax.ProductCode = prod.Id;

                    ControllerManager.TransactionHistoryWeekly.Save(transax);
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //Seccion de Calculo de promedios semanales
            IList<Product> info = ControllerManager.Product.GetProductList();
            ControllerManager.ProductStatisticWeekly.CleanTable();
            for (int cont = 1; cont < 3; cont++)
            {
                foreach (Product product in info)
                {
                    ControllerManager.TransactionHistoryWeekly.CalculateStatistic(product, Config.CurrentWeek, Config.CurrentDate.Year, (Period)cont);
                }
            }
        }
    }
}
