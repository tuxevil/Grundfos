using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class QuoteItemView
    {
        private string productCode;
        private string productName;
        private string price;
        private string priceSell;
        private string leadTime;

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public string LeadTime
        {
            get { return leadTime; }
            set { leadTime = value; }
        }

        public QuoteItemView() {}

        public QuoteItemView(QuoteItem qi)
        {
            this.price = qi.PriceCurrency.Description + " " + qi.Price.ToString("#,##0.00");
            this.priceSell = qi.PriceSell;
            if (!string.IsNullOrEmpty(qi.PriceBase.Product.Code))
                this.productCode = qi.PriceBase.Product.Code;
            else
                this.productCode = qi.PriceBase.ProviderCode;
            this.productName = qi.PriceBase.Product.Model;
            this.LeadTime = qi.LeadTime;

        }
    }
}
