using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class Quote : BaseAuditableEntity<int>
    {
        private string number;
        private Distributor distributor;
        private string description;
        private string observations;
        private string distributorObservation;
        private QuoteStatus status;
        private ICollection<QuoteItem> quoteItems = new HashedSet<QuoteItem>();
        private Lookup introText;
        private Lookup condition;
        private Lookup vigency;
        private ICollection<IQuoteNotification> quoteNotifications = new HashedSet<IQuoteNotification>();
        private DateTime? sentDate;
        private Currency currency;
        private CurrencyRate currencyRate;
        private List<QuoteItem> sortedQuoteItems = new List<QuoteItem>();
        
        [DomainSignature]
        public virtual string Number
        {
            get { return number; }
            set { number = value; }
        }

        [DomainSignature]
        public virtual Distributor Distributor
        {
            get { return distributor; }
            set { distributor = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Observations
        {
            get { return observations; }
            set { observations = value; }
        }

        public virtual string DistributorObservation
        {
            get { return distributorObservation; }
            set { distributorObservation = value; }
        }

        public virtual QuoteStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual ICollection<QuoteItem> QuoteItems
        {
            get { return quoteItems; }
            set { quoteItems = value; }
        }

        public virtual Lookup IntroText
        {
            get { return introText; }
            set { introText = value; }
        }

        public virtual Lookup Vigency
        {
            get { return vigency; }
            set { vigency = value; }
        }

        public virtual Lookup Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public virtual ICollection<IQuoteNotification> QuoteNotifications
        {
            get { return quoteNotifications; }
            set { quoteNotifications = value; }
        }

        public virtual string Contacts
        {
            get
            {
                string contacts = string.Empty;
                foreach (IQuoteNotification notification in this.QuoteNotifications)
                    contacts += notification.Name + " [" + notification.Email + "]; ";
                return contacts;
            }
        }

        public virtual DateTime? SentDate
        {
            get { return sentDate; }
            set { sentDate = value; }
        }

        public virtual Currency Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public virtual ICollection<QuoteItem> ActiveQuoteItems
        {
            get
            {
                List<QuoteItem> lst = new List<QuoteItem>(quoteItems);
                return lst.FindAll(delegate(QuoteItem record)
                                                    {
                                                        if (record.Price > 0)
                                                            return true;

                                                        return false;
                                                    });
            }
        }

        public virtual CurrencyRate CurrencyRate
        {
            get { return currencyRate; }
            set { currencyRate = value; }
        }

        public virtual List<QuoteItem> SortedQuoteItems
        {
            get
            {
                sortedQuoteItems  = new List<QuoteItem>(quoteItems);
                sortedQuoteItems.Sort(delegate(QuoteItem qi1, QuoteItem qi2) { return qi1.Order.CompareTo(qi2.Order); });
                return sortedQuoteItems;
            }
        }

        public Quote () { }

        public Quote (int id)
        {
            this.id = id;
        }

        public virtual void AddNotification(Contact contact, string name, string email)
        {
            List<IQuoteNotification> tmp = new List<IQuoteNotification>(this.quoteNotifications);
            if (contact != null)
            {
                if (!tmp.Exists(delegate(IQuoteNotification record)
                                    {
                                        if (record.Email == contact.Email)
                                            return true;
                                        return false;
                                    }))
                {
                    ContactQuoteNotification cqn = new ContactQuoteNotification();
                    cqn.Name = contact.Name + " " + contact.LastName;
                    cqn.Email = contact.Email;
                    cqn.Contact = contact;
                    cqn.Quote = this;
                    this.quoteNotifications.Add(cqn);
                    return;
                }
            }
            else
            {
                if (!tmp.Exists(delegate(IQuoteNotification record)
                                                  {
                                                      if (record.Email == email)
                                                          return true;
                                                      return false;
                                                  }))
                {
                    QuoteNotification qn = new QuoteNotification();
                    qn.Name = name;
                    qn.Email = email;
                    qn.Quote = this;
                    this.quoteNotifications.Add(qn);
                    return;
                }
            }
            throw new QuoteNotificationAlreadyExistException(string.Empty);
            
        }
    }
}
