using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using ProjectBase.Data;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Common;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class PriceBaseHistoryController : AbstractNHibernateDao<PriceBaseHistory, int>
    {
        public PriceBaseHistoryController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        //public void SaveAudit(PriceBase priceBase, HistoryStatus historyStatus)
        //{
        //    SaveAudit(priceBase, historyStatus, null);
        //}

        //public void SaveAudit(PriceBase priceBase, HistoryStatus historyStatus, Guid? userId)
        //{
        //    PriceBaseHistory priceBaseHistory = new PriceBaseHistory();

        //    priceBaseHistory.PriceImport = priceBase.PriceImport;
        //    priceBaseHistory.PriceList = priceBase.PriceList;
        //    priceBaseHistory.PriceListCurrency = priceBase.PriceListCurrency;
        //    priceBaseHistory.PricePurchase = priceBase.PricePurchase;
        //    priceBaseHistory.PricePurchaseCurrency = priceBase.PricePurchaseCurrency;
        //    priceBaseHistory.PriceSuggest = priceBase.PriceSuggest;
        //    priceBaseHistory.PriceSuggestCurrency = priceBase.PriceSuggestCurrency;
        //    priceBaseHistory.Product = priceBase.Product;
        //    priceBaseHistory.Provider = priceBase.Provider;
        //    priceBaseHistory.ProviderCode = priceBase.ProviderCode;
        //    priceBaseHistory.Status = priceBase.Status;
        //    priceBaseHistory.HistoryStatus = historyStatus;
        //    priceBaseHistory.CurrencyRate = priceBase.CurrencyRate;
        //    priceBaseHistory.PricePurchaseCurrencyRate = priceBase.PricePurchaseCurrencyRate;
        //    priceBaseHistory.PriceSuggestCurrencyRate = priceBase.PriceSuggestCurrencyRate;

        //    if (userId.HasValue)
        //    {
        //        priceBaseHistory.TimeStamp.CreatedBy = userId;
        //        priceBaseHistory.TimeStamp.CreatedOn = DateTime.Now;
        //        priceBaseHistory.TimeStamp.ModifiedBy = userId;
        //        priceBaseHistory.TimeStamp.ModifiedOn = DateTime.Now;
        //    }

        //    Save(priceBaseHistory);
        //}

        //public void SaveAudit(IList<PriceBase> lst, HistoryStatus historyStatus)
        //{
        //    foreach (PriceBase priceBase in lst)
        //        SaveAudit(priceBase, historyStatus);
        //}

        public IList<ProductListView> GetByProduct(Product product, GridState gridState, out int totalRecords)
        {
            ICriteria crit = GetByProductCriteria(product);
            //crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            //totalRecords = crit.UniqueResult<int>();
            //if (totalRecords == 0)
            //    return new List<ProductListView>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            
            //crit = GetByProductCriteria(product);

            //crit.SetMaxResults(gridState.PageSize);
            //if (pageNumber == 1)
            //    crit.SetFirstResult(0);
            //else
            //    crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);

            string[] sort = gridState.SortField.Split('.');

            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            IList<PriceBaseHistory> priceBaseHistoryList = crit.List<PriceBaseHistory>();
            IList<ProductListView> productListViewList = new List<ProductListView>();

            totalRecords = priceBaseHistoryList.Count;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            int count;
            int maxcount;
            if (pageNumber == 1)
                count = 0;
            else
                count = (pageNumber - 1) * gridState.PageSize;
            maxcount = count + pageSize;
            decimal price = -1;

            foreach (PriceBaseHistory pbh in priceBaseHistoryList)
            {
                if(count < maxcount)
                {
                    if (price == pbh.PriceList)
                        continue;
                    ProductListView productListView = new ProductListView(pbh);
                    productListViewList.Add(productListView);
                    count++;
                    price = pbh.PriceList;
                }
                else
                    break;
            }


            return productListViewList;
        }
        
        public ICriteria GetByProductCriteria(Product product)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Product", product));
            
            return crit;
        }

        public List<HistoricView> GetHistoricPrices(int priceBaseId)
        {
            PriceBase pb = ControllerManager.PriceBase.GetById(priceBaseId);
            if (pb == null)
                return null;

            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Product", pb.Product));
            crit.Add(Expression.Eq("Provider", pb.Provider));
            ProjectionList pl = Projections.ProjectionList();
            pl.Add(Projections.Distinct(Projections.Property("PriceList")));
            pl.Add(Projections.Property("TimeStamp.ModifiedOn"));
            crit.SetProjection(pl);

            crit.AddOrder(new Order("TimeStamp.ModifiedOn", true));

            IList lst = crit.List();

            List<HistoricView> hv = new List<HistoricView>();
            foreach(object[] arr in lst)
                hv.Add(new HistoricView(StringFormat.MilliTimeStamp((DateTime)arr[1]), Convert.ToDecimal(arr[0])));

            return hv;
        }

        public void RollBack(PriceBaseHistory pbh)
        {
            pbh = GetById(pbh.ID);

            PriceBase pb = ControllerManager.PriceBase.GetPriceBase(pbh.Product, pbh.Provider);
            //SaveAudit(pb, HistoryStatus.RollBack);

            pb.PriceList = pbh.PriceList;
            pb.PriceListCurrency = pbh.PriceListCurrency;
            pb.PricePurchase = pbh.PricePurchase;
            pb.PricePurchaseCurrency = pbh.PricePurchaseCurrency;
            pb.PriceSuggest = pbh.PriceSuggest;
            pb.PriceSuggestCurrency = pbh.PriceSuggestCurrency;
            pb.ProviderCode = pbh.ProviderCode;

            ControllerManager.PriceBase.Save(pb);
            CommitChanges();
        }

        
    }
}
