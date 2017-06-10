namespace PriceManager.Core
{
    public class ProductAudit : Product
    {
    }

    public class ProductPriceAudit : Entity
    {
        private decimal price;
        private decimal priceSell;
        private PriceList priceList;
        private Product product;
        private decimal cTM;
        private decimal cTR;
        private Currency priceCurrency;
        private Currency priceSellCurrency;

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// This field is calculated as : PriceList - Discount
        /// </summary>
        public virtual decimal PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }

        public virtual PriceList PriceList
        {
            get { return priceList; }
            set { priceList = value; }
        }

        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual decimal CTM
        {
            get { return cTM; }
            set { cTM = value; }
        }

        public virtual decimal CTR
        {
            get { return cTR; }
            set { cTR = value; }
        }


        public virtual Currency PriceCurrency
        {
            get { return priceCurrency; }
            set { priceCurrency = value; }
        }

        public virtual Currency PriceSellCurrency
        {
            get { return priceSellCurrency; }
            set { priceSellCurrency = value; }
        }
    }
}
