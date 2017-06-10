using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using PriceManager.Common;
using PriceManager.Core;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using ProjectBase.Data;


namespace PriceManager.Business
{
    public class MenuItem : Entity<string>
    {
        #region Menu Creation
        public static void BuildMenuHierarchy()
        {
            MenuItem child;
            homeMenu.Childs.Clear();

            MenuItem masterPrice = new MenuItem(homeMenu, "Maestros", "/masterproductlist/", "tabMasterPrice");
            masterPrice.IsRedirectedToFirstChild = true;
            masterPrice.showAtRightCorner = true;

            #region Add PriceGroups

            IList<PriceGroup> lstPriceGroups = ControllerManager.PriceGroup.GetAll();
            bool first = true;

            foreach (PriceGroup pg in lstPriceGroups)
            {
                child = masterPrice.AddChild(new MenuItem(masterPrice, pg.Name, "/masterproductlist/country/", "tab" + pg.Name.Substring(0,3), new string[] { "id" }, new object[] { pg.ID }));
                child.ShortDescription = pg.Name.Substring(0, 3).ToUpper();
                if (first)
                {
                    child.Separator = "Por País";
                    first = false;
                }
            }

            #endregion

            child = masterPrice.AddChild(new MenuItem(masterPrice, "Base", "/masterproductlist/base/", "tabBase"));
            child.Separator = "General";
            child = masterPrice.AddChild(new MenuItem(masterPrice, "Fuera de Lista", "/masterproductlist/out-of-list/", "tabOutOfList"));

            #region AdminTab
            MenuItem adminMenu = new MenuItem(homeMenu, "Admin.", "/admin/", "tabAdmin", true);
            adminMenu.IsRedirectedToFirstChild = true;
            //adminMenu.AddChild(new MenuItem(adminMenu, "Productos", "/admin/products/", "tabAdminProducts"));
            #endregion

            #region Import

            //adminMenu.AddChild(new MenuItem(adminMenu, "Importación", "/admin/importation/", "tabAdminImportation"));
            MenuItem admImport = new MenuItem(adminMenu, "Importación", "/admin/importation/", "tabAdminImportation");
            admImport.ShowChilds = false;

            MenuItem admImportCreate = new MenuItem(admImport, "Nueva Importación", "/admin/importation/create/", "tabAdminImportNew");
            admImportCreate.selfChild = true;
            admImport.AddChild(admImportCreate);

            admImport.AddChild(new MenuItem(admImport, "Detalle", "/admin/importation/view/", "tabAdminImportView", new string[] { "id" }));

            adminMenu.AddChild(admImport);
            #endregion

            #region AdminProducts
            MenuItem admProducts = new MenuItem(adminMenu, "Productos", "/admin/products/", "tabAdminProducts");
            admProducts.showChilds = false;
            
            MenuItem admProductCreate = new MenuItem(admProducts, "Nuevo Producto", "/admin/products/create/", "tabAdminProductsNew");
            admProductCreate.selfChild = true;
            admProducts.AddChild(admProductCreate);

            admProducts.AddChild(new MenuItem(admProducts, "Detalle", "/admin/products/view/", "tabAdminProductsView", new string[] { "id" }));

            adminMenu.AddChild(admProducts);
            #endregion

            #region Currencies
            MenuItem currencies = new MenuItem(adminMenu, "Monedas", "/admin/currencies/", "tabCurrencies");
            currencies.ShowChilds = false;

            MenuItem currencyCreate = new MenuItem(currencies, "Nueva Moneda", "/admin/currencies/create/", "tabCurrenciesNew");
            currencyCreate.SelfChild = true;
            currencies.AddChild(currencyCreate);

            currencies.AddChild(new MenuItem(currencies, "Detalle", "/admin/currencies/view/", "tabCurrenciesDetail", new string[] { "Id" }));

            adminMenu.AddChild(currencies);
            #endregion

            #region PriceCalculation
            MenuItem priceCalculation = new MenuItem(adminMenu, "Políticas de Precios", "/admin/pricespolitics/", "tabPriceCalculation");
            priceCalculation.ShowChilds = false;

            MenuItem priceCalculationCreate = new MenuItem(priceCalculation, "Nueva Política", "/admin/pricespolitics/create/", "tabPriceCalculationNew");
            priceCalculationCreate.selfChild = true;
            priceCalculation.AddChild(priceCalculationCreate);

            priceCalculation.AddChild(new MenuItem(priceCalculation, "Detalle", "/admin/pricespolitics/view/", "tabPriceCalculationDetail", new string[] { "Id" }));

            adminMenu.AddChild(priceCalculation);
            #endregion

            #region LookUps
            MenuItem lookups = new MenuItem(adminMenu, "Datos Generales", "/admin/lookups/", "tabLookups");
            lookups.ShowChilds = false;

            MenuItem lookupsCreate = new MenuItem(lookups, "Nuevo Dato General", "/admin/lookups/create/", "tabLookupsNew");
            lookupsCreate.SelfChild = true;
            lookups.AddChild(lookupsCreate);

            lookups.AddChild(new MenuItem(lookups, "Detalle", "/admin/lookups/view/", "tabLookupsDetail", new string[] { "Id" }));

            adminMenu.AddChild(lookups);
            #endregion

            #region PriceGroups
            MenuItem pricegroups = new MenuItem(adminMenu, "Maestros de Precios", "/admin/pricegroups/", "tabPriceGroups");
            pricegroups.ShowChilds = false;

            pricegroups.AddChild(new MenuItem(pricegroups, "Detalle", "/admin/pricegroups/view/", "tabPriceGroupsDetail"));

            adminMenu.AddChild(pricegroups);
            #endregion

            #region PriceListsGroups
            MenuItem priceLists = new MenuItem(homeMenu, "Grupo de Precios", "/pricelists/", "tabPriceList");
            priceLists.ShowChilds = false;

            MenuItem create = new MenuItem(priceLists, "Nuevo", "/pricelists/create/", "tabPriceListNew");
            create.SelfChild = true;
            priceLists.AddChild(create);
            
            priceLists.AddChild(new MenuItem(priceLists, "Detalle", "/pricelists/view/", "tabPriceListDetail", new string[] { "Id" }));
            priceLists.AddChild(new MenuItem(priceLists, "Canal de Ventas", "/pricelists/distributors/", "tabPriceListDistributors", new string[] { "Id" }));
            priceLists.AddChild(new MenuItem(priceLists, "Usuarios", "/pricelists/addusers/", "tabAdminAddUsersToPriceList", new string[] { "Id" }));

            MenuItem modPrices = new MenuItem(priceLists, "Definición de Precios", "/pricelists/categories/", "tabPriceListModifyPrices", new string[] { "Id" });
            modPrices.IsRedirectedToFirstChild = true;
            modPrices.AddChild(new MenuItem(modPrices, "Por página", "/pricelists/categories/modifiedcategorys/", "tabPriceListModByPage", new string[] { "Id" }));
            modPrices.AddChild(new MenuItem(modPrices, "Todas las páginas", "/pricelists/items/edit/", "tabPriceListModAll", new string[] { "Id" }));
            modPrices.AddChild(new MenuItem(modPrices, "Aprobación", "/pricelists/items/approve/", "tabApprove", new string[] { "Id" }, null));
            modPrices.AddChild(new MenuItem(modPrices, "Publicación", "/pricelists/items/edit/publish.aspx", "tabPublish", new string[] { "Id" }, null));
            modPrices.Childs[0].AlwaysShowParentMenu = true;
            modPrices.Childs[1].AlwaysShowParentMenu = true;
            modPrices.Childs[2].AlwaysShowParentMenu = true;
            modPrices.Childs[3].AlwaysShowParentMenu = true;
            priceLists.AddChild(modPrices);

            MenuItem pubPrices = new MenuItem(priceLists, "Publicado", "/pricelists/categories2/", "tabPriceListPublished", new string[] { "Id" });
            pubPrices.IsRedirectedToFirstChild = true;
            pubPrices.AddChild(new MenuItem(pubPrices, "Por página", "/pricelists/categories/publishedcategorys/", "tabPriceListPublishedByPage", new string[] { "Id" }));
            pubPrices.AddChild(new MenuItem(pubPrices, "Todas las páginas", "/pricelists/items/published/", "tabPriceListPublishedAll", new string[] { "Id" }));
            pubPrices.Childs[0].AlwaysShowParentMenu = true;
            pubPrices.Childs[1].AlwaysShowParentMenu = true;
            priceLists.AddChild(pubPrices);

            MenuItem currentPrices = new MenuItem(priceLists, "Vigente", "/pricelists/categories3/","tabPriceListCurrent", new string[] { "Id" });
            currentPrices.IsRedirectedToFirstChild = true;
            currentPrices.AddChild(new MenuItem(currentPrices, "Por página", "/pricelists/categories/currentcategorys/", "tabPriceListCurrentByPage", new string[] { "Id" }));
            currentPrices.AddChild(new MenuItem(currentPrices, "Todas las páginas", "/pricelists/items/current/", "tabPriceListCurrentAll", new string[] { "Id" }));
            currentPrices.Childs[0].AlwaysShowParentMenu = true;
            currentPrices.Childs[1].AlwaysShowParentMenu = true;
            priceLists.AddChild(currentPrices);

            //priceLists.AddChild(new MenuItem(priceLists, "Listas de Precios", "/pricelists/pagelist/pagesbygroup/", "tabPageListinGroupList", new string[] { "Id" }, null));
            priceLists.AddChild(new MenuItem(priceLists, "Definicion de Listas", "/pricelists/pagelist/", "tabPriceListPageList", new string[] { "Id" }, null));

            #endregion

            #region Distributors

            MenuItem distributors = new MenuItem(homeMenu, "Canales de Ventas", "/distributors/", "tabDistributors");
            distributors.ShowChilds = false;

            distributors.AddChild(new MenuItem(distributors, "Detalle", "/distributors/view/", "tabDistributorsDetail", new string[] { "Id" }));
            distributors.AddChild(new MenuItem(distributors, "Grupo Vigente", "/distributors/items/current/", "tabDistributorsCurrentPriceList", new string[] { "Id" }));
            distributors.AddChild(new MenuItem(distributors, "Cotizaciones", "/distributors/quotes/", "tabDistributorQuotes", new string[] { "Id" }));
            distributors.AddChild(new MenuItem(distributors, "Listas de Precios", "/distributors/pagelists/", "tabDistributorPageLists", new string[] { "Id" }));
            distributors.AddChild(new MenuItem(distributors, "Contactos", "/distributors/contacts/", "tabDistributorContacts", new string[] { "Id" }));
            #endregion

            #region Products
            MenuItem products = new MenuItem(homeMenu, "Productos", "/products/","tabProducts");
            products.ShowChilds = false;

            products.AddChild(new MenuItem(products, "Detalle", "/products/view/" ,"tabProductsDetail", new string[] { "id" }));
            products.AddChild(new MenuItem(products, "Proveedores", "/products/provider/","tabProductsProvider", new string[] { "id" }));
            products.AddChild(new MenuItem(products, "Categorías", "/products/category/", "tabProductsCategory", new string[] { "id" }));
            products.AddChild(new MenuItem(products, "Grupo de Precios", "/products/pricelists/", "tabProductsPriceList", new string[] { "id" }));
            products.AddChild(new MenuItem(products, "Historial", "/products/history/pricebasehistorys/","tabProductsHistory", new string[] { "id" }));
            products.AddChild(new MenuItem(products, "Hist. por País", "/products/history/priceattributehistorys/", "tabProductAttributeHistoy", new string[] { "id" }));
            products.AddChild(new MenuItem(products, "Hist. por Lista", "/products/history/worklistitemhistorys/", "tabProductItemsHistory", new string[] { "id" }));

            #endregion

            #region proveedores
            MenuItem provider = new MenuItem(homeMenu, "Proveedores", "/providers/", "tabProviders");
            provider.ShowChilds = false;

            provider.AddChild(new MenuItem(provider, "Detalle", "/providers/view/", "tabProvidersDetail", new string[] { "Id" }));
            provider.AddChild(new MenuItem(provider, "Productos", "/providers/items/assigned/", "tabProvidersProducts", new string[] { "Id" }));
            #endregion

            #region Categories
            MenuItem categories = new MenuItem(homeMenu, "Categorías", "/categorys/", "tabCategories");
            categories.ShowChilds = false;

            MenuItem createCategory = new MenuItem(categories, "Nuevo", "/categorys/create/", "tabCategoriesNew");
            createCategory.SelfChild = true;
            categories.AddChild(createCategory);

            categories.AddChild(new MenuItem(categories, "Detalle", "/categorys/view/", "tabCategoriesDetail", new string[] { "Id" }));
            #endregion

            #region Quote
            MenuItem quote = new MenuItem(homeMenu, "Cotizaciones", "/quotes/", "tabQuote");
            quote.ShowChilds = false;

            MenuItem createquote = new MenuItem(quote, "Nuevo", "/quotes/create/", "tabQuoteNew");
            createquote.SelfChild = true;
            quote.AddChild(createquote);
            quote.AddChild(new MenuItem(quote, "Detalle", "/quotes/view/", "tabQuoteView", new string[] { "Id" }));
            //quote.AddChild(new MenuItem(quote, "Editar", "/quotes/edit/", "tabQuoteEdit", new string[] { "QuoteId" }));
            #endregion

            #region PageList

            MenuItem pageListMenu = new MenuItem(homeMenu, "Listas de Precios", "/pagelist/", "tabPageList");
            pageListMenu.showChilds = false;

            MenuItem createPageList = new MenuItem(pageListMenu, "Nuevo", "/pagelist/create/", "tabPageListNew");
            createPageList.selfChild = true;
            pageListMenu.AddChild(createPageList);

            pageListMenu.AddChild(new MenuItem(pageListMenu, "Detalle", "/pagelist/view/", "tabPageListDetail", new string[] { "Id" }));

            pageListMenu.AddChild(new MenuItem(pageListMenu, "Productos", "/pagelist/products/", "tabPageListProducts", new string[] { "id" }));
            
            MenuItem pageListSonMenu = new MenuItem(pageListMenu, "Hijos", "/pagelist/childs/", "tabPageListChilds", new string[] { "id" });
            pageListSonMenu.showChilds = false;

            MenuItem createPageListSon = new MenuItem(pageListSonMenu, "Nuevo", "/pagelist/childs/create/", "tabPageListSonNew", new string[] { "id" });
            createPageListSon.selfChild = true;
            pageListSonMenu.AddChild(createPageListSon);

            pageListSonMenu.AddChild(new MenuItem(pageListSonMenu, "Detalle", "/pagelist/childs/view/", "tabPageListSonDetail", new string[] { "Id" }));

            pageListMenu.AddChild(pageListSonMenu);
            #endregion

            #region QuoteRange
            MenuItem quoterange = new MenuItem(adminMenu, "Rangos Cotizaciones", "/admin/quoterange/", "tabQuoteRange");
            quoterange.ShowChilds = false;

            MenuItem quoterangeCreate = new MenuItem(quoterange, "Nuevo", "/admin/quoterange/create/", "tabQuoteRangeNew");
            quoterangeCreate.SelfChild = true;
            quoterange.AddChild(quoterangeCreate);

            quoterange.AddChild(new MenuItem(quoterange, "Detalle", "/admin/quoterange/view/", "tabQuoteRangeDetail", new string[] { "Id" }));

            adminMenu.AddChild(quoterange);
            #endregion

            homeMenu.AddChild(priceLists);
            homeMenu.AddChild(distributors);
            homeMenu.AddChild(products);
            homeMenu.AddChild(provider);
            homeMenu.AddChild(categories);
            homeMenu.AddChild(pageListMenu);
            homeMenu.AddChild(adminMenu);
            homeMenu.AddChild(masterPrice);
            homeMenu.AddChild(quote);
            

            commonMenus.Add(homeMenu);
            commonMenus.Add(adminMenu);
            commonMenus.Add(masterPrice);
        }
        #endregion

