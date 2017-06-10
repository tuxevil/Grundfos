using NHibernate.Cfg;
using ProjectBase.Data;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using PartnerNet.Common;


namespace Grundfos.ScalaConnector.Controllers
{
    public class StockMovementPendingController : AbstractNHibernateDao<StockMovementPending, string>
    {
        public StockMovementPendingController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<StockMovementPending> GetPurchaseOrders()
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.InsensitiveLike("OrderNumber", "00000", MatchMode.Start));
            crit.Add(new EqExpression("Warehouse", "01"));
            return crit.List<StockMovementPending>();
        }

        public IList<StockMovementPending> GetSaleOrders()
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Not(Expression.InsensitiveLike("OrderNumber", "00000", MatchMode.Start)));
            return crit.List<StockMovementPending>();
        }
    }
}
