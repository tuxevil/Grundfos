using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;

namespace PriceManager.Business.Actions
{
    public class SaveQuoteAction : LinkButtonAction
    {
        protected override void OnInit(EventArgs e)
        {
            ShouldConfirm = false;
            base.OnInit(e);
        }

        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {
            try
            {
                //ControllerManager.Quote.AddItems(gs, filters, 0);
                return true;
            }
            catch (CannotApproveRejectPriceListItemsException)
            {
                return false;
            }
        }
    }
}
