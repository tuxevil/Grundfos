using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using NHibernate;
using NHibernate.Criterion;
using NybbleMembership.Core.Domain;
using NybbleMembership.Core;
using NybbleMembership;

namespace PriceManager.Business
{
    public class PriceAttributeHistoryController : AbstractNHibernateDao<PriceAttributeHistory, int>
    {
        public PriceAttributeHistoryController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        //public void SaveAudit(PriceAttribute priceAttribute, HistoryStatus historyStatus)
        //{
        //    PriceAttributeHistory priceAttributeHistory = new PriceAttributeHistory();

        //    priceAttributeHistory.Price = priceAttribute.Price;
        //    priceAttributeHistory.PriceBase = priceAttribute.PriceBase;
        //    priceAttributeHistory.PriceCurrency = priceAttribute.PriceCurrency;
        //    priceAttributeHistory.PriceGroup = priceAttribute.PriceGroup;
        //    priceAttributeHistory.CurrencyRate = priceAttribute.CurrencyRate;
        //    priceAttributeHistory.HistoryStatus = historyStatus;
        //    priceAttributeHistory.PricePurchaseCurrencyRate = priceAttribute.PricePurchaseCurrencyRate;
        //    priceAttributeHistory.PriceSuggestCurrencyRate = priceAttribute.PriceSuggestCurrencyRate;
            
        //    Save(priceAttributeHistory);
        //}

        //public void SaveAudit(IList<PriceAttribute> lst, HistoryStatus historyStatus)
        //{
        //    foreach (PriceAttribute pa in lst)
        //        SaveAudit(pa, historyStatus);
        //}

        public IList<PriceAttributeHistory> GetByProduct(Product product, PriceGroup priceGroup, GridState gridState, out int totalRecords)
        {
            ICriteria crit = GetByProductCriteria(product, priceGroup);

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            
            string[] sort = gridState.SortField.Split('.');

            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            IList<PriceAttributeHistory> priceAttributeHistoryList = crit.List<PriceAttributeHistory>();
            IList<PriceAttributeHistory> productListViewList = new List<PriceAttributeHistory>();

            totalRecords = priceAttributeHistoryList.Count;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);


            int count;
            int maxcount;
            if (pageNumber == 1)
                count = 0;
            else
                count = (pageNumber - 1) * gridState.PageSize;
            maxcount = count + pageSize;
            decimal price = -1;

            foreach (PriceAttributeHistory pah in priceAttributeHistoryList)
            {
                if (count < maxcount)
                {
                    if (price == pah.Price)
                        continue;
                    productListViewList.Add(pah);
                    count++;
                    price = pah.Price;
                }
                else
                    break;
            }


            return productListViewList;
        }

        private ICriteria GetByProductCriteria(Product product, PriceGroup priceGroup)
        {
            ICriteria crit = GetCriteria();

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            if (PermissionManager.Check(epv) == false)
            {
                IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                ICriteria critPriceList = crit.CreateCriteria("PriceGroup").CreateCriteria("PriceLists");
                critPriceList.Add(Expression.In("ID", intPriceListIds));
            }

            crit.CreateCriteria("PriceBase").CreateCriteria("Product").Add(Expression.Eq("ID", product.ID));
            if(priceGroup != null)
                crit.Add(Expression.Eq("PriceGroup", priceGroup));

            return crit;
        }

        public bool RollBack(PriceAttributeHistory pah)
        {
            pah = GetById(pah.ID);

            PriceAttribute pa = ControllerManager.PriceAttribute.GetPriceAttribute(pah.PriceGroup, pah.PriceBase);
            if(pa == null)
                return false;

            pa.Price = pah.Price;
            pa.PriceCurrency = pah.PriceCurrency;
            pa.CurrencyRate = pah.CurrencyRate;

            ControllerManager.PriceAttribute.Save(pa);
            CommitChanges();
            return true;
        }
    }
}
