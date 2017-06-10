using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business.Actions
{
    public class AddToPagelistAction : JavascriptAnchorAction
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                JavascriptCode = "openAddPageListPopup();";

            base.OnLoad(e);
        }


        public override bool ExecuteAction(GridState gh, IList<PriceManager.Business.Filters.IFilter> filters, params object[] parameters)
        {
            if (parameters.Length != 1)
                throw new Exception("Expected Category ID.");


            int categoryId;

            if (!string.IsNullOrEmpty(parameters[0].ToString()))
                categoryId = Convert.ToInt32(parameters[0].ToString());
            else
                throw new Exception("No single parameter has value.");

            return ControllerManager.Family.Add(gh, filters, categoryId);

        }
    }
}
