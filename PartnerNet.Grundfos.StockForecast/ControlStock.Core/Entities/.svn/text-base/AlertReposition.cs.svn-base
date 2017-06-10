using System;
using System.Collections.Generic;
using System.Text;
using PartnerNet.Common;

namespace PartnerNet.Domain
{
    public class AlertReposition : Identifier
    {
        private Product product;
        private int sales;
        private decimal result;
        private bool isConflicted;
        private string orderInfo;
        private decimal productSaleLife;
        
        
        public virtual Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public virtual int Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public virtual decimal Result
        {
            get { return result; }
            set { result = value; }
        }

        public virtual decimal ProductSaleLife
        {
            get { return productSaleLife; }
            set { productSaleLife = value; }
        }
        
        public virtual string ProductCode
        {
            get { return product.ProductCode; }
        }

        public virtual int RepositionLevel
        {
            get { return product.RepositionLevel; }
        }

        public virtual string ProductName
        {
            get { return product.Description; }
        }

        public virtual string Group
        {
            get { return product.Group; }
        }

        public virtual string Price
        {
            get { return product.ViewScala.Price.ToString("#,##0.00"); }
        }

        public virtual string Provider
        {
            get { return product.Provider.Name; }
        }

        public virtual bool IsConflicted
        {
            get { return isConflicted; }
            set { isConflicted = value; }
        }

        public virtual string OrderInfo
        {
            get { return orderInfo; }
            set { orderInfo = value; }
        }

        public virtual int SaleMonths
        {
            get
            {
                int month = Convert.ToInt32(Math.Round(Convert.ToDecimal(productSaleLife) / 4, MidpointRounding.AwayFromZero));
                if (month > 12)
                    return 12;
                if (month == 0)
                    return 1;

                return month;

            }
        }

        public virtual decimal CuatrimestralSales
        {
            get
            {
                decimal divider = Convert.ToDecimal((SaleMonths * 3)) / 12;
                if (divider != 0 && divider > 1)
                    return Math.Round(sales / divider);
                else
                    return sales;
            }
        }

        public virtual decimal SemestralSales
        {
            get
            {
                decimal divider = Convert.ToDecimal((SaleMonths * 2)) / 12;
                if (divider != 0 && divider > 1)
                    return Math.Round(sales / divider);
                else
                    return sales;
            }
        }

        public AlertReposition() { }

        public AlertReposition(int id, int repLevel, string productCode, string alternativeProduct, DateTime alternativeDate, int sales, int productSaleLife)
        {
            this.product = new Product(id);
            this.product.RepositionLevel = repLevel;
            this.product.ProductCode = productCode;
            this.product.AlternativeProduct = alternativeProduct;
            this.product.AlternativeDate = alternativeDate;
            this.sales = sales;
            this.productSaleLife = productSaleLife;
        }
    }
}
