using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using Iesi.Collections.Generic;

namespace PriceManager.Core
{
    [Serializable]
    public class Distributor : BaseAuditableEntity<int>
    {
        private string code;
        private string name;
        private string description;
        private DistributorStatus distributorStatus;
        private Country country;
        private string email;
        private string alternativeEmail;
        private string telephone;
        private string contact;
        private decimal discount;
        private PriceList priceList;
        private Lookup paymentTerm;
        private string address;
        private string fax;
        private string salesTaxCode;
        private string scalaPaymentTerm;
        private string salePrevYear;
        private string saleYTD;
        private string profitYTD;
        private string comment;
        private string scalaCountryCode;
        private string completeName;
        private string impExpCustomer;
        private Incoterm? saleConditions;
        private Lookup type;
        private ICollection<Quote> quotes = new HashedSet<Quote>();

        public virtual ICollection<Quote> Quotes
        {
            get { return quotes; }
            set { quotes = value; }
        }

        [DomainSignature]
        public virtual string Code
        { 
          get { return code; }
          set { code = value; }
        }

        [DomainSignature]
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual string NameCode
        {
            get { return string.Format("{0}-[{1}]", Name, Code.TrimEnd()).TrimEnd(); }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DomainSignature]
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

        public virtual string AlternativeEmail
        {
            get { return alternativeEmail; }
            set { alternativeEmail = value; }
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

        public virtual DistributorStatus DistributorStatus
        {
            get { return distributorStatus; }
            set { distributorStatus = value; }
        }

        public virtual decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual Lookup PaymentTerm
        {
            get { return paymentTerm; }
            set { paymentTerm = value; }
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

        public virtual string SalesTaxCode
        {
            get { return salesTaxCode; }
            set { salesTaxCode = value; }
        }

        public virtual string ScalaPaymentTerm
        {
            get { return scalaPaymentTerm; }
            set { scalaPaymentTerm = value; }
        }

        public virtual string SalePrevYear
        {
            get { return salePrevYear; }
            set { salePrevYear = value; }
        }

        public virtual string SaleYTD
        {
            get { return saleYTD; }
            set { saleYTD = value; }
        }

        public virtual string ProfitYTD
        {
            get { return profitYTD; }
            set { profitYTD = value; }
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

        public virtual string ImpExpCustomer
        {
            get { return impExpCustomer; }
            set { impExpCustomer = value; }
        }

        public virtual Incoterm? SaleConditions
        {
            get { return saleConditions; }
            set { saleConditions = value; }
        }

        public virtual Lookup Type
        {
            get { return type; }
            set { type = value; }
        }

        public Distributor() { }

        public Distributor(int id)
        {
            this.id = id;
            
        }
        public Distributor(string name, string code)
        {
            this.name = name;
            this.code = code;
        }
    }

}
