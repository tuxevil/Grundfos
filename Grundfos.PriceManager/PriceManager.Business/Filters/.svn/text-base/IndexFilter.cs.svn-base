using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;
using NybbleMembership;

namespace PriceManager.Business.Filters
{
    public class IndexFilter : DropDownFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(IndexPrice); }
        }


        public override string PropertyName
        {
            get { return "ID"; }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }

            this.Visible = PermissionManager.Check(this);
            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = ControllerManager.IndexPrice.GetAll();
            DataTextField = "Description";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Index--", "0"));
        }

    }
}
