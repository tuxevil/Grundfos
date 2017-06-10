using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class CatalogPageParentFilter : DropDownFilter
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
            get { return "Parent"; }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if(!Page.IsPostBack)
                Refresh();

            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = ControllerManager.CatalogPage.GetFirstLevelParents();
            DataTextField = "Name";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Padre--", "0"));
        }

    }
}
