using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NHibernate;
using NHibernate.Expression;
using PartnerNet.Domain;
using ProjectBase.Data;

namespace PartnerNet.Business
{
    public class TransactionHistoryWeeklyController : AbstractNHibernateDao<TransactionHistoryWeekly, int>
    {
        public TransactionHistoryWeeklyController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<TransactionHistoryWeekly> GetInfo(int productID, int week, int year, int period)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ProductID", new Product(productID)));
       
            int weekDif = (week - period);
            if (weekDif <= 0)
            {
                Disjunction dis = new Disjunction();
                dis.Add(new AndExpression(new BetweenExpression("Week", 52 + weekDif, 52), new EqExpression("Year", year - 1)));
                dis.Add(new AndExpression(new BetweenExpression("Week", 1, week), new EqExpression("Year", year)));
                crit.Add(dis);
            }
            else
                crit.Add(new AndExpression(new BetweenExpression("Week", week - period, week), new EqExpression("Year", year)));
            
            crit.AddOrder(new Order("Year", false));
            crit.AddOrder(new Order("Week", false));
            
            return crit.List<TransactionHistoryWeekly>();
        }

        public TransactionHistoryWeekly GetIndividualInfo(int productID, int week, int year)
        {
            if(productID==2008)
                return new TransactionHistoryWeekly(0, ControllerManager.Product.GetById(productID));
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ProductID", new Product(productID)));
            crit.Add(new AndExpression(new EqExpression("Week", week), new EqExpression("Year", year)));

            return crit.UniqueResult<TransactionHistoryWeekly>();
        }

        public IList<TransactionHistoryWeekly> GetSalesTotal(Product productID, int week, int year)
        {
            List<TransactionHistoryWeekly> info = new List<TransactionHistoryWeekly>();
            
            for (int interval = 4; interval <= 52; )
            {
                ICriteria crit = GetCriteria();
                crit.Add(Expression.Eq("ProductID", productID));

                int weekDif = (week - interval);
                if (weekDif <= 0)
                {
                    Disjunction dis = new Disjunction();
                    dis.Add(new AndExpression(new BetweenExpression("Week", 52 + weekDif, 52), new EqExpression("Year", year - 1)));
                    dis.Add(new AndExpression(new BetweenExpression("Week", 1, week), new EqExpression("Year", year)));
                    crit.Add(dis);
                }
                else
                    crit.Add(new AndExpression(new BetweenExpression("Week", week - interval, week), new EqExpression("Year", year)));

                crit.SetProjection(Projections.ProjectionList()
                                       .Add(Projections.Sum("Sale"))
                                       .Add(Projections.GroupProperty("ProductID"))
                    );

                crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(TransactionHistoryWeekly).GetConstructors()[1]));
                
                TransactionHistoryWeekly res = crit.UniqueResult<TransactionHistoryWeekly>();
                if (res == null)
                {
                    res = new TransactionHistoryWeekly();
                    res.Sale = 0;
                }

                info.Add(res);

                switch(interval)
                {
                    case 4:
                        interval = 13;
                        break;
                    case 13:
                        interval = 26;
                        break;
                    case 26:
                        interval = 52;
                        break;
                    case 52:
                        interval = 60;
                        break;
                }
            }
            return info;
        }

       

        public void CalculateStatistic(Product productid, int week, int year, Period period)
        {
            int interval = 0;
            if (Convert.ToInt32(period) == 1)
                interval = 4;
            else if (Convert.ToInt32(period) == 2)
                interval = 8;
            else if (Convert.ToInt32(period) == 3)
                interval = 13;
            else if (Convert.ToInt32(period) == 4)
                interval = 26;
            else if (Convert.ToInt32(period) == 5)
                interval = 52;
            
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ProductID", productid));

            int weekDif = (week - interval);
            if (weekDif <= 0)
            {
                Disjunction dis = new Disjunction();
                dis.Add(new AndExpression(new BetweenExpression("Week", 52 + weekDif, 52), new EqExpression("Year", year - 1)));
                dis.Add(new AndExpression(new BetweenExpression("Week", 1, week), new EqExpression("Year", year)));
                crit.Add(dis);
            }
            else
                crit.Add(new AndExpression(new BetweenExpression("Week", week - interval, week), new EqExpression("Year", year)));
            
            //crit.Add(new AndExpression(new OrExpression(new AndExpression(new EqExpression("Year", year), new GtExpression("Week", week)), new AndExpression(new GtExpression("Year", year), new LeExpression("Week", week))), new OrExpression(new AndExpression(new EqExpression("Year", year), new LeExpression("Week", week)), new AndExpression(new LtExpression("Year", year), new GeExpression("Week", week)))));
            crit.SetProjection(Projections.ProjectionList()
                                   .Add(Projections.Avg("Purchase"))
                                   .Add(Projections.Avg("Sale"))
                                   .Add(Projections.GroupProperty("ProductID"))
                );
            
            //IList lst = crit.List();

            crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductStatisticWeekly).GetConstructors()[1]));
            ProductStatisticWeekly res = crit.UniqueResult<ProductStatisticWeekly>();
            if(res == null)
            {
                res= new ProductStatisticWeekly();
                res.Product = productid;
                res.Sale = 0;
                res.Purchase = 0;
                res.Period = period;
            }
            else
                res.Period = period;

            this.NHibernateSession.Save(res);
            
        }
    }
}
