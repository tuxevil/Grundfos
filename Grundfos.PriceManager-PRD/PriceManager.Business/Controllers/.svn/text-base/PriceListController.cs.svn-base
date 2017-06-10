using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using NybbleMembership;
using NybbleMembership.Core.Domain;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ProjectBase.Utils.Email;
using NybbleMembership.Core;
using List=iTextSharp.text.List;
using ProjectBase.Utils.Cache;


namespace PriceManager.Business
{
    public class PriceListController : AbstractNHibernateDao<PriceList, int>
    {
        public PriceListController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        #region ABM Methods

        public PriceList Create(string name, PriceGroup pG)
        {
            return Create(name, null, null, null, PriceListStatus.Active, null, pG, pG.Currency);
        }

        public PriceList Create(string name, PriceGroup pG, Currency currency)
        {
            return Create(name, null, null, null, PriceListStatus.Active, null, pG, currency);
        }

        public bool CanCreate(string name)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Name", name));

            return crit.UniqueResult<PriceList>() == null;
        }

        public PriceList Create(string name, string description, Lookup type, Incoterm? saleCondition, PriceListStatus status, Frequency? frequency, PriceGroup pG, Currency currency)
        {
            PriceList pl = new PriceList();

            pl.Discount = 0;
            pl.PriceGroup = pG;

            pl = Modify(pl, name, description, type, saleCondition, status, frequency, currency);

            PermissionManager.AddEntityPermision(pl.GetType(), pl.ID.ToString(), MembershipHelper.GetUser().UserName);
            
            //Borrar Cache Para Lista de Precio de PriceGroup
            
            CacheManager.ExpireAll(typeof(PriceList));

            return pl;
        }

        public PriceList Modify(PriceList pl, string name, string description, Lookup type, Incoterm? saleCondition, PriceListStatus status, Frequency? frequency, Currency currency)
        {
            if(pl.ID != 0)
                pl = GetById(pl.ID);

            pl.Name = name;
            pl.Description = description;
            pl.Type = type;
            pl.SaleCondition = saleCondition;
            pl.PriceListStatus = status;
            pl.Frecuency = frequency;
            pl.Currency = currency;
            Save(pl);

            return pl;
        }

        public void EraseAndActivate(int id)
        {
            PriceList pl = GetById(id);

            if (pl.PriceListStatus == PriceListStatus.Active || pl.PriceListStatus == PriceListStatus.New)
                pl.PriceListStatus = PriceListStatus.Deleted;
            else
                pl.PriceListStatus = PriceListStatus.Active;

            CacheManager.ExpireAll(typeof(PriceList));
            Save(pl);
            CommitChanges();
            NHibernateSession.Refresh(pl.CurrentState);
        }

        public void Disable(int id)
        {
            PriceList pl = GetById(id);
            pl.PriceListStatus = PriceListStatus.Disable;
            CacheManager.ExpireAll(typeof(PriceList));
            Save(pl);
        }

        public int GetCount(int priceListId)
        {
            ICriteria crit = this.GetCriteria(typeof(WorkListItem));
            crit.Add(Expression.Eq("PriceList", new PriceList(priceListId)));
            crit.SetProjection(Projections.Count("ID"));
            return crit.UniqueResult<int>();
        }

        #endregion

        #region Listing Methods

