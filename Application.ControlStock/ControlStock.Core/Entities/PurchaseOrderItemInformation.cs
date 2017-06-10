using System;
using System.Collections.Generic;
using System.Text;

namespace PartnerNet.Domain
{
    public class PurchaseOrderItemInformation
    {
        private int id;
        private string productName;
        private int quantity;
        private int quantitySuggested;
        private float price;
        private float totalPrice;
        private int stock;
        private string productCode;
        private int provideID;
        private int status;


        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public virtual int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public virtual float Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public virtual int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public virtual string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public int ProvideID
        {
            get { return provideID; }
            set { provideID = value; }
        }

        public virtual int Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual int QuantitySuggested
        {
            get { return quantitySuggested; }
            set { quantitySuggested = value; }
        }
    }
}