        #region Private Fields

        //private string id;
        private string description;
        private string shortDescription;
        private string goToPage;
        private string[] additionalPages;
        private NameValueCollection parameters = new NameValueCollection();
        private IList<MenuItem> childs = new List<MenuItem>();
        private bool showAtRightCorner = false;
        private MenuItem parent;
        private static string iconRelativeLocation = "~/res/menu/icons/";
        private static string menuLocation = HttpContext.Current.Server.MapPath("~/res/menu/menu.config");
        private static string iconLocation = HttpContext.Current.Server.MapPath(iconRelativeLocation);

        #endregion

        #region Constructors

        public MenuItem() {}

        #region Without parent

        public MenuItem(string description, string goToPage, string tabId)
        {
            Initialize(description, goToPage,tabId , null, null, false, null, null);
        }

        public MenuItem(string description, string goToPage, string tabId, bool showAtRightCorner)
        {
            Initialize(description, goToPage, tabId, null, null, showAtRightCorner, null, null);
        }

        public MenuItem(string description, string goToPage, string tabId, string[] queryStringParameters)
        {
            Initialize(description, goToPage, tabId, queryStringParameters, null, false, null, null);
        }

        public MenuItem(string description, string goToPage, string tabId, string[] queryStringParameters, bool showAtRightCorner)
        {
            Initialize(description, goToPage, tabId, queryStringParameters, null, showAtRightCorner, null, null);
        }

