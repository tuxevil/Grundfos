using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Core
{
    public class BasePriceHistory : BasePrice
    {
    }

    public class BasePrice : Entity
    {
        private decimal tP;
        private Currency tPCurrency;
        private decimal gRP;
        private Currency gRPCurrency;
        private string providerCode;
        private Provider provider;
        private Product product;
        private PriceImport priceImport;
        private decimal priceList;
        private Currency priceListCurrency;
        private decimal basePrisceSell;
        private Currency basePrisceSellCurrency;
        private Status status;
        private IList<PriceAttribute> priceAttributes;

        public virtual decimal TP
        {
            get { return tP; }
            set { tP = value; }
        }

        public virtual decimal GRP
        {
            get { return gRP; }
            set { gRP = value; }
        }

        public virtual string ProviderCode
        {
            get { return providerCode; }
            set { providerCode = value; }
        }

        public virtual Provider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual PriceImport PriceImport
        {
            get { return priceImport; }
            set { priceImport = value; }
        }

        public virtual decimal PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual decimal BasePrisceSell
        {
            get { return basePrisceSell; }
            set { basePrisceSell = value; }
        }

        public virtual Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual Currency TPCurrency
        {
            get { return tPCurrency; }
            set { tPCurrency = value; }
        }

        public virtual Currency GRPCurrency
        {
            get { return gRPCurrency; }
            set { gRPCurrency = value; }
        }

        public virtual Currency PriceListCurrency
        {
            get { return priceListCurrency; }
            set { priceListCurrency = value; }
        }

        public virtual Currency BasePrisceSellCurrency
        {
            get { return basePrisceSellCurrency; }
            set { basePrisceSellCurrency = value; }
        }

        public virtual IList<PriceAttribute> PriceAttributes
        {
            get { return priceAttributes; }
            set { priceAttributes = value; }
        }
    }
}
