using System;
using System.Collections.Generic;
using System.Text;

namespace PriceManager.Business.Actions
{
    public class MoveToPricegroupAction : JavascriptAnchorAction
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                JavascriptCode = "openAddPricegoupPopup();";

            base.OnLoad(e);
        }


        public override bool ExecuteAction(GridState gh, IList<PriceManager.Business.Filters.IFilter> filters, params object[] parameters)
        {
            if (parameters.Length != 1)
                throw new Exception("Expected PriceGroup ID.");

            string pgId = string.Empty;

            if (!string.IsNullOrEmpty(parameters[0].ToString()))
                pgId = parameters[0].ToString();

            if (string.IsNullOrEmpty(pgId))
                throw new Exception("No single parameter has value.");

            return ControllerManager.PriceBase.AddToPriceGroup(gh, filters, pgId);
        }
    }
}
