using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using Zayko.Finance;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class CurrencyController : AbstractNHibernateDao<Currency, int>
    {
        public CurrencyController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public Currency GetBaseCurrency()
        {
            ICriteria crit = GetCriteria();
            ICriteria rate = crit.CreateCriteria("LastCurrencyRateView");
            rate.Add(Expression.Eq("Rate", Convert.ToDecimal(1)));

            return crit.UniqueResult<Currency>();
        }

        public Currency GetByDescription(string description)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Description", description));

            return crit.UniqueResult<Currency>();
        }

        public List<string> GetCurrencyCodes()
        {
            return GetCurrencyCodes(string.Empty);
        }

        public List<string> GetCurrencyCodes(string currentCode)
        {
            List<string> lst = new List<string>(CurrencyList.Codes);

            IList<Currency> lstCurrencies = GetAll();
            foreach (Currency c in lstCurrencies)
                if (currentCode != c.Code)
                    lst.Remove(c.Code);

            return lst;
        }

        public void Edit(int id, string description, decimal value, string code)
        {
            this.BeginTransaction();

            Currency c = GetById(id);
            c.Description = description;
            c.Code = code;
            Save(c);

            ControllerManager.CurrencyRate.Create(c, value);

            this.CommitChanges();
        }

        public Currency Create(string description, decimal value, string code)
        {
            Currency c = new Currency();
            
            c.Description = description;
            c.Code = code;
            Save(c);
            CommitChanges();
            
            CurrencyRate newCR = new CurrencyRate();
            newCR.Currency = c;
            newCR.Rate = value;
            newCR.Date = DateTime.Now;
            ControllerManager.CurrencyRate.Save(newCR);
            
            return c;
        }

        public IList<Currency> List(GridState gridState, out int records)
        {
            ICriteria crit = ListCriteria();
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));
            records = crit.UniqueResult<int>();
            if (records == 0)
                return new List<Currency>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, records);


            crit = ListCriteria();
            crit.SetMaxResults(gridState.PageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);

            crit.AddOrder(new Order("Description", false));

            return crit.List<Currency>();
        }

        private ICriteria ListCriteria()
        {
            ICriteria crit = GetCriteria();
            ICriteria rate = crit.CreateCriteria("LastCurrencyRateView");
            rate.Add(Expression.Not(Expression.Eq("Rate", Convert.ToDecimal(1))));
            return crit;
        }

        public void Remove(int id)
        {
            Currency c = GetById(id);
            Delete(c);
        }
    }
}