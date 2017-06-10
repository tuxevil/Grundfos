using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Security;
using NHibernate.Mapping;
using NHibernate;
using NHibernate.Criterion;
using PriceManager.Core;
using ProjectBase.Data;
using NybbleMembership;


namespace PriceManager.Business
{
    public class SelectionController : AbstractNHibernateDao<Selection, int>
    {
        public SelectionController(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public Selection GetWithProducts(int id)
        {
            ICriteria crit = GetCriteria();
            crit.SetFetchMode("Products", FetchMode.Join);
            crit.Add(Expression.Eq("ID", id));
            return crit.UniqueResult<Selection>();
        }

        public new IList<Selection> GetAll()
        {
            MembershipHelperUser u = MembershipHelper.GetUser();

            ICriteria crit = GetCriteria();
            crit.AddOrder(new Order("Description", true));
            if (u != null)
                crit.Add(Expression.Eq("User", u.UserId));
            return crit.List<Selection>();
        }

        public bool Remove(GridState gridState, IList<Filters.IFilter> filters)
        {
            if (!gridState.IsAnyItemMarked)
                throw new NoItemMarkedException("No items has been marked");

            string order = "DESC";
            if (gridState.SortAscending)
                order= "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);

            if (ControllerManager.PriceBase.RemoveFromSelection(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gridState.SortField, order, gridState.MarkedAll, gridState.Items, mpsp.Currency, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor))
            {
                if ((gridState.MarkedAll) && (CanRemove(mpsp.Selection.ID)))
                {
                    ControllerManager.Selection.DeleteSelection(mpsp.Selection.ID);
                }

                return true;
            }
            else 
                return false;
        }

        public void RemoveFromSelection (List<int> prodlist, Selection selection)
        {
            List<Product> templst = new List<Product>(selection.Products);
            foreach (int proditem in prodlist)
                //selection.Products.Remove(new Product(proditem));
                {
                    Product prod = templst.Find(delegate(Product record)
                                                             {
                                                                 if (record.ID == proditem)
                                                                 {
                                                                     return true;
                                                                 }
                                                                 return false;
                                                             });
                    if (prod != null)
                        selection.Products.Remove(prod);
                }


            Save(selection);
            CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridState"></param>
        /// <param name="filters"></param>
        /// <param name="newselection"></param>
        /// <param name="selectionid"></param>
        /// <returns></returns>
        /// <exception cref="SelectionAlreadyExistException">Throws this exception when a selection already exist.</exception>
        public Selection Add(GridState gridState, IList<Filters.IFilter> filters, string newselection, int selectionid)
        {
            if (!gridState.IsAnyItemMarked)
                throw new NoItemMarkedException("No items has been marked");

            Selection nuevaseleccion;
            if (!string.IsNullOrEmpty(newselection))
            {
                if (!CanCreate(newselection))
                    throw new SelectionAlreadyExistException("Ya existe una selección con ese nombre");

                MembershipHelperUser usuario = MembershipHelper.GetUser();
                nuevaseleccion = ControllerManager.Selection.CreateSelection(newselection, usuario.UserId);
            }
            else
                nuevaseleccion = ControllerManager.Selection.GetWithProducts(selectionid);

            if (nuevaseleccion == null)
                return null;

            string order = "DESC";
            if (gridState.SortAscending)
                order = "ASC";

            MasterPriceSearchParameters mpsp = FilterHelper.GetSearchFilters(filters);
            ControllerManager.PriceBase.AddToSelection(mpsp.Description, mpsp.Categories, mpsp.CtrRange, mpsp.Selection, mpsp.Frequency, gridState.SortField, order, gridState.MarkedAll, gridState.Items, mpsp.Currency, nuevaseleccion, mpsp.PriceGroup, mpsp.Provider, mpsp.SearchDate, mpsp.PriceBaseStatus, mpsp.ProductStatus, mpsp.IndexPrice, mpsp.SearchDateTo, mpsp.PriceImport, mpsp.PriceList, mpsp.WorkListItemStatus, mpsp.PublishList, mpsp.Distributor);
            return nuevaseleccion;
        }

        public void AddToSelection(List<int> prodlist, Selection selection)
        {
            foreach (int productId in prodlist)
                selection.Products.Add(new Product(productId));

            Save(selection);
            CommitChanges();
        }

        public Selection CreateSelection (string description, Guid userid)
        {
            Selection newtemp = new Selection();
            newtemp.Description = description;
            newtemp.User = userid;
            Save(newtemp);
            return newtemp;
        }

        public void DeleteSelection (int selectionid)
        {
            Selection sel = GetById(selectionid);
            Delete(sel);
        }
    
        private bool CanCreate(string description)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("Description", description));

            return crit.UniqueResult<Selection>() == null;
        }

        private bool CanRemove(int id)
        {
            ICriteria crit = GetCriteria();
            crit.Add(Expression.Eq("ID", id));

            Selection tempsel = crit.UniqueResult<Selection>();
            return tempsel.Products.Count == 0;
        }

    }
}