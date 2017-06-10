using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;

namespace PriceManager.Business
{
    public class PriceAttributeController : AbstractNHibernateDao<PriceAttribute, int>
    {
        public PriceAttributeController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public ProductView GetProductView(int id, int toCurrency)
        {
            string hql = "SELECT PA.ID, P.Description, P.Code, PI.PriceSell, PI.Price, PI.CTM, PI.CTR, PI.Index, PI.LastPrice, PI.PLCurrencyId, PI.PricePurchase";
            hql += " FROM ProductInfoByGroup PI";
            hql += " JOIN PI.PriceAttribute PA";
            hql += " JOIN PA.PriceGroup PG";
            hql += " JOIN PA.PriceBase PB";
            hql += " JOIN PB.Provider PV";
            hql += " JOIN PB.Product P";
            hql += " WHERE PB.Status = :Status";
            hql += " AND P.Status = :ProductStatus";
            hql += " AND PA.ID = :Id";
            
            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetEnum("Status", PriceBaseStatus.Verified);
            q.SetEnum("ProductStatus", ProductStatus.Active);
            q.SetInt32("Id", id);
            
            q.SetMaxResults(1);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductView).GetConstructors()[1]));
            return q.UniqueResult<ProductView>();
        }

        public PriceAttribute GetPriceAttribute(PriceGroup priceGroup, PriceBase priceBase)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("PriceBase", priceBase));
            crit.Add(Expression.Eq("PriceGroup", priceGroup));

            return crit.UniqueResult<PriceAttribute>();
        }
    }
}
