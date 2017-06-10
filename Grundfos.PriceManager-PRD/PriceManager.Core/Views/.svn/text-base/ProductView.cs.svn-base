using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Common;
using ProjectBase.Data;
using ProjectBase.Utils.Cache;

namespace PriceManager.Core
{
    public class ProductView
    {
        private string description;
        private string code;
        private string priceSell;
        private string price;
        private string cTM;
        private string cTR;
        private string index;
        private string lastPrice;
        private string arrow;
        private string cTRColor;

        public virtual string Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual string CTM
        {
            get { return cTM; }
            set { cTM = value; }
        }

        public virtual string CTR
        {
            get { return cTR; }
            set { cTR = value; }
        }

        public virtual string PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual string Index
        {
            get { return index; }
            set { index = value; }
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Code
        {
            get { return code; }
            set { code = value; }
        }

        public virtual string LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }

        public virtual string Arrow
        {
            get { return arrow; }
            set { arrow = value; }
        }

        public virtual string Status
        {
            get {
                if (StatusEnum.HasValue)
                    return Resource.Business.GetString("WorkListItem" + StatusEnum.ToString());

                return "N/D";
            }
        }

        private WorkListItemStatus? _statusEnum;
        public virtual WorkListItemStatus? StatusEnum
        {
            get { return _statusEnum; }
            set { _statusEnum = value; }
        }

        public virtual string CTrColor
        {
            get { return cTRColor; }
            set { cTRColor = value; }
        }

        public ProductView() {}

        public ProductView(int id, string description, string code, decimal priceSell, decimal price, decimal cTM, decimal cTR, decimal index, decimal lastPrice, int priceCurrencyId, decimal pricePurchase)
        {
            CurrencyRateConverter[,] tmp = CacheManager.GetCached("Currencies.GetRates") as CurrencyRateConverter[,];
            string priceCurrency = "";
            if(tmp!= null)
                priceCurrency = tmp[0, priceCurrencyId - 1].Description;
            //this.id = id;
            this.description = description;
            this.code = code;
            this.priceSell = priceCurrency + " " + priceSell.ToString("#,##0.00");
            this.price = priceCurrency + " " + price.ToString("#,##0.00");
            this.cTM = priceCurrency + cTM.ToString("#,##0.00");
            this.cTR = cTR.ToString("##0.00") + "%";
            this.index = index.ToString("0.0");
            this.lastPrice = priceCurrency + " " + lastPrice.ToString("#,##0.00");

            if (lastPrice > price)
                this.arrow = "down";
            else if ((lastPrice > 0) && (lastPrice < price))
                this.arrow = "up";

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

        public ProductView(int id, string description, string code, decimal priceSell, decimal price, decimal cTM, decimal cTR, decimal index, decimal lastPrice, decimal pCR, int priceCurrencyId, decimal pricePurchase)
        {
            CurrencyRateConverter[,] tmp = CacheManager.GetCached("Currencies.GetRates") as CurrencyRateConverter[,];
            string priceCurrency = "";
            if (tmp != null)
                priceCurrency = tmp[0, priceCurrencyId - 1].Description;
            //this.id = id;
            this.description = description;
            this.code = code;
            this.priceSell = priceCurrency + " " + priceSell.ToString("#,##0.00");
            this.price = priceCurrency + " " + price.ToString("#,##0.00");
            this.cTM = priceCurrency + cTM.ToString("#,##0.00");
            this.cTR = cTR.ToString("##0.00") + "%";
            this.index = index.ToString("0.0");
            this.lastPrice = priceCurrency + " " + lastPrice.ToString("#,##0.00") + "(" + pCR.ToString("##0.00") + "%)";

            if (lastPrice > price)
                this.arrow = "down";
            else if ((lastPrice > 0) && (lastPrice < price))
                this.arrow = "up";

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

        public ProductView(int id, string description, string code, decimal priceSell, decimal price, decimal cTM, decimal cTR, decimal index, decimal lastPrice, decimal pCR, int workListItemStatus, int priceCurrencyId, decimal pricePurchase)
        {
            CurrencyRateConverter[,] tmp = CacheManager.GetCached("Currencies.GetRates") as CurrencyRateConverter[,];
            string priceCurrency = "";
            if (tmp != null)
                priceCurrency = tmp[0, priceCurrencyId - 1].Description;
            //this.id = id;
            this.description = description;
            this.code = code;
            this.priceSell = priceCurrency + " " + priceSell.ToString("#,##0.00");
            this.price = priceCurrency + " " + price.ToString("#,##0.00");
            this.cTM = priceCurrency + cTM.ToString("#,##0.00");
            this.cTR = cTR.ToString("##0.00") + "%";
            this.index = index.ToString("0.0");
            this.lastPrice = priceCurrency + " " + lastPrice.ToString("#,##0.00") + "(" + pCR.ToString("##0.00") + "%)";

            if (lastPrice > price)
                this.arrow = "down";
            else if ((lastPrice > 0) && (lastPrice < price))
                this.arrow = "up";

            if (workListItemStatus > 0)
                this.StatusEnum = (WorkListItemStatus) Enum.Parse(typeof(WorkListItemStatus), workListItemStatus.ToString());

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


    }
}
