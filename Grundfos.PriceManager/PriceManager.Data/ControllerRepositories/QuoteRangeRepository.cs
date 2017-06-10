using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using PriceManager.Core.State;
using ProjectBase.Data;

namespace PriceManager.Data.ControllerRepositories
{
    public class QuoteRangeRepository : AbstractNHibernateDao<QuoteRange, int>, IQuoteRangeRepository
    {
        public QuoteRangeRepository(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public void BeginTransactions()
        {
            this.BeginTransaction();
        }

        public void CommitChange()
        {
            this.CommitChanges();
        }

        public void GenericDelete(object o)
        {
            NHibernateSession.Delete(o);
        }

        public void Refresh(object o)
        {
            NHibernateSession.Refresh(o);
        }

        public IList<QuoteRange> List(GridState gridState, out int totalRecords)
        {
            ICriteria crit = GetCriteria();

            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<QuoteRange>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = GetCriteria();

            crit.SetMaxResults(gridState.PageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);

            string[] sort = gridState.SortField.Split('.');

            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.CreateCriteria(sort[0], JoinType.LeftOuterJoin);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<QuoteRange>();
        }

        public QuoteRange GetByTitle(string title)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Title", title));

            return crit.UniqueResult() as QuoteRange;
        }
    }
}