        public MenuItem(string description, string goToPage, string tabId, string[] queryStringParameters, object[] values)
        {
            Initialize(description, goToPage, tabId, queryStringParameters, values, false, null, null);
        }

        public MenuItem(string description, string goToPage, string tabId, string[] queryStringParameters, object[] values, bool showAtRightCorner)
        {
            Initialize(description, goToPage, tabId, queryStringParameters, values, showAtRightCorner, null, null);
        }

        #endregion

        #region With parent

        public MenuItem(MenuItem parent, string description, string goToPage, string tabId)
        {
            Initialize(description, goToPage, tabId, null, null, false, parent, null);
        }

        public MenuItem(MenuItem parent, string description, string goToPage, string tabId, bool showAtRightCorner)
        {
            Initialize(description, goToPage, tabId, null, null, showAtRightCorner, parent, null);
        }

        public MenuItem(MenuItem parent, string description, string goToPage, string tabId, string[] queryStringParameters)
        {
            Initialize(description, goToPage,tabId, queryStringParameters, null, false, parent, null);
        }

        public MenuItem(MenuItem parent, string description, string goToPage, string tabId, string[] queryStringParameters, bool showAtRightCorner)
        {
            Initialize(description, goToPage,tabId , queryStringParameters, null, showAtRightCorner, parent, null);
        }

