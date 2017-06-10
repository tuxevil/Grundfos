using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;
using NybbleMembership;

namespace PriceManager.Business.Filters
{
    public class PriceImportFilter: DropDownFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(PriceImport); }
        }

        public override string FilterName
        {
            get { return PropertyName; }
        }

        public override string PropertyName
        {
            get { return "ID"; }
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
            DataSource = ControllerManager.PriceImport.GetByStatus(ImportStatus.Processed, "TimeStamp.CreatedOn");
            DataTextField = "Description";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Archivo de Importación--", "0"));

            this.Visible = PermissionManager.Check(this);
        }

    }
}
