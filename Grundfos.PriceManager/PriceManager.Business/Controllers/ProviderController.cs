using System.Collections.Generic;
using GrundFos.ScalaConnector;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using NHibernate.SqlCommand;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class ProviderController : AbstractNHibernateDao<Provider, int>
    {
        public ProviderController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath)
        {
        }

        public List<IDIDView> GetProviderIds()
        {
            string hql = "select P.ID, PV.ID from Provider PV JOIN PV.Products P";
            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(IDIDView).GetConstructors()[1]));
            return q.List<IDIDView>() as List<IDIDView>;
        }

        public void ScalaUpdate()
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            IList<ScalaProvider> scalaProvList = scalaConnector.GetProvidersData();
            List<Provider> provList = GetAll() as List<Provider>;

            ScalaUpdate(provList, scalaProvList);
        }

        public void ScalaUpdate(List<int> provIDList, bool markedAll)
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            List<Provider> provList = GetProviderList(provIDList, markedAll);
            List<string> provCodeList = new List<string>();
            foreach (Provider provider in provList)
            {
                provCodeList.Add(provider.Code);
            }
            IList<ScalaProvider> scalaProvList = scalaConnector.GetProvidersData(provCodeList);

            ScalaUpdate(provList, scalaProvList);
        }

        private void ScalaUpdate(List<Provider> provList, IList<ScalaProvider> scalaProvList)
        {
            foreach (ScalaProvider provider in scalaProvList)
            {
                Provider prov = provList.Find(delegate(Provider record)
                                                  {
                                                      if (record.Code == provider.Code)
                                                      {
                                                          return true;
                                                      }
                                                      return false;
                                                  });

                if (prov == null)
                {
                    prov = new Provider();
                    prov.ProviderStatus = ProviderStatus.Incomplete;
                }
                prov.Code = provider.Code.Trim();
                prov.Address = provider.Address1.Trim() + " " + provider.Address2.Trim() + " " + provider.Address3.Trim() + " " +
                               provider.Address4.Trim();
                prov.Comment = provider.InternalNote1 + " " + provider.InternalNote2;
                prov.CompleteName = provider.CompleteName.Trim();
                prov.Contact = provider.Reference.Trim();
                prov.Fax = provider.Fax.Trim();
                prov.LastInvDate = provider.LastInvDate;
                prov.Name = provider.Name.Trim();
                prov.PurchaseYTD = provider.PurchYTD.Trim();
                prov.PurchPrevYear = provider.PurchPrevYear.Trim();
                prov.ScalaCountryCode = provider.CountryCode.Trim();
                prov.TaxCode = provider.TaxCode.Trim();
                prov.Telephone = provider.Telephone.Trim();

                Save(prov);
            }
            Utils.GetLogger().Info(string.Format("[[SCALA UPDATE]] {0} Providers Updated", scalaProvList.Count));
        }

        private List<Provider> GetProviderList(List<int> providerID, bool markedAll)
        {
            ICriteria crit = GetCriteria();
            if (markedAll)
                crit.Add(Restrictions.Not(Restrictions.In("ID", providerID)));
            else
                crit.Add(Restrictions.In("ID", providerID));

            return crit.List<Provider>() as List<Provider>;
        }

        public Provider GetByCode(string code)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Restrictions.Eq("Code", code));

            return crit.UniqueResult<Provider>();
        }

        public IList<Provider> GetProviderList(string description, Country country, ProviderStatus? status, Lookup saleCondition,
                                               GridState gridState, out int totalRecords)
        {
            ICriteria crit = GetProviderListCriteria(description, country, status, saleCondition);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<Provider>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = GetProviderListCriteria(description, country, status, saleCondition);

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

            return crit.List<Provider>();
        }

        private ICriteria GetProviderListCriteria(string description, Country country, ProviderStatus? status, Lookup saleCondition)
        {
            ICriteria crit = GetCriteria();

            if (!string.IsNullOrEmpty(description))
            {
                Disjunction d = new Disjunction();
                d.Add(Restrictions.InsensitiveLike("Description", description, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("Name", description, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("Code", description, MatchMode.Anywhere));
                crit.Add(d);
            }

            if (country != null)
            {
                ICriteria critCountry = crit.CreateCriteria("Country");
                critCountry.Add(Restrictions.Eq("ID", country.ID));
            }

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Provider);
            epv.KeyIdentifier = Config.ProviderInactiveStatus;

            if (PermissionManager.Check(epv) == false)
            {
                crit.Add(Expression.Eq("ProviderStatus", ProviderStatus.Active));
            }
            else
                if (status != null)
                    crit.Add(Restrictions.Eq("ProviderStatus", status));

            if (saleCondition != null)
                crit.Add(Expression.Eq("SaleConditions", saleCondition));

            return crit;
        }

        public void Updates(int providerId, string description, string city, int leadTime, string mail,
                            Lookup purchaseType, Country country, Lookup saleCondition, decimal discount)
        {
            Provider p = GetById(providerId);

            p.Description = description;
            p.City = city;
            p.LeadTime = leadTime;
            p.Email = mail;
            p.PurchaseType = purchaseType;
            p.Country = country;
            p.SaleConditions = saleCondition;
            p.Discount = discount;

            if (p.ProviderStatus == ProviderStatus.Incomplete)
                p.ProviderStatus = ProviderStatus.Active;

            Save(p);
            CommitChanges();
        }

        public IList<Provider> GetActives()
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ProviderStatus", ProviderStatus.Active));
            crit.AddOrder(new Order("Name", false));

            return crit.List<Provider>();
        }

        public bool ActivateDeactivate(int id)
        {
            Provider p = GetById(id);

            if (p.ProviderStatus == ProviderStatus.Active)
            { //chekear si tiene politicas
                if (!ControllerManager.PriceCalculation.HaveAnyProvider(p))
                {
                    p.ProviderStatus = ProviderStatus.Disable;
                    return true;
                }
                return false;
            }
            else
            { 
                p.ProviderStatus = ProviderStatus.Active;
                return true;
            }
        }

    }
}