        public MenuItem(MenuItem parent, string description, string goToPage, string tabId, string[] queryStringParameters, object[] values)
        {
            Initialize(description, goToPage, tabId, queryStringParameters, values, false, parent, null);
        }

        public MenuItem(MenuItem parent, string description, string goToPage, string tabId, string[] queryStringParameters, object[] values, bool showAtRightCorner)
        {
            Initialize(description, goToPage,tabId , queryStringParameters, values, showAtRightCorner, parent, null);
        }

        #endregion

        private void Initialize(string description, string goToPage, string tabId, string[] queryStringParameters, object[] values, bool showAtRightCorner, MenuItem parent, string[] additionalPages)
        {
            this.description = description;
            this.goToPage = goToPage;
            this.ID = tabId;

            if (queryStringParameters != null)
            {
                foreach (string paramName in queryStringParameters)
                    parameters.Add(paramName, string.Empty);

                if (values != null)
                {
                    if (values.Length != parameters.Count)
                        throw new Exception("You can not initialize with different amounts of values than parameters");

                    int i = 0;
                    foreach (object val in values)
                        parameters[parameters.GetKey(i++)] = val.ToString();
                }
            }

            this.showAtRightCorner = showAtRightCorner;
            this.parent = parent;
            this.additionalPages = additionalPages;

            string fileName = this.ID + ".png";
            if (File.Exists(Path.Combine(iconLocation, fileName)))
                icon = iconRelativeLocation.Replace("~","").Replace("\\","/") + fileName;
        }

