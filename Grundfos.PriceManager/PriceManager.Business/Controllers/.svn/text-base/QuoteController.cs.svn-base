using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NHibernate;
using NybbleMembership.Core.Domain;
using PriceManager.Core;
using PriceManager.Core.Interfaces;
using ProjectBase.Data;
using ProjectBase.Utils.Email;
using ProjectBase.Utils.MailSender;
using NybbleMembership;
using PriceManager.Common;
using System.Collections;
using NybbleMembership.Core;
using PriceManager.Core.State;

namespace PriceManager.Business
{
    public class QuoteController
    {
        private readonly IQuoteRepository repository;
        private CurrencyRateConverter[,] lstRates;

        public QuoteController(IQuoteRepository repository)
        {
            this.repository = repository;
        }

        public IList Check()
        {
            ExecutePermissionValidator epv = new ExecutePermissionValidator();
            epv.ClassType = typeof(Quote);
            epv.KeyIdentifier = Config.SeeQuotes;
            IList quoteIds = null;

            if (PermissionManager.Check(epv) == false)
                quoteIds = PermissionManager.GetPermissionIdentifiers(typeof(Quote), PermissionAction.Create);

            return quoteIds;
        }

        public void Send(Quote q, byte[] filecontent)
        {
            MembershipHelperUser mhu = MembershipHelper.GetUser(q.TimeStamp.CreatedBy);
            IList<string[]> lstMails = new List<string[]>();
            if (q.QuoteNotifications.Count > 0)
                foreach (IQuoteNotification quoteNotification in q.QuoteNotifications)
                {
                    string[] _contact = new string[2];
                    _contact[0] = quoteNotification.Name;
                    _contact[1] = quoteNotification.Email;
                    lstMails.Add(_contact);
                }
            else
            {
                string name = q.Distributor.Contact;
                string email = q.Distributor.Email;
                if (string.IsNullOrEmpty(email))
                    email = q.Distributor.AlternativeEmail;

                string[] _contact = new string[2];
                _contact[0] = name;
                _contact[1] = email;
                lstMails.Add(_contact);
            }


            if (mhu != null)
            {
                string[] _contact = new string[2];
                _contact[0] = mhu.FullName;
                _contact[1] = mhu.Email;
                lstMails.Add(_contact);
            }

            if (ControllerManager.Lookup.List(LookupType.AdministratorReceiveMail)[0].Description == "True")
            {
                IList<UserMember> umlst = MembershipManager.GetAdministrators();
                foreach (UserMember um in umlst)
                {
                    string[] _contact = new string[2];
                    _contact[0] = um.UserName;
                    _contact[1] = um.Email;
                    lstMails.Add(_contact);
                }
            }
            
            string title = "Cotizaciones";
            string subject = "Cotización para " + q.Distributor.Name;
            string fileName = "Cotizacion" + q.Number + ".pdf";

            WebMailing w = new WebMailing();
            foreach (string[] currentEmail in lstMails)
            {
                string body = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath(Config.MailTemplatePath), "quote.htm"));
                body = body.Replace("[QUOTE_CONTACT]", currentEmail[0]);
                body = body.Replace("[QUOTE_BODY]", Resource.Business.GetString("QuoteBody"));
                body = body.Replace("[QUOTE_OBSERVATION]", q.Observations);
                body = body.Replace("[USUARIO]", mhu.FullName);
                body = body.Replace("[EMAIL]", mhu.Email);

                w.SendMail(currentEmail[1], title, subject, body, false, false, mhu.Email, mhu.FullName, fileName, filecontent);
            }

