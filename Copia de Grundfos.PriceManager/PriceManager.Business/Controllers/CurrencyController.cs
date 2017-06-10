using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;


namespace PriceManager.Business
{
    public class CurrencyController : AbstractNHibernateDao<Currency, int>
    {
        public CurrencyController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public string GetBaseCurrency()
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Value", Convert.ToDecimal(1)));

            return crit.UniqueResult<Currency>().Description;
        }
    }
}