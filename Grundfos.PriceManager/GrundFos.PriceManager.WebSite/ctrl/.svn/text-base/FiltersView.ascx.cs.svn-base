using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PriceManager.Business;
using PriceManager.Business.Filters;
using PriceManager.Common;
using PriceManager.Core;
using System.Collections.Generic;

namespace GrundFos.PriceManager.WebSite.ctrl
{
    public partial class FiltersView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                UpdateState(GetCurrentFilters());

            // Always recreate dynamic controls on PostBack
            CreateCurrentFilters();
        }

        public void AddFilter(Control filter)
        {
            plhFilters.Controls.Add(filter);
        }

        public IFilter FindFilter(Type className, string property)
        {
            return FilterHelper.FindFilter(plhFilters.Controls, className, property);
        }

        public IFilter FindFilterSelection()
        {
            return FilterHelper.FindFilter(GetFiltersApplied(), typeof(Selection), "ID");
        }

        public void Refresh()
        {
            foreach (IFilter f in plhFilters.Controls)
                f.Refresh();
        }

        public List<IFilter> GetFiltersApplied()
        {
            if (ViewState["FiltersApplied"] != null)
                return ReadState() as List<IFilter>;

            return GetCurrentFilters();
        }

        private List<IFilter> GetCurrentFilters()
        {
            List<IFilter> filters = new List<IFilter>();

            foreach (IFilter filter in plhFilters.Controls)
                if (filter.HasValue)
                    filters.Add(filter);

            return filters;
        }

        private void CreateCurrentFilters()
        {
            CreateCurrentFilters(this.GetCurrentFilters());
        }

        private void CreateCurrentFilters(IList<IFilter> filters)
        {
            plhCurrentFilters.Controls.Clear();

            foreach (IFilter f in filters)
            {
                if (f is FixedFilter)
                    continue;

                //Add Last Filters to plhCurrentFilters
                FilterLinkButton fl = new FilterLinkButton();
                fl.ID = "flb" + f.ClassName + f.FilterName;
                fl.LinkText = string.Format("{0} : <b>{1}</b>", Resource.Business.GetString(f.ID), StringFormat.Cut(f.TextValue.ToString().Replace((char)160, ' ').Trim(), 29));
                fl.RelatedFilterID = f.ID.ToString();
                fl.Click += Link_Click;
                plhCurrentFilters.Controls.Add(fl);
            }

            if (plhCurrentFilters.Controls.Count == 0)
                lblFilterText.Text = "No hay ningún filtro activo.";
            else
                lblFilterText.Text = "Se encuentra filtrando por:";
        }

        protected void lnkCleanFilters_Click(object sender, EventArgs e)
        {
            foreach(IFilter f in plhFilters.Controls)
                f.Clear();
        }

        protected void Link_Click (object sender, EventArgs e)
        {
            FilterLinkButton flb = (FilterLinkButton)sender;

            List<IFilter> lst = GetFiltersApplied();
            foreach (IFilter f in lst)
                if (f.ID.ToString() == flb.RelatedFilterID.ToString())
                    f.Clear();

            UpdateState(lst);
            plhCurrentFilters.Controls.Remove(flb);

            if (plhCurrentFilters.Controls.Count == 0)
                lblFilterText.Text = "No hay ningún filtro activo.";

            SearchAppliedOnly();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "flip", "<Script> flip_filters(); </Script>", false);
            Search();
        }

        protected void SearchAppliedOnly()
        {
            List<IFilter> filters = this.GetFiltersApplied();
            OnFilter(new FilterEventArgs(filters));
        }

        protected void Search()
        {
            List<IFilter> filters = GetCurrentFilters();
            UpdateState(filters);
            CreateCurrentFilters(filters);
            OnFilter(new FilterEventArgs(filters));
        }

        private void UpdateState(IList<IFilter> filters)
        {
            SearchParameters searchParameters = FilterHelper.GetSerchParameters(filters);
            ViewState["FiltersApplied"] = searchParameters;
        }

        private IList<IFilter> ReadState()
        {
            SearchParameters searchParameters = (SearchParameters)ViewState["FiltersApplied"];
            IList<IFilter> lst = FilterHelper.GetFiltersState(this.plhFilters.Controls, searchParameters);
            CreateCurrentFilters(lst);
            return lst;
        }

        #region OnFilter Event Methods

        public event FilterEventHandler FilterClick;
        protected virtual void OnFilter(FilterEventArgs e)
        {
            if (FilterClick != null)
                FilterClick(this, e);
        }

        #endregion
    }
}