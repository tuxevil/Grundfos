using System;
using System.Collections.Generic;
using System.Text;

namespace Grundfos.ScalaConnector
{
    public class SaleOrderItem
    {
        private string id;
        private SaleOrder saleOrder;
        private string product;
        private int quantity;

        public virtual SaleOrder SaleOrder
        {
            get { return saleOrder; }
            set { saleOrder = value; }
        }

        public virtual string Product
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

        public SaleOrderItem() {}

        public SaleOrderItem(int quantity, string product)
        {
            this.quantity = quantity;
            this.product = product;
        }
    }
}
