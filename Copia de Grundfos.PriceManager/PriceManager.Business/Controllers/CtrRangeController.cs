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
    public class CtrRangeController : AbstractNHibernateDao<CtrRange, int>
    {
        public CtrRangeController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<CtrRange> GetCTRRangeList()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Min", false));
            return crit.List<CtrRange>();
        }
    }
}