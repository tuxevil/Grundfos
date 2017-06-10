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
    public class DistributorRepository : AbstractNHibernateDao<Distributor, int>, IDistributorRepository
    {
        public DistributorRepository(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Distributor> GetByPriceList(int id)
        {
            ICriteria crit = GetCriteria();

            crit.CreateCriteria("PriceList").Add(Expression.Eq("ID", id));
            crit.Add(Expression.Not(Expression.Eq("DistributorStatus", DistributorStatus.Disable)));
            crit.AddOrder(new Order("Name", false));

            return crit.List<Distributor>();
        }

        public IList<Distributor> GetActivesByPriceGroup(PriceGroup pG, int? maxResults, IList priceListIds)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Not(Expression.Eq("DistributorStatus", DistributorStatus.Disable)));

            ICriteria critPriceList = crit.CreateCriteria("PriceList");

            if (priceListIds != null)
            {
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                critPriceList.Add(Expression.In("ID", intPriceListIds));
            }

            critPriceList.Add(Expression.Or(Expression.Eq("PriceListStatus", PriceListStatus.Active), Expression.Eq("PriceListStatus", PriceListStatus.New)));
            critPriceList.Add(Expression.Eq("PriceGroup", pG));


            crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
            if (maxResults.HasValue)
                crit.SetMaxResults(maxResults.Value);

            return crit.List<Distributor>() as IList<Distributor>;
        }

        public IList<Distributor> GetDistributors(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, out int totalRecords, Lookup saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive)
        {
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            ICriteria crit = GetDistributorsCriteria(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page, priceListIds, isActive);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<Distributor>();

            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = GetDistributorsCriteria(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page, priceListIds, isActive);

            if(gridState.PageSize > 0)
                crit.SetMaxResults(gridState.PageSize);
            if(pageNumber > 0)
            {
                if (pageNumber == 1)
                    crit.SetFirstResult(0);
                else
                    crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);
            }

            string[] sort = gridState.SortField.Split('.');

            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.CreateCriteria(sort[0], JoinType.LeftOuterJoin);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<Distributor>();
        }

        private ICriteria GetDistributorsCriteria(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, Lookup saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive)
        {
            ICriteria crit = GetCriteria();

            if (priceListIds != null)
            {
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                ICriteria critDistributor = crit.CreateCriteria("PriceList");
                critDistributor.Add(Expression.In("ID", intPriceListIds));
            }


            if (!string.IsNullOrEmpty(name))
            {
                Disjunction d = new Disjunction();
                d.Add(Expression.InsensitiveLike("Name", name, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("Code", name, MatchMode.Anywhere));
                crit.Add(d);
            }


            if (country != null)
            {
                ICriteria critCountry = crit.CreateCriteria("Country");
                critCountry.Add(Expression.Eq("ID", country.ID));
            }
            if (priceList != null)
            {
                ICriteria critPriceList = crit.CreateCriteria("PriceList");
                critPriceList.Add(Expression.Eq("ID", priceList.ID));
            }
            if (paymentTerm != null)
                crit.Add(Expression.Eq("PaymentTerm", paymentTerm));

            if (status != null)
                crit.Add(Expression.Eq("DistributorStatus", status));
            else
                if (isActive == false)
                    crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));

            if (saleCondition != null)
                crit.Add(Expression.Eq("SaleConditions", saleCondition));

            if (type != null)
                crit.Add(Expression.Eq("Type", type));

            if (page != null)
                crit.CreateCriteria("PriceList").CreateCriteria("CategoryPages").Add(Expression.Eq("ID", page.ID));

            return crit;
        }

        public List<Distributor> GetDistributorList(List<int> distributorID, bool markedAll)
        {
            ICriteria crit = GetCriteria();
            if (markedAll)
                crit.Add(Expression.Not(Expression.In("ID", distributorID)));
            else
                crit.Add(Expression.In("ID", distributorID));

            return crit.List<Distributor>() as List<Distributor>;
        }

        public Distributor GetByCode(string code)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Code", code));

            return crit.UniqueResult<Distributor>();
        }

        public Distributor GetByName(string name)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Name", name));
            IList<Distributor> lst = crit.List<Distributor>();

            if (lst.Count > 0)
                new Exception("Existe mas de un distribuidor con ese nombre.");
            else if (lst.Count == 0)
                return null;

            return lst[0];
        }

        public IList<Distributor> GetActives()
        {
            string query = "SELECT D FROM Distributor D WHERE";

            query += " DistributorStatus = :Status";
            query += " ORDER BY UPPER(Name)";

            IQuery q = NHibernateSession.CreateQuery(query);

            q.SetEnum("Status", DistributorStatus.Active);

            return q.List<Distributor>();

            //ICriteria crit = GetCriteria();
            //crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));
            //crit.AddOrder(new Order("Name", false));

            //return crit.List<Distributor>();
        }

        public IList<Distributor> GetActivesByPriceList(IList priceListIds)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));

            if (priceListIds != null)
            {
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                ICriteria critPriceList = crit.CreateCriteria("PriceList");
                critPriceList.Add(Expression.In("ID", intPriceListIds));
            }

            crit.AddOrder(new Order("Name", false));

            return crit.List<Distributor>();
        }

        public List<string> GetActives(string name, int count, IList priceListIds)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));

            crit.Add(Expression.InsensitiveLike("Name", name, MatchMode.Anywhere));

            if (priceListIds != null)
            {
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                ICriteria critDistributor = crit.CreateCriteria("PriceList");
                critDistributor.Add(Expression.In("ID", intPriceListIds));
            }

            crit.AddOrder(new Order("Name", false));
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Property("Name"))
                                .Add(Projections.Property("Code")));

            if (count > 0)
                crit.SetMaxResults(count);

            crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(Distributor).GetConstructors()[2]));

            IList<Distributor> lst = crit.List<Distributor>();
            List<string> finallst = new List<string>();
            foreach (Distributor dis in lst)
                finallst.Add(dis.NameCode);

            return finallst;
        }

        public bool Check(string name)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Name", name));

            IList<Distributor> lstDistributos = crit.List<Distributor>();

            if (lstDistributos.Count == 1)
                return true;

            return false;
        }

        public IList<Distributor> GetSelecteds(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status
                                                , GridState gridState, Lookup saleCondition, Lookup type, CatalogPage page, IList priceListIds, bool isActive)
        {
            ICriteria crit = GetDistributorsCriteria(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page, priceListIds, isActive);

            if (!gridState.MarkedAll)
                crit.Add(Expression.In("ID", gridState.Items));

            return crit.List<Distributor>();

        }

        #region Find Average Discounts

        public decimal FindMaxDiscountPerList(PriceList pl)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("PriceList", pl));
            crit.Add(Expression.Not(Expression.Eq("DistributorStatus", DistributorStatus.Disable)));
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Max("Discount")));
            object val = crit.UniqueResult();
            return val != null ? Convert.ToDecimal(val) : 0;
        }

        public decimal FindMaxDiscountPerPriceBase(PriceBase priceBase)
        {
            ICriteria crit = GetCriteria();
            ICriteria pricelist = crit.CreateCriteria("PriceList");
            ICriteria worklistitems = pricelist.CreateCriteria("Items");
            ICriteria priceattribute = worklistitems.CreateCriteria("PriceAttribute");

            priceattribute.Add(Expression.Eq("PriceBase", priceBase));
            crit.Add(Expression.Not(Expression.Eq("DistributorStatus", DistributorStatus.Disable)));
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Max("Discount")));
            object val = crit.UniqueResult();
            return val != null ? Convert.ToDecimal(val) : 0;
        }

        #endregion

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

        public IList<Contact> GetOrderedByStatus(int distributorId)
        {
            ICriteria crit = GetCriteria(typeof(Contact));

            crit.AddOrder(new Order("Status", false)).CreateCriteria("Distributor").Add(Expression.Eq("ID", distributorId));
            return crit.List<Contact>();
        }

        public Contact SaveContact(Contact c)
        {
            return NHibernateSession.Save(c) as Contact;

        }

        public void Refresh(object o)
        {
            NHibernateSession.Refresh(o);
        }

    }
}
