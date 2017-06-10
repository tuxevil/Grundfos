using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Business.Filters;
using PriceManager.Common;
using PriceManager.Core;
using PriceManager.Business.Actions;
using System.Collections.Generic;
using ProjectBase.Data;
using NybbleMembership.Core.Domain;
using NybbleMembership;
using PriceManager;



namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class PriceMasterList : System.Web.UI.UserControl
    {
        #region PrivateStrings
        private const string ERASE_COMMAND = "EraseList";
        private const string PROVIDER_ACTIVITY_COMMAND = "ProviderActivity";
        private const string DISTRIBUTOR_ACTIVITY_COMMAND = "DistributorActivity";
        private const string ERASE_CATEGORY_COMMAND = "EraseCategory";
        private const string UPDATE_CURRENCY_COMMAND = "UpdateCurrency";
        private const string ERASE_LOOKUP_COMMAND = "EraseLookup";
        private const string ERASE_PRICECALCULATION_COMMAND = "ErasePriceCalculation";
        private const string REJECT_QUOTE_COMMAND = "RejectQuote";
        private const string ROLLBACK_BASEHISTORY_COMMAND = "RollbackBaseHistory";
        private const string ROLLBACK_ATTRIBUTEHISTORY_COMMAND = "RollbackAttributeHistory";
        private const string ROLLBACK_WORKLISTITEMHISTORY_COMMAND = "RollbackPriceListHistory";
        private const string PAGELIST_ACTIVITY_COMMAND = "PageListActivity";
        #endregion

        #region Custom Properties

        private int _priceGroupID = 0;
        public int PriceGroupID
        {
            get
            {
                if (_priceGroupID == 0 && ViewState["PriceGroup"] != null)
                    _priceGroupID = Convert.ToInt32(ViewState["PriceGroup"]);

                return _priceGroupID;
            }
            set { ViewState["PriceGroup"] = value; }
        }

        public PriceGroup PriceGroup
        {
            get
            {
                return (PriceGroupID != 0) ? new PriceGroup(PriceGroupID) : null;
            }
            
        }

        private int _priceListID = 0;
        public int PriceListID
        {
            get
            {
                if (_priceListID == 0 && ViewState["PriceListId"] != null)
                    _priceListID = Convert.ToInt32(ViewState["PriceListId"]);

                return _priceListID;
            }
            set { ViewState["PriceListId"] = value; }
        }

        private int _publishListId = 0;
        public int PublishListID
        {
            get
            {
                if (_publishListId == 0 && ViewState["PublishListID"] != null)
                    _publishListId = Convert.ToInt32(ViewState["PublishListID"]);

                return _publishListId;
            }
            set { ViewState["PublishListID"] = value; }
        }

        private int _distributorId = 0;
        public int DistributorID
        {
            get
            {
                if (_distributorId == 0 && ViewState["DistributorID"] != null)
                    _distributorId = Convert.ToInt32(ViewState["DistributorID"]);

                return _distributorId;
            }
            set { ViewState["DistributorID"] = value; }
        }

        public PriceList PriceList
        {
            get
            {
                return (PriceListID != 0) ? new PriceList(PriceListID) : null;
            }

        }

        private int _productId = 0;
        public int ProductId
        {
            get
            {
                if (_productId == 0 && ViewState["ProductId"] != null)
                    _productId = Convert.ToInt32(ViewState["ProductId"]);

                return _productId;
            }
            set { ViewState["ProductId"] = value; }
        }

        public Product Product
        {
            get 
            {
                return (ProductId != 0) ? new Product(ProductId) : null;
            }
        }

        private int _providerId = 0;
        public int ProviderId
        {
            get
            {
                if (_providerId == 0 && ViewState["ProviderId"] != null)
                    _providerId = Convert.ToInt32(ViewState["ProviderId"]);

                return _providerId;
            }
            set { ViewState["ProviderId"] = value; }
        }

        public Provider Provider
        {
            get
            {
                return (ProviderId != 0) ? new Provider(ProviderId) : null;
            }
        }

        private int _CatalogPageId = 0;
        public int CatalogPageID
        {
            get
            {
                if (_CatalogPageId == 0 && ViewState["CatalogPageID"] != null)
                    _CatalogPageId = Convert.ToInt32(ViewState["CatalogPageID"]);

                return _CatalogPageId;
            }
            set { ViewState["CatalogPageID"] = value; }
        }

        public CatalogPage CatalogPage
        {
            get
            {
                return (CatalogPageID != 0) ? new CatalogPage(CatalogPageID) : null;
            }
        }
        

        private int _LookUpId = 0;
        public int LookUpId
        {
            get
            {
                if (_LookUpId == 0 && ViewState["LookUpId"] != null)
                    _LookUpId = Convert.ToInt32(ViewState["LookUpId"]);

                return _LookUpId;
            }
            set { ViewState["LookUpId"] = value; }
        }

        private int _QuoteId = 0;
        public int QuoteId
        {
            get
            {
                if (_QuoteId == 0 && ViewState["QuoteId"] != null)
                    _QuoteId = Convert.ToInt32(ViewState["QuoteId"]);

                return _QuoteId;
            }
            set { ViewState["QuoteId"] = value; }
        }


        public Lookup LookUp
        {
            get
            {
                return (LookUpId != 0) ? new Lookup(LookUpId) : null;
            }
        }
        public GridState GridState
        {
            get { return GridHelper.State; }
        }

        public IList<IFilter> Filters
        {
            get { return ucFilters.GetFiltersApplied(); }
        }

        public string HidSelChecks
        {
            get { return hidSelChecks.Value; }
            set { hidSelChecks.Value = value; }
        }

        private bool _SaveSelectedItems;
        public bool SaveSelectedItems
        {
            get
            {
                if (ViewState["SaveSelectedItems"] != null)
                    _SaveSelectedItems = Convert.ToBoolean(ViewState["SaveSelectedItems"]);

                return _SaveSelectedItems;
            }
            set { ViewState["SaveSelectedItems"] = value; } 
        }

        private List<string> _SelectedItems;
        public List<string> SelectedItems
        {
            get
            {
                if (ViewState["SelectedItems"] != null)
                    _SelectedItems = ViewState["SelectedItems"] as List<string>;

                return _SelectedItems;
            }
            set { ViewState["SelectedItems"] = value; }
        }

        #endregion

        #region Set Filters
        private void SetFilters()
        {
            if (Type != MasterListType.ProductsBaseHistory && Type != MasterListType.ProductPriceAttributeHistory &&
                Type != MasterListType.ProductWorkListItemHistory && Type != MasterListType.CurrencyView && Type != MasterListType.PriceGroupDetailsView
                && Type != MasterListType.PageListChilds)
            {
                ucFilters.AddFilter(new SearchFilter());
                if (Type != MasterListType.Distributors && Type != MasterListType.ProvidersView &&
                    Type != MasterListType.CategoryView && Type != MasterListType.LookupView &&
                    Type != MasterListType.PriceCalculation && Type != MasterListType.QuoteView &&
                    Type != MasterListType.QuoteProductsView && Type != MasterListType.QuoteProductsCreate &&
                    Type != MasterListType.PageList)
                    ucFilters.AddFilter(new RangeFilter("TimeStampCheck"));

                if (Type != MasterListType.Import && Type != MasterListType.PriceList && Type != MasterListType.Distributors && 
                    Type != MasterListType.ProductsView && Type != MasterListType.ProvidersView && Type != MasterListType.ProviderAssignedProducts
                    && Type != MasterListType.CategoryView && Type != MasterListType.LookupView && Type != MasterListType.PriceCalculation
                    && Type != MasterListType.QuoteView && Type != MasterListType.QuoteProductsView && Type != MasterListType.QuoteProductsCreate &&
                    Type != MasterListType.PageList && Type != MasterListType.PageListProducts)
                {
                    ucFilters.AddFilter(new ProviderFilter());
                    ucFilters.AddFilter(new FamilyFilter());
                    if (Type == MasterListType.PriceListModifiedProducts || Type == MasterListType.PublishListProducts || Type == MasterListType.PriceListProducts)
                        ucFilters.AddFilter(new CatalogPageFilter(true));
                    else
                        ucFilters.AddFilter(new CatalogPageFilter());
                    ucFilters.AddFilter(new ApplicationFilter());
                    ucFilters.AddFilter(new ProductTypeFilter());
                    ucFilters.AddFilter(new LineFilter());
                    ucFilters.AddFilter(new AreaFilter());
                    ucFilters.AddFilter(new CtrRangeFilter());
                    ucFilters.AddFilter(new IndexFilter());
                    ucFilters.AddFilter(new SelectionFilter());
                    if(Type == MasterListType.MasterPriceView)
                        ucFilters.AddFilter(new CurrencyFilter());
                    ucFilters.AddFilter(new PriceImportFilter());
                    ucFilters.AddFilter(new FixedFilter(typeof(PriceGroup), "ID", false));
                    ucFilters.AddFilter(new PriceListFrequencyFilter());
                    //ucFilters.AddFilter(new FrequencyFilter());
                }
            }

                switch (Type)
                {
                    case MasterListType.MasterPriceView:
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                        break;

                    case MasterListType.OutOfGroupView:
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.NotVerified), PriceBaseStatus.NotVerified));
                        break;

                    case MasterListType.PriceGroupView:
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                        break;

                    case MasterListType.AdminView:
                        //ucFilters.AddFilter(new ProductStatusFilter());
                        ucFilters.AddFilter(new PriceBaseStatusFilter());
                        break;

                    case MasterListType.PriceList:
                        ucFilters.AddFilter(new PriceListDistributorFilter());
                        ucFilters.AddFilter(new PriceListFrequencyFilter());
                        ucFilters.AddFilter(new IncotermFilter());
                        ucFilters.AddFilter(new PriceListStatusFilter());
                        ucFilters.AddFilter(new PriceGroupFilter());
                        ucFilters.AddFilter(new PriceListTypeFilter());
                        ucFilters.AddFilter(new CatalogPageFilter(true));
                        break;

                    case MasterListType.PriceListProducts:
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceList), "ID", false));
                        ucFilters.AddFilter(new WorkListItemStatusFilter());
                        break;

                    case MasterListType.PriceListModifiedProducts:
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                        ucFilters.AddFilter(new FixedFilter(typeof(PriceList), "ID", false));
                        ucFilters.AddFilter(new FixedFilter(typeof(WorkListItemStatus), "ID", EnumHelper.GetDescription(WorkListItemStatus.Modified), WorkListItemStatus.Modified));
                        break;

                    case MasterListType.PublishListProducts:
                        //ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        //ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                        ucFilters.AddFilter(new FixedFilter(typeof(PublishList), "ID", false));
                        break;
                    case MasterListType.DistributorCurrentPriceList:
                        //ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        //ucFilters.AddFilter(new FixedFilter(typeof(PriceBaseStatus), "ID", EnumHelper.GetDescription(PriceBaseStatus.Verified), PriceBaseStatus.Verified));
                        ucFilters.AddFilter(new FixedFilter(typeof(PublishList), "ID", false));
                        ucFilters.AddFilter(new FixedFilter(typeof(Distributor), "ID", false));
                        break;

                    case MasterListType.Distributors:
                        ucFilters.AddFilter(new CountryFilter());
                        ucFilters.AddFilter(new PriceListFilter());
                        ucFilters.AddFilter(new PaymentTermFilter());
                        ucFilters.AddFilter(new DistributorStatusFilter());
                        ucFilters.AddFilter(new IncotermFilter());
                        ucFilters.AddFilter(new DistributorTypeFilter());
                        ucFilters.AddFilter(new CatalogPageFilter(true));
                        break;
                    case MasterListType.ProductsView:
                        ucFilters.AddFilter(new ProviderFilter());
                        ucFilters.AddFilter(new FamilyFilter());
                        ucFilters.AddFilter(new CatalogPageFilter());
                        ucFilters.AddFilter(new ApplicationFilter());
                        ucFilters.AddFilter(new ProductTypeFilter());
                        ucFilters.AddFilter(new LineFilter());
                        ucFilters.AddFilter(new AreaFilter());
                        ucFilters.AddFilter(new PriceListFrequencyFilter());
                        ucFilters.AddFilter(new SelectionFilter());
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        break;
                    case MasterListType.ProductsBaseHistory:
                        ucFilters.AddFilter(new FixedFilter(typeof(Product), "ID", false));
                        break;
                    case MasterListType.ProductPriceAttributeHistory:
                        ucFilters.AddFilter(new FixedFilter(typeof(Product), "ID", false));
                        ucFilters.AddFilter(new PriceGroupFilter());
                        break;
                    case MasterListType.ProductWorkListItemHistory:
                        ucFilters.AddFilter(new FixedFilter(typeof(Product), "ID", false));
                        ucFilters.AddFilter(new PriceListFilter());
                        break;
                    case MasterListType.ProvidersView:
                        ucFilters.AddFilter(new CountryFilter());
                        ucFilters.AddFilter(new ProviderStatusFilter());
                        ucFilters.AddFilter(new IncotermFilter());
                        break;
                    case MasterListType.ProviderAssignedProducts:
                        ucFilters.AddFilter(new FixedFilter(typeof(Provider), "ID", false));
                        ucFilters.AddFilter(new FamilyFilter());
                        ucFilters.AddFilter(new CatalogPageFilter());
                        ucFilters.AddFilter(new ApplicationFilter());
                        ucFilters.AddFilter(new ProductTypeFilter());
                        ucFilters.AddFilter(new LineFilter());
                        ucFilters.AddFilter(new AreaFilter());
                        ucFilters.AddFilter(new PriceListFrequencyFilter());
                        ucFilters.AddFilter(new SelectionFilter());
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        break;
                    case MasterListType.CategoryView:
                        //ucFilters.AddFilter(new CategoryTypeFilter());
                        //ucFilters.AddFilter(new CategoryBaseFilter());
                        ucFilters.AddFilter(new LinkedDropDownFilters());
                        break;
                    case MasterListType.LookupView:
                        ucFilters.AddFilter(new LookupTypeFilter());
                        break;
                    case MasterListType.PriceCalculation:
                        ucFilters.AddFilter(new ProviderFilter());
                        ucFilters.AddFilter(new FamilyFilter());
                        ucFilters.AddFilter(new CatalogPageFilter());
                        ucFilters.AddFilter(new ApplicationFilter());
                        ucFilters.AddFilter(new ProductTypeFilter());
                        ucFilters.AddFilter(new LineFilter());
                        ucFilters.AddFilter(new AreaFilter());
                        ucFilters.AddFilter(new PoliticsPriorityFilter());
                        break;
                    case MasterListType.QuoteView:
                        ucFilters.AddFilter(new DistributorFilter());
                        ucFilters.AddFilter(new QuoteStatusFilter());
                        ucFilters.AddFilter(new UserFilter());
                        break;
                    case MasterListType.QuoteProductsView:
                        ucFilters.AddFilter(new ProviderFilter());
                        ucFilters.AddFilter(new FamilyFilter());
                        ucFilters.AddFilter(new CatalogPageFilter());
                        ucFilters.AddFilter(new ApplicationFilter());
                        ucFilters.AddFilter(new ProductTypeFilter());
                        ucFilters.AddFilter(new LineFilter());
                        ucFilters.AddFilter(new AreaFilter());
                        ucFilters.AddFilter(new PriceListFrequencyFilter());
                        ucFilters.AddFilter(new SelectionFilter());
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        break;
                    case MasterListType.QuoteProductsCreate:
                        ucFilters.AddFilter(new ProviderFilter());
                        ucFilters.AddFilter(new FamilyFilter());
                        ucFilters.AddFilter(new CatalogPageFilter());
                        ucFilters.AddFilter(new ApplicationFilter());
                        ucFilters.AddFilter(new ProductTypeFilter());
                        ucFilters.AddFilter(new LineFilter());
                        ucFilters.AddFilter(new AreaFilter());
                        ucFilters.AddFilter(new PriceListFrequencyFilter());
                        ucFilters.AddFilter(new SelectionFilter());
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        break;
                    case MasterListType.Import:
                        ucFilters.AddFilter(new ImportStatusFilter());
                        break;
                    case MasterListType.PageList:
                        ucFilters.AddFilter(new FixedFilter(typeof(CategoryType), "ID", EnumHelper.GetDescription(CategoryType.CatalogPage), CategoryType.CatalogPage));
                        ucFilters.AddFilter(new CatalogPageParentFilter());
                        //ucFilters.AddFilter(new CategoryPageStatusFilter());
                        break;
                    case MasterListType.PageListProducts:
                        ucFilters.AddFilter(new ProviderFilter());
                        ucFilters.AddFilter(new PriceListFrequencyFilter());
                        ucFilters.AddFilter(new SelectionFilter());
                        ucFilters.AddFilter(new FixedFilter(typeof(ProductStatus), "ID", EnumHelper.GetDescription(ProductStatus.Active), ProductStatus.Active));
                        ucFilters.AddFilter(new FixedFilter(typeof(CatalogPage), "ID", false));
                        break;
                    case MasterListType.PageListChilds:
                        ucFilters.AddFilter(new FixedFilter(typeof(CatalogPage), "ID", false));
                        break;
            }
        }
        #endregion

        #region Set Actions
        private void SetActions()
        {
                if (Type != MasterListType.Import && Type != MasterListType.ProductsView &&
                    Type != MasterListType.ProvidersView && Type != MasterListType.ProviderAssignedProducts && Type != MasterListType.CategoryView &&
                    Type != MasterListType.PriceCalculation && Type != MasterListType.QuoteProductsView && Type != MasterListType.QuoteProductsCreate
                    )
                {
                    IAction action;
                    if (Type != MasterListType.PageList && Type != MasterListType.PageListProducts && Type != MasterListType.Distributors)
                    {
                        action = new ExportToExcelAction();
                        action.ID = "btnExportExcel";
                        AddAction(action, false);

                        action = new ExportToPdfAction();
                        action.ID = "btnExportPDF";
                        AddAction(action, false);

                        action = new MoveToSelectionAction();
                        action.ID = "btnMoveToSelection";
                        AddAction(action);

                        action = new EraseFromSelectionAction();
                        action.ID = "lnkEraseFromSelection";
                        action.Visible = false;
                        AddAction(action);
                    }
                    switch (Type)
                    {
                        case MasterListType.MasterPriceView:

                            action = new MoveProductsToOutOfListAction();
                            action.ID = "btnTakeOutOfMasterList";
                            AddAction(action);

                            action = new MoveToPricegroupAction();
                            action.ID += "btnMoveToPriceGroup";
                            AddAction(action);

                            action = new ModifyPricesAction();
                            action.ID = "btnModifyPrices";
                            AddAction(action);

                            //action = new DeactivateProductsAction();
                            //action.ID = "btnDeactivateProduct";
                            //AddAction(action);

                            break;

                        case MasterListType.OutOfGroupView:
                            action = new AddProductsToMasterListAction();
                            action.ID = "AddToMasterList";
                            AddAction(action);

                            action = new DeactivateProductsAction();
                            action.ID = "btnDeactivateProduct";
                            AddAction(action);

                            break;

                        case MasterListType.PriceGroupView:
                            action = new ModifyPricesAction();
                            action.ID = "btnModifyPrices";
                            AddAction(action);

                            action = new MoveProductsToBaseListAction();
                            action.ID = "btnTakeOutOfPriceGroup";
                            AddAction(action);

                            action = new MoveToPriceListAction();
                            action.ID = "btnMoveToPriceList";
                            AddAction(action);

                            break;

                        case MasterListType.Distributors:
                            
                            action = new AddDistributorsToPriceListAction();
                            action.ID = "btnMoveDistributorsToPriceList";
                            AddAction(action);

                            break;

                        case MasterListType.AdminView:

                            action = new MoveProductsToOutOfListAction();
                            action.ID = "btnTakeOutOfMasterList";
                            AddAction(action);

                            action = new MoveToCategoryAction();
                            action.ID += "btnMoveToCategory";
                            AddAction(action);

                            action = new TakeOutFromCategoryAction();
                            action.ID = "btnTakeOutFromCategory";
                            AddAction(action);

                            action = new DeactivateProductsAction();
                            action.ID = "btnDeactivateProduct";
                            action.Visible = false;
                            AddAction(action);

                            action = new ActivateProductsAction();
                            action.ID = "btnActivateProduct";
                            action.Visible = false;
                            AddAction(action);

                            action = new AddToPagelistAction();
                            action.ID += "btnAddToPageList";
                            AddAction(action);
                            
                            break;

                        case MasterListType.PriceListProducts:

                            action = new ModifyPricesAction();
                            action.ID = "btnModifyPrices";
                            AddAction(action);

                            action = new EraseFromPriceListAction();
                            action.ID = "lnkEraseFromPriceList";
                            AddAction(action);
                            break;

                        case MasterListType.PriceListModifiedProducts:

                            action = new ApprovePriceListItemsAction();
                            action.ID = "lnkApprovePriceListItems";
                            action.Visible = false;
                            AddAction(action);

                            action = new RejectPriceListItemsAction();
                            action.ID = "lnkRejectPriceListItems";
                            action.Visible = false;
                            AddAction(action);
                            break;
                        case MasterListType.PageList:
                            action = new AddPagesToPriceListAction();
                            action.ID = "btnMovePagesToPriceList";
                            AddAction(action);
                            break;
                        case MasterListType.PageListProducts:
                            action = new EraseFromCatalogPageAction();
                            action.ID = "btnEraseFromCatalogPageAction";
                            AddAction(action);
                            break;
                    }
                }
                else if(Type == MasterListType.ProductsView)
                {
                    
                }

        }
        #endregion

        #region Set Columns

        private void SetColumns()
        {
            ExecutePermissionValidator epv;
            switch (Type)
            {
                case MasterListType.Import:
                    #region Import Fields
                    BoundField bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "File";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFile");
                    bf.SortExpression = "File";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    TemplateField tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "TimeStamp", "ModifiedBy");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnUser");
                    tc.SortExpression = "TimeStamp.ModifiedBy";
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);


                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "ImportView", "AmountNew");
                    tc.SortExpression = "ImportView.AmountNew";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnImportNew");
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "ImportView", "AmountChange");
                    tc.SortExpression = "ImportView.AmountChange";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnImportMod");
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "ImportView", "AmountError");
                    tc.SortExpression = "ImportView.AmountError";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnImportError");
                    grdItems.Columns.Add(tc);
                   
                    bf = new BoundField();
                    bf.DataField = "DateImported";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDate");
                    bf.SortExpression = "DateImported";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "ImportStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "ImportStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);
                    #endregion
                    break;
                case MasterListType.PriceList:
                    #region PriceList
                    bf = new BoundField();
                    bf.DataField = "ID";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnListID");
                    bf.SortExpression = "ID";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnListName");
                    bf.SortExpression = "Name";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Frecuency";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "Frecuency";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnType");
                    bf.SortExpression = "Type";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "SaleCondition";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnIncoterm");
                    bf.SortExpression = "SaleCondition";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "CurrentState", "LastPublishedOn");
                    tc.SortExpression = "CurrentState.PublishOn";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnPublishDate");
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "CurrentState", "PublishOn");
                    tc.SortExpression = "CurrentState.LastPublishedOn";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnVigencyDate");
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "CurrentState", "PendingToApprovecount");
                    tc.SortExpression = "CurrentState.PendingToApproveCount";
                    tc.HeaderText = Resource.Business.GetString("PendingToApprovecount");
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "CurrentState", "Status");
                    tc.SortExpression = "CurrentState.Status";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    tc.HeaderStyle.CssClass = "textalign";
                    tc.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "PriceGroup", "Name");
                    tc.SortExpression = "PriceGroup.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnListCountry");
                    tc.HeaderStyle.CssClass = "textalign";
                    tc.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(PriceList);
                    epv.KeyIdentifier = Config.PriceListActivity;

                    ButtonField btf = new ButtonField();
                    btf.Text = "[x]";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.CommandName = ERASE_COMMAND;
                    btf.ImageUrl = "~/img/activate.png";
                    btf.Visible = PermissionManager.Check(epv);
                    btf.ButtonType = ButtonType.Image;

                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.Distributors:
                    #region Distributors
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDistributorName");
                    bf.SortExpression = "Name";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Discount";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDiscount");
                    bf.SortExpression = "Discount";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "PriceList", "Name");
                    tc.SortExpression = "PriceList.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnListName");
                    tc.HeaderStyle.CssClass = "textalign";
                    tc.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnType");
                    bf.SortExpression = "Type";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "SaleConditions";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnIncoterm");
                    bf.SortExpression = "SaleConditions";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "DistributorStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "DistributorStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "PaymentTerm", "Description");
                    tc.SortExpression = "PaymentTerm.Description";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnPaymentTerm");
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Country", "Name");
                    tc.SortExpression = "Country.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnCountry");
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(Distributor);
                    epv.KeyIdentifier = Config.DistributorActivity;

                    btf = new ButtonField();
                    //btf.Text = "Activar/Desactivar";
                    btf.ButtonType = ButtonType.Image;
                    btf.ImageUrl = "~/img/activate.png";
                    btf.CausesValidation = true;
                    btf.CommandName = DISTRIBUTOR_ACTIVITY_COMMAND;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.ProductsView:
                    #region ProductsView
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "P.Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Model";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnModel");
                    bf.SortExpression = "P.Model";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "P.Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Frequency";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "P.Frequency";
                    grdItems.Columns.Add(bf);

                    #endregion
                    break;
                case MasterListType.ProductsBaseHistory:
                    #region ProductsBaseHistory
                    
                    bf = new BoundField();
                    bf.DataField = "ModifiedOn";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDate");
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "ModifiedBy";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnUser");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Provider";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProvider");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(ProductListView);
                    epv.KeyIdentifier = Config.TpColumn;
                    bf = new BoundField();

                    bf = new BoundField();
                    bf.DataField = "PricePurchase";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnTP");
                    bf.SortExpression = "PricePurchase";
                    bf.HeaderStyle.CssClass = "price";
                    bf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(ProductListView);
                    epv.KeyIdentifier = Config.GrpColumn;

                    bf = new BoundField();
                    bf.DataField = "PriceSuggest";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnGRP");
                    bf.SortExpression = "PriceSuggest";
                    bf.HeaderStyle.CssClass = "price";
                    bf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Price";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnNetPrice");
                    bf.SortExpression = "PriceList";
                    bf.HeaderStyle.CssClass = "price";
                    grdItems.Columns.Add(bf);

                    //If User == Admin
                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(ProductListView);
                    epv.KeyIdentifier = Config.ProductListField;

                    btf = new ButtonField();
                    btf.Text = "[RollBack]";
                    btf.CommandName = ROLLBACK_BASEHISTORY_COMMAND;
                    btf.ImageUrl = "~/img/rollback.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.ProductPriceAttributeHistory:
                    #region ProductPriceAttributeHistory

                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "TimeStamp", "ModifiedOn");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnDate");
                    tc.SortExpression = "TimeStamp.ModifiedOn";
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "TimeStamp", "ModifiedBy");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnUser");
                    tc.SortExpression = "TimeStamp.ModifiedBy";
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "PriceCurrency", "Description");
                    tc.SortExpression = "PriceCurrency.Description";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnCurrency");
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "Price";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnPrice");
                    bf.SortExpression = "Price";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "PriceGroup", "Name");
                    tc.SortExpression = "PriceGroup.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnName");
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "HistoryStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "HistoryStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    //If User == Admin
                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(PriceAttributeHistory);
                    epv.KeyIdentifier = Config.PriceAttributeHistoryField;

                    btf = new ButtonField();
                    btf.Text = "[RollBack]";
                    btf.CommandName = ROLLBACK_ATTRIBUTEHISTORY_COMMAND;
                    btf.ImageUrl = "~/img/rollback.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.ProductWorkListItemHistory:
                    #region ProductWorkListItemHistory
                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "TimeStamp", "ModifiedOn");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnDate");
                    tc.SortExpression = "TimeStamp.ModifiedOn";
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "TimeStamp", "ModifiedBy");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnUser");
                    tc.SortExpression = "TimeStamp.ModifiedBy";
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "PriceCurrency", "Description");
                    tc.SortExpression = "PriceCurrency.Description";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnCurrency");
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "Price";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnPrice");
                    bf.SortExpression = "Price";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate = new PropertyTemplateField(DataControlRowType.DataRow, "PriceList", "Name");
                    tc.SortExpression = "PriceList.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnListName");
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "HistoryStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "HistoryStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    //If User == Admin
                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(WorkListItemHistory);
                    epv.KeyIdentifier = Config.WorkListItemHistoryField;

                    btf = new ButtonField();
                    btf.Text = "[RollBack]";
                    btf.CommandName = ROLLBACK_WORKLISTITEMHISTORY_COMMAND;
                    btf.ImageUrl = "~/img/rollback.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.ProvidersView:
                    #region Providers
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnName");
                    bf.SortExpression = "Name";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "SaleConditions";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnIncoterm");
                    bf.SortExpression = "SaleConditions";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Country", "Name");
                    tc.SortExpression = "Country.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnCountry");
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "ProviderStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "ProviderStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(Provider);
                    epv.KeyIdentifier = Config.ProviderActivity;

                    btf = new ButtonField();
                    btf.ButtonType = ButtonType.Image;
                    btf.ImageUrl = "~/img/activate.png";
                    btf.CausesValidation = true;
                    btf.CommandName = PROVIDER_ACTIVITY_COMMAND;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);

                    #endregion
                    break;
                case MasterListType.ProviderAssignedProducts:
                    #region ProviderAssignedProducts
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Model";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnModel");
                    bf.SortExpression = "Model";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "Description";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Frequency";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "Frequency";
                    grdItems.Columns.Add(bf);

                    #endregion
                    break;
                case MasterListType.CategoryView:
                    #region CategoryView
                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnType");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Parent", "Name");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnParent");
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnName");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(CategoryBase);
                    epv.KeyIdentifier = Config.CategoryEraseColumn;

                    btf = new ButtonField();
                    btf.Text = "[x]";
                    btf.CommandName = ERASE_CATEGORY_COMMAND;
                    btf.ImageUrl = "~/img/delete.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.CurrencyView:
                    #region CurrencyView
                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "LastCurrencyRateView", "Rate");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnConvertionFactor");
                    grdItems.Columns.Add(tc);
                    
                    //bf = new BoundField();
                    //bf.DataField = "Value";
                    //bf.HeaderText = Resource.Business.GetString("GridViewColumnValue");
                    //grdItems.Columns.Add(bf);

                    //If User == Admin
                    btf = new ButtonField();
                    btf.Text = "Actualizar";
                    btf.CommandName = UPDATE_CURRENCY_COMMAND;
                    btf.ImageUrl = "~/img/update.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.LookupView:
                    #region LookupView
                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "LookupType";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnLookupType");
                    bf.SortExpression = "LookupType";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(Lookup);
                    epv.KeyIdentifier = Config.LookUpEraseColumn;

                    btf = new ButtonField();
                    btf.Text = "[x]";
                    btf.ButtonType = ButtonType.Image;
                    btf.ImageUrl = "~/img/delete.png";
                    btf.CausesValidation = true;
                    btf.CommandName = ERASE_LOOKUP_COMMAND;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.PriceCalculation:
                    #region PriceCalculation

                    bf = new BoundField();
                    bf.DataField = "ProviderName";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProvider");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "CategoryName";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCategory");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);


                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(PriceCalculation);
                    epv.KeyIdentifier = Config.PriceCalculationFormulasField;

                    bf = new BoundField();
                    bf.DataField = "MainFormula";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFormula");
                    bf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "SecFormula";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFormulaSec");
                    bf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Priority";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnPriority");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(PriceCalculation);
                    epv.KeyIdentifier = Config.PriceCalculationActivity;

                    btf = new ButtonField();
                    btf.Text = "[x]";
                    btf.CommandName = ERASE_PRICECALCULATION_COMMAND;
                    btf.ImageUrl = "~/img/delete.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.QuoteView:
                    #region QuoteView

                    bf = new BoundField();
                    bf.DataField = "Number";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnNumber");
                    bf.SortExpression = "Number";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Distributor", "Name");
                    tc.SortExpression = "Distributor.Name";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnDistributor");
                    tc.HeaderStyle.CssClass = "textalign";
                    tc.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Observations";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnObservations");
                    bf.SortExpression = "Observations";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "TimeStamp", "ModifiedBy");
                    tc.SortExpression = "TimeStamp.ModifiedBy";
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnUser");
                    tc.HeaderStyle.CssClass = "textalign";
                    tc.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "Status";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "Status";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    epv = new ExecutePermissionValidator();
                    epv.ClassType = typeof(Quote);
                    epv.KeyIdentifier = Config.QuoteEraseColumn;

                    btf = new ButtonField();
                    //btf.Text = "[Rechazar]";
                    //btf.ImageUrl = "~/img/reject.png";
                    btf.ButtonType = ButtonType.Image;
                    btf.CausesValidation = true;
                    btf.CommandName = REJECT_QUOTE_COMMAND;
                    btf.Visible = PermissionManager.Check(epv);
                    grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.PriceGroupDetailsView:
                    #region PriceGroupDetailsView
                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnName");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Adjust";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnAdjust");
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "PriceSuggestCoef";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnGRP");
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Currency", "Description");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnListCurrency");
                    grdItems.Columns.Add(tc);
                    #endregion
                    break;
                case MasterListType.QuoteProductsView:
                    #region QuoteProductsView
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "P.Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "FinalInfo";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnModel");
                    bf.SortExpression = "P.Model";
                    bf.ItemStyle.CssClass = "description";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "P.Description";
                    bf.ItemStyle.CssClass = "description";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "P.Frequency";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Provider";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProvider");
                    bf.SortExpression = "PV.Name";
                    grdItems.Columns.Add(bf);

                    #endregion
                    break;
                case MasterListType.QuoteProductsCreate:
                    #region QuoteProductsCreate
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "P.Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "FinalInfo";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnModel");
                    bf.SortExpression = "P.Model";
                    bf.ItemStyle.CssClass = "description";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "P.Frequency";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Provider";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProvider");
                    bf.SortExpression = "PV.Name";
                    grdItems.Columns.Add(bf);

                    #endregion
                    break;
                case MasterListType.PageList:
                    #region PageList(New PriceLists)
                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnName");
                    bf.SortExpression = "Name";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Parent", "Name");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnParent");
                    tc.SortExpression = "Parent.Name";
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "CategoryPageStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    bf.SortExpression = "CategoryPageStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "TotalCount";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProductsTotal");
                    bf.SortExpression = "TotalCount";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "ChildCount";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnChildTotal");
                    //bf.SortExpression = "TotalCount";
                    grdItems.Columns.Add(bf);

                    //btf = new ButtonField();
                    //btf.ButtonType = ButtonType.Image;
                    //btf.ImageUrl = "~/img/activate.png";
                    //btf.CausesValidation = true;
                    //btf.CommandName = PAGELIST_ACTIVITY_COMMAND;
                    ////btf.Visible = PermissionManager.Check(epv);
                    //grdItems.Columns.Add(btf);
                    #endregion
                    break;
                case MasterListType.PageListProducts:
                    #region PageListProducts
                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "P.Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Model";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnModel");
                    bf.SortExpression = "P.Model";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    bf.SortExpression = "P.Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Frequency";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "P.Frequency";
                    grdItems.Columns.Add(bf);

                    #endregion
                    break;
                case MasterListType.PageListChilds:
                    #region PageListChilds

                    bf = new BoundField();
                    bf.DataField = "Name";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnName");
                    //bf.SortExpression = "Name";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Description";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnDescription");
                    //bf.SortExpression = "Description";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    tc = new TemplateField();
                    tc.ItemTemplate =
                        new PropertyTemplateField(DataControlRowType.DataRow, "Parent", "Name");
                    tc.HeaderText = Resource.Business.GetString("GridViewColumnParent");
                    //tc.SortExpression = "Parent.Name";
                    tc.ItemStyle.CssClass = "textalign";
                    tc.HeaderStyle.CssClass = "textalign";
                    grdItems.Columns.Add(tc);

                    bf = new BoundField();
                    bf.DataField = "CategoryPageStatus";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                    //bf.SortExpression = "CategoryPageStatus";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "TotalCount";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProductsTotal");
                    //bf.SortExpression = "TotalCount";
                    grdItems.Columns.Add(bf);

                    //btf = new ButtonField();
                    //btf.ButtonType = ButtonType.Image;
                    //btf.ImageUrl = "~/img/activate.png";
                    //btf.CausesValidation = true;
                    //btf.CommandName = PAGELIST_ACTIVITY_COMMAND;
                    ////btf.Visible = PermissionManager.Check(epv);
                    //grdItems.Columns.Add(btf);

                    #endregion
                    break;
                default:
                    #region Master Price List Fields
                    
                    if (Type == MasterListType.MasterPriceView || Type == MasterListType.PriceGroupView || 
                        Type == MasterListType.PriceListProducts)
                    {
                        //Example on how check "ExecutePermission" permission´s
                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        switch (Type)
                        {
                            case MasterListType.MasterPriceView:
                                epv.KeyIdentifier = Config.SingleModificationMasterPriceView;
                                break;
                            case MasterListType.PriceGroupView:
                                epv.KeyIdentifier = Config.SingleModificationPriceGroupView;
                                break;
                            case MasterListType.PriceListProducts:
                                epv.KeyIdentifier = Config.SingleModificationPriceListProducts;
                                break;
                        }
                            tc = new TemplateField();
                            tc.ItemTemplate =
                                new ChangeIndividualPriceTemplateField(DataControlRowType.DataRow);
                            tc.HeaderStyle.CssClass = "action";
                            tc.ItemStyle.CssClass = "action";
                            tc.Visible = PermissionManager.Check(epv);
                            grdItems.Columns.Add(tc);
                        
                    }

                    bf = new BoundField();
                    bf.DataField = "Code";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnCode");
                    bf.SortExpression = "P.Code";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "FinalInfo";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnModel");
                    bf.SortExpression = "P.Model";
                    bf.HeaderStyle.CssClass = "description";
                    bf.ItemStyle.CssClass = "description";
                    grdItems.Columns.Add(bf);

                    bf = new BoundField();
                    bf.DataField = "Provider";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnProvider");
                    bf.SortExpression = "PV.Name";
                    bf.HeaderStyle.CssClass = "textalign";
                    bf.ItemStyle.CssClass = "textalign";
                    grdItems.Columns.Add(bf);
                
                    bf = new BoundField();
                    bf.DataField = "Type";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnFrequency");
                    bf.SortExpression = "P.Frequency";
                    grdItems.Columns.Add(bf);

                    if (Type == MasterListType.MasterPriceView || Type == MasterListType.PriceGroupView || 
                        Type == MasterListType.PriceListProducts || Type == MasterListType.PriceListModifiedProducts
                        || Type == MasterListType.PublishListProducts)
                    {
                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        epv.KeyIdentifier = Config.IndexColumn;

                        bf = new BoundField();
                        bf.DataField = "Index";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnIndex");
                        bf.SortExpression = "PI.Index";
                        bf.HeaderStyle.CssClass = "price";
                        bf.Visible = PermissionManager.Check(epv);
                        grdItems.Columns.Add(bf);
                    }

                    if (Type != MasterListType.DistributorCurrentPriceList)
                    {
                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        epv.KeyIdentifier = Config.TpColumn;
                        bf = new BoundField();

                        bf.DataField = "PricePurchase";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnTP");
                        bf.SortExpression = "PI.PricePurchase";
                        bf.HeaderStyle.CssClass = "price";
                        bf.Visible = PermissionManager.Check(epv);
                        grdItems.Columns.Add(bf);

                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        epv.KeyIdentifier = Config.GrpColumn;

                        bf = new BoundField();
                        bf.DataField = "PriceSuggest";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnGRP");
                        bf.SortExpression = "PI.PriceSuggest";
                        bf.HeaderStyle.CssClass = "price";
                        bf.Visible = PermissionManager.Check(epv);
                        grdItems.Columns.Add(bf);
                    }

                    if (Type == MasterListType.MasterPriceView || Type == MasterListType.PriceGroupView || 
                        Type == MasterListType.PriceListProducts || Type == MasterListType.PriceListModifiedProducts || 
                        Type == MasterListType.DistributorCurrentPriceList)
                    {
                        bf = new BoundField();
                        bf.DataField = "PriceSell";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnPriceSell");
                        bf.SortExpression = "PI.PriceSell";
                        bf.HeaderStyle.CssClass = "price";
                        grdItems.Columns.Add(bf);
                    }

                    
                    bf = new BoundField();
                    bf.DataField = "Price";
                    bf.HeaderText = Resource.Business.GetString("GridViewColumnNetPrice");
                    bf.SortExpression = "PI.Price";
                    if (Type == MasterListType.PriceGroupView || Type == MasterListType.PriceListProducts || Type == MasterListType.PriceListModifiedProducts)
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnPriceList");
                    
                    bf.HeaderStyle.CssClass = "price";

                    if (Type != MasterListType.PublishListProducts)
                        bf.Visible = true;
                    else
                    {
                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        epv.KeyIdentifier = Config.PLColumn;
                        bf.Visible = PermissionManager.Check(epv);
                    }
                    grdItems.Columns.Add(bf);

                    if (Type == MasterListType.PriceListModifiedProducts)
                    {
                        bf = new BoundField();
                        bf.DataField = "PCR";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnPCR");
                        bf.SortExpression = "PI.PCR";
                        bf.HeaderStyle.CssClass = "price";
                        grdItems.Columns.Add(bf);
                    }
                    
                    if (Type == MasterListType.MasterPriceView || Type == MasterListType.PriceGroupView || 
                        Type == MasterListType.PriceListProducts || Type == MasterListType.PriceListModifiedProducts ||
                        Type == MasterListType.PublishListProducts)
                    {
                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        epv.KeyIdentifier = Config.CtmColumn;

                        bf = new BoundField();
                        bf.DataField = "CTM";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnCTM");
                        bf.SortExpression = "PI.CTM";
                        bf.HeaderStyle.CssClass = "price";
                        bf.Visible = PermissionManager.Check(epv);
                        grdItems.Columns.Add(bf);

                        epv = new ExecutePermissionValidator();
                        epv.ClassType = typeof(ProductListView);
                        epv.KeyIdentifier = Config.CtrColumn;

                        bf = new BoundField();
                        bf.DataField = "CTR";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnCTR");
                        bf.SortExpression = "PI.CTR";
                        bf.HeaderStyle.CssClass = "price";
                        bf.Visible = PermissionManager.Check(epv);
                        grdItems.Columns.Add(bf);
                    }

                    if (Type == MasterListType.AdminView || Type == MasterListType.PriceListProducts || 
                        Type == MasterListType.PriceListModifiedProducts)
                    {
                        bf = new BoundField();
                        bf.DataField = "Status";
                        bf.HeaderText = Resource.Business.GetString("GridViewColumnStatus");
                        bf.SortExpression = "PB.Status";
                        grdItems.Columns.Add(bf);
                    }



                    #endregion
                    break;
            }
        }

        #endregion

        #region Search & Grid Column Formatting

        #region Find Column Helper Methods

        private int FindColumnIndex(GridViewRow row, string dataField)
        {
            return FindColumnIndex(row, dataField, null);
        }

        private int FindColumnIndex(GridViewRow row, string dataField, string dataPropertyField)
        {
            int columnIndex = 0;

            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (dataPropertyField == null)
                {
                    if (cell.ContainingField is BoundField)
                        if (((BoundField)cell.ContainingField).DataField.Equals(dataField))
                            return columnIndex;
                }
                else
                {
                    if ((cell.ContainingField is TemplateField) && ((TemplateField)cell.ContainingField).ItemTemplate is PropertyTemplateField)
                        if ((((PropertyTemplateField)(((TemplateField)cell.ContainingField).ItemTemplate)).DataTextField.Equals(dataField))
                            && (((PropertyTemplateField)(((TemplateField)cell.ContainingField).ItemTemplate)).DataPropertyField.Equals(dataPropertyField))) //.Equals(dataField))
                            return columnIndex;
                }
                columnIndex++;
            }

            return -1;
        }

        private int FindButtonFieldIndex(GridViewRow row, string commandName)
        {
            int columnIndex = 0;

            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is ButtonField)
                    if (((ButtonField)cell.ContainingField).CommandName.Equals(commandName))
                        return columnIndex;

                columnIndex++;
            }

            return -1;
        }

        #endregion

        private object OnSetDataSource(IList<IFilter> lstFilters, out int totalRecords)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(lstFilters);
            
            int records;
            object datasource;
            Trace.Write("Begin datasource databound");
            switch(Type)
            {
                #region Set Datasource
                case MasterListType.Import:
                    datasource = ControllerManager.PriceImport.Search(mpsp.Description, mpsp.SearchDate, out records, GridHelper.State, mpsp.SearchDateTo, mpsp.ImportStatus);
                    break;
                case MasterListType.PriceList:
                    datasource = ControllerManager.PriceList.GetPriceLists(mpsp.Description, mpsp.Frequency, mpsp.SearchDate, mpsp.Distributor, mpsp.Incoterm, mpsp.PublishListStatus, GridHelper.State, mpsp.PriceGroup, out records, mpsp.LookupType, mpsp.Categories[1] as CatalogPage);
                    break;
                case MasterListType.PriceListModifiedProducts:
                    ddlToCurrency.Visible = true;
                    lblToCurrency.Visible = true;
                    datasource = ControllerManager.PriceBase.GetProductList(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, out records, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, GridHelper.State, mpsp.PriceBaseStatus, mpsp.ProductStatus, false, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                case MasterListType.Distributors:
                    datasource = ControllerManager.Distributor.GetDistributors(mpsp.Description, mpsp.Country, mpsp.PriceList, mpsp.PaymentTerm, mpsp.DistributorStatus, GridHelper.State, out records, mpsp.Incoterm, mpsp.LookupType, mpsp.Categories[1] as CatalogPage);
                    break;
                case MasterListType.ProductsView:
                    datasource = ControllerManager.Product.GetProductList(mpsp.Description, mpsp.Frequency, mpsp.SearchDateTo, mpsp.ProductStatus, mpsp.Provider, mpsp.Categories, mpsp.Selection, GridHelper.State, out records);
                    break;
                case MasterListType.ProductsBaseHistory:
                    datasource = ControllerManager.PriceBaseHistory.GetByProduct(Product, GridHelper.State, out records);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                case MasterListType.ProductPriceAttributeHistory:
                    datasource = ControllerManager.PriceAttributeHistory.GetByProduct(Product, mpsp.PriceGroup, GridHelper.State, out records);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                case MasterListType.ProductWorkListItemHistory:
                    datasource = ControllerManager.WorkListItemHistory.GetByProduct(Product, mpsp.PriceList, GridHelper.State, out records);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                case MasterListType.ProvidersView:
                    datasource = ControllerManager.Provider.GetProviderList(mpsp.Description, mpsp.Country, mpsp.ProviderStatus, mpsp.Incoterm, GridHelper.State, out records);
                    break;
                case MasterListType.ProviderAssignedProducts:
                    datasource = ControllerManager.Product.GetProductList(mpsp.Description, mpsp.Frequency, mpsp.SearchDateTo, mpsp.ProductStatus, mpsp.Provider, mpsp.Categories, mpsp.Selection, GridHelper.State, out records);
                    break;
                case MasterListType.CategoryView:
                    datasource = ControllerManager.CategoryBase.ListSearch(mpsp.Description, mpsp.CategoryType, mpsp.CategoryBase, GridHelper.State, out records);
                    break;
                case MasterListType.CurrencyView:
                    datasource = ControllerManager.Currency.List(GridHelper.State, out records);
                    grdItems.Width = Unit.Percentage(50);
                    break;
                case MasterListType.LookupView:
                    datasource = ControllerManager.Lookup.List(mpsp.Description, mpsp.LookupTypeABM, GridHelper.State, out records);
                    break;
                case MasterListType.PriceCalculation:
                    datasource = ControllerManager.PriceCalculation.List(mpsp.Description, mpsp.Categories, mpsp.Provider, mpsp.PriceCalculationPriority, GridHelper.State, out records);
                    break;
                case MasterListType.QuoteView:
                    datasource = ControllerManager.Quote.List(GridHelper.State, mpsp.Description,mpsp.Distributor,mpsp.QuoteStatus, out records, mpsp.MembershipHelperUser);
                    break;
                case MasterListType.PriceGroupDetailsView:
                    datasource = ControllerManager.PriceGroup.List(GridHelper.State, out records);
                    break;
                case MasterListType.QuoteProductsView:
                    datasource = ControllerManager.PriceBase.GetProductList(mpsp.Description, mpsp.Categories, null, mpsp.Selection, mpsp.Frequency, null, out records, null, mpsp.Provider, mpsp.SearchDate, GridHelper.State, PriceBaseStatus.Disable, mpsp.ProductStatus, false, null, null, null, null, null, null, null, true, true);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                case MasterListType.QuoteProductsCreate:
                    datasource = ControllerManager.PriceBase.GetProductList(mpsp.Description, mpsp.Categories, null, mpsp.Selection, mpsp.Frequency, null, out records, null, mpsp.Provider, mpsp.SearchDate, GridHelper.State, PriceBaseStatus.Disable, mpsp.ProductStatus, false, null, null, null, null, null, null, null, false, true);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                case MasterListType.PageList:
                    datasource = ControllerManager.CatalogPage.ListLevelOnePages(mpsp.Description, mpsp.CatalogPage,mpsp.CategoryPageStatus, GridHelper.State, out records);
                    break;
                case MasterListType.PageListProducts:
                    datasource = ControllerManager.Product.GetProductList(mpsp.Description, mpsp.Frequency, mpsp.SearchDateTo, mpsp.ProductStatus, mpsp.Provider, mpsp.Categories, mpsp.Selection, GridHelper.State, out records);
                    break;
                case MasterListType.PageListChilds:
                    datasource = ControllerManager.CategoryBase.GetChildrens(mpsp.Categories[1] as CatalogPage,GridHelper.State, out records);
                    break;
                default:
                    ddlToCurrency.Visible = true;
                    lblToCurrency.Visible = true;
                    datasource = ControllerManager.PriceBase.GetProductList(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, out records, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, GridHelper.State, mpsp.PriceBaseStatus, mpsp.ProductStatus, false, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
                    lstRates = ControllerManager.CurrencyRate.GetArray();
                    break;
                #endregion
            }
            Trace.Write("End datasource databound");

            totalRecords = records;
            litNoItems.Visible = false;

            if (totalRecords <= 0)
                litNoItems.Visible = true;

            divActions.Visible = !litNoItems.Visible;
            divMarked.Visible = !litNoItems.Visible;
            divPaging.Visible = !litNoItems.Visible;
            upGrid.Visible = !litNoItems.Visible;
            if (Type != MasterListType.QuoteProductsCreate && Type != MasterListType.QuoteProductsView)
                ClientUnmarkAll();

            return datasource;
       }

        private void OnHeaderDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                //for (int i = 0; i < e.Row.Cells.Count; i++)
                //{
                //    e.Row.Cells[i].Attributes["title"] = Resource.Business.GetString("tooltip" + e.Row.Cells[i].Text);
                //}

            }
        }

        private void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        private void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = 0;
            if(e.CommandName == ERASE_COMMAND || e.CommandName == PROVIDER_ACTIVITY_COMMAND || e.CommandName == DISTRIBUTOR_ACTIVITY_COMMAND
                || e.CommandName == ERASE_CATEGORY_COMMAND || e.CommandName == UPDATE_CURRENCY_COMMAND || e.CommandName == ERASE_LOOKUP_COMMAND 
                || e.CommandName == ERASE_PRICECALCULATION_COMMAND || e.CommandName == REJECT_QUOTE_COMMAND || e.CommandName == ROLLBACK_BASEHISTORY_COMMAND
                || e.CommandName == ROLLBACK_ATTRIBUTEHISTORY_COMMAND || e.CommandName == ROLLBACK_WORKLISTITEMHISTORY_COMMAND 
                || e.CommandName == PAGELIST_ACTIVITY_COMMAND)
                id = (int)this.grdItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
            
            switch(e.CommandName)
            {
                case ERASE_COMMAND:
                    ControllerManager.PriceList.EraseAndActivate(id);
                    break;
                case PROVIDER_ACTIVITY_COMMAND:
                    if(!ControllerManager.Provider.ActivateDeactivate(id))
                        Utils.ShowMessageInAjax(grdItems, "No se puede borrar por tener una Política de Precios asociada. Por favor, borre la Política de Precios y vuelva a intentarlo.", Utils.MessageType.Error);
                    break;
                case DISTRIBUTOR_ACTIVITY_COMMAND:
                    ControllerManager.Distributor.ActivateDeactivate(id);
                    break;
                case ERASE_CATEGORY_COMMAND: 
                    if (!ControllerManager.CategoryBase.EraseCategory(id))
                        Utils.ShowMessageInAjax(grdItems, "No se puede borrar por tener una Política de Precios asociada. Por favor, borre la Política de Precios y vuelva a intentarlo.", Utils.MessageType.Error);
                    break;
                case UPDATE_CURRENCY_COMMAND:
                    ControllerManager.CurrencyRate.Synchronize(ControllerManager.Currency.GetById(id));
                    break;
                case ERASE_LOOKUP_COMMAND:
                    int tmp = ControllerManager.Lookup.Erase(id);
                    if(tmp == -1)
                        Utils.ShowMessageInAjax(grdItems, "No se puede eliminar ya que esta siendo utilizado actualmente en el sistema.", Utils.MessageType.Error);
                    break;
                case ERASE_PRICECALCULATION_COMMAND:
                    ControllerManager.PriceCalculation.Delete(id);
                    break;
                case REJECT_QUOTE_COMMAND:
                    ControllerManager.Quote.Reject(new Quote(id));
                    break;
                case ROLLBACK_BASEHISTORY_COMMAND:
                    ControllerManager.PriceBaseHistory.RollBack(new PriceBaseHistory(id));
                    break;
                case ROLLBACK_ATTRIBUTEHISTORY_COMMAND:
                    if(!ControllerManager.PriceAttributeHistory.RollBack(new PriceAttributeHistory(id)))
                        Utils.ShowMessageInAjax(grdItems, "El producto ya no existe en ese país.", Utils.MessageType.Error);
                    break;
                case ROLLBACK_WORKLISTITEMHISTORY_COMMAND:
                    if(!ControllerManager.WorkListItemHistory.RollBack(new WorkListItemHistory(id)))
                        Utils.ShowMessageInAjax(grdItems, "El producto ya no existe en esa lista.", Utils.MessageType.Error);
                    break;
                case PAGELIST_ACTIVITY_COMMAND:
                    ControllerManager.CatalogPage.SetActivity(id);
                    break;
            }
            SearchAndFillRepeater();
        }

        private CurrencyRateConverter[,] lstRates = null;

        private void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Setup Row Ids for Javascript
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null && (e.Row.DataItem is Entity<int> || e.Row.DataItem is Entity<Guid> || Type == MasterListType.PriceCalculation))
            {
                if (e.Row.DataItem is Entity<int> && Type != MasterListType.AdminView)
                    e.Row.Attributes["id"] = "pp" + (e.Row.DataItem as Entity<int>).ID.ToString();
                else if (e.Row.DataItem is Entity<Guid> && Type != MasterListType.AdminView)
                    e.Row.Attributes["id"] = "pp" + (e.Row.DataItem as Entity<Guid>).ID.ToString();
                else if (Type == MasterListType.PriceCalculation)
                    e.Row.Attributes["id"] = "pp" + (e.Row.DataItem as PriceCalculationListView).ID.ToString();
                else if (Type == MasterListType.AdminView)
                {
                   // e.Row.Attributes["id"] = "pp" + (e.Row.DataItem as ProductListView).ProductID.ToString();
                    e.Row.Attributes["id"] = "pp" + (e.Row.DataItem as ProductListView).PriceBaseId.ToString();
                }
                switch (Type)
                {
                    case MasterListType.Import:
                        break;
                    case MasterListType.PriceList:
                        break;
                    //case MasterListType.PriceListModifiedProducts:
                    //    e.Row.Attributes["productid"] = "pp" + (e.Row.DataItem as ProductListView).ProductID.ToString();
                    //    break;
                    case MasterListType.Distributors:
                        break;
                    case MasterListType.ProductsView:
                        //e.Row.Attributes["productid"] = "pp" + (e.Row.DataItem as Product).ID.ToString();
                        break;
                    case MasterListType.ProductsBaseHistory:
                        break;
                    case MasterListType.ProductPriceAttributeHistory:
                        break;
                    case MasterListType.ProductWorkListItemHistory:
                        break;
                    case MasterListType.ProvidersView:
                        e.Row.Attributes["providerid"] = "pp" + (e.Row.DataItem as Provider).ID.ToString();
                        break;
                    case MasterListType.ProviderAssignedProducts:
                        //e.Row.Attributes["productid"] = "pp" + (e.Row.DataItem as Product).ID.ToString();
                        break;
                    case MasterListType.CategoryView:
                        //e.Row.Attributes["categoryid"] = "pp" + (e.Row.DataItem as CategoryBase).ID.ToString();
                        break;
                    case MasterListType.CurrencyView:
                        //e.Row.Attributes["currencyid"] = "pp" + (e.Row.DataItem as Currency).ID.ToString();
                        break;
                    case MasterListType.LookupView:
                        //e.Row.Attributes["lookupid"] = "pp" + (e.Row.DataItem as Lookup).ID.ToString();
                        break;
                    case MasterListType.PriceCalculation:
                        //e.Row.Attributes["politicsid"] = "pp" + (e.Row.DataItem as PriceCalculationListView).ID.ToString();
                        break;
                    case MasterListType.PriceGroupDetailsView:
                        //e.Row.Attributes["pricegroupdetailsid"] = "pp" + (e.Row.DataItem as PriceGroup).ID.ToString();
                        break;
                    case MasterListType.QuoteView:
                        //e.Row.Attributes["quoteid"] = "pp" + (e.Row.DataItem as Quote).ID.ToString();
                        break;
                    case MasterListType.PageList:
                        break;
                    case MasterListType.PageListProducts:
                        //e.Row.Attributes["productid"] = "pp" + (e.Row.DataItem as Product).ID.ToString();
                        break;
                    case MasterListType.PageListChilds:
                        break;
                    default:
                        e.Row.Attributes["productid"] = "pp" + (e.Row.DataItem as ProductListView).ProductID.ToString();
                        e.Row.Attributes["pricebaseid"] = "pp" + (e.Row.DataItem as ProductListView).PriceBaseId.ToString();
                        //e.Row.Attributes["id"] = "pp" + (e.Row.DataItem as ProductListView).ID.ToString();
                        break;
                }
            }
            #endregion

            #region PriceList Row Formatting

            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.PriceList)
            {
                PriceList pl = e.Row.DataItem as PriceList;

                int colIndex = FindButtonFieldIndex(e.Row, ERASE_COMMAND);
                e.Row.Cells[colIndex].Attributes["class"] = "action";
                (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ERASE_COMMAND), StringFormat.ClearCommasOnJavascript(pl.Name)) + "');";
                if (pl.PriceListStatus == PriceListStatus.Active || pl.PriceListStatus == PriceListStatus.New)
                {
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/deactivate.png";
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Desactivar";
                }
                else
                {
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/activate.png";
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Activar";
                }

                colIndex = FindColumnIndex(e.Row, "Name");
                if (colIndex > 0)
                {
                    if (pl.Name.Length > 32)
                    {
                        e.Row.Cells[colIndex].Text = StringFormat.Cut(pl.Name, 30);
                        e.Row.Cells[colIndex].Attributes["title"] = pl.Name;
                    }
                }

                colIndex = FindColumnIndex(e.Row, "PublishOn", "CurrentState");
                if (colIndex > 0)
                {
                    if(pl.CurrentState.PublishOn != null)
                        e.Row.Cells[colIndex].Text = pl.CurrentState.PublishOn.Value.ToShortDateString();
                }
                colIndex = FindColumnIndex(e.Row, "LastPublishedOn", "CurrentState");
                if (colIndex > 0)
                {
                    if (pl.CurrentState.LastPublishedOn != null)
                        e.Row.Cells[colIndex].Text = pl.CurrentState.LastPublishedOn.Value.ToShortDateString();
                }
                colIndex = FindColumnIndex(e.Row, "Frecuency");
                if (colIndex > 0)
                {
                    if (pl.Frecuency != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(pl.Frecuency.ToString());
                }
                colIndex = FindColumnIndex(e.Row, "Type");
                if (colIndex > 0)
                {
                    if (pl.Type != null)
                        e.Row.Cells[colIndex].Text = pl.Type.Description;
                    else
                        e.Row.Cells[colIndex].Text = "N/D";
                }
                //colIndex = FindColumnIndex(e.Row, "Status", "CurrentState");
                //if (colIndex > 0)
                //{
                //    if (pl.CurrentState != null)
                //        e.Row.Cells[colIndex].Text = Resource.Business.GetString(pl.CurrentState.Status.ToString());
                //}


            }

            #endregion

            #region Prices Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null && Type != MasterListType.Import &&
                Type != MasterListType.Distributors && Type != MasterListType.ProvidersView && Type != MasterListType.ProviderAssignedProducts && Type != MasterListType.ProductsView
                && Type != MasterListType.CategoryView && Type != MasterListType.CurrencyView && Type != MasterListType.LookupView && Type != MasterListType.PriceCalculation
                && Type != MasterListType.PriceGroupDetailsView && Type != MasterListType.ProductPriceAttributeHistory && Type != MasterListType.ProductsBaseHistory
                && Type != MasterListType.ProductWorkListItemHistory && Type != MasterListType.QuoteView && Type != MasterListType.Import
                && Type != MasterListType.PageList && Type != MasterListType.PageListProducts && Type != MasterListType.PageListChilds)
            {
                ProductListView plv = (e.Row.DataItem as ProductListView);
                if (plv == null)
                    return;

                string pPCurrencyDescription = lstRates[0, plv.PricePurchaseCurrencyId - 1].Description;
                decimal pP = plv.PricePurchase;
                string pSGCurrencyDescription = lstRates[0, plv.PriceSuggestCurrencyId - 1].Description;
                decimal pSG = plv.PriceSuggest;
                string pLCurrencyDescription = lstRates[0, plv.PriceCurrencyId - 1].Description;
                decimal pL = plv.Price;
                string pSCurrencyDescription = lstRates[0, plv.PriceCurrencyId - 1].Description;
                decimal pS = plv.PriceSell;
                string lPCurrencyDescription = lstRates[0, plv.LastPriceCurrencyId - 1].Description;
                decimal? lP = plv.LastPrice;
                string cTMCurrencyDescription = lstRates[0, plv.PriceCurrencyId - 1].Description;
                decimal cTM = plv.CTM;
                
                if(ddlToCurrency.SelectedIndex > 0)
                {
                    pPCurrencyDescription = lstRates[0, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Description;
                    pP = plv.PricePurchase * lstRates[plv.PricePurchaseCurrencyId - 1, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Rate;
                    pSGCurrencyDescription = lstRates[0, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Description;
                    pSG = plv.PriceSuggest * lstRates[plv.PriceSuggestCurrencyId - 1, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Rate;
                    pLCurrencyDescription = lstRates[0, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Description;
                    pL = plv.Price * lstRates[plv.PriceCurrencyId - 1, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Rate;
                    pSCurrencyDescription = lstRates[0, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Description;
                    pS = plv.PriceSell * lstRates[plv.PriceCurrencyId - 1, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Rate;
                    lPCurrencyDescription = lstRates[0, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Description;
                    if (plv.LastPrice != null)
                        lP = plv.LastPrice * lstRates[plv.PriceCurrencyId - 1, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Rate;
                    cTMCurrencyDescription = lstRates[0, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Description;
                    cTM = plv.CTM * lstRates[plv.PriceCurrencyId - 1, Convert.ToInt32(ddlToCurrency.SelectedValue) - 1].Rate;
                }

                int colIndex = FindColumnIndex(e.Row, "Code");
                if (colIndex > 0)
                {
                    if (!plv.IsGrundfosCode)
                        e.Row.Cells[colIndex].Attributes["class"] += " providercode";
                }

                colIndex = FindColumnIndex(e.Row, "FinalInfo");
                if (colIndex > 0)
                {
                    if(plv.FinalInfo!= null)
                        e.Row.Cells[colIndex].Text = StringFormat.Cut(plv.FinalInfo, 42);
                    if (!string.IsNullOrEmpty(plv.Description))
                        e.Row.Cells[colIndex].Attributes["title"] = StringFormat.Cut(plv.Description, 79);
                    else
                        if(!string.IsNullOrEmpty(plv.AlternativeDescription))
                            e.Row.Cells[colIndex].Attributes["title"] = StringFormat.Cut(plv.AlternativeDescription, 79);
                }
                
                colIndex = FindColumnIndex(e.Row, "Price");
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Text = pLCurrencyDescription + " " + pL.ToString("#,##0.00");
                    if (lP != null)
                        e.Row.Cells[colIndex].Attributes["title"] = lPCurrencyDescription + " " + Convert.ToDecimal(lP).ToString("#,##0.00");
                    if (plv.LastPrice != null && plv.LastPrice > plv.Price)
                        e.Row.Cells[colIndex].Attributes["class"] = "down";
                    else if (plv.LastPrice != null && plv.LastPrice < plv.Price)
                        e.Row.Cells[colIndex].Attributes["class"] = "up";
                }

                colIndex = FindColumnIndex(e.Row, "PriceSell");
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Text = pSCurrencyDescription + " " + pS.ToString("#,##0.00");
                    e.Row.Cells[colIndex].Attributes["title"] = plv.Discount;
                }

                colIndex = FindColumnIndex(e.Row, "PricePurchase");
                if (colIndex > 0)
                    e.Row.Cells[colIndex].Text = pPCurrencyDescription + " " + pP.ToString("#,##0.00");

                colIndex = FindColumnIndex(e.Row, "PriceSuggest");
                if (colIndex > 0)
                    e.Row.Cells[colIndex].Text = pSGCurrencyDescription + " " + pSG.ToString("#,##0.00");

                colIndex = FindColumnIndex(e.Row, "CTR");
                if (colIndex > 0)
                    e.Row.Cells[colIndex].Attributes["class"] += " " + plv.CTRColor;

                colIndex = FindColumnIndex(e.Row, "CTM");
                if (colIndex > 0)
                    e.Row.Cells[colIndex].Text = cTMCurrencyDescription + " " + cTM.ToString("#,##0.00");


                colIndex = FindColumnIndex(e.Row, "Code");
                if (colIndex >= 0)
                {
                    if (string.IsNullOrEmpty(plv.Code))
                    {
                        ProductInfo pi = ControllerManager.ProductInfo.GetById(plv.ID);
                        if (pi != null && pi.PriceBase != null && pi.PriceBase.ProviderCode != null)
                            e.Row.Cells[colIndex].Text = StringFormat.Cut(pi.PriceBase.ProviderCode, 29);
                    }
                    else
                        if(plv.Code != null)
                            e.Row.Cells[colIndex].Text = StringFormat.Cut(plv.Code, 29);
                }

                colIndex = FindColumnIndex(e.Row, "Description");
                if (colIndex >= 0)
                { 
                  if (plv.Description != null)
                       e.Row.Cells[colIndex].Text = StringFormat.Cut(plv.Description, 29);
                }
            }

            #endregion

            #region Distributors Row Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.Distributors)
            {
                Distributor d = (e.Row.DataItem as Distributor);
                int colIndex = FindColumnIndex(e.Row, "DistributorStatus");
                if (colIndex > 0)
                {
                    if (d != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(d.DistributorStatus.ToString());
                }
                
                colIndex = FindColumnIndex(e.Row, "Name");
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Attributes["title"] = d.Description;
                    if(d.Name != null)
                        e.Row.Cells[colIndex].Text = StringFormat.Cut(d.Name,32);
                }


                colIndex = FindColumnIndex(e.Row,"Name", "PriceList");
                if (colIndex > 0)
                    if (d.PriceList != null && (d.PriceList.PriceListStatus == PriceListStatus.Disable || d.PriceList.PriceListStatus == PriceListStatus.Deleted))
                        e.Row.Cells[colIndex].Text = "N/D";
                    else
                    {
                        if (d.PriceList != null)
                            if (d.PriceList.Name.Length > 19)
                            {
                                e.Row.Cells[colIndex].Text = StringFormat.Cut(d.PriceList.Name, 20);
                                e.Row.Cells[colIndex].Attributes["title"] = d.PriceList.Name;
                            }
                    }

                colIndex = FindColumnIndex(e.Row, "Contact");
                if (colIndex > 0)
                    if(d.Contact != null)
                        e.Row.Cells[colIndex].Text = StringFormat.Cut(d.Contact, 30);
                
                colIndex = FindButtonFieldIndex(e.Row, DISTRIBUTOR_ACTIVITY_COMMAND);
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Attributes["class"] = "action";
                    
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(DISTRIBUTOR_ACTIVITY_COMMAND), StringFormat.ClearCommasOnJavascript(d.Name)) + "');";
                        if (d.DistributorStatus == DistributorStatus.Active)
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/deactivate.png";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Desactivar";
                        }
                        else
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/activate.png";
                           (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Activar";
                        }
                    
                }

                colIndex = FindColumnIndex(e.Row, "Type");
                if (colIndex > 0)
                {
                    if (d.Type != null)
                        e.Row.Cells[colIndex].Text = d.Type.Description;
                    else
                        e.Row.Cells[colIndex].Text = "N/D";
                }

                colIndex = FindColumnIndex(e.Row, "Discount");
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Text = d.Discount.ToString("#0.##");   
                }
            }

            #endregion

            #region Providers Formatting

            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.ProvidersView)
            {
                Provider pv = (e.Row.DataItem as Provider);
                int colIndex = FindColumnIndex(e.Row, "ProviderStatus");
                if (colIndex > 0)
                {
                    if (pv != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(pv.ProviderStatus.ToString());
                }

                colIndex = FindButtonFieldIndex(e.Row, PROVIDER_ACTIVITY_COMMAND);
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Attributes["class"] = "action";
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(PROVIDER_ACTIVITY_COMMAND), StringFormat.ClearCommasOnJavascript(pv.Name)) + "');";

                        if (pv.ProviderStatus == ProviderStatus.Active)
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/deactivate.png";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Desactivar";
                        }
                        else
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/activate.png";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Activar";
                        }
                }
                colIndex = FindColumnIndex(e.Row, "SaleConditions");
                if (colIndex > 0)
                {
                    if (pv != null && pv.SaleConditions == null)
                        e.Row.Cells[colIndex].Text = "N/D";
                }
            }

            #endregion

            #region PageList (New PriceList)
            
            if (e.Row.RowType == DataControlRowType.DataRow && (Type == MasterListType.PageList || Type == MasterListType.PageListChilds))
            {
                CatalogPage cp = (e.Row.DataItem as CatalogPage);
                int colIndex = FindColumnIndex(e.Row, "CategoryPageStatus");
                if (colIndex > 0)
                    if (cp != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(cp.CategoryPageStatus.ToString());

                colIndex = FindButtonFieldIndex(e.Row, PAGELIST_ACTIVITY_COMMAND);
                if (colIndex > 0)
                {
                    e.Row.Cells[colIndex].Attributes["class"] = "action";
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(PAGELIST_ACTIVITY_COMMAND), StringFormat.ClearCommasOnJavascript(cp.Name)) + "');";

                    if (cp != null && cp.CategoryPageStatus != null)
                    {
                        if (cp.CategoryPageStatus == CategoryPageStatus.Active)
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/deactivate.png";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Desactivar";
                        }
                        else
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/activate.png";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Activar";
                        }
                    }
                }
                colIndex = FindColumnIndex(e.Row, "ChildCount");
                if (colIndex > 0)
                    if (cp != null)
                        e.Row.Cells[colIndex].Text = ControllerManager.CatalogPage.GetChildCount(cp.ID).ToString();
            }


            #endregion

            #region Providers Products, ProductsView & PageListProducts Formatting

            if (e.Row.RowType == DataControlRowType.DataRow && (Type == MasterListType.ProviderAssignedProducts || Type == MasterListType.ProductsView || Type== MasterListType.PageListProducts))
            {
                Product p = (e.Row.DataItem as Product);
                int colIndex = FindColumnIndex(e.Row, "Frequency");
                if (colIndex > 0)
                {
                    if (p != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(p.Frequency.ToString());
                }

                colIndex = FindColumnIndex(e.Row, "Model");
                if (colIndex > 0)
                {
                    if (!string.IsNullOrEmpty(p.Model))
                        e.Row.Cells[colIndex].Text = StringFormat.Cut(p.Model, 49);
                    else
                        if (!string.IsNullOrEmpty(p.ModelAlternative))
                            e.Row.Cells[colIndex].Text = StringFormat.Cut(p.ModelAlternative, 49);
                        else
                            e.Row.Cells[colIndex].Text = "N/D";
                    if (!string.IsNullOrEmpty(p.Description ))
                        e.Row.Cells[colIndex].Attributes["title"] = StringFormat.Cut(p.Description, 79);
                    else
                        if (!string.IsNullOrEmpty(p.DescriptionAlternative))
                            e.Row.Cells[colIndex].Attributes["title"] = StringFormat.Cut(p.DescriptionAlternative, 79);
                }

                colIndex = FindColumnIndex(e.Row, "Code");
                if (colIndex >= 0)
                    if(p.Code != null)
                   e.Row.Cells[colIndex].Text = StringFormat.Cut(p.Code, 29);

               colIndex = FindColumnIndex(e.Row, "Description");
               if (colIndex >= 0)
               {
                   if (!string.IsNullOrEmpty(p.Description))
                       e.Row.Cells[colIndex].Text = StringFormat.Cut(p.Description, 29);
                   else
                        if (!string.IsNullOrEmpty(p.DescriptionAlternative))
                            e.Row.Cells[colIndex].Text = StringFormat.Cut(p.DescriptionAlternative, 29);
                        else
                            e.Row.Cells[colIndex].Text = "N/D";
               }
            }

            #endregion

            #region Categories Row Formatting

            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.CategoryView)
            {
                CategoryBase cb = (e.Row.DataItem as CategoryBase);
                int colIndex = FindColumnIndex(e.Row, "Type");
                if (colIndex >= 0)
                { 
                    if(cb != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString("CategoryType"+cb.Type);
                }

                colIndex = FindButtonFieldIndex(e.Row, ERASE_CATEGORY_COMMAND);
                if (colIndex >= 0)
                {
                    e.Row.Cells[colIndex].Attributes["class"] = "action";
                    (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ERASE_CATEGORY_COMMAND), StringFormat.ClearCommasOnJavascript(cb.Name)) + "');";
                    if (ControllerManager.CategoryBase.IsParent(cb))
                       (e.Row.Cells[colIndex].Controls[0] as ImageButton).Visible = false;
                    else
                       (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Borrar";
                }
            }

            #endregion

            #region Currencies Row Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.CurrencyView)
            { 
                Currency c = (e.Row.DataItem as Currency);
                Currency bc = ControllerManager.Currency.GetBaseCurrency();
                int colIndex = FindColumnIndex(e.Row, "Value");
                if (colIndex > 0)
                {
                    if (c != null)
                        e.Row.Cells[colIndex].Text = c.LastCurrencyRateView.Rate.ToString("#0.####");
                }

                colIndex = FindColumnIndex(e.Row, "Rate", "LastCurrencyRateView");
                if (colIndex > 0)
                {
                    if (c != null)
                    {
                        e.Row.Cells[colIndex].Text = "1 " + c.Description + " = " + bc.Description + c.LastCurrencyRateView.Rate; 
                    }
                }

                colIndex = FindButtonFieldIndex(e.Row, UPDATE_CURRENCY_COMMAND);
                if (colIndex > 0)
                {
                    if (c != null)
                    {
                        e.Row.Cells[colIndex].Attributes["class"] = "action";
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(UPDATE_CURRENCY_COMMAND), StringFormat.ClearCommasOnJavascript(c.Description)) + "');";
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Actualizar";
                    }
                }
                
            
            }
            #endregion

            #region Lookup Row Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.LookupView)
            {
                Lookup l = (e.Row.DataItem as Lookup);
                

                int colIndex = FindButtonFieldIndex(e.Row, ERASE_LOOKUP_COMMAND);
                if (colIndex > 0)
                {
                    if (l != null)
                    {
                        e.Row.Cells[colIndex].Attributes["class"] = "action";
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ERASE_LOOKUP_COMMAND), StringFormat.ClearCommasOnJavascript(l.Description)) + "');";
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Borrar";
                    }
                }

                colIndex = FindColumnIndex(e.Row, "LookupType");
                if (colIndex > 0)
                {
                    if (l != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(l.LookupType.ToString());
                }
                colIndex = FindColumnIndex(e.Row, "Description");
                if (colIndex >= 0)
                {
                    if (l != null)
                        e.Row.Cells[colIndex].Text = StringFormat.Cut(l.Description, 64);
                }

            }
            #endregion

            #region PriceCalculation Row Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.PriceCalculation)
            {
                PriceCalculationListView pc = (e.Row.DataItem as PriceCalculationListView);

                int colIndex = FindButtonFieldIndex(e.Row, ERASE_PRICECALCULATION_COMMAND);
                if (colIndex > 0)
                {
                    if (pc != null)
                    {
                        e.Row.Cells[colIndex].Attributes["class"] = "action";
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ERASE_PRICECALCULATION_COMMAND), StringFormat.ClearCommasOnJavascript(pc.MainFormula)) + "');";
                        (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Borrar";
                    }
                }
            }
            #endregion

            #region PriceGroupDetails Row Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.PriceGroupDetailsView)
            { 
                PriceGroup pg = (e.Row.DataItem as PriceGroup);
                if (pg != null)
                {
                    //int colIndex = FindColumnIndex(e.Row, "Discount");
                    //if (colIndex > 0)
                    //    e.Row.Cells[colIndex].Text = pg.Discount.ToString("#0.##");
                    
                    int colIndex = FindColumnIndex(e.Row, "Adjust");
                    if(colIndex > 0)
                        if(pg.Adjust != null)
                            e.Row.Cells[colIndex].Text = pg.Adjust.Value.ToString("#0.##");

                    colIndex = FindColumnIndex(e.Row, "PriceSuggestCoef");
                    if (colIndex > 0)
                        e.Row.Cells[colIndex].Text = pg.PriceSuggestCoef.ToString("#0.##");
                 }
            }

            #endregion

            #region ProductsBaseHistory
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.ProductsBaseHistory)
            {
                ProductListView plv = (e.Row.DataItem as ProductListView);
                if (plv != null)
                {
                    int colIndex = FindColumnIndex(e.Row, "ModifiedOn");
                    if (colIndex >= 0)
                        if (plv.ModifiedOn != null)
                            e.Row.Cells[colIndex].Text = plv.ModifiedOn.Value.ToShortDateString();

                    colIndex = FindColumnIndex(e.Row, "ModifiedBy");
                    if (colIndex >= 0)
                    {
                        MembershipHelperUser mhu = null;
                        if (plv.ModifiedBy != null)
                            mhu = MembershipHelper.GetUser(plv.ModifiedBy);
                        if (mhu != null)
                            e.Row.Cells[colIndex].Text = mhu.FullName;
                        else
                            e.Row.Cells[colIndex].Text = "N/D";
                    }
                    colIndex = FindButtonFieldIndex(e.Row, ROLLBACK_BASEHISTORY_COMMAND);
                    if (colIndex > 0)
                    {
                        if (plv != null)
                        {
                            e.Row.Cells[colIndex].Attributes["class"] = "action";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ROLLBACK_BASEHISTORY_COMMAND)) + "');";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Volver a esta version de precios";
                        }
                    }
                    
                }
            }
            #endregion

            #region ProductPriceAttributeHistory
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.ProductPriceAttributeHistory)
            {
                PriceAttributeHistory pah = (e.Row.DataItem as PriceAttributeHistory);
                if (pah != null)
                {
                    int colIndex = FindColumnIndex(e.Row, "ModifiedOn", "TimeStamp");
                    if (colIndex >= 0)
                        if (pah.TimeStamp.ModifiedOn.HasValue != null)
                            e.Row.Cells[colIndex].Text = pah.TimeStamp.ModifiedOn.Value.ToShortDateString();

                    colIndex = FindColumnIndex(e.Row, "ModifiedBy", "TimeStamp");
                    if (colIndex >= 0)
                    {
                         MembershipHelperUser mhu = null;
                        if (pah.TimeStamp != null)
                            mhu = MembershipHelper.GetUser(pah.TimeStamp.ModifiedBy);
                        if (mhu != null)
                            e.Row.Cells[colIndex].Text = mhu.FullName;
                        else
                            e.Row.Cells[colIndex].Text = "N/D";
                    }

                    colIndex = FindButtonFieldIndex(e.Row, ROLLBACK_ATTRIBUTEHISTORY_COMMAND);
                    if (colIndex > 0)
                    {
                        if (pah != null)
                        {
                            e.Row.Cells[colIndex].Attributes["class"] = "action";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ROLLBACK_ATTRIBUTEHISTORY_COMMAND)) + "');";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Volver a esta version de precios";
                        }
                    }
                    colIndex = FindColumnIndex(e.Row, "HistoryStatus");
                    if (colIndex > 0)
                    {
                        e.Row.Cells[colIndex].Text = EnumHelper.GetDescription(pah.HistoryStatus);
                    }
                }
            }
            #endregion

            #region ProductWorkListItemHistory
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.ProductWorkListItemHistory)
            {
                WorkListItemHistory wih = (e.Row.DataItem as WorkListItemHistory);
                if (wih != null)
                {
                    int colIndex = FindColumnIndex(e.Row, "ModifiedOn", "TimeStamp");
                    if (colIndex >= 0)
                        if (wih.TimeStamp.ModifiedOn.HasValue != null)
                            e.Row.Cells[colIndex].Text = wih.TimeStamp.ModifiedOn.Value.ToShortDateString();

                    colIndex = FindColumnIndex(e.Row, "ModifiedBy", "TimeStamp");
                    if (colIndex > 0)
                    {
                        MembershipHelperUser mhu = null;
                        if (wih.TimeStamp != null)
                            mhu = MembershipHelper.GetUser(wih.TimeStamp.ModifiedBy);
                        if (mhu != null)
                            e.Row.Cells[colIndex].Text = mhu.FullName;
                        else
                            e.Row.Cells[colIndex].Text = "N/D";
                    }
                    colIndex = FindButtonFieldIndex(e.Row, ROLLBACK_WORKLISTITEMHISTORY_COMMAND);
                    if (colIndex > 0)
                    {
                        if (wih != null)
                        {
                            e.Row.Cells[colIndex].Attributes["class"] = "action";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(ROLLBACK_WORKLISTITEMHISTORY_COMMAND)) + "');";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Volver a esta version de precios";
                        }
                    }
                    colIndex = FindColumnIndex(e.Row, "HistoryStatus");
                    if (colIndex > 0)
                    {
                            e.Row.Cells[colIndex].Text = EnumHelper.GetDescription(wih.HistoryStatus);
                    }
                }
            }
            #endregion

            #region Quote
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.QuoteView)
            {
                Quote q = (e.Row.DataItem as Quote);

                int colIndex = FindColumnIndex(e.Row, "Status");
                if (colIndex > 0)
                {
                    if (q != null)
                        e.Row.Cells[colIndex].Text = Resource.Business.GetString(q.Status.ToString());
                }
                colIndex = FindColumnIndex(e.Row, "ModifiedBy", "TimeStamp");
                if (colIndex >= 0)
                {
                    MembershipHelperUser mhu = null;
                    if (q.TimeStamp.ModifiedBy != null)
                        mhu = MembershipHelper.GetUser(q.TimeStamp.ModifiedBy);
                    if (mhu != null)
                        e.Row.Cells[colIndex].Text = mhu.FullName;
                    else
                        e.Row.Cells[colIndex].Text = "N/D";
                }
                colIndex = FindButtonFieldIndex(e.Row, REJECT_QUOTE_COMMAND);
                if (colIndex > 0)
                {
                    if (q != null)
                    {
                        e.Row.Cells[colIndex].Attributes["class"] = "action";

                        if (q.Status == QuoteStatus.Draft)
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).OnClientClick = "javascript: return confirm('" + string.Format(Resource.Business.GetString(REJECT_QUOTE_COMMAND), StringFormat.ClearCommasOnJavascript(q.Description)) + "');";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ToolTip = "Rechazar";
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).ImageUrl = "~/img/reject.png";
                        }
                        else
                        {
                            (e.Row.Cells[colIndex].Controls[0] as ImageButton).Visible = false;
                        }
                    }
                }


            }
            #endregion

            #region Import
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.Import)
            {
                PriceImport piv = (e.Row.DataItem as PriceImport);

                //int colIndex = FindColumnIndex(e.Row,"ModifiedBy","TimeStamp" );
                //if (colIndex > 0)
                //{
                //    if (piv != null && piv.TimeStamp != null && piv.TimeStamp.ModifiedBy != null)
                //        e.Row.Cells[colIndex].Text = MembershipHelper.GetUser(piv.TimeStamp.ModifiedBy).FullName;
                //    else
                //    { e.Row.Cells[colIndex].Text = "N/D";}
                //}

                int colIndex = FindColumnIndex(e.Row, "ImportStatus");
                if(colIndex > 0)
                {
                    if(piv != null)
                        e.Row.Cells[colIndex].Text = EnumHelper.GetDescription(piv.ImportStatus);
                }
            }
            #endregion

            #region Quote Products Formatting
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null && Type == MasterListType.QuoteProductsCreate)
            {
                ProductListView plv = (e.Row.DataItem as ProductListView);
                if (plv == null)
                    return;

                int colIndex = FindColumnIndex(e.Row, "Model");
                if (colIndex > 0)
                    e.Row.Cells[colIndex].Attributes["title"] = plv.Description;
                
                colIndex = FindColumnIndex(e.Row, "Code");
                if (colIndex > 0)
                    if (string.IsNullOrEmpty(plv.Code))
                    {
                        ProductInfo pi = ControllerManager.ProductInfo.GetById(plv.ID);
                        if (pi != null && pi.PriceBase != null)
                            e.Row.Cells[colIndex].Text = pi.PriceBase.ProviderCode;
                    }
            }

            #endregion

            #region PriceImport
            if (e.Row.RowType == DataControlRowType.DataRow && Type == MasterListType.Import)
            {
                PriceImport pi = (e.Row.DataItem as PriceImport);
                if (pi != null)
                {
                    

                    int colIndex = FindColumnIndex(e.Row, "ModifiedBy", "TimeStamp");
                    if (colIndex > 0)
                    {
                        MembershipHelperUser mhu = null;
                        if (pi.TimeStamp != null)
                            mhu = MembershipHelper.GetUser(pi.TimeStamp.ModifiedBy);
                        if (mhu != null)
                            e.Row.Cells[colIndex].Text = mhu.FullName;
                        else
                            e.Row.Cells[colIndex].Text = "N/D";
                    }
                }
            }
            #endregion
        }

        #endregion

        #region Action Execution

        private void OnActionExecuted(object sender, EventArgs sp)
        {
            if (sender is EraseFromSelectionAction || sender is MoveToSelectionAction || sender is MoveProductsToBaseListAction || sender is MoveProductsToOutOfListAction ||
                sender is DeactivateProductsAction || sender is AddProductsToMasterListAction || sender is ActivateProductsAction || 
                sender is EraseFromPriceListAction || sender is ApprovePriceListItemsAction || sender is RejectPriceListItemsAction)
            {
                if (Type != MasterListType.QuoteProductsCreate && Type != MasterListType.QuoteProductsView)
                {
                    GridHelper.UnMarkAllItems();
                    ClientUnmarkAll();
                }
                
                Utils.ShowMessage(Page, "Acción realizada con éxito.", Utils.MessageType.Info);
            }
            
        }

        private void ClientUnmarkAll()
        {
            string Clientscript = "unMarkAllClick();";
            //ScriptManager.RegisterClientScriptBlock(this.plhActions, this.plhActions.GetType(), "Message", Clientscript, true);
            //Utils.ShowMessageInAjax(this.plhActions, "Acción realizada con éxito.", Utils.MessageType.Info);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", Clientscript, true); 
        }

        #region Popup Based Events

        // TODO: Custom for Products
        protected void btnUpdateChecked_Click(object sender, EventArgs e)
        {
            ((IAction)plhActions.FindControl("btnModifyPrices")).ExecuteAction(this.GridHelper.State, ucFilters.GetFiltersApplied(), txtModValor.Text, txtModCTR.Text);
            SearchAndFillRepeater();
            Utils.ShowMessage(this.Page, "Modificación masiva de precios realizada con éxito.", Utils.MessageType.Info);

            GridHelper.UnMarkAllItems();
            string Clientscript = "unMarkAllClick();";
            //ScriptManager.RegisterClientScriptBlock(this.plhActions, this.plhActions.GetType(), "Message", Clientscript, true); 
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", Clientscript, true);
        }

        // TODO: Custom for Products
        protected void btnAddToPriceList_Click(object sender, EventArgs e)
        {
            if(Type == MasterListType.PriceGroupView)
                ((IAction)plhActions.FindControl("btnMoveToPriceList")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), txtNewPriceList.Text, ddlPriceList.SelectedValue, ddlCurrencies.SelectedValue);
            else
                if(Type == MasterListType.PageList)
                ((IAction)plhActions.FindControl("btnMovePagesToPriceList")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), txtNewPriceList.Text, ddlPriceList.SelectedValue, ddlCurrencies.SelectedValue, ddlPriceGroupForPage.SelectedValue);
                else
                if (Type == MasterListType.Distributors)
                {
                    ((IAction)plhActions.FindControl("btnMoveDistributorsToPriceList")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), ddlPriceList.SelectedValue);
                    SearchAndFillRepeater();
                    Utils.ShowMessage(this.Page, "Canales de Venta asignados exitosamente.", Utils.MessageType.Info);
                }
            txtNewPriceList.Text = string.Empty;
            FillPriceList();

            //TODO: Regenerate Menu with new items
            if (this.Page.Master is BaseMasterPage)
                (this.Page.Master as BaseMasterPage).LoadMenu();
            Utils.ShowMessage(this.Page, "Productos agregados exitosamente.", Utils.MessageType.Info);
        }

        // TODO: Custom for Products
        protected void btnAddToSelection_Click(object sender, EventArgs e)
        {
            ((IAction)plhActions.FindControl("btnMoveToSelection")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), txtNewSelection.Text, ddlSelecciones.SelectedValue);
            ucFilters.FindFilter(typeof(Selection), "ID").Refresh();
            //Re-Select the first index in dropdown, cause is showing the second one.
            ((DropDownFilter)ucFilters.FindFilter(typeof(Selection), "ID")).SelectedValue = ((DropDownFilter)ucFilters.FindFilter(typeof(Selection), "ID")).Items[0].Value;
            FillSelections();
            GridHelper.UnMarkAllItems();
            ClientUnmarkAll();
            Utils.ShowMessage(this.Page, "Productos agregados exitosamente.", Utils.MessageType.Info);
        }

        // TODO: Custom for Products
        protected void btnAddToCategory_Click(object sender, EventArgs e)
        {
            ((IAction)plhActions.FindControl("btnMoveToCategory")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), ddlCategoryLinked.Values);
            SearchAndFillRepeater();
            Utils.ShowMessage(this.Page, "Productos agregados exitosamente.", Utils.MessageType.Info);
        }

        // TODO: Custom for Products
        protected void btnAddToPageList_Click(object sender, EventArgs e)
        {
            char[] firstLetter = ddlPageLists.SelectedItem.Text.Substring(0, 1).ToCharArray();

            if (firstLetter[0] != (char)160)
                Utils.ShowMessage(this.Page, "No se puede agregar productos a Listas Bases.", Utils.MessageType.Error);
            else
            {
                ((IAction)plhActions.FindControl("btnAddToPageList")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), ddlPageLists.SelectedValue);
                SearchAndFillRepeater();
                Utils.ShowMessage(this.Page, "Productos agregados exitosamente.", Utils.MessageType.Info);
            }
        }
       

        // TODO: Custom for Products
        protected void btnRemoveFromCategory_Click(object sender, EventArgs e)
        {
            ((IAction)plhActions.FindControl("btnTakeOutFromCategory")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), ddlCategoryLinkedRemove.Values);
            SearchAndFillRepeater();
            Utils.ShowMessage(this.Page, "Los productos se quitaron de la categoria exitosamente.", Utils.MessageType.Info);
        }

        // TODO: Custom for Products
        protected void btnAddToPriceGroup_Click(object sender, EventArgs e)
        {
            ((IAction)plhActions.FindControl("btnMoveToPriceGroup")).ExecuteAction(GridHelper.State, ucFilters.GetFiltersApplied(), ddlPricegroup.SelectedValue);
            Utils.ShowMessage(this.Page, "Productos agregados exitosamente.", Utils.MessageType.Info);
        }

        #endregion

        #endregion

        #region Page Load
        private void OnDataBind()
        {
            #region Set Column OrderBy
            switch (Type)
            { 
                case MasterListType.Import:
                    GridHelper.SortField = "DateImported";
                    GridHelper.SortAscending = false;
                    break;
                case MasterListType.PriceList:
                    GridHelper.SortField = "TimeStamp.CreatedOn";
                    break;
                case MasterListType.Distributors:
                    GridHelper.SortField = "Name";
                    GridHelper.SortAscending = true;
                    break;
                case MasterListType.ProductsView:
                    GridHelper.SortField = "P.Code";
                    break;
                case MasterListType.ProviderAssignedProducts:
                    GridHelper.SortField = "P.Code";
                    break;
                case MasterListType.ProductsBaseHistory:
                    GridHelper.SortField = "ProviderCode";
                    break;
                case MasterListType.ProvidersView:
                    GridHelper.SortField = "Code";
                    break;
                case MasterListType.ProductPriceAttributeHistory:
                    GridHelper.SortField = "TimeStamp.ModifiedOn";
                    GridHelper.SortAscending = false;
                    break;
                case MasterListType.ProductWorkListItemHistory:
                    GridHelper.SortField = "Price";
                    break;
                case MasterListType.CurrencyView:
                    GridHelper.SortField = "Description";
                    break;
                case MasterListType.LookupView:
                    GridHelper.SortField = "Description";
                    break;
                case MasterListType.PriceCalculation:
                    GridHelper.SortField = "Priority";
                    break;
                case MasterListType.QuoteView:
                    GridHelper.SortField = "Number";
                    GridHelper.SortAscending = false;
                    break;
                case MasterListType.PriceGroupDetailsView:
                    GridHelper.SortField = "Name";
                    break;
                case MasterListType.QuoteProductsView:
                    GridHelper.SortField = "P.Code";
                    break;
                case MasterListType.QuoteProductsCreate:
                    GridHelper.SortField = "P.Code";
                    break;
                case MasterListType.PageList:
                    GridHelper.SortField = "Name";
                    break;
                case MasterListType.PageListProducts:
                    GridHelper.SortField = "P.Code";
                    break;
                default:
                    GridHelper.SortField = "P.Code";
                    break;
            }
            #endregion

            //btnAddToSelection.OnClientClick = "javascript:return standardClick(this);";

            if (PriceGroup != null)
                (ucFilters.FindFilter(typeof(PriceGroup), "ID") as IFilter).Values = PriceGroup.ID;

            if (PriceList != null)
                (ucFilters.FindFilter(typeof(PriceList), "ID") as IFilter).Values = PriceList.ID;

            if (Type == MasterListType.PublishListProducts)
                (ucFilters.FindFilter(typeof(PublishList), "ID") as IFilter).Values = PublishListID;

            if (Type == MasterListType.DistributorCurrentPriceList)
            {
                (ucFilters.FindFilter(typeof(PublishList), "ID") as IFilter).Values = PublishListID;
                (ucFilters.FindFilter(typeof(Distributor), "ID") as IFilter).Values = DistributorID;
            }

            if((Type == MasterListType.ProductsBaseHistory || Type == MasterListType.ProductPriceAttributeHistory || Type == MasterListType.ProductWorkListItemHistory) && Product != null)
                (ucFilters.FindFilter(typeof(Product), "ID") as IFilter).Values = ProductId;

            if(Type == MasterListType.ProviderAssignedProducts && Provider != null)
                (ucFilters.FindFilter(typeof(Provider), "ID") as IFilter).Values = ProviderId;

            if (CatalogPage != null)
                (ucFilters.FindFilter(typeof(CatalogPage), "ID") as IFilter).Values = CatalogPageID.ToString();

            if(LookUp != null)
                (ucFilters.FindFilter(typeof(Lookup), "ID") as IFilter).Values = LookUpId.ToString();
        }

        protected void OnPageLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divVigency.Visible = false;

                FillSelections();

                ddlPageSize.DataSource = GridHelper.PageSizesAvailables;
                ddlPageSize.DataBind();
                ddlPageSize.SelectedValue = GridHelper.PageSize.ToString();

                ddlCurrencies.DataSource = ControllerManager.Currency.GetAll();
                ddlCurrencies.DataTextField = "Description";
                ddlCurrencies.DataValueField = "ID";
                ddlCurrencies.DataBind();
                
                if (PriceGroup != null)
                {
                    PriceGroup pg = ControllerManager.PriceGroup.GetById(PriceGroup.ID);
                    if(pg.Currency != null)
                     ddlCurrencies.SelectedValue = ddlCurrencies.Items.FindByValue(pg.Currency.ID.ToString()).Value;
                }

                if (this.Type == MasterListType.MasterPriceView)
                {
                    ddlPricegroup.DataSource = ControllerManager.PriceGroup.GetAll();
                    ddlPricegroup.DataTextField = "Name";
                    ddlPricegroup.DataValueField = "ID";
                    ddlPricegroup.DataBind();
                }
                if (Type == MasterListType.PageList)
                {
                    ddlPriceGroupForPage.DataSource = ControllerManager.PriceGroup.GetAll();
                    ddlPriceGroupForPage.DataTextField = "Name";
                    ddlPriceGroupForPage.DataValueField = "ID";
                    ddlPriceGroupForPage.DataBind();

                    FillPriceList();
                }
                if (Type == MasterListType.PriceGroupView || Type == MasterListType.Distributors)
                {
                    FillPriceList();
                }
                if (Type == MasterListType.PublishListProducts || Type == MasterListType.DistributorCurrentPriceList)
                    VigencyDate();

                if (Type == MasterListType.AdminView)
                { 
                    ddlPageLists.DataSource = ControllerManager.CategoryBase.GetPagesTreeToLevel("2", 2, 0);
                    ddlPageLists.DataTextField = "NameAsHtml";
                    ddlPageLists.DataValueField = "ID";
                    ddlPageLists.DataBind();
                }
            }
            else
                GridHelper.RecreateFromJavascript(hidSelChecks.Value.Split(','), Convert.ToBoolean(hidAllSelected.Value));
        }

        public void RecreateFromJavascript()
        {
            GridHelper.RecreateFromJavascript(hidSelChecks.Value.Split(','), Convert.ToBoolean(hidAllSelected.Value));
        }

        protected void FillSelections()
        {
            ddlSelecciones.DataSource = ControllerManager.Selection.GetAll();
            ddlSelecciones.DataTextField = "Description";
            ddlSelecciones.DataValueField = "ID";
            ddlSelecciones.DataBind();
            ddlSelecciones.Items.Insert(0, new ListItem("--Selecciones--", "0"));
        }

        protected void FillPriceList()
        {
            if(Type == MasterListType.PriceGroupView)
                ddlPriceList.DataSource = ControllerManager.PriceList.GetActivesByPriceGroup(PriceGroup, null);
            else //Type == PageList
                ddlPriceList.DataSource = ControllerManager.PriceList.GetActives();

            ddlPriceList.DataTextField = "Name";
            ddlPriceList.DataValueField = "ID";
            ddlPriceList.DataBind();
            ddlPriceList.Items.Insert(0, new ListItem("--Grupo de Precios--", "0"));
        }

        protected void VigencyDate()
        {
            PublishList pl = ControllerManager.PublishList.GetById(PublishListID);
            if (pl != null && pl.PublishItems.Count > 0)
            {
                divVigency.Visible = true;
                lblVigency.Text = pl.ValidFrom.ToShortDateString();
            }
        }
        #endregion

        #region Visibility

        private void OnQuantitySelectedAndChecked()
        {
                if (Type != MasterListType.Import && Type != MasterListType.PriceList && Type != MasterListType.Distributors &&
                    Type != MasterListType.ProductsView && Type != MasterListType.ProductsBaseHistory &&
                    Type != MasterListType.ProvidersView && Type != MasterListType.ProviderAssignedProducts &&
                    Type != MasterListType.ProductPriceAttributeHistory && Type != MasterListType.ProductWorkListItemHistory &&
                    Type != MasterListType.CategoryView && Type != MasterListType.CurrencyView && Type != MasterListType.LookupView &&
                    Type != MasterListType.PriceCalculation && Type != MasterListType.QuoteView && Type != MasterListType.PriceGroupDetailsView &&
                    Type != MasterListType.PageList && Type != MasterListType.PageListProducts && Type != MasterListType.PageListChilds)
                {
                    VisibilityOfLnkTakeOutOfSelection();
                    VisibilityOfProductActivity();
                }
        }

        protected void VisibilityOfProductActivity()
        {
            if (Type == MasterListType.AdminView)
            {
                //if ((this.ucFilters.FindFilter(typeof(ProductStatus), "ID").HasValue || this.ucFilters.FindFilter(typeof(PriceBaseStatus), "ID").HasValue) && GridHelper.IsAnyItemMarked())
                if (this.ucFilters.FindFilter(typeof(PriceBaseStatus), "ID").HasValue)
                {
                    if (this.ucFilters.FindFilter(typeof(PriceBaseStatus), "ID").Values.ToString() == PriceBaseStatus.Disable.ToString())
                    {
                        ((LinkButton)plhActions.FindControl("btnActivateProduct")).Visible = true;
                        ((LinkButton)plhActions.FindControl("btnDeactivateProduct")).Visible = false;
                        ((LinkButton)plhActions.FindControl("btnTakeOutOfMasterList")).Visible = true;
                    }
                    else
                    {
                        ((LinkButton) plhActions.FindControl("btnActivateProduct")).Visible = false;
                        ((LinkButton) plhActions.FindControl("btnDeactivateProduct")).Visible = true;
                        ((LinkButton)plhActions.FindControl("btnTakeOutOfMasterList")).Visible = false;
                    }
                }
                else
                {
                    ((LinkButton)plhActions.FindControl("btnActivateProduct")).Visible = false;
                    ((LinkButton)plhActions.FindControl("btnDeactivateProduct")).Visible = false;
                    ((LinkButton)plhActions.FindControl("btnTakeOutOfMasterList")).Visible = false;
                }
            }
            if (Type == MasterListType.PriceListModifiedProducts)
            {
                ((LinkButton)plhActions.FindControl("lnkApprovePriceListItems")).Visible = true;
                ((LinkButton)plhActions.FindControl("lnkRejectPriceListItems")).Visible = true;
            }
        }

        protected void VisibilityOfLnkTakeOutOfSelection()
        {
            IFilter f = this.ucFilters.FindFilterSelection();
            LinkButton lb;
            if(f != null)
                if (f.HasValue)
                {
                    lb= ((LinkButton)plhActions.FindControl("lnkEraseFromSelection"));
                    if(lb != null)
                        lb.Visible = true;
                }
                else
                {
                    lb = ((LinkButton)plhActions.FindControl("lnkEraseFromSelection"));
                    if (lb != null)
                        lb.Visible = false;
                }
            else
            {
                lb = ((LinkButton)plhActions.FindControl("lnkEraseFromSelection"));
                if (lb != null)
                    lb.Visible = false;
            }
        }

        #endregion
        
    }
}