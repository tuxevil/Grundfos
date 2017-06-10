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
using ProjectBase.Utils.Cache;


namespace PriceManager.Business
{
    public class FamilyController : AbstractNHibernateDao<Family, int>
    {
        public FamilyController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Family> GetCategoryList(int parentid)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Parent", parentid));
            crit.AddOrder(new Order("Name", true));
            return crit.List<Family>();
        }

        public List<Family> GetCategoryList()
        {
            ICriteria crit = GetCriteria();
            crit.Add(new NotExpression(new OrExpression(new OrExpression(Expression.Eq("ID", 1),Expression.Eq("ID",2)),new OrExpression(Expression.Eq("Parent", 1),Expression.Eq("Parent",2)))));
            crit.AddOrder(new Order("Name", true));
            return crit.List<Family>() as List<Family>;
        }

        public bool IsParent(Family family)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Parent", family.ID));
            return ((crit.List<Family>().Count > 0) ? true : false ); 
  
        }

        public List<Family> GetChildrens (Family parent)
        {
            List<Family> children = CacheManager.GetCached("cat" + parent.ID.ToString()) as List<Family>;
            if (children != null)
                return children;

            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Parent", parent.ID));
            children = crit.List<Family>() as List<Family>;

            CacheManager.AddItem("cat" + parent.ID.ToString(), children);
            return children;
        }

        public List<Family> FindChildrensOrSelf(Family family)
        {
            List<Family> children = null;
            
            if (family != null)
            {
                children = CacheManager.GetCached("hier" + family.ID.ToString()) as List<Family>;
                if (children != null)
                    return children;

                if (IsParent(family))
                    children = GetChildrens(family, children);
                else
                {
                    children = new List<Family>();
                    children.Add(family);
                }

                CacheManager.AddItem("hier" + family.ID.ToString(), children);
            }


            return children;
        }

        public void AddFamily(Family family, string name, string description)
        {
            Family f = new Family();

            if (family != null)
                f.Parent = family.ID;
            else
                f.Parent = 0;

            f.Name = name;
            f.Description = description;
            
            Save(f);
        }

        public void Modify(Family family, string name, string description)
        {
            if (family != null)
            {
                family.Name = name;
                family.Description = description;
                
                Save(family);
            }
        }

        public void AddtoFamily(List<Product> prodlist, Family f)
        {
            foreach(Product prod in prodlist)
                  prod.Families.Add(f);
        }

        public void EraseFromFamily(List<Product> prodlist, Family f)
        {
            foreach (Product prod in prodlist)
                prod.Families.Remove(f);
        }

        public bool IsFamilyMember(Product p, Family f)
        {
            ICriteria crit = GetCriteria();
            ICriteria product = crit.CreateCriteria("Products");
            crit.Add(Expression.Eq("ID", f.ID));
            product.Add(Expression.Eq("ID", p.ID));
            return ((crit.List<Family>().Count > 0) ? true : false); 
        }

        public List<Family> GetAllFamily()
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Name", true));
            return crit.List<Family>() as List<Family>;
        }

        public List<Family> GetChildrens(Family parent, List<Family> parentandchildrens)
        {
            if (parentandchildrens == null)
                parentandchildrens = new List<Family>();

            parentandchildrens.Add(parent);

            List<Family> tempchildrens = ControllerManager.Family.GetChildrens(parent);
            foreach (Family tempchildren in tempchildrens)
                GetChildrens(tempchildren, parentandchildrens);

            return parentandchildrens;
        }

        private ListItemCollection GetChildrens(List<Family> familylist, Family family, int level, ListItemCollection familydisplay)
        {
            string tabulation = "";

            for (int i = 1; i <= level; i++)
            {
                tabulation = tabulation.Insert(0, new String((char)160, 10));
            }
            tabulation = tabulation.Insert(tabulation.Length, " ");


            List<Family> tempchildrens = familylist.FindAll(delegate(Family record)
                                                             {
                                                                 if (record.Parent == family.ID)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            level++;
            foreach (Family tempchildren in tempchildrens)
            {
                ListItem li = new ListItem(tabulation + tempchildren.Name, tempchildren.ID.ToString());
                familydisplay.Add(li);
                GetChildrens(familylist, tempchildren, level, familydisplay);
            }
            return familydisplay;
        }

        public ListItemCollection GetListItemCollection(List<Family> categorylist)
        {
            ListItemCollection familydisplay = new ListItemCollection();

            List<Family> templist = categorylist.FindAll(delegate(Family record)
                                                             {
                                                                 if (record.Parent == 0)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
            foreach (Family family in templist)
            {
                ListItem li = new ListItem(family.Name, family.ID.ToString());
                familydisplay.Add(li);
                familydisplay = GetChildrens(categorylist, family, 1, familydisplay);
            }

            return familydisplay;
        }

        public bool Add(bool Marked, List<string> selecteditems, SearchParams param, Family newfamily)
        {
            Family tempfam;
            CtrRange tempctr;
            Selection tempsel;
            ProductType tempprodtype;
            Currency tempcurr;
            Family tempcat;

            ControllerManager.Selection.GetSearchObjects(param, out tempfam, out tempctr, out tempsel, out tempprodtype, out tempcurr, out tempcat);

            if(ControllerManager.Product.GetProductListToAdd(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, null, null,  (Marked), selecteditems, tempcurr, newfamily))
                return true;
            return false;

        }

        public bool Remove(bool Marked, List<string> selecteditems, SearchParams param, Family newfamily)
        {
            Family tempfam;
            CtrRange tempctr;
            Selection tempsel;
            ProductType tempprodtype;
            Currency tempcurr;
            Family tempcat;

            ControllerManager.Selection.GetSearchObjects(param, out tempfam, out tempctr, out tempsel, out tempprodtype, out tempcurr, out tempcat);

            if(ControllerManager.Product.GetProductListToRemove(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, null, null, (Marked), selecteditems, tempcurr, newfamily))
                return true;
            return false;
        }
    }
}