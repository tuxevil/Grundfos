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
    public class DiscountController : AbstractNHibernateDao<Discount, int>
    {
        public DiscountController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void Modify(Discount discount, decimal disc)
        {
            if (discount != null)
            {
                discount.MaxDiscount = disc;
                
                Save(discount);
                NHibernateSession.Flush();
            }
        }

        public bool canDelete(Discount discount)
        {
           int p = ControllerManager.PriceList.QuatintyofPriceListWithDiscount(discount);    
            
           return ((p > 0) ? false : true);
        }

        public void AddDiscount( string description, decimal discount)
        {
            Discount d = new Discount();

                d.Description = description;
                d.MaxDiscount = discount;
                
                Save(d);
        }

        public void RunModification(Discount discount, Guid userid, DateTime moddate)
        {
            IQuery q = NHibernateSession.GetNamedQuery("sp_DiscountModification");
            q.SetInt32("discountid", discount.ID);
            q.SetGuid("userid", userid);
            q.SetDateTime("moddate", moddate);
            q.UniqueResult();
            
        }
    }
}