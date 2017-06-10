using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using ProjectBase.Utils.Cache;
using Zayko.Finance;

namespace PriceManager.Business
{
    public class CurrencyRateController : AbstractNHibernateDao<CurrencyRate, int>
    {
        public CurrencyRateController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        #region Rate Methods
        public IList<CurrencyRateView> GetAllRates()
        {
            ICriteria crit = NHibernateSession.CreateCriteria(typeof(CurrencyRateView));
            return crit.List<CurrencyRateView>();
        }

        public decimal GetRate(Currency fromCurrency, Currency toCurrency)
        {
            ICriteria crit = NHibernateSession.CreateCriteria(typeof(CurrencyRateView));
            crit.Add(Expression.And(Expression.Eq("FromCurrency", fromCurrency), Expression.Eq("ToCurrency", toCurrency)));

            return crit.UniqueResult<CurrencyRateView>().Rate;
        }
        #endregion

        #region Listing Methods

        public List<CurrencyRate> GetLastList()
        {
            string query = @"select CR.Id from CurrencyRate CR
                            inner join (select max([Date]) as MaxDate, CurrencyId
                            from CurrencyRate
                            group by CurrencyId) LCR on CR.Date = LCR.MaxDate and CR.CurrencyId = LCR.CurrencyId";

            IQuery q = NHibernateSession.CreateSQLQuery(query);

            List<int> tempids = q.List<int>() as List<int>;

            ICriteria crit = GetCriteria();

            crit.Add(Expression.In("ID", tempids));

            return crit.List<CurrencyRate>() as List<CurrencyRate>;
        }

        public CurrencyRate GetLast(Currency currency)
        {
            string query = @"select CR.Id from CurrencyRate CR
                            inner join (select max([Date]) as MaxDate, CurrencyId
                            from CurrencyRate
                            group by CurrencyId) LCR on CR.Date = LCR.MaxDate and CR.CurrencyId = LCR.CurrencyId
                            where CR.CurrencyId = :CurrencyId";

            IQuery q = NHibernateSession.CreateSQLQuery(query);
            q.SetInt32("CurrencyId", currency.ID);

            int tempid = q.UniqueResult<int>();

            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("ID", tempid));

            return crit.UniqueResult<CurrencyRate>();
        }

        public List<CurrencyRate> ListByCurrency(Currency currency)
        {
            return ListByCurrency(currency, 10);
        }

        public List<CurrencyRate> ListByCurrency(Currency currency, int maxResults)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Currency", currency));
            crit.AddOrder(new Order("Date", false));
            crit.SetMaxResults(maxResults);

            List<CurrencyRate> lst = crit.List<CurrencyRate>() as List<CurrencyRate>;
            
            return lst;
        }

        #endregion

        #region Synchronization Methods

        public void Synchronize()
        {
            Currency baseCurrency = ControllerManager.Currency.GetBaseCurrency();
            IList<Currency> lstCurrency = ControllerManager.Currency.GetAll();

            this.BeginTransaction();
            foreach (Currency currency in lstCurrency)
                Synchronize(currency, baseCurrency);
            this.CommitChanges();

            Utils.GetLogger().Info(string.Format("[[CURRENCY UPDATE]] {0} Currencies Updated", lstCurrency.Count));

            NHibernateSession.Clear();
        }

        public void Synchronize(Currency currency)
        {
            currency = ControllerManager.Currency.GetById(currency.ID);
            Currency baseCurrency = ControllerManager.Currency.GetBaseCurrency();
            this.BeginTransaction();
            Synchronize(currency, baseCurrency);
            this.CommitChanges();

            NHibernateSession.Clear();
        }

        private void Synchronize(Currency currency, Currency baseCurrency)
        {
            if (currency == baseCurrency)
                return;

            try
            {
                WebServiceX.CurrencyConvertor currencyConvertor = new WebServiceX.CurrencyConvertor();
                double rate = currencyConvertor.ConversionRate(
                    (WebServiceX.Currency)Enum.Parse(typeof(WebServiceX.Currency), currency.Code),
                    (WebServiceX.Currency)Enum.Parse(typeof(WebServiceX.Currency), baseCurrency.Code));
                Create(currency, Convert.ToDecimal(rate));
            }
            catch (Exception ex)
            {
                Utils.GetLogger().Error(ex);
                throw new Exception("En este momento no se puede actualizar la cotización. Por favor, vuelva a intentarlo en unos minutos.");
            }
        }

        #endregion

        #region Creation Methods

        public CurrencyRate Create(Currency c, decimal value, DateTime date)
        {
            if (value == 0)
                return null;
            this.BeginTransaction();

            if (c.LastCurrencyRateView != null && value == c.LastCurrencyRateView.Rate)
                return null;

            CurrencyRate newCR = new CurrencyRate();
            newCR.Currency = c;
            newCR.Rate = value;
            newCR.Date = date;
            Save(newCR);

            if (c.LastCurrencyRateView != null)
                NHibernateSession.Refresh(c.LastCurrencyRateView);

            CommitChanges();

            UpdateCurrenciesArray();

            return newCR;
        }

        public CurrencyRate Create(Currency c, decimal value)
        {
            return Create(c, value, DateTime.Now);
        }

        #endregion

        #region Array Helper Methods

        public CurrencyRateConverter[,] GetArray()
        {
            object o = CacheManager.GetCached(CurrencyRate.CURRENCY_RATE);
            if (o == null)
                return UpdateCurrenciesArray();

            return o as CurrencyRateConverter[,];
        }

        private CurrencyRateConverter[,] UpdateCurrenciesArray()
        {
            object o = CacheManager.GetCached(CurrencyRate.CURRENCY_RATE);
            if (o != null)
                CacheManager.ExpireItem(CurrencyRate.CURRENCY_RATE);

            ICriteria crit = NHibernateSession.CreateCriteria(typeof(CurrencyRateView));
            crit.AddOrder(new Order("FromCurrency", true));
            crit.AddOrder(new Order("ToCurrency", true));

            IList<CurrencyRateView> tmp = crit.List<CurrencyRateView>();

            int indice = Convert.ToInt32(Math.Pow(tmp.Count, Convert.ToDouble(1) / 2));

            CurrencyRateConverter[,] lst = new CurrencyRateConverter[indice, indice];
            foreach (CurrencyRateView currencyRateView in tmp)
                lst[currencyRateView.FromCurrency.ID - 1, currencyRateView.ToCurrency.ID - 1] = new CurrencyRateConverter(currencyRateView.ToCurrency.Description, currencyRateView.Rate);
            o = lst;

            CacheManager.AddItem(CurrencyRate.CURRENCY_RATE, o);

            return lst;
        }

        #endregion
    }

}
