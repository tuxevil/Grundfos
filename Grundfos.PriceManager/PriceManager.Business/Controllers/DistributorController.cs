using System;
using System.Collections.Generic;
using GrundFos.ScalaConnector;
using PriceManager.Common;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using ProjectBase.Data;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using System.Collections;
using NybbleMembership.Core;
using ProjectBase.Utils.Cache;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class DistributorController
    {
        private readonly IDistributorRepository repository;

        public DistributorController(IDistributorRepository repository)
        {
            this.repository = repository;
        }
        
        #region CRUD Methods

        public Distributor Create(string name, string description, string telephone, string email, string contact,
                                  PriceList pl, string code, Country c, decimal discount, Lookup paymentTerm, Lookup saleCondition, Lookup type, string alternativeEmail)
        {
            Distributor d = new Distributor();
            return Update(d, name, description, telephone, email, contact, pl, code, c, discount, paymentTerm, saleCondition, type, alternativeEmail);
        }

        public Distributor Update(int id, string description, string contact, PriceList pl, Country c, decimal discount,
                                  Lookup paymentTerm, Lookup saleCondition, Lookup type, string alternativeEmail)
        {
            Distributor d = repository.GetById(id);
            return Update(d, d.Name, description, d.Telephone, d.Email, contact, pl, d.Code, c, discount, paymentTerm, saleCondition, type, alternativeEmail);
        }

        private Distributor Update(Distributor d, string name, string description, string telephone, string email,
                                   string contact, PriceList pl, string code, Country c, decimal discount,
                                   Lookup paymentTerm, Lookup saleCondition, Lookup type, string alternativeEmail)
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

            repository.Save(d);
            repository.CommitChange();

            if (updateDiscount)
                ControllerManager.PriceList.CalculateDiscounts(d.PriceList);
            CacheManager.ExpireAll(typeof(Distributor));
            return d;
        }

        public void Disable(int distributorId)
        {
            Distributor d = repository.GetById(distributorId);
            if (d == null)
                return;

            d.DistributorStatus = DistributorStatus.Disable;
            repository.Save(d);

            repository.CommitChange();

            ControllerManager.PriceList.CalculateDiscounts(d.PriceList);
            CacheManager.ExpireAll(typeof(Distributor));
        }

        public void Remove(int distributorId)
        {
            Distributor d = repository.GetById(distributorId);
            if (d == null)
                return;

            repository.Delete(d);
            repository.CommitChange();

            ControllerManager.PriceList.CalculateDiscounts(d.PriceList);
            CacheManager.ExpireAll(typeof(Distributor));
        }

        #endregion

        public void ActivateDeactivate(int id)
        {
            Distributor d = repository.GetById(id);

            if (d.DistributorStatus == DistributorStatus.Active)
                d.DistributorStatus = DistributorStatus.Disable;
            else
                d.DistributorStatus = DistributorStatus.Active;

            CacheManager.ExpireAll(typeof(Distributor));
        }

        public void AddToPriceList(GridState gridState, IList<Filters.IFilter> filters, int priceListId)
        {
            if (!gridState.IsAnyItemMarked)
                throw new NoItemMarkedException("No se ha seleccionado ningun Canal de Venta.");

            MasterPriceSearchParameters msps = FilterHelper.GetSearchFilters(filters);

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            bool CanSeeAll = PermissionManager.Check(epv);
            IList priceListIds = null;
            if (!CanSeeAll)
                priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);

            epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Distributor);
            epv.KeyIdentifier = Config.DistributorInactiveStatus;
            bool isActive = PermissionManager.Check(epv);

            IList<Distributor> lst = repository.GetSelecteds(msps.Description, msps.Country, msps.PriceList, msps.PaymentTerm, msps.DistributorStatus, gridState, msps.Incoterm, msps.LookupType, msps.Categories[1] as CatalogPage, priceListIds, isActive);

            foreach (Distributor d in lst)
            {
                d.PriceList = new PriceList(priceListId);
                repository.Save(d);
            }
        }
        
        #region Scala Updates

        public void ScalaUpdate()
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            IList<ScalaDistributor> scalaDistList = scalaConnector.GetDistributorsData();
            List<Distributor> distList = repository.GetAll() as List<Distributor>;

            ScalaUpdate(distList, scalaDistList);
        }

        public void ScalaUpdate(int id)
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            IList<ScalaDistributor> scalaDistList = scalaConnector.GetDistributorsData();
            List<Distributor> distList = new List<Distributor>();
            distList.Add(repository.GetById(id));

            ScalaUpdate(distList, scalaDistList);
        }

        public void ScalaUpdate(List<int> lstDistributorIds, bool markedAll)
        {
            ScalaConnector scalaConnector = new ScalaConnector(Config.ScalaFactoryConfigPath);
            List<Distributor> distList = repository.GetDistributorList(lstDistributorIds, markedAll);
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

                repository.Save(dist);
            }
            Utils.GetLogger().Info(string.Format("[[SCALA UPDATE]] {0} Distributors Updated", scalaDistList.Count));
        }

        #endregion

        #region Repository Methods

        public IList<Distributor> GetSelecteds(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, Lookup saleCondition, Lookup type, CatalogPage page)
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            bool CanSeeAll = PermissionManager.Check(epv);
            IList priceListIds = null;
            if (!CanSeeAll)
                priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);

            epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Distributor);
            epv.KeyIdentifier = Config.DistributorInactiveStatus;
            bool isActive = PermissionManager.Check(epv);
               
            return repository.GetSelecteds(name, country, priceList, paymentTerm, status, gridState, saleCondition, type, page,priceListIds, isActive);
        }
        public List<Distributor> GetDistributorList(List<int> distributorID, bool markedAll)
        {
            return repository.GetDistributorList(distributorID, markedAll);
        }
        public Distributor GetByName(string name)
        {
            return repository.GetByName(name);
        }
        public Distributor GetByCode(string code)
        {
            return repository.GetByCode(code);
        }
        public IList<Distributor> GetActives()
        {
            return repository.GetActives();
        }
        public List<string> GetActives(string name, int count)
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            bool CanSeeAll = PermissionManager.Check(epv);
            IList priceListIds = null;
            if (!CanSeeAll)
                priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);

            return repository.GetActives(name, count, priceListIds);
        }
        public decimal FindMaxDiscountPerList(PriceList pl)
        {
            return repository.FindMaxDiscountPerList(pl);
        }
        public decimal FindMaxDiscountPerPriceBase(PriceBase priceBase)
        {
            return repository.FindMaxDiscountPerPriceBase(priceBase);
        }
        public IList<Distributor> GetActivesByPriceList()
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            IList priceListIds = null;
            if (PermissionManager.Check(epv) == false)
                 priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
           
            return repository.GetActivesByPriceList(priceListIds);
        }
        public IList<Distributor> GetActivesByPriceGroup(PriceGroup pG, int? maxResults)
        {
            //Cache Section
            string cacheKey = null;
            MembershipHelperUser mhu = MembershipHelper.GetUser();
            if (mhu != null)
                cacheKey = string.Format("DISTRIBUTORS_{0}_{1}_{2}_{3}", mhu.UserId, typeof(Distributor).ToString(), pG.ID, maxResults);

            object result = CacheManager.GetCached(typeof(Distributor), cacheKey);
            
            if (result == null)
            {
                ExecutePermissionValidator epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(PriceList);
                epv.KeyIdentifier = Config.SeePriceLists;

                bool CanSeeAll = PermissionManager.Check(epv);
                IList priceListIds = null;
                if(!CanSeeAll)
                    priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
               
                IList<Distributor> d = repository.GetActivesByPriceGroup(pG, maxResults, priceListIds);
                
                CacheManager.AddItem(typeof(Distributor), cacheKey, d);
                result = d;
            }
            return result as IList<Distributor>;
        }

        public Distributor GetById(int id)
        {
            return repository.GetById(id);
        }

        public IList<Distributor> GetDistributors()
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            bool CanSeeAll = PermissionManager.Check(epv);
            IList priceListIds = null;
            if (!CanSeeAll)
                priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);

            epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Distributor);
            epv.KeyIdentifier = Config.DistributorInactiveStatus;
            bool isActive = PermissionManager.Check(epv);
            int totalRecords;
            
            return repository.GetDistributors(string.Empty, null, null, null, DistributorStatus.Active, new GridState(new List<int>(), 0, 0, "Name", true, false, DateTime.Now, null), out totalRecords, null, null, null, priceListIds, isActive);
        }

        public IList<Distributor> GetDistributors(string name, Country country, PriceList priceList, Lookup paymentTerm, DistributorStatus? status, GridState gridState, out int totalRecords, Lookup saleCondition, Lookup type, CatalogPage page)
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            bool CanSeeAll = PermissionManager.Check(epv);
            IList priceListIds = null;
            if (!CanSeeAll)
                priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);

            epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Distributor);
            epv.KeyIdentifier = Config.DistributorInactiveStatus;
            bool isActive = PermissionManager.Check(epv);
               
            return repository.GetDistributors(name, country, priceList, paymentTerm, status, gridState, out totalRecords, saleCondition, type, page, priceListIds, isActive);
        }

        public IList<Distributor> GetByPriceList(int id)
        {
            return repository.GetByPriceList(id);
        }

        public bool Check(string name)
        {
            return repository.Check(name);
        }

        #endregion

        #region Contact Methods

        public IList<Contact> GetOrderedByStatus(int distributorId)
        {
           return repository.GetOrderedByStatus(distributorId);
        }

        private Contact ActivateContact(Contact c)
        {
            if (c != null)
                c.Activate();

            return c;
        }

        private Contact DeactivateContact(Contact c)
        {
            if (c != null)
                c.Deactivate();

            return c;
        }

        public Contact ChangeStatus(int distributorId, int contactId)
        {
            Contact c = FindContactInDistributor(distributorId, contactId);

            if (c.Status == ContactStatus.Active)
            {
              c = DeactivateContact(c);
            }
            else
            {
              c =  ActivateContact(c);
            }
            return c;
        }

        public Contact FindContactInDistributor(int distributorId, int contactId)
        {
            Distributor d = GetById(distributorId);

            List<Contact> lst = new List<Contact>(d.Contacts);
            Contact c = lst.Find(delegate(Contact record)
                                   {
                                       if (record.ID == contactId)
                                           return true;

                                       return false;
                                   });
            return c;
        }

        public Contact AddContact(int distributorId, string name, string lastName, string email)
        {
            Distributor d = GetById(distributorId);

            Contact c = null;
            if (d != null)
            {
                c = d.AddContact(name, lastName, email);
                repository.Save(d);
            }
            return c;
        }

        public Contact EditContact(int distributorId, int contactId, string name, string lastName, string email)
        {
            Contact c = FindContactInDistributor(distributorId, contactId);

            c.Name = name;
            c.LastName = lastName;

            if (c.Email != email)
            {
                Distributor d = GetById(distributorId);
                List<Contact> contacts = new List<Contact>(d.Contacts);
                if (!contacts.Exists(delegate(Contact record)
                                                          {
                                                              if (record.Email == email)
                                                                  return true;
                                                              return false;
                                                          }))
                {

                    c.Email = email;
                }
                else
                {
                    throw new DistributorContactAlreadyExistsException("Este mail ya existe para este Canal de Ventas");
                }

            }
            repository.SaveContact(c);
            repository.CommitChange();

            return c;
        }
        #endregion
    }
}