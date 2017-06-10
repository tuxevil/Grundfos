using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class EraseFromPriceListAction : LinkButtonAction
    {
        protected override void OnInit(EventArgs e)
        {
            ShouldConfirm = true;
            base.OnInit(e);
        }

        public override bool ExecuteAction(GridState gh, IList<PriceManager.Business.Filters.IFilter> filters, params object[] parameters)
        {
            try
            {
                ControllerManager.PriceList.RemoveItemsFromPriceList(gh, filters);
                return true;
            }
            catch (CannotEraseFromPriceListException )
            {
                return false;
            }
        }
    }
}
