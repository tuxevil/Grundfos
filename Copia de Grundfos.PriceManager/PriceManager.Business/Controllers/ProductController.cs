using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;


namespace PriceManager.Business
{
    public class ProductController : AbstractNHibernateDao<Product, int>
    {
        public ProductController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        #region Product List View Methods 

        public List<ProductListView> GetProductList(SearchParams param, out int totalRecords)
        {
            Family tempfam;
            CtrRange tempctr;
            Selection tempsel;
            ProductType tempprodtype;
            Currency tempcurr;
            Family tempcat;

            ControllerManager.Selection.GetSearchObjects(param, out tempfam, out tempctr, out tempsel, out tempprodtype, out tempcurr, out tempcat);

            return GetProductList(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, param.PageNumber, param.PageSize, param.SortColumn, param.SortOrder, tempcurr, out totalRecords, false, null);
        }

        public List<ProductListView> GetProductList(string description, Family family, Family category, CtrRange cTR, Selection list, 
            ProductType? productType, int pageNumber, int pageSize, string sortField, string sortOrder, Currency currency, out int totalRecords,
            bool markedAll, List<string> selecteditems)
        {
            // Get the number of records for the current filters
            totalRecords = Convert.ToInt32(GetProductListQuery("COUNT(DISTINCT PP.ID)", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems).UniqueResult());

            if (totalRecords == 0)
                return new List<ProductListView>();
 
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PP.ID, P.Code, P.Description, P.BasePrices[0].PriceSuggestCurrency.Description, P.BasePrices[0].PriceSuggest, PP.PriceSellCurrency.Description, PP.PriceSell, P.BasePrices[0].PricePurchaseCurrency.Description, P.BasePrices[0].PricePurchase, PP.PriceCurrency.Description, PP.Price, LPPA.Price, PP.CTM, PP.CTR, PL.Type, P.BasePrices[0].PriceSuggestCurrency.Value, PP.PriceSellCurrency.Value, LPPA.PCR, PP.ModifiedOn", description, family, category, cTR, list, productType, currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductListView).GetConstructors()[1]));

            return q.List<ProductListView>() as List<ProductListView>;
        }

