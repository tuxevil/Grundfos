using System;
using System.Collections.Generic;
using System.Text;

namespace Grundfos.ScalaConnector
{
    public class ProductDetail
    {
        private string id;
        private string location;
        private int stock;
        private int sales1;
        private int sales2;
        private int purchases;

        public virtual string Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Location
        {
            get { return location; }
            set { location = value; }
        }

        public virtual int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public virtual int Sales1
        {
            get { return sales1; }
            set { sales1 = value; }
        }

        public virtual int Sales2
        {
            get { return sales2; }
            set { sales2 = value; }
        }

        public virtual int Purchases
        {
            get { return purchases; }
            set { purchases = value; }
        }
    }
}
