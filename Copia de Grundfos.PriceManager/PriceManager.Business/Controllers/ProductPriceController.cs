using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;


namespace PriceManager.Business
{
    public class ProductPriceController : AbstractNHibernateDao<ProductPrice, int>
    {
        public ProductPriceController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
       
        public ProductPrice GetByProduct(Product product)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Product", product));
            return crit.UniqueResult<ProductPrice>();
        }

        public bool PercentageIncrement(IList<ProductPrice> prodPlist, decimal percentage, Guid user)
        {
            int count = 0;
            foreach (ProductPrice pP in prodPlist)
            {
                ControllerManager.ProductPriceAudit.SaveAudit(pP);

                pP.Price = pP.Price*(1 + (percentage/100));

                Modification(pP);
               
                Save(pP);

                count++;
                if (count > 300)
                {
                    count = 0;
                    NHibernateSession.Flush();
                    NHibernateSession.Clear();
                }
            }

            NHibernateSession.Flush();
            return true;
        }

        public bool SaveCTR(IList<ProductPrice> lstProducts, decimal ctr, Guid user)
        {
            foreach (ProductPrice pP in lstProducts)
            {
                ControllerManager.ProductPriceAudit.SaveAudit(pP);

                //pP.Price = (((ctr * (pP.Product.PricePurchase * pP.Product.PricePurchaseCurrency.Value)) + (pP.Product.PricePurchase * pP.Product.PricePurchaseCurrency.Value * 100)) / (100 - pP.PriceList.Discount.MaxDiscount)) / pP.PriceCurrency.Value;

                pP.Price = (-((pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value) / (((ctr / 100) - 1) * ((100 - pP.PriceList.Discount.MaxDiscount) / 100))) / pP.PriceSellCurrency.Value);

                Modification(pP);

                Save(pP);
                NHibernateSession.Flush();
            }
            return true;
        }

        public void Modification(ProductPrice pP)
        {
            pP.PriceSell = ((pP.Price * pP.PriceCurrency.Value)*(100 - pP.PriceList.Discount.MaxDiscount) / 100) / pP.PriceSellCurrency.Value;
            pP.CTM = ((pP.PriceSell * pP.PriceSellCurrency.Value) - (pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value));
            if (pP.PriceSell != 0)
            {
                pP.CTR = (1 - ((pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value) / (pP.PriceSell * pP.PriceSellCurrency.Value))) * 100;
            }
        }

        public void ModifyProduct(int id, string decription, string code, decimal priceSuggested, Currency suggestedCurrency, decimal pricePurchase, Currency purchaseCurrency, decimal priceList, Currency listCurrency, ProductType productType, Guid user)
        {
            ProductPrice pp;
            Product p;

            //Load products by ID
            if (id != 0)
            {
                pp = ControllerManager.ProductPrice.GetById(id);
                p = ControllerManager.Product.GetById(pp.Product.ID);
                
                //Save Audit before modification
                ControllerManager.ProductAudit.SaveAudit(p);
                ControllerManager.ProductPriceAudit.SaveAudit(pp);
            }
            else
            {
                p = ControllerManager.Product.GetProductByCode(code);
                pp= new ProductPrice();
                if (p == null)
                {
                    p = new Product();
                    
                }
            }
            //Seting new values for product
            p.Description = decription;
            p.Code = code;
            p.BasePrices[0].PricePurchase = pricePurchase;
            p.BasePrices[0].PricePurchaseCurrency = purchaseCurrency;
            p.BasePrices[0].PriceSuggest = priceSuggested;
            p.BasePrices[0].PriceSuggestCurrency = suggestedCurrency;
            p.Status = ProductStatus.Enable;

            //Saving Product Object
            ControllerManager.Product.Save(p);

            //Seting new values for product price
            pp.Product = p;
            pp.Price = priceList;
            pp.PriceCurrency = listCurrency;
            pp.PriceSellCurrency = listCurrency;
            pp.PriceList = ControllerManager.PriceList.getByProductType(productType);

            decimal priceSell = ((priceList * listCurrency.Value) * (100 - pp.PriceList.Discount.MaxDiscount) / 100) / pp.PriceSellCurrency.Value;

            pp.PriceSell = priceSell;

            if (pricePurchase != 0)
            {
                pp.CTM = (priceSell*pp.PriceSellCurrency.Value) - (pricePurchase*purchaseCurrency.Value);
                pp.CTR = (1 - ((pp.Product.BasePrices[0].PricePurchase * pp.Product.BasePrices[0].PricePurchaseCurrency.Value) /
                           (pp.PriceSell*pp.PriceSellCurrency.Value)))*100;
            }
            else
            {
                pp.CTM = 0;
                pp.CTR = 0;
            }

            //Saving Product Price Object
            Save(pp);

            NHibernateSession.Flush();
        }

