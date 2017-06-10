using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class Provider
    {
        private string name;
        private string description;
        private string saleConditions;
        private string purchaseConditions;
        private string city;
        private string country;
        private string email;
        private string telephone;
        private string contact;
        private ProviderStatus providerStatus;
        private IList<BasePrice> basePrices;
        private IList<Product> products;

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

        public virtual string SaleConditions
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

        public virtual string Country
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

        public IList<BasePrice> BasePrices
        {
            get { return basePrices; }
            set { basePrices = value; }
        }

        public IList<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
    }
}
