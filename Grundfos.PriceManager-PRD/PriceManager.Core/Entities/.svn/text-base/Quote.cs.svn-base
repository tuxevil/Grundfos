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
        private string email;
        private string contact;

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

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public Quote () { }

        public Quote (int id)
        {
            this.id = id;
        }
    }
}
