using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using ProjectBase.Data;

namespace Grundfos.ScalaConnector.Controllers
{
    public class SaleOrderItemController : AbstractNHibernateDao<SaleOrderItem, string>
    {
        public SaleOrderItemController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<SaleOrderItem> GetMonthlyTransaction(int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1);

            ICriteria crit = GetCriteria();

            ICriteria sale = crit.CreateCriteria("SaleOrder");

            sale.Add(new LtExpression("Date", endDate));
            sale.Add(new GeExpression("Date", startDate));
            crit.SetProjection(Projections.ProjectionList()
                                   .Add(Projections.Sum("Quantity"))
                                   .Add(Projections.GroupProperty("Product"))
                );

            crit.SetResultTransformer(
                    new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(SaleOrderItem).GetConstructors()[1])
                );

            //IList obj = new ArrayList();
            //crit.List(obj);

            return crit.List<SaleOrderItem>();
        }
    }
}
