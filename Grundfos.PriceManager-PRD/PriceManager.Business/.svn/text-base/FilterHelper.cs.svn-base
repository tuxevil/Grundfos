using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using NybbleMembership;
using PriceManager.Business.Filters;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using System.Globalization;

namespace PriceManager.Business
{
    public class FilterHelper
    {
        public static void RenderLabel(IFilter filter, HtmlTextWriter writer)
        {
            writer.RenderBeginTag("label");
            writer.Write(Resource.Business.GetString(filter.ID.ToString()));
            writer.RenderEndTag();
        }

        /// <summary>
        /// Determines if a filter correspond to the current type.
        /// </summary>
        /// <returns></returns>
        public static object FindObjectFromFilter(IList<IFilter> filters, Type className, string property)
        {
            if(filters != null)
                foreach (IFilter f in filters)
                    if (f.ClassName == className && f.FilterName == property)
                        return CreateObjectFromFilter(f);

            return null;
        }

        /// <summary>
        /// Find a filter with the className and property identified
        /// </summary>
        /// <returns></returns>
        public static IFilter FindFilter(ControlCollection filters, Type className, string property)
        {
            foreach (Control c in filters)
            {
                IFilter f = c as IFilter;
                if (f != null && f.ClassName == className && f.FilterName == property)
                    return f;
            }

            return null;
        }

        public static IFilter FindFilter(IList<IFilter> filters, Type className, string property)
        {
            foreach (IFilter f in filters)
            {
                if (f != null && f.ClassName == className && f.FilterName == property)
                    return f;
            }

            return null;
        }

        /// <summary>
        /// Create the final object for the Business Logic from a IFilter object.
        /// </summary>
        /// <param name="filter">IFilter object</param>
        /// <returns>The corresponding class with its value setted or the returing structure depending on the IsStructure setup on each filter.</returns>
        private static object CreateObjectFromFilter(IFilter filter)
        {
            if (!filter.HasValue)
                return null;

            Object ent = null;

            if (!filter.ClassName.IsAbstract)
            {
                if (filter.ClassName.IsEnum)
                {
                    if (filter is FixedFilter)
                        return filter.Values;

                    return Enum.Parse(filter.ClassName, filter.Values.ToString());
                }

                if (filter.ClassName.IsValueType || filter.ClassName == typeof(String)) 
                {
                    if (filter.ClassName == typeof(Guid))
                        return new Guid(filter.Values.ToString());

                    if (filter.ClassName == typeof(int))
                        return Convert.ToInt32(filter.Values.ToString());

                    return filter.Values.ToString();
                }
 
                if (filter is RangeFilter)
                    ent = filter.Values;
                else
                    ent = Activator.CreateInstance(filter.ClassName);
            }
            else
            {
                ObjectHandle oh;
                if (filter.ClassName is Type) 
                    oh = Activator.CreateInstance("PriceManager.Core", filter.Values.ToString()) as ObjectHandle;
                else
                    oh = Activator.CreateInstance("PriceManager.Core", "PriceManager.Core." + filter.Values.ToString()) as ObjectHandle;

                if (oh == null)
                    return null;

                if (filter.ClassName is Type)
                    ent = oh.Unwrap().GetType();
                else
                    ent = oh.Unwrap();
            }

            if (ent is Entity<int> || ent is Entity<Guid>)
            {
                string[] parts = filter.PropertyName.Split('.');

                object temporalPropertyValue = ent;
                object previousPropertyValue = null;
                PropertyInfo pi = null;

                foreach (string part in parts)
                {
                    previousPropertyValue = temporalPropertyValue;
                    temporalPropertyValue = FindProperty(temporalPropertyValue, part, out pi);
                }
                
                if (pi != null)
                {
                    if (filter.IsStructure)
                    {
                        if (pi.PropertyType == typeof(DateTime) && !(filter.Values is DateTime))
                        {  
                            return Convert.ToDateTime(filter.Values);
                        }

                        return filter.Values;
                    }

                    if (filter.Values != null)
                    {
                        if (pi.PropertyType == typeof(DateTime) && !(filter.Values is DateTime))
                            pi.SetValue(previousPropertyValue, Convert.ToDateTime(filter.Values), null);
                        else if(pi.PropertyType == typeof(int))
                            pi.SetValue(previousPropertyValue, Convert.ToInt32(filter.Values), null);
                        else if(pi.PropertyType == typeof(Guid))
                            pi.SetValue(previousPropertyValue, new Guid(filter.Values.ToString()), null);
                        else
                            pi.SetValue(previousPropertyValue, filter.Values, null);
                    }
                }
            }
            
