using System;
using System.Collections.Generic;
using System.Text;

namespace PartnerNet.Domain
{
    public class PurchaseOrderInformation
    {
        private int id;
        private DateTime orderdate;
        private string provider;
        private int totalcount;
        private float amount;
        private DateTime arrivaldate;
        private string type;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual DateTime Orderdate
        {
            get { return orderdate; }
            set { orderdate = value; }
        }

        public virtual string Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public int Totalcount
        {
            get { return totalcount; }
            set { totalcount = value; }
        }

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime Arrivaldate
        {
            get { return arrivaldate; }
            set { arrivaldate = value; }
        }

        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }

        public PurchaseOrderInformation() {}

        public PurchaseOrderInformation(int id, Provider provider, DateTime orderdate, PurchaseOrderType type)
        {
            this.id = id;
            this.orderdate= orderdate;
            this.provider = provider.Name;
            this.type= type.ToString();
        }
    }
}