        public ProductView GetProductView(string id)
        {
            string hql = "SELECT PP.ID, P.Description, P.Code, P.BasePrices[0].PriceSuggestCurrency.Description, P.BasePrices[0].PriceSuggest, PP.PriceSellCurrency.Description, PP.PriceSell, P.BasePrices[0].PricePurchaseCurrency.Description, P.BasePrices[0].PricePurchase, PP.PriceCurrency.Description, PP.Price, LPPA.Price, PP.CTM, PP.CTR, P.BasePrices[0].PriceSuggestCurrency.Value, PP.PriceSellCurrency.Value, LPPA.PCR, PP.ModifiedOn";
            hql += " FROM ProductPrice PP";
            hql += " JOIN PP.PriceList PL";
            hql += " JOIN PP.Product P";
            hql += " LEFT JOIN PP.LastProductPrice LPPA";
            hql += " WHERE P.Status = :Status";
            hql += " AND PP.ID = :Id";

            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetEnum("Status", ProductStatus.Enable);
            q.SetInt32("Id", Convert.ToInt32(id));

            q.SetMaxResults(1);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductView).GetConstructors()[1]));
            return q.UniqueResult<ProductView>();
        }

        #endregion

        #region Get Products To Add/Remove from Selection

        public bool GetProductListToAdd(string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, Currency currency, Selection newselection)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PP.Product", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, true, newselection, null);
            List<Product> tempproductlist = q.List<Product>() as List<Product>;

            if (tempproductlist != null)
                if (tempproductlist.Count > 0)
                {
                    ControllerManager.Selection.AddToSelection(tempproductlist, newselection);
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        public bool GetProductListToRemove(string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, Currency currency)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PP.Product", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, list, null);
            List<Product> tempproductlist = q.List<Product>() as List<Product>;

            if (tempproductlist != null)
                if (tempproductlist.Count > 0)
                {
                    ControllerManager.Selection.RemoveFromSelection(tempproductlist, list);
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        #endregion

        #region Get Products To Add/Remove from Category

        public bool GetProductListToAdd(string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, Currency currency, Family newfamily)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PP.Product", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, true, null, newfamily);

            List<Product> tempproductlist = q.List<Product>() as List<Product>;

            if (tempproductlist != null)
                if (tempproductlist.Count > 0)
                {
                    ControllerManager.Family.AddtoFamily(tempproductlist, newfamily);
                    return true;
                }
                else
                    return false;
            else 
                return false;
        }

        public bool GetProductListToRemove(string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, Currency currency, Family cat)
        {
            // Get the current page and data for the current filters
            IQuery q = GetProductListQuery("DISTINCT PP.Product", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, family);

            List<Product> tempproductlist = q.List<Product>() as List<Product>;

            if (tempproductlist != null)
                if (tempproductlist.Count > 0)
                {
                    ControllerManager.Family.EraseFromFamily(tempproductlist, cat);
                    return true;
                }
                else
                    return false;
            else
                return false;
        }

        #endregion

        #region Get Product Prices To Update Prices
        public List<ProductPrice> GetProductListForPriceUpdates(string description, Family family, Family category, CtrRange cTR, Selection list,
            ProductType? productType, Currency currency, bool markedAll, List<string> selecteditems, 
            DateTime listedDate)
        {
            IQuery q = GetProductListQuery("DISTINCT PP", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, listedDate);
            return q.List<ProductPrice>() as List<ProductPrice>;
        }
        #endregion

        #region Update Prices

        public bool Update(bool Marked, List<string> SelectedItems, SearchParams param, string modvalor, string modctr, DateTime searchDate, out List<ProductPrice> lstProductPrices)
        {
            Family tempfam;
            CtrRange tempctr;
            Selection tempsel;
            ProductType tempprodtype;
            Currency tempcurr;
            Family tempcat;

            ControllerManager.Selection.GetSearchObjects(param, out tempfam, out tempctr, out tempsel, out tempprodtype, out tempcurr, out tempcat);

            lstProductPrices = new List<ProductPrice>();

            if (!string.IsNullOrEmpty(modvalor))
                lstProductPrices = ControllerManager.Product.UpdateProductPrices(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, tempcurr, Marked, SelectedItems, searchDate, (Guid)Membership.GetUser().ProviderUserKey, true, Convert.ToDecimal(modvalor.Replace(",", ".")));

            else if (!string.IsNullOrEmpty(modctr))
                lstProductPrices = ControllerManager.Product.UpdateProductPrices(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, tempcurr, Marked, SelectedItems, searchDate, (Guid)Membership.GetUser().ProviderUserKey, false, Convert.ToDecimal(modctr.Replace(",", ".")));

            if (lstProductPrices.Count > 0)
            {
                return false;
            }
            return true;
        }

        public List<ProductPrice> UpdateProductPrices(string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, bool markedAll, List<string> selecteditems, DateTime listedDate, Guid userId, bool modpcr, decimal value)
        {
            string prodq = GetProductListHQL("DISTINCT PP.Id", description, family, category, cTR, list, productType, currency, 0, 0, null, null, markedAll, selecteditems, false, null, null, listedDate, true, false);
            IQuery iq = NHibernateSession.CreateSQLQuery(prodq);

            CreateParameters(iq, string.Empty, description, family, category, cTR, list, productType, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, listedDate);

            iq.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(ProductPrice).GetConstructors()[1]));

            List<ProductPrice> templist = iq.List<ProductPrice>() as List<ProductPrice>;
            
            // INSERT INTO PRODUCTAUDIT
            string plsql = GetProductListHQL("DISTINCT PP.ProductId, PP.PriceListId, PP.PriceSell, PP.Price, PP.PriceCurrencyId, PP.PriceSellCurrencyId, PP.CTM, PP.CTR, PP.CreatedBy, PP.CreatedOn, '" + userId.ToString()+ "', :DateCurrent", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true);
            string insertsql = "INSERT INTO ProductPriceAudit (ProductId, PriceListId, PriceSell, Price, PriceCurrencyId, PriceSellCurrencyId, CTM, CTR, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) " + plsql + "";

            IQuery q = NHibernateSession.CreateSQLQuery(insertsql);

            CreateParameters(q, string.Empty, description, family, category, cTR, list, productType, currency,
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false,
                null, null, listedDate);

            q.SetDateTime("DateCurrent", DateTime.Now);
            q.ExecuteUpdate();

            // UPDATE CORRESPONDING RECORDS
            plsql = GetProductListHQL("DISTINCT PP.Id", description, family, category, cTR, list, productType, currency, 0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, null, null, listedDate, true, true);

            string updateSql = "UPDATE ProductPrice SET";

            string price;

            if (modpcr)
                price = "(PP.Price * ((:Value/Cast(100 as FLOAT))+1))";
            else
                price = "(-((P.BasePrices[0].PricePurchase * CPP.Value)/(((:Value/Cast(100 as FLOAT))-1)*((100-D.MaxDiscount)/100)))/CPS.Value)";

            string pricesell = "(((" + price + "*CP.Value)/100*(100-D.MaxDiscount))/CPS.Value)";
            string ctm = "(" + pricesell + " - (P.BasePrices[0].PricePurchase * CPP.Value))";
            string ctr = "CASE WHEN (" + pricesell + " = 0) THEN 0 ELSE (1 - ((P.BasePrices[0].PricePurchase * CPP.Value) / (" + pricesell + " * CPS.Value))) * 100 END";

            updateSql += " Price = " + price + ",";
            updateSql += " PriceSell = " + pricesell + ",";
            updateSql += " CTM = " + ctm + ",";
            updateSql += " CTR = " + ctr + ",";
            updateSql += " ModifiedBy = '" + userId + "',";
            updateSql += " ModifiedOn = :DateCurrent"; 
            updateSql += " from ProductPrice PP";
	        updateSql += " inner join PriceList PL";
	        updateSql += " on PP.PriceListId = PL.Id";
	        updateSql += " inner join Product P";
	        updateSql += " on PP.ProductId = P.Id";
	        updateSql += " inner join Discount D";
	        updateSql += " on PL.DiscountId = D.Id";
	        updateSql += " inner join Currency CP";
	        updateSql += " on PP.PriceCurrencyId = CP.Id";
	        updateSql += " inner join Currency CPS";
	        updateSql += " on PP.PriceSellCurrencyId = CPS.Id";
	        updateSql += " inner join Currency CPP";
            updateSql += " on P.BasePrices[0].PricePurchaseCurrencyId = CPP.Id";

            updateSql += " WHERE PP.Id IN (" + plsql + ")";
            
            q = NHibernateSession.CreateSQLQuery(updateSql);

            CreateParameters(q, string.Empty, description, family, category, cTR, list, productType, currency, 
                0, 0, string.Empty, string.Empty, markedAll, selecteditems, false, 
                null, null, listedDate);
            q.SetDecimal("Value", value);
            q.SetDateTime("DateCurrent", DateTime.Now);
            q.ExecuteUpdate();

            // Return Modified Prices
            return templist;
        }

        #endregion

        #region Common IQuery Creation Methods

        private IQuery GetProductListQuery(string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems)
        {
            return
                GetProductListQuery(fields, description, family, category, cTR, list, productType, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, false, null, null);
        }

        private IQuery GetProductListQuery(string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, DateTime listedDate)
        {
            return
                GetProductListQuery(fields, description, family, category, cTR, list, productType, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, false, null, null, listedDate);
        }

        private IQuery GetProductListQuery(string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, bool addTo, Selection newselection, Family newfamily)
        {
            return
                GetProductListQuery(fields, description, family, category, cTR, list, productType, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, null);
        }

        private IQuery GetProductListQuery(string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, bool addTo, Selection newselection, Family newfamily, DateTime? listedDate)
        {
            return
                GetProductListQuery(fields, description, family, category, cTR, list, productType, currency, pageNumber,
                                    pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, newselection, newfamily, listedDate, false);
        }

        private string GetProductListHQL(string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, bool addTo, Selection newselection, Family newfamily, DateTime? listedDate, bool createSQL, bool can)
        {
            List<Family> categories = new FamilyController(this.SessionFactoryConfigPath).FindChildrensOrSelf(category);

            string hql = "SELECT " + fields;
            hql += " FROM ProductPrice PP";
            if (!createSQL)
            {
                hql += " JOIN PP.PriceList PL";
                hql += " JOIN PP.Product P";

                if (list != null)
                    hql += " JOIN P.Selections S";

                if (family != null)
                    hql += " JOIN P.Families F";

                if (categories != null && categories.Count > 0)
                    hql += " JOIN P.Families Cat";

                if (currency != null)
                    hql += " JOIN PP.PriceCurrency C";

                hql += " LEFT JOIN PP.LastProductPrice LPPA";
            }
            else
            {
                hql += " INNER JOIN PriceList PL ON PL.Id = PP.PriceListId ";
                hql += " INNER JOIN Product P ON P.Id = PP.ProductId";

                if (list != null)
                    hql += " INNER JOIN ProductBySelection PBS ON PBS.ProductId = P.Id INNER JOIN Selections S ON PBS.SelectionId = S.Id";

                if (family != null)
                    hql += " INNER JOIN ProductByCategory PBC ON PBC.ProductId = P.Id INNER JOIN Category F ON PBC2.CategoryId = F.Id";

                if (categories != null && categories.Count > 0)
                    hql += " INNER JOIN ProductByCategory PBC2 ON PBC2.ProductId = P.Id INNER JOIN Category Cat ON PBC2.CategoryId = Cat.Id";

                if (currency != null)
                    hql += " INNER JOIN Currency C ON PP.PriceCurrencyId = C.Id";

                hql += " LEFT JOIN viewLastProductPrice LPPA ON LPPA.ProductPriceId = PP.Id";
            }

            hql += " WHERE P.Status = :Status";

            if (listedDate.HasValue)
                if(!createSQL)
                    if(can)
                        hql += " AND PP.ModifiedOn < :ListedDate";
                    else
                        hql += " AND PP.ModifiedOn > :ListedDate";
                else
                    if(can)
                        hql += " AND DATEDIFF(ss, PP.ModifiedOn , :ListedDate) >= 0";
                    else
                        hql += " AND DATEDIFF(ss, PP.ModifiedOn , :ListedDate) < 0";

            if (!addTo && newfamily != null)
                hql += " AND PP.Product.ID in (select P.ID from Family F JOIN F.Products P where F.ID = :NewFamily)";

            if (addTo && newfamily != null)
                hql += " AND PP.Product.ID not in (select P.ID from Family F JOIN F.Products P where F.ID = :NewFamily)";

            if (!addTo && newselection != null)
                hql += " AND PP.Product.ID in (select P.ID from Selection S JOIN S.Products P where S.ID = :NewSelection)";

            if (addTo && newselection != null)
                hql += " AND PP.Product.ID not in (select P.ID from Selection S JOIN S.Products P where S.ID = :NewSelection)";

            if (!string.IsNullOrEmpty(description))
                hql += " AND (lower(P.Description) LIKE :Description OR lower(P.Code) LIKE :Description)";

            if (family != null)
                hql += " AND F.ID = :Family";

            if (cTR != null)
            {
                hql += " AND PP.CTR >= :CtrMin";
                hql += " AND PP.CTR <= :CtrMax";
            }
            if (list != null)
                hql += " AND S.ID = :Selection";

            if (productType != ProductType.Vacio)
            {
                if(!createSQL)
                    hql += " AND PL.Type = :ProductType";
                else
                    hql += " AND PL.ProductType = :ProductType";
            }

            if (currency != null)
                hql += " AND C.ID = :Currency";

            if (selecteditems != null && selecteditems.Count > 0)
            {
                if (markedAll)
                    hql += " AND PP.ID NOT IN (";
                else
                    hql += " AND PP.ID IN (";

                foreach (string item in selecteditems)
                    hql += item + ",";

                hql = hql.Substring(0, hql.Length - 1);
                hql += ") ";
            }

            if (categories != null && categories.Count > 0)
            {
                hql += " AND Cat.ID in (";

                foreach (Family item in categories)
                    hql += item.ID + ",";

                hql = hql.Substring(0, hql.Length - 1);
                hql += ") ";
            }

            if (!string.IsNullOrEmpty(sortField))
                hql += " ORDER BY " + sortField;

            if (!string.IsNullOrEmpty(sortOrder))
                hql += " " + sortOrder;

            if (!string.IsNullOrEmpty(sortField))
                hql += ", PL.Type ASC";

            if (createSQL)
            {
                hql = hql.Replace(".ID", ".Id");
                hql = hql.Replace("Selections", "Selection");
            }

            return hql;
        }

        private void CreateParameters(IQuery q, string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, bool addTo, Selection newselection, Family newfamily, DateTime? listedDate)
        {
            q.SetEnum("Status", ProductStatus.Enable);

            if (!string.IsNullOrEmpty(description))
                q.SetString("Description", "%" + description.ToLower() + "%");

            if (list != null)
                q.SetInt32("Selection", list.ID);

            if (family != null)
                q.SetInt32("Family", family.ID);

            if (cTR != null)
            {
                q.SetDecimal("CtrMin", cTR.Min);
                q.SetDecimal("CtrMax", cTR.Max);
            }

            if (productType != ProductType.Vacio)
                q.SetInt32("ProductType", (int)productType);

            if (currency != null)
                q.SetInt32("Currency", currency.ID);

            if (newselection != null)
                q.SetInt32("NewSelection", newselection.ID);

            if (newfamily != null)
                q.SetInt32("NewFamily", newfamily.ID);

            if (listedDate.HasValue)
                q.SetDateTime("ListedDate", listedDate.Value);

            if (pageNumber > 0 && (fields != "COUNT(*)" || pageSize == 0))
            {
                q.SetMaxResults(pageSize);
                if (pageNumber > 1)
                    q.SetFirstResult(pageSize * (pageNumber - 1));
            }            
        }

        private IQuery GetProductListQuery(string fields, string description, Family family, Family category, CtrRange cTR, Selection list, ProductType? productType, Currency currency, int pageNumber, int pageSize, string sortField, string sortOrder, bool markedAll, List<string> selecteditems, bool addTo, Selection newselection, Family newfamily, DateTime? listedDate, bool createSQL)
        {
            string hql = GetProductListHQL(fields, description, family, category, cTR, list, productType, 
                currency, pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, 
                addTo, newselection, newfamily, listedDate, createSQL, true);

            IQuery q = NHibernateSession.CreateQuery(hql);

            CreateParameters(q, fields, description, family, category, cTR, list, productType, currency, 
                pageNumber, pageSize, sortField, sortOrder, markedAll, selecteditems, addTo, 
                newselection, newfamily, listedDate);

            return q;
        }

        #endregion

        #region Get Product

        public Product GetProductByCode (string code)
        {
            ICriteria crit = GetCriteria();

            crit.Add(Expression.Eq("Code", code));

            return crit.UniqueResult<Product>();
        }

        #endregion
    }
}