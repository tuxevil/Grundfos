using System;
using System.Collections.Generic;
using System.Text;

namespace PartnerNet.Domain
{
    public class AlertPurchaseOrder : Identifier
    {
        private string purchaseOrderCode;
        private Product product;
        private int quantity;
        private AlertPurchaseOrderType type;
        private int gAP;
        private WayOfDelivery wayOfDelivery;
        private AlertPurchaseOrderDestination destination;
        private DateTime arrivalDate;
        private string purchaseOrderProviderCode;
        private DateTime purchaseOrderDate;

        public virtual string PurchaseOrderCode
        {
            get { return purchaseOrderCode; }
            set { purchaseOrderCode = value; }
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

        public virtual AlertPurchaseOrderType Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual int GAP
        {
            get { return gAP; }
            set { gAP = value; }
        }

        public virtual WayOfDelivery WayOfDelivery
        {
            get { return wayOfDelivery; }
            set { wayOfDelivery = value; }
        }

        public virtual AlertPurchaseOrderDestination Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public virtual DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; }
        }

        public virtual DateTime PurchaseOrderDate
        {
            get { return purchaseOrderDate; }
            set { purchaseOrderDate = value; }
        }

        public virtual string PurchaseOrderProviderCode
        {
            get { return purchaseOrderProviderCode; }
            set { purchaseOrderProviderCode = value; }
        }

        public virtual string ProductDescription
        {
            get { return product.Description; }
        }

        public virtual string ProductCode
        {
            get { return product.ProductCode; }   
        }

    }
}
