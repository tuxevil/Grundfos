using System;
using System.Collections.Generic;

namespace PriceManager.Core
{
    public class LastProductPrice
    {
        private decimal price;
        private PriceList priceList;
        private Product product;
        private int id;
        private decimal pCR;

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }

        public virtual PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual decimal PCR
        {
            get { return pCR; }
            set { pCR = value; }
        }
    }
}
