using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class MoveToSelectionAction : JavascriptAnchorAction
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                JavascriptCode = "openAddSelectionPopup();";

            base.OnLoad(e);
        }

        public override bool ExecuteAction(GridState gh, IList<PriceManager.Business.Filters.IFilter> filters, params object[] parameters)
        {
            if (parameters.Length != 2)
                throw new ParameterMismatchException("Expected New Selection, Selection ID.");

            string selectionName = string.Empty;
            int selectionId = 0;

            if (!string.IsNullOrEmpty(parameters[0].ToString()))
                selectionName = parameters[0].ToString();

            if (!string.IsNullOrEmpty(parameters[1].ToString()))
                selectionId = Convert.ToInt32(parameters[1]);

            if (string.IsNullOrEmpty(selectionName) && selectionId == 0)
                throw new ParameterMismatchException("No single parameter has value.");

            try 
            {
                ControllerManager.Selection.Add(gh, filters, selectionName, selectionId);
                return true;
            }
            catch( SelectionAlreadyExistException) 
            {
                return false;
            }
        }
    }
}
