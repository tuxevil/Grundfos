using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;

namespace PriceManager.Business
{
    public class WorkListItemController : AbstractNHibernateDao<WorkListItem, int>
    {
        public WorkListItemController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public ProductView GetProductView(int id, int toCurrency)
        {
            string hql = "SELECT WLI.ID, P.Description, P.Code, PI.PriceSell, PI.Price, PI.CTM, PI.CTR, PI.Index, PI.LastPrice, PI.PCR, WLI.WorkListItemStatus, PI.PLCurrencyId, PI.PricePurchase";
            hql += " FROM ProductInfoByPriceList PI";
            hql += " JOIN PI.WorkListItem WLI";
            hql += " JOIN WLI.PriceAttribute PA";
            hql += " JOIN PA.PriceGroup PG";
            hql += " JOIN PA.PriceBase PB";
            hql += " JOIN PB.Provider PV";
            hql += " JOIN PB.Product P";
            hql += " WHERE PB.Status = :Status";
            hql += " AND P.Status = :ProductStatus";
            hql += " AND WLI.ID = :Id";
            
            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetEnum("Status", PriceBaseStatus.Verified);
            q.SetEnum("ProductStatus", ProductStatus.Active);
            q.SetInt32("Id", id);

            q.SetMaxResults(1);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductView).GetConstructors()[3]));
            return q.UniqueResult<ProductView>();
        }

        public WorkListItem Get(PriceBase pb, PriceList pl)
        {
            ICriteria crit = GetCriteria();

            ICriteria pa = crit.CreateCriteria("PriceAttribute");
            pa.Add(Expression.Eq("PriceBase", pb));
            crit.Add(Expression.Eq("PriceList", pl));

            return crit.UniqueResult<WorkListItem>();
        }

        public WorkListItem GetByIdentifier(int id)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ID", id));
            return crit.UniqueResult<WorkListItem>();
        }
    }
}
