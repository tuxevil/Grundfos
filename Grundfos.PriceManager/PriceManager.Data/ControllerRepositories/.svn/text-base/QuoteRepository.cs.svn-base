using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using PriceManager.Core.State;
using ProjectBase.Data;

namespace PriceManager.Data.ControllerRepositories
{
    public class QuoteRepository : AbstractNHibernateDao<Quote, int>, IQuoteRepository
    {
        public QuoteRepository(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Quote> List(GridState gridState, string text, Distributor distributor, QuoteStatus? status, out int records, Guid? userId, IList quoteIds)
        {
            ICriteria crit = ListCriteria(text, distributor, status, userId, quoteIds);

            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            records = crit.UniqueResult<int>();
            if (records == 0)
                return new List<Quote>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, records);

            crit = ListCriteria(text, distributor, status, userId, quoteIds);

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
                critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<Quote>();
        }

        public ICriteria ListCriteria(string text, Distributor distributor, QuoteStatus? status, Guid? userId, IList quoteIds)
        {
            ICriteria crit = GetCriteria();

            if (quoteIds != null)
            {
                int[] intQuoteIds = new int[quoteIds.Count];
                for (int i = 0; i < quoteIds.Count; i++)
                    intQuoteIds[i] = Convert.ToInt32(quoteIds[i]);

                crit.Add(Expression.In("ID", intQuoteIds));
            }

            if (!string.IsNullOrEmpty(text))
            {
                Disjunction d = new Disjunction();
                d.Add(Restrictions.InsensitiveLike("Description", text, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("Observations", text, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("Number", text, MatchMode.Anywhere));
                crit.Add(d);
            }
            if (distributor != null)
                crit.Add(Expression.Eq("Distributor", distributor));

            if (status != null)
                crit.Add(Expression.Eq("Status", status));

            if (userId.HasValue)
                crit.Add(Expression.Eq("TimeStamp.ModifiedBy", userId));

            return crit;
        }

        public IList<Quote> GetQuotesByUser(Distributor d, Guid userId)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Distributor", d));
            crit.Add(Expression.Eq("TimeStamp.CreatedBy", userId));

            return crit.List<Quote>();
        }

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
        public QuoteItem SaveQuoteItem(QuoteItem qi)
        {
            return NHibernateSession.Save(qi) as QuoteItem;
        }

        public void Refresh(object o)
        {
            NHibernateSession.Refresh(o);
        }
    }
}
