using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;
using NybbleMembership;

namespace PriceManager.Business.Filters
{
    public class CtrRangeFilter : DropDownFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(CtrRange); }
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
            
            base.OnLoad(e);
        }

        public override void Refresh()
        {
            DataSource = ControllerManager.CtrRange.GetAll();
            DataTextField = "Description";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Rango--", "0"));

            //this.ID = "ddlCtrRangeFilter";

            this.Visible = PermissionManager.Check(this);
        }

    }
}
