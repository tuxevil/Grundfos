using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class ProductExport
    {
        private int id;
        private string description;
        private string code;
        private string priceCurrency;
        private decimal price;

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string PriceCurrency
        {
            get { return priceCurrency; }
            set { priceCurrency = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public ProductExport() {}

        public ProductExport(int id, string description, string code, string priceCurrency, decimal price )
        {
            this.id = id;

            this.description = description;
            this.code = code;
            this.priceCurrency = priceCurrency;
            this.price = Math.Round(price,2);
        }
    }
}
