using System;
using System.Collections;
using System.Collections.Generic;
using PartnerNet.Domain;
using ProjectBase.Data;
using NHibernate;
using NHibernate.Expression;

namespace PartnerNet.Business
{
    public class ProductSetController : AbstractNHibernateDao<ProductSet, int>
    {
        public ProductSetController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<ProductSet> GetProductSetList()
        {
            ICriteria crit = GetCriteria();
            
            crit.AddOrder(new Order("Name", true));

            return crit.List<ProductSet>();
        }
        public ProductSet GetProductSet(int id)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new EqExpression("Id", id));

            return crit.UniqueResult<ProductSet>();
        }
        public void CreateNewProductSet(string name)
        {
            ProductSet newproductset = new ProductSet();
            newproductset.Name = name;

            this.Save(newproductset);
        }
        public void AddProductToProductSet(int id, IList<Product> productlist)
        {
            ProductSet prodset = this.GetById(id);
            
            foreach (Product product in productlist)
                prodset.Products.Add(product); 

            this.SaveOrUpdate(prodset);
        }
        public void DelProductFromProductSet(int id, IList<Product> productlist)
        {
            ProductSet prodset = this.GetById(id);

            foreach (Product product in productlist)
                prodset.Products.Remove(product);

            this.SaveOrUpdate(prodset);
        }

		public void Test()
		{
			ProductSet p = GetById( 1 );
			p.Name = "Zoquete" + DateTime.Now;
			p.Products.Clear();
			p.Products.Add(new Product(1));
			p.Products.Add( new Product( 2 ) );
			p.Products.Add( new Product( 3 ) );
			p.Products.Add( new Product( 4 ) );
			Save( p );
		}
    }
}
