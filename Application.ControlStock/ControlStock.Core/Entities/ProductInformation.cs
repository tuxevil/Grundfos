using System;
using System.Collections.Generic;
using System.Text;

namespace PartnerNet.Domain
{
    public class ProductInformation
    {
        private int id;
        private string productCode;
        private string description;
        private string provider;
        private int stock;
        private int repositionLevel;
        private int repositionPoint;
        private int saleaverage;        
        private int leadTime;
        private int safety;
        private bool selection;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public virtual int RepositionLevel
        {
            get { return repositionLevel; }
            set { repositionLevel = value; }
        }

        public virtual int RepositionPoint
        {
            get { return repositionPoint; }
            set { repositionPoint = value; }
        }

        public virtual int Saleaverage
        {
            get { return saleaverage; }
            set { saleaverage = value; }
        }

        public virtual int LeadTime
        {
            get { return leadTime; }
            set { leadTime = value; }
        }

        public virtual int Safety
        {
            get { return safety; }
            set { safety = value; }
        }

        public virtual bool Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        
        public ProductInformation() {}

        public ProductInformation(int id, string productCode, string description, string provider, int stock, int replevel, int reppoint, int sale, int leadtime, int safety)
        {
            this.id = id;
            this.productCode = productCode;
            this.description = description;
            this.provider = provider;
            this.stock = stock;
            this.repositionLevel = replevel;
            this.repositionPoint = reppoint;
            this.saleaverage = sale;
            this.leadTime = leadtime;
            this.safety = safety;
        }

    }
}