            q.Status = QuoteStatus.Sent;
            if(q.SentDate == null)
                q.SentDate = DateTime.Now;
            repository.Save(q);
            repository.CommitChange();
        }

        public void Reject(Quote q)
        {
            q = repository.GetById(q.ID);
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

        public Quote AddItems(GridState gridState, int quoteId, string distributorName, string description, string observations, int vigency, int quoteCondition, int quoteIntroText, string email, string contact, out bool canfinal, List<int> contactids, int currencyId)
        {
            lstRates = ControllerManager.CurrencyRate.GetArray();

            canfinal = true;
            Currency c = ControllerManager.Currency.GetById(currencyId);
            Quote q = new Quote();
            if (quoteId > 0)
                q = repository.GetById(quoteId);

            Distributor d = ControllerManager.Distributor.GetByName(distributorName);
            q.Distributor = d;
            q.Condition = ControllerManager.Lookup.GetById(quoteCondition);
            q.Description = description;
            q.IntroText = ControllerManager.Lookup.GetById(quoteIntroText);
            q.Observations = observations;
            q.Status = QuoteStatus.Draft;
            q.Vigency = ControllerManager.Lookup.GetById(vigency);
            q.Currency = c;
            q.CurrencyRate = ControllerManager.CurrencyRate.GetLast(q.Currency);
            
            List<Contact> temp = new List<Contact>(d.Contacts);
            AddContactNotifications(q, temp, contactids);
            if(!string.IsNullOrEmpty(email.Trim()))
                AddNotifications(q, contact.Trim(), email.Trim());
            
            if(q.QuoteNotifications.Count == 0 && !string.IsNullOrEmpty(q.Distributor.Email))
                AddNotifications(q, q.Distributor.Contact, q.Distributor.Email);
            else if (q.QuoteNotifications.Count == 0 && !string.IsNullOrEmpty(q.Distributor.AlternativeEmail))
                AddNotifications(q, q.Distributor.Contact, q.Distributor.AlternativeEmail);

            //Si no limpiamos los items antes de agregarlos, se ahorraria tiempo y se podria acomodar por fecha de creación.
            //¿Porque se sacan todos?
            //q.QuoteItems.Clear();

            List<PriceBase> temppblist = ControllerManager.PriceBase.GetPriceBases(string.Empty, null, null, null, null, null, null, false, gridState.Items, false, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            int i = 1;
            foreach (int item in gridState.Items)
            {
                PriceBase pb = temppblist.Find(delegate(PriceBase record)
                                           {
                                               if (record.ID == item)
                                               {
                                                   return true;
                                               }
                                               return false;
                                           });
                canfinal = canfinal && AddItem(q, pb, string.Empty, i);
                i++;
            }


            //foreach (PriceBase priceBase in temppblist)
            //    canfinal = canfinal && AddItem(q, priceBase, string.Empty);

            repository.Save(q);
            repository.CommitChange();
            q.Number = q.ID.ToString("000000");

            if (quoteId == 0)
                PermissionManager.AddEntityPermision(q.GetType(), q.ID.ToString(), MembershipHelper.GetUser().UserName);

            return q;
        }

        private bool AddItem(Quote q, PriceBase priceBase, string observation, int order)
        {
            bool added = true;

            List<QuoteItem> tmplst = new List<QuoteItem>(q.QuoteItems);

            decimal pL = 0;
            Currency plCurrency = null;
            
            QuoteItem qi = tmplst.Find(delegate(QuoteItem record)
                                           {
                                               if (record.PriceBase.ID == priceBase.ID)
                                               {
                                                   return true;
                                               }
                                               return false;
                                           });
            if(qi == null)
            {
                qi = new QuoteItem();
                qi.Quote = q;
            }
            qi.Observation = observation;
            qi.Order = order;
            qi.Quantity = 1;

            if (qi.SaleCondition == null)
            {
                if (qi.PriceBase != null && qi.PriceBase.Provider != null && qi.PriceBase.Provider.SaleConditions != null)
                    qi.SaleCondition = qi.PriceBase.Provider.SaleConditions;
                else
                    qi.SaleCondition = ControllerManager.Lookup.List(LookupType.Incoterm, true)[0];
            }
            if(string.IsNullOrEmpty(qi.DeliveryTime))
                qi.DeliveryTime = ControllerManager.Lookup.List(LookupType.DeliveryTime, true)[0].Description;

            if (qi.DeliveryTerm == null)
                qi.DeliveryTerm = ControllerManager.Lookup.List(LookupType.DeliveryTerm, true)[0];

            ValidateQuoteItem(q, priceBase, qi, out pL, out plCurrency);
            qi.LastPrice = qi.Price;
            q.QuoteItems.Add(qi);
            
            if(pL == 0)
                added = false;

            return added;
        }

        public bool ValidateQuote(Quote q)
        {
            if(q.Status == QuoteStatus.Sent)
                return true;

            lstRates = ControllerManager.CurrencyRate.GetArray();
            bool canfinal = true;
            List<QuoteItem> removelst = new List<QuoteItem>();
            foreach (QuoteItem quoteItem in q.QuoteItems)
            {
                if(quoteItem.PriceBase.Status == PriceBaseStatus.Disable)
                {
                    removelst.Add(quoteItem);
                    canfinal = false;
                    continue;
                }
                bool can = ValidateQuoteItem(q, quoteItem);
                canfinal = canfinal && can;
            }
            foreach (QuoteItem item in removelst)
                q.QuoteItems.Remove(item);

            return canfinal;
        }

        private bool ValidateQuoteItem(Quote q, QuoteItem qi)
        {
            decimal pL;
            Currency plCurrency;
            return ValidateQuoteItem(q, qi.PriceBase, qi, out pL, out plCurrency);
        }

        private bool ValidateQuoteItem(Quote q, PriceBase priceBase, QuoteItem qi, out decimal pL, out Currency plCurrency)
        {
            plCurrency = null;
            pL = 0;

            PublishItem pi = ControllerManager.PublishList.GetPublishItem(q.Distributor, priceBase);
            PriceAttribute pa = null;

            if (pi != null)
            {
                // Lista de Precio (Publicada)
                qi.PriceBase = priceBase;
                pL = pi.Price;
                plCurrency = pi.PriceCurrency;
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
                        pL = pa.Price;
                        plCurrency = pa.PriceCurrency;
                        qi.Source = Resource.Business.GetString("Country");
                    }
                }

                if (pa == null)
                {
                    // Base o Fuera de Lista
                    decimal? factor = null;
                    if (q.Distributor.PriceList != null)
                        if (q.Distributor.PriceList.PriceGroup.Adjust != null)
                            factor = q.Distributor.PriceList.PriceGroup.Adjust;
                    if (factor == null || factor == 0)
                        factor = 1;
                    qi.PriceBase = priceBase;
                    pL = priceBase.PriceList / Convert.ToDecimal(factor);
                    plCurrency = priceBase.PriceListCurrency;

                    if (priceBase.Status == PriceBaseStatus.Verified)
                        qi.Source = Resource.Business.GetString("Base");
                    else if (priceBase.Status == PriceBaseStatus.NotVerified)
                        qi.Source = Resource.Business.GetString("OutOfList");
                }
            }

            decimal lastPrice = qi.Price;
            if (plCurrency != null)
            {
                qi.Price = Math.Round(pL * lstRates[plCurrency.ID - 1, q.Currency.ID - 1].Rate, 3);
                qi.PriceCurrency = q.Currency;
                qi.CurrencyRate = ControllerManager.CurrencyRate.GetLast(q.Currency);
            }
            
            return lastPrice == qi.Price;
        }
        
        private void AddContactNotifications(Quote q, List<Contact> contacts, List<int> contactids)
        {
            q.QuoteNotifications.Clear();
            foreach (int contactid in contactids)
            {
                Contact c = contacts.Find(delegate(Contact record)
                                                     {
                                                         if (record.ID == contactid)
                                                         {
                                                             return true;
                                                         }
                                                         return false;
                                                     });
                if (c != null)
                {
                    try
                    {
                        q.AddNotification(c, string.Empty, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        if (ex is QuoteNotificationAlreadyExistException)
                        {
                            continue;
                        }
                        
                        throw ex;
                    }



                }
            }
        }

        private void AddNotifications(Quote q, string name, string email)
        {
            try
            {
                q.AddNotification(null, name, email);
            }
            catch (Exception ex)
            {
                if (ex is QuoteNotificationAlreadyExistException)
                {
                    return;
                }
                throw ex;
            }
        }

        public void GetAssistence(Quote q, string path)
        {
            q = GetById(q.ID);
            q.Status = QuoteStatus.AssistenceRequired;
            
            IList<UserMember> umlst = MembershipManager.GetAdministrators();
            MembershipHelperUser user = MembershipHelper.GetUser();

            IList<Note> lst = ControllerManager.Note.ListByType(q.GetType(), q.ID, 1);

            foreach (UserMember userMember in umlst)
            {
                //PermissionManager.AddEntityPermision(q.GetType(), q.ID.ToString(), userMember.UserName);
                WebMailing w = new WebMailing();
                string body = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath(Config.MailTemplatePath), "quote.htm"));
                body = body.Replace("[QUOTE_CONTACT]", MembershipHelper.GetUser(userMember.ID).FullName);
                body = body.Replace("[QUOTE_BODY]", path);
                body = body.Replace("[QUOTE_OBSERVATION]", lst[0].Description);
                body = body.Replace("[USUARIO]", user.FullName);
                body = body.Replace("[EMAIL]", user.Email);

                w.SendMail(userMember.Email, "", "Se ha solicitado asistencia en la cotización " + q.Number, body, false);
            }

            Save(q);
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

            DateTime date = DateTime.Today;
            if (q.SentDate != null)
                date = Convert.ToDateTime(q.SentDate);

            document.Add(new Paragraph("Buenos Aires, " + date.ToLongDateString()));
            document.Add(new Paragraph("Cotización Nro: " + q.ID));
            if(includePriceSell)
                document.Add(new Paragraph("Descuento: " + q.Distributor.Discount.ToString("##0.00") + "%"));
            document.Add(new Paragraph(q.IntroText.Description));
            
            IList<QuoteItemView> lst = new List<QuoteItemView>();

            foreach (QuoteItem item in q.ActiveQuoteItems)
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
            document.Add(new Paragraph("Los precios son: " + ((q.Distributor.SaleConditions != null) ? q.Distributor.SaleConditions.Description : "N/D")));
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

        #region Repository Methods

        public IList<Quote> List(GridState gridState, string text, Distributor distributor, QuoteStatus? status, out int records, Guid? userId, IList quoteIds)
        {
            return repository.List(gridState, text, distributor, status, out records, userId, quoteIds);
        }
        public ICriteria ListCriteria(string text, Distributor distributor, QuoteStatus? status, Guid? userId, IList quoteIds)
        {
            return repository.ListCriteria(text, distributor, status, userId, quoteIds);
        }
        public IList<Quote> GetQuotesByUser(Distributor d, MembershipHelperUser user)
        {
            return repository.GetQuotesByUser(d, user.UserId);
        }
        public Quote GetById(int id)
        {
            return repository.GetById(id);
        }
        public Quote Save(Quote q)
        {
            return repository.Save(q);
        }
        public void BeginTransactions()
        {
            repository.BeginTransactions();
        }
        public void CommitChange()
        {
            repository.CommitChange();
        }
        public void Refresh(object o)
        {
            repository.Refresh(o);
        }

        #endregion

        public QuoteItem GetQuoteItem(int quoteId, int quoteItemId)
        {
            Quote q = GetById(quoteId);

            List<QuoteItem> lst = new List<QuoteItem>(q.QuoteItems);
            QuoteItem qi = lst.Find(delegate(QuoteItem record)
                                   {
                                       if (record.ID == quoteItemId)
                                           return true;

                                       return false;
                                   });
            return qi;
        }

        public QuoteItem EditQuoteItem(int quoteId, int quoteItemId, int quantity, string deliveryTime, Lookup deliveryTerm, Lookup saleCondition, decimal listPrice)
        {
            BeginTransactions();

            Quote q = GetById(quoteId);

            List<QuoteItem> lst = new List<QuoteItem>(q.QuoteItems);
            QuoteItem qi = lst.Find(delegate(QuoteItem record)
                                   {
                                       if (record.ID == quoteItemId)
                                           return true;

                                       return false;
                                   });

            qi.Quantity = quantity;
            qi.DeliveryTime = deliveryTime;
            qi.DeliveryTerm = deliveryTerm;
            qi.SaleCondition = saleCondition;
            qi.LastPrice = listPrice;

            repository.Save(q);
            CommitChange();

            return qi;
        }
    }

    public class QuoteItemController : AbstractNHibernateDao<QuoteItem, int>
    {
        public QuoteItemController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
    }
}
