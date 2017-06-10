using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Mapping;
using PartnerNet.Domain;
using ProjectBase.Data;
using NHibernate;
using NHibernate.Expression;


namespace PartnerNet.Business
{
    public class ProductController : AbstractNHibernateDao<Product, int>
    {
        public ProductController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Product> GetProductList()
        {
            ICriteria crit = GetCriteria();
            return crit.List<Product>();
        }

        public Product GetProductInfo(string ProductCode)
        {
            ICriteria crit = GetCriteria();
            crit.Add(new LikeExpression("ProductCode", ProductCode, MatchMode.Exact));
            return crit.UniqueResult<Product>();
        }

        public IList<string> GetGroups()
        {
            ICriteria crit = GetCriteria();
            crit.SetProjection(Projections.ProjectionList()
                                   .Add(Projections.GroupProperty("Group"))
                );
            crit.AddOrder(new Order("Group", true));
            
            IList lst = crit.List();

            return crit.List<string>();
        }

        public IList<Product> GetProductList(string nameCode, string group, int selection)
        {
            ProductSet prodset = ControllerManager.ProductSet.GetProductSet(selection);
            ICriteria crit = GetCriteria();

            if (nameCode != null)
                crit.Add(new OrExpression(new LikeExpression("ProductCode", nameCode, MatchMode.Anywhere), new LikeExpression("Description", nameCode, MatchMode.Anywhere)));
            if (group != null)
                crit.Add(new EqExpression("Group", group));
            if (selection > 0)
                crit.Add(new EqExpression("ProductSets", prodset));
            
            return crit.List<Product>();
        }

        public IList<ProductInformation> GetProductInformation(string nameCode, string group, int selection, int provider, int week, int year, int page, int pagesize)
        {
            string querystring = "P.Id, P.ProductCode, P.Description, PV.Name, THW.Stock, P.RepositionLevel, P.RepositionPoint, PSW.Sale, P.LeadTime, P.Safety";
            IQuery q = GetInfo(nameCode, group, selection, provider, week, year, page, pagesize, querystring);

            IList lst = q.List();

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductInformation).GetConstructors()[1]));

            return q.List<ProductInformation>();
        }

        public int GetProductInformationCount(string nameCode, string group, int selection, int provider, int week, int year, int page, int pagesize)
        {
            string querystring = "Count(P.Id)";
            IQuery q =GetInfo(nameCode, group, selection, provider, week, year, 0, 0, querystring);

            long prueba = q.UniqueResult<Int64>();

            return Convert.ToInt32(prueba);
        }

        public IQuery GetInfo(string nameCode, string group, int selection, int provider, int week, int year, int page, int pagesize, string querystring)
        {
            string query = "select " + querystring + " from Product P";
            query += " join P.ProductStatisticsWeeklys PSW";
            query += " join P.TransactionHistoryWeeklys THW";
            if (selection > 0)
                query += " join P.ProductSets PS";
            //if (provider > 0)
                query += " join P.Provider PV";
            query += " where PSW.Period = :Period";
            query += " AND THW.Week = :Week AND THW.Year = :Year";
            if (nameCode != "")
                query += " AND (P.ProductCode LIKE :namecode OR P.Description LIKE :namecode)";
            if (group != "N/A")
                query += " AND P.Group = :Group";
            if (selection > 0)
                query += " AND PS.Id = :Selection";
            if (provider > 0)
                query += " AND PV.Id = :Provider";


            IQuery q = NHibernateSession.CreateQuery(query);

            q.SetInt32("Period", (int)Period.Bimonthly);

            //q.SetEnum("Period", Period.Bimonthly);
            q.SetInt32("Week", week);
            q.SetInt32("Year", year);
            if (nameCode != "")
                q.SetString("namecode", "%" + nameCode + "%");
            if (group != "N/A")
                q.SetString("Group", group);
            if (selection > 0)
                q.SetInt32("Selection", selection);
            if (provider > 0)
                q.SetInt32("Provider", provider);

            if (pagesize != 0)
            {
                q.SetMaxResults(pagesize);
                if (page == 1)
                    q.SetFirstResult(0);
                else
                    q.SetFirstResult((page - 1)*pagesize);
            }

            return q;
        }
        
        public void AddProductToProductSet(IList<Product> productlist, IList<ProductSet> productsetlist)
        {
            foreach(Product prod in productlist)
            {
                prod.ProductSets.Clear();

                foreach (ProductSet productset in productsetlist)
                    prod.ProductSets.Add(productset);

                this.SaveOrUpdate(prod);    
            }
            
        }

        public void UpdateProductSafety(IList<Product> productlist, int safety)
        {
            foreach (Product prod in productlist)
            {
                prod.Safety = safety;

                this.SaveOrUpdate(prod);
            }
        }

        public void UpdateProductLeadTime(IList<Product> productlist, int leadtime)
        {
            foreach (Product prod in productlist)
            {
                prod.LeadTime = leadtime;

                this.SaveOrUpdate(prod);
            }
        }

        public void UpdateProductRepositionPoint(IList<Product> productlist, int repPoint)
        {
            foreach (Product prod in productlist)
            {
                prod.RepositionPoint = repPoint;

                this.SaveOrUpdate(prod);
            }
        }

        public IList cualquiera ()
        {
            IList nue = new ArrayList();
            return nue;
        }


        
    }
}