        #endregion

        #region Public Properties

        public string Description
        {
            get { return description; }
        }

        public string ShortDescription
        {
            set { shortDescription = value; }
            get { return (!string.IsNullOrEmpty(shortDescription)) ? shortDescription : description; }
        }

        private string separator;
        public string Separator
        {
            get { return separator; }
            set { separator = value; }
        }

        public string GoToPage
        {
            get { return goToPage; }
        }

        private bool isRedirectedToFirstChild = false;
        public bool IsRedirectedToFirstChild
        {
            get { return isRedirectedToFirstChild; }
            set { isRedirectedToFirstChild = value; }
        }

        private bool alwaysShowParentMenu = false;
        public bool AlwaysShowParentMenu
        {
            get { return alwaysShowParentMenu; }
            set { alwaysShowParentMenu = value; }
        }

        private string icon;
        public string Icon 
        {
            get 
            {
                return icon;
            }
        }

        public string[] AdditionalPages
        {
            get { return additionalPages; }
            set { additionalPages = value;  }
        }

        private bool showChilds = true;
        public bool ShowChilds
        {
            get { return showChilds; }
            set { showChilds = value; }
        }

        private bool selfChild = false;
        public bool SelfChild
        {
            get { return selfChild; }
            set { selfChild = value; }
        }

        private string alternativeTitle;
        public string AlternativeTitle
        {
            get { return alternativeTitle; }
            set { alternativeTitle = value;}
        }

        public NameValueCollection Parameters
        {
            get { return parameters; }
        }

        public IList<MenuItem> Childs
        {
            get { return childs; }
        }

        //public string ID
        //{
        //    //get
        //    //{
        //    //    string id = this.GoToPage.Replace("/","-");
        //    //    id = id.Remove(0, 1);

        //    //    foreach(string key in parameters)
        //    //        id += string.Format("-{0}-{1}", key, parameters[key]);

        //    //    id = id.Replace("--", "-");

        //    //    if (id == string.Empty)
        //    //        return "home";

        //    //    return id;
        //    //}
        //    get { return id; }
        //    set { id = value; }
        //}

        #endregion

        #region DropDownMenus Creation

        public IList<HtmlControl> CreateDropDownMenus()
        {
            IList<HtmlControl> lstControls = new List<HtmlControl>();

            MenuItem itemToUse = this;
            
            if (this.AlwaysShowParentMenu)
                itemToUse = parent.parent;
            else if (this.Childs.Count == 0 && this.parent != null && !this.SelfChild)
                itemToUse = parent;

            if (this.AlwaysShowParentMenu || itemToUse.ShowChilds || (!itemToUse.ShowChilds && this.parent == itemToUse))
            {
                foreach (MenuItem mi in itemToUse.Childs)
                {
                    HtmlControl ctrl = CreateDropdownMenu(mi);
                    if (ctrl != null)
                            lstControls.Add(ctrl);
                }
            }

            if (itemToUse != homeMenu)
                foreach(MenuItem mi in commonMenus)
                {
                    HtmlControl ctrl = CreateDropdownMenu(mi);
                    if (ctrl != null)
                            lstControls.Add(ctrl);
                }

            return lstControls;
        }

