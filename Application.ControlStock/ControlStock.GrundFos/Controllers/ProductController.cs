using NHibernate.Cfg;
using ProjectBase.Data;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;


namespace Grundfos.ScalaConnector.Controllers
{
    public class ProductController : AbstractNHibernateDao<Product, string>
    {
        public ProductController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Product> GetProductList()
        {
            ICriteria crit = GetCriteria();
            return crit.List<Product>();
        }

        public IList<Product> GetProductList(IList<PartnerNet.Domain.Product> prodlist)
        {
            IList<Product> resultado = new List<Product>();
            foreach (PartnerNet.Domain.Product product in prodlist)
            {
                ICriteria crit = GetCriteria();
                crit.Add(new LikeExpression("Id", product.ProductCode, MatchMode.Exact));
                resultado.Add(crit.UniqueResult<Product>());
            }
            
            return resultado;
        }

        public IList<Product> FilterByGroup(string group)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new LikeExpression("Group", group, MatchMode.Exact));
            return crit.List<Product>();
        }

        public Product GetProductInfo(string ProductCode)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new LikeExpression("Id", ProductCode, MatchMode.Exact));
            return crit.UniqueResult<Product>();
        }
    }
}