using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class ModifyPricesAction : JavascriptAnchorAction
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                JavascriptCode = "openChangePricePopupTotal();";

            base.OnLoad(e);
        }

        public override bool ExecuteAction(GridState gh, IList<IFilter> filters, params object[] parameters)
        {
            //TODO: Change To Custom Exception
            if (parameters.Length != 2)
            {
                Utils.ShowMessage(Page, "Se esperaba un % Valor y un % CTR.", Utils.MessageType.Error);
                //throw new Exception("Expected Value % and CTR %.");
            }

            string val = null;
            string ctr = null;
            


            if (!string.IsNullOrEmpty(parameters[0].ToString()))
                val = parameters[0].ToString();

            if (!string.IsNullOrEmpty(parameters[1].ToString()))
                ctr = parameters[1].ToString();
            

            if (string.IsNullOrEmpty(val) && string.IsNullOrEmpty(ctr))
            {
                Utils.ShowMessage(Page, "Ningun parametro tiene valor.", Utils.MessageType.Error);
                //throw new Exception("No single parameter has value.");
            }

            List<int> lst;
            
            if (!ControllerManager.PriceBase.Update(gh, filters, val, ctr, out lst))
            {
                Utils.ShowMessage(Page, lst.Count + " productos no se pudieron actualizar.", Utils.MessageType.Error);
                //throw new Exception(lst.Count.ToString() + " products couldn´t be updated");
            }

            return true;

        }
    }
}