            return ent;
        }

        /// <summary>
        /// Find a property recursevely.
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="name"></param>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static object FindProperty(object ent, string name, out PropertyInfo pi)
        {
            pi = ent.GetType().GetProperty(name);
            if (pi == null)
                throw new Exception("Property Not Found");
            return pi.GetValue(ent, null);
        }

        public static MasterPriceSearchParameters GetSearchFilters(IList<IFilter> filters)
        {
            MasterPriceSearchParameters mpsp = new MasterPriceSearchParameters();
            
            mpsp.PriceGroup = (PriceGroup)FindObjectFromFilter(filters, typeof(PriceGroup), "ID");
            mpsp.PriceBaseStatus = (PriceBaseStatus?)FindObjectFromFilter(filters, typeof(PriceBaseStatus), "ID");
            mpsp.ProductStatus = (ProductStatus?)FindObjectFromFilter(filters, typeof(ProductStatus), "ID");
            mpsp.Currency = FindObjectFromFilter(filters, typeof(Currency), "ID") as Currency;
            mpsp.Description = (FindObjectFromFilter(filters, typeof(Product), "Description") as String ?? string.Empty).Trim();
            mpsp.CtrRange = FindObjectFromFilter(filters, typeof(CtrRange), "ID") as CtrRange;
            mpsp.IndexPrice = FindObjectFromFilter(filters, typeof(IndexPrice), "ID") as IndexPrice;
            mpsp.Selection = FindObjectFromFilter(filters, typeof(Selection), "ID") as Selection;
            mpsp.Provider = FindObjectFromFilter(filters, typeof(Provider), "ID") as Provider;
            mpsp.Distributor = FindObjectFromFilter(filters, typeof(Distributor), "ID") as Distributor;
            mpsp.Incoterm = (Incoterm?)FindObjectFromFilter(filters, typeof(Incoterm), "ID");
            mpsp.PriceImport = (PriceImport)FindObjectFromFilter(filters, typeof(PriceImport), "ID");
            mpsp.PublishListStatus = (PublishListStatus?)FindObjectFromFilter(filters, typeof(PublishListStatus), "ID");
            mpsp.PriceList = (PriceList)FindObjectFromFilter(filters, typeof(PriceList), "ID");
            mpsp.Frequency = (Frequency?)FindObjectFromFilter(filters, typeof(Frequency), "ID");
            mpsp.WorkListItemStatus = (WorkListItemStatus?) FindObjectFromFilter(filters, typeof (WorkListItemStatus), "ID");
            mpsp.PublishList = (PublishList)FindObjectFromFilter(filters, typeof(PublishList), "ID");
            mpsp.PaymentTerm = (Lookup)FindObjectFromFilter(filters, typeof(Lookup), "Payment");
            mpsp.DistributorStatus = (DistributorStatus?)FindObjectFromFilter(filters, typeof(DistributorStatus), "ID");
            mpsp.Country = FindObjectFromFilter(filters, typeof(Country), "ID") as Country;
            mpsp.ProviderStatus = (ProviderStatus?)FindObjectFromFilter(filters, typeof(ProviderStatus), "ID");
            mpsp.CategoryType = (Type)FindObjectFromFilter(filters, typeof(Type), "FullName");
            //mpsp.CategoryBase = (CategoryBase)FindObjectFromFilter(filters, typeof(CategoryBase), "ID");
            mpsp.CategoryBase = (CategoryBase)FindObjectFromFilter(filters, typeof(CategoryBase), "ID");
            mpsp.LookupType = FindObjectFromFilter(filters, typeof (Lookup), "ID") as Lookup;
            mpsp.LookupTypeABM = (LookupType?)FindObjectFromFilter(filters, typeof(LookupType), "ID");
            mpsp.PriceCalculationPriority = (PriceCalculationPriority?)FindObjectFromFilter(filters, typeof(PriceCalculationPriority), "ID");
            mpsp.QuoteStatus = (QuoteStatus?)FindObjectFromFilter(filters, typeof(QuoteStatus), "ID");
            mpsp.ImportStatus = (ImportStatus?)FindObjectFromFilter(filters, typeof(ImportStatus), "ID");
            mpsp.CatalogPage = (CatalogPage)FindObjectFromFilter(filters, typeof(CatalogPage), "Parent");
            mpsp.CategoryPageStatus = (CategoryPageStatus?)FindObjectFromFilter(filters, typeof(CategoryPageStatus), "ID");

            mpsp.MembershipHelperUser = (Guid?)
                FindObjectFromFilter(filters, typeof(Guid), "UserId");

            mpsp.Categories[0] = FindObjectFromFilter(filters, typeof(Family), "ID") as Family; 
            mpsp.Categories[1] = FindObjectFromFilter(filters, typeof(CatalogPage), "ID") as CatalogPage;
            mpsp.Categories[2] = FindObjectFromFilter(filters, typeof(ProductType), "ID") as ProductType; 
            mpsp.Categories[3] = FindObjectFromFilter(filters, typeof(Application), "ID") as Application;
            mpsp.Categories[4] = FindObjectFromFilter(filters, typeof(Line), "ID") as Line;
            mpsp.Categories[5] = FindObjectFromFilter(filters, typeof(Area), "ID") as Area;

            Pair p = (Pair) FindObjectFromFilter(filters, typeof(Pair), "TimeStampCheck");
            if (p != null)
            {
                if (!string.IsNullOrEmpty(p.First.ToString()))
                    mpsp.SearchDate = Convert.ToDateTime(p.First);
                if (!string.IsNullOrEmpty(p.Second.ToString()))
                    mpsp.SearchDateTo = Convert.ToDateTime(p.Second);
            }

            return mpsp;
        }

