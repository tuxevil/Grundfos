using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Grundfos.ScalaConnector;
using ParnerNet.Integrators.Scala;
using PartnerNet.Common;
using PartnerNet.Domain;
using ControllerManager=PartnerNet.Business.ControllerManager;
using MailMessage=System.Net.Mail.MailMessage;
using Product=PartnerNet.Domain.Product;
using PurchaseOrder=PartnerNet.Domain.PurchaseOrder;
using PurchaseOrderItem=PartnerNet.Domain.PurchaseOrderItem;

namespace Grundfos.StockForecast
{
    public partial class services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.ScriptTimeout = 5600;
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {

            ControllerManager.PurchaseOrder.GenerateFullPO(Config.CurrentWeek, Config.CurrentDate.Year, PurchaseOrderType.Forecast);

        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "")
            {
                IList<Product> tempprodlist = new List<Product>();
                ControllerManager.Forecast.CalculateFullForecast(Config.CurrentWeek, Config.CurrentDate.Year, tempprodlist, true);
            }
            else
            {
                List<Product> prodlist = new List<Product>();
                Product producto = ControllerManager.Product.GetProductInfo(TextBox1.Text);
                prodlist.Add(producto);
                ControllerManager.Forecast.CalculateFullForecast(Config.CurrentWeek, Config.CurrentDate.Year, prodlist, false);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ControllerManager.PurchaseOrder.CleanTable();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            IList<Grundfos.ScalaConnector.Product> productosScala = Grundfos.ScalaConnector.ControllerManager.Product.GetProductList();
            List<PartnerNet.Domain.Product> productos = ControllerManager.Product.GetFullProductList();
            List<PartnerNet.Domain.Provider> proveedores = ControllerManager.Provider.GetFullProviderList();

            foreach (Grundfos.ScalaConnector.Product product in productosScala)
            {
                PartnerNet.Domain.Product producto = productos.Find(delegate(PartnerNet.Domain.Product record)
                                              {
                                                  if (record.ProductCode != product.Id)
                                                  {
                                                      return false;
                                                  }
                                                  return true;
                                              });

                if (producto == null)
                {
                    producto = new PartnerNet.Domain.Product();
                    producto.ProductCode = product.Id;
                    producto.Safety = 6;
                }

                producto.Description = product.Description;
                producto.Group = product.Group;
                producto.LeadTime = product.Detail[0].Leadtime;
                producto.CountryCode = product.CountryCode;
                if (producto.RepositionLevel != product.Detail[0].RepPoint)
                {
                    producto.RepositionLevel = product.Detail[0].RepPoint;
                    //ProductRepositionLevelHistory prlh = new ProductRepositionLevelHistory();
                    //prlh.Product = producto;
                    //prlh.RepositionLevel = producto.RepositionLevel;
                    //ControllerManager.Product.GenericSave(prlh);
                }
                producto.RepositionPoint = product.Detail[0].PurchaseMod;
                producto.AlternativeProduct = product.AlternativeProduct;
                producto.AlternativeDate = product.AlternativeDate;
                PartnerNet.Domain.Provider provtemp = proveedores.Find(delegate(PartnerNet.Domain.Provider record)
                                                         {
                                                             if (record.ProviderCode != product.Provider.Id)
                                                             {
                                                                 return false;
                                                             }
                                                             return true;
                                                         });
                if (provtemp != null)
                    producto.Provider = provtemp;
                else if (provtemp == null)
                    producto.Provider = proveedores.Find(delegate(PartnerNet.Domain.Provider record)
                                                         {
                                                             if (record.ProviderCode != "999999")
                                                             {
                                                                 return false;
                                                             }
                                                             return true;
                                                         });

                ControllerManager.Product.Save(producto);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            IList<Grundfos.ScalaConnector.Provider> proveedoresScala =
                   Grundfos.ScalaConnector.ControllerManager.Provider.GetProviderList();
            List<PartnerNet.Domain.Provider> proveedores = ControllerManager.Provider.GetFullProviderList();

            foreach (Grundfos.ScalaConnector.Provider provider in proveedoresScala)
            {
                bool updated = false;
                PartnerNet.Domain.Provider prov = null;
                prov = proveedores.Find(delegate(PartnerNet.Domain.Provider record)
                                            {
                                                if (record.ProviderCode != provider.Id)
                                                {
                                                    return false;
                                                }
                                                return true;
                                            });

                if (prov != null)
                {
                    prov.Name = provider.Name;
                    prov.CountryCode = provider.CountryCode;
                    updated = true;
                }

                if (updated == false)
                {
                    PartnerNet.Domain.Provider nuevo = new PartnerNet.Domain.Provider();
                    nuevo.Name = provider.Name;
                    nuevo.ProviderCode = provider.Id;
                    nuevo.CountryCode = provider.CountryCode;
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
            IList<ScalaConnector.Product> prodlist;
        
            if (TextBox1.Text == "")
            {
                  prodlist = Grundfos.ScalaConnector.ControllerManager.Product.GetProductList();
            }
            else
            {
                prodlist = Grundfos.ScalaConnector.ControllerManager.Product.GetProductListInfo(TextBox1.Text);
            }
            List<PartnerNet.Domain.Product> productlist = ControllerManager.Product.GetProductListAlt();
                List<Transactions> transcomp =
                    Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDate, endDate, 0);
                List<Transactions> transvent =
                    Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDate, endDate, 1);
                List<ScalaConnector.PurchaseOrderItem> poil =
                    Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetWeeklyTransaction(startDate,
                                                                                                     endDate);

                foreach (ScalaConnector.Product prod in prodlist)
                {
                    PartnerNet.Domain.Product producto = null;
                    producto = productlist.Find(delegate(PartnerNet.Domain.Product record)
                                                    {
                                                        if (record.ProductCode != prod.Id)
                                                        {
                                                            return false;
                                                        }
                                                        return true;
                                                    });

                    if (producto != null)
                    {
                        #region Generate TransactionHistoryWeekly

                        TransactionHistoryWeekly transax = new TransactionHistoryWeekly();

                        int stock = 0;
                        int purchases = 0;
                        int sales = 0;
                        int purchaseorders = 0;

                        stock = prod.StockQ;

                        Transactions subList = null;

                        subList = transcomp.Find(delegate(Transactions record)
                                                     {
                                                         if (record.Product != prod)
                                                         {
                                                             return false;
                                                         }
                                                         return true;
                                                     });

                        if (subList != null)
                            purchases = subList.Quantity;

                        subList = transvent.Find(delegate(Transactions record)
                                                     {
                                                         if (record.Product != prod)
                                                         {
                                                             return false;
                                                         }
                                                         return true;
                                                     });
                        if (subList != null)
                            sales = -subList.Quantity;

                        ScalaConnector.PurchaseOrderItem subList2 = null;
                        subList2 = poil.Find(delegate(ScalaConnector.PurchaseOrderItem record)
                                                 {
                                                     if (record.Product != prod)
                                                     {
                                                         return false;
                                                     }
                                                     return true;
                                                 });

                        if (subList2 != null)
                            purchaseorders = subList2.QuantityOrdered;


                        transax.ProductID = producto;
                        transax.Purchase = purchases;
                        transax.Sale = sales;
                        transax.PurchaseOrders = purchaseorders;
                        transax.Stock = stock;
                        transax.Year = endDate.Year;
                        transax.Week =
                            Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(endDate,
                                                                                       CalendarWeekRule.
                                                                                           FirstFourDayWeek,
                                                                                       DayOfWeek.Sunday);
                        transax.ProductCode = prod.Id;

                        ControllerManager.TransactionHistoryWeekly.Save(transax);

                        #endregion
                    }
                }

                ControllerManager.TransactionHistoryWeekly.Copy();
            

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
          
            ControllerManager.TransactionHistoryWeekly.CalculateFullStatistic(Config.CurrentWeek, Config.CurrentDate.Year);
            return;

        
        }



        protected void stockNegativo_Click(object sender, EventArgs e)
        {
           
            List<Product> templist = ControllerManager.Product.GetAlertNegativeFutureStock();
            PartnerNet.Domain.Product prodtemp = null;

            foreach (PartnerNet.Domain.Product product in templist)
            {
                if (prodtemp != product)
                {
                    AlertProduct alert = new AlertProduct();
                    alert.StandardCost = 0;
                    alert.SubTotal = 0;
                    alert.Quantity = product.Forecasts[0].FinalStock;
                    DateTime fechatemp = Convert.ToDateTime("01/01/" + Config.CurrentDate.Year.ToString());
                    fechatemp = Thread.CurrentThread.CurrentCulture.Calendar.AddWeeks(fechatemp, product.Forecasts[0].Week);
                    alert.NegativeDate = fechatemp.AddDays(-7 + (int)fechatemp.DayOfWeek);
                    alert.Type = 2;
                    alert.Product = product;

                    ControllerManager.AlertProduct.Save(alert);

                    prodtemp = product;
                }
            }
            return;

        
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string errors;
            new ForecastProcessor().Execute(out errors);
            Response.Write(errors);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            for (DateTime fecha = Convert.ToDateTime("01/05/2008"); fecha < Convert.ToDateTime("12/14/2008"); fecha = fecha.AddDays(7))
            {
                //Seccion de Carga de datos historicos
                //DateTime endDate = Config.CurrentDate;
                DateTime endDate = fecha;
                DateTime startDate = endDate.AddDays(-7);

                IList<Grundfos.ScalaConnector.Product> prodlist =
                    Grundfos.ScalaConnector.ControllerManager.Product.GetProductList();
                List<Product> productlist = ControllerManager.Product.GetProductListAlt();
                List<Grundfos.ScalaConnector.Transactions> transcomp =
                    Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDate, endDate, 0);
                List<Grundfos.ScalaConnector.Transactions> transvent =
                    Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDate, endDate, 1);
                List<Grundfos.ScalaConnector.PurchaseOrderItem> poil =
                    Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetWeeklyTransaction(startDate, endDate);


                foreach (Grundfos.ScalaConnector.Product prod in prodlist)
                {
                    Product producto = null;

                    producto = productlist.Find(delegate(Product record)
                                                    {
                                                        if (record.ProductCode != prod.Id)
                                                        {
                                                            return false;
                                                        }
                                                        return true;
                                                    });

                    if (producto != null)
                    {
                        PartnerNet.Domain.TransactionHistoryWeekly transax = new TransactionHistoryWeekly();

                        int stock = 0;
                        int purchases = 0;
                        int sales = 0;
                        int purchaseorders = 0;

                        stock = prod.StockQ;

                        Grundfos.ScalaConnector.Transactions subList = null;

                        subList = transcomp.Find(delegate(Grundfos.ScalaConnector.Transactions record)
                                                     {
                                                         if (record.Product != prod)
                                                         {
                                                             return false;
                                                         }
                                                         return true;
                                                     });

                        if (subList != null)
                            purchases = subList.Quantity;

                        subList = transvent.Find(delegate(Grundfos.ScalaConnector.Transactions record)
                                                     {
                                                         if (record.Product != prod)
                                                         {
                                                             return false;
                                                         }
                                                         return true;
                                                     });
                        if (subList != null)
                            sales = -subList.Quantity;

                        Grundfos.ScalaConnector.PurchaseOrderItem subList2 = null;

                        subList2 = poil.Find(delegate(Grundfos.ScalaConnector.PurchaseOrderItem record)
                                                 {
                                                     if (record.Product != prod)
                                                     {
                                                         return false;
                                                     }
                                                     return true;
                                                 });

                        if (subList2 != null)
                            purchaseorders = subList2.QuantityOrdered;

                        transax.ProductID = producto;
                        transax.Purchase = purchases;
                        transax.Sale = sales;
                        transax.PurchaseOrders = purchaseorders;
                        transax.Stock = 0;
                        transax.Year = endDate.Year;
                        transax.Week =
                            Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(endDate,
                                                                                       CalendarWeekRule.FirstFourDayWeek,
                                                                                       DayOfWeek.Sunday);
                        //borrar esta propiedad!!!
                        transax.ProductCode = prod.Id;

                        ControllerManager.TransactionHistoryWeekly.Save(transax);
                    }
                }
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(Calendar1.SelectedDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday).ToString();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            DateTime endDateM = GetLastDayOfMonth(Config.CurrentDate.AddMonths(-1));
            DateTime startDateM = GetFirstDayOfMonth(Config.CurrentDate.AddMonths(-1));

            IList<Grundfos.ScalaConnector.Product> prodlist = Grundfos.ScalaConnector.ControllerManager.Product.GetProductList();
            List<PartnerNet.Domain.Product> productlist = ControllerManager.Product.GetProductListAlt();
            List<Grundfos.ScalaConnector.Transactions> transcompm = Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDateM, endDateM, 0);
            List<Grundfos.ScalaConnector.Transactions> transventm = Grundfos.ScalaConnector.ControllerManager.Transactions.GetTransaction(startDateM, endDateM, 1);
            List<Grundfos.ScalaConnector.PurchaseOrderItem> poilm = Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetWeeklyTransaction(startDateM, endDateM);

