using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Threading;
using Grundfos.ScalaConnector;
using PartnerNet.Common;
using PartnerNet.Domain;
using ControllerManager = PartnerNet.Business.ControllerManager;
using Product = Grundfos.ScalaConnector.Product;
using PurchaseOrder=Grundfos.ScalaConnector.PurchaseOrder;
using PurchaseOrderItem = Grundfos.ScalaConnector.PurchaseOrderItem;

namespace ParnerNet.Integrators.Scala
{
    public class AlertsProcessor : IProcessor
    {
        public string Name
        {
            get { return "Alerts Processor"; }
        }
        private int AlertOCGapAverage = 0;
        private int AlertOCGapCount = 0;
        private int AlertOVGapAverage = 0;
        private int AlertOVGapCount = 0;

        public bool Execute(out string errors)
        {
            errors = "";

            try
            {
                #region Check if needs to be executed

                if (DateTime.Now.Hour >= Convert.ToInt32(ConfigurationManager.AppSettings["ExecuteHourAlerts"]))
                {
                    // Review if the forecast is executing in the log
                    // If not start the process, otherwise returns true with no errors.
                    if (ControllerManager.Log.IsExecuting(Name, ExecutionStatus.Start))
                        return true;
                    else
                        ControllerManager.Log.Add(Name, ExecutionStatus.Start, string.Empty);
                }
                else
                    return true;

                #endregion

                //------------------------------------------------------------------------------------------------------------------
                List<PartnerNet.Domain.Product> products = ControllerManager.Product.GetAll() as List<PartnerNet.Domain.Product>;
                List<PurchaseOrderItem> purchaseOrderItemList = Grundfos.ScalaConnector.ControllerManager.PurchaseOrderItem.GetAlerts();

                # region Alerta de Ordenes de Compras Confirmadas y no Despachadas
                try
                {
                    List<StockMovementPending> stockMovementPendings = Grundfos.ScalaConnector.ControllerManager.StockMovementPending.GetPurchaseOrders() as List<StockMovementPending>;
                    List<PurchaseOrder> purchaseOrderList = Grundfos.ScalaConnector.ControllerManager.PurchaseOrder.GetAll() as List<PurchaseOrder>;

                    ControllerManager.AlertPurchaseOrder.CleanAlertPurchaseOrder();

                    foreach (StockMovementPending item in stockMovementPendings)
                    {
                        PurchaseOrder po = purchaseOrderList.Find(delegate(PurchaseOrder record)
                                                              {
                                                                  if (record.Id == item.OrderNumber)
                                                                  {
                                                                      return true;
                                                                  }
                                                                  return false;
                                                              });
                        PurchaseOrderItem poi = purchaseOrderItemList.Find(delegate(PurchaseOrderItem record)
                                                              {
                                                                  if ((record.Product.Id == item.ProductCode)&& (record.PurchaseOrder.Id == item.OrderNumber))
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
                        if (poi.Confirmed == "1")
                            alert.Type = AlertPurchaseOrderType.Confirmada;
                        alert.GAP = (item.DeliveryCommitt - po.Date).Days;
                        alert.WayOfDelivery = (WayOfDelivery)po.WayOfDelivery;
                        alert.ArrivalDate = item.DeliveryCommitt;
                        if (item.CustSupCode == null)
                            alert.PurchaseOrderProviderCode = ControllerManager.Provider.GetProvider("999999").ProviderCode;
                        else if (!string.IsNullOrEmpty(item.CustSupCode.Trim()))
                            alert.PurchaseOrderProviderCode = item.CustSupCode;
                        else
                            alert.PurchaseOrderProviderCode = string.Empty;

                        alert.PurchaseOrderDate = po.Date;

                        if (item.CustSupName.EndsWith("#"))
                            alert.Type = AlertPurchaseOrderType.Transito;

                        if (alert.Product == null)
                            continue;

                        AlertOCGapAverage += alert.GAP;
                        AlertOCGapCount++;

                        ControllerManager.AlertPurchaseOrder.Save(alert);
                    }
                    ControllerManager.Log.Add(Name, ExecutionStatus.Running, "Alerta de Ordenes de Compras Confirmadas y no Despachadas: Completadas");
                }
                catch (Exception ex)
                {
                    errors = ex.ToString();

                    try
                    {
                        string process = "Alerta de Ordenes de Compras Confirmadas y no Despachadas";
                        ControllerManager.Log.Add(Name, ExecutionStatus.Running, process + ": " + errors);
                        SendErrorEmail(process, errors);
                    }
                    catch
                    {
                    }

                    return false;
                }

                #endregion

                #region Alerta de Ordenes de Compras No Confirmadas
                //Se reemplazo y unio todo con la alerta 1

                #endregion

                #region Alerta de Stock Negativos
                try
                {
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
                        alert.Product = products.Find(delegate(PartnerNet.Domain.Product record)
                                                                      {
                                                                          if (record.ProductCode == productDetail.Product.Id)
                                                                          {
                                                                              return true;
                                                                          }
                                                                          return false;
                                                                      });

                        ControllerManager.AlertProduct.Save(alert);
                    }

                    ControllerManager.Log.Add(Name, ExecutionStatus.Running, "Alertas de Stock Negativo: Completadas");
                }
                catch (Exception ex)
                {
                    errors = ex.ToString();

                    try
                    {
                        string process = "Alertas de Stock Negativo";
                        ControllerManager.Log.Add(Name, ExecutionStatus.Running, process + ": " + errors);
                        SendErrorEmail(process, errors);
                    }
                    catch
                    {
                    }
                    return false;
                }

                #endregion

                #region Alerta de Ventas no Cumplimentadas
                try
                {
                    List<SaleOrderItem> saleorderitems = Grundfos.ScalaConnector.ControllerManager.SaleOrderItem.PendingSaleOrder(Config.CurrentDate.AddDays(-44));

                    List<PurchaseOrderItem> POListAlert3 = purchaseOrderItemList.FindAll(delegate(PurchaseOrderItem record)
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

                    ControllerManager.AlertSaleOrder.CleanAlertSaleOrder();

                    List<Product> scalaProducts = new List<Product>();
                    foreach (SaleOrderItem saleOrderItem in saleorderitems)
                    {
                        CreateAlert(products, saleOrderItem, POListAlert3, scalaProducts);
                    }
                    ControllerManager.Log.Add(Name, ExecutionStatus.Running, "Alertas de Ventas no Cumplimentadas: Completadas");
                }
                catch (Exception ex)
                {
                    errors = ex.ToString();

                    try
                    {
                        string process = "Alertas de Ventas no Cumplimentadas";
                        ControllerManager.Log.Add(Name, ExecutionStatus.Running, process + ": " + errors);
                        SendErrorEmail(process, errors);
                    }
                    catch
                    {
                    }

                    return false;
                }

                #endregion

                #region Alerta de Stock Futuro Menor al Safety
                //PENDIENTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //try
                //{
                //    List<PartnerNet.Domain.Product> ProdList = ControllerManager.Product.GetAlertNegativeFutureStock();
                //    PartnerNet.Domain.Product prodtemp = null;

                //    foreach (PartnerNet.Domain.Product product in ProdList)
                //    {
                //        if (prodtemp != product)
                //        {
                //            AlertProduct alert = new AlertProduct();
                //            alert.StandardCost = 0;
                //            alert.SubTotal = 0;
                //            alert.Quantity = product.Forecasts[0].FinalStock;
                //            DateTime fechatemp = Convert.ToDateTime("01/01/" + Config.CurrentDate.Year.ToString());
                //            fechatemp = Thread.CurrentThread.CurrentCulture.Calendar.AddWeeks(fechatemp, product.Forecasts[0].Week);
                //            alert.NegativeDate = fechatemp.AddDays(-7 + (int)fechatemp.DayOfWeek);
                //            alert.Type = 2;
                //            alert.Product = product;

                //            ControllerManager.AlertProduct.Save(alert);

                //            prodtemp = product;
                //        }
                //    }
                //    ControllerManager.Log.Add(Name, ExecutionStatus.Running, "Stock Futuro Menor al Safety: Completadas");
                //}
                //catch (Exception ex)
                //{
                //    errors = ex.ToString();

                //    try
                //    {
                //        string process = "Stock Futuro Menor al Safety";
                //        ControllerManager.Log.Add(Name, ExecutionStatus.Running, process + ": " + errors);
                //        SendErrorEmail(process, errors);
                //    }
                //    catch
                //    {
                //    }

                //    return false;
                //}

                //PENDIENTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                #endregion

                #region Alerta de Nivel de Reposición
                try
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
                    ControllerManager.Log.Add(Name, ExecutionStatus.Running, "Alertas de Nivel de Reposición: Completadas");
                }
                catch (Exception ex)
                {
                    errors = ex.ToString();

                    try
                    {
                        string process = "Alertas de Nivel de Reposición";
                        ControllerManager.Log.Add(Name, ExecutionStatus.Running, process + ": " + errors);
                        SendErrorEmail(process, errors);
                    }
                    catch
                    {
                    }

                    return false;
                }

                #endregion

                #region Obtener Totales

                AlertTotal alerttotal;

                for (int i = 1; i <= 6; i++)
                {
                    alerttotal = ControllerManager.AlertTotal.GetAlertTotal(i);

                    switch (i)
                    {
                        case 1:
                            alerttotal.Total = AlertOCGapAverage / AlertOCGapCount;
                            if (alerttotal.Total < 0)
                                alerttotal.Total = -alerttotal.Total;
                            break;
                        case 2:
                            alerttotal.Total = AlertOCGapAverage / AlertOCGapCount;
                            if (alerttotal.Total < 0)
                                alerttotal.Total = -alerttotal.Total;
                            break;
                        case 3:
                            alerttotal.Total = ControllerManager.TransactionHistoryWeekly.GetActiveProducts(Config.CurrentWeek, Config.CurrentDate.Year);
                            break;
                        case 4:
                            alerttotal.Total = AlertOVGapAverage / AlertOVGapCount;
                            if (alerttotal.Total < 0)
                                alerttotal.Total = -alerttotal.Total;
                            break;
                        case 5:
                            alerttotal.Total = ControllerManager.TransactionHistoryWeekly.GetActiveProducts(Config.CurrentWeek, Config.CurrentDate.Year);
                            break;
                        case 6:
                            alerttotal.Total = ControllerManager.TransactionHistoryWeekly.GetActiveProducts(Config.CurrentWeek, Config.CurrentDate.Year);
                            break;
                    }
                }
                ControllerManager.Log.Add(Name, ExecutionStatus.Running, "Totales obtenidos para las alertas.");
                #endregion

                ControllerManager.Log.Add(Name, ExecutionStatus.Finished, "Alert process finished successfully");
            }
            catch (Exception ex)
            {
                errors = ex.ToString();

                try
                {
                    string process = "Proceso de Alertas";
                    ControllerManager.Log.Add(Name, ExecutionStatus.Running, errors);
                    SendErrorEmail(process, errors);
                }
                catch
                {
                }

                return false;
            }

            return true;
        }

        private void CreateAlert(List<PartnerNet.Domain.Product> products, SaleOrderItem item, List<PurchaseOrderItem> purchaseorderitems)
        {
            List<PurchaseOrderItem> purchaseorderitem = SearchPurchaseOrder(purchaseorderitems, item);

            if (purchaseorderitem.Count == 0)
                return;
            
            AlertSaleOrder alert = new AlertSaleOrder();
            alert.Product = products.Find(delegate(PartnerNet.Domain.Product record)
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
            alert.Type = AlertSaleOrderType.Cumplimentada;

            foreach (PurchaseOrderItem orderItem in purchaseorderitem)
            {
                if (orderItem.ArrivalDate > alert.PurchaseOrderArrivalDate)
                    alert.PurchaseOrderArrivalDate = orderItem.ArrivalDate;
                if (alert.PurchaseOrderArrivalDate > item.DeliveryDate)
                    alert.Type = AlertSaleOrderType.NoCumplimentada;
            }
            ControllerManager.AlertSaleOrder.Save(alert);

            if(alert.SaleOrderDeliveryDate <= DateTime.Today)
            {
                AlertOVGapAverage += alert.GAP;
                AlertOVGapCount++;
            }
        }

        private void CreateAlert(List<PartnerNet.Domain.Product> products, SaleOrderItem item, List<PurchaseOrderItem> purchaseorderitems, List<Product> scalaProducts)
        {
            List<PurchaseOrderItem> purchaseorderitem = SearchPurchaseOrder(purchaseorderitems, item);

            if (purchaseorderitem.Count == 0)
                return;

            AlertSaleOrder alert = new AlertSaleOrder();
            alert.Product = products.Find(delegate(PartnerNet.Domain.Product record)
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

            Product scalaProduct = scalaProducts.Find(delegate(Product record)
                                                      {
                                                          if (record.Id == item.Product.Id)
                                                          {
                                                              return true;
                                                          }
                                                          return false;
                                                      });
            if (scalaProduct == null)
            {
                scalaProduct = new Product();
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

                foreach (PurchaseOrderItem orderItem in purchaseorderitem)
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
        
        private List<PurchaseOrderItem> SearchPurchaseOrder(List<PurchaseOrderItem> purchaseorderitems, SaleOrderItem item)
        {
            List<PurchaseOrderItem> purchaseorderitem = purchaseorderitems.FindAll(delegate(PurchaseOrderItem record)
                                                        {
                                                            if (record.Product == item.Product)
                                                            {
                                                                return true;
                                                            }
                                                            return false;
                                                        });
            return purchaseorderitem;
        }

        private void GetAlertRepositionResult(AlertReposition ar, AlertReposition pastproduct)
        {
            if (ar.Product.RepositionLevel == 0)
            {
                ar.Result = 0;
                return;
            }
            int saleMonts = ar.SaleMonths;
            if (pastproduct != null)
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

        private void SendErrorEmail(string process, string errors)
        {
            SmtpClient mailclient = new SmtpClient();

            MailMessage mm = new MailMessage();
            mm.To.Add(ConfigurationManager.AppSettings["SupportEmail"]);
            mm.Subject = "Error in " + process;
            mm.Body = errors;

            mailclient.Send(mm);
        }
    }
}
