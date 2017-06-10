using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class MoveToPriceListAction : JavascriptAnchorAction
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                JavascriptCode = "openAddToPriceListPopup();";

            base.OnLoad(e);
        }

        public override bool ExecuteAction(GridState gh, IList<PriceManager.Business.Filters.IFilter> filters, params object[] parameters)
        {
            if (parameters.Length != 3)
            {
                Utils.ShowMessage(Page, "Se esperaba una lista de precios nueva o vieja y una moneda.", Utils.MessageType.Error);
                //throw new ParameterMismatchException("Expected New Price List, Price List ID and Currency.");
            }

            string priceListName = string.Empty;
            int priceListId = 0;
            int currencyId = 0;

            if (!string.IsNullOrEmpty(parameters[0].ToString()))
                priceListName = parameters[0].ToString();

            if (!string.IsNullOrEmpty(parameters[1].ToString()))
                priceListId = Convert.ToInt32(parameters[1]);

            if (!string.IsNullOrEmpty(parameters[2].ToString()))
                currencyId = Convert.ToInt32(parameters[2]);

            if (string.IsNullOrEmpty(priceListName) && priceListId == 0 && currencyId == 0)
            {
                Utils.ShowMessage(Page, "Ningún parametro tenia valor.", Utils.MessageType.Error);
                //throw new ParameterMismatchException("No single parameter has value.");
            }

            try 
            {
                ControllerManager.PriceList.AddItemsFromPriceGroup(gh, filters, priceListName, priceListId, currencyId);
                return true;
            }
            catch (PriceListAlreadyExistException ex) 
            {
                Utils.ShowMessage(Page, ex.Message, Utils.MessageType.Error);
                return false;
            }
        }
    }
}
