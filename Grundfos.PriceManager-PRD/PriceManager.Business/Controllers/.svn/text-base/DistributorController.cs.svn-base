using System;
using System.Collections.Generic;
using GrundFos.ScalaConnector;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using System.Collections;
using NybbleMembership.Core;
using ProjectBase.Utils.Cache;

namespace PriceManager.Business
{
    public class DistributorController : AbstractNHibernateDao<Distributor, int>
    {
        public DistributorController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath)
        {
        }

        #region CRUD Methods

        public Distributor Create(string name, string description, string telephone, string email, string contact,
                                  PriceList pl, string code, Country c, decimal discount, Lookup paymentTerm, Incoterm? saleCondition, Lookup type, string alternativeEmail)
        {
            Distributor d = new Distributor();
            return Update(d, name, description, telephone, email, contact, pl, code, c, discount, paymentTerm, saleCondition, type, alternativeEmail);
        }

        public Distributor Update(int id, string description, string contact, PriceList pl, Country c, decimal discount,
                                  Lookup paymentTerm, Incoterm? saleCondition, Lookup type, string alternativeEmail)
        {
            Distributor d = GetById(id);
            return Update(d, d.Name, description, d.Telephone, d.Email, contact, pl, d.Code, c, discount, paymentTerm, saleCondition, type, alternativeEmail);
        }

        private Distributor Update(Distributor d, string name, string description, string telephone, string email,
                                   string contact, PriceList pl, string code, Country c, decimal discount,
                                   Lookup paymentTerm, Incoterm? saleCondition, Lookup type, string alternativeEmail)
        {
            bool updateDiscount = false;

            d.Name = name;
            d.Description = description;
            d.Telephone = telephone;
            d.Email = email;
            if (d.PriceList == null || pl == null || d.PriceList.ID != pl.ID)
                updateDiscount = true;
            if (pl != null)
                d.PriceList = ControllerManager.PriceList.GetById(pl.ID); // Because we use it in the AssignDiscount method
            else
                d.PriceList = pl;
                    
            d.Code = code;
            d.Country = c;
            d.Contact = contact;
            d.DistributorStatus = DistributorStatus.Active;
            d.PaymentTerm = paymentTerm;
            d.SaleConditions = saleCondition;

            if (d.Discount != discount)
                updateDiscount = true;

            d.Discount = discount;
            d.Type = type;
            d.AlternativeEmail = alternativeEmail;

            Save(d);
            CommitChanges();

            if (updateDiscount)
                ControllerManager.PriceList.CalculateDiscounts(d.PriceList);
            CacheManager.ExpireAll(typeof(Distributor));
            return d;
        }

        public void Disable(int distributorId)
        {
            Distributor d = GetById(distributorId);
            if (d == null)
                return;

            d.DistributorStatus = DistributorStatus.Disable;
            Save(d);

            CommitChanges();

            ControllerManager.PriceList.CalculateDiscounts(d.PriceList);
            CacheManager.ExpireAll(typeof(Distributor));
        }

        public void Remove(int distributorId)
        {
            Distributor d = GetById(distributorId);
            if (d == null)
                return;

            Delete(d);
            CommitChanges();

            ControllerManager.PriceList.CalculateDiscounts(d.PriceList);
            CacheManager.ExpireAll(typeof(Distributor));
        }

        #endregion

        public IList<Distributor> GetByPriceList(int id)
        {
            ICriteria crit = GetCriteria();

            crit.CreateCriteria("PriceList").Add(Expression.Eq("ID", id));
            crit.Add(Expression.Not(Expression.Eq("DistributorStatus", DistributorStatus.Disable)));
            crit.AddOrder(new Order("Name", false));

            return crit.List<Distributor>();
        }

