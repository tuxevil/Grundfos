using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NHibernate;
using NHibernate.Criterion;
using NybbleMembership.Core.Domain;
using PriceManager.Core;
using ProjectBase.Data;
using ProjectBase.Utils.Email;
using ProjectBase.Utils.MailSender;
using NybbleMembership;
using PriceManager.Common;
using System.Collections;
using NybbleMembership.Core;

namespace PriceManager.Business
{
    public class QuoteController : AbstractNHibernateDao<Quote, int>
    {
        public QuoteController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Quote> List(GridState gridState, string text, Distributor distributor, QuoteStatus? status, out int records, Guid? userId)
        {
            ICriteria crit = ListCriteria(text, distributor, status, userId);

            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));
            
            records = crit.UniqueResult<int>();
            if (records == 0)
                return new List<Quote>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, records);

            crit = ListCriteria(text, distributor, status, userId);
            
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
                critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<Quote>();
        }

        private ICriteria ListCriteria(string text, Distributor distributor, QuoteStatus? status, Guid? userId)
        {
            ICriteria crit = GetCriteria();

            //check quote permissions
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Quote);
            epv.KeyIdentifier = Config.SeeQuotes;

            if (PermissionManager.Check(epv) == false)
            {
                IList quoteIds = PermissionManager.GetPermissionIdentifiers(typeof(Quote), PermissionAction.Create);
                int[] intQuoteIds = new int[quoteIds.Count];
                for (int i = 0; i < quoteIds.Count; i++)
                    intQuoteIds[i] = Convert.ToInt32(quoteIds[i]);

                crit.Add(Expression.In("ID", intQuoteIds));
            }

            if (!string.IsNullOrEmpty(text))
            {
                Disjunction d = new Disjunction();
                d.Add(Restrictions.InsensitiveLike("Description", text, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("Observations", text, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("Number", text, MatchMode.Anywhere));
                crit.Add(d);
            }
            if (distributor != null)
                crit.Add(Expression.Eq("Distributor", distributor));

            if (status != null)
                crit.Add(Expression.Eq("Status", status));

            if (userId.HasValue)
                crit.Add(Expression.Eq("TimeStamp.ModifiedBy", userId));

            return crit;
        }

        public void Send(Quote q, byte[] filecontent)
        {
            string body = File.ReadAllText(
                Path.Combine(HttpContext.Current.Server.MapPath(Config.MailTemplatePath), "quote.htm"));
            
            string email = q.Email;
            if (string.IsNullOrEmpty(email))
                email = q.Distributor.Email;
            if (string.IsNullOrEmpty(email))
                email = q.Distributor.AlternativeEmail;
            q.Status = QuoteStatus.Sent;
            Save(q);
            this.CommitChanges();

            MembershipHelperUser mhu = MembershipHelper.GetUser(q.TimeStamp.CreatedBy);
            body = body.Replace("[QUOTE_BODY]", Resource.Business.GetString("QuoteBody"));
            body = body.Replace("[QUOTE_OBSERVATION]", q.Observations);
            body = body.Replace("[USUARIO]", mhu.FullName);
            body = body.Replace("[EMAIL]", mhu.Email);

            string title = "Cotizaciones";
            string subject = "Cotización para " + q.Distributor.Name;
            string fileName = "Cotizacion" + q.Number + ".pdf";

            IList<string> lstMails = new List<string>();
            lstMails.Add(email);
            if (mhu != null)
                lstMails.Add(mhu.Email);

            if (ControllerManager.Lookup.List(LookupType.AdministratorReceiveMail)[0].Description == "True")
            {
                IList<UserMember> umlst = MembershipManager.GetAdministrators();
                foreach (UserMember um in umlst)
                    lstMails.Add(um.Email);
            }

            WebMailing w = new WebMailing();
            foreach (string currentEmail in lstMails)
                w.SendMail(currentEmail, title, subject, body, false, false, mhu.Email, mhu.FullName, fileName, filecontent);
        }

        public void Reject(Quote q)
        {
            q = GetById(q.ID);
            if(q.TimeStamp.CreatedBy == null)
                return;

            MembershipHelperUser mu = MembershipHelper.GetUser((Guid) q.TimeStamp.CreatedBy);
            Reject(q, mu.Email);
        }
        
        private void Reject(Quote q, string creatoremail)
        {
            if(string.IsNullOrEmpty(creatoremail) || q.Status == QuoteStatus.Sent)
                return;

            q.Status = QuoteStatus.Rejected;

            string body = File.ReadAllText(
                Path.Combine(HttpContext.Current.Server.MapPath(Config.MailTemplatePath), "rejectquote.htm"));

            body = body.Replace("[QUOTE_BODY]", string.Format(Resource.Business.GetString("QuoteReject"), q.Number, q.Description));
            body = body.Replace("[USUARIO]", MembershipHelper.GetUser().UserName);

            WebMailing wm = new WebMailing();
            wm.SendMail(creatoremail, "Cotización Rechazada", "Cotización rechazada", body, false);
        }

        public Quote AddItems(GridState gridState, IList<Filters.IFilter> filters, int quoteId, string distributorName, string description, string observations, int vigency, int quoteCondition, int quoteIntroText, string email, string contact, out bool canfinal)
        {
            canfinal = true;
            Quote q = new Quote();
            if (quoteId > 0)
                q = GetById(quoteId);

            q.Distributor = ControllerManager.Distributor.GetByName(distributorName);
            q.Condition = ControllerManager.Lookup.GetById(quoteCondition);
            q.Description = description;
            q.IntroText = ControllerManager.Lookup.GetById(quoteIntroText);
            q.Observations = observations;
            q.Status = QuoteStatus.Draft;
            q.Vigency = ControllerManager.Lookup.GetById(vigency);
            q.Email = email;
            q.Contact = contact;

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            //Si no limpiamos los items antes de agregarlos, se ahorraria tiempo y se podria acomodar por fecha de creación.
            //¿Porque se sacan todos?
            q.QuoteItems.Clear();
            List<PriceBase> temppblist = ControllerManager.PriceBase.GetPriceBases(string.Empty, null, null, null, null, null, null, false, gridState.Items, false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            foreach (PriceBase priceBase in temppblist)
                canfinal = canfinal && AddItem(q, priceBase, string.Empty);

            Save(q);
            CommitChanges();
            q.Number = q.ID.ToString("000000");

            if (quoteId == 0)
                PermissionManager.AddEntityPermision(q.GetType(), q.ID.ToString(), MembershipHelper.GetUser().UserName);

            return q;
        }

        private bool AddItem(Quote q, PriceBase priceBase, string observation)
        {
            bool added = true;

            List<QuoteItem> tmplst = new List<QuoteItem>(q.QuoteItems);
            if(tmplst.Exists(delegate(QuoteItem record)
                                                         {
                                                             if (record.PriceBase.ID == priceBase.ID)
                                                             {
                                                                 return true;
                                                             }
                                                             return false;
                                                         }))
                return true;

            QuoteItem qi = new QuoteItem();
            qi.Observation = observation;
            qi.Quote = q;
            
            PublishItem pi = ControllerManager.PublishList.GetPublishItem(q.Distributor, priceBase);
            PriceAttribute pa = null;

            if(pi != null)
            {
                // Lista de Precio (Publicada)
                qi.PriceBase = priceBase;
                qi.Price = pi.Price;
                qi.PriceCurrency = pi.PriceCurrency;
                qi.CurrencyRate = pi.CurrencyRate;
                qi.Source = pi.PublishList.PriceList.Name;
            }
            else 
            {
                if (q.Distributor.PriceList != null)
                {
                    pa = ControllerManager.PriceAttribute.GetPriceAttribute(q.Distributor.PriceList.PriceGroup,
                                                                            priceBase);
                    if (pa != null)
                    {
                        // Pais
                        qi.PriceBase = priceBase;
                        qi.Price = pa.Price;
                        qi.PriceCurrency = pa.PriceCurrency;
                        qi.CurrencyRate = pa.CurrencyRate;
                        qi.Source = Resource.Business.GetString("Country");
                    }
                }

                if (pa == null) {
                    // Base
                    decimal? factor = null;
                    if (q.Distributor.PriceList != null)
                        if (q.Distributor.PriceList.PriceGroup.Adjust != null)
                        factor = q.Distributor.PriceList.PriceGroup.Adjust;
                    if (factor == null || factor == 0)
                        factor = 1;
                    qi.PriceBase = priceBase;
                    qi.Price = priceBase.PriceList / Convert.ToDecimal(factor);
                    qi.PriceCurrency = priceBase.PriceListCurrency;
                    qi.CurrencyRate = priceBase.CurrencyRate;

                    if (priceBase.Status == PriceBaseStatus.Verified)
                        qi.Source = Resource.Business.GetString("Base");
                    else if (priceBase.Status == PriceBaseStatus.NotVerified)
                        qi.Source = Resource.Business.GetString("OutOfList");
                }
            }

            if (qi.Price > 0)
                q.QuoteItems.Add(qi);
            else
                added = false;

            return added;
        }

        #region Export to PDF
        public MemoryStream ExportToPDF(Quote q, string imagepath, bool includePriceSell)
        {
            MemoryStream ms = new MemoryStream();
            System.Drawing.Image.FromFile(imagepath).Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            
            Font myfont = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
            Document document = new Document(PageSize.LETTER);
            document.AddHeader("Expires", "0");

            MemoryStream stream = new MemoryStream();
            PdfWriter.GetInstance(document, stream).CloseStream = false;

            GeneratePDFHeaderFooter(document);
            
            document.Open();
            document.NewPage();

            GeneratePDFHeaderFooter(document);

            Image im = Image.GetInstance(ms.ToArray());
            im.Alignment = Image.MIDDLE_ALIGN;
            im.ScalePercent(73);
            document.Add(im);
            
            document.Add(new Paragraph("Señores de:"));
            document.Add(new Paragraph(q.Distributor.Name));
            document.Add(new Paragraph("Att:"));
            if(!string.IsNullOrEmpty(q.Contact))
                document.Add(new Paragraph(q.Contact));
            else
                document.Add(new Paragraph(q.Distributor.Contact));
            document.Add(new Paragraph("Buenos Aires, " + q.TimeStamp.CreatedOn.ToLongDateString()));
            document.Add(new Paragraph("Cotización Nro: " + q.ID));
            if(includePriceSell)
                document.Add(new Paragraph("Descuento: " + q.Distributor.Discount.ToString("##0.00") + "%"));
            document.Add(new Paragraph(q.IntroText.Description));
            
            IList<QuoteItemView> lst = new List<QuoteItemView>();

            foreach (QuoteItem item in q.QuoteItems)
                lst.Add(new QuoteItemView(item));

            string[] titles;
            string[] columns;

            SetTitlesAndColumns(out titles, out columns, includePriceSell);
            document.Add(GeneratePDFTable(lst, titles, columns, includePriceSell));

            Paragraph p = new Paragraph();
            p.SpacingBefore = 10;
            p.Add("Forma de Pago: " + ((q.Distributor.PaymentTerm != null) ? q.Distributor.PaymentTerm.Title : "N/D"));
            document.Add(p);
            document.Add(new Paragraph("Validez de la Oferta: " + q.Vigency.Description + " días."));
            document.Add(new Paragraph("Los precios son: " + ((q.Distributor.SaleConditions.HasValue) ? EnumHelper.GetDescription(q.Distributor.SaleConditions.Value) : "N/D")));
            document.Add(new Paragraph(q.Condition.Description));
            p = new Paragraph();
            p.SpacingBefore = 10;
            p.Add("Sin más, saludo a Uds atte.");
            document.Add(p);
            p = new Paragraph();
            p.SpacingBefore = 10;
            p.Add(q.CreatedByName);
            document.Add(p);
            document.Add(new Paragraph(MembershipHelper.GetUser(q.TimeStamp.CreatedBy).Email));

            document.Close();

            return stream;
            
        }

        private void GeneratePDFHeaderFooter(Document document)
        {
            Font myfont = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));

            Paragraph p = new Paragraph();
            p.Alignment = HeaderFooter.ALIGN_CENTER;
            p.Add(new Phrase("Datos al: " + DateTime.Now, myfont));

            HeaderFooter footer = new HeaderFooter(p, true);
            footer.Alignment = HeaderFooter.ALIGN_CENTER;
            footer.Border = Rectangle.NO_BORDER;

            document.Footer = footer;
        }

        private Table GeneratePDFTable(IList<QuoteItemView> list, string[] titles, string[] columns, bool includePriceSell)
        {
            Table datatable = new Table(columns.Length);
            datatable.Padding = 2;
            datatable.Spacing = 0;
            float[] headerwidths;

            if(includePriceSell)
                headerwidths = new float[] { 100, 300, 85, 85, 120 };
            else
                headerwidths = new float[] { 100, 300, 85, 120 };
            datatable.Widths = headerwidths;
            datatable.WidthPercentage = 100;

            datatable.DefaultCellBorderWidth = 1;
            datatable.BackgroundColor = Color.LIGHT_GRAY;

            Font myfont = new Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.NORMAL));

            Font myfontTitle = new Font(FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, new Color(255, 255, 255)));

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
                    if (column != "Description")
                        cel.HorizontalAlignment = Element.ALIGN_RIGHT;

                    datatable.AddCell(cel);
                }
            }
            return datatable;
        }

        private void SetTitlesAndColumns(out string[] titles, out string[] columns, bool includePriceSell)
        {
            if(includePriceSell)
            {
                titles = new string[]
                                 {
                                     "Código",
                                     "Descripción",
                                     "Precio de Venta",
                                     "Precio de Lista",
                                     "Plazo de Entrega"
                                 };
                columns = new string[]
                            {
                                 "ProductCode",
                                 "ProductName",
                                 "PriceSell",
                                 "Price",
                                 "LeadTime"
                            };
            }
            else
            {
                titles = new string[]
                                 {
                                     "Código",
                                     "Descripción",
                                     "Precio de Lista",
                                     "Plazo de Entrega"
                                 };
                columns = new string[]
                            {
                                 "ProductCode",
                                 "ProductName",
                                 "Price",
                                 "LeadTime"
                            };
            }
            
        }
        #endregion

        public IList<Quote> GetQuotesByUser(Distributor d, MembershipHelperUser user)
        {
            ICriteria crit = GetCriteria();
            if (user == null)
                return null;
            crit.Add(Expression.Eq("Distributor", d));
            crit.Add(Expression.Eq("TimeStamp.CreatedBy", user.UserId));

            return crit.List<Quote>();
        }
    }

    public class QuoteItemController : AbstractNHibernateDao<QuoteItem, int>
    {
        public QuoteItemController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
    }
}