            foreach (Grundfos.ScalaConnector.Product prod in prodlist)
            {
                PartnerNet.Domain.Product producto = null;
                producto = productlist.Find(delegate(PartnerNet.Domain.Product record)
                                                {
                                                    if (record.ProductCode != prod.Id)
                                                    {
                                                        return false;
                                                    }
                                                    return true;
                                                });

                if (producto != null)
                {
                    #region Generate TransactionHistoryMonthly

                    TransactionHistoryMonthly transax = new TransactionHistoryMonthly();

                    int stock = 0;
                    int purchases = 0;
                    int sales = 0;
                    int purchaseorders = 0;

                    stock = prod.StockQ;

                    Transactions subList = null;

                    subList = transcompm.Find(delegate(Transactions record)
                                                  {
                                                      if (record.Product != prod)
                                                      {
                                                          return false;
                                                      }
                                                      return true;
                                                  });

                    if (subList != null)
                        purchases = subList.Quantity;

                    subList = transventm.Find(delegate(Transactions record)
                                                  {
                                                      if (record.Product != prod)
                                                      {
                                                          return false;
                                                      }
                                                      return true;
                                                  });
                    if (subList != null)
                        sales = -subList.Quantity;

                    Grundfos.ScalaConnector.PurchaseOrderItem subList2 = null;
                    subList2 = poilm.Find(delegate(Grundfos.ScalaConnector.PurchaseOrderItem record)
                                              {
                                                  if (record.Product != prod)
                                                  {
                                                      return false;
                                                  }
                                                  return true;
                                              });

                    if (subList2 != null)
                        purchaseorders = subList2.QuantityOrdered;


                    transax.ProductID = producto;
                    transax.Purchase = purchases;
                    transax.Sale = sales;
                    transax.PurchaseOrders = purchaseorders;
                    transax.Stock = stock;
                    transax.Year = endDateM.Year;
                    transax.Month = Thread.CurrentThread.CurrentCulture.Calendar.GetMonth(endDateM);
                    transax.ProductCode = prod.Id;

                    ControllerManager.TransactionHistoryMonthly.Save(transax);

                    #endregion
                }
            }
        }

        private DateTime GetFirstDayOfMonth(DateTime dtDate)
        {
            DateTime dtFrom = dtDate;
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
            return dtFrom;
        }

        private DateTime GetLastDayOfMonth(DateTime dtDate)
        {
            DateTime dtTo = dtDate;
            dtTo = dtTo.AddMonths(1);
            dtTo = dtTo.AddDays(-(dtTo.Day));
            return dtTo;
        }

        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string errors;
            new AlertsProcessor().Execute(out errors);
            Response.Write(errors);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists("StockForecast"))
            {
                EventLog.CreateEventSource("StockForecast", "StockForecast");
            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            List<Product> products = ControllerManager.Product.GetAll() as List<Product>;
            List<Grundfos.ScalaConnector.StockMovementPending> stockMovementPendings = Grundfos.ScalaConnector.ControllerManager.StockMovementPending.GetPurchaseOrders() as List<StockMovementPending>;
            List<ScalaConnector.PurchaseOrder> purchaseOrderList = ScalaConnector.ControllerManager.PurchaseOrder.GetAll() as List<ScalaConnector.PurchaseOrder>;
            List<Grundfos.ScalaConnector.PurchaseOrderItem> purchaseOrderItemList = Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetAlerts();

            ControllerManager.AlertPurchaseOrder.CleanAlertPurchaseOrder();

            foreach (Grundfos.ScalaConnector.StockMovementPending item in stockMovementPendings)
            {
                ScalaConnector.PurchaseOrder po = purchaseOrderList.Find(delegate(ScalaConnector.PurchaseOrder record)
                                                      {
                                                          if (record.Id == item.OrderNumber)
                                                          {
                                                              return true;
                                                          }
                                                          return false;
                                                      });
                ScalaConnector.PurchaseOrderItem poi = purchaseOrderItemList.Find(delegate(ScalaConnector.PurchaseOrderItem record)
                                                      {
                                                          if ((record.Product.Id == item.ProductCode) && (record.PurchaseOrder.Id == item.OrderNumber))
                                                          {
                                                              return true;
                                                          }
                                                          return false;
                                                      });
                AlertPurchaseOrder alert = new AlertPurchaseOrder();

                alert.Destination = AlertPurchaseOrderDestination.Stock;
                alert.PurchaseOrderCode = item.OrderNumber;
                alert.Product = products.Find(delegate(PartnerNet.Domain.Product record)
                                                      {
                                                          if (record.ProductCode == item.ProductCode)
                                                          {
                                                              return true;
                                                          }
                                                          return false;
                                                      });
                alert.Quantity = item.Quantity;
                alert.Type = AlertPurchaseOrderType.NoConfirmada;
                if(poi.Confirmed == "1")
                    alert.Type = AlertPurchaseOrderType.Confirmada;
                alert.GAP = (item.DeliveryCommitt - po.Date).Days;
                alert.WayOfDelivery = (WayOfDelivery) po.WayOfDelivery;
                alert.ArrivalDate = item.DeliveryCommitt;
                if (item.CustSupCode == null)
                    alert.PurchaseOrderProviderCode = ControllerManager.Provider.GetProvider("999999").ProviderCode;
                else if (!string.IsNullOrEmpty(item.CustSupCode.Trim()))
                    alert.PurchaseOrderProviderCode = item.CustSupCode;
                else
                    alert.PurchaseOrderProviderCode = string.Empty;

                alert.PurchaseOrderDate = po.Date;

                if(item.CustSupName.EndsWith("#"))
                    alert.Type = AlertPurchaseOrderType.Transito;

                if (alert.Product == null)
                    continue;
                ControllerManager.AlertPurchaseOrder.Save(alert);
            }
        }

        private AlertPurchaseOrderDestination SearchSaleOrderDestination(List<Grundfos.ScalaConnector.SaleOrderItem> saleorderitems, Grundfos.ScalaConnector.PurchaseOrderItem item)
        {
            Grundfos.ScalaConnector.SaleOrderItem saleorderitem = saleorderitems.Find(delegate(Grundfos.ScalaConnector.SaleOrderItem record)
                                                        {
                                                            if (record.Product == item.Product)
                                                            {
                                                                return true;
                                                            }
                                                            return false;
                                                        });
            if (saleorderitem != null)
            {
                if (saleorderitem.Product.StockQ <= saleorderitem.Quantity)
                {
                    return AlertPurchaseOrderDestination.Venta;
                }
                else return AlertPurchaseOrderDestination.Stock;
            }
            else return AlertPurchaseOrderDestination.Stock;
        }

        private List<SaleOrderItem> SearchSaleOrder(List<Grundfos.ScalaConnector.SaleOrderItem> saleorderitems, Grundfos.ScalaConnector.PurchaseOrderItem item)
        {
            List<Grundfos.ScalaConnector.SaleOrderItem> saleorderitem = saleorderitems.FindAll(delegate(Grundfos.ScalaConnector.SaleOrderItem record)
                                                        {
                                                            if (record.Product == item.Product)
                                                            {
                                                                return true;
                                                            }
                                                            return false;
                                                        });
            return saleorderitem;
        }

        private List<Grundfos.ScalaConnector.PurchaseOrderItem> SearchPurchaseOrder(List<Grundfos.ScalaConnector.PurchaseOrderItem> purchaseorderitems, Grundfos.ScalaConnector.SaleOrderItem item)
        {
            List<Grundfos.ScalaConnector.PurchaseOrderItem> purchaseorderitem = purchaseorderitems.FindAll(delegate(Grundfos.ScalaConnector.PurchaseOrderItem record)
                                                        {
                                                            if (record.Product == item.Product)
                                                            {
                                                                return true;
                                                            }
                                                            return false;
                                                        });
            return purchaseorderitem;
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            List<Product> products = ControllerManager.Product.GetAll() as List<Product>;
            List<ProductDetail> productDetails = Grundfos.ScalaConnector.ControllerManager.ProductDetail.GetAlert3();

            ControllerManager.AlertProduct.CleanAlertProduct();

            foreach (ProductDetail productDetail in productDetails)
            {
                AlertProduct alert = new AlertProduct();
                alert.StandardCost = productDetail.Product.StandardCost;
                alert.SubTotal = productDetail.Product.StandardCost * Convert.ToDouble(productDetail.Stock);
                alert.Quantity = productDetail.Stock;
                alert.Type = 1;
                alert.NegativeDate = DateTime.Today;
                alert.Location = productDetail.Location;
                alert.Product = products.Find(delegate(Product record)
                                                                      {
                                                                          if (record.ProductCode == productDetail.Product.Id)
                                                                          {
                                                                              return true;
                                                                          }
                                                                          return false;
                                                                      });
                ControllerManager.AlertProduct.Save(alert);
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            List<Grundfos.ScalaConnector.PurchaseOrderItem> POList = Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetAlerts();

            List<SaleOrderItem> saleorderitems = Grundfos.ScalaConnector.ControllerManager.SaleOrderItem.PendingSaleOrder(Config.CurrentDate.AddDays(-44));

            List<ScalaConnector.PurchaseOrderItem> POListAlert3 = POList.FindAll(delegate(ScalaConnector.PurchaseOrderItem record)
                                                                      {
                                                                          if ((record.Confirmed == "1") &&
                                                                              (record.PurchaseOrder.Location ==
                                                                               "01") &&
                                                                              (record.PurchaseOrder.Id.
                                                                                  StartsWith("00000")))
                                                                          {
                                                                              return true;
                                                                          }
                                                                          return false;
                                                                      });

            List<Product> products = ControllerManager.Product.GetAll() as List<Product>;
            ControllerManager.AlertSaleOrder.CleanAlertSaleOrder();
            List<ScalaConnector.Product> scalaProducts = new List<ScalaConnector.Product>();
            foreach (SaleOrderItem saleOrderItem in saleorderitems)
            {
                CreateAlert(products, saleOrderItem, POListAlert3, scalaProducts);
            }
        }

        private void CreateAlert(List<Product> products, ScalaConnector.SaleOrderItem item, List<ScalaConnector.PurchaseOrderItem> purchaseorderitems, List<ScalaConnector.Product> scalaProducts)
        {
            List<ScalaConnector.PurchaseOrderItem> purchaseorderitem = SearchPurchaseOrder(purchaseorderitems, item);
            
            if (purchaseorderitem.Count == 0)
                return;
            
            AlertSaleOrder alert = new AlertSaleOrder();
            alert.Product = products.Find(delegate(Product record)
                                                      {
                                                          if (record.ProductCode == item.Product.Id)
                                                          {
                                                              return true;
                                                          }
                                                          return false;
                                                      });
            alert.SaleOrderCode = item.SaleOrderId;
            alert.CustomerCode = item.SaleOrder.Customer.Id;
            alert.CustomerName = item.SaleOrder.Customer.Name;
            alert.Quantity = (int)item.Quantity;
            alert.GAP = (item.RequiredDate - Config.CurrentDate).Days;
            alert.SaleOrderDeliveryDate = item.RequiredDate;
            alert.OrderDate = item.SaleOrder.Date;

            ScalaConnector.Product scalaProduct = scalaProducts.Find(delegate(ScalaConnector.Product record)
                                                      {
                                                          if (record.Id == item.Product.Id)
                                                          {
                                                              return true;
                                                          }
                                                          return false;
                                                      });
            if (scalaProduct == null)
            {
                scalaProduct = new ScalaConnector.Product();
                scalaProduct.Id = item.Product.Id;
                scalaProduct.StockQ = item.Product.StockQ;
                scalaProducts.Add(scalaProduct);
            }

            if (scalaProduct.StockQ >= item.Quantity - item.QuantityDelivery)
            {
                alert.Type = AlertSaleOrderType.Cumplimentada;
                alert.PurchaseOrderArrivalDate = DateTime.Today;
            }
            else
            {
                alert.Type = AlertSaleOrderType.NoCumplimentada;

                foreach (ScalaConnector.PurchaseOrderItem orderItem in purchaseorderitem)
                {
                    if (orderItem.ArrivalDate > alert.PurchaseOrderArrivalDate)
                        alert.PurchaseOrderArrivalDate = orderItem.ArrivalDate;
                    if (alert.PurchaseOrderArrivalDate > item.DeliveryDate)
                        alert.Type = AlertSaleOrderType.NoCumplimentada;
                    else
                        alert.Type = AlertSaleOrderType.Cumplimentada;
                }
            }

            if (scalaProduct.StockQ >= alert.Quantity)
                scalaProduct.StockQ -= alert.Quantity;
            else if (scalaProduct.StockQ > 0)
                scalaProduct.StockQ = 0;
            
            ControllerManager.AlertSaleOrder.Save(alert);
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            List<string> prodlistfalt = ControllerManager.Product.GetLeftProductList();
            List<Product> prodlisttemp = ControllerManager.Product.GetAll() as List<Product>;
            List<string> leftproducts = new List<string>();

            foreach (Product product in prodlisttemp)
            {
                string temp = prodlistfalt.Find(delegate(string record)
                                                                      {
                                                                          if (record == product.ProductCode)
                                                                          {
                                                                              return true;
                                                                          }
                                                                          return false;
                                                                      });

                if(temp == null)
                {
                    leftproducts.Add(product.ProductCode);
                }
            }



            List<Product> prodfalt = new List<Product>();
            foreach (string product in leftproducts)
            {
                Product producto = ControllerManager.Product.GetProductInfo(product);
                prodfalt.Add(producto);
            }

            ControllerManager.Forecast.CalculateFullForecast(Config.CurrentWeek, Config.CurrentDate.Year, prodfalt, false);
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            SmtpClient mailclient = new SmtpClient();
            mailclient.Send("sebastian.real@nybblegroup.com", "sebastian.real@nybblegroup.com", "Error en Product Refresh", "Esto es una prueba");
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(TextBox2.Text) % 1000 == 0)
                Label2.Text = "valido";
            else Label2.Text = "no valido";
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            ControllerManager.TransactionHistoryWeekly.CleanData(Thread.CurrentThread.CurrentCulture.Calendar.GetWeekOfYear(Calendar1.SelectedDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday), Calendar1.SelectedDate.Year);
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            ControllerManager.TransactionHistoryMonthly.CleanData(Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Year);
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            ControllerManager.TransactionHistoryMonthly.CalculateFullStatistic(Config.CurrentDate.Month - 1, Config.CurrentDate.Year);
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            ControllerManager.PurchaseOrder.CleanData(Config.CurrentDate);
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            TextBox3.Text = ControllerManager.TransactionHistoryWeekly.GetActiveProducts(Config.CurrentWeek, Config.CurrentDate.Year).ToString();
        }

        protected void btnRepositionLevel_Click(object sender, EventArgs e)
        {
            List<AlertReposition> lstrepotmp = ControllerManager.TransactionHistoryWeekly.GetAlert6(Config.CurrentWeek, Config.CurrentDate.Year) as List<AlertReposition>;
            ControllerManager.AlertReposition.CleanAlertReposition();

            List<AlertReposition> aRLst = lstrepotmp.FindAll(delegate(AlertReposition record)
                                                                      {
                                                                          if (record.Product.AlternativeProduct == " "
                                                                              && record.Product.AlternativeDate == new DateTime(9999, 12, 31)

                                                                              )
                                                                              return true;
                                                                          else
                                                                              return false;
                                                                      });

            List<AlertReposition> aRLst2 = lstrepotmp.FindAll(delegate(AlertReposition record)
                                                                  {
                                                                      if (record.Product.AlternativeProduct != " "
                                                                          && record.Product.AlternativeDate != new DateTime(9999, 12, 31)
                                                                          )
                                                                          return true;
                                                                      else
                                                                          return false;
                                                                  });

            List<string> alternativeProducts = new List<string>();
            foreach (AlertReposition alertReposition in aRLst2)
                alternativeProducts.Add(alertReposition.Product.AlternativeProduct);

            List<AlertReposition> lstprodalt = ControllerManager.TransactionHistoryWeekly.GetAlert6(Config.CurrentWeek, Config.CurrentDate.Year, alternativeProducts) as List<AlertReposition>;

            List<AlertReposition> aRLst3 = lstprodalt.FindAll(delegate(AlertReposition record)
                                                                      {
                                                                          if (record.Product.AlternativeProduct == " "
                                                                              && record.Product.AlternativeDate == new DateTime(9999, 12, 31)

                                                                              )
                                                                              return true;
                                                                          else
                                                                              return false;
                                                                      });

            List<SaleOrderItem> soFullLst = Grundfos.ScalaConnector.ControllerManager.SaleOrderItem.SaleOrdersByProduct();
            foreach (AlertReposition ar in aRLst)
            {
                List<SaleOrderItem> soLst = soFullLst.FindAll(delegate(SaleOrderItem record)
                                                                  {
                                                                      if (record.Product.Id == ar.Product.ProductCode)
                                                                          return true;
                                                                      else
                                                                          return false;
                                                                  });

                double maximumQuantity = 0;
                double total = 0;
                bool haveParts = false;
                string maximumOrderCode = "Sin Orden";
                foreach (SaleOrderItem sOI in soLst)
                {
                    if (sOI.Quantity > maximumQuantity)
                    {
                        maximumQuantity = sOI.Quantity;
                        maximumOrderCode = sOI.SaleOrderId;
                    }
                    total = total + sOI.Quantity;

                    if (sOI.Product.Parts.Count > 0 && sOI.Product.Parts[0].Type == "B")
                    {
                        haveParts = true;
                        break;
                    }
                }
                if (!haveParts)
                {
                    if (((maximumQuantity * total) / 100) > 40)
                        ar.IsConflicted = true;
                    else
                        ar.IsConflicted = false;

                    ar.OrderInfo = soLst.Count + "/" + ((maximumQuantity * total) / 100) + "/" + maximumOrderCode;

                    GetAlertRepositionResult(ar, null);

                    if (!aRLst3.Exists(delegate(AlertReposition record)
                                                              {
                                                                  if (record.ProductCode == ar.ProductCode)
                                                                      return true;
                                                                  else
                                                                      return false;
                                                              }))
                        ControllerManager.AlertReposition.Save(ar);
                }
            }

            foreach (AlertReposition ar in aRLst3)
            {
                AlertReposition pastproduct = aRLst2.Find(delegate(AlertReposition record)
                                                              {
                                                                  if (record.Product.AlternativeProduct == ar.Product.ProductCode)
                                                                      return true;
                                                                  else
                                                                      return false;
                                                              });

                List<SaleOrderItem> soLst = soFullLst.FindAll(delegate(SaleOrderItem record)
                                                                  {
                                                                      if (record.Product.Id == ar.Product.ProductCode)
                                                                          return true;
                                                                      else
                                                                          return false;
                                                                  });


                List<SaleOrderItem> soLstAlt = soFullLst.FindAll(delegate(SaleOrderItem record)
                                                                  {
                                                                      if (record.Product.Id == pastproduct.Product.ProductCode)
                                                                          return true;
                                                                      else
                                                                          return false;
                                                                  });

                ar.Sales += pastproduct.Sales;

                GetAlertRepositionResult(ar, pastproduct);

                double maximumQuantity = 0;
                double total = 0;
                bool haveParts = false;
                string maximumOrderCode = "Sin Orden";
                foreach (SaleOrderItem sOI in soLst)
                {
                    if (sOI.Quantity > maximumQuantity)
                    {
                        maximumQuantity = sOI.Quantity;
                        maximumOrderCode = sOI.SaleOrderId;
                    }
                    total = total + sOI.Quantity;

                    if (sOI.Product.Parts.Count > 0 && sOI.Product.Parts[0].Type == "B")
                    {
                        haveParts = true;
                        break;
                    }
                }
                foreach (SaleOrderItem sOI in soLstAlt)
                {
                    if (sOI.Quantity > maximumQuantity)
                    {
                        maximumQuantity = sOI.Quantity;
                        maximumOrderCode = sOI.SaleOrderId;
                    }
                    total = total + sOI.Quantity;

                    if (sOI.Product.Parts.Count > 0 && sOI.Product.Parts[0].Type == "B")
                    {
                        haveParts = true;
                        break;
                    }
                }
                if (!haveParts)
                {
                    if (((maximumQuantity * total) / 100) > 40)
                        ar.IsConflicted = true;
                    else
                        ar.IsConflicted = false;

                    ar.OrderInfo = soLst.Count + "/" + ((maximumQuantity * total) / 100) + "/" + maximumOrderCode;

                    ControllerManager.AlertReposition.Save(ar);
                }
            }
        }

        private void GetAlertRepositionResult(AlertReposition ar, AlertReposition pastproduct)
        {
            if(ar.Product.RepositionLevel == 0)
            {
                ar.Result = 0;
                return;
            }
            int saleMonts = ar.SaleMonths;
            if(pastproduct != null)
                saleMonts = Convert.ToInt32(Math.Round(Convert.ToDecimal(ar.ProductSaleLife + pastproduct.ProductSaleLife) / 4, MidpointRounding.AwayFromZero));
            if (saleMonts > 12)
                saleMonts = 12;
            if (saleMonts == 0)
                saleMonts = 1;
            
            decimal cuatrimestralSales;
            decimal divider = Convert.ToDecimal((saleMonts * 3)) / 12;
            if (divider > 1)
                cuatrimestralSales = Math.Round(ar.Sales / divider);
            else
                cuatrimestralSales = ar.Sales;

            if (cuatrimestralSales > 0)
                ar.Result = (ar.Product.RepositionLevel * 100 / cuatrimestralSales) - 100;
        }

        protected void btnUpdateProductLifeOfAlertProduct_Click(object sender, EventArgs e)
        {
            //List<AlertReposition> lstrepotmp = ControllerManager.AlertReposition.GetAll() as List<AlertReposition>;
            //ControllerManager.TransactionHistoryWeekly.UpdateProductSaleLife(lstrepotmp);
        }
    }
}
