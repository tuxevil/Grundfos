using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using ProjectBase.Data;

namespace Grundfos.ScalaConnector.Controllers
{
    public class PurchaseOrderItemController : AbstractNHibernateDao<PurchaseOrderItem, string>
    {
        public PurchaseOrderItemController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<PurchaseOrderItem> GetMonthlyTransaction(int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = startDate.AddMonths(1);

            ICriteria crit = GetCriteria();

            ICriteria purchase = crit.CreateCriteria("PurchaseOrder");

            purchase.Add(new LtExpression("Date", endDate));
            purchase.Add(new GeExpression("Date", startDate));
            crit.SetProjection(Projections.ProjectionList()
                                   .Add(Projections.Sum("Quantity"))
                                   .Add(Projections.GroupProperty("Product"))
                );

            crit.SetResultTransformer(
                    new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PurchaseOrderItem).GetConstructors()[1])
                );

            //IList obj = new ArrayList();
            //crit.List(obj);

            return crit.List<PurchaseOrderItem>();
        }

        public IList<PurchaseOrderItem> GetWeeklyTransaction(DateTime startDate, DateTime endDate)
        {
            ICriteria crit = GetCriteria();

            ICriteria purchase = crit.CreateCriteria("PurchaseOrder");

            purchase.Add(new LeExpression("Date", endDate));
            purchase.Add(new GeExpression("Date", startDate));
            crit.SetProjection(Projections.ProjectionList()
                                   .Add(Projections.Sum("Quantity"))
                                   .Add(Projections.GroupProperty("Product"))
                );

            crit.SetResultTransformer(
                    new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PurchaseOrderItem).GetConstructors()[1])
                );

            return crit.List<PurchaseOrderItem>();
        }


        public PurchaseOrderItem GetPurchaseOrderInfo(Product product, PurchaseOrder po)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new EqExpression("Product", product));
            crit.Add(new EqExpression("PurchaseOrder", po));
        	ICriteria critPurchaseOrder = crit.CreateCriteria("PurchaseOrder");
			//critPurchaseOrder.Add( new LtExpression( "Date" , endDate ) );
			//critPurchaseOrder.Add( new GeExpression( "Date" , startDate ) );


            return crit.UniqueResult<PurchaseOrderItem>();
        }
    }
}
