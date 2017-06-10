using System;
using System.Collections.Generic;
using System.Text;
using PriceManager.Business.Filters;
using PriceManager.Core;

namespace PriceManager.Business.Actions
{
    public class RejectPriceListItemsAction : LinkButtonAction
    {
        protected override void OnInit(EventArgs e)
        {
            ShouldConfirm = true;
            base.OnInit(e);
        }

        public override bool ExecuteAction(GridState gs, IList<IFilter> filters, params object[] parameters)
        {
            try
            {
                ControllerManager.PriceList.RejectItems(gs, filters);
                return true;
            }
            catch (CannotApproveRejectPriceListItemsException)
            {
                return false;
            }
        }
    }
}
