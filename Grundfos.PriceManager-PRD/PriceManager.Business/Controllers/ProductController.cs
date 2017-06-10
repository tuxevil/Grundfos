using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using PriceManager.Common;


namespace PriceManager.Business
{
    public class ProductController : AbstractNHibernateDao<Product, int>
    {
        public ProductController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        
        #region Get Product

        public List<CodeProvView> GetCodProvViewList()
        {
            string hql = "select P.ID, P.Code, PV.ID, PB.ProviderCode from Product P JOIN P.Providers PV JOIN P.PriceBases PB";
            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(CodeProvView).GetConstructors()[1]));
            return q.List<CodeProvView>() as List<CodeProvView>;
        }

        public Product GetProductByCode (string code)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Code", code));

            Product p = crit.UniqueResult<Product>();
            if (p != null)
                return p;

            return new Product();
        }

        public IList<Product> GetProductList(string description, Frequency? frequency, DateTime? date, ProductStatus? status, Provider provider, CategoryBase[] category, Selection selection, GridState gridState, out int totalRecords)
        {
            string sortOrder = gridState.SortAscending ? "ASC" : "DESC";
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            IQuery q = ControllerManager.PriceBase.GetProductListQuery("COUNT(DISTINCT P.ID)", description, category, selection, frequency, date, status, provider, 0, 0, string.Empty, string.Empty, gridState.MarkedAll, null);
            totalRecords = Convert.ToInt32(q.UniqueResult());
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);
            q = ControllerManager.PriceBase.GetProductListQuery("P", description, category, selection, frequency, date, status, provider, pageNumber, pageSize, gridState.SortField, sortOrder, gridState.MarkedAll, null);

            return q.List<Product>();
        }

        #endregion

    }
}