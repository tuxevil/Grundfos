using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;

namespace PriceManager.Business.Actions
{
    public class AddDistributorsToPriceListAction : JavascriptAnchorAction
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                JavascriptCode = "openAddToPriceListPopup();";

            base.OnLoad(e);
        }

        public override bool ExecuteAction(GridState gh, IList<PriceManager.Business.Filters.IFilter> filters, params object[] parameters)
        {
            if (parameters.Length != 1)
            {
                Utils.ShowMessage(Page, "Se esperaba una lista de precios.", Utils.MessageType.Error);
                //throw new ParameterMismatchException("Expected New Price List, Price List ID and Currency.");
            }

            int priceListId = 0;


            if (!string.IsNullOrEmpty(parameters[0].ToString()))
                priceListId = Convert.ToInt32(parameters[0]);

            if (priceListId == 0)
            {
                Utils.ShowMessage(Page, "Ningún parametro tenia valor.", Utils.MessageType.Error);
                //throw new ParameterMismatchException("No single parameter has value.");
            }

            try 
            {
                ControllerManager.Distributor.AddToPriceList(gh, filters, priceListId);
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
