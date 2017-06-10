using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using PriceManager.Core;

namespace PriceManager.Business.Filters
{
    public class CurrencyFilter : DropDownFilter
    {
        #region IFilter Members

        public override Type ClassName
        {
            get { return typeof(Currency); }
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
            DataSource = ControllerManager.Currency.GetAll();
            DataTextField = "Description";
            DataValueField = "ID";
            DataBind();
            Items.Insert(0, new ListItem("--Moneda--", "0"));
        }
    }
}
