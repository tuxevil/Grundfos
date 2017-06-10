using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using NHibernate.SqlCommand;
using NybbleMembership;
using ProjectBase.Utils.Cache;
using PriceManager.Core.State;


namespace PriceManager.Business
{
    public class LookupController : AbstractNHibernateDao<Lookup, int>
    {
        public LookupController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        /// <summary>
        /// Get all items for the current type
        /// </summary>
        /// <returns>A list of Lookup objects</returns>
        public IList<Lookup> List(LookupType type)
        {
            return List(type, false);
        }

        public IList<Lookup> List(LookupType type, bool isDefault)
        {
            //Cache Section
            string cacheKey = null;
            MembershipHelperUser mhu = MembershipHelper.GetUser();
            if (mhu != null)
                cacheKey = string.Format("LOOKUPS_{0}_{1}_{2}", mhu.UserId, typeof(Lookup).ToString(), type.ToString());

            object result = CacheManager.GetCached(typeof(Lookup), cacheKey);

            //ICriteria crit = GetCriteria();
            if (result == null)
            {
                string query = "SELECT L FROM Lookup L WHERE";

                query += " LookupType = :Type";
                if (isDefault)
                    query += " AND IsDefault = :isDefault";
                query += " ORDER BY UPPER(Description)";

                IQuery q = NHibernateSession.CreateQuery(query);

                q.SetEnum("Type", type);
                if(isDefault)
                    q.SetBoolean("isDefault", isDefault);

                result = q.List<Lookup>();
                //crit.Add(Expression.Eq("LookupType", type));
                //crit.AddOrder(new Order("Description", true));

                //result = crit.List<Lookup>();
                CacheManager.AddItem(typeof(Lookup), cacheKey, result);
            }
            return result as IList<Lookup>;
        }

        public Lookup Create(LookupType type, string title, string description, bool isDefault)
        {
            Lookup l = new Lookup();
            l.LookupType = type;
            l.Title = title;
            l.Description = description;
            l.IsDefault = isDefault;

            if (isDefault)
                UnDefault(type);

            Save(l);
            CacheManager.ExpireAll(typeof(Lookup));
            return l;
        }

        private void UnDefault(LookupType type)
        {
            IList<Lookup> lst = List(type);
            BeginTransaction();
            foreach (Lookup lookup in lst)
            {
                lookup.IsDefault = false;
                Save(lookup);
            }
            CommitChanges();
        }

        public void Edit(int id, LookupType type, string title, string description, bool isDefault)
        {
            Lookup l = GetById(id);
            l.LookupType = type;
            l.Title = title;
            l.Description = description;
            l.IsDefault = isDefault;

            if (isDefault)
                UnDefault(type);

            Save(l);
            CacheManager.ExpireAll(typeof(Lookup));
        }

        public IList<Lookup> List(string description, LookupType? type, GridState gridState, out int records)
        {
            ICriteria crit = ListCriteria(description, type);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));
            records = crit.UniqueResult<int>();
            if (records == 0)
                return new List<Lookup>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, records);

            crit = ListCriteria(description, type);

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


            return crit.List<Lookup>();
        }

        protected ICriteria ListCriteria(string description, LookupType? type)
        {
            ICriteria crit = GetCriteria();
            if (!string.IsNullOrEmpty(description))
            {
                Disjunction d = new Disjunction();
                d.Add(Restrictions.InsensitiveLike("Description", description, MatchMode.Anywhere));
                crit.Add(d);
            }

            if (type != null)
                crit.Add(Expression.Eq("LookupType", type));

            return crit;
        }

        public int Erase(int id)
        {
            Lookup l = GetById(id);
            try
            {
                Delete(l);
                CommitChanges();
            }
            catch (Exception)
            {
                id = -1;
                //throw new Exception("No se pudo eliminar.");
            }
            CacheManager.ExpireAll(typeof(Lookup));
            return id;
        }
    }
}