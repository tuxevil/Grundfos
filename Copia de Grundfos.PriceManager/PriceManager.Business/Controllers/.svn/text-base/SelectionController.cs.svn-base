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
    public class SelectionController : AbstractNHibernateDao<Selection, int>
    {
        public SelectionController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public IList<Selection> GetSelectionList(int pageNumber, out int count)
        {
            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Description", true));
            count = crit.List<Selection>().Count;

            if (pageNumber != 0)
            {
                crit.SetMaxResults(5);
            
                if (pageNumber > 1)
                    crit.SetFirstResult(5*(pageNumber - 1));
            }

            return crit.List<Selection>();
        }

        public bool Remove(bool Marked, List<string> SelectedItems, SearchParams param)
        {
            if (!(Marked || (!Marked && SelectedItems.Count > 0)))
                return false;

            Family tempfam;
            CtrRange tempctr;
            Selection tempsel;
            ProductType tempprodtype;
            Currency tempcurr;
            Family tempcat;

            GetSearchObjects(param, out tempfam, out tempctr, out tempsel, out tempprodtype, out tempcurr, out tempcat);

            if (ControllerManager.Product.GetProductListToRemove(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, param.SortColumn, param.SortOrder, Marked, SelectedItems, tempcurr))
            {
                if ((Marked) && (ControllerManager.Selection.CanRemove(tempsel.ID)))
                {
                    int selectionid = param.Selection;
                    param.Selection = 0;
                    ControllerManager.Selection.DeleteSelection(selectionid);
                }

                return true;
            }
            else 
                return false;
        }

        public void RemoveFromSelection (List<Product> prodlist, Selection selection)
        {
            foreach (Product proditem in prodlist)
            {
                {
                    proditem.Selections.Remove(selection);
                }
            }
            NHibernateSession.Flush();
        }

        public bool Add(bool Marked, List<string> SelectedItems, SearchParams param, string newselection, string selectionid, out string error, out int newselectionid)
        {
            error = string.Empty;
            newselectionid = 0;
            if (!(((!Marked) && (SelectedItems.Count > 0)) || (Marked)))
            {
                return false;
            }
            if (string.IsNullOrEmpty(newselection) && selectionid == "0")
                return false;

            Selection nuevaseleccion;
            if (!string.IsNullOrEmpty(newselection))
            {
                if (ControllerManager.Selection.CanCreate(newselection))
                {
                    MembershipUser usuario = Membership.GetUser();
                    Guid id = (Guid)usuario.ProviderUserKey;
                    nuevaseleccion = ControllerManager.Selection.CreateSelection(newselection, id);
                }
                else
                {
                    error = "Ya existe una selección con ese nombre";
                    return false;
                }
            }
            else
            {
                if (selectionid != "0")
                    nuevaseleccion = ControllerManager.Selection.GetById(Convert.ToInt32(selectionid));
                else
                    return false;
            }

            Family tempfam;
            CtrRange tempctr;
            Selection tempsel;
            ProductType tempprodtype;
            Currency tempcurr;
            Family tempcat;

            GetSearchObjects(param, out tempfam, out tempctr, out tempsel, out tempprodtype, out tempcurr, out tempcat);

            //TODO: Move to database processing, is vey expensive to do this kind of updates on several records that could be thousands.
            if (ControllerManager.Product.GetProductListToAdd(param.Description, tempfam, tempcat, tempctr, tempsel, tempprodtype, param.SortColumn, param.SortOrder, Marked, SelectedItems, tempcurr, nuevaseleccion))
            {
                newselectionid = nuevaseleccion.ID;
                return true;
            }
            else
                return false;
        }

        public void AddToSelection(List<Product> prodlist, Selection selection)
        {
            foreach (Product prod in prodlist)
            {
                {
                    prod.Selections.Add(selection);
                }
            }
        }

        public Selection CreateSelection (string description, Guid userid)
        {
            Selection newtemp = new Selection();
            newtemp.Description = description;
            Save(newtemp);
            return newtemp;
        }

        public void DeleteSelection (int selectionid)
        {
            Selection sel = GetById(selectionid);
            Delete(sel);
        }
    
        public bool CanCreate(string description)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Description", description));

            return crit.UniqueResult<Selection>() == null;
        }

        public bool CanRemove(int id)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ID", id));

            Selection tempsel = crit.UniqueResult<Selection>();
            return tempsel.Products.Count == 0;
        }

        public void GetSearchObjects(SearchParams param, out Family tempfam, out CtrRange tempctr, out Selection tempsel, out ProductType tempprodtype, out Currency tempcurr, out Family tempcat)
        {
            tempfam = ControllerManager.Family.GetById(param.Family);
            tempctr = ControllerManager.CtrRange.GetById(param.CtrRange);
            tempsel = ControllerManager.Selection.GetById(param.Selection);
            tempprodtype = (ProductType)param.ProductType;
            tempcurr = ControllerManager.Currency.GetById(param.Currency);
            tempcat = ControllerManager.Family.GetById(param.Category);
        }
    }
}