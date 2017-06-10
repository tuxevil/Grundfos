using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Mapping;
using PriceManager.Core;
using ProjectBase.Data;
using IFilter = PriceManager.Business.Filters.IFilter;
using NybbleMembership;
using System.Diagnostics;

namespace PriceManager.Business
{
    public class PriceBaseController : AbstractNHibernateDao<PriceBase, int>
    {
        public PriceBaseController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        #region PriceBase
        public PriceBase Create(PriceImport pi, string codGrunfos, string codProvider, string model, string description, Provider provider, Frequency? frequency, decimal? tP, Currency tPCurrency, decimal? gRP, Currency gRPCurrency, decimal? pL, Currency pLCurrency, ICollection<CategoryBase> categories, Product prod, Currency baseCurrency, List<CurrencyRate> currencyRates)
        {
            PriceBase bp = new PriceBase();
            bp.Product = prod;
            bp.PriceImports = new List<PriceImport>();
            return UpdateInformation(bp, pi, codGrunfos, codProvider, model, description, provider, frequency, tP, tPCurrency, gRP, gRPCurrency, pL, pLCurrency, categories, baseCurrency, currencyRates);
        }

        public PriceBase Modify(PriceImport pi, string codGrunfos, string codProvider, string model, string description, Provider provider, Frequency? frequency, decimal? tP, Currency tPCurrency, decimal? gRP, Currency gRPCurrency, decimal? pL, Currency pLCurrency, ICollection<CategoryBase> categories, PriceBase bp, Currency baseCurrency, HistoryStatus historyStatus, List<CurrencyRate> currencyRates)
        {
            return UpdateInformation(bp, pi, codGrunfos, codProvider, model, description, provider, frequency, tP, tPCurrency, gRP, gRPCurrency, pL, pLCurrency, categories, baseCurrency, currencyRates);
        }

        private PriceBase UpdateInformation(PriceBase bp, PriceImport pi, string codGrunfos, string codProvider, string model, string description, Provider provider, Frequency? frequency, decimal? tP, Currency tPCurrency, decimal? gRP, Currency gRPCurrency, decimal? pL, Currency pLCurrency, ICollection<CategoryBase> categories, Currency baseCurrency, List<CurrencyRate> currencyRates)
        {
            bp.Status = PriceBaseStatus.NotVerified;
            if (bp.PriceList > 0 || pL > 0)
                bp.Status = PriceBaseStatus.Verified;

            //Propiedades obligatorias
            bp.Provider = provider;
            bp.PriceImports.Add(pi);

            if (pLCurrency != null)
                bp.CurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == pLCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            else
                bp.CurrencyRate = currencyRates[0];
            if (tPCurrency != null)
                bp.PricePurchaseCurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == tPCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            else
                bp.PricePurchaseCurrencyRate = currencyRates[0];
            if (gRPCurrency != null)
                bp.PriceSuggestCurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == gRPCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            else
                bp.PriceSuggestCurrencyRate = currencyRates[0];

            //Propiedades SEMI obligatorias
            if (!string.IsNullOrEmpty(codProvider))
                bp.ProviderCode = codProvider;
            if (!string.IsNullOrEmpty(codGrunfos))
                bp.Product.Code = codGrunfos;

            //Propiedades NO obligatorias
            if (tP != null && tP > 0)
                bp.PricePurchase = Convert.ToDecimal(tP);
            if (tPCurrency != null)
                bp.PricePurchaseCurrency = tPCurrency;
            else if (bp.PricePurchaseCurrency == null)
                bp.PricePurchaseCurrency = baseCurrency;
            if (gRP != null && gRP > 0)
                bp.PriceSuggest = Convert.ToDecimal(gRP);
            if (gRPCurrency != null)
                bp.PriceSuggestCurrency = gRPCurrency;
            else if (bp.PriceSuggestCurrency == null)
                bp.PriceSuggestCurrency = baseCurrency;
            if (pL != null && pL > 0)
                bp.PriceList = Convert.ToDecimal(pL);
            if (pLCurrency != null)
                bp.PriceListCurrency = pLCurrency;
            else if (bp.PriceListCurrency == null)
                bp.PriceListCurrency = baseCurrency;
            if (!string.IsNullOrEmpty(model))
                bp.Product.Model = model;
            if (!string.IsNullOrEmpty(description))
                bp.Product.Description = description;
            
            if (frequency != null)
                bp.Product.Frequency = frequency;
            else if (bp.Product.Frequency == null)
                bp.Product.Frequency = Frequency.All;

            if(pLCurrency != null)
                bp.CurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == pLCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            else
                bp.CurrencyRate = currencyRates[0];
            
            if (tPCurrency != null)
                bp.PricePurchaseCurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == tPCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            else
                bp.PricePurchaseCurrencyRate = currencyRates[0];
            
            if (gRPCurrency != null)
                bp.PriceSuggestCurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == gRPCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            else
                bp.PriceSuggestCurrencyRate = currencyRates[0];

            return bp;
        }
        #endregion

        #region New Search

        public IList<ProductListView> GetProductList(PublishList publishList)
        {
            int record;
            return GetProductList(null, null, null, null, null, null, out record, null, null, null, new GridState(new List<int>(), 0, 0, "", true, false, DateTime.Today, null), null, null, false, null, null, null, null, null, publishList, null);
        }

        public IList<ProductListView> GetProductList(string description, CategoryBase[] category, CtrRange cTR, Selection list,
            Frequency? frequency, Currency currency, out int totalRecords, PriceGroup priceGroup, Provider provider, DateTime? date, GridState gridState, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, bool forExport, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            return GetProductList(description, category, cTR, list, frequency, currency, out totalRecords, priceGroup, provider, date, gridState, priceBaseStatus, productStatus, forExport, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, false, false);
        }