        public IList<Distributor> GetActivesByPriceGroup(PriceGroup pG, int? maxResults)
        {
            //Cache Section
            string cacheKey = null;
            MembershipHelperUser mhu = MembershipHelper.GetUser();
            if (mhu != null)
                cacheKey = string.Format("DISTRIBUTORS_{0}_{1}_{2}_{3}", mhu.UserId, typeof(Distributor).ToString(), pG.ID, maxResults);

            object result = CacheManager.GetCached(typeof(Distributor),cacheKey);

            ICriteria crit = GetCriteria();
            if (result == null)
            {
                crit.Add(Expression.Not(Expression.Eq("DistributorStatus", DistributorStatus.Disable)));

                ICriteria critPriceList = crit.CreateCriteria("PriceList");

                ExecutePermissionValidator epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(PriceList);
                epv.KeyIdentifier = Config.SeePriceLists;

                if (PermissionManager.Check(epv) == false)
                {

                    IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
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
                
                result = crit.List<Distributor>();
                CacheManager.AddItem(typeof(Distributor), cacheKey, result);
            }
            return result as IList<Distributor>;
        }

        public IList<Distributor> GetDistributors(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, out int totalRecords, Incoterm? saleCondition, Lookup type, CatalogPage page)
        {
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            ICriteria crit = GetDistributorsCriteria(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<Distributor>();

            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = GetDistributorsCriteria(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page);

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

            return crit.List<Distributor>();
        }

        private ICriteria GetDistributorsCriteria(string name, Country country, PriceList priceList,
                                                  Lookup paymentTerm, DistributorStatus? status,
                                                  GridState gridState, Incoterm? saleCondition, Lookup type, CatalogPage page)
        {
            ICriteria crit = GetCriteria();

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Distributor);
            epv.KeyIdentifier = Config.SeeAllDistributors;

            if (PermissionManager.Check(epv) == false)
            {
                IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
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
            {
                epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(Distributor);
                epv.KeyIdentifier = Config.DistributorInactiveStatus;

                if (PermissionManager.Check(epv) == false)
                {
                    crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));
                }
            }
            
            if (saleCondition != null)
                crit.Add(Expression.Eq("SaleConditions", saleCondition));

            if(type != null)
                crit.Add(Expression.Eq("Type", type));

            if (page != null)
                crit.CreateCriteria("PriceList").CreateCriteria("CategoryPages").Add(Expression.Eq("ID", page.ID));

            return crit;
        }

