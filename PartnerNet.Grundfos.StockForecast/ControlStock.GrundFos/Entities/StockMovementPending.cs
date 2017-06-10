using System;
using System.Collections.Generic;
using System.Text;

namespace Grundfos.ScalaConnector
{
    public class StockMovementPending
    {
        //id compuesto
        private string productCode;
        //id compuesto
        private DateTime deliveryCommitt;
        //id compuesto
        private string orderNumber;
        //id compuesto
        private string warehouse;

        private int quantity;
        private string custSupCode;
        private string custSupName;
        private DateTime deliveryRequest;

        //id compuesto
        private string originatingOrderLine;
        //id compuesto
        private string deliveryTransType;

        public virtual string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public virtual DateTime DeliveryCommitt
        {
            get { return deliveryCommitt; }
            set { deliveryCommitt = value; }
        }

        public virtual string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public virtual string Warehouse
        {
            get { return warehouse; }
            set { warehouse = value; }
        }

        public virtual int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public virtual string CustSupCode
        {
            get { return custSupCode; }
            set { custSupCode = value; }
        }

        public virtual string CustSupName
        {
            get { return custSupName; }
            set { custSupName = value; }
        }

        public virtual DateTime DeliveryRequest
        {
            get { return deliveryRequest; }
            set { deliveryRequest = value; }
        }

        public virtual string OriginatingOrderLine
        {
            get { return originatingOrderLine; }
            set { originatingOrderLine = value; }
        }

        public virtual string DeliveryTransType
        {
            get { return deliveryTransType; }
            set { deliveryTransType = value; }
        }

        public override bool Equals(object obj)
        {
            StockMovementPending item = (StockMovementPending)obj;
            return item.ProductCode == this.ProductCode && item.DeliveryCommitt == this.DeliveryCommitt && item.OrderNumber == this.OrderNumber && item.Warehouse == this.Warehouse && item.OriginatingOrderLine == this.OriginatingOrderLine && item.DeliveryTransType == this.DeliveryTransType;
        }

        public override int GetHashCode()
        {
            return this.ProductCode.GetHashCode() + this.DeliveryCommitt.GetHashCode() + this.OrderNumber.GetHashCode() + this.Warehouse.GetHashCode() + this.OriginatingOrderLine.GetHashCode() + this.DeliveryTransType.GetHashCode();
        }
    }
}
