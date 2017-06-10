using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Core;
using PriceManager.Core.State;

namespace PriceManager.Business.Actions
{
    public class EraseFromCatalogPageAction : LinkButtonAction
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
                return ControllerManager.Family.Remove(gh, filters, true);
            }
            catch (CannotEraseFromPriceListException)
            {
                return false;
            }
        }
    }
}
