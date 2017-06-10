using System;
using System.Collections.Generic;
using System.Text;
using ProjectBase.Data;
using PriceManager.Core;

namespace PriceManager.Business
{
    public class ProductAuditController : AbstractNHibernateDao<ProductAudit, int>
    {
        public ProductAuditController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public List<ProductAudit> GetAllProducts()
        {
            return new List<ProductAudit>();
        }

        public List<ProductAudit> GetProducts()
        {
            return new List<ProductAudit>();
        }

        public bool SaveAudit(Product product)
        {
            try
            {
                ProductAudit prodaudit;
                prodaudit = (ProductAudit) product;

                Save(prodaudit);
                NHibernateSession.Flush();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
