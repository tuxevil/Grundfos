using System.Collections.Generic;

namespace PartnerNet.Domain
{
    public class TransactionHistoryMonthly : Identifier
    {
        private Product productID;
        private int purchase;
        private int sale;
        private int stock;
        private int month;
        private int year;

        public virtual Product ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public virtual int Sale
        {
            get { return sale; }
            set { sale = value; }
        }

        public virtual int Month
        {
            get { return month; }
            set { month = value; }
        }

        public virtual int Year
        {
            get { return year; }
            set { year = value; }
        }

        public virtual int Purchase
        {
            get { return purchase; }
            set { purchase = value; }
        }

        public virtual int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}