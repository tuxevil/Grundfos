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
    public class PriceListController : AbstractNHibernateDao<PriceList, int>
    {
        public PriceListController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public PriceList getByProductType(ProductType type)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Type", type));
            return crit.UniqueResult<PriceList>();
        }

        public int QuatintyofPriceListWithDiscount(Discount discount)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Discount", discount));
            return (crit.List<PriceList>().Count);

        }

        public IList<PriceList> getByDiscount(Discount discount)
         {
             ICriteria crit = GetCriteria();
             crit.Add( Expression.Eq("Discount",discount));
            
            return crit.List<PriceList>();

            
         }


    }

   
}