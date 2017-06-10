using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using ProjectBase.Data;

namespace Grundfos.ScalaConnector.Controllers
{
    public class TransactionsController : AbstractNHibernateDao<Transactions, string>
    {
        public TransactionsController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Transactions> GetTransaction(DateTime startDate, DateTime endDate)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new LeExpression("Date", endDate));
            crit.Add(new GtExpression("Date", startDate));

            return crit.List<Transactions>();
        }
        public IList<Transactions> GetTransaction(DateTime startDate, DateTime endDate, Product prod)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new LeExpression("Date", endDate));
            crit.Add(new GtExpression("Date", startDate));
            crit.Add(new EqExpression("Id", prod));


            return crit.List<Transactions>();
        }

    }
}