        private List<Distributor> GetDistributorList(List<int> distributorID, bool markedAll)
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
            
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));
            crit.AddOrder(new Order("Name", false));

            return crit.List<Distributor>();
        }

        public IList<Distributor> GetActivesByPriceList()
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));
            
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            if (PermissionManager.Check(epv) == false)
            {
                IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                ICriteria critPriceList = crit.CreateCriteria("PriceList");
                critPriceList.Add(Expression.In("ID", intPriceListIds));
            }

            crit.AddOrder(new Order("Name", false));

            return crit.List<Distributor>();
        }


        public List<string> GetActives(string name, int count)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("DistributorStatus", DistributorStatus.Active));

            crit.Add(Expression.InsensitiveLike("Name", name, MatchMode.Anywhere));
            crit.AddOrder(new Order("Name", false));
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Property("Name"))
                                .Add(Projections.Property("Code")));

            if (count > 0)
                crit.SetMaxResults(count);

            crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(Distributor).GetConstructors()[2]));

            IList<Distributor> lst = crit.List<Distributor>();
            List<string> finallst = new List<string>();
            foreach(Distributor dis in lst)
                finallst.Add(dis.NameCode);

            return finallst;
        }

        public void ActivateDeactivate(int id)
        {
            Distributor d = GetById(id);

            if (d.DistributorStatus == DistributorStatus.Active)
                d.DistributorStatus = DistributorStatus.Disable;
            else
                d.DistributorStatus = DistributorStatus.Active;

            CacheManager.ExpireAll(typeof(Distributor));
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

        public void AddToPriceList(GridState gridState, IList<Filters.IFilter> filters, int priceListId)
        {
            if (!gridState.IsAnyItemMarked)
                throw new NoItemMarkedException("No se ha seleccionado ningun Canal de Venta.");

            MasterPriceSearchParameters msps = FilterHelper.GetSearchFilters(filters);

            IList<Distributor> lst = GetSelecteds(msps.Description, msps.Country, msps.PriceList, msps.PaymentTerm, msps.DistributorStatus, gridState, msps.Incoterm, msps.LookupType, msps.Categories[1] as CatalogPage);

            foreach (Distributor d in lst)
            {
                d.PriceList = new PriceList(priceListId);
                Save(d);
            }
            //NHibernateSession.Flush();
            //CommitChanges();
            
        }

        private IList<Distributor> GetSelecteds(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status
                                                , GridState gridState, Incoterm? saleCondition, Lookup type, CatalogPage page)
        {
            ICriteria crit = GetDistributorsCriteria(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page);

            if (!gridState.MarkedAll)
                crit.Add(Expression.In("ID", gridState.Items));

            return crit.List<Distributor>();

        }

        #region Scala Updates

        public void ScalaUpdate()
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            IList<ScalaDistributor> scalaDistList = scalaConnector.GetDistributorsData();
            List<Distributor> distList = GetAll() as List<Distributor>;

            ScalaUpdate(distList, scalaDistList);
        }

        public void ScalaUpdate(int id)
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            IList<ScalaDistributor> scalaDistList = scalaConnector.GetDistributorsData();
            List<Distributor> distList = new List<Distributor>();
            distList.Add(GetById(id));

            ScalaUpdate(distList, scalaDistList);
        }

        public void ScalaUpdate(List<int> lstDistributorIds, bool markedAll)
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            List<Distributor> distList = GetDistributorList(lstDistributorIds, markedAll);
            List<string> distCodeList = new List<string>();
            foreach (Distributor distributor in distList)
            {
                distCodeList.Add(distributor.Code);
            }
            IList<ScalaDistributor> scalaDistList = scalaConnector.GetDistributorsData(distCodeList);

            ScalaUpdate(distList, scalaDistList);
        }

        private void ScalaUpdate(List<Distributor> distList, IList<ScalaDistributor> scalaDistList)
        {
            foreach (ScalaDistributor distributor in scalaDistList)
            {
                Distributor dist = distList.Find(delegate(Distributor record)
                                                     {
                                                         if (record.Code == distributor.Code.Trim())
                                                         {
                                                             return true;
                                                         }
                                                         return false;
                                                     });

                if (dist == null)
                {
                    dist = new Distributor();
                    dist.DistributorStatus = DistributorStatus.Incomplete;
                }

                dist.Address = distributor.Address1.Trim() + " " + distributor.Address2.Trim() + " " + distributor.Address3.Trim() + " " +
                               distributor.Address4.Trim();
                dist.Comment = distributor.InternalNote.Trim();
                dist.Code = distributor.Code.Trim();
                dist.Contact = distributor.Reference1.Trim() + " " + distributor.Reference2.Trim() + " " + distributor.Reference3.Trim() +
                               " " + distributor.Reference4.Trim();
                dist.Fax = distributor.Fax.Trim();
                dist.Name = distributor.Name.Trim();
                dist.CompleteName = distributor.CompleteName.Trim();
                dist.ProfitYTD = distributor.ProfitYTD.Trim();
                dist.SalePrevYear = distributor.SalePrevYear.Trim();
                dist.SalesTaxCode = distributor.TaxCode.Trim();
                dist.SaleYTD = distributor.SaleYTD.Trim();
                dist.ScalaCountryCode = distributor.CountryCode.Trim();
                dist.ScalaPaymentTerm = distributor.PaymentTerm.Trim();
                dist.Telephone = distributor.Telephone.Trim();
                dist.ImpExpCustomer = distributor.ImpExpCustomer.Trim();

                Save(dist);
            }
            Utils.GetLogger().Info(string.Format("[[SCALA UPDATE]] {0} Distributors Updated", scalaDistList.Count));
        }

        #endregion

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

    }
}