        public static SearchParameters GetSerchParameters(IList<IFilter> filters)
        {
            MasterPriceSearchParameters msps = GetSearchFilters(filters);
            SearchParameters searchParameters = new SearchParameters();
            
            for (int i = 0; i < 6; i++)
                if (msps.Categories[i] != null)
                    searchParameters.Categories[i] = msps.Categories[i].ID;
            if(msps.Country != null)
                searchParameters.Country = msps.Country.ID;
            if (msps.CtrRange != null)
                searchParameters.CtrRange = msps.CtrRange.ID;
            if (msps.Currency != null)
                searchParameters.Currency = msps.Currency.ID;
            if (!string.IsNullOrEmpty(msps.Description))
                searchParameters.Description = msps.Description;
            if (msps.Distributor != null)
                searchParameters.Distributor = msps.Distributor.ID;
            if (msps.DistributorStatus != null)
                searchParameters.DistributorStatus = msps.DistributorStatus;
            if (msps.Family != null)
                searchParameters.Family = msps.Family.ID;
            if (msps.Incoterm != null)
                searchParameters.Incoterm = msps.Incoterm;
            if (msps.IndexPrice != null)
                searchParameters.IndexPrice = msps.IndexPrice.ID;
            if (msps.PaymentTerm != null)
                searchParameters.PaymentTerm = msps.PaymentTerm;
            if (msps.PriceBaseStatus != null)
                searchParameters.PriceBaseStatus = msps.PriceBaseStatus;
            if (msps.PriceGroup != null)
                searchParameters.PriceGroup = msps.PriceGroup.ID;
            if (msps.PriceImport != null)
                searchParameters.PriceImport = msps.PriceImport.ID;
            if (msps.PriceList != null)
                searchParameters.PriceList = msps.PriceList.ID;
            if (msps.Frequency != null)
                searchParameters.Frequency = msps.Frequency;
            if (msps.ProductStatus != null)
                searchParameters.ProductStatus = msps.ProductStatus;
            if (msps.Provider != null)
                searchParameters.Provider = msps.Provider.ID;
            if (msps.PublishList != null)
                searchParameters.PublishList = msps.PublishList.ID;
            if (msps.PublishListStatus != null)
                searchParameters.PublishListStatus = msps.PublishListStatus;
            if (msps.SearchDate != null)
                searchParameters.SearchDate = msps.SearchDate;
            if (msps.SearchDateTo != null)
                searchParameters.SearchDateTo = msps.SearchDateTo;
            if (msps.Selection != null)
                searchParameters.Selection = msps.Selection.ID;
            if (msps.WorkListItemStatus != null)
                searchParameters.WorkListItemStatus = msps.WorkListItemStatus;
            if (msps.CategoryBase != null)
                searchParameters.CategoryBase = msps.CategoryBase.ID;
            if (msps.CategoryType != null)
                searchParameters.CategoryType = msps.CategoryType.ToString();
            if (msps.LookupType != null)
                searchParameters.Type = msps.LookupType.ID;
            if (msps.LookupTypeABM != null)
                searchParameters.LookupType = msps.LookupTypeABM;
            if (msps.PriceCalculationPriority != null)
                searchParameters.PriceCalculationPriority = msps.PriceCalculationPriority;
            if (msps.QuoteStatus != null)
                searchParameters.QuoteStatus = msps.QuoteStatus;
            if (msps.ProviderStatus != null)
                searchParameters.ProviderStatus = msps.ProviderStatus;
            if (msps.MembershipHelperUser != null)
                searchParameters.MembershipHelperUser = msps.MembershipHelperUser;
            if (msps.ImportStatus != null)
                searchParameters.ImportStatus = msps.ImportStatus;
            if(msps.CatalogPage != null)
                searchParameters.CatalogPage = msps.CatalogPage.ID;
            if (msps.CategoryPageStatus != null)
                searchParameters.CategoryPageStatus = msps.CategoryPageStatus;

            return searchParameters;
        }

