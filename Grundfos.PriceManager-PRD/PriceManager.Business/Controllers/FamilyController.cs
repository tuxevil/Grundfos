using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Common;
using PriceManager.Core;
using ProjectBase.Data;
using ProjectBase.OfflineProcessor;
using ProjectBase.OfflineProcessor.Remoting;
using ProjectBase.Utils.Cache;
using NHibernate.SqlCommand;


namespace PriceManager.Business
{
    public class CategoryBaseController : AbstractNHibernateDao<CategoryBase, int>
    {
        public CategoryBaseController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public CategoryBase GetWithProducts(int id)
        {
            ICriteria crit = GetCriteria();
            crit.SetFetchMode("Products", FetchMode.Join);
            crit.Add(Expression.Eq("ID", id));
            return crit.UniqueResult<CategoryBase>();
        }

        public List<IDIDView> GetCategoriesIds()
        {
            string hql = "select P.ID, C.ID from CategoryBase C JOIN C.Products P";
            IQuery q = NHibernateSession.CreateQuery(hql);
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(IDIDView).GetConstructors()[1]));
            return q.List<IDIDView>() as List<IDIDView>;
        }

        public void EraseFromCategory(List<int> prodlist, CategoryBase f)
        {
            foreach (int productId in prodlist)
                f.Products.Remove(new Product(productId));
            Save(f);
            CommitChanges();
        }

        public bool IsParent(CategoryBase family)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Parent", family));
            return ((crit.List<CategoryBase>().Count > 0) ? true : false);
        }

        public List<CategoryBase> GetChildrens(CategoryBase parent)
        {
            List<CategoryBase> children;// = CacheManager.GetCached("cat" + parent.ID.ToString()) as List<CategoryBase>;
            //if (children != null)
            //    return children;

            ICriteria crit = GetChildrensCriteria(parent);

            children = crit.List<CategoryBase>() as List<CategoryBase>;

            //CacheManager.AddItem("cat" + parent.ID.ToString(), children);
            return children;
        }

        private ICriteria GetChildrensCriteria(CategoryBase parent)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Parent", parent));

            return crit;
        }

        public List<CategoryBase> GetChildrens(CategoryBase parent, GridState gridState, out int totalRecords)
        {
            
            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;

            ICriteria crit = GetChildrensCriteria(parent);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<CategoryBase>();

            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = GetChildrensCriteria(parent);
            
            crit.SetMaxResults(pageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * pageSize);


            return crit.List<CategoryBase>() as List<CategoryBase>;
        }

        private List<CategoryBase> GetChildrens(CategoryBase parent, List<CategoryBase> lstCategories)
        {
            if (lstCategories == null)
                lstCategories = new List<CategoryBase>();

            lstCategories.Add(parent);

            List<CategoryBase> lstChildrens = GetChildrens(parent);
            foreach (CategoryBase f in lstChildrens)
                GetChildrens(f, lstCategories);

            return lstCategories;
        }

        public List<CategoryBase> FindChildrensOrSelf(CategoryBase family)
        {
            List<CategoryBase> children = null;

            if (family != null)
            {
                //children = CacheManager.GetCached("hier" + family.ID.ToString()) as List<CategoryBase>;
                if (children != null)
                    return children;

                if (IsParent(family))
                    children = GetChildrens(family, children);
                else
                {
                    children = new List<CategoryBase>();
                    children.Add(family);
                }

                //CacheManager.AddItem("hier" + family.ID.ToString(), children);
            }


            return children;
        }

        public ListItemCollection GetHierarchyItems(IList<PageTreeView> categorylist, CategoryBase category)
        {
            if (categorylist == null)
                return new ListItemCollection();

            ListItemCollection familydisplay = new ListItemCollection();

            foreach (PageTreeView family in categorylist)
            {
                if (category != null && family.Id == category.ID)
                    continue;

                ListItem li = new ListItem(family.NameAsHtml, family.Id.ToString());
                familydisplay.Add(li);
            }
            return familydisplay;
        }

        public ListItemCollection GetHierarchyItems(string type)
        {
            IList<PageTreeView> cblst = GetPagesTree(type);
            return ControllerManager.CategoryBase.GetHierarchyItems(cblst, null);
        }

        public List<CategoryBase> GetByType(Type type)
        {
            ICriteria crit = NHibernateSession.CreateCriteria(type).AddOrder(new Order("Name", true));

            return crit.List<CategoryBase>() as List<CategoryBase>;
        }
        
        public IList<CategoryBase> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<CategoryBase>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            ListItemCollection lst = new ListItemCollection();
            lst.AddRange(ConvertToArray(GetHierarchyItems("1")));
            lst.AddRange(ConvertToArray(GetHierarchyItems("2")));
            lst.AddRange(ConvertToArray(GetHierarchyItems("3")));
            lst.AddRange(ConvertToArray(GetHierarchyItems("4")));
            lst.AddRange(ConvertToArray(GetHierarchyItems("5")));
            lst.AddRange(ConvertToArray(GetHierarchyItems("6")));

            return lst;
        }

        private ListItem[] ConvertToArray (ListItemCollection lst)
        {
            ListItem[] finalLst = new ListItem[lst.Count];
            int i = 0;
            foreach (ListItem listItem in lst)
            {
                finalLst[i] = listItem;
                i++;
            }
            return finalLst;
        }

        public IList<CategoryBase> ListSearch(string search, Type type, CategoryBase parent, GridState gridState, out int records)
        {
            ICriteria crit = ListSearchCriteria(search, type, parent);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            records = crit.UniqueResult<int>();
            if (records == 0)
                return new List<CategoryBase>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, records);

            crit = ListSearchCriteria(search, type, parent);
            
            crit.SetMaxResults(gridState.PageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);

            crit.AddOrder(new Order("Type", true));
            crit.AddOrder(new Order("Parent", true));
            crit.AddOrder(new Order("ID", true));

            return crit.List<CategoryBase>();
        }

        private ICriteria ListSearchCriteria(string search, Type type, CategoryBase parent)
        {
            ICriteria crit = GetCriteria();
            if (type != null)
               crit = NHibernateSession.CreateCriteria(type);
            

            if (!string.IsNullOrEmpty(search))
            {
                Disjunction d = new Disjunction();
                d.Add(Expression.InsensitiveLike("Name", search, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("Description", search, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("NameEnglish", search, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("DescripionEnglish", search, MatchMode.Anywhere));
                crit.Add(d);
            }

            if (parent != null)
                crit.Add(Expression.Eq("Parent", parent));

            return crit;
        }

        public bool EraseCategory(int id)
        {
            CategoryBase cb = GetById(id);
            //check for sons ???
            if (!IsParent(cb) && !ControllerManager.PriceCalculation.HaveCategory(cb))
            {
                //ControllerManager.PriceCalculation.Delete(cb);
                Delete(cb);
                CommitChanges();
                NHibernateSession.Flush();
                
                return true;
            }
            return false;
        }

        public CategoryBase CreateCategory(Type type, CategoryBase parent, string name, string description, string nameEnglish, string descriptionEnglish, string observation)
        { 
            CategoryBase o = Activator.CreateInstance(type) as CategoryBase;
            
            o.Parent = parent;
            o.Name = name;
            o.Description = description;
            o.NameEnglish = nameEnglish;
            o.Observations = observation;
            o.DescripionEnglish = descriptionEnglish;
            o.CategoryPageStatus = CategoryPageStatus.Active;

            Save(o);
            return o;
        }

        public CategoryBase ModifyCategory(int id, CategoryBase parent, string name, string description, string nameEnglish, string descriptionEnglish, string observation)
        {
            CategoryBase cb = GetById(id);

            cb.Parent = parent;
            cb.Name = name;
            cb.Description = description;
            cb.NameEnglish = nameEnglish;
            cb.DescripionEnglish = descriptionEnglish;
            cb.Observations = observation;

            Save(cb);
            return cb;
        }

        public IList<PageTreeView> GetPagesTree(string type)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetToLevel");

            q.SetString("Type", type);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);
            q.SetInt32("FromDepth", 0);
            q.SetInt32("ToDepth", -1);
            
            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));
            
            return q.List<PageTreeView>();
        }

        public IList<PageTreeView> GetPagesTreeToLevel(string type, int toLevel, int fromDepth)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetToLevel");

            q.SetString("Type", type);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);
            q.SetInt32("FromDepth", fromDepth);
            q.SetInt32("ToDepth", toLevel);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));

            return q.List<PageTreeView>();
        }

        public IList<PageTreeView> GetPagesByPublishListTree(int pbl)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetByPublishListToLevel");

            q.SetString("Type", "2");
            q.SetInt32("PriceListId", pbl);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);
            q.SetInt32("FromDepth", 0);
            q.SetInt32("ToDepth", -1);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));

            return q.List<PageTreeView>();
        }

        public IList<PageTreeView> CategoryTreeGetByPublishListToLevel(int pbl, int toLevel, int fromDepth)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetByPublishListToLevel");

            q.SetString("Type", "2");
            q.SetInt32("PriceListId", pbl);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);
            q.SetInt32("FromDepth", fromDepth);
            q.SetInt32("ToDepth", toLevel);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));

            return q.List<PageTreeView>();
        }

        public IList<PageTreeView> GetPagesByPriceListTree(int pl)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetByPriceListToLevel");

            q.SetString("Type", "2");
            q.SetInt32("PriceListId", pl);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);
            q.SetInt32("FromDepth", 0);
            q.SetInt32("ToDepth", -1);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));

            return q.List<PageTreeView>();
        }


        public IList<PageTreeView> CategoryTreeGetByPriceListToLevel(int pl, int toLevel, int fromDepth)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetByPriceListToLevel");

            q.SetString("Type", "2");
            q.SetInt32("PriceListId", pl);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);
            q.SetInt32("FromDepth", fromDepth);
            q.SetInt32("ToDepth", toLevel);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));

            return q.List<PageTreeView>();
        }

        public int GetChildCount(int categoryId)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryGetChildCount");

            q.SetInt32("CategoryId", categoryId);

            return Convert.ToInt32(q.UniqueResult());
        }
    }

    public class CatalogPageController : AbstractNHibernateDao<CatalogPage, int>
    {
        public CatalogPageController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<CatalogPage> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<CatalogPage>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            return ControllerManager.CategoryBase.GetHierarchyItems("2");
        }

        public IList<CatalogPage> GetFirstLevelParents()
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.IsNull("Parent"));

            return crit.List<CatalogPage>();
        }

        public static CategoryBase CategoryConverter(CatalogPage f)
        {
            return (CategoryBase)f;
        }

        public IList<CatalogPage> ListLevelOnePages(string search, CatalogPage parent,CategoryPageStatus? status, GridState gridState, out int totalRecords)
        {
            ICriteria crit = ListLevelOnePagesCriteria(search, parent, status);
            crit.SetProjection(Projections.ProjectionList().Add(Projections.Count("ID")));

            totalRecords = crit.UniqueResult<int>();
            if (totalRecords == 0)
                return new List<CatalogPage>();

            int pageNumber = gridState.PageNumber;
            int pageSize = gridState.PageSize;
            pageNumber = Utils.AdjustPageNumber(pageNumber, pageSize, totalRecords);

            crit = ListLevelOnePagesCriteria(search, parent, status);

            crit.SetMaxResults(gridState.PageSize);
            if (pageNumber == 1)
                crit.SetFirstResult(0);
            else
                crit.SetFirstResult((pageNumber - 1) * gridState.PageSize);

            string[] sort = gridState.SortField.Split('.');

            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.CreateCriteria(sort[0], JoinType.LeftOuterJoin);
                sortField = sort[1];
            }

            critSort.AddOrder(new Order(sortField, gridState.SortAscending));

            return crit.List<CatalogPage>();
        }

        private ICriteria ListLevelOnePagesCriteria(string search, CatalogPage parent, CategoryPageStatus? status)
        {
            ICriteria crit = GetCriteria();

            if (!string.IsNullOrEmpty(search))
            {
                Disjunction d = new Disjunction();
                d.Add(Expression.InsensitiveLike("Name", search, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("Description", search, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("NameEnglish", search, MatchMode.Anywhere));
                d.Add(Expression.InsensitiveLike("DescripionEnglish", search, MatchMode.Anywhere));
                crit.Add(d);
            }

            if (parent != null)
                crit.Add(Expression.Eq("Parent", parent));
            if (status != null)
                crit.Add(Expression.Eq("CategoryPageStatus", status));

            DetachedCriteria levelOneCriteria = DetachedCriteria.For<CatalogPage>().SetProjection(Projections.Property("ID"))
            .Add(Expression.IsNull("Parent"));

            ICriterion levelOneSubquery = Subqueries.PropertyIn("Parent", levelOneCriteria);

            crit.Add(levelOneSubquery);

            return crit;
        }

        public void SetActivity(int id)
        {
            CatalogPage cp = GetById(id);
            if (cp.CategoryPageStatus == CategoryPageStatus.Active)
                cp.CategoryPageStatus = CategoryPageStatus.Disable;
            else
                cp.CategoryPageStatus = CategoryPageStatus.Active;

            Save(cp);
        }

        public IList<CatalogPage> GetPagesByFilters(GridState gridState, IList<Filters.IFilter> filters)
        {
            ICriteria crit = GetCriteria();
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            if (!string.IsNullOrEmpty(mpsp.Description))
            {
                Disjunction d = new Disjunction();
                d.Add(Restrictions.InsensitiveLike("Description", mpsp.Description, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("DescriptionAlternative", mpsp.Description, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("Name", mpsp.Description, MatchMode.Anywhere));
                d.Add(Restrictions.InsensitiveLike("NameAlternative", mpsp.Description, MatchMode.Anywhere));

                crit.Add(d);
            }
            if (mpsp.CatalogPage != null)
                crit.Add(Expression.Eq("Parent", mpsp.CatalogPage));

            if (mpsp.CategoryPageStatus != null)
                crit.Add(Expression.Eq("CategoryPageStatus", mpsp.CategoryPageStatus));

            DetachedCriteria levelOneCriteria = DetachedCriteria.For<CatalogPage>().SetProjection(Projections.Property("ID"))
            .Add(Expression.IsNull("Parent"));

            ICriterion levelOneSubquery = Subqueries.PropertyIn("Parent", levelOneCriteria);

            crit.Add(levelOneSubquery);

            string[] sort = gridState.SortField.Split('.');
            ICriteria critSort = crit;
            string sortField = gridState.SortField;
            if (!sortField.Contains("TimeStamp") && sort.Length > 1)
            {
                critSort = crit.GetCriteriaByPath(sort[0]);
                if (critSort == null)
                    critSort = crit.CreateCriteria(sort[0]);
                sortField = sort[1];
            }
            critSort.AddOrder(new Order(sortField, gridState.SortAscending));
            if (!gridState.MarkedAll)
                crit.Add(Expression.In("ID", gridState.Items));

            return crit.List<CatalogPage>();
        }

        //No es utilizado por el momento, en el caso de que no se utilize mas, puede ser borrado.
        public IList<PageTreeView> GetPagesWithOutPriceListTree(PriceList pl)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryTreeGetByPagesWithoutPriceList");

            q.SetString("Type", "2");
            q.SetInt32("PriceListId", pl.ID);
            q.SetInt32("CategoryId", 0);
            q.SetByte("FromRoot", 0);

            q.SetResultTransformer(new NHibernate.Transform.AliasToBeanConstructorResultTransformer(typeof(PageTreeView).GetConstructors()[1]));

            return q.List<PageTreeView>();
        }

        public int GetChildCount(int categoryId)
        {
            IQuery q = NHibernateSession.GetNamedQuery("CategoryGetChildCount");

            q.SetInt32("CategoryId", categoryId);

            return Convert.ToInt32( q.UniqueResult());
        }
        
}

    public class ProductTypeController : AbstractNHibernateDao<ProductType, int>
    {
        public ProductTypeController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<ProductType> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<ProductType>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            return ControllerManager.CategoryBase.GetHierarchyItems("3");
        }

        public static CategoryBase CategoryConverter(ProductType f)
        {
            return (CategoryBase)f;
        }
    }

    public class ApplicationController : AbstractNHibernateDao<Application, int>
    {
        public ApplicationController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Application> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<Application>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            return ControllerManager.CategoryBase.GetHierarchyItems("4");
        }

        public static CategoryBase CategoryConverter(Application f)
        {
            return (CategoryBase)f;
        }
    }

    public class FamilyController : AbstractNHibernateDao<Family, int>
    {
        public FamilyController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public new Family GetById(int id)
        {
            return (Family)NHibernateSession.Get(typeof(Family), id);
        }

        public bool Add(GridState gridState, IList<Filters.IFilter> filters, int newfamilyId)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);
            
            bool changed = ControllerManager.PriceBase.AddToCategory(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, null, null, gridState.MarkedAll, gridState.Items, mpsp.Currency, newfamilyId, null, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
            
            CommitChanges();

            if (changed)
            {
                IQuery q = NHibernateSession.GetNamedQuery("CategoryCountUpdate");
                q.SetInt32("CategoryId", newfamilyId);
                q.UniqueResult();

                ControllerManager.PriceCalculation.Run(mpsp, gridState, newfamilyId, true);
            }

            return changed;
        }

        public bool Remove(GridState gridState, IList<Filters.IFilter> filters, bool isProduct)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);
            return Remove(gridState, filters, (mpsp.Categories[1] as CatalogPage).ID, isProduct);
        }

        public bool Remove(GridState gridState, IList<Filters.IFilter> filters, int newfamilyId, bool isProduct)
        {
            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            bool changed = ControllerManager.PriceBase.RemoveFromCategory(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, null, null, gridState.MarkedAll, gridState.Items, mpsp.Currency, newfamilyId, null, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor, isProduct);

            CommitChanges();

            if (changed)
            {
                IQuery q = NHibernateSession.GetNamedQuery("CategoryCountUpdate");
                q.SetInt32("CategoryId", newfamilyId);
                q.UniqueResult();

                ControllerManager.PriceCalculation.Run(mpsp, gridState, newfamilyId, false);
            }

            return changed;
        }

        public IList<Family> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<Family>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            return ControllerManager.CategoryBase.GetHierarchyItems("1");
        }

        public static CategoryBase CategoryConverter(Family f)
        {
            return (CategoryBase) f;
        }
    }

    public class LineController : AbstractNHibernateDao<Line, int>
    {
        public LineController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Line> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<Line>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            return ControllerManager.CategoryBase.GetHierarchyItems("5");
        }

        public static Line CategoryConverter(Line f)
        {
            return (Line)f;
        }
    }

    public class AreaController : AbstractNHibernateDao<Area, int>
    {
        public AreaController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Area> List()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<Area>();
        }

        public ListItemCollection GetHierarchyItems()
        {
            return ControllerManager.CategoryBase.GetHierarchyItems("6");
        }

        public static Area CategoryConverter(Area f)
        {
            return (Area)f;
        }
    }
}