        private HtmlControl CreateDropdownMenu(MenuItem mi)
        {
            HtmlControl div = new HtmlGenericControl("div");
            div.Attributes["id"] = mi.ID;
            div.Attributes["class"] = "dropmenudiv";
            
            if (mi.ShowChilds && mi.Childs.Count > 0)
                foreach (MenuItem child in mi.Childs)
                {
                    if (!PermissionManager.Check(child))
                        continue;

                    if (!string.IsNullOrEmpty(child.Separator))
                        div.Controls.Add(CreateDropDownSeparator(child.Separator));

                    if (mi.ID == "tabHome" && (child.ID == "tabAdmin" || child.ID == "tabMasterPrice"))
                        continue;

                    div.Controls.Add(CreateDropDownAnchor(child));
                }

            // Find all childs lists for the current country
            if (mi.GoToPage == "/masterproductlist/country/")
            {
                int countryId = Convert.ToInt32(mi.Parameters[0]);
                PriceGroup pg = new PriceGroup(countryId);
                
                IList<PriceList> priceLists = ControllerManager.PriceList.GetActivesByPriceGroup(pg, 10);
                if (priceLists.Count > 0)
                {
                    div.Controls.Add(CreateDropDownSeparator("Grupo de Precios"));

                    foreach (PriceList pl in priceLists)
                    {
                        string url = "/pricelists/view/?Id=" + pl.ID;
                        div.Controls.Add(CreateDropDownAnchor(url, StringFormat.Cut(pl.Name, 25)));
                    }
                }

                if (priceLists.Count == 10)
                {
                    div.Controls.Add(CreateDropDownAnchor("/pricelists/?PriceGroupId=" + countryId, "Ver más...", true));
                }

                IList<Distributor> distributors = ControllerManager.Distributor.GetActivesByPriceGroup(pg, 10);
                if (distributors.Count > 0)
                {
                    div.Controls.Add(CreateDropDownSeparator("Canales de Ventas"));

                    foreach (Distributor d in distributors)
                    {
                        string url = "/distributors/view/?Id=" + d.ID;
                        div.Controls.Add(CreateDropDownAnchor(url, StringFormat.Cut(d.Name, 25)));
                    }
                }

                if (distributors.Count == 10)
                {
                    div.Controls.Add(CreateDropDownAnchor("/distributors/?PriceGroupId=" + countryId, "Ver más...", true));
                }

            }

            if (mi.GoToPage == "/distributors/")
            {
               IList<Lookup> lulst = ControllerManager.Lookup.List(LookupType.DistributorType);
               if (lulst.Count > 0)
               {
                   div.Controls.Add(CreateDropDownSeparator("Tipos"));
                   foreach (Lookup lu in lulst)
                   {
                       string url = "/distributors/?LookUpId=" + lu.ID;
                       div.Controls.Add(CreateDropDownAnchor(url, StringFormat.Cut(lu.Description, 25)));
                   }
               }

            }
            if (div.Controls.Count == 0)
                return null;

            return div;
        }

        private static HtmlGenericControl CreateDropDownSeparator(string separator)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = separator;
            return span;
        }

        private static HtmlControl CreateDropDownAnchor(MenuItem mi)
        {
            HtmlAnchor link = new HtmlAnchor();
            link.InnerText = mi.Description;
            link.HRef = BuildUrl(mi);
            if (mi.Icon != null)
                link.Attributes["style"] = string.Format("background-image: url({0}); background-position: left;	background-repeat: no-repeat; padding-left: 20px;", mi.Icon);
            link.ID = "ddm" + mi.ID;
                
            return link;
        }

        private static HtmlControl CreateDropDownAnchor(string url, string text)
        {
            return CreateDropDownAnchor(url, text, false);
        }
        private static HtmlControl CreateDropDownAnchor(string url, string text, bool strong)
        {
            HtmlAnchor link = new HtmlAnchor();
            link.InnerText = text;
            link.HRef = url;

            if (strong)
            {
                HtmlControl ctrl = new HtmlGenericControl("strong");
                ctrl.Controls.Add(link);
                return ctrl;
            }
            return link;

        }

        #endregion

        #region Menu Creation Methods

        public MenuItem AddChild(MenuItem child)
        {
            if (!childs.Contains(child))
                childs.Add(child);

            return child;
        }

        public MenuItem SetParameterValue(string parameter, object value)
        {
            if (parameters[parameter] != null)
                parameters[parameter] = value.ToString();

            return this;
        }

        public HtmlControl CreateMenu()
        {
            if (this.AlwaysShowParentMenu && this.parent.parent != null)
                return CreateMenu(parent.parent, parent);

            if (Childs.Count == 0 && parent != null)
                return CreateMenu(parent, this);

            return CreateMenu(this, this);
        }