        public IList<ProductPrice> GetByPriceList(IList<PriceList> priceList)
        {
            IList<ProductPrice> pp = new List<ProductPrice>();
            foreach (PriceList pl in priceList)
            {
                ICriteria crit = GetCriteria();
                crit.Add(Expression.Eq("PriceList", pl));
                IList tmp = crit.List();
                foreach (ProductPrice pptmp in tmp)
                    pp.Add(pptmp);
            }

            return pp;
        }

        public ProductPrice GetPrices(string id)
        {
            ProductPrice pp = new ProductPrice();
            pp = GetById(Convert.ToInt32(id));
            
            return (pp);
        }

        public ProductView ChangePrice(string id, string value, string type, Guid user)
        {
            decimal price = 0;
            GetTempPrice(id, value, type, out price);
            ProductPrice pP = GetById(Convert.ToInt32(id));

            ControllerManager.ProductPriceAudit.SaveAudit(pP);

            decimal p = Convert.ToDecimal(price);

            pP.Price =p;
            pP.PriceSell = ((p * pP.PriceCurrency.Value) * (100 - pP.PriceList.Discount.MaxDiscount) / 100) / pP.PriceSellCurrency.Value;
            if (!(pP.PriceSell == 0))
            {
                pP.CTM = ((pP.PriceSell * pP.PriceSellCurrency.Value) - (pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value));
                pP.CTR = (1 - ((pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value) / (pP.PriceSell * pP.PriceSellCurrency.Value))) * 100;
            }
            else
            {
                pP.CTM = 0;
                pP.CTR = 0;
            }

            Save(pP);
            NHibernateSession.Flush();

            return ControllerManager.Product.GetProductView(pP.ID.ToString());
        }

        public TempPrice GetTempPrice(string id, string value, string type, out decimal price)
        {
            ProductPrice pP = GetById(Convert.ToInt32(id));
            TempPrice tP = new TempPrice();
            decimal Price;
            decimal PriceSell;
            decimal CTR;

            string tempvalue = value.Replace(",", ".");
 

            if(type == "1")
                Price = Convert.ToDecimal(tempvalue);
            else if(type == "2")
                Price = (-((pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value) / (((Convert.ToDecimal(tempvalue) / 100) - 1) * ((100 - pP.PriceList.Discount.MaxDiscount) / 100))) / pP.PriceSellCurrency.Value);
            else
                Price = pP.Price * (1 + (Convert.ToDecimal(tempvalue) / 100));

            PriceSell = ((Price * pP.PriceCurrency.Value) * (100 - pP.PriceList.Discount.MaxDiscount) / 100) / pP.PriceSellCurrency.Value;
            if (!(pP.Product.BasePrices[0].PricePurchase == 0))
                CTR = (1 - ((pP.Product.BasePrices[0].PricePurchase * pP.Product.BasePrices[0].PricePurchaseCurrency.Value) / (PriceSell * pP.PriceSellCurrency.Value))) * 100;
            else 
                CTR = 0;

            price = Price;
            tP.NewPrice = pP.PriceCurrency.Description + " " + Price.ToString("#,##0.00");
            tP.NewCtr = CTR.ToString("##0.00") + " %";
            tP.OriginalPrice = pP.PriceCurrency.Description + " " + pP.Price.ToString("#,##0.00");
            tP.NewPriceWF = Price.ToString();
            tP.OriginalPriceWF = pP.Price;

            return tP;
        }

        public List<ProductPrice> GetProductsFromSelection(Selection selection)
        {
            ICriteria crit = GetCriteria();
            ICriteria product = crit.CreateCriteria("Product");
            ICriteria selections = product.CreateCriteria("Selections");
            selections.Add(Expression.Eq("ID", selection.ID));

            return crit.List<ProductPrice>() as List<ProductPrice>;
        }

        public bool ExistsProduct(string code, ProductType type)
        {
            ICriteria crit = GetCriteria();
            ICriteria product = crit.CreateCriteria("Product");
            ICriteria pricelist = crit.CreateCriteria("PriceList");

            product.Add(Expression.InsensitiveLike("Code", code));
            pricelist.Add(Expression.Eq("Type", type));
            product.Add(Expression.Eq("Status", ProductStatus.Enable));

            return ((crit.UniqueResult<ProductPrice>() != null) ? true : false);
        }
    }
}