using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Common;
using ProjectBase.Data;
using System.Web;

namespace PriceManager.Core
{
    public class ProductListView : Entity<int>
    {
        private string code;
        private string model;
        private string alternativeModel;
        private string description;
        private string alternativeDescription;
        private string type;
        private int pricePurchaseCurrencyId;
        private decimal pricePurchase;
        private int priceSuggestCurrencyId;
        private decimal priceSuggest;
        private int priceCurrencyId; 
        private decimal priceSell;
        private decimal price;
        private int lastPriceCurrencyId;
        private decimal? lastPrice;
        private decimal cTM;
        private string cTR;
        private string index;
        private string status;
        private string provider;
        private int productID;
        private string pCR;
        private string discount;
        private int providerID;
        private DateTime? modifiedOn;
        private object modifiedBy;
        private int priceBaseId;
        private bool isGrundfosCode;
        private string cTRColor;
        
        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual decimal PriceSuggest
        {
            get { return priceSuggest; }
            set { priceSuggest = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual decimal PricePurchase
        {
            get { return pricePurchase; }
            set { pricePurchase = value; }
        }

        public virtual decimal CTM
        {
            get { return cTM; }
            set { cTM = value; }
        }

        public virtual string CTR
        {
            get { return cTR; }
            set { cTR = value; }
        }

        public virtual decimal PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual string Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual string Index
        {
            get { return index; }
            set { index = value; }
        }
        
        public virtual string Model
        {
            get { return model; }
            set { model = value; }
        }

        public virtual string Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual string Status
        {
            get { return status; }
            set { status = value; }
        }

        public virtual decimal? LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public virtual string PCR
        {
            get { return pCR; }
            set { pCR = value; }
        }

        public virtual string Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public virtual int ProviderID
        {
            get { return providerID; }
            set { providerID = value; }
        }

        public DateTime? ModifiedOn
        {
            get { return modifiedOn; }
            set { modifiedOn = value; }
        }

        public object ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        public virtual int PriceBaseId
        {
            get { return priceBaseId; }
            set { priceBaseId = value; }
        }

        public virtual int PricePurchaseCurrencyId
        {
            get { return pricePurchaseCurrencyId; }
            set { pricePurchaseCurrencyId = value; }
        }

        public virtual int PriceSuggestCurrencyId
        {
            get { return priceSuggestCurrencyId; }
            set { priceSuggestCurrencyId = value; }
        }

        public virtual int PriceCurrencyId
        {
            get { return priceCurrencyId; }
            set { priceCurrencyId = value; }
        }

        public virtual int LastPriceCurrencyId
        {
            get { return lastPriceCurrencyId; }
            set { lastPriceCurrencyId = value; }
        }

        public virtual string AlternativeModel
        {
            get { return alternativeModel; }
            set { alternativeModel = value; }
        }

        public virtual string AlternativeDescription
        {
            get { return alternativeDescription; }
            set { alternativeDescription = value; }
        }

        public virtual string FinalInfo
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Model))
                    return this.Model;
                else
                    if (!string.IsNullOrEmpty(this.AlternativeModel))
                        return this.AlternativeModel;
                    else
                        if (!string.IsNullOrEmpty(this.Description))
                            return this.Description;
                        else
                            if (!string.IsNullOrEmpty(this.AlternativeDescription))
                                return this.alternativeDescription;
                            else
                                return "N/D";
            }
        }

        public string PriceListCurrency
        {
            get
            {

                CurrencyRateConverter[,] lst = CurrencyRate.GetArray;

                return lst[0, PriceCurrencyId - 1].Description;
            }

        }

        public string PriceSuggestCurrency
        {
            get
            {

                CurrencyRateConverter[,] lst = CurrencyRate.GetArray;

                return lst[0, PriceSuggestCurrencyId - 1].Description;
            }

        }

        public string PricePurchaseCurrency
        {
            get
            {

                CurrencyRateConverter[,] lst = CurrencyRate.GetArray;

                return lst[0, PricePurchaseCurrencyId - 1].Description;
            }

        }

        public virtual bool IsGrundfosCode
        {
            get { return isGrundfosCode; }
            set { isGrundfosCode = value; }
        }

        public string CTRColor
        {
            get { return cTRColor; }
            set { cTRColor = value; }
        }

        public ProductListView() {}
        
        public ProductListView(int id, int priceBaseId, int productID, string code, string providerCode, string model, string description, int type, decimal pricePurchase, decimal priceSuggest, decimal priceSell, decimal price, decimal cTM, decimal cTR, decimal index, string provider, PriceBaseStatus priceBaseStatus, decimal? lastPrice, decimal discount, int providerID, int priceCurrencyId, int pricePurchaseCurrencyId, int priceSuggestCurrencyId, int lastPriceCurrencyId, string alternativeModel, string alternativeDescription)
        {
            this.id = id;
            if (string.IsNullOrEmpty(code))
                this.code = providerCode;
            else
            {
                this.code = code;
                this.isGrundfosCode = true;
            }
            this.productID = productID;
            this.description = description;
            this.model = model;
            this.priceSuggestCurrencyId = priceSuggestCurrencyId;
            this.priceSuggest = priceSuggest;
            this.pricePurchaseCurrencyId = pricePurchaseCurrencyId; 
            this.pricePurchase = pricePurchase;
            this.priceCurrencyId = priceCurrencyId;
            this.priceSell = priceSell;
            this.price = price;
            this.lastPriceCurrencyId = lastPriceCurrencyId;
            this.lastPrice = lastPrice;
            this.cTM = cTM;
            this.cTR = cTR.ToString("#0.##") + "%";
            this.type = Resource.Business.GetString(((Frequency)type).ToString());
            this.index = index.ToString("0.0");
            this.provider = provider;
            this.alternativeModel = alternativeModel;
            this.alternativeDescription = alternativeDescription;
            switch (priceBaseStatus)
            {
                case PriceBaseStatus.Disable:
                    this.status = Resource.Business.GetString("PriceBaseDisable");
                    break;
                case PriceBaseStatus.Verified:
                    this.status = Resource.Business.GetString("PriceBaseVerified");
                    break;
                case PriceBaseStatus.NotVerified:
                    this.status = Resource.Business.GetString("PriceBaseNotVerified");
                    break;
            }
            this.discount = discount.ToString("#0.##") + "%";
            this.providerID = providerID;
            this.priceBaseId = priceBaseId;

            if (cTR <= 0)
            {
                if (pricePurchase != 0)
                    cTRColor = "textred";
            }
            else if (cTR < 10)
                cTRColor = "textyellow";
            else if (cTR < 50)
                cTRColor = "textgreen";
            else
                cTRColor = "textpurple";
        }

        public ProductListView(int id, int workListItemStatus, decimal pCR, int priceBaseId, int productID, string code, string providerCode, string model, string description, int type, decimal pricePurchase, decimal priceSuggest, decimal priceSell, decimal price, decimal cTM, decimal cTR, decimal index, string provider, PriceBaseStatus priceBaseStatus, decimal? lastPrice, decimal discount, int providerID, int priceCurrencyId, int pricePurchaseCurrencyId, int priceSuggestCurrencyId, int lastPriceCurrencyId, string alternativeModel, string alternativeDescription)
        {
            this.id = id;
            if (string.IsNullOrEmpty(code))
                this.code = providerCode;
            else
            {
                this.code = code;
                this.isGrundfosCode = true;
            }
            this.productID = productID;
            this.description = description;
            this.model = model;
            this.priceSuggestCurrencyId = priceSuggestCurrencyId;
            this.priceSuggest = priceSuggest;
            this.pricePurchaseCurrencyId = pricePurchaseCurrencyId;
            this.pricePurchase = pricePurchase;
            this.priceCurrencyId = priceCurrencyId;
            this.priceSell = priceSell;
            this.price = price;
            this.lastPriceCurrencyId = lastPriceCurrencyId;
            this.lastPrice = lastPrice;
            this.cTM = cTM;
            this.cTR = cTR.ToString("#0.##") + "%";
            this.type = Resource.Business.GetString(((Frequency)type).ToString());
            this.index = index.ToString("0.0");
            this.provider = provider;
            this.alternativeModel = alternativeModel;
            this.alternativeDescription = alternativeDescription;
            switch (priceBaseStatus)
            {
                case PriceBaseStatus.Disable:
                    this.status = Resource.Business.GetString("PriceBaseDisable");
                    break;
                case PriceBaseStatus.Verified:
                    this.status = Resource.Business.GetString("PriceBaseVerified");
                    break;
                case PriceBaseStatus.NotVerified:
                    this.status = Resource.Business.GetString("PriceBaseNotVerified");
                    break;
            }
            if (workListItemStatus > 0)
                switch (workListItemStatus)
                {
                    case (int)WorkListItemStatus.Approved:
                        this.status = Resource.Business.GetString("WorkListItemApproved");
                        break;
                    case (int)WorkListItemStatus.Modified:
                        this.status = Resource.Business.GetString("WorkListItemModified");
                        break;
                    case (int)WorkListItemStatus.Published:
                        this.status = Resource.Business.GetString("WorkListItemPublished");
                        break;
                    case (int)WorkListItemStatus.Added:
                        this.status = Resource.Business.GetString("WorkListItemAdded");
                        break;
                    case (int)WorkListItemStatus.AddedMod:
                        this.status = Resource.Business.GetString("WorkListItemAddedMod");
                        break;
                }
            this.pCR = pCR.ToString("#0.##") + "%";
            this.discount = discount.ToString("#0.##") + "%";
            this.providerID = providerID;
            this.priceBaseId = priceBaseId;
            this.priceCurrencyId = priceCurrencyId;
            this.pricePurchaseCurrencyId = pricePurchaseCurrencyId;
            this.priceSuggestCurrencyId = priceSuggestCurrencyId;

            if (cTR <= 0)
            {
                if (pricePurchase != 0)
                    cTRColor = "textred";
            }
            else if (cTR < 10)
                cTRColor = "textyellow";
            else if (cTR < 50)
                cTRColor = "textgreen";
            else
                cTRColor = "textpurple";
        }


        public ProductListView(PriceBaseHistory priceBase)
        {
            this.id = priceBase.ID;
            if (string.IsNullOrEmpty(priceBase.Product.Code))
                this.code = priceBase.ProviderCode;
            else
            {
                this.code = priceBase.Product.Code;
                this.isGrundfosCode = true;
            }
            this.productID = priceBase.Product.ID;
            this.description = priceBase.Product.Description;
            this.model = priceBase.Product.Model;
            this.priceSuggestCurrencyId = priceBase.PriceSuggestCurrency.ID;
            this.priceSuggest = priceBase.PriceSuggest;
            this.pricePurchaseCurrencyId = priceBase.PricePurchaseCurrency.ID;
            this.pricePurchase = priceBase.PricePurchase;
            this.priceCurrencyId = priceBase.PriceListCurrency.ID;
            this.price = priceBase.PriceList;
            this.type = Resource.Business.GetString((priceBase.Product.Frequency).ToString());
            this.provider = priceBase.Provider.Description;
            this.modifiedOn = priceBase.TimeStamp.ModifiedOn;
            this.modifiedBy = priceBase.TimeStamp.ModifiedBy;
            this.priceBaseId = priceBase.ID;
            this.priceCurrencyId = priceBase.PriceListCurrency.ID;
            this.pricePurchaseCurrencyId = priceBase.PricePurchaseCurrency.ID;
            this.priceSuggestCurrencyId = priceBase.PriceSuggestCurrency.ID;
        }

    }
}
