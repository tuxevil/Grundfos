using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class Provider : BaseAuditableEntity<int>
    {
        private string code;
        private string name;
        private string description;
        private Lookup saleConditions;
        private string purchaseConditions;
        private string city;
        private Country country;
        private string email;
        private string telephone;
        private string contact;
        private ProviderStatus providerStatus;
        private ICollection<PriceBase> priceBases = new HashedSet<PriceBase>();
        private ICollection<Product> products = new HashedSet<Product>();
        private int leadTime;
        private decimal discount;
        private string address;
        private string fax;
        private string purchPrevYear;
        private string purchaseYTD;
        private DateTime? lastInvDate;
        private string comment;
        private string scalaCountryCode;
        private string completeName;
        private string taxCode;
        private Lookup purchaseType;

        public Provider(int id)
        {
            this.id = id;
        }

        public Provider()
        {
        }

        [DomainSignature]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual Lookup SaleConditions
        {
            get { return saleConditions; }
            set { saleConditions = value; }
        }

        public virtual string PurchaseConditions
        {
            get { return purchaseConditions; }
            set { purchaseConditions = value; }
        }

        public virtual string City
        {
            get { return city; }
            set { city = value; }
        }

        public virtual Country Country
        {
            get { return country; }
            set { country = value; }
        }

        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }

        public virtual string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public virtual string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public virtual ProviderStatus ProviderStatus
        {
            get { return providerStatus; }
            set { providerStatus = value; }
        }

        public virtual ICollection<PriceBase> PriceBases
        {
            get { return priceBases; }
            set { priceBases = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual int LeadTime
        {
            get { return leadTime; }
            set { leadTime = value; }
        }

        public virtual decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public virtual string PurchPrevYear
        {
            get { return purchPrevYear; }
            set { purchPrevYear = value; }
        }

        public virtual string PurchaseYTD
        {
            get { return purchaseYTD; }
            set { purchaseYTD = value; }
        }

        public virtual DateTime? LastInvDate
        {
            get { return lastInvDate; }
            set { lastInvDate = value; }
        }

        public virtual string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public virtual string ScalaCountryCode
        {
            get { return scalaCountryCode; }
            set { scalaCountryCode = value; }
        }

        public virtual string CompleteName
        {
            get { return completeName; }
            set { completeName = value; }
        }

        public virtual string TaxCode
        {
            get { return taxCode; }
            set { taxCode = value; }
        }

        public virtual Lookup PurchaseType
        {
            get { return purchaseType; }
            set { purchaseType = value; }
        }
    }
}
