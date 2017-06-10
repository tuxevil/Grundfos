using System;
using System.Collections.Generic;
using System.Text;

namespace PartnerNet.Domain
{
    public class AlertSaleOrder : Identifier
    {
        private string saleOrderCode;
        private Product product;
        private int quantity;
        private string customerCode;
        private string customerName;
        private int gAP;
        private DateTime purchaseOrderArrivalDate;
        private DateTime saleOrderDeliveryDate;
        private DateTime orderDate;
        private AlertSaleOrderType type;

        public virtual string SaleOrderCode
        {
            get { return saleOrderCode; }
            set { saleOrderCode = value; }
        }

        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public virtual string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }

        public virtual int GAP
        {
            get { return gAP; }
            set { gAP = value; }
        }

        public virtual DateTime PurchaseOrderArrivalDate
        {
            get { return purchaseOrderArrivalDate; }
            set { purchaseOrderArrivalDate = value; }
        }

        public virtual DateTime SaleOrderDeliveryDate
        {
            get { return saleOrderDeliveryDate; }
            set { saleOrderDeliveryDate = value; }
        }

        public virtual DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public virtual AlertSaleOrderType Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual string ProductCode
        {
            get { return product.ProductCode; }
        }

        public virtual string ProductDescription
        {
            get { return product.Description; }
        }

        public virtual string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
    }
}