        public IList<ProductListView> GetProductList(string description, CategoryBase[] category, CtrRange cTR, Selection list,
            Frequency? frequency, Currency currency, out int totalRecords, PriceGroup priceGroup, Provider provider, DateTime? date, GridState gridState, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, bool forExport, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, bool onlySelectedItems, bool priceBaseStatusQuotes)
        {
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            string sortField = gridState.SortField;
            string sortOrder = gridState.SortAscending ? "ASC" : "DESC";
            bool markedAll = gridState.MarkedAll;
            Currency toCurrency = null;
            //if(gridState.ShowInCurrency != null)
            //    toCurrency = ControllerManager.Currency.GetById((int)gridState.ShowInCurrency);
            List<int> selecteditems;
            if (forExport)
            {
                selecteditems = gridState.Items;
                pageSize = 0;
                pageNumber = 0;
            }
            else if(onlySelectedItems)
                selecteditems = gridState.Items;
            else
                selecteditems = new List<int>();

            Trace.Write("Begin Count");
            // Get the number of records for the current filters
            totalRecords = Convert.ToInt32(GetProductListQuery("COUNT(distinct PI.ID)", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, priceBaseStatusQuotes).UniqueResult());
            Trace.Write("End Count");

            if (totalRecords == 0)
                return new List<ProductListView>();

            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            // Get the current page and data for the current filters
            string query;
            query = "distinct ";
            if (priceGroup != null)
                query += "PA.ID,";
            else if (priceList != null)
                query += "WLI.ID, WLI.WorkListItemStatus, PI.PCR,";
            else if (publishList != null)
                query += "PLI.ID,";
            else
                query += "PB.ID,";

            query += " PB.ID, P.ID, P.Code, PB.ProviderCode, P.Model, P.Description, P.Frequency, PI.PricePurchase, PI.PriceSuggest, PI.PriceSell, PI.Price, PI.CTM, PI.CTR, PI.Index, PV.Name, PB.Status, PI.LastPrice, PI.Discount, PV.ID, PI.PLCurrencyId, PI.PPCurrencyId, PI.PSCurrencyId, PI.LastPriceCurrencyId, P.ModelAlternative, P.DescriptionAlternative";

            IQuery q = GetProductListQuery(query, description, category, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, priceBaseStatusQuotes);

            if (priceList != null)
                q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductListView).GetConstructors()[2]));
            else
                q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductListView).GetConstructors()[1]));

            Trace.Write("Begin List");
            return q.List<ProductListView>() as List<ProductListView>;
            Trace.Write("End List");
        }

        public IList<PriceBase> Get(PriceBaseStatus priceBaseStatus)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Status", priceBaseStatus));

            return crit.List<PriceBase>();
        }

        public IList<PriceBase> Get(Provider provider, CategoryBase category, PriceBaseStatus priceBaseStatus)
        {
            ICriteria crit = GetCriteria();
            if (provider != null)
                crit.Add(Expression.Eq("Provider", provider));
            if (category != null)
            {
                ICriteria prod = crit.CreateCriteria("Product");
                ICriteria cats = prod.CreateCriteria("Families");
                cats.Add(Expression.Eq("ID", category.ID));
            }
            crit.Add(Expression.Eq("Status", priceBaseStatus));

            return crit.List<PriceBase>();
        }

        public IList<PriceBase> Get(PriceImport priceImport, PriceBaseStatus priceBaseStatus)
        {
            ICriteria crit = GetCriteria();
            
            if (priceImport != null)
            {
                ICriteria pi = crit.CreateCriteria("PriceImports");
                pi.Add(Expression.Eq("ID", priceImport.ID));
            }
            crit.Add(Expression.Eq("Status", priceBaseStatus));

            return crit.List<PriceBase>();
        }

        public PriceBase GetPriceBase(Product product, PriceBaseStatus status)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Product", product));
            crit.Add(Expression.Eq("Status", status));

            return crit.UniqueResult<PriceBase>();
        }

        public PriceBase GetPriceBase(Product product)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Product", product));
            crit.SetMaxResults(1);

            return crit.UniqueResult<PriceBase>();
        }

        public PriceBase GetPriceBase(Product product, Provider provider)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Product", product));
            crit.Add(Expression.Eq("Provider", provider));

            return crit.UniqueResult<PriceBase>();
        }

        #endregion

        #region Common IQuery Creation Methods

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, false, null, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, Selection selection, Frequency? frequency, DateTime? date, ProductStatus? status, Provider provider, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems)
        {
            return GetProductListQuery(fields, description, category, null, selection, frequency, null, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, false, null, null, null, provider, date, null, status, null, null, null, null, null, null, null);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, bool priceBaseStatusQuotes)
        {
            return GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, false, null, null, null, false, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, priceBaseStatusQuotes, null, null);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, false, null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, PriceList newPriceList)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, newPriceList);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, PriceGroup newPriceGroup)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, newPriceGroup);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, false, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null, false, null, null);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, PriceList newPriceList)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, false, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null, false, null, newPriceList);
        }

        public IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, PriceGroup newPriceGroup)
        {
            return
                GetProductListQuery(fields, description, category, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, false, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null, false, newPriceGroup, null);
        }

        public string GetProductListHQL(string fields, string description, CategoryBase[] categoryArray, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, bool createSQL, bool can, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, bool isProduct)
        {
            return GetProductListHQL(fields, description, categoryArray, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, createSQL, can, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, false, null, null, isProduct);
        }

        public string GetProductListHQL(string fields, string description, CategoryBase[] categoryArray, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, bool createSQL, bool can, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            return GetProductListHQL(fields, description, categoryArray, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, createSQL, can, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, false, null, null, false);
        }

        public string GetProductListHQL(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, bool isProduct)
        {
            return GetProductListHQL(fields, description, category, cTR, list, frequency, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, null, true, false, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null, isProduct);
        }

        public string GetProductListHQL(string fields, string description, CategoryBase[] categoryArray, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, bool createSQL, bool can, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, bool priceBaseStatusQuotes, PriceGroup newPriceGroup, PriceList newPriceList, bool isProduct)
        {
            bool isCount = fields.ToLower().Contains("count(");

            List<CategoryBase>[] lstcategories = new List<CategoryBase>[6];
            
            bool categoriesIn = true;
            bool therearecategories = false;
            int cattypecount = 0;
            if (categoryArray != null)
            {
                foreach (CategoryBase categoryBase in categoryArray)
                {
                    if (categoryBase != null)
                        therearecategories = true;
                    else
                        continue;

                    List<CategoryBase> categories = new List<CategoryBase>();
                    if (categoryBase.ID == -1)
                    {
                        categoriesIn = false;
                        categories.Add(new CatalogPage());
                        continue;
                    }

                    List<CategoryBase> tempCB = new CategoryBaseController(this.SessionFactoryConfigPath).FindChildrensOrSelf(categoryBase);
                    
                    // Find the type of the Category
                    if (categoryBase is CatalogPage)
                        cattypecount = 0;
                    if (categoryBase is Family)
                        cattypecount = 1;
                    if (categoryBase is Application)
                        cattypecount = 2;
                    if (categoryBase is ProductType)
                        cattypecount = 3;
                    if (categoryBase is Line)
                        cattypecount = 4;
                    if (categoryBase is Area)
                        cattypecount = 5;
                    
                    if (lstcategories[cattypecount] != null)
                        lstcategories[cattypecount].AddRange(tempCB);
                    else
                        lstcategories[cattypecount] = tempCB;
                }
            }


            string hql = "SELECT " + fields;

            if (!createSQL)
            {
                if (priceGroup != null)
                {
                    hql += " FROM ProductInfoByGroup PI";
                    hql += " JOIN PI.PriceAttribute PA";
                    hql += " JOIN PA.PriceGroup PG";
                    hql += " JOIN PA.PriceBase PB";
                    if(priceList != null)
                        hql += " JOIN PG.PriceLists PL";
                }
                else if (priceList != null)
                {
                    hql += " FROM ProductInfoByPriceList PI";
                    hql += " JOIN PI.PriceList PL";
                    hql += " JOIN PI.WorkListItem WLI";
                    hql += " JOIN WLI.PriceAttribute PA";
                    hql += " JOIN PA.PriceGroup PG";
                    hql += " JOIN PA.PriceBase PB";
                    if (distributor != null)
                        hql += " JOIN PL.Distributors D";
                }
                else if (publishList != null)
                {
                    if (distributor != null)
                        hql += " FROM ProductInfoByDistributor PI";
                    else
                        hql += " FROM ProductInfoByPublishList PI";
                    hql += " JOIN PI.PublishItem PLI";
                    hql += " JOIN PLI.PublishList PbL";
                    hql += " JOIN PbL.PriceList PL";
                    hql += " JOIN PLI.PriceBase PB";
                    hql += " LEFT JOIN PL.Distributors D";
                }
                else
                {
                    hql += " FROM ProductInfo PI";
                    hql += " JOIN PI.PriceBase PB";
                }

                hql += " JOIN PB.Provider PV";
                hql += " JOIN PB.Product P";
                if(priceImport != null)
                    hql += " LEFT JOIN PB.PriceImports PIM";

                if (list != null)
                    hql += " JOIN P.Selections S";

                if (therearecategories)
                    if(categoriesIn)
                    {
                        foreach (List<CategoryBase> categories in lstcategories)
                        {
                            if (categories == null)
                                continue;
                            if (categories[0].GetType() == typeof(CatalogPage))
                                hql += " JOIN P.Families Pag";
                            else if (categories[0].GetType() == typeof(Family))
                                hql += " JOIN P.Families Fam";
                            else if (categories[0].GetType() == typeof(Application))
                                hql += " JOIN P.Families App";
                            else if (categories[0].GetType() == typeof(ProductType))
                                hql += " JOIN P.Families PrT";
                            else if (categories[0].GetType() == typeof(Line))
                                hql += " JOIN P.Families Lin";
                            else if (categories[0].GetType() == typeof(Area))
                                hql += " JOIN P.Families Are";
                        }
                    }
                    else
                    {
                        hql += " LEFT JOIN P.Families Cat";
                    }

                if (currency != null)
                    if (priceGroup != null)
                    {
                        hql += " LEFT JOIN PA.PriceCurrency PC";
                    }
                    else
                    {
                        hql += " LEFT JOIN PB.PriceListCurrency PC";
                    }
            }

            #region SQL Script
            else
            {
                if (priceGroup != null)
                {
                    hql += " FROM viewProductInfoByGroup PI";
                    hql += " INNER JOIN PriceAttribute PA ON PI.Id = PA.Id";
                    //hql += " INNER JOIN PriceGroup PG ON PA.PriceGroupId = PG.Id";
                    hql += " INNER JOIN PriceBase PB ON PA.PriceBaseId = PB.Id";
                }
                else if (priceList != null)
                {
                    hql += " FROM viewProductInfoByPriceList PI";
                    hql += " INNER JOIN WorkListItem WLI ON PI.Id = WLI.Id";
                    hql += " INNER JOIN PriceList PL ON WLI.PriceListId = PL.Id";
                    hql += " INNER JOIN PriceAttribute PA ON WLI.PriceAttributeId = PA.Id";
                    hql += " INNER JOIN PriceGroup PG ON PA.PriceGroupId = PG.Id";
                    hql += " INNER JOIN PriceBase PB ON PA.PriceBaseId = PB.Id";
                }
                else if (publishList != null)
                {
                    if (distributor != null)
                        hql += " FROM viewProductInfoByDistributor PI";
                    else
                        hql += " FROM viewProductInfoByPublishList PI";
                        
                    hql += " INNER JOIN PublishItem PLI ON PLI.Id = PI.Id";
                    hql += " INNER JOIN PublishList PbL ON PLI.PublishListId = PbL.Id";
                    hql += " INNER JOIN PriceList PL ON PbL.PriceListId = PL.Id";
                    hql += " INNER JOIN PriceBase PB ON PB.Id = PLI.PriceBaseId";
                    hql += " INNER JOIN Distributor D ON D.Id = PbL.DistributorId";
                }
                else
                {
                    hql += " FROM viewProductInfo PI";
                    hql += " INNER JOIN PriceBase PB ON PI.Id = PB.Id";
                }

                hql += " INNER JOIN Provider PV ON PB.ProviderId = PV.Id";
                hql += " INNER JOIN Product P ON P.Id = PB.ProductId";
                if(priceImport != null)
                {
                    hql += " LEFT JOIN PriceBaseByPriceImport PbBPM ON PbBPM.PriceBaseId = PB.Id";
                    hql += " LEFT JOIN PriceImport PIM ON PIM.Id = PbBPM.PriceImportId";
                }

                if (list != null)
                    hql += " INNER JOIN ProductBySelection PBS ON PBS.ProductId = P.Id INNER JOIN Selections S ON PBS.SelectionId = S.Id";

                if (therearecategories)
                    if(categoriesIn)
                    {
                        foreach (List<CategoryBase> categories in lstcategories)
                        {
                            if (categories == null)
                                continue;

                            if (categories[0].GetType() == typeof(CatalogPage))
                            {
                                hql += " INNER JOIN ProductByCategory PBC2 ON PBC2.ProductId = P.Id";
                                hql += " INNER JOIN Category Pag ON PBC2.CategoryId = Pag.Id";
                            }
                            else if (categories[0].GetType() == typeof(Family))
                            {
                                hql += " INNER JOIN ProductByCategory PBC3 ON PBC3.ProductId = P.Id";
                                hql += " INNER JOIN Category Fam ON PBC3.CategoryId = Fam.Id";
                            }
                            else if (categories[0].GetType() == typeof(Application))
                            {
                                hql += " INNER JOIN ProductByCategory PBC4 ON PBC4.ProductId = P.Id";
                                hql += " INNER JOIN Category App ON PBC4.CategoryId = App.Id";
                            }
                            else if (categories[0].GetType() == typeof(ProductType))
                            {
                                hql += " INNER JOIN ProductByCategory PBC5 ON PBC5.ProductId = P.Id";
                                hql += " INNER JOIN Category PrT ON PBC5.CategoryId = PrT.Id";
                            }
                            else if (categories[0].GetType() == typeof(Line))
                            {
                                hql += " INNER JOIN ProductByCategory PBC6 ON PBC6.ProductId = P.Id";
                                hql += " INNER JOIN Category Lin ON PBC6.CategoryId = Lin.Id";
                            }
                            else if (categories[0].GetType() == typeof(Area))
                            {
                                hql += " INNER JOIN ProductByCategory PBC7 ON PBC7.ProductId = P.Id";
                                hql += " INNER JOIN Category Are ON PBC7.CategoryId = Are.Id";
                            }
                        }
                    }
                    else
                    {
                        hql += " LEFT JOIN ProductByCategory PBC2 ON PBC2.ProductId = P.Id";
                        hql += " LEFT JOIN Category Cat ON PBC2.CategoryId = Cat.Id";

                    }

                if (currency != null)
                    if (priceGroup != null)
                    {
                        hql += " LEFT JOIN Currency PC ON PA.PriceCurrencyId = C.Id";
                    }
                    else
                    {
                        hql += " LEFT JOIN Currency PC ON PB.PriceListCurrencyId = C.Id";
                    }
            }
            #endregion

            hql += " WHERE";

            if (!(priceList != null || publishList != null || priceGroup != null))
//            if (priceGroup == null)
            {
                if (priceBaseStatusQuotes == false && priceBaseStatus != null)
                    hql += " PB.Status = :Status AND";
                if (priceBaseStatusQuotes)
                    hql += " PB.Status != :Status AND";
                if (productStatus != null)
                    hql += " P.Status = :ProductStatus AND";
            }

            if (!addTo && newfamily != null)
                if(!createSQL)
                    hql += " PB.Product.ID in (select P.ID from CategoryBase F JOIN F.Products P where F.ID = :NewFamily) AND";
                else
                    hql += " P.ID in (select PbC.ProductId from ProductByCategory PbC where PbC.CategoryId = :NewFamily) AND";

            if (addTo && newfamily != null)
                if(!createSQL)
                    hql += " PB.Product.ID not in (select P.ID from CategoryBase F JOIN F.Products P where F.ID = :NewFamily) AND";
                else
                    hql += " P.ID not in (select PbC.ProductId from ProductByCategory PbC where PbC.CategoryId = :NewFamily) AND";

            if (!addTo && newselection != null)
                if(!createSQL)
                    hql += " PB.Product.ID in (select P.ID from Selection S JOIN S.Products P where S.ID = :NewSelection) AND";
                else
                    hql += " P.ID in (select PbS.ProductId from ProductBySelection PbS where PbS.SelectionId = :NewSelection) AND";

            if (addTo && newselection != null)
                if(!createSQL)
                    hql += " PB.Product.ID not in (select P.ID from Selection S JOIN S.Products P where S.ID = :NewSelection) AND";
                else
                    hql += " P.ID not in (select PbS.ProductId from ProductBySelection PbS where PbS.SelectionId = :NewSelection) AND";

            if (!string.IsNullOrEmpty(description))
                hql += " (lower(P.Description) LIKE :Description OR lower(P.DescriptionAlternative) LIKE :Description OR lower(P.Model) LIKE :Description OR lower(P.ModelAlternative) LIKE :Description OR (lower(P.Code) LIKE :Description) OR (((lower(P.Code) LIKE '')OR(lower(P.Code) IS NULL)) AND (lower(PB.ProviderCode) LIKE :Description))) AND";

            if (cTR != null)
            {
                hql += " PI.CTR >= :CtrMin AND";
                hql += " PI.CTR <= :CtrMax AND";
            }

            if (index != null)
            {
                hql += " PI.Index >= :IndexMin AND";
                hql += " PI.Index <= :IndexMax AND";
            }

            if (list != null)
                hql += " S.ID = :Selection AND";

            if (frequency != null)
            {
                if (!createSQL)
                    hql += " P.Frequency = :Frequency AND";
                else
                    hql += " P.Type = :Frequency AND";
            }

            if (currency != null)
                hql += " PC.ID = :Currency AND";

            if (selecteditems != null && selecteditems.Count > 0)
            {
                string temp = " PI.ID";
                if (isProduct)
                    temp = " P.ID";

                if (markedAll)
                    hql += temp + " NOT IN (";
                else
                    hql += temp + " IN (";


                foreach (int item in selecteditems)
                    hql += item + ",";

                hql = hql.Substring(0, hql.Length - 1);
                hql += ") AND";
            }

            if (therearecategories)
            {
                if (newfamily == null)
                {
                    if (categoriesIn)
                    {
                        foreach (List<CategoryBase> categories in lstcategories)
                        {
                            if (categories == null)
                                continue;

                            if (categories[0].GetType() == typeof(CatalogPage))
                                hql += " Pag.ID in (";
                            else if (categories[0].GetType() == typeof(Family))
                                hql += " Fam.ID in (";
                            else if (categories[0].GetType() == typeof(Application))
                                hql += " App.ID in (";
                            else if (categories[0].GetType() == typeof(ProductType))
                                hql += " PrT.ID in (";
                            else if (categories[0].GetType() == typeof(Line))
                                hql += " Lin.ID in (";
                            else if (categories[0].GetType() == typeof(Area))
                                hql += " Are.ID in (";

                            foreach (CategoryBase item in categories)
                                hql += item.ID + ",";

                            hql = hql.Substring(0, hql.Length - 1);
                            hql += ") AND";
                        }
                         if (addTo)
                        {
                            hql += " P.ID NOT IN (";
                            if (!createSQL)
                            {
                                hql += " select P_.ID from Product P_ JOIN P_.Families CAT_ JOIN CAT_.PriceLists PL_ where";
                                if(priceList != null)
                                    hql += " PL_.ID = :PriceList and ";
                                hql += " CAT_.ID not in (";
                            }
                            else
                            {
                                hql += " select PBC_.ProductId from ProductByCategory PBC_";
                                hql += " INNER JOIN PriceListByCategory PLBC_ ON PBC_.CategoryId = PLBC_.CategoryId where";
                                if (priceList != null)
                                    hql += " PLBC_.PriceListId = :PriceList and";
                                hql += " PBC_.CategoryId not in (";
                            }

                            foreach (List<CategoryBase> categories in lstcategories)
                            {
                                if (categories == null)
                                    continue;
                                foreach (CategoryBase item in categories)
                                    hql += item.ID + ",";
                            }
                            hql = hql.Substring(0, hql.Length - 1);
                            hql += ")) AND";
                        }
                    }
                    else
                    {
                        hql += " (Cat.Type != 2 OR Cat.Type is null) AND";
                    }
                }
            }

            //if (addTo && priceList == null && newPriceGroup != null)
            //    hql += " PI.ID NOT IN (select PA__.PriceBase.ID from PriceAttribute PA__ WHERE PA__.PriceGroup.ID = :NewPriceGroup) AND";

            //if (addTo && priceList == null && newPriceList != null)
            //    hql += " PI.ID NOT IN (select WLI__.PriceAttribute.ID from WorkListItem WLI__ WHERE WLI__.PriceList.ID = :NewPriceList) AND";

            //if (addTo && priceList != null && newPriceGroup != null)
            //    hql += " PI.ID NOT IN (select WLI__.ID from WorkListItem WLI__ WHERE WLI__.PriceList.ID = :PriceList) AND";

            //if (addTo && priceList != null && newPriceList != null)
            //    hql += " PI.ID NOT IN (select WLI__.PriceAttribute.ID from WorkListItem WLI__ WHERE WLI__.PriceList.ID = :PriceList) AND";

            if (addTo && priceGroup == null && priceList == null && newPriceGroup != null)
                hql += " PB.ID NOT IN (select PA__.PriceBase.ID from PriceAttribute PA__ WHERE PA__.PriceGroup.ID = :NewPriceGroup) AND";

            else if (addTo && priceGroup != null && priceList == null && newPriceGroup != null)
                hql += " PB.ID NOT IN (select PA__.PriceBase.ID from PriceAttribute PA__ WHERE PA__.PriceGroup.ID = :NewPriceGroup) AND";

            else if (addTo && priceGroup == null && priceList != null && newPriceGroup != null)
                hql += " PB.ID NOT IN (select PA__.PriceBase.ID from PriceAttribute PA__ LEFT JOIN PA__.WorkListItems WLI__ WHERE WLI__.PriceList.ID = :PriceList OR PA__.PriceGroup.ID = :NewPriceGroup) AND";

            else if (addTo && priceGroup != null && priceList == null && newPriceList != null)
                hql += " PA.ID NOT IN (select WLI__.PriceAttribute.ID from WorkListItem WLI__ WHERE WLI__.PriceList.ID = :NewPriceList) AND";
            
            else if (addTo && priceGroup != null && priceList != null && newPriceList != null)
                hql += " PA.ID NOT IN (select WLI__.PriceAttribute.ID from WorkListItem WLI__ WHERE WLI__.PriceList.ID = :NewPriceList) AND";
                
            else if (addTo && priceGroup == null && priceList != null && newPriceList != null)
                hql += " PB.ID NOT IN (select PA__.PriceBase.ID from PriceAttribute PA__ LEFT JOIN PA__.WorkListItems WLI__ WHERE WLI__.PriceList.ID = :NewPriceList) AND";
            
            if (priceGroup != null)
                hql += " PI.PriceGroupId = :PriceGroup AND";

            if (provider != null)
                hql += " PV.ID = :Provider AND";

            if (date != null)
                hql += " PI.ModifiedOn >= :DateFrom AND";

            if (dateto != null)
                hql += " PI.ModifiedOn <= :DateTo AND";

            if (priceImport != null)
                hql += " PIM.ID = :PriceImport AND";

            if (priceList != null && newPriceList == null)
                hql += " PL.ID = :PriceList AND";

            if (workListItemStatus != null)
                if(workListItemStatus == WorkListItemStatus.Modified)
                    hql += " (WLI.WorkListItemStatus != :WLIStatus AND WLI.WorkListItemStatus != :WLIStatus2) AND";
                else
                    hql += " WLI.WorkListItemStatus = :WLIStatus AND";

            if (publishList != null)
                hql += " PbL.ID = :PublishList AND";

            if(distributor != null)
                hql += " PI.Distributor.ID = :Distributor AND";

            if (hql.EndsWith(" AND") || hql.EndsWith(" WHERE"))
            {
                int end = 0;
                end = hql.LastIndexOf(" AND");
                if (end < 1)
                    end = hql.LastIndexOf(" WHERE");
                hql = hql.Substring(0, end);
            }
            if (!string.IsNullOrEmpty(sortField))
            {
                hql += " ORDER BY " + sortField;
                if (!string.IsNullOrEmpty(sortOrder))
                    hql += " " + sortOrder;
                //hql += ", P.Frequency ASC";
            }

            if (createSQL)
            {
                hql = hql.Replace(".ID", ".Id");
                hql = hql.Replace("Selections", "Selection");
                hql = hql.Replace("Index ", "[Index] ");
            }

            return hql;
        }

        public void CreateParameters(IQuery q, string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            CreateParameters(q, fields, description, category, cTR, list, frequency, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, null, null);
        }

        public void CreateParameters(IQuery q, string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, PriceGroup newPriceGroup, PriceList newPriceList)
        {
            bool therearecategories = false;
            bool categoriesIn = true;
            if (category != null)
            {
                foreach (CategoryBase categoryBase in category)
                {
                    if (categoryBase != null)
                        therearecategories = true;
                    else
                        continue;
                    
                    if (categoryBase.ID == -1)
                        categoriesIn = false;
                }
            }
            
            if (cTR != null)
                cTR = ControllerManager.CtrRange.GetById(cTR.ID);

            if (index != null)
                index = ControllerManager.IndexPrice.GetById(index.ID);

            if (!(priceList != null || publishList != null || priceGroup != null))
            //if (priceGroup == null)
            {
                if (priceBaseStatus != null)
                    q.SetEnum("Status", priceBaseStatus);

                if (productStatus != null)
                    q.SetEnum("ProductStatus", productStatus);
            }

            if (!string.IsNullOrEmpty(description))
                q.SetString("Description", "%" + description.ToLower() + "%");

            if (list != null)
                q.SetInt32("Selection", list.ID);

            if (cTR != null)
            {
                q.SetDecimal("CtrMin", cTR.Min);
                q.SetDecimal("CtrMax", cTR.Max);
            }

            if (index != null)
            {
                q.SetDecimal("IndexMin", index.Min);
                q.SetDecimal("IndexMax", index.Max);
            }

            if (frequency != null)
                q.SetEnum("Frequency", frequency);

            if (currency != null)
                q.SetInt32("Currency", currency.ID);

            if (newselection != null)
                q.SetInt32("NewSelection", newselection.ID);

            if (newfamily != null)
                q.SetInt32("NewFamily", newfamily.ID);

            if (pageNumber > 0 && (fields != "COUNT(*)" || pageSize == 0))
            {
                q.SetMaxResults(pageSize);
                if (pageNumber > 1)
                    q.SetFirstResult(pageSize * (pageNumber - 1));
            }

            if (priceGroup != null)
                q.SetInt32("PriceGroup", priceGroup.ID);

            if (provider != null)
                q.SetInt32("Provider", provider.ID);

            if (date != null)
                q.SetDateTime("DateFrom", (DateTime)date);

            if (dateto != null)
                q.SetDateTime("DateTo", (DateTime)dateto);

            //if (priceList != null)
            if (priceList != null && (therearecategories && newfamily == null && categoriesIn && addTo) || (addTo && priceGroup == null && priceList != null && newPriceGroup != null) || (priceList != null && newPriceList == null))
                q.SetInt32("PriceList", priceList.ID);

            if (priceImport != null)
                q.SetGuid("PriceImport", priceImport.ID);

            if (workListItemStatus != null)
                if (workListItemStatus == WorkListItemStatus.Modified)
                {
                    q.SetEnum("WLIStatus", WorkListItemStatus.Approved);
                    q.SetEnum("WLIStatus2", WorkListItemStatus.Published);
                }
                else
                    q.SetEnum("WLIStatus", workListItemStatus);

            if (publishList != null)
                q.SetInt32("PublishList", publishList.ID);

            if (distributor != null)
                q.SetInt32("Distributor", distributor.ID);

            if (addTo && newPriceGroup != null)
                q.SetInt32("NewPriceGroup", newPriceGroup.ID);
            else if (addTo && newPriceList != null)
                q.SetInt32("NewPriceList", newPriceList.ID);
        }

        private IQuery GetProductListQuery(string fields, string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Selection newselection, CategoryBase newfamily, DateTime? listedDate, bool createSQL, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, bool priceBaseStatusQuotes, PriceGroup newPriceGroup, PriceList newPriceList)
        {
            string hql = GetProductListHQL(fields, description, category, cTR, list, frequency,
                currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems,
                addTo, newselection, newfamily, listedDate, createSQL, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, priceBaseStatusQuotes, newPriceGroup, newPriceList, false);

            IQuery q = NHibernateSession.CreateQuery(hql);

            CreateParameters(q, fields, description, category, cTR, list, frequency, currency,
                pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo,
                newselection, newfamily, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency, newPriceGroup, newPriceList);

            return q;
        }

        #endregion

        #region Get Products To Add/Remove from Selection

        public bool AddToSelection(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, Selection newselection, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            List<int> tempproductlist = GetProducts(description, category, cTR, list, frequency, sortField, sortOrder, markedAll, selecteditems, true, currency, newselection, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);

            if (tempproductlist != null)
                if (tempproductlist.Count > 0)
                {
                    ControllerManager.Selection.AddToSelection(tempproductlist, newselection);
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        public bool RemoveFromSelection(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            Selection selection = ControllerManager.Selection.GetById(list.ID);
            // Get the current page and data for the current filters
            List<int> tempproductlist = GetProducts(description, category, cTR, list, frequency, sortField, sortOrder, markedAll, selecteditems, false, currency, list, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);
            if (tempproductlist != null)
                if (tempproductlist.Count > 0)
                {
                    ControllerManager.Selection.RemoveFromSelection(tempproductlist, selection);
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        #endregion

        #region GetProducts

        public List<int> GetProducts(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Currency currency, Selection newselection, CategoryBase newfamily, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PB.Product.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, addTo, newselection, newfamily, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);
            List<int> tempproductlist = q.List<int>() as List<int>;

            return tempproductlist;
        }

        #endregion

        #region GetPriceBases

        public List<PriceBase> GetPriceBases(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, bool addTo, Currency currency, Selection newselection, CategoryBase newfamily, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PB", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, addTo, newselection, newfamily, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);
            List<PriceBase> temppblist = q.List<PriceBase>() as List<PriceBase>;

            return temppblist;
        }

        #endregion
        
        #region Get Products To Add/Remove from Category

        public bool AddToCategory(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, int newfamilyId, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            CategoryBase newfamily = ControllerManager.CategoryBase.GetById(Convert.ToInt32(newfamilyId));
            if (newfamily != null)
            {
                string select = GetProductListHQL("DISTINCT P.Id, " + newfamily.ID, description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, true, null, newfamily, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, false);
                string insert = "insert into ProductByCategory (ProductId, CategoryId) " + select;
                IQuery q = NHibernateSession.CreateSQLQuery(insert);
                CreateParameters(q, "", description, category, cTR, list, frequency, currency, 0, 0, sortField, sortOrder, markedAll, selecteditems, true, null, newfamily, date, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null);

                q.ExecuteUpdate();
                return true;
            }
            return false;
        }

        public bool RemoveFromCategory(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, int newfamilyId, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, bool isProduct)
        {
            // Get the current page and data for the current filters
            CategoryBase newfamily = ControllerManager.CategoryBase.GetById(Convert.ToInt32(newfamilyId));
            if (newfamily != null)
            {
                string select = GetProductListHQL("DISTINCT P.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, newfamily, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, isProduct);
                string insert = "delete from ProductByCategory where ProductId in (" + select + ") and CategoryId = :NewFamily";
                IQuery q = NHibernateSession.CreateSQLQuery(insert);
                CreateParameters(q, "", description, category, cTR, list, frequency, currency, 0, 0, sortField, sortOrder, markedAll, selecteditems, true, null, newfamily, date, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null);

                q.ExecuteUpdate();
                return true;
            }
            return false;
        }

        #endregion

        #region PriceBaseStatus Change

        public bool ChangePriceBaseStatus(GridState gs, IList<Filters.IFilter> filters, PriceBaseStatus newPriceBaseStatus)
        {
            string order = "DESC";
            if (gs.SortAscending)
                order = "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            Currency toCurrency = null;
            if (gs.ShowInCurrency != null && gs.ShowInCurrency > 0)
                ControllerManager.Currency.GetById((int)gs.ShowInCurrency);

            bool changed = ChangePriceBaseStatus(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gs.SortField, order, gs.MarkedAll, gs.Items, gs.SearchDate, mpsp.Currency, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, newPriceBaseStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor, toCurrency);

            CommitChanges();

            if (changed && newPriceBaseStatus == PriceBaseStatus.NotVerified)
                ControllerManager.PriceCalculation.Run(mpsp, gs, toCurrency, newPriceBaseStatus);

            return changed;
        }

        private bool ChangePriceBaseStatus(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, DateTime searchDate, Currency currency, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, PriceBaseStatus newPriceBaseStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            if (productStatus == null)
                productStatus = ProductStatus.Active;

            if (newPriceBaseStatus == PriceBaseStatus.NotVerified)
                RemoveFromBasePrice(description, category, cTR, list, frequency, currency, markedAll, selecteditems, searchDate, MembershipHelper.GetUser().UserId, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            // Get the current page and data for the current filters
            BeginTransaction();
            string plsql = ControllerManager.PriceBase.GetProductListHQL("DISTINCT PB.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, DateTime.Now, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, null);

            string updateSql = "UPDATE PriceBase SET";
            updateSql += " Status = :NewStatus,";
            updateSql += " ModifiedBy = :User,";
            updateSql += " ModifiedOn = :DateCurrent";
            updateSql += " from PriceBase PB_";
            updateSql += " WHERE PB_.Id IN (" + plsql + ")";

            IQuery q = NHibernateSession.CreateSQLQuery(updateSql);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, DateTime.Now, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, null, publishList, distributor, null);
            q.SetEnum("NewStatus", newPriceBaseStatus);
            q.SetDateTime("DateCurrent", DateTime.Now);
            q.SetGuid("User", MembershipHelper.GetUser().UserId);

            q.ExecuteUpdate();
            CommitChanges();        
            
            return true;
        }

        private void RemoveFromBasePrice(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, Guid userId, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            #region Save history of WorkListItem and Erase them
            // DELETE CORRESPONDING RECORDS
            DeleteWLIList(description, category, cTR, list, frequency, currency, markedAll, selecteditems, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            NHibernateSession.Flush();
            #endregion

            #region Save history PriceAttribute and erase them
            // DELETE CORRESPONDING RECORDS
            DeletePAList(description, category, cTR, list, frequency, currency, markedAll, selecteditems, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            NHibernateSession.Flush();
            #endregion
        }

        #endregion

        private void DeletePAList(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPBsql = GetProductListHQL("DISTINCT PB.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            string deletePA = "SELECT DISTINCT PA.Id";
            deletePA += " FROM viewProductInfoByGroup PI";
            deletePA += " INNER JOIN PriceAttribute PA ON PI.Id = PA.Id";
            deletePA += " INNER JOIN PriceBase PB ON PA.PriceBaseId = PB.Id";
            deletePA += " INNER JOIN Product P ON P.Id = PB.ProductId";
            deletePA += " WHERE PB.Status = " + (int)PriceBaseStatus.Verified;
            deletePA += " AND P.Status = " + (int)ProductStatus.Active;
            deletePA += " AND PB.Id IN (" + selectPBsql + ")";

            string deleteSql = "DELETE FROM PriceAttribute";
            deleteSql += " WHERE Id IN (" + deletePA + ")";

            IQuery q = NHibernateSession.CreateSQLQuery(deleteSql);

            CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                             0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                             null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            q.ExecuteUpdate();
        }

        private IList<PriceAttribute> GetPAList(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPB = GetProductListHQL("DISTINCT PB.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            string selectPA = "SELECT DISTINCT PA_";
            selectPA += " FROM ProductInfoByGroup PI_";
            selectPA += " JOIN PI_.PriceAttribute PA_";
            selectPA += " JOIN PA_.PriceBase PB_";
            selectPA += " JOIN PB_.Product P_";
            selectPA += " WHERE PB_.Status = " + (int)PriceBaseStatus.Verified;
            selectPA += " AND P_.Status = " + (int)ProductStatus.Active;
            if (priceGroup != null)
                selectPA += " AND PA_.PriceGroup = :PriceGroup";
            selectPA += " AND PB_.ID IN (" + selectPB + ")";

            IQuery q2 = NHibernateSession.CreateQuery(selectPA);

            ControllerManager.PriceBase.CreateParameters(q2, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            return q2.List<PriceAttribute>();
        }

        private void DeleteWLIList(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPBsql = GetProductListHQL("DISTINCT PB.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            string deleteWLI = "SELECT DISTINCT WLI.Id";
            deleteWLI += " FROM viewProductInfoByPriceList PI";
            deleteWLI += " INNER JOIN WorkListItem WLI ON PI.Id = WLI.Id";
            deleteWLI += " INNER JOIN PriceAttribute PA ON WLI.PriceAttributeId = PA.Id";
            deleteWLI += " INNER JOIN PriceBase PB ON PA.PriceBaseId = PB.Id";
            deleteWLI += " INNER JOIN Product P ON P.Id = PB.ProductId";
            deleteWLI += " WHERE PB.Status = " + (int)PriceBaseStatus.Verified;
            deleteWLI += " AND P.Status = " + (int)ProductStatus.Active;
            deleteWLI += " AND PB.Id IN (" + selectPBsql + ")";

            string deleteSql = "DELETE FROM WorkListItem";
            deleteSql += " WHERE Id IN (" + deleteWLI + ")";

            IQuery q = NHibernateSession.CreateSQLQuery(deleteSql);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            q.ExecuteUpdate();
        }

        private IList<WorkListItem> GetWLIList(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPB = GetProductListHQL("DISTINCT PB.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            // INSERT INTO WORKLISTITEMHISTORY
            string selectWLI = "SELECT DISTINCT WLI_";
            selectWLI += " FROM ProductInfoByPriceList PI_";
            selectWLI += " JOIN PI_.WorkListItem WLI_";
            selectWLI += " JOIN WLI_.PriceAttribute PA_";
            selectWLI += " JOIN PA_.PriceBase PB_";
            selectWLI += " JOIN PB_.Product P_";
            selectWLI += " WHERE PB_.Status = " + (int)PriceBaseStatus.Verified;
            selectWLI += " AND P_.Status = " + (int)ProductStatus.Active;
            if (priceList != null )
                selectWLI += " AND WLI_.PriceList = :PriceList";
            selectWLI += " AND PB_.ID IN (" + selectPB + ")";
            
            IQuery q = NHibernateSession.CreateQuery(selectWLI);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            return q.List<WorkListItem>();
        }

        #region Product Status Change

        public bool ChangeProductStatus(GridState gs, IList<Filters.IFilter> filters, ProductStatus newProductStatus)
        {
            string order = "DESC";
            if (gs.SortAscending)
                order = "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            return ChangeProductStatus(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gs.SortField, order, gs.MarkedAll, gs.Items, mpsp.Currency, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, newProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
        }

        private bool ChangeProductStatus(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, ProductStatus newproductStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("P", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);

            List<Product> productlist = q.List<Product>() as List<Product>;

            if (productlist != null)
                if (productlist.Count > 0)
                {
                    ChangeProductStatus(productlist, newproductStatus);
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        private void ChangeProductStatus(List<Product> products, ProductStatus newproductStatus)
        {
            foreach (Product product in products)
                product.Status = newproductStatus;
            CommitChanges();
        }

        #endregion

        #region Get List of WorkListItem Selected

        public IList<WorkListItem> GetWorkListItemsSelected(GridState gs, IList<Filters.IFilter> filters)
        {
            string order = "DESC";
            if (gs.SortAscending)
                order = "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            return GetWorkListItemsSelected(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gs.SortField, order, gs.MarkedAll, gs.Items, mpsp.Currency, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
        }

        private IList<WorkListItem> GetWorkListItemsSelected(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT WLI", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor);

            return q.List<WorkListItem>();
        }

        #endregion

        #region Get List of PriceAttribute Selected

        public IList<PriceAttribute> GetPriceAttributesSelected(GridState gs, IList<Filters.IFilter> filters, PriceList newPriceList)
        {
            string order = "DESC";
            if (gs.SortAscending)
                order = "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            return GetPriceAttributesSelected(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gs.SortField, order, gs.MarkedAll, gs.Items, mpsp.Currency, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor, newPriceList);
        }

        public IList<PriceAttribute> GetPriceAttributesSelected(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, PriceList newPriceList)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PA", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, true, null, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, newPriceList);

            return q.List<PriceAttribute>();
        }

        #endregion

        #region Update Prices

        public bool Update(GridState gs, IList<Filters.IFilter> filters, string modvalor, string modctr, out List<int> lstpriceBase)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            bool isValue = (!string.IsNullOrEmpty(modvalor));
            decimal val;

            if (!string.IsNullOrEmpty(modvalor))
                val = Convert.ToDecimal(modvalor);
            else
                val = Convert.ToDecimal(modctr);

            Currency toCurrency = null;
            
            lstpriceBase = ControllerManager.PriceBase.UpdateProductPrices(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, gs.MarkedAll, gs.Items, gs.SearchDate, MembershipHelper.GetUser().UserId, isValue, val, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor, toCurrency);
            return lstpriceBase.Count > 0;
        }

        private List<int> UpdateProductPrices(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, Guid userId, bool modpcr, decimal value, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string prodq = GetProductListHQL("DISTINCT PB.Id", description, category, cTR, list, frequency, currency, 0, 0, null, null, markedAll, selecteditems, false, null, null, listedDate, true, false, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            IQuery iq = NHibernateSession.CreateSQLQuery(prodq);

            CreateParameters(iq, string.Empty, description, category, cTR, list, frequency, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            List<int> templist = iq.List<int>() as List<int>;

            // INSERT INTO PRODUCTAUDIT
            string plsql;
            //string insertsql;
            //if (priceGroup != null)
            //{
            //    //IList<PriceAttribute> lstpa = GetPAList(description, category, cTR, list, frequency, currency, markedAll, selecteditems, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            //    //ControllerManager.PriceAttributeHistory.SaveAudit(lstpa, HistoryStatus.Modification);
            //}
            //else if (priceList != null)
            //{
            //    IList<WorkListItem> lst = GetWLIList(description, category, cTR, list, frequency, currency, markedAll, selecteditems, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            //    ControllerManager.WorkListItemHistory.SaveAudit(lst, HistoryStatus.Modification);
            //}
            //else
            //{
            //    IList<PriceBase> lst = ControllerManager.PriceBase.GetListFromPBList(templist);
            //    ControllerManager.PriceBaseHistory.SaveAudit(lst, HistoryStatus.Modification);
            //}

            NHibernateSession.Flush();

            // UPDATE CORRESPONDING RECORDS
            string updateSql;
            string price;
            if (priceGroup != null)
            {
                plsql = GetProductListHQL("DISTINCT PA.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
                updateSql = "UPDATE PriceAttribute SET";

                if (modpcr)
                    price = "(PA.Price * ((:Value/Cast(100 as FLOAT))+1))";
                else
                    price = "(-((PB.PricePurchase * PG.PriceSuggestCoef * CPP.Value)/(((:Value/Cast(100 as FLOAT))-1)*((100-Cast(ISNULL(DISC.MaximumDiscount,PG.Discount) as FLOAT))/100))))/CP.Value";

                updateSql += " Price = " + price + ",";
                updateSql += " ModifiedBy = :User,";
                updateSql += " ModifiedOn = :DateCurrent,";
                updateSql += " CurrencyRateId = LCR.CurrencyRateId,";
                updateSql += " PriceSuggestCurrencyRateId = LCRS.CurrencyRateId,";
                updateSql += " PricePurchaseCurrencyRateId = LCRP.CurrencyRateId";
                updateSql += " from PriceAttribute PA";
                updateSql += " inner join PriceBase PB";
                updateSql += " on PB.Id = PA.PriceBaseId";
                updateSql += " inner join PriceGroup PG";
                updateSql += " on PG.Id = PA.PriceGroupId";
                updateSql += " inner join viewCurrency CP";
                updateSql += " on PA.PriceCurrencyId = CP.Id";
                updateSql += " inner join viewCurrency CPP";
                updateSql += " on PB.PricePurchaseCurrencyId = CPP.Id";
                updateSql += " inner join viewCurrency CPS";
                updateSql += " on PB.PriceSuggestCurrencyId = CPS.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCR on CP.Id = LCR.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCRP on CPP.Id = LCRP.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCRS on CPS.Id = LCRS.Id";
                updateSql += " left join dbo.PriceBaseDiscount DISC ON DISC.PriceBaseId = PB.Id";
                
                updateSql += " WHERE PA.Id IN (" + plsql + ")";

            }
            else if (priceList != null)
            {
                plsql = GetProductListHQL("DISTINCT WLI.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
                updateSql = "UPDATE WorkListItem SET";

                if (modpcr)
                    price = "(WLI.Price * ((:Value/Cast(100 as FLOAT))+1))";
                else
                    price = "(-((PB.PricePurchase * PG.PriceSuggestCoef * CPP.Value)/(((:Value/Cast(100 as FLOAT))-1)*((100-Cast(ISNULL(DISC.MaximumDiscount,PL.Discount) as FLOAT))/100))))/CP.Value";

                updateSql += " WorkListItemStatus = CASE WHEN WorkListItemStatus = " + (int)WorkListItemStatus.Added + " OR WorkListItemStatus = " + (int)WorkListItemStatus.AddedMod + "THEN " + (int)WorkListItemStatus.AddedMod + " ELSE " + (int)WorkListItemStatus.Modified + " END,";
                updateSql += " Price = " + price + ",";
                updateSql += " ModifiedBy = :User,";
                updateSql += " ModifiedOn = :DateCurrent,";
                updateSql += " CurrencyRateId = LCR.CurrencyRateId,";
                updateSql += " PriceSuggestCurrencyRateId = LCRS.CurrencyRateId,";
                updateSql += " PricePurchaseCurrencyRateId = LCRP.CurrencyRateId";
                updateSql += " from WorkListItem WLI";
                updateSql += " inner join PriceList PL";
                updateSql += " on WLI.PriceListId = PL.Id";
                updateSql += " inner join PriceAttribute PA";
                updateSql += " on WLI.PriceAttributeId = PA.Id";
                updateSql += " inner join PriceGroup PG";
                updateSql += " on PG.Id = PA.PriceGroupId";
                updateSql += " inner join PriceBase PB";
                updateSql += " on PB.Id = PA.PriceBaseId";
                updateSql += " inner join viewCurrency CP";
                updateSql += " on WLI.PriceCurrencyId = CP.Id";
                updateSql += " inner join viewCurrency CPP";
                updateSql += " on PB.PricePurchaseCurrencyId = CPP.Id";
                updateSql += " inner join viewCurrency CPS";
                updateSql += " on PB.PriceSuggestCurrencyId = CPS.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCR on CP.Id = LCR.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCRP on CPP.Id = LCRP.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCRS on CPS.Id = LCRS.Id";
                updateSql += " left join dbo.PriceBaseDiscount DISC ON DISC.PriceBaseId = PB.Id";
                
                updateSql += " WHERE WLI.Id IN (" + plsql + ")";

            }
            else
            {
                plsql = GetProductListHQL("DISTINCT PB.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
                updateSql = "UPDATE PriceBase SET";

                if (modpcr)
                    price = "(PB.PriceList * ((:Value/Cast(100 as FLOAT))+1))";
                else
                    price = "(-((PB.PricePurchase * CPP.Value)/(((:Value/Cast(100 as FLOAT))-1)*((100-Cast(ISNULL(DISC.MaximumDiscount,PV.Discount) as FLOAT))/100))))/CP.Value";

                updateSql += " PriceList = " + price + ",";
                updateSql += " ModifiedBy = :User,";
                updateSql += " ModifiedOn = :DateCurrent,";
                updateSql += " CurrencyRateId = LCR.CurrencyRateId,";
                updateSql += " PriceSuggestCurrencyRateId = LCRS.CurrencyRateId,";
                updateSql += " PricePurchaseCurrencyRateId = LCRP.CurrencyRateId";
                updateSql += " from PriceBase PB";
                updateSql += " inner join viewCurrency CP";
                updateSql += " on PB.PriceListCurrencyId = CP.Id";
                updateSql += " inner join viewCurrency CPP";
                updateSql += " on PB.PricePurchaseCurrencyId = CPP.Id";
                updateSql += " inner join viewCurrency CPS";
                updateSql += " on PB.PriceSuggestCurrencyId = CPS.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCR on CP.Id = LCR.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCRP on CPP.Id = LCRP.Id";
                updateSql += " inner join dbo.viewLastCurrencyRate LCRS on CPS.Id = LCRS.Id";
                updateSql += " inner join Provider PV";
                updateSql += " on PB.ProviderId = PV.Id";
                updateSql += " left join dbo.PriceBaseDiscount DISC ON DISC.PriceBaseId = PB.Id";
                
                updateSql += " WHERE PB.Id IN (" + plsql + ")";

            }

            IQuery q = NHibernateSession.CreateSQLQuery(updateSql);

            CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            q.SetDecimal("Value", value);
            q.SetDateTime("DateCurrent", DateTime.Now);
            q.SetString("User", userId.ToString());
            q.ExecuteUpdate();

            // Return Modified Prices
            return templist;
        }

        public bool ModifyCreateProduct(int id, int productid, string code, string description, Frequency frecuencyType, string model, string providercode, int providerId, bool isNew, Currency listCurrency, Currency suggestCurrency, Currency purchaseCurrency,
            decimal list, decimal suggest, decimal purchase, string alternativeModel, string eAN, string alternativeDescription, string observation, out int productId, out int priceBaseId)
        {
            ProductInfo pI = null;
            Product product = new Product();
            List<CurrencyRate> currencyRates = ControllerManager.CurrencyRate.GetLastList();

            string completeCode = string.Empty;
            if (!string.IsNullOrEmpty(code))
                completeCode = code.PadLeft(8, '0');
            
            priceBaseId = 0;
            PriceBase pb = new PriceBase();
            Provider provider = ControllerManager.Provider.GetById(providerId); 
            if (!isNew)
            {
                if (productid != 0)
                {
                    product = ControllerManager.Product.GetById(productid);
                }
                else
                {
                    pI = ControllerManager.ProductInfo.GetById(id);
                    product = pI.PriceBase.Product;
                }
            }

            else
            {

                Currency baseCurrency = ControllerManager.Currency.GetBaseCurrency();
                
               
                if (CanCreate(completeCode, provider))
                {
                    pb.PriceList = list;
                    pb.PriceListCurrency = listCurrency;

                    pb.PricePurchase = purchase;
                    pb.PricePurchaseCurrency = purchaseCurrency;
                    pb.PriceSuggest = suggest;
                    pb.PriceSuggestCurrency = suggestCurrency;
                    pb.Provider = provider;

                    if (list == 0)
                        pb.Status = PriceBaseStatus.NotVerified;
                    else
                        pb.Status = PriceBaseStatus.Verified;
                    
                    pb.CurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == listCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });

                    pb.PricePurchaseCurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                             {
                                                                 if (record.Currency == purchaseCurrency)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             }); ;

                    pb.PriceSuggestCurrencyRate = currencyRates.Find(delegate(CurrencyRate record)
                                                         {
                                                             if (record.Currency == suggestCurrency)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         });
                    pb.ProviderCode = providercode;
                   
                    
             
                }
                else
                {
                    productId = 0;
                    priceBaseId = 0;
                    return false;
                }
            }
            product.EAN = eAN;
            product.ModelAlternative = alternativeModel;
            product.DescriptionAlternative = alternativeDescription;
            product.Observations = observation;

            product.Code = completeCode;
            product.Description = description;
            product.Frequency = (Frequency)frecuencyType;
            product.Model = model;
            
            ControllerManager.Product.Save(product);
            if (isNew)
            {
                product.Keywords = "";
                product.Providers.Add(provider);
                product.Status = ProductStatus.Active;
                
                pb.Product = product;
                Save(pb);
                priceBaseId = pb.ID;
            }

            CommitChanges();

            productId = product.ID;

            if (isNew)
                ControllerManager.PriceCalculation.Run(pb.ID);

            return true;
        }

        private bool CanCreate(string code, Provider provider)
        {
            if (!string.IsNullOrEmpty(code))
            {
                ICriteria crit = GetCriteria();
                if (provider != null)
                {
                    ICriteria critProvider = crit.CreateCriteria("Provider");
                    critProvider.Add(Expression.Eq("ID", provider.ID)).CreateCriteria("Products").Add(Expression.Eq("Code", code));
                    if (crit.List().Count > 0)
                        return false;
                    
                    return true;
                }
                return false;
            }
            else
                return true;
        }

        #endregion

        #region Individual Update

        public ProductView ChangePrice(string id, string value, string type, Guid user, string masterListType, string globalToCurrency)
        {
            decimal price = 0;
            GetTempPrice(id, value, type, out price, masterListType, globalToCurrency);
            decimal p = Convert.ToDecimal(price);
            List<CurrencyRate> lastCurrencyRate = ControllerManager.CurrencyRate.GetLastList();

            if (masterListType == Convert.ToInt32(MasterListType.PriceGroupView).ToString())
            {
                PriceAttribute priceAttribute = ControllerManager.PriceAttribute.GetById(Convert.ToInt32(id));
                if(priceAttribute == null)
                    return new ProductView();
                //ControllerManager.PriceAttributeHistory.SaveAudit(priceAttribute, HistoryStatus.Modification);

                priceAttribute.Price = p;
                priceAttribute.CurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == priceAttribute.PriceCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                priceAttribute.PricePurchaseCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == priceAttribute.PriceBase.PricePurchaseCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                priceAttribute.PriceSuggestCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == priceAttribute.PriceBase.PriceSuggestCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });

                ControllerManager.PriceAttribute.Save(priceAttribute);
                CommitChanges();

                return ControllerManager.PriceAttribute.GetProductView(priceAttribute.ID, Convert.ToInt32(globalToCurrency));
            }
            else if (masterListType == Convert.ToInt32(MasterListType.PriceListProducts).ToString())
            {
                WorkListItem workListItem = ControllerManager.WorkListItem.GetByIdentifier(Convert.ToInt32(id));
                if (workListItem == null)
                    return new ProductView();
                //ControllerManager.WorkListItemHistory.SaveAudit(workListItem, HistoryStatus.Modification);

                workListItem.Price = p;
                workListItem.CurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == workListItem.PriceCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                workListItem.PricePurchaseCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == workListItem.PriceAttribute.PriceBase.PricePurchaseCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                workListItem.PriceSuggestCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == workListItem.PriceAttribute.PriceBase.PriceSuggestCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });

                if(workListItem.WorkListItemStatus == WorkListItemStatus.Added)
                    workListItem.WorkListItemStatus = WorkListItemStatus.AddedMod;
                else if (workListItem.WorkListItemStatus != WorkListItemStatus.AddedMod)
                    workListItem.WorkListItemStatus = WorkListItemStatus.Modified;

                ControllerManager.WorkListItem.Save(workListItem);
                CommitChanges();

                return ControllerManager.WorkListItem.GetProductView(workListItem.ID, Convert.ToInt32(globalToCurrency));
            }
            else if (masterListType == Convert.ToInt32(MasterListType.MasterPriceView).ToString())
            {
                PriceBase priceBase = GetById(Convert.ToInt32(id));
                if (priceBase == null)
                    return new ProductView();
                //ControllerManager.PriceBaseHistory.SaveAudit(priceBase, HistoryStatus.Modification);

                priceBase.PriceList = p;
                priceBase.CurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == priceBase.PriceListCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                priceBase.PricePurchaseCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == priceBase.PricePurchaseCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                priceBase.PriceSuggestCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency == priceBase.PriceSuggestCurrency)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });

                Save(priceBase);
                CommitChanges();

                return GetProductView(priceBase.ID, Convert.ToInt32(globalToCurrency));
            }

            return new ProductView();
        }

        public TempPrice GetTempPrice(string id, string value, string type, out decimal price, string masterListType, string globalToCurrency)
        {
            Currency toCurrency = null;
            Currency fromCurrency = null;

            if (!string.IsNullOrEmpty(globalToCurrency))
                fromCurrency = ControllerManager.Currency.GetById(Convert.ToInt32(globalToCurrency));

            decimal pricePurchase = 0;
            decimal pricePurchaseCurrencyValue = 0;
            decimal listPrice = 0;
            decimal listPriceCurrencyValue = 0;
            decimal discount = 0;
            string listPriceCurrencyDescription = "";
            if (masterListType == "PriceGroupView" || masterListType == "2")
            {
                PriceAttribute priceAttribute = ControllerManager.PriceAttribute.GetById(Convert.ToInt32(id));
                pricePurchase = priceAttribute.PriceBase.PricePurchase * priceAttribute.PriceGroup.PriceSuggestCoef;
                pricePurchaseCurrencyValue = priceAttribute.PriceBase.PricePurchaseCurrency.LastCurrencyRateView.Rate;
                listPrice = priceAttribute.Price;
                listPriceCurrencyValue = priceAttribute.PriceCurrency.LastCurrencyRateView.Rate;
                discount = ControllerManager.Distributor.FindMaxDiscountPerPriceBase(priceAttribute.PriceBase);
                if(discount == 0)
                    discount = priceAttribute.PriceGroup.Discount;
                if (fromCurrency == null)
                    fromCurrency = priceAttribute.PriceCurrency;
                toCurrency = priceAttribute.PriceCurrency;
            }
            else if (masterListType == "PriceListProducts" || masterListType == "7")
            {
                WorkListItem workListItem = ControllerManager.WorkListItem.GetByIdentifier(Convert.ToInt32(id));
                pricePurchase = workListItem.PriceAttribute.PriceBase.PricePurchase * workListItem.PriceAttribute.PriceGroup.PriceSuggestCoef;
                pricePurchaseCurrencyValue = workListItem.PriceAttribute.PriceBase.PricePurchaseCurrency.LastCurrencyRateView.Rate;
                listPrice = workListItem.Price;
                listPriceCurrencyValue = workListItem.PriceCurrency.LastCurrencyRateView.Rate;
                discount = ControllerManager.Distributor.FindMaxDiscountPerPriceBase(workListItem.PriceAttribute.PriceBase);
                if (discount == 0)
                    discount = workListItem.PriceList.Discount;
                if (fromCurrency == null)
                    fromCurrency = workListItem.PriceCurrency;
                listPriceCurrencyDescription = workListItem.PriceCurrency.Description;
                toCurrency = workListItem.PriceCurrency;
            }
            else if (masterListType == "MasterPriceView" || masterListType == "4")
            {
                PriceBase priceBase = GetById(Convert.ToInt32(id));
                pricePurchase = priceBase.PricePurchase;
                pricePurchaseCurrencyValue = priceBase.PricePurchaseCurrency.LastCurrencyRateView.Rate;
                listPrice = priceBase.PriceList;
                listPriceCurrencyValue = priceBase.PriceListCurrency.LastCurrencyRateView.Rate;
                discount = ControllerManager.Distributor.FindMaxDiscountPerPriceBase(priceBase);
                if (discount == 0)
                    discount = priceBase.Provider.Discount;
                if (fromCurrency == null)
                    fromCurrency = priceBase.PriceListCurrency;
                listPriceCurrencyDescription = priceBase.PriceListCurrency.Description;
                toCurrency = priceBase.PriceListCurrency;
            }

            decimal rate = ControllerManager.CurrencyRate.GetRate(fromCurrency, toCurrency);


            TempPrice tP = new TempPrice();
            decimal Price;
            decimal PriceSell;
            decimal CTR;

            //string tempvalue = value.Replace(",", ".");
            decimal tempvalue;
            if (type == "1")
                tempvalue = Convert.ToDecimal(value) * rate;
            else
                tempvalue = Convert.ToDecimal(value);

            if (type == "1")
                Price = tempvalue;
            else if (type == "2")
                Price = (-((pricePurchase * pricePurchaseCurrencyValue) / (((tempvalue / 100) - 1) * ((100 - discount) / Convert.ToDecimal(100)))) / listPriceCurrencyValue);
            else
                Price = listPrice * (1 + (tempvalue / 100));

            PriceSell = ((Price * listPriceCurrencyValue) * (100 - discount) / 100) / listPriceCurrencyValue;
            if (!(PriceSell == 0))
                CTR = (1 - ((pricePurchase * pricePurchaseCurrencyValue) / (PriceSell * listPriceCurrencyValue))) * 100;
            else
                CTR = 0;

            rate = ControllerManager.CurrencyRate.GetRate(toCurrency, fromCurrency);

            price = Price;
            tP.NewPrice = fromCurrency.Description + " " + (Price * rate).ToString("#,##0.00");
            tP.NewCtr = CTR.ToString("##0.00") + " %";
            tP.OriginalPrice = fromCurrency.Description + " " + (listPrice * rate).ToString("#,##0.00");
            tP.NewPriceWF = (Price * rate).ToString();
            tP.OriginalPriceWF = (listPrice * rate);

            return tP;
        }

        public ProductView GetProductView(int id, int toCurrency)
        {
            string hql = "SELECT PB.ID, P.Description, P.Code, PI.PriceSell, PI.Price, PI.CTM, PI.CTR, PI.Index, PI.LastPrice, PI.PLCurrencyId, PI.PricePurchase";
            hql += " FROM ProductInfo PI";
            hql += " JOIN PI.PriceBase PB";
            hql += " JOIN PB.Provider PV";
            hql += " JOIN PB.Product P";
            hql += " WHERE PB.Status = :Status";
            hql += " AND P.Status = :ProductStatus";
            hql += " AND PB.ID = :Id";
            
            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetEnum("Status", PriceBaseStatus.Verified);
            q.SetEnum("ProductStatus", ProductStatus.Active);
            q.SetInt32("Id", id);
           
            q.SetMaxResults(1);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductView).GetConstructors()[1]));
            return q.UniqueResult<ProductView>();
        }

        #endregion

        #region Add/Remove to PriceGroup

        public bool AddToPriceGroup(GridState gs, IList<Filters.IFilter> filters, string newPriceGroup)
        {
            string order = "DESC";
            if (gs.SortAscending)
                order = "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            return AddToPriceGroup(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gs.SortField, order, gs.MarkedAll, gs.Items, mpsp.Currency, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, Convert.ToInt32(newPriceGroup), mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
        }

        public bool AddToPriceGroup(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, string sortField, string sortOrder, bool markedAll, List<int> selecteditems, Currency currency, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, int newPriceGroup, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PB", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, true, null, null, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, null, workListItemStatus, null, distributor, new PriceGroup(newPriceGroup));
            List<PriceBase> priceBases = q.List<PriceBase>() as List<PriceBase>;
            if (priceBases != null)
                if (priceBases.Count > 0)
                {
                    ControllerManager.PriceGroup.AddToPriceGroup(newPriceGroup, priceBases);
                    return true;
                }
                else
                    return false;
            return false;
        }

        public bool RemoveFromPriceGroup(GridState gs, IList<Filters.IFilter> filters, PriceGroup priceGroup)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            Currency toCurrency = null;
            if (gs.ShowInCurrency != null && gs.ShowInCurrency > 0)
                ControllerManager.Currency.GetById((int)gs.ShowInCurrency);

            return RemoveFromPriceGroup(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, gs.MarkedAll, gs.Items, gs.SearchDate, MembershipHelper.GetUser().UserId, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor, toCurrency);
        }

        private bool RemoveFromPriceGroup(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, Guid userId, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            #region Save history of WorkListItem and Erase them
            // DELETE CORRESPONDING RECORDS
            DeleteWLIListForPG(description, category, cTR, list, frequency, currency, markedAll, selecteditems, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            #endregion

            #region Save history PriceAttribute and erase them
            DeletePAListForPG(description, category, cTR, list, frequency, currency, markedAll, selecteditems, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            #endregion

            return true;
        }

        private void DeletePAListForPG(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string plsql = GetProductListHQL("PA.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            string deleteSql = "DELETE FROM PriceAttribute";
            deleteSql += " WHERE ID IN (" + plsql + ")";

            IQuery q = NHibernateSession.CreateQuery(deleteSql);

            CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                             0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                             null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            q.ExecuteUpdate();
        }

        private IList<PriceAttribute> GetPAListForPG(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPA = GetProductListHQL("DISTINCT PA", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            IQuery q = NHibernateSession.CreateQuery(selectPA);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            return q.List<PriceAttribute>();
        }

        private void DeleteWLIListForPG(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPA = GetProductListHQL("PA.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            
            string deleteSql = "DELETE FROM WorkListItem";
            deleteSql += " WHERE PriceAttribute.ID IN (" + selectPA + ")";

            IQuery q = NHibernateSession.CreateQuery(deleteSql);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            q.ExecuteUpdate();
        }

        private IList<WorkListItem> GetWLIListForPG(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency)
        {
            string selectPA = GetProductListHQL("DISTINCT PA.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            string selectWLI = "SELECT DISTINCT WLI_";
            selectWLI += " FROM ProductInfoByPriceList PI_";
            selectWLI += " JOIN PI_.WorkListItem WLI_";
            selectWLI += " JOIN WLI_.PriceAttribute PA_";
            selectWLI += " JOIN PA_.PriceGroup PG_";
            selectWLI += " JOIN PA_.PriceBase PB_";
            selectWLI += " JOIN PB_.Product P_";
            selectWLI += " WHERE PB_.Status = " + (int)PriceBaseStatus.Verified;
            selectWLI += " AND P_.Status = " + (int)ProductStatus.Active;
            selectWLI += " AND PA_.ID IN (" + selectPA + ")";

            IQuery q = NHibernateSession.CreateQuery(selectWLI);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            return q.List<WorkListItem>();
        }

        #endregion

        public IList<PriceBase> GetListFromPBList(List<int> pblist)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.In("ID", pblist));
            return crit.List<PriceBase>();
        }
    }
}
