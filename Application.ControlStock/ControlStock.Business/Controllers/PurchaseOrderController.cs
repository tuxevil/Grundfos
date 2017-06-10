using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using PartnerNet.Common;
using PartnerNet.Domain;
using ProjectBase.Data;
using System.IO;

namespace PartnerNet.Business
{
    public class PurchaseOrderController : AbstractNHibernateDao<PurchaseOrder, int>
    {
        public PurchaseOrderController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void ChangeStatus(IList<PurchaseOrder> selectedOC, PurchaseOrderStatus status)
        {
            foreach(PurchaseOrder oc in selectedOC)
            {
                oc.PurchaseOrderStatus = status;
            }
        }

        public PurchaseOrder GetPurchaseOrder(Provider provider, PurchaseOrderType pot, PurchaseOrderStatus pos)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new EqExpression("Provider", provider));
            crit.Add(new EqExpression("Date", Config.CurrentDate));
            crit.Add(new EqExpression("PurchaseOrderType", pot));
            crit.Add(new EqExpression("PurchaseOrderStatus", pos));

            PurchaseOrder po = crit.UniqueResult<PurchaseOrder>();

            if (po == null)
            {
                po = new PurchaseOrder();
                po.Provider = provider;
                po.Date = Config.CurrentDate;
                po.PurchaseOrderStatus = 0;
                po.PurchaseOrderType = pot;
                
            }
            return po;
        }

        public void GeneratePO(Product prod, int week, int year, PurchaseOrderType pot, int repositionpoint)
        {
            PurchaseOrderStatus pos = 0;
            PurchaseOrder po = GetPurchaseOrder(prod.Provider, pot, pos);
                        
            PurchaseOrderItem poi = new PurchaseOrderItem();
            poi.PurchaseOrder = po;
            poi.Product = prod;
            if (pot == (PurchaseOrderType)1)
            {
                poi.Forecast = ControllerManager.Forecast.GetProductInfo(prod, Config.CurrentWeek + 1, Config.CurrentDate.Year);
                poi.QuantitySuggested = poi.Forecast.QuantitySuggested;
                poi.Quantity = poi.Forecast.QuantitySuggested;
            }
            else if (pot == (PurchaseOrderType)2)
            {
                poi.Forecast = ControllerManager.Forecast.GetProductInfo(prod, Config.CurrentWeek + 1, Config.CurrentDate.Year);
                poi.QuantitySuggested = repositionpoint;
                poi.Quantity = repositionpoint;
            }

            po.PurchaseOrderItems.Add(poi);
            
            this.Save(po);
        }

        public void FilterByDate()
        {
            throw new System.NotImplementedException();
        }

        public void FilterByProduct()
        {
            throw new System.NotImplementedException();
        }

        public IList<PurchaseOrderInformation> GetPurchaseOrders(int poid, DateTime date, int provider, int status, int page, int pagesize)
        {
            string querystring = "PO.Id, PO.Provider, PO.Date, PO.PurchaseOrderType";
            IQuery q = GetInfo(poid, date, provider, status, page, pagesize, querystring);

            IList lst = q.List();

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PurchaseOrderInformation).GetConstructors()[1]));

            IList<PurchaseOrderInformation> poinfo = q.List<PurchaseOrderInformation>();

            return poinfo;
        }

        public int GetProductInformationCount(int poid, DateTime date, int provider, int status, int page, int pagesize)
        {
            string querystring = "Count(PO.Id)";
            IQuery q = GetInfo(poid, date, provider, status, 0, 0, querystring);

            long prueba = q.UniqueResult<Int64>();

            return Convert.ToInt32(prueba);
        }

        public IQuery GetInfo(int poid, DateTime date, int provider, int status, int page, int pagesize, string querystring)
        {
            string query = "select " + querystring + " from PurchaseOrder PO";
            query += " join PO.Provider PV";
            query += " where PO.PurchaseOrderStatus = :Status";
            if(poid > 0)
                query += " AND PO.Id = :Id";
            if(provider > 0)
                query += " AND PV.Id = :Provider";
            if (date > Convert.ToDateTime("1/1/1900"))
                query += " AND PO.Date = :Date";


            IQuery q = NHibernateSession.CreateQuery(query);

            q.SetEnum("Status", (PurchaseOrderStatus)status);

            if (poid > 0)
                q.SetInt32("Id", poid);
            if (provider > 0)
                q.SetInt32("Provider", provider);
            if (date > Convert.ToDateTime("1/1/1900"))
                q.SetDateTime("Date", date);                

            return q;
        }

        public void CleanTable()
        {
            foreach (PurchaseOrder o in GetAll())
                this.Delete(o);
        }
       
        public void ExportPurchaseOrder(PurchaseOrder po)
        {
            Stream strStremW;
            StreamWriter strStremWriter;

            //string filepath = Server.MapPath(".");
        }
    }
}
