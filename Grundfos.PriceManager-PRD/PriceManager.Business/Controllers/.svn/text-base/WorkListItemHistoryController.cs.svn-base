using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using ProjectBase.Data;
using NHibernate;
using NHibernate.Criterion;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership;
using NybbleMembership.Core;
using System.Collections;

namespace PriceManager.Business
{
    public class WorkListItemHistoryController : AbstractNHibernateDao<WorkListItemHistory, int>
    {
        public WorkListItemHistoryController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        //public WorkListItemHistory SaveAudit(WorkListItem workListItem, HistoryStatus historyStatus)
        //{
        //    WorkListItemHistory workListItemHistory = new WorkListItemHistory();

        //    workListItemHistory.Price = workListItem.Price;
        //    workListItemHistory.LastApproved = workListItem.LastApproved;
        //    workListItemHistory.LastPublishItem = workListItem.LastPublishItem;
        //    workListItemHistory.PriceCurrency = workListItem.PriceCurrency;
        //    workListItemHistory.PriceList = workListItem.PriceList;
        //    workListItemHistory.WorkListItemStatus = workListItem.WorkListItemStatus;
        //    workListItemHistory.PriceBase = workListItem.PriceAttribute.PriceBase;
        //    workListItemHistory.CurrencyRate = workListItem.CurrencyRate;
        //    workListItemHistory.HistoryStatus = historyStatus;
        //    workListItemHistory.PricePurchaseCurrencyRate = workListItem.PricePurchaseCurrencyRate;
        //    workListItemHistory.PriceSuggestCurrencyRate = workListItem.PriceSuggestCurrencyRate;

        //    Save(workListItemHistory);

        //    return workListItemHistory;
        //}
        
        //public void SaveAudit(IList<WorkListItem> wliList, HistoryStatus historyStatus)
        //{
        //    foreach (WorkListItem workListItem in wliList)
        //    {
        //        SaveAudit(workListItem, historyStatus);
        //    }
        //}

        public IList<WorkListItemHistory> GetByProduct(Product product, PriceList priceList, GridState gridState, out int totalRecords)
        {
            ICriteria crit = GetByProductCriteria(product, priceList);
            
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            crit.AddOrder(new Order("PriceList", true));
            crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
            
            string[] sort = gridState.SortField.Split('.');

            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            IList<WorkListItemHistory> workListItemHistoryList = crit.List<WorkListItemHistory>();
            IList<WorkListItemHistory> productListViewList = new List<WorkListItemHistory>();

            totalRecords = workListItemHistoryList.Count;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            int count;
            int maxcount;
            if (pageNumber == 1)
                count = 0;
            else
                count = (pageNumber - 1) * gridState.PageSize;
            maxcount = count + pageSize;
            decimal price = -1;

            foreach (WorkListItemHistory wlih in workListItemHistoryList)
            {
                if (count < maxcount)
                {
                    if (price == wlih.Price)
                        continue;
                    productListViewList.Add(wlih);
                    count++;
                    price = wlih.Price;
                }
                else
                    break;
            }


            return productListViewList;
        }

        private ICriteria GetByProductCriteria(Product product, PriceList priceList)
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

                ICriteria critPriceList = crit.CreateCriteria("PriceList");
                critPriceList.Add(Expression.In("ID", intPriceListIds));
            }

            crit.CreateCriteria("PriceBase").CreateCriteria("Product").Add(Expression.Eq("ID", product.ID));
            if(priceList != null)
                crit.Add(Expression.Eq("PriceList", priceList));
            return crit;
        }

        public bool RollBack(WorkListItemHistory wlih)
        {
            wlih = GetById(wlih.ID);

            WorkListItem wli = ControllerManager.WorkListItem.Get(wlih.PriceBase, wlih.PriceList);
            if(wli == null)
                return false;
            //SaveAudit(wli, HistoryStatus.RollBack);

            wli.Price = wlih.Price;
            wli.PriceCurrency = wlih.PriceCurrency;
            wli.CurrencyRate = wlih.CurrencyRate;

            ControllerManager.WorkListItem.Save(wli);
            CommitChanges();
            return true;
        }
    }
}
