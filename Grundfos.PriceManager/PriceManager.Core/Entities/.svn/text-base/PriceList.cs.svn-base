using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class PriceList : BaseAuditableEntity<int>
    {
        private string name;
        private string description;
        private PriceGroup priceGroup;
        private decimal discount;
        private PriceListStatus priceListStatus;
        private ICollection<PublishList> publishLists  = new HashedSet<PublishList>();
        private ICollection<Distributor> distributors = new HashedSet<Distributor>();
        private ICollection<WorkListItem> items = new HashedSet<WorkListItem>();
        private Frequency? frecuency;
        private Lookup saleCondition;
        private PriceListCurrentState currentState;
        private Lookup type;
        private Currency currency;
        private ICollection<CatalogPage> categoryPages = new HashedSet<CatalogPage>();
        
        public PriceList(int id)
        {
            this.id = id;
        }

        public PriceList()
        {
        }

        public virtual PriceListCurrentState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        [DomainSignature]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string FullName
        {
            get
            {
                if (this.PriceGroup != null)
                    return string.Format("{0} - {1}", this.PriceGroup.Name, this.Name);

                return Name;
            }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DomainSignature]
        public virtual PriceGroup PriceGroup
        {
            get { return priceGroup; }
            set { priceGroup = value; }
        }

        public virtual decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual PriceListStatus PriceListStatus
        {
            get { return priceListStatus; }
            set { priceListStatus = value; }
        }

        public virtual ICollection<PublishList> PublishLists
        {
            get { return publishLists; }
            set { publishLists = value; }
        }

        public virtual ICollection<Distributor> Distributors
        {
            get { return distributors; }
            set { distributors = value; }
        }

        public virtual Frequency? Frecuency
        {
            get { return frecuency; }
            set { frecuency = value; }
        }

        public virtual Lookup SaleCondition
        {
            get { return saleCondition; }
            set { saleCondition = value; }
        }

        public virtual ICollection<WorkListItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        public virtual Lookup Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual Currency Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        public virtual ICollection<CatalogPage> CategoryPages
        {
            get { return categoryPages; }
            set { categoryPages = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}", this.id);
        }
    }
}
