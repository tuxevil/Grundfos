using System;
using System.Collections.Generic;
using System.Text;

namespace Grundfos.ScalaConnector
{
    public class PurchaseOrderItem
    {
        private string id;
        private PurchaseOrder purchaseOrder;
        private Product product;
        private int quantity;

        public virtual PurchaseOrder PurchaseOrder
        {
            get { return purchaseOrder; }
            set { purchaseOrder = value; }
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

        public virtual string Id
        {
            get { return id; }
            set { id = value; }
        }

        public PurchaseOrderItem() {}

        public PurchaseOrderItem(int quantity, Product product)
        {
            this.quantity = quantity;
            this.product = product;
        }
    }
}
