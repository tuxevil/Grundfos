using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using NybbleMembership.Core.Domain;
using PriceManager.Common;
using NybbleMembership;
using System.Collections;
using NybbleMembership.Core;

namespace PriceManager.Business
{
    public class PriceGroupController : AbstractNHibernateDao<PriceGroup, int>
    {
        public PriceGroupController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public PriceGroup GetByName(string name)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Name", name));

            crit.SetMaxResults(1);

            return crit.UniqueResult<PriceGroup>();
        }

        public void AddToPriceGroup(int priceGroupId, IList<PriceBase> priceBaseToAdd)
        {
            PriceGroup priceGroup = GetById(priceGroupId);

            List<CurrencyRateView> currencyRateViews = ControllerManager.CurrencyRate.GetAllRates() as List<CurrencyRateView>;

            this.BeginTransaction();

            foreach (PriceBase priceBase in priceBaseToAdd)
            {
                PriceAttribute priceAttribute = new PriceAttribute();
                priceAttribute.PriceGroup = priceGroup;
                priceAttribute.PriceBase = priceBase;

                CurrencyRateView cr = currencyRateViews.Find(delegate(CurrencyRateView record)
                                                         {
                                                             if (record.FromCurrency == priceBase.PriceListCurrency &&
                                                                 record.ToCurrency == priceGroup.Currency)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         });

                priceAttribute.Price = priceBase.PriceList * cr.Rate;
                priceAttribute.PriceCurrency = priceGroup.Currency;
                priceAttribute.CurrencyRate = cr.ToCurrencyRate;
                priceAttribute.PricePurchaseCurrencyRate = priceBase.PricePurchaseCurrencyRate;
                priceAttribute.PriceSuggestCurrencyRate = priceBase.PriceSuggestCurrencyRate;

                NHibernateSession.Save(priceAttribute);
            }

            CommitChanges();
        }

        public void RemoveFromPriceGroup(int priceGroupId, IList<PriceAttribute> priceAttributeToRemove)
        {
            PriceGroup priceGroup = GetById(priceGroupId);

            List<PriceAttribute> priceAttributes = new List<PriceAttribute>(priceGroup.PriceAttributes);

            foreach (PriceAttribute priceAttribute in priceAttributeToRemove)
            {
                if (priceAttributes.Exists(delegate(PriceAttribute record)
                                                 {
                                                     if (record.ID == priceAttribute.ID)
                                                     {
                                                         return true;
                                                     }
                                                     return false;
                                                 }))
                {
                    foreach (WorkListItem workListItem in priceAttribute.WorkListItems)
                    {
                        //ControllerManager.WorkListItemHistory.SaveAudit(workListItem, HistoryStatus.Delete);
                        ControllerManager.WorkListItem.Delete(workListItem);
                    }
                    
                    //ControllerManager.PriceAttributeHistory.SaveAudit(priceAttribute, HistoryStatus.Delete);
                    NHibernateSession.Delete(priceAttribute);
                }
            }

            CommitChanges();
        }

        //public void CalculateDiscounts(PriceGroup priceGroup)
        //{
        //    // Find all distributors of this pricelist and assign average to PriceList.
        //    decimal avg = ControllerManager.Distributor.FindMaxDiscountPerPriceGroup(priceGroup);
        //    priceGroup.Discount = avg;
        //    NHibernateSession.Save(priceGroup);

        //    ControllerManager.Provider.CalculateDiscounts();
        //}

        public PriceGroup Create(string name, string description, decimal? adjust, decimal discount, decimal priceSuggestCoef, Currency currency)
        {
            PriceGroup pg = new PriceGroup();
            
            pg = Modify(pg, name, description, adjust, discount, priceSuggestCoef, currency);

            return pg;
        }

        public PriceGroup Modify(PriceGroup pg, string name, string description, decimal? adjust, decimal? discount, decimal priceSuggestCoef, Currency currency)
        {
            pg = GetById(pg.ID);

            pg.Name = name;
            pg.Description = description;
            pg.Adjust = adjust;
            if(discount != null)
                pg.Discount = discount.Value;
            pg.PriceSuggestCoef = priceSuggestCoef;
            
            if(pg.PriceAttributes.Count == 0)
                pg.Currency = currency;

            Save(pg);

            return pg;
        }

        public IList<PriceGroup> List(GridState gridState, out int totalRecords)
        {
            ICriteria crit = ListCriteria();
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<PriceGroup>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = ListCriteria();

            crit.SetMaxResults(gridState.PageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);

            return crit.List<PriceGroup>();
        }

        public ICriteria ListCriteria()
        {
            ICriteria crit = GetCriteria();
            return crit;
        }

        public IList<PriceGroup> GetByPriceLists()
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

               ICriteria critPriceList = crit.CreateCriteria("PriceLists");
               critPriceList.Add(Expression.In("ID", intPriceListIds));
            }

            return crit.List<PriceGroup>();
        }
    }
}