        private HtmlControl CreateMenu(MenuItem mi, MenuItem current)
        {
            HtmlControl ul = new HtmlGenericControl("ul");
            ul.Attributes["id"] = "MainTabs";

            if (mi.ShowChilds || current.parent == mi)
            {
                foreach (MenuItem child in mi.childs)
                {
                    // Show only self child if showing a SelfChild as current
                    // Example: For create pages, to avoid showing all items.
                    if (current.SelfChild && child != current)
                        continue;

                    if (child.SelfChild && child != current)
                        continue;

                    if (!PermissionManager.Check(child))
                        continue;

                    HtmlControl li = CreateMenuTab(child, current);
                    ul.Controls.Add(li);
                }
            }
            else
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlAnchor link = BuildLink(mi);
                link.Attributes["class"] = "current";
                li.Controls.Add(link);
                ul.Controls.Add(li);
            }

            //Always add Volver, except for home.
            if (current != homeMenu)
            {
                foreach (MenuItem rightMenu in commonMenus)
                {
                    if (!PermissionManager.Check(rightMenu))
                        continue;

                    ul.Controls.Add(CreateMenuTab(rightMenu, current));
                }
            }

            return ul;
        }

        private HtmlControl CreateMenuTab(MenuItem mi, MenuItem current)
        {
            HtmlControl li = new HtmlGenericControl("li");

            li.ID = mi.ID;

            if (mi.showAtRightCorner)
                li.Attributes["style"] = "float:right;";

            HtmlAnchor link = BuildLink(mi);

            if (mi.ID == current.ID)
                link.Attributes["class"] = "current";


            if (mi.Icon != null)
                link.Attributes["style"] = string.Format("background-image: url({0}); background-position: left;	background-repeat: no-repeat; padding-left: 20px;", mi.Icon);

            li.Controls.Add(link);

            return li;
        }

        #endregion

        #region Title & Breadcrumb

        public void SetHeaderTitle(HtmlControl headerTitle)
        {
            headerTitle.Controls.Clear();

            MenuItem current = this;
            if (current.Childs.Count == 0 && current.parent != null)
                current = current.parent;

            HtmlGenericControl span = new HtmlGenericControl("span");
            AddParentRecursive(span.Controls, current);

            HtmlGenericControl currentSpan = new HtmlGenericControl("span");
            currentSpan.Attributes["class"] = "current";

            if (this.ID != current.ID)
            {
                if (!current.IsRedirectedToFirstChild)
                    span.Controls.Add(BuildLink(current));
                else
                    currentSpan.InnerHtml += current.Description;

                currentSpan.InnerHtml += " : " + this.Description;
            }
            else
            {
                currentSpan.InnerHtml = current.Description;
            }

            if (!string.IsNullOrEmpty(this.AlternativeTitle))
                currentSpan.InnerHtml += string.Format(" [{0}]", this.AlternativeTitle);

            span.Controls.Add(currentSpan);

            headerTitle.Controls.Add(span);
        }

        public HtmlGenericControl GetCurrentPageTitle()
        {
            MenuItem current = this;

            if (current.AlwaysShowParentMenu || (current.Childs.Count == 0 && current.parent != null))
                current = current.parent;

            HtmlGenericControl span = new HtmlGenericControl("span");
            AddParentRecursive(span.Controls, current);

            HtmlGenericControl currentSpan = new HtmlGenericControl("span");
            currentSpan.Attributes["class"] = "current";

            if (this.ID != current.ID)
            {
                if (!current.IsRedirectedToFirstChild)
                    span.Controls.Add(BuildLink(current));
                else
                    currentSpan.InnerHtml += current.Description;

                if (!string.IsNullOrEmpty(this.AlternativeTitle))
                    currentSpan.InnerHtml += string.Format(" <strong>[{0}]</strong>", StringFormat.Cut(this.AlternativeTitle, 29));

                if (!this.AlwaysShowParentMenu)
                    currentSpan.InnerHtml += " : " + this.Description;
            }
            else
            {
                currentSpan.InnerHtml = current.Description;
            }

            span.Controls.Add(currentSpan);
            return span;
        }

        private void AddParentRecursive(ControlCollection controls, MenuItem mi)
        {
            if (mi.parent != null)
            {
                LiteralControl lc = new LiteralControl();
                lc.Text = " > ";
                controls.AddAt(0, lc);
                controls.AddAt(0, BuildLink(mi.parent));

                AddParentRecursive(controls, mi.parent);
            }
        }

        #endregion

        #region Url Helpers

        private HtmlAnchor BuildLink(MenuItem child)
        {
            // Create Anchor Link
            HtmlAnchor link = new HtmlAnchor();
            link.InnerText = child.ShortDescription;

            if (child.IsRedirectedToFirstChild)
            {
                foreach (MenuItem ch in child.Childs)
                {
                    if (PermissionManager.Check(ch))
                    { 
                        link.HRef = BuildUrl(ch);
                        break;
                    }
                }
            }
            else
                link.HRef = BuildUrl(child);

            link.Attributes["rel"] = child.ID;
            link.Title = child.Description;
            if (child.ID == "tabAdmin")
                link.Title = Resource.Business.GetString("AdminTooltip");
            return link;
        }


        private static string BuildUrl(MenuItem child)
        {
            string url = child.GoToPage;

            if (child.parameters.Keys.Count > 0)
            {
                url += "?";
                foreach (string key in child.parameters.Keys)
                {
                    string value = child.parameters[key];
                    if (value == string.Empty)
                    {
                        if (HttpContext.Current.Request.QueryString[key] != null)
                            value = HttpContext.Current.Request.QueryString[key];
                        else
                            throw new Exception("No value defined for key: " + key);
                    }

                    url += string.Format("&{0}={1}", key, value);
                }

                url = url.Replace("?&", "?");
            }


            return url;
        }

        #endregion

        #region FindMenu And Static Methods

        private static MenuItem homeMenu = null;
        private static IList<MenuItem> commonMenus = new List<MenuItem>();

        static MenuItem()
        {
            homeMenu = new MenuItem("Inicio", "/", "tabHome");
            homeMenu.showAtRightCorner = true;

            // Creates the menu hierarchy when class created statically
            BuildMenuHierarchy();
        }
        
        //TODO: Change the NameValueCollection to Collection of Custom Type for serialize to work
        private static void SerializeMenu(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof (MenuItem));
            StreamWriter sw = new StreamWriter(filePath);
            xs.Serialize(sw, homeMenu);
            sw.Close();
        }

        //TODO: Change the NameValueCollection to Collection of Custom Type for serialize to work
        private static MenuItem DeserializeMenu(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(MenuItem));
            StreamReader sw = new StreamReader(filePath);
            MenuItem mi = xs.Deserialize(sw) as MenuItem;
            sw.Close();

            return mi;
        }

        public static MenuItem FindMenu(string currentRelativeUrl)
        {
            // Make sure current page is lowered and has no default.aspx
            currentRelativeUrl = currentRelativeUrl.ToLower().Replace("default.aspx", "");
            if (string.IsNullOrEmpty(currentRelativeUrl))
                currentRelativeUrl = "/";

            // Remove relative prepend
            currentRelativeUrl = currentRelativeUrl.Replace("~/", "/");

            // Make sure it starts with /
            if (!currentRelativeUrl.StartsWith("/"))
                currentRelativeUrl = "/" + currentRelativeUrl;

            // Make sure itend with / when no .aspx page is defined
            if (!currentRelativeUrl.EndsWith(".aspx") && !currentRelativeUrl.EndsWith("/"))
                currentRelativeUrl = currentRelativeUrl + "/";

            // Try to find if there is a menu item that matches the goToPage and the querystring
            MenuItem mi = FindMenuItemInChilds(currentRelativeUrl, homeMenu, true);
            
            // If none found, try to found if there is a menu item without the querystring match or an additional page
            if (mi == null)
                mi = FindMenuItemInChilds(currentRelativeUrl, homeMenu, false);

            // Check if there is a menu for the current folder
            if (mi == null && !currentRelativeUrl.EndsWith("/"))
            {
                string folderUrl = currentRelativeUrl.Substring(0, currentRelativeUrl.LastIndexOf("/") + 1);
                mi = FindMenuItemInChilds(folderUrl, homeMenu, false);
            }

            return mi;
        }

        private static MenuItem FindMenuItemInChilds(string currentPage, MenuItem mi, bool matchQuerystring)
        {
            if (mi.GoToPage == currentPage)
            {
                if (matchQuerystring)
                {
                    bool valid = true;
                    foreach (string key in HttpContext.Current.Request.QueryString.AllKeys)
                        if (mi.Parameters[key] == null || mi.Parameters[key] != HttpContext.Current.Request.QueryString[key])
                            valid = false;

                    if (valid)
                        return mi;
                }
                else
                    return mi;
            }
            else if (!matchQuerystring && mi.AdditionalPages != null)
            {
                foreach (string additionalPage in mi.AdditionalPages)
                    if (additionalPage == currentPage)
                        return mi;
            }

            foreach (MenuItem child in mi.Childs)
            {
                MenuItem findItem = FindMenuItemInChilds(currentPage, child, matchQuerystring);
                if (findItem != null)
                    return findItem;
            }

            return null;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}", this.id);
        }
    }
}