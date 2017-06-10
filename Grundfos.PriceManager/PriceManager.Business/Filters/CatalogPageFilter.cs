using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Common;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class CatalogPageFilter : DropDownFilter
    {
        #region Abstract Members

        public override Type ClassName
        {
            get { return typeof(CatalogPage); }
        }

        public override string PropertyName
        {
            get { return "ID"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        private bool withOutPage;
        public bool WithOutPage
        {
            get { return withOutPage; }
            set { withOutPage = value; }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            // OnInit always refresh because we need it for setup on page.
            Refresh();
            base.OnInit(e);
        }

        public override void Refresh()
        {
            DataSource = ControllerManager.CatalogPage.GetHierarchyItems();
            DataTextField = "Text";
            DataValueField = "Value";
            DataBind();
            Items.Insert(0, new ListItem("--Página--", "0"));
            if(WithOutPage)
                Items.Add(new ListItem("--" + Resource.Business.GetString("WithOutCatalogPage") + "--", "-1"));
        }


        public CatalogPageFilter() {}
        public CatalogPageFilter(bool withoutpage)
        {
            this.withOutPage = withoutpage;
        }
    }
}