        public static IList<IFilter> GetFiltersState(ControlCollection filtersControls, SearchParameters searchParameters)
        {
            IList<IFilter> lastfilters = new List<IFilter>();

            IFilter f = FindFilter(filtersControls, typeof(Family), "ID");
            if (searchParameters.Categories[0] != 0)
            {
                f.Values = searchParameters.Categories[0];
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(CatalogPage), "ID");
            if (searchParameters.Categories[1] != 0)
            {
                f.Values = searchParameters.Categories[1];
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(ProductType), "ID");
            if (searchParameters.Categories[2] != 0)
            {
                f.Values = searchParameters.Categories[2];
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Application), "ID");
            if (searchParameters.Categories[3] != 0)
            {
                f.Values = searchParameters.Categories[3];
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Line), "ID");
            if (searchParameters.Categories[4] != 0)
            {
                f.Values = searchParameters.Categories[4];
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Area), "ID");
            if (searchParameters.Categories[5] != 0)
            {
                f.Values = searchParameters.Categories[5];
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Country), "ID");
            if (searchParameters.Country != 0)
            {
                f.Values = searchParameters.Country;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(CtrRange), "ID");
            if (searchParameters.CtrRange != 0)
            {
                f.Values = searchParameters.CtrRange;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Currency), "ID");
            if (searchParameters.Currency != 0)
            {
                f.Values = searchParameters.Currency;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Product), "Description");
            if (!string.IsNullOrEmpty(searchParameters.Description))
            {
                f.Values = searchParameters.Description;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Distributor), "ID");
            if (searchParameters.Distributor != 0)
            {
                f.Values = searchParameters.Distributor;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(DistributorStatus), "ID");
            if (searchParameters.DistributorStatus != null)
            {
                f.Values = searchParameters.DistributorStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Incoterm), "ID");
            if (searchParameters.Incoterm != null)
            {
                f.Values = searchParameters.Incoterm;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(IndexPrice), "ID");
            if (searchParameters.IndexPrice != 0)
            {
                f.Values = searchParameters.IndexPrice;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Lookup), "Payment");
            if (searchParameters.PaymentTerm != null)
            {
                f.Values = searchParameters.PaymentTerm.ID;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(PriceBaseStatus), "ID");
            if (searchParameters.PriceBaseStatus != null)
            {
                f.Values = searchParameters.PriceBaseStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(PriceGroup), "ID");
            if (searchParameters.PriceGroup != 0)
            {
                f.Values = searchParameters.PriceGroup;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(PriceImport), "ID");
            if (searchParameters.PriceImport != Guid.Empty)
            {
                f.Values = searchParameters.PriceImport;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(PriceList), "ID");
            if (searchParameters.PriceList != 0)
            {
                f.Values = searchParameters.PriceList;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Frequency), "ID");
            if (searchParameters.Frequency != null)
            {
                f.Values = searchParameters.Frequency;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(ProductStatus), "ID");
            if (searchParameters.ProductStatus != null)
            {
                f.Values = searchParameters.ProductStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Provider), "ID");
            if (searchParameters.Provider != 0)
            {
                f.Values = searchParameters.Provider;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(PublishList), "ID");
            if (searchParameters.PublishList != 0)
            {
                f.Values = searchParameters.PublishList.ToString();
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(PublishListStatus), "ID");
            if (searchParameters.PublishListStatus != null)
            {
                f.Values = searchParameters.PublishListStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Pair), "TimeStampCheck");
            if (f != null && (searchParameters.SearchDateTo != null || searchParameters.SearchDate != null))
            {
                Pair p = new Pair();
                if (searchParameters.SearchDate != null)
                    p.First = searchParameters.SearchDate.Value.ToShortDateString();
                if (searchParameters.SearchDateTo != null)
                    p.Second = searchParameters.SearchDateTo.Value.ToShortDateString();

                f.Values = p;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(Selection), "ID");
            if (searchParameters.Selection > 0)
            {
                f.Values = searchParameters.Selection;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls,typeof(WorkListItemStatus), "ID");
            if (searchParameters.WorkListItemStatus != null)
            {
                f.Values = searchParameters.WorkListItemStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(CategoryBase), "ID");
            if (searchParameters.CategoryBase != 0)
            {
                f.Values = searchParameters.CategoryBase;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Type), "FullName");
            if (!string.IsNullOrEmpty(searchParameters.CategoryType))
            {
                f.Values =Type.GetType(searchParameters.CategoryType);
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Lookup), "ID");
            if (searchParameters.Type > 0)
            {
                f.Values = searchParameters.Type;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(LookupType), "ID");
            if (searchParameters.LookupType != null)
            {
                f.Values = searchParameters.LookupType;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(PriceCalculationPriority), "ID");
            if (searchParameters.PriceCalculationPriority != null)
            {
                f.Values = searchParameters.PriceCalculationPriority;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(ProviderStatus), "ID");
            if (searchParameters.ProviderStatus != null)
            {
                f.Values = searchParameters.ProviderStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(QuoteStatus), "ID");
            if (searchParameters.QuoteStatus != null)
            {
                f.Values = searchParameters.QuoteStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(Guid), "UserId");
            if (searchParameters.MembershipHelperUser != null)
            {
                f.Values = searchParameters.MembershipHelperUser;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(ImportStatus), "ID");
            if (searchParameters.ImportStatus != null)
            {
                f.Values = searchParameters.ImportStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(CatalogPage), "Parent");
            if (searchParameters.CatalogPage != 0)
            {
                f.Values = searchParameters.CatalogPage;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            f = FindFilter(filtersControls, typeof(CategoryPageStatus), "ID");
            if (searchParameters.CategoryPageStatus != null)
            {
                f.Values = searchParameters.CategoryPageStatus;
                lastfilters.Add(f);
            }
            else if (f != null)
                f.Clear();

            return lastfilters;
        }
    }

    #region MasterPriceSearchParameters

    [Serializable]
    public class MasterPriceSearchParameters
    {
        private PriceBaseStatus? priceBaseStatus;

        public PriceBaseStatus? PriceBaseStatus
        {
            get { return priceBaseStatus; }
            set { priceBaseStatus = value; }
        }
        private ProductStatus? productStatus;

        public ProductStatus? ProductStatus
        {
            get { return productStatus; }
            set { productStatus = value; }
        }
        private Currency currency;

        public Currency Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        private Family family;

        public Family Family
        {
            get { return family; }
            set { family = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        private CtrRange ctrRange;

        public CtrRange CtrRange
        {
            get { return ctrRange; }
            set { ctrRange = value; }
        }
        private IndexPrice indexPrice;

        public IndexPrice IndexPrice
        {
            get { return indexPrice; }
            set { indexPrice = value; }
        }
        private Selection selection;

        public Selection Selection
        {
            get { return selection; }
            set { selection = value; }
        }
        private Provider provider;

        public Provider Provider
        {
            get { return provider; }
            set { provider = value; }
        }
        private DateTime? searchDate;

        public DateTime? SearchDate
        {
            get { return searchDate; }
            set { searchDate = value; }
        }

        private PriceGroup priceGroup;
        public PriceGroup PriceGroup
        {
            get { return priceGroup; }
            set { priceGroup = value; }
        }

        private Distributor distributor;
        public Distributor Distributor
        {
            get { return distributor; }
            set { distributor = value; }
        }

        private Incoterm? incoterm;
        public Incoterm? Incoterm
        {
            get { return incoterm; }
            set { incoterm = value; }
        }

        private CategoryBase[] categories = new CategoryBase[6];
        public CategoryBase[] Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        private PriceImport priceImport;
        public PriceImport PriceImport
        {
            get { return priceImport; }
            set { priceImport = value; }
        }

        private DateTime? searchDateTo;
        public DateTime? SearchDateTo
        {
            get { return searchDateTo; }
            set { searchDateTo = value; }
        }

        private PublishListStatus? publishListStatus;
        public PublishListStatus? PublishListStatus
        {
            get { return publishListStatus; }
            set { publishListStatus = value; }
        }

        private PriceList priceList;
        public PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        private Frequency? frequency;
        public Frequency? Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        private WorkListItemStatus? workListItemStatus;
        public WorkListItemStatus? WorkListItemStatus
        {
            get { return workListItemStatus; }
            set { workListItemStatus = value; }
        }

        private PublishList publishList;
        public PublishList PublishList
        {
            get { return publishList; }
            set { publishList = value; }
        }

        private Lookup paymentTerm;
        public Lookup PaymentTerm
        {
            get { return paymentTerm; }
            set { paymentTerm = value; }
        }

        private DistributorStatus? distributorStatus;
        public DistributorStatus? DistributorStatus
        {
            get { return distributorStatus; }
            set { distributorStatus = value; }
        }

        private Country country;
        public Country Country
        {
            get { return country; }
            set { country = value; }
        }

        private ProviderStatus? providerStatus;
        public ProviderStatus? ProviderStatus
        {
            get { return providerStatus; }
            set { providerStatus = value; }
        }

        private Type categoryType;
        public Type CategoryType
        {
            get { return categoryType; }
            set { categoryType = value; }
        }

        private CategoryBase categoryBase;
        public CategoryBase CategoryBase
        {
            get { return categoryBase; }
            set { categoryBase = value; }
        }


        private Lookup lookupType;
        public Lookup LookupType
        {
            get { return lookupType; }
            set { lookupType = value; }
        }

        private LookupType? lookupTypeABM;
        public LookupType? LookupTypeABM
        {
            get { return lookupTypeABM; }
            set { lookupTypeABM = value; }
        }

        private PriceCalculationPriority? priceCalculationPriority;
        public PriceCalculationPriority? PriceCalculationPriority
        {
            get { return priceCalculationPriority; }
            set { priceCalculationPriority = value; }
        }

        private QuoteStatus? quoteStatus;
        public QuoteStatus? QuoteStatus
        {
            get { return quoteStatus; }
            set { quoteStatus = value; }
        }

        private Guid? membershipHelperUser;
        public Guid? MembershipHelperUser
        {
            get { return membershipHelperUser; }
            set { membershipHelperUser = value; }
        }

        private ImportStatus? importStatus;
        public ImportStatus? ImportStatus
        {
            get { return importStatus; }
            set { importStatus = value; }
        }

        private CatalogPage catalogPage;
        public CatalogPage CatalogPage
        {
            get { return catalogPage; }
            set { catalogPage = value; }
        }

        private CategoryPageStatus? categoryPageStatus;
        public CategoryPageStatus? CategoryPageStatus
        {
            get { return categoryPageStatus; }
            set { categoryPageStatus = value; }
        }

    }

    #endregion
}