        public IList<PriceList> GetPriceLists(string description, Frequency? frequency, DateTime? date, Distributor distributor, Incoterm? incoterm, PublishListStatus? status, GridState gridState, PriceGroup priceGroup, out int totalRecords, Lookup type, CatalogPage page)
        {
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            ICriteria crit = GetPriceListsCriteria(description, frequency, date, distributor, incoterm, status, priceGroup, type, page);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<PriceList>();

            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = GetPriceListsCriteria(description, frequency, date, distributor, incoterm, status, priceGroup, type, page);

            crit.SetMaxResults(pageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * pageSize);

            string[] sort = gridState.SortField.Split('.');
            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.GetCriteriaByPath(sort[0]);
                if (critSort == null)
                    critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }
            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<PriceList>();

        }



        private ICriteria GetPriceListsCriteria(string description, Frequency? frequency, DateTime? date, Distributor distributor, Incoterm? incoterm, PublishListStatus? status, PriceGroup priceGroup, Lookup type, CatalogPage page)
        {
            ICriteria crit = GetCriteria();

            //TODO: Sin embargo, seguro que hay una forma mejor de pasar una lista de string a enteros.
            //string[] priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), 1) as string[];
            //int[] intPriceListIds = System.Array.ConvertAll<string, int>(priceListIds, delegate(string plId)
            //{
            //    int result;
            //    Int32.TryParse(plId, out result);
            //    return result;
            //});

            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            if (PermissionManager.Check(epv) == false)
            {
                IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
                int[] intPriceListIds = new int[priceListIds.Count];
                for (int i = 0; i < priceListIds.Count; i++)
                    intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                crit.Add(Expression.In("ID", intPriceListIds));
            }

            if(priceGroup != null)
                crit.Add(Expression.Eq("PriceGroup", priceGroup));

            if (!string.IsNullOrEmpty(description))
            {
                int val;
                if (StringFormat.IsInteger(description, out val))
                    crit.Add(Expression.Or(Expression.InsensitiveLike("Name", description, MatchMode.Anywhere), Expression.Eq("ID", val)));
                else
                    crit.Add(Expression.InsensitiveLike("Name", description,MatchMode.Anywhere));
            }

            if (frequency != null)
                crit.Add(Expression.Eq("Frecuency", frequency));

            if (date != null)
                crit.Add(Expression.Gt("TimeStamp.ModifiedOn", date));

            if (distributor != null)
            {
                ICriteria critDistributor = crit.CreateCriteria("Distributors");
                critDistributor.Add(Expression.Eq("ID", distributor.ID));
            }
            if (incoterm != null)
                crit.Add(Expression.Eq("SaleCondition", incoterm));

            if (status != null)
            {
                ICriteria critStatus = crit.CreateCriteria("CurrentState");
                critStatus.Add(Expression.Eq("Status", status));
            }
            else
            { 
                epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(PriceList);
                epv.KeyIdentifier = Config.PriceListInactiveStatus;

                if (PermissionManager.Check(epv) == false)
                {
                    ICriteria critPStatus = crit.CreateCriteria("CurrentState");
                    critPStatus.Add(Expression.Not(Expression.Eq("Status",PublishListStatus.Disable)));
                }
            }

            if (type != null)
                crit.Add(Expression.Eq("Type", type));

            if (page != null)
            {
                ICriteria critPage = crit.CreateCriteria("CategoryPages");
                critPage.Add(Expression.Eq("ID", page.ID));
            }

            //TODO: Porque esta comentado el codigo
            //crit.Add(Expression.Eq("PriceListStatus", PriceListStatus.Active));
            
            return crit;
        }

        public List<WorkListItemView> GetWLIView(PriceList priceList)
        {
            ICriteria crit = GetCriteria(typeof (WorkListItem))
                .Add(Expression.Eq("PriceList", priceList));
                
            ICriteria pb = crit.CreateCriteria("PriceAttribute").CreateCriteria("PriceBase", "pricebase")
                .SetProjection(Projections.ProjectionList()
                                  
                );
            ICriteria grpCurrency = pb.CreateCriteria("PriceSuggestCurrency", "grpCurrency");
            ICriteria tpCurrency = pb.CreateCriteria("PricePurchaseCurrency", "tpCurrency");
            
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Property("ID"))
                 .Add(Projections.Property("pricebase.ID"))
                 .Add(Projections.Property("pricebase.PriceSuggest"))
                 .Add(Projections.Property("grpCurrency.ID"))
                 .Add(Projections.Property("pricebase.PricePurchase"))
                 .Add(Projections.Property("tpCurrency.ID"))
                );

            crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(WorkListItemView).GetConstructors()[1]));

            return crit.List<WorkListItemView>() as List<WorkListItemView>;
        }

        public List<PriceAttributeView> GetPAView(PriceGroup priceGroup)
        {
            ICriteria crit = GetCriteria(typeof(PriceAttribute))
                .Add(Expression.Eq("PriceGroup", priceGroup));

            ICriteria pb = crit.CreateCriteria("PriceBase", "pricebase")
                .SetProjection(Projections.ProjectionList()

                );
            ICriteria grpCurrency = pb.CreateCriteria("PriceSuggestCurrencyRate", "grpCurrencyRate");
            ICriteria tpCurrency = pb.CreateCriteria("PricePurchaseCurrencyRate", "tpCurrencyRate");

            crit.SetProjection(Projections.ProjectionList().Add(Projections.Property("ID"))
                 .Add(Projections.Property("grpCurrencyRate.ID"))
                 .Add(Projections.Property("tpCurrencyRate.ID"))
                );

            crit.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PriceAttributeView).GetConstructors()[1]));

            return crit.List<PriceAttributeView>() as List<PriceAttributeView>;
        }

        #endregion

        #region Publish Methods

        public PublishList Publish(int id, DateTime validFrom, string comercialConditions, string mail, string path)
        {
            PriceList pl = GetWithItems(id);
            if (pl == null)
                return null;

            if (pl.CurrentState.PendingToApproveCount > 0 && pl.CurrentState.Status != PublishListStatus.Approved)
                throw new Exception("There are pending records to approve.");

            List<CurrencyRate> lastCurrencyRate = ControllerManager.CurrencyRate.GetLastList();
            List<CurrencyRateView> currencyRateViews = ControllerManager.CurrencyRate.GetAllRates() as List<CurrencyRateView>;
            List<WorkListItemView> lstWLI = GetWLIView(pl);

            //NHibernateSession.Flush();
            //NHibernateSession.Clear();

            this.BeginTransaction();

            PublishList pbl = new PublishList();
            pbl.ValidFrom = validFrom;
            pbl.PriceList = pl;
            
            Currency plCurrency = new Currency(pl.Currency.ID);

            decimal priceSuggestRate = pl.PriceGroup.PriceSuggestCoef;

            foreach (WorkListItem wli in pl.Items)
            {
                PriceBase pb = new PriceBase(lstWLI.Find(delegate(WorkListItemView record)
                                                         {
                                                             if (record.WorkListItemId == wli.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PriceBaseId);

                decimal grp = lstWLI.Find(delegate(WorkListItemView record)
                                                         {
                                                             if (record.WorkListItemId == wli.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PriceSuggest;

                Currency grpCurrency = new Currency(lstWLI.Find(delegate(WorkListItemView record)
                                                         {
                                                             if (record.WorkListItemId == wli.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PriceSuggestCurrencyId);

                decimal tp = lstWLI.Find(delegate(WorkListItemView record)
                                                         {
                                                             if (record.WorkListItemId == wli.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PricePurchase;

                Currency tpCurrency = new Currency(lstWLI.Find(delegate(WorkListItemView record)
                                                         {
                                                             if (record.WorkListItemId == wli.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PricePurchaseCurrencyId);




                PublishItem pi = new PublishItem();
                pi.Price = wli.Price;
                pi.PriceBase = pb;
                pi.PriceCurrency = wli.PriceCurrency;
                pi.PublishList = pbl;
                pi.CurrencyRate = wli.CurrencyRate;
                pi.PriceSuggestCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                                         {
                                                             if (record.Currency.ID == grpCurrency.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         });

                CurrencyRateView cr = currencyRateViews.Find(delegate(CurrencyRateView record)
                                         {
                                             if (record.FromCurrency.ID == grpCurrency.ID &&
                                                 record.ToCurrency.ID == plCurrency.ID)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });
                pi.PriceSuggest = grp * priceSuggestRate * cr.Rate;

                pi.PricePurchaseCurrencyRate = lastCurrencyRate.Find(delegate(CurrencyRate record)
                                         {
                                             if (record.Currency.ID == tpCurrency.ID)
                                             {
                                                 return true;
                                             }
                                             return false;
                                         });

                cr = currencyRateViews.Find(delegate(CurrencyRateView record)
                                                         {
                                                             if (record.FromCurrency.ID == tpCurrency.ID &&
                                                                 record.ToCurrency.ID == plCurrency.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         });

                pi.PricePurchase = tp * priceSuggestRate * cr.Rate;

                pbl.PublishItems.Add(pi);
            }
            foreach (CatalogPage cp in pl.CategoryPages)
                pbl.PublishedCategoryPages.Add(cp);

            NHibernateSession.Save(pbl);

            ChangeStatus(pl, WorkListItemStatus.Published);
            
            if(!string.IsNullOrEmpty(mail))
                SendMailsToDistributors(pl, pbl, comercialConditions, mail, path, validFrom);
            return pbl;
        }

        public void SendMailsToDistributors(PriceList pl, PublishList pbl, string comercialConditions, string mail, string path, DateTime validFrom)
        {
            byte[] pdfDocument = CreatePdf(pbl, comercialConditions, path, validFrom);

            string body = File.ReadAllText(
                Path.Combine(HttpContext.Current.Server.MapPath(Config.MailTemplatePath), "publishlist.htm"));

           body = body.Replace("[PUBLISH_BODY]", mail);
           body = body.Replace("[USUARIO]", MembershipHelper.GetUser().UserName);
           body = body.Replace("[EMAIL]", MembershipHelper.GetUser().Email);

           IList<string> mailLst = new List<string>();
            foreach (Distributor d in pl.Distributors)
            {
                string distEmail = string.Empty;
                if (!string.IsNullOrEmpty(d.Email))
                    distEmail = d.Email;
                else
                    if (!string.IsNullOrEmpty(d.AlternativeEmail))
                        distEmail = d.AlternativeEmail;

                if (!string.IsNullOrEmpty(distEmail))
                    mailLst.Add(distEmail);
            }

            //Envia mail a el usuario que publica.
            MembershipHelperUser publishingUser = MembershipHelper.GetUser();
            mailLst.Add(publishingUser.Email);
            
            //Envia mail a los administradores.
            if (ControllerManager.Lookup.List(LookupType.AdministratorReceiveMail)[0].Description == "True")
            {
                //Trae Los usuarios en roles que tenga tildado "IsAdmin".
                IList<UserMember> umlst = MembershipManager.GetAdministrators();
                foreach (UserMember um in umlst)
                    mailLst.Add(um.Email);
            }
            WebMailing w = new WebMailing();
            foreach (string userMail in mailLst)
                w.SendMail(userMail, "Minuta de Cambio de Precio", "Minuta de Cambio de Precio", body, false, "Minuta de Cambio de Precio.pdf", pdfDocument);
        }


        #region PDF
        private byte[] CreatePdf(PublishList pl, string comercialConditions, string path, DateTime validFrom)
        { 
            MemoryStream ms = new MemoryStream();
            System.Drawing.Image.FromFile(path).Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            
            Font myfont = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
            Document document = new Document(PageSize.LETTER);
            document.AddHeader("Expires", "0");

            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(document, stream).CloseStream = false;

            GeneratePDFHeaderFooter(document, pl.PriceList);

            document.Open();
            document.NewPage();

            GeneratePDFHeaderFooter(document, pl.PriceList);
            
            Image im = Image.GetInstance(ms.ToArray());
            im.Alignment = Image.MIDDLE_ALIGN;
            im.ScalePercent(73);
            document.Add(im);
            
            Paragraph p = new Paragraph();
            p.Font.IsBold();
            p.Font.Size = 20;
            p.Font.IsUnderlined();
            p.Alignment = 1;
            p.SpacingBefore = 5;
            p.SpacingAfter = 10;
            p.Add("Minuta de Cambio de Precios");
            document.Add(p);
            
            p = new Paragraph();
            p.SpacingBefore = 5;
            p.Add(new Chunk("Vigente desde: ", new Font(Font.BOLD)));
            p.Add(new Chunk(validFrom.ToShortDateString()));
            document.Add(p);

            IList<ProductListView> lst = ControllerManager.PriceBase.GetProductList(pl);
            
            string[] titles;
            string[] columns;

            SetTitlesAndColumns(out titles, out columns);
            document.Add(GeneratePDFTable(lst, titles, columns));

            p = new Paragraph();
            p.Font.IsStrikethru();
            p.Font.Size = 7;
            p.Alignment = 1;
            p.SpacingBefore = 25;
            
            if (!string.IsNullOrEmpty(comercialConditions))
                p.Add(comercialConditions);
            else
            {
                IList<Lookup> lulst = ControllerManager.Lookup.List(LookupType.ComercialCondition);
                p.Add(lulst[0].Description);
            }
            document.Add(p);
            
            document.Close();

            return stream.GetBuffer();
        }

        private iTextSharp.text.Table GeneratePDFTable(IList<ProductListView> list, string[] titles, string[] columns)
        {
            iTextSharp.text.Table datatable = new iTextSharp.text.Table(columns.Length);
            datatable.Padding = 2;
            datatable.Spacing = 0;
            float[] headerwidths;

            headerwidths = new float[] { 85, 300, 80 };
            datatable.Widths = headerwidths;
            datatable.WidthPercentage = 100;

            datatable.DefaultCellBorderWidth = 1;
            datatable.BackgroundColor = Color.LIGHT_GRAY;
           
            Font myfont = new Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL));

            Font myfontTitle = new Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, new Color(255,255,255)));

            Cell cel = new Cell();

            foreach (string title in titles)
            {
                cel = new Cell();
                cel.Add(new Phrase(title, myfontTitle));
                cel.BackgroundColor = new Color(0, 51, 102);
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                
                datatable.AddCell(cel);
            }

            datatable.EndHeaders();
            datatable.BackgroundColor = Color.WHITE;
            foreach (object r in list)
            {
                foreach (string column in columns)
                {
                    object o = r.GetType().GetProperty(column).GetValue(r, new object[0]);
                    string val;
                    if (o is double || o is decimal)
                        val = Convert.ToDouble(o).ToString("0.00");
                    else
                        val = Convert.ToString(o);

                    cel = new Cell();
                    cel.Add(new Phrase(val, myfont));

                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    if (column != "Model")
                        cel.HorizontalAlignment = Element.ALIGN_RIGHT;

                    datatable.AddCell(cel);
                }
            }
            return datatable;
        }

        private void GeneratePDFHeaderFooter(Document document, PriceList pl)
        {
            Font myfont = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));

            //Paragraph p = new Paragraph();
            //p.Alignment = HeaderFooter.ALIGN_CENTER;
            //p.Add(new Phrase("Datos al: " + DateTime.Now, myfont));

            HeaderFooter footer = new HeaderFooter(new Phrase(""), true);
            footer.Alignment = HeaderFooter.ALIGN_RIGHT;
            footer.Border = Rectangle.NO_BORDER;

            document.Footer = footer;

            Paragraph p = new Paragraph();
            //p.Alignment = 2;
            //p.SpacingAfter = 5;
            p.Font.Size = 8;
            p.Add("Buenos Aires, " + pl.TimeStamp.CreatedOn.ToLongDateString());

            HeaderFooter head = new HeaderFooter(p, false);
            head.Alignment = HeaderFooter.ALIGN_RIGHT;
            head.Border = Rectangle.NO_BORDER;
            
            document.Header = head;
        }

        private void SetTitlesAndColumns(out string[] titles, out string[] columns)
        {
            titles = new string[]
                             {
                                 "Código",
                                 "Modelo",
                                 "Precio Neto"
                             };
            columns = new string[]
                            {
                                 "Code",
                                 "Model",
                                 "Price"
                            };
        }
        #endregion

        #endregion

        #region Add/Remove Items From PriceGroup

        public PriceList AddItemsFromPriceGroup(GridState gridState, IList<Filters.IFilter> filters, string newPriceListName, int priceListId, int currencyId)
        {
            if (!gridState.IsAnyItemMarked)
                throw new NoItemMarkedException("No se ha seleccionado ningun item.");

            MasterPriceSearchParameters msps = FilterHelper.GetSearchFilters(filters);
            IList<PriceAttribute> lstPA = ControllerManager.PriceBase.GetPriceAttributesSelected(gridState, filters, new PriceList(priceListId));

            return AddItemsFromPriceGroup(lstPA, newPriceListName, priceListId, currencyId, msps.PriceGroup);
        }

        public PriceList AddItemsFromPriceGroup(CategoryBase[] catalogPages, int priceListId, PriceGroup pg, string newPriceList, int currencyId)
        {
            PriceList pl = GetById(priceListId);
            IList<PriceAttribute> pALst = ControllerManager.PriceBase.GetPriceAttributesSelected(null, catalogPages, null, null, null, null, null, true, null, null, pg, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, pl, null, null, null, pl);

            return AddItemsFromPriceGroup(pALst, newPriceList, priceListId, currencyId, pg);
        }
        private PriceList AddItemsFromPriceGroup(IList<PriceAttribute> priceAttributeLst, string newPriceListName, int priceListId, int currencyId, PriceGroup pg)
        {
            List<CurrencyRateView> currencyRateViews = ControllerManager.CurrencyRate.GetAllRates() as List<CurrencyRateView>;

            this.BeginTransaction();

            PriceList priceList;
            if (!string.IsNullOrEmpty(newPriceListName))
            {
                if (!CanCreate(newPriceListName))
                    throw new PriceListAlreadyExistException("Ya existe una lista de precios con ese nombre.");

                Currency c = ControllerManager.Currency.GetById(currencyId);
                priceList = Create(newPriceListName, pg, c);
                
            }
            else
                priceList = GetById(priceListId);

            if (priceList == null)
                return null;

            List<PriceAttributeView> lstPAV = GetPAView(priceList.PriceGroup);

            foreach (PriceAttribute priceAttribute in priceAttributeLst)
            {
                WorkListItem wli = new WorkListItem();
                wli.PriceList = priceList;
                wli.WorkListItemStatus = WorkListItemStatus.Added;
                wli.PriceAttribute = priceAttribute;

                CurrencyRateView cr = currencyRateViews.Find(delegate(CurrencyRateView record)
                                                         {
                                                             if (record.FromCurrency == priceAttribute.PriceCurrency &&
                                                                 record.ToCurrency == priceList.Currency)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         });
                wli.Price = priceAttribute.Price * cr.Rate;
                wli.PriceCurrency = priceList.Currency;
                wli.CurrencyRate = cr.ToCurrencyRate;
                
                wli.PricePurchaseCurrencyRate = new CurrencyRate(lstPAV.Find(delegate(PriceAttributeView record)
                                                         {
                                                             if (record.PriceAttributeId == priceAttribute.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PricePurchaseCurrencyRateId); ;
                wli.PriceSuggestCurrencyRate = new CurrencyRate(lstPAV.Find(delegate(PriceAttributeView record)
                                                         {
                                                             if (record.PriceAttributeId == priceAttribute.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }).PriceSuggestCurrencyRateId); ;
                
                priceList.Items.Add(wli);
            }

            Save(priceList);

            CommitChanges();
            Trace.Write("End Add to PriceList");
            IQuery q = NHibernateSession.GetNamedQuery("PriceListItemCountUpdate");
            q.SetInt32("PriceListId", priceList.ID);
            q.UniqueResult();
            Trace.Write("End PriceListItemCountUpdate");

            return priceList;
        }

        public void RemoveItemsFromPriceList(GridState gridstate, IList<Filters.IFilter> filters)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            Currency toCurrency = null;
            if(gridstate.ShowInCurrency != null && gridstate.ShowInCurrency > 0)
                ControllerManager.Currency.GetById((int)gridstate.ShowInCurrency);

            RemoveItemsFromPriceList(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, gridstate.MarkedAll, gridstate.Items, gridstate.SearchDate, MembershipHelper.GetUser().UserId, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor, toCurrency, false);
        }

        private IList<WorkListItem> GetWLIList(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, bool addTo)
        {
            string selectWLI = ControllerManager.PriceBase.GetProductListHQL("DISTINCT WLI", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, addTo, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            
            IQuery q = NHibernateSession.CreateQuery(selectWLI);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                                                         0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                                                         null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);

            return q.List<WorkListItem>();
        }

        private void RemoveItemsFromPriceList(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, Guid userId, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor, Currency toCurrency, bool addTo)
        {
            // DELETE CORRESPONDING RECORDS
            string deleteSql;

            string plsql = ControllerManager.PriceBase.GetProductListHQL("WLI.ID", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, addTo, null, null, listedDate, false, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            deleteSql = "DELETE FROM WorkListItem";
            deleteSql += " WHERE ID IN (" + plsql + ")";
            
            IQuery q = NHibernateSession.CreateQuery(deleteSql);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, workListItemStatus, publishList, distributor, toCurrency);
            q.ExecuteUpdate();

            q = NHibernateSession.GetNamedQuery("PriceListItemCountUpdate");
            q.SetInt32("PriceListId", priceList.ID);
            q.UniqueResult();
        }

        #endregion

        public PriceList GetWithItems(int id)
        {
            ICriteria crit = GetCriteria();
            crit.SetFetchMode("Items", FetchMode.Join);
            crit.Add(Expression.Eq("ID", id));
            return crit.UniqueResult<PriceList>();
        }

        public IList<PriceList> GetForProduct(int productId)
        {
            ICriteria crit = GetCriteria();
            crit.CreateCriteria("Items").CreateCriteria("PriceAttribute").CreateCriteria("PriceBase").CreateCriteria(
                "Product").Add(Expression.Eq("ID", productId));
            crit.SetResultTransformer(NHibernate.Transform.Transformers.DistinctRootEntity);
            return crit.List<PriceList>();
        }

        public IList<PriceList> GetActivesByPriceGroup(PriceGroup pG, int? maxResults)
        {
            //Cache Section
            string cacheKey = null;
            MembershipHelperUser mhu = MembershipHelper.GetUser();
            if (mhu != null)
                cacheKey = string.Format("PRICELISTS_{0}_{1}_{2}_{3}", mhu.UserId, typeof(PriceList).ToString(), pG.ID, maxResults);

            object result = CacheManager.GetCached(typeof(PriceList),cacheKey);

            ICriteria crit = GetCriteria();
            if (result == null)
            {
                ExecutePermissionValidator epv = new ExecutePermissionValidator();
                epv.ClassType = typeof(PriceList);
                epv.KeyIdentifier = Config.SeePriceLists;

                if (PermissionManager.Check(epv) == false)
                {
                    IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
                    int[] intPriceListIds = new int[priceListIds.Count];
                    for (int i = 0; i < priceListIds.Count; i++)
                        intPriceListIds[i] = Convert.ToInt32(priceListIds[i]);

                    crit.Add(Expression.In("ID", intPriceListIds));
                }

                crit.Add(Expression.Or(Expression.Eq("PriceListStatus", PriceListStatus.Active), Expression.Eq("PriceListStatus", PriceListStatus.New)));
                crit.Add(Expression.Eq("PriceGroup", pG));
                crit.AddOrder(new Order("TimeStamp.CreatedOn", false));
                if (maxResults.HasValue)
                    crit.SetMaxResults(maxResults.Value);

                result = crit.List<PriceList>();
                CacheManager.AddItem(typeof(PriceList),cacheKey, result);
            }

            return result as IList<PriceList>;
        }

        public IList<PriceList> GetActives()
        {
            string query = "SELECT PL FROM PriceList PL WHERE";
            
            
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(PriceList);
            epv.KeyIdentifier = Config.SeePriceLists;

            if (PermissionManager.Check(epv) == false)
            {
                IList priceListIds = PermissionManager.GetPermissionIdentifiers(typeof(PriceList), PermissionAction.Create);
                query += " ID IN (";
                for (int i = 0; i < priceListIds.Count; i++)
                    query += Convert.ToInt32(priceListIds[i]) + ",";
                query = query.Substring(0, query.Length - 1);
                query += ") AND";
            }
            query += " PriceListStatus IN (:Status1, :Status2)";
            query += " ORDER BY UPPER(Name)";
            
            IQuery q = NHibernateSession.CreateQuery(query);

            q.SetEnum("Status1", PriceListStatus.Active);
            q.SetEnum("Status2", PriceListStatus.New);

            return q.List<PriceList>();
        }


        public IList<PriceList> GetAllActives()
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Or(Expression.Eq("PriceListStatus", PriceListStatus.Active), Expression.Eq("PriceListStatus", PriceListStatus.New)));
            crit.AddOrder(new Order("Name", false));

            return crit.List<PriceList>();
        }

        public void CalculateDiscounts(PriceList priceList)
        {
            if (priceList != null)
            {
                // Find all distributors of this pricelist and assign average to PriceList.
                decimal avg = ControllerManager.Distributor.FindMaxDiscountPerList(priceList);
                priceList.Discount = avg;
                NHibernateSession.Save(priceList);
            }
        }

        public void ApproveItems(GridState gs, IList<Filters.IFilter> filters)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);
            ChangeStatus(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, mpsp.Currency, gs.MarkedAll, gs.Items, gs.SearchDate, MembershipHelper.GetUser().UserId, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, WorkListItemStatus.Approved, mpsp.PublishList, mpsp.Distributor);
        }

        private void ChangeStatus(PriceList priceList, WorkListItemStatus? workListItemStatus)
        {
            ChangeStatus(string.Empty, null, null, null, null, null, true, null, DateTime.Now, MembershipHelper.GetUser().UserId, null, null, null, null, null, null, null, null, priceList, workListItemStatus, null, null);
        }

        private void ChangeStatus(string description, CategoryBase[] category, CtrRange cTR, Selection list, Frequency? frequency, Currency currency, bool markedAll, List<int> selecteditems, DateTime listedDate, Guid userId, PriceGroup priceGroup, Provider provider, DateTime? date, PriceBaseStatus? priceBaseStatus, ProductStatus? productStatus, IndexPrice index, DateTime? dateto, PriceImport priceImport, PriceList priceList, WorkListItemStatus? workListItemStatus, PublishList publishList, Distributor distributor)
        {
            BeginTransaction();
            string plsql = ControllerManager.PriceBase.GetProductListHQL("DISTINCT WLI.Id", description, category, cTR, list, frequency, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, null, publishList, distributor, null);
            
            string updateSql = "UPDATE WorkListItem SET";
            updateSql += " WorkListItemStatus = :WLIStatus,";
            updateSql += " ModifiedBy = :User,";
            updateSql += " ModifiedOn = :DateCurrent";
            updateSql += " from WorkListItem WLI";
            updateSql += " WHERE WLI.Id IN (" + plsql + ")";

            IQuery q = NHibernateSession.CreateSQLQuery(updateSql);

            ControllerManager.PriceBase.CreateParameters(q, string.Empty, description, category, cTR, list, frequency, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, listedDate, priceGroup, provider, date, priceBaseStatus, productStatus, index, dateto, priceImport, priceList, null, publishList, distributor, null);
            q.SetEnum("WLIStatus", workListItemStatus);
            q.SetDateTime("DateCurrent", DateTime.Now);
            q.SetGuid("User", userId);
            
            q.ExecuteUpdate();
            CommitChanges();
        }


        public void RejectItems(GridState gridState, IList<Filters.IFilter> filters)
        {
            BeginTransaction();

            IList<WorkListItem> lstWli = ControllerManager.PriceBase.GetWorkListItemsSelected(gridState, filters);
            foreach (WorkListItem wli in lstWli)
            {
                if (wli.LastApproved != null)
                {
                    wli.WorkListItemStatus = WorkListItemStatus.Published;
                    wli.Price = wli.LastApproved.Price;
                    wli.LastPublishItem = wli.LastApproved.LastPublishItem;
                    wli.LastApproved = wli.LastApproved.LastApproved;
                }
                else if(wli.WorkListItemStatus == WorkListItemStatus.Added)
                {
                    ControllerManager.WorkListItem.Delete(wli);
                }
                else
                {
                    wli.Price = wli.PriceAttribute.Price;
                    wli.LastPublishItem = null;
                    wli.LastApproved = null;
                    wli.WorkListItemStatus = WorkListItemStatus.Added; 
                }
            }
            this.CommitChanges();
        }

        public void AddPagesToPriceList(IList<CatalogPage> pages, PriceList pl)
        {
            AddPagesToPriceList(pages, pl.ID, pl.PriceGroup.ID, null, 0); 
        }
        public void AddPagesToPriceList(GridState gridState, IList<Filters.IFilter> filters, int priceListId, int priceGroupId, string newPriceList, int currencyId)
        {
            IList<CatalogPage> catalogPagesLst = ControllerManager.CatalogPage.GetPagesByFilters(gridState, filters);
            AddPagesToPriceList(catalogPagesLst, priceListId, priceGroupId, newPriceList, currencyId);
        }

        public void AddPagesToPriceList(IList<CatalogPage> catalogPagesLst, int priceListId, int priceGroupId, string newPriceList, int currencyId)
        {
            PriceGroup pg = null;
            if (!string.IsNullOrEmpty(newPriceList))
                pg = ControllerManager.PriceGroup.GetById(priceGroupId);
            else
                if (priceListId != 0)
                    pg = GetById(priceListId).PriceGroup;

            //1- Paso las paginas a un array de Category base para mantener el esquema que se viene utilizando
            CategoryBase[] pages = new CategoryBase[catalogPagesLst.Count];
            int i = 0;
            foreach (CatalogPage cp in catalogPagesLst)
            {
                pages[i] = cp;
                i++;
            }
            //2- Agregar productos que no estan en un PG a el PG
            PriceList pl = GetById(priceListId);
            ControllerManager.PriceBase.AddToPriceGroup(null, pages, null, null, null, null, null, true, null, null, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, pg.ID, null, null, null, pl, null, null, null);

            //3-Agregar los productos del pricegroup a la lista de precios
            pl = AddItemsFromPriceGroup(pages, priceListId, pg, newPriceList, currencyId);

            //4- Agregar catgorias a lista de precio
            
            //0-Tomo los hijos de cada categoria
            //List<CategoryBase> completeLst = new List<CategoryBase>();
            //foreach (CategoryBase cb in catalogPagesLst)
            //{
            //    List<CategoryBase> lst = ControllerManager.CategoryBase.GetChildrens(cb);
            //    foreach (CategoryBase c in lst)
            //        completeLst.Add(c);

            //    completeLst.Add(cb as CatalogPage);

            //    CategoryBase parent = ControllerManager.CategoryBase.GetById(cb.ID).Parent;
            //    if(parent != null)
            //    {
            //        if (!completeLst.Exists(delegate(CategoryBase record)
            //                                              {
            //                                                  if (record.ID == parent.ID)
            //                                                      return true;
            //                                                  return false;
            //                                              }))
            //            completeLst.Add(parent);
            //        CategoryBase grandparent = parent.Parent;
            //        if (grandparent != null && !completeLst.Exists(delegate(CategoryBase record)
            //                                              {
            //                                                  if (record.ID == grandparent.ID)
            //                                                      return true;
            //                                                  return false;
            //                                              }))
            //            completeLst.Add(grandparent);
            //    }
            //}

            foreach (CatalogPage cp in catalogPagesLst)
                pl.CategoryPages.Add(cp);

            Save(pl);

        }

        public void RemovePagesFromPriceList(IList<CatalogPage> catalogPagesLst, PriceList pl)
        {
            
            //1- Paso las paginas a un array de Category base para mantener el esquema que se viene utilizando
            CategoryBase[] pages = new CategoryBase[catalogPagesLst.Count];
            int i = 0;
            foreach (CatalogPage cp in catalogPagesLst)
            {
                pages[i] = cp;
                i++;
            }
            RemoveItemsFromPriceList(string.Empty, pages, null, null, null, null, true, null, DateTime.Today, MembershipHelper.GetUser().UserId, null, null, null, PriceBaseStatus.Verified, ProductStatus.Active, null, null, null, pl, null, null, null, null, true);

            //2- Tomo los hijos para sacarlos de la relacion.
            //No mas, ahora se agregan solo los hijos de nivel 2
            //List<CategoryBase> completeLst = new List<CategoryBase>();
            //foreach (CategoryBase cb in catalogPagesLst)
            //{
            //    List<CategoryBase> lst = ControllerManager.CategoryBase.GetChildrens(cb);
            //    foreach (CategoryBase c in lst)
            //        completeLst.Add(c);

            //    completeLst.Add(cb);

            //    CategoryBase parent = ControllerManager.CategoryBase.GetById(cb.ID).Parent;
            //    if (parent != null)
            //    {
            //        if (AddParentToErase(parent, destinationLst))
            //            completeLst.Add(parent);

            //        CategoryBase grandparent = parent.Parent;
            //        if (grandparent != null)
            //            if (AddParentToErase(grandparent, destinationLst))
            //                completeLst.Add(grandparent);
            //    }
            //}

            foreach (CatalogPage cp in catalogPagesLst)
                pl.CategoryPages.Remove(cp);

            Save(pl);

        }

        //private bool AddParentToErase(CategoryBase cb, IList<CatalogPage> inLst)
        //{
        //    List<CategoryBase> lstParent = ControllerManager.CategoryBase.GetChildrens(cb);
        //    int cant = 0;
        //    foreach (CategoryBase cbl in inLst)
        //    {
        //        if (lstParent.Contains(cbl))
        //            cant++;
        //    }
        //    return cant <=0;
        //}

        public void UpdatePagesFromPriceList(int priceListId, IList<CatalogPage> destinationLst)
        {
            PriceList pl = GetById(priceListId);

            //Saco de la base los originales
            IList<CatalogPage> originalDestinationLst = new List<CatalogPage>(pl.CategoryPages);
            
            //Tomo los cambios del lado izquierdo
            IList<CatalogPage> tempSource = new List<CatalogPage>();
            foreach (CatalogPage odl in originalDestinationLst)
            {
                if (!destinationLst.Contains(odl))
                    tempSource.Add(odl);
            }
            if(tempSource.Count > 0)
                ControllerManager.PriceList.RemovePagesFromPriceList(tempSource, pl);

            //Tomo los cambios del lado derecho
            IList<CatalogPage> tempDestination = new List<CatalogPage>();
            foreach (CatalogPage dP in destinationLst)
            {
                if (!originalDestinationLst.Contains(dP))
                    tempDestination.Add(dP);
            }
            //si hay alguno nuevo para agregar, se agrega
           if( tempDestination.Count > 0)
                ControllerManager.PriceList.AddPagesToPriceList(tempDestination, pl);

            NHibernateSession.Flush();
        }

        public void AddDistributor(int priceListId, string code)
        {
            PriceList pl = GetById(priceListId);
            Distributor d = ControllerManager.Distributor.GetByCode(code);

            d.PriceList = pl;
            NHibernateSession.Flush();
        }
